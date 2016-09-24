# ZenGarden
ZenGarden WinForms App - a small winforms app

I would like to deploy it to the windows app store using the desktop app converter.

I am using the latest version from the windows app store with the following parameters.

DesktopAppConverter -Installer C:\Temp\ZenGarden\Setup.exe -InstallerArguments "/quiet" -Destination C:\Temp\Output\ZenGarden -PackageName "ZenGarden2D" -Publisher "CN=S.Albert" -Version 1.0.0.0 -MakeAppx -Verbose -AppExecutable "C:\Program Files\S.Albert\Zen Garden 2D\ZenGarden.exe"

Signing:

signtool.exe sign -f SAlbert.pfx -fd SHA256 -v .\ZenGarden\ZenGarden2D\ZenGarden2D.appx

I am still facing some issues...

