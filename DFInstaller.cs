using System.Diagnostics;
using UnityEditor;
using UnityEngine;
using UnityEngine.Windows;

namespace DanonUnityFramework.Installer {
    internal static class DFInstaller {
        private const string c_url = "https://github.com/Danon5/DanonUnityFramework.git";
        private const string c_installer_path = "Assets/DanonUnityFrameworkInstaller";
        private static readonly string s_path = $"{Application.dataPath}/Framework/DanonUnityFramework";
        private static readonly string s_cmd = $"clone --recurse-submodules -j8 {c_url} {s_path}";

        [MenuItem("Assets/Install DanonUnityFramework", false, 0)]
        private static void Install() {
            var startInfo = new ProcessStartInfo("git", s_cmd)
            {
                CreateNoWindow = true,
                UseShellExecute = false,
            };
            
            var process = new Process();
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();

            if (Directory.Exists(c_installer_path))
                AssetDatabase.DeleteAsset(c_installer_path);
            
            AssetDatabase.Refresh();
        }
    }
}
