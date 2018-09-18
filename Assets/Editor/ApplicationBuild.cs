using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;

public static class ApplicationBuild
{
    private static List<string> _levels;
    private static BuildOptions _buildOptions = BuildOptions.None;
    private static readonly string debugSceneDirectory = $"./Assets/Scenes/Debug";

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
        var commands = System.Environment.GetCommandLineArgs();
        foreach (var command in commands)
        {
            switch (command)
            {
                case "-development":
                    _buildOptions = BuildOptions.Development;
                    var debugScenes = Directory.GetFiles(debugSceneDirectory, "*.unity", SearchOption.TopDirectoryOnly);
                    _levels.AddRange(debugScenes);
                    break;
            }
        }
    }
}
