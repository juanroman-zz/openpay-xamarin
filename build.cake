#addin nuget:?package=Cake.Android.SdkManager

var TARGET = Argument ("target", Argument ("t", "Default"));
var VERSION = EnvironmentVariable ("APPVEYOR_BUILD_VERSION") ?? Argument("version", "0.0.9999");
var CONFIG = Argument("configuration", EnvironmentVariable ("CONFIGURATION") ?? "Release");
var SLN = "./src/Openpay.Xamarin.sln";

var ANDROID_HOME = EnvironmentVariable ("ANDROID_HOME") ?? Argument ("android_home", "");

Task("Libraries").Does(()=>
{
	NuGetRestore (SLN);
	MSBuild (SLN, c => {
		c.Configuration = CONFIG;
		c.MSBuildPlatform = Cake.Common.Tools.MSBuild.MSBuildPlatform.x86;
	});
});

Task ("NuGet")
	.IsDependentOn ("AndroidSDK")
	.IsDependentOn ("Libraries")
	.Does (() =>
{
    if(!DirectoryExists("./Build/nuget/"))
        CreateDirectory("./Build/nuget");
        
	NuGetPack ("./nuget/API.nuspec", new NuGetPackSettings { 
		Version = VERSION,
		OutputDirectory = "./Build/nuget/",
		BasePath = "./"
	});	
});

Task ("AndroidSDK")
	.Does (() =>
{
	Information ("ANDROID_HOME: {0}", ANDROID_HOME);

	var androidSdkSettings = new AndroidSdkManagerToolSettings { 
		SdkRoot = ANDROID_HOME,
		SkipVersionCheck = true
	};

	try { AcceptLicenses (androidSdkSettings); } catch { }

	AndroidSdkManagerInstall (new [] { 
			"platforms;android-15",
			"platforms;android-23",
			"platforms;android-25",
			"platforms;android-26"
		}, androidSdkSettings);
});

//Build the component, which build samples, nugets, and libraries
Task ("Default").IsDependentOn("NuGet");

Task ("Clean").Does (() => 
{
	CleanDirectory ("./component/tools/");
	CleanDirectories ("./Build/");
	CleanDirectories ("./**/bin");
	CleanDirectories ("./**/obj");
});

RunTarget (TARGET);
