using System;

namespace Wild.Storage
{
    [Serializable]
    public class PathPare
    {
        public PathKind Kind = PathKind.Absolute;
        public string Path = string.Empty;
    }
}
