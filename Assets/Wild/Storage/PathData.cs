using System;

namespace Wild.Storage
{
    [Serializable]
    public class PathData
    {
        public PathKind Kind = PathKind.Absolute;
        public string Path = string.Empty;

        public PathData() { }
        public PathData(PathKind kind, string path) {Kind = kind; Path = path; }
        public PathData(string path) { Path = path; }
    }
}
