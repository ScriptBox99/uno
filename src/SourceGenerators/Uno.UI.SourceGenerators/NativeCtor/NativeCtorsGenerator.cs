﻿#nullable enable

using System;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Uno.UI.SourceGenerators.Helpers;
using System.Diagnostics;
using Uno.Extensions;

#if NETFRAMEWORK
using Uno.SourceGeneration;
#endif

namespace Uno.UI.SourceGenerators.NativeCtor
{
	[Generator]
#if NETFRAMEWORK
	[GenerateAfter("Uno.UI.SourceGenerators.XamlGenerator." + nameof(XamlGenerator.XamlCodeGenerator))]
#endif
	public class NativeCtorsGenerator : ISourceGenerator
	{
		public void Initialize(GeneratorInitializationContext context)
		{
			DependenciesInitializer.Init();
		}

		public void Execute(GeneratorExecutionContext context)
		{
			if (!DesignTimeHelper.IsDesignTime(context))
			{

				var visitor = new SerializationMethodsGenerator(context);
				visitor.Visit(context.Compilation.SourceModule);
			}
		}

		private class SerializationMethodsGenerator : SymbolVisitor
		{ 
			private readonly GeneratorExecutionContext _context; 
			private readonly INamedTypeSymbol? _iosViewSymbol;
			private readonly INamedTypeSymbol? _objcNativeHandleSymbol;
			private readonly INamedTypeSymbol? _macosViewSymbol;
			private readonly INamedTypeSymbol? _androidViewSymbol;
			private readonly INamedTypeSymbol? _intPtrSymbol;
			private readonly INamedTypeSymbol? _jniHandleOwnershipSymbol;
			private readonly INamedTypeSymbol?[]? _javaCtorParams;

			public SerializationMethodsGenerator(GeneratorExecutionContext context)
			{
				_context = context;

				_iosViewSymbol = context.Compilation.GetTypeByMetadataName("UIKit.UIView");
				_objcNativeHandleSymbol = context.Compilation.GetTypeByMetadataName("ObjCRuntime.NativeHandle");
				_macosViewSymbol = context.Compilation.GetTypeByMetadataName("AppKit.NSView");
				_androidViewSymbol = context.Compilation.GetTypeByMetadataName("Android.Views.View");
				_intPtrSymbol = context.Compilation.GetTypeByMetadataName("System.IntPtr");
				_jniHandleOwnershipSymbol = context.Compilation.GetTypeByMetadataName("Android.Runtime.JniHandleOwnership");
				_javaCtorParams = new[] { _intPtrSymbol, _jniHandleOwnershipSymbol };
			}

			public override void VisitNamedType(INamedTypeSymbol type)
			{
				_context.CancellationToken.ThrowIfCancellationRequested();

				foreach (var t in type.GetTypeMembers())
				{
					VisitNamedType(t);
				}

				ProcessType(type);
			}

			public override void VisitModule(IModuleSymbol symbol)
			{
				_context.CancellationToken.ThrowIfCancellationRequested();

				VisitNamespace(symbol.GlobalNamespace);
			}

			public override void VisitNamespace(INamespaceSymbol symbol)
			{
				_context.CancellationToken.ThrowIfCancellationRequested();

				foreach (var n in symbol.GetNamespaceMembers())
				{
					VisitNamespace(n);
				}

				foreach (var t in symbol.GetTypeMembers())
				{
					VisitNamedType(t);
				}
			}

