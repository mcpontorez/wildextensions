using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Wild.Storage
{
    public static class PathHelper
    {
        public static string ToAbsolutePath(PathKind pathKind, string path)
        {
            string result = path;
            switch (pathKind)
            {
                case PathKind.RelativeStreamingAssets:
                    string streamingAssetsPath = Application.streamingAssetsPath;
                    if (!path.StartsWith(streamingAssetsPath))
                        result = Path.Combine(streamingAssetsPath, path);
                    break;
                case PathKind.RelativePersistentData:
                    string persistentDataPath = Application.persistentDataPath;
                    if (!path.StartsWith(persistentDataPath))
                        result = Path.Combine(persistentDataPath, path);
                    break;
            }
            return result;
        }

        public static string ToAbsolutePath(this PathPare pathPare) => ToAbsolutePath(pathPare.Kind, pathPare.Path);
    }
}
