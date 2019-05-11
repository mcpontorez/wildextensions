using System;
using System.IO;

namespace Wild.IO
{
    public static class FileSystemInfoExstensions
    {
        public static T GetRefresh<T>(this T target) where T : FileSystemInfo
        {
            target.Refresh();
            return target;
        }

        public static FileInfo DeleteIfExists(this FileInfo target)
        {
            if (target.GetRefresh().Exists)
                target.Delete();
            return target;
        }

        public static DirectoryInfo DeleteIfExists(this DirectoryInfo target)
        {
            if(target.GetRefresh().Exists)
                target.Delete(true);
            return target;
        }
    }
}