			private void ProcessType(INamedTypeSymbol typeSymbol)
			{
				var isiOSView = typeSymbol.Is(_iosViewSymbol);
				var ismacOSView = typeSymbol.Is(_macosViewSymbol);
				var isAndroidView = typeSymbol.Is(_androidViewSymbol);

				if (isiOSView || ismacOSView)
				{
					Func<IMethodSymbol, bool> predicate = m =>
						!m.Parameters.IsDefaultOrEmpty
						&& (
							SymbolEqualityComparer.Default.Equals(m.Parameters[0].Type, _intPtrSymbol)
							|| SymbolEqualityComparer.Default.Equals(m.Parameters[0].Type, _objcNativeHandleSymbol));

					var nativeCtor = GetNativeCtor(typeSymbol, predicate, considerAllBaseTypes: false);

					if (nativeCtor == null && GetNativeCtor(typeSymbol.BaseType, predicate, considerAllBaseTypes: true) != null)
					{
						_context.AddSource(
							HashBuilder.BuildIDFromSymbol(typeSymbol),
							GetGeneratedCode(typeSymbol));
					}
				}

				if (isAndroidView)
				{
					Func<IMethodSymbol, bool> predicate = m => m.Parameters.Select(p => p.Type).SequenceEqual(_javaCtorParams ?? Array.Empty<ITypeSymbol?>());
					var nativeCtor = GetNativeCtor(typeSymbol, predicate, considerAllBaseTypes: false);

					if (nativeCtor == null && GetNativeCtor(typeSymbol.BaseType, predicate, considerAllBaseTypes: true) != null)
					{
						_context.AddSource(
							HashBuilder.BuildIDFromSymbol(typeSymbol),
							GetGeneratedCode(typeSymbol));
					}
				}

				string GetGeneratedCode(INamedTypeSymbol typeSymbol)
				{
					var builder = new IndentedStringBuilder();
					builder.AppendLineInvariant("// <auto-generated>");
					builder.AppendLineInvariant("// *************************************************************");
					builder.AppendLineInvariant("// This file has been generated by Uno.UI (NativeCtorsGenerator)");
					builder.AppendLineInvariant("// *************************************************************");
					builder.AppendLineInvariant("// </auto-generated>");
					builder.AppendLine();
					builder.AppendLineInvariant("using System;");
					builder.AppendLine();
					var disposables = typeSymbol.AddToIndentedStringBuilder(builder, beforeClassHeaderAction: builder =>
					{
						// These will be generated just before `partial class ClassName {`
						builder.Append("#if __IOS__ || __MACOS__");
						builder.AppendLine();
						builder.AppendLineInvariant("[global::Foundation.Register]");
						builder.Append("#endif");
						builder.AppendLine();
					});

					var syntacticValidSymbolName = SyntaxFacts.GetKeywordKind(typeSymbol.Name) == SyntaxKind.None ? typeSymbol.Name : "@" + typeSymbol.Name;

					if (NeedsExplicitDefaultCtor(typeSymbol))
					{
						builder.AppendLineInvariant("/// <summary>");
						builder.AppendLineInvariant("/// Initializes a new instance of the class.");
						builder.AppendLineInvariant("/// </summary>");
						builder.AppendLineInvariant($"public {syntacticValidSymbolName}() {{{{ }}}}");
						builder.AppendLine();
					}

					builder.Append("#if __ANDROID__");
					builder.AppendLine();
					builder.AppendLineInvariant("/// <summary>");
					builder.AppendLineInvariant("/// Native constructor, do not use explicitly.");
					builder.AppendLineInvariant("/// </summary>");
					builder.AppendLineInvariant("/// <remarks>");
					builder.AppendLineInvariant("/// Used by the Xamarin Runtime to materialize native ");
					builder.AppendLineInvariant("/// objects that may have been collected in the managed world.");
					builder.AppendLineInvariant("/// </remarks>");
					builder.AppendLineInvariant($"public {syntacticValidSymbolName}(IntPtr javaReference, global::Android.Runtime.JniHandleOwnership transfer) : base (javaReference, transfer) {{{{ }}}}");
					builder.Append("#endif");
					builder.AppendLine();

					builder.Append("#if __IOS__ || __MACOS__ || __MACCATALYST__");
					builder.AppendLine();
					builder.AppendLineInvariant("/// <summary>");
					builder.AppendLineInvariant("/// Native constructor, do not use explicitly.");
					builder.AppendLineInvariant("/// </summary>");
					builder.AppendLineInvariant("/// <remarks>");
					builder.AppendLineInvariant("/// Used by the Xamarin Runtime to materialize native ");
					builder.AppendLineInvariant("/// objects that may have been collected in the managed world.");
					builder.AppendLineInvariant("/// </remarks>");
					builder.AppendLineInvariant($"public {syntacticValidSymbolName}(IntPtr handle) : base (handle) {{{{ }}}}");

					if(_objcNativeHandleSymbol != null)
					{
						builder.AppendLineInvariant("/// <summary>");
						builder.AppendLineInvariant("/// Native constructor, do not use explicitly.");
						builder.AppendLineInvariant("/// </summary>");
						builder.AppendLineInvariant("/// <remarks>");
						builder.AppendLineInvariant("/// Used by the .NET Runtime to materialize native ");
						builder.AppendLineInvariant("/// objects that may have been collected in the managed world.");
						builder.AppendLineInvariant("/// </remarks>");
						builder.AppendLineInvariant($"public {syntacticValidSymbolName}(global::ObjCRuntime.NativeHandle handle) : base (handle) {{{{ }}}}");
					}

					builder.Append("#endif");
					builder.AppendLine();

					while (disposables.Count > 0)
					{
						disposables.Pop().Dispose();
					}

					return builder.ToString();
				}

				static IMethodSymbol? GetNativeCtor(INamedTypeSymbol? type, Func<IMethodSymbol, bool> predicate, bool considerAllBaseTypes)
				{
					// Consider:
					// Type A -> Type B -> Type C
					// HasCtor   NoCtor    NoCtor
					// We want to generate the ctor for both Type B and Type C
					// But since the generator doesn't guarantee Type B is getting processed first,
					// We need to check the inheritance hierarchy.
					// However, assume Type B wasn't declared in source, we can't generate the ctor for it.
					// Consequently, Type C shouldn't generate source as well.
					if (type is null)
					{
						return null;
					}

					var ctor = type.GetMembers(WellKnownMemberNames.InstanceConstructorName).Cast<IMethodSymbol>().FirstOrDefault(predicate);
					if (ctor != null || !considerAllBaseTypes || !type.Locations.Any(l => l.IsInSource))
					{
						return ctor;
					}
					else
					{
						return GetNativeCtor(type.BaseType, predicate, true);
					}
				}
			}

			private static bool NeedsExplicitDefaultCtor(INamedTypeSymbol typeSymbol)
			{
				var hasExplicitConstructor = typeSymbol
					.GetMembers(WellKnownMemberNames.InstanceConstructorName)
					.Any(m => m is IMethodSymbol { IsImplicitlyDeclared: false, Parameters: { Length: 0 } });
				if (hasExplicitConstructor)
				{
					return false;
				}

				var baseHasDefaultCtor = typeSymbol
					.BaseType?
					.GetMembers(WellKnownMemberNames.InstanceConstructorName)
					.Any(m => m is IMethodSymbol { Parameters: { Length: 0 } }) ?? false;
				return baseHasDefaultCtor;
			}
		}
	}
}

