---
uid: Uno.UI.CommonIssues.AllIDEs
---

# Issues related to all development environments

## Could not resolve SDK "Uno.Sdk"

This error may happen for multiple reasons:

- Ensure that all [NuGet feeds are authenticated properly](https://learn.microsoft.com/nuget/consume-packages/consuming-packages-authenticated-feeds). When building on the command line, some enterprise NuGet feeds may not be authenticated properly.
- Ensure that no global package mappings are interfering with nuget restore. To validate that no package mappings are set, on Windows for Visual Studio 2022:
  - Make a backup copy of `%AppData%\NuGet\NuGet.Config`
  - Open a visual studio instance that does not have any solution opened
  - Go to **Tools**, **Options**, **NuGet Package Manager**, then **Package Source Mappings**
  - If there are entries in the list, click then click **Remove All**

Try building your project again.

## Runtime error `No parameterless constructor defined for XXXX`

This error is generally caused by some missing [IL Linker](https://github.com/mono/linker/tree/master/docs) configuration on WebAssembly. You may need to add some of your application assemblies in the LinkerConfig.xml file of your project. You can find [additional information in the documentation](features/using-il-linker-webassembly.md).

Similar error messages using various libraries:

- `Don't know how to detect when XXX is activated/deactivated, you may need to implement IActivationForViewFetcher` (ReactiveUI)

## `Layout cycle detected` exception

Layout cycle means that the measuring of a specific part of the visual tree couldn't get stabilized. For example, during an element `Arrange` pass, its measure was invalidated, then it's measured again then arranged, and the app will fall into a layout cycle.

Uno Platform and WinUI run this loop for 250 iterations. If the loop hasn't stabilized, the app will fail with an exception with the message `Layout cycle detected`. This error is sometimes tricky to debug, you can set `Microsoft.UI.Xaml.DebugSettings.LayoutCycleTracingLevel = Microsoft.UI.Xaml.LayoutCycleTracingLevel.High` in order to get additional troubleshooting information printed out in the app's logs. For more information, see also [LayoutCycleTracingLevel in Microsoft Docs](https://learn.microsoft.com/windows/windows-app-sdk/api/winrt/microsoft.ui.xaml.debugsettings.layoutcycletracinglevel). Note that what Uno Platform logs may be quite different from what WinUI logs.

When the last 10 iterations out of 150 are reached, we will start logging some information as warnings. Those logs are prefixed with `[LayoutCycleTracing]` and include information such as when an element is measured or arranged, and when measure or arrange is invalidated.

One possible cause of layout cycle is incorrect usage of `LayoutUpdated` event. This event isn't really tied to a specific `FrameworkElement` and is fired whenever any element changes its layout in the visual tree. So, using this event to add or remove an element to the visual tree can lead to layout cycle. The simplest example is having XAML similar to the following

```xaml
<StackPanel x:Name="sp" LayoutUpdated="sp_LayoutUpdated" />
```

and code behind:

```csharp
private void sp_LayoutUpdated(object sender, object e)
{
    sp.Children.Add(new Button() { Content = "Button" });
}
```

In this case, when `LayoutUpdated` is first fired, you add a new child to the `StackPanel` which will cause visual tree root to have its measure invalidated, then `LayoutUpdated` gets fired again, causing visual tree root to have its measured invalidated again, and so on. This ends up causing a layout cycle.

## Cannot build with both Uno.WinUI and Uno.UI NuGet packages referenced

This issue generally happens when referencing an Uno.UI (using UWP APIs) NuGet package in an application that uses Uno.WinUI (Using WinAppSDK APIs).

For instance, if your application has `<PackageReference Include="Uno.WinUI"` in the `csproj` files, this means that you'll need to reference WinUI versions of NuGet packages.

For instance:

- `Uno.UI` -> `Uno.WinUI`

## Abnormally long build times when using Roslyn analyzers

It is a good practice to use Roslyn analyzers to validate your code during compilation, but some generators may have difficulty handling the source generated by the Uno Platform (one notable example is [GCop](https://github.com/Geeksltd/GCop)). You may need to disable those for Uno projects or get an update from the analyzer's vendor.

## Android Warning XA4218

When building for Android, the following messages may happen:

```text
obj\Debug\net8.0-android\android\AndroidManifest.xml : warning XA4218: Unable to find //manifest/application/uses-library at path: C:\Program Files (x86)\Android\android-sdk\platforms\android-34\optional\androidx.window.extensions.jar
obj\Debug\net8.0-android\android\AndroidManifest.xml : warning XA4218: Unable to find //manifest/application/uses-library at path: C:\Program Files (x86)\Android\android-sdk\platforms\android-34\optional\androidx.window.sidecar.jar
```

Those messages are from a [known .NET for Android issue](https://github.com/xamarin/xamarin-android/issues/6809) and can be ignored as they are not impacting the build output.