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
		private global::Windows.UI.Xaml.NameScope __nameScope = new global::Windows.UI.Xaml.NameScope();
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
				// Source 0\MainPage.xaml (Line 10:3)
				Children = 
				{
					new global::Windows.UI.Xaml.Controls.TextBox
					{
						IsParsing = true,
						// Source 0\MainPage.xaml (Line 11:4)
					}
					.MainPage_d6cd66944958ced0c513e0a04797b51d_XamlApply((MainPage_d6cd66944958ced0c513e0a04797b51dXamlApplyExtensions.XamlApplyHandler0)(c0 => 
					{
						global::Windows.UI.Xaml.Controls.ToolTipService.SetToolTip(c0, 
							null						);
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
				// Class TestRepro.MainPage
				global::Uno.UI.FrameworkElementHelper.SetBaseUri(c3, __baseUri_MainPage_d6cd66944958ced0c513e0a04797b51d);
				c3.CreationComplete();
			}
			))
			;
			OnInitializeCompleted();

		}
		partial void OnInitializeCompleted();
	}
}
namespace MyProject
{
	static class MainPage_d6cd66944958ced0c513e0a04797b51dXamlApplyExtensions
	{
		public delegate void XamlApplyHandler0(global::Windows.UI.Xaml.Controls.TextBox instance);
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public static global::Windows.UI.Xaml.Controls.TextBox MainPage_d6cd66944958ced0c513e0a04797b51d_XamlApply(this global::Windows.UI.Xaml.Controls.TextBox instance, XamlApplyHandler0 handler)
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