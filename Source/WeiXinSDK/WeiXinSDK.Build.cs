// Copyright 1998-2017 Epic Games, Inc. All Rights Reserved.

using UnrealBuildTool;
using System.IO;

public class WeiXinSDK : ModuleRules
{
	public WeiXinSDK(ReadOnlyTargetRules Target) : base(Target)
	{
		PCHUsage = ModuleRules.PCHUsageMode.UseExplicitOrSharedPCHs;
		
		PublicIncludePaths.AddRange(
			new string[] {
				"WeiXinSDK/Public"
				// ... add public include paths required here ...
			}
			);
				
		
		PrivateIncludePaths.AddRange(
			new string[] {
				"WeiXinSDK/Private",
				// ... add other private include paths required here ...
			}
			);
			
		
		PublicDependencyModuleNames.AddRange(
			new string[]
			{
				"Core",
                "CoreUObject",
                "Engine",
				"Projects"
				// ... add other public dependencies that you statically link with here ...
			}
			);
			
		
		PrivateDependencyModuleNames.AddRange(
			new string[]
			{
				// ... add private dependencies that you statically link with here ...	
			}
			);
		
		
		DynamicallyLoadedModuleNames.AddRange(
			new string[]
			{
				// ... add any modules that your module loads dynamically here ...
			}
			);

        if (Target.Platform == UnrealTargetPlatform.Android)
        {
            PrivateDependencyModuleNames.AddRange(new string[] 
            {
                "Launch"
            });
        }

        if (Target.Platform == UnrealTargetPlatform.IOS)
        {
            var LibDir = Path.Combine(ModuleDirectory, "..", "..", "lib", "iOS");
            PrivateIncludePaths.Add(LibDir);

            PrivateIncludePaths.Add(Path.Combine(ModuleDirectory, "..", "ThirdParty", "iOS"));

            PublicAdditionalLibraries.Add(Path.Combine(LibDir, "libWeChatSDK.a"));


            PublicFrameworks.AddRange(
                new string[]
                {
                    "SystemConfiguration",
                    "CoreTelephony",
                    "CFNetwork"
                }
            );

            // libz.tdb
            PublicAdditionalLibraries.Add("z");
            // libsqlite3.0.tdb
            PublicAdditionalLibraries.Add("sqlite3.0");
            // libc++.tdb
            PublicAdditionalLibraries.Add("c++");
            
            //string PluginPath = Utils.MakePathRelativeTo(ModuleDirectory, BuildConfiguration.RelativeEnginePath);
            //AdditionalPropertiesForReceipt.Add(new ReceiptProperty("IOSPlugin", Path.Combine(PluginPath, "WeiXinSDK_IPL.xml")));
        }
        else if (Target.Platform == UnrealTargetPlatform.Android)
        {
            string PluginPath = Utils.MakePathRelativeTo(ModuleDirectory, BuildConfiguration.RelativeEnginePath);
            AdditionalPropertiesForReceipt.Add(new ReceiptProperty("AndroidPlugin", Path.Combine(PluginPath, "WeiXinSDK_APL.xml")));
        }
    }
}
