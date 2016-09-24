# ZenGarden
ZenGarden WinForms App - a small winforms app

I would like to deploy it to the windows app store using the desktop app converter.

I am using the latest version from the windows app store with the following parameters.
DesktopAppConverter -Installer C:\Temp\ZenGarden\Setup.exe -InstallerArguments "/quiet" -Destination C:\Temp\Output\ZenGarden -PackageName "ZenGarden2D" -Publisher "CN=S.Albert" -Version 1.0.0.0 -MakeAppx -Verbose -AppExecutable "C:\Program Files\S.Albert\Zen Garden 2D\ZenGarden.exe"
Signing:
signtool.exe sign -f SAlbert.pfx -fd SHA256 -v .\ZenGarden\ZenGarden2D\ZenGarden2D.appx

I am still facing the following issues:

 Package acceptance validation error: The PublisherDisplayName element in the app manifest of ZenGarden2D.appx is CN=S.Albert, which doesn't match your publisher display name: S.Albert.
Package acceptance validation error: You don't have permissions to specify the following namespaces in the appx manifest file of the package ZenGarden2D.appx: http://schemas.microsoft.com/appx/manifest/foundation/windows10/restrictedcapabilities
Package acceptance validation error: Your developer account doesn’t have permission to submit apps converted with the Desktop App Converter at this time.

Because you’ve selected the Games category for this app, you must complete the concept approval process before you can publish a submission targeting the Xbox device family. Learn more 