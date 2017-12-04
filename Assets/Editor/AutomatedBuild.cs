using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class AutomatedBuild : MonoBehaviour
{
    public static string[] GetLevels()
    {
        return new string[]
        {
            "Assets/Levels/MainMenu.unity",
            "Assets/Levels/long.unity",
            "Assets/Levels/donut-donut-donut.unity",
            "Assets/Levels/loops.unity",
            "Assets/Levels/donutDrop.unity",
            "Assets/Levels/small.unity"
        };
    }

    public static void BuildWebGLTest()
    {
        BuildPlayerOptions options = new BuildPlayerOptions();
        options.scenes = GetLevels();

        options.targetGroup = BuildTargetGroup.WebGL;
        options.target = BuildTarget.WebGL;
        options.locationPathName = "Build/Testing/WebGL/WebGL";

        BuildPipeline.BuildPlayer(options);
    }

    public static void BuildWebGL()
    {
        BuildPlayerOptions options = new BuildPlayerOptions();
        options.scenes = GetLevels();

        options.targetGroup = BuildTargetGroup.WebGL;
        options.target = BuildTarget.WebGL;
        options.locationPathName = "Build/Jam/WebGL/WebGL";

        BuildPipeline.BuildPlayer(options);
    }

    public static void BuildWindows()
    {
        BuildPlayerOptions options = new BuildPlayerOptions();
        options.scenes = GetLevels();

        options.targetGroup = BuildTargetGroup.Standalone;
        options.target = BuildTarget.StandaloneWindows;
        options.locationPathName = "Build/Jam/Windows/Windows.exe";

        BuildPipeline.BuildPlayer(options);
    }

    public static void BuildMac()
    {
        BuildPlayerOptions options = new BuildPlayerOptions();
        options.scenes = GetLevels();

        options.targetGroup = BuildTargetGroup.Standalone;
        options.target = BuildTarget.StandaloneOSXUniversal;
        options.locationPathName = "Build/Jam/Mac/Mac";

        BuildPipeline.BuildPlayer(options);
    }

    public static void BuildLinux()
    {
        BuildPlayerOptions options = new BuildPlayerOptions();
        options.scenes = GetLevels();

        options.targetGroup = BuildTargetGroup.Standalone;
        options.target = BuildTarget.StandaloneLinuxUniversal;
        options.locationPathName = "Build/Jam/Linux/Linux.x86";

        BuildPipeline.BuildPlayer(options);
    }
}