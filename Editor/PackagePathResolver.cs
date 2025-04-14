namespace GfxQA.ShaderVariantTool
{
    using System;
    using System.IO;
    using System.Reflection;

    using UnityEditor.PackageManager;

    using UnityEngine;

    public static class PackagePathResolver
    {
        public static string GetPackageAbsolutePath(string packageName)
        {
            Type packageInfoType = typeof(PackageInfo);
            MethodInfo method = packageInfoType.GetMethod("GetAllRegisteredPackages", BindingFlags.NonPublic | BindingFlags.Static);
            if (method != null)
            {
                var packages = (PackageInfo[])method.Invoke(null, null);
                foreach (PackageInfo package in packages)
                {
                    if (package.name == packageName)
                    {
                        return Path.GetFullPath(package.resolvedPath);
                    }
                }
            }

            Debug.LogWarning($"Package '{packageName}' not found.");
            return null;
        }
    }
}