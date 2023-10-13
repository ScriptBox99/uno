﻿// <autogenerated />
#pragma warning disable CS0114
#pragma warning disable CS0108
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Uno.UI;
using Uno.UI.Xaml;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Shapes;
using Windows.UI.Text;
using Uno.Extensions;
using Uno;
using Uno.UI.Helpers;
using Uno.UI.Helpers.Xaml;
using MyProject;

#if __ANDROID__
using _View = Android.Views.View;
#elif __IOS__
using _View = UIKit.UIView;
#elif __MACOS__
using _View = AppKit.NSView;
#else
using _View = Windows.UI.Xaml.UIElement;
#endif

namespace TestRepro
{
	partial class MainPage : global::Windows.UI.Xaml.Controls.Page
	{
		[global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
		private const string __baseUri_prefix_MainPage_d6cd66944958ced0c513e0a04797b51d = "ms-appx:///TestProject/";
		[global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
		private const string __baseUri_MainPage_d6cd66944958ced0c513e0a04797b51d = "ms-appx:///TestProject/";
		global::Windows.UI.Xaml.NameScope __nameScope = new global::Windows.UI.Xaml.NameScope();
		private void InitializeComponent()
		{
			NameScope.SetNameScope(this, __nameScope);
			var __that = this;
			base.IsParsing = true;
			// Source 0\MainPage.xaml (Line 1:2)
			base.Content = 
			new global::Windows.UI.Xaml.Controls.Grid
			{
				IsParsing = true,
				// Source 0\MainPage.xaml (Line 11:3)
				Children = 
				{
					new global::Windows.UI.Xaml.Controls.TextBlock
					{
						IsParsing = true,
						// Source 0\MainPage.xaml (Line 12:4)
					}
					.MainPage_d6cd66944958ced0c513e0a04797b51d_XamlApply((MainPage_d6cd66944958ced0c513e0a04797b51dXamlApplyExtensions.XamlApplyHandler0)(c0 => 
					{
						/* _isTopLevelDictionary:False */
						__that._component_0 = c0;
						c0.SetBinding(
							global::Windows.UI.Xaml.Controls.TextBlock.TextProperty,
							new Windows.UI.Xaml.Data.Binding()
							{
								Mode = BindingMode.OneTime,
							}
								.BindingApply(___b =>  /*defaultBindModeOneTime MyArray.Length*/ global::Uno.UI.Xaml.BindingHelper.SetBindingXBindProvider(___b, __that, ___ctx => ___ctx is global::TestRepro.MainPage ___tctx ? (TryGetInstance_xBind_1(___tctx, out var bindResult1) ? (true, bindResult1) : (false, default)) : (false, default), null ))
						);
						global::Uno.UI.FrameworkElementHelper.SetBaseUri(c0, __baseUri_MainPage_d6cd66944958ced0c513e0a04797b51d);
						c0.CreationComplete();
					}
					))
					,
				}
			}
			.MainPage_d6cd66944958ced0c513e0a04797b51d_XamlApply((MainPage_d6cd66944958ced0c513e0a04797b51dXamlApplyExtensions.XamlApplyHandler1)(c1 => 
			{
				global::Uno.UI.FrameworkElementHelper.SetBaseUri(c1, __baseUri_MainPage_d6cd66944958ced0c513e0a04797b51d);
				c1.CreationComplete();
			}
			))
			;
			
			this
			.GenericApply(((c2) => 
			{
				// Source 0\MainPage.xaml (Line 1:2)
				
				// WARNING Property c2.base does not exist on {http://schemas.microsoft.com/winfx/2006/xaml/presentation}Page, the namespace is http://www.w3.org/XML/1998/namespace. This error was considered irrelevant by the XamlFileGenerator
			}
			))
			.GenericApply(((c3) => 
			{
				/* _isTopLevelDictionary:False */
				__that._component_1 = c3;
				// Class TestRepro.MainPage
				global::Uno.UI.ResourceResolverSingleton.Instance.ApplyResource(c3, global::Windows.UI.Xaml.Controls.Page.BackgroundProperty, "ApplicationPageBackgroundThemeBrush", isThemeResourceExtension: true, isHotReloadSupported: false, context: global::MyProject.GlobalStaticResources.__ParseContext_);
				global::Uno.UI.FrameworkElementHelper.SetBaseUri(c3, __baseUri_MainPage_d6cd66944958ced0c513e0a04797b51d);
				c3.CreationComplete();
			}
			))
			;
			OnInitializeCompleted();

			Bindings = new MainPage_Bindings(this);
			Loading += (s, e) => 
			{
				__that.Bindings.Update();
				__that.Bindings.UpdateResources();
			}
			;
		}
		partial void OnInitializeCompleted();
		private global::Windows.UI.Xaml.Markup.ComponentHolder _component_0_Holder  = new global::Windows.UI.Xaml.Markup.ComponentHolder(isWeak: true);
		private global::Windows.UI.Xaml.Controls.TextBlock _component_0
		{
			get
			{
				return (global::Windows.UI.Xaml.Controls.TextBlock)_component_0_Holder.Instance;
			}
			set
			{
				_component_0_Holder.Instance = value;
			}
		}
		private global::Windows.UI.Xaml.Markup.ComponentHolder _component_1_Holder  = new global::Windows.UI.Xaml.Markup.ComponentHolder(isWeak: true);
		private global::Windows.UI.Xaml.Controls.Page _component_1
		{
			get
			{
				return (global::Windows.UI.Xaml.Controls.Page)_component_1_Holder.Instance;
			}
			set
			{
				_component_1_Holder.Instance = value;
			}
		}
		private interface IMainPage_Bindings
		{
			void Initialize();
			void Update();
			void UpdateResources();
			void StopTracking();
		}
		#pragma warning disable 0169 //  Suppress unused field warning in case Bindings is not used.
		private IMainPage_Bindings Bindings;
		#pragma warning restore 0169
		[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
		private class MainPage_Bindings : IMainPage_Bindings
		{
			#if UNO_HAS_UIELEMENT_IMPLICIT_PINNING
			private global::System.WeakReference _ownerReference;
			private global::TestRepro.MainPage Owner { get => (global::TestRepro.MainPage)_ownerReference?.Target; set => _ownerReference = new global::System.WeakReference(value); }
			#else
			private global::TestRepro.MainPage Owner { get; set; }
			#endif
			public MainPage_Bindings(global::TestRepro.MainPage owner)
			{
				Owner = owner;
			}
			void IMainPage_Bindings.Initialize()
			{
			}
			void IMainPage_Bindings.Update()
			{
				var owner = Owner;
				owner._component_0.ApplyXBind();
			}
			void IMainPage_Bindings.UpdateResources()
			{
				var owner = Owner;
				owner._component_0.UpdateResourceBindings();
				owner._component_1.UpdateResourceBindings();
			}
			void IMainPage_Bindings.StopTracking()
			{
			}
		}
		private static bool TryGetInstance_xBind_1(global::TestRepro.MainPage ___tctx, out object o)
		{
			o = null;
			var sub1 = ___tctx.MyArray;
			if (sub1 == null) return false;
			o = sub1.Length;
			return true;
		}
	}
}
namespace MyProject
{
	static class MainPage_d6cd66944958ced0c513e0a04797b51dXamlApplyExtensions
	{
		public delegate void XamlApplyHandler0(global::Windows.UI.Xaml.Controls.TextBlock instance);
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public static global::Windows.UI.Xaml.Controls.TextBlock MainPage_d6cd66944958ced0c513e0a04797b51d_XamlApply(this global::Windows.UI.Xaml.Controls.TextBlock instance, XamlApplyHandler0 handler)
		{
			handler(instance);
			return instance;
		}
		public delegate void XamlApplyHandler1(global::Windows.UI.Xaml.Controls.Grid instance);
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public static global::Windows.UI.Xaml.Controls.Grid MainPage_d6cd66944958ced0c513e0a04797b51d_XamlApply(this global::Windows.UI.Xaml.Controls.Grid instance, XamlApplyHandler1 handler)
		{
			handler(instance);
			return instance;
		}
	}
}
