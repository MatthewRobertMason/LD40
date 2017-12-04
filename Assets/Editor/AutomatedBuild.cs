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
            "Assets/Levels/donut-donut-donut.unity",
            "Assets/Levels/long.unity",
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
        options.locationPathName = "Build/Testing/WebGL";

        BuildPipeline.BuildPlayer(options);
    }

    public static void BuildWebGL()
    {
        BuildPlayerOptions options = new BuildPlayerOptions();
        options.scenes = GetLevels();

        options.targetGroup = BuildTargetGroup.WebGL;
        options.target = BuildTarget.WebGL;
        options.locationPathName = "Build/Jam/WebGL";

        BuildPipeline.BuildPlayer(options);
    }
}