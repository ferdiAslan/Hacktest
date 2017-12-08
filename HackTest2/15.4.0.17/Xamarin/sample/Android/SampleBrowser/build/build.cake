#addin nuget:?package=Cake.HockeyApp&version=0.6.0
#addin nuget:?package=Cake.Xamarin&version=1.3.0.15
#addin nuget:?package=Cake.FileHelpers&version=1.0.4
using System.Diagnostics;
using System.Xml.Linq;
using System.IO;
using System.Text;
using System.Net;
using System.Text.RegularExpressions;

//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");
var API_TOKEN = Argument<string>("apitoken");
var apkLocation = "";

Task("Build")
.Does(()=>
{   	
    
	if(!System.IO.Directory.Exists("../packages"))
		System.IO.Directory.CreateDirectory("../packages");

	SetVersionCode();	
	CopyFileToDirectory("../build/cipackages.config" , "../");
	CopyFileToDirectory("../SampleBrowser-Android_2017.sln" , "../build");
	CopyFileToDirectory("../SampleBrowser_2017.csproj" , "../build");
		 
	if(FileExists("../SampleBrowser_2017.csproj"))
		DeleteFile("../SampleBrowser_2017.csproj");
	if(FileExists("../SampleBrowser-Android_2017.sln"))
		DeleteFile("../SampleBrowser-Android_2017.sln");
	
	if(FileExists("../packages.config"))
		DeleteFile("../packages.config");
	
	System.IO.File.Move("../cipackages.config", "../packages.config");
	
	NuGetUpdate(@"..\SampleBrowser-Android_2015.sln" , new NuGetUpdateSettings {
	Source = new List<string>{"http://nexus.syncfusion.com/repository/nuget-hosted/"}	
	});
	
	EnsureDirectoryExists("../cireports/warnings/");
	EnsureDirectoryExists("../cireports/errorlogs/");
	RunBatFile();
	MSBuild(@"..\SampleBrowser-Android_2015.sln", settings =>
          settings.SetConfiguration(configuration).
          AddFileLogger(new MSBuildFileLogger { LogFile = "../cireports/warnings/SampleBrowser-Android_2015.txt",  MSBuildFileLoggerOutput = MSBuildFileLoggerOutput.WarningsOnly }).
          AddFileLogger(new MSBuildFileLogger { LogFile = "../cireports/errorlogs/SampleBrowser-Android_2015.txt", MSBuildFileLoggerOutput = MSBuildFileLoggerOutput.ErrorsOnly}).
          WithProperty("AndroidLinkMode", "None"));	  
		  		  
	CopyFileToDirectory("../build/SampleBrowser-Android_2017.sln" , "../");
	CopyFileToDirectory("../build/SampleBrowser_2017.csproj" , "../");
	
	if(FileExists("../SampleBrowser_2015.csproj"))
		DeleteFile("../SampleBrowser_2015.csproj");
	if(FileExists("../SampleBrowser-Android_2015.sln"))
		DeleteFile("../SampleBrowser-Android_2015.sln");
	
	if(FileExists("../packages.config"))
		DeleteFile("../packages.config");
		
	CopyFileToDirectory("../build/cipackages.config" , "../");
	
	System.IO.File.Move("../cipackages.config", "../packages.config");	
	
    NuGetUpdate(@"..\SampleBrowser-Android_2017.sln" , new NuGetUpdateSettings {
	Source = new List<string>{"http://nexus.syncfusion.com/repository/nuget-hosted/"}	
	});
	
	MSBuild(@"..\SampleBrowser-Android_2017.sln", settings =>
          settings.SetConfiguration(configuration).
          AddFileLogger(new MSBuildFileLogger { LogFile = "../cireports/warnings/SampleBrowser-Android_2017.txt",  MSBuildFileLoggerOutput = MSBuildFileLoggerOutput.WarningsOnly }).
          AddFileLogger(new MSBuildFileLogger { LogFile = "../cireports/errorlogs/SampleBrowser-Android_2017.txt", MSBuildFileLoggerOutput = MSBuildFileLoggerOutput.ErrorsOnly}).
          WithProperty("AndroidLinkMode", "None"));	
		  
	if(FileExists("../cireports/errorlogs/SampleBrowser-Android_2015.txt"))
      DeleteFile("../cireports/errorlogs/SampleBrowser-Android_2015.txt");
	if(FileExists("../cireports/errorlogs/SampleBrowser-Android_2017.txt"))
      DeleteFile("../cireports/errorlogs/SampleBrowser-Android_2017.txt");
	  
	StartProcess("cmd" , new ProcessSettings { Arguments = "/c adb kill-server" });

});

public void SetVersionCode()
{
	HttpWebRequest webRequest = HttpWebRequest.CreateHttp("https://rink.hockeyapp.net/api/2/apps/6c20520cead54b08a138e0dfd0920da6/app_versions");
    webRequest.Headers.Add("X-HockeyAppToken", "bc28e49134394f2880ed3383ba7da1d7");
    Stream stream = webRequest.GetResponse().GetResponseStream();
    string result;
    using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
    {
        result = reader.ReadToEnd();
    }
	
	string sPattern = "(?<=\"version\":\").*?(?=\")";
    var matchedVersion = Regex.Match(result, sPattern);
	int version = 0;
    int.TryParse(matchedVersion.Value, out version);

    XDocument xmlFile = XDocument.Load("../Properties/AndroidManifest.xml");
    var query = from c in xmlFile.Elements("manifest") select c;
    foreach (XElement element in query)
    {
		XNamespace androidNamespace =  "http://schemas.android.com/apk/res/android";
        element.Attribute(androidNamespace+"versionCode").Value = (version+1).ToString();
    }
    xmlFile.Save("../Properties/AndroidManifest.xml");
}

public void RunBatFile()
{
	try
	{
		Information("Running BAT file...");
		Process process = new Process();
		var currentDirectory = MakeAbsolute(Directory("../"));
		process.StartInfo.WorkingDirectory = currentDirectory.FullPath;
		process.StartInfo.FileName = "cmd.exe";
		process.StartInfo.Arguments = "/c CopyFilesFromCommon.bat";
		process.Start();
		process.WaitForExit();
		process.Close();
		process.Dispose();
		Information("Successfully files copied from common location.");
	}
	catch(Exception ex)
	{
		Information("Failed to copy files from common location.");
	}
}

Task("CreateAPK")
.Does(()=>
{
   apkLocation = AndroidPackage(@"..\SampleBrowser_2017.csproj", true, null).ToString();
});

public string GetAndroidCommitLogs()
{
	var files =	GetFiles("../packages/**/*releasenotes.txt");
	string controlName;
	string androidCommits ="";
	foreach(var file in files)
	{
		controlName = file.FullPath.Substring(file.FullPath.IndexOf("Xamarin") + 8);
		controlName = controlName.Split('.').First();
		var creationTime = System.IO.File.GetLastWriteTime(file.FullPath);
	    IEnumerable<string> logs = System.IO.File.ReadAllLines(file.FullPath);
		bool canAddControlName = true;
		foreach(var log in logs)
		{
			string logWithoutSpace = log.Replace(" ", String.Empty);
			if(logWithoutSpace.Contains("[Android") || logWithoutSpace.Contains(",Android,") || logWithoutSpace.Contains(",Android]"))
			{
				if(canAddControlName)
					androidCommits = androidCommits + "\n \n" + controlName + " [" + creationTime.ToString("MM-dd-yyyy hh:mm tt") + "]";
				androidCommits = androidCommits + "\n" + log;
				canAddControlName = false;
			}
		}
	}
	
    string commitLog = System.IO.File.ReadAllText("../cireports/releasenotes/releasenotes.txt");
	commitLog = "SampleBrowser" +"\n" + commitLog + androidCommits;
	return commitLog;
}

Task("Publish")
.IsDependentOn("CreateAPK")
.Does(()=>
{
	HockeyAppUploadResult result = UploadToHockeyApp(apkLocation, new HockeyAppUploadSettings 
	{
		ApiToken = API_TOKEN,
		ReleaseType = ReleaseType.Beta,
        Notes = GetAndroidCommitLogs(),
		Notify = NotifyOption.AllTesters,
		Status = Cake.HockeyApp.DownloadStatus.Allowed
    });
	
	EnsureDirectoryExists("../cireports/publish");
	FileWriteText("../cireports/publish/publish.txt", "APK Location: " + result.PublicUrl.ToString());
	
	StartProcess("cmd" , new ProcessSettings { Arguments = "/c adb kill-server" });

});

Task("Default")
    .IsDependentOn("Publish");

RunTarget(target);
