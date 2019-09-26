using System;

namespace Wild.Freelance.Storage
{
    public interface IStorageClient
    {
        void CreateFile(string path);

        void ReadTextAsync(string filePath, Action<string> onReaded);

        void ReadTextFromStreamingAssets(string filePath, Action<string> onReaded);

        void ReadBytesAsync(string filePath, Action<byte[]> onReaded, bool isLog = true);
    }
}
