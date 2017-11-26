using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class AutomatedBuild : MonoBehaviour
{
    public static void BuildWebGLTest()
    {
        BuildPlayerOptions options = new BuildPlayerOptions();
        options.scenes = new string[] {
            "Assets/main.unity"
        };

        options.targetGroup = BuildTargetGroup.WebGL;
        options.target = BuildTarget.WebGL;
        options.locationPathName = "Build/Testing/WebGL";

        BuildPipeline.BuildPlayer(options);
    }

    public static void BuildWebGL()
    {
        BuildPlayerOptions options = new BuildPlayerOptions();
        options.scenes = new string[] {
            "Assets/main.unity"
        };

        options.targetGroup = BuildTargetGroup.WebGL;
        options.target = BuildTarget.WebGL;
        options.locationPathName = "Build/Jam/WebGL";

        BuildPipeline.BuildPlayer(options);
    }
}