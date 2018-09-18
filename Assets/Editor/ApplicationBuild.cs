using System.Collections.Generic;
using System.Linq;
using UnityEditor;

public static class ApplicationBuild
{
    private static List<string> _levels;
    private static BuildOptions _buildOptions = BuildOptions.None;

    private static string[] _debugScenes = new[]
    {
        "Assets/Scenes/DebugScene.unity",
    };

    public static void AndroidBuild()
    {
        _levels = EditorBuildSettings.scenes
            .Where(scene => scene.enabled)
            .Select(scene => scene.path)
            .ToList();
        ResolveCommandLineArgs();
        BuildPipeline.BuildPlayer(_levels.ToArray(), "./application.apk", BuildTarget.Android, _buildOptions);
    }

    private static void ResolveCommandLineArgs()
    {
        foreach (var command in System.Environment.GetCommandLineArgs())
        {
            switch (command)
            {
                case "-development":
                    _buildOptions = BuildOptions.Development;
                    _levels.AddRange(_debugScenes);
                    break;
            }
        }
    }
}
