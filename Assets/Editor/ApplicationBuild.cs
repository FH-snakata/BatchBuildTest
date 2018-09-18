using System.Linq;
using UnityEditor;

public static class ApplicationBuild
{
    public static void AndroidBuild()
    {
        var levels = EditorBuildSettings.scenes
            .Where(scene => scene.enabled)
            .Select(scene => scene.path)
            .ToArray();
        BuildPipeline.BuildPlayer(levels, "./application.apk", BuildTarget.Android, BuildOptions.None);
    }
}
