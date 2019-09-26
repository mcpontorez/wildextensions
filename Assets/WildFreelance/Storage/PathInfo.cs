using System;
using UnityEngine;

namespace Wild.Freelance.Storage
{
    public static class PathInfo
    {
        public static string StartStreamingAssetsPathForUwr
        {
            get
            {
                string path = StartPathForUwr;
                if (Application.platform == RuntimePlatform.Android)
                    path = "jar:" + path;
                return path;
            }
        }

        public static string StartPathForUwr
        {
            get
            {
                string path = string.Empty;
                if (Application.platform == RuntimePlatform.Android)
                    path = "file://";
                else if (Application.platform == RuntimePlatform.IPhonePlayer)
                    path = "file:///";
                return path;
            }
        }

        public static string ConvertPersistentPathToUwr(string path)
        {
            return new Uri(path).ToString();
        }
    }
}
