using System.Linq;
using UnityEditor;

public static class ApplicationBuild
{
    private static BuildOptions _buildOptions = BuildOptions.None;

    public static void AndroidBuild()
    {
        var levels = EditorBuildSettings.scenes
            .Where(scene => scene.enabled)
            .Select(scene => scene.path)
            .ToArray();
        ResolveCommandLineArgs();
        BuildPipeline.BuildPlayer(levels, "./application.apk", BuildTarget.Android, _buildOptions);
    }

    private static void ResolveCommandLineArgs()
    {
        foreach (var command in System.Environment.GetCommandLineArgs())
        {
            switch (command)
            {
                case "-development":
                    _buildOptions = BuildOptions.Development;
                    break;
            }
        }
    }
}
