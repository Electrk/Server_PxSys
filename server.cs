$PxSys::Version = 1;

$PxSys::Default::AppName    = "My Application";
$PxSys::Default::AppVersion = 1;
$PxSys::Default::BrickGroup = BrickGroup_888888;
$PxSys::HasBrickScreen      = false;

exec ("./utility.cs");
exec ("./miscellaneous.cs");
exec ("./screen/screen.cs");
exec ("./tcp/tcp.cs");
