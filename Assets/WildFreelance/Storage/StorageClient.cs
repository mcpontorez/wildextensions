using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using Wild.Systems;

namespace Wild.Freelance.Storage
{
    public sealed class StorageClient : IStorageClient
    {
        private IGameLogicUpdateSystem GameLogicUpdateSystem { get; set; }

        public StorageClient(IGameLogicUpdateSystem gameLogicUpdateSystem)
        {
            GameLogicUpdateSystem = gameLogicUpdateSystem;
        }

        public void CreateFile(string path)
        {
            File.Create(path).Dispose();
        }

        public void ReadTextAsync(string filePath, Action<string> onReaded)
        {
            GameLogicUpdateSystem.StartCoroutine(ReadingText(PathInfo.StartPathForUwr + filePath, onReaded));
        }

        public void ReadTextFromStreamingAssets(string filePath, Action<string> onReaded)
        {
            GameLogicUpdateSystem.StartCoroutine(ReadingText(PathInfo.StartStreamingAssetsPathForUwr + filePath, onReaded));
        }

        private IEnumerator ReadingText(string filePath, Action<string> onReaded)
        {
            string text = string.Empty;

            Debug.Log($"{nameof(StorageClient)}: Start get from " + filePath);

            using (UnityWebRequest webRequest = UnityWebRequest.Get(filePath))
            {
                yield return webRequest.SendWebRequest();
                Debug.Log(webRequest.isNetworkError ? webRequest.error : $"{nameof(StorageClient)}: Complete get from " + filePath);

                text = webRequest.downloadHandler.text;
            }
            onReaded?.Invoke(text);
        }

        public void ReadBytesAsync(string filePath, Action<byte[]> onReaded, bool isLog = true)
        {
            GameLogicUpdateSystem.StartCoroutine(ReadingBytes(PathInfo.ConvertPersistentPathToUwr(filePath), onReaded, isLog));
        }

        public static IEnumerator ReadingBytesAsync(string filePath, Action<byte[]> onReaded, bool isLog)
        {
            yield return ReadingBytes(PathInfo.ConvertPersistentPathToUwr(filePath), onReaded, isLog);
        }

        private static IEnumerator ReadingBytes(string filePath, Action<byte[]> onReaded, bool isLog)
        {
            byte[] data = new byte[0];

            if(isLog)
                Debug.Log($"{nameof(StorageClient)}: Start get from " + filePath);

            using (UnityWebRequest webRequest = UnityWebRequest.Get(filePath))
            {
                yield return webRequest.SendWebRequest();
                if (isLog)
                    Debug.Log(webRequest.isNetworkError ? webRequest.error : $"{nameof(StorageClient)}: Complete get from " + filePath);

                data = webRequest.downloadHandler.data;
            }
            onReaded?.Invoke(data);
        }
    }
}
