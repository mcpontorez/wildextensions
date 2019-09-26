using Wild.Freelance.Storage;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wild.Systems;

namespace Wild.Freelance.AssetServices
{
    public sealed class PersistentFileToTexture2dConverter
    {
        private IGameLogicUpdateSystem GameLogicUpdateSystem { get; set; }

        public PersistentFileToTexture2dConverter(IGameLogicUpdateSystem gameLogicUpdateSystem)
        {
            GameLogicUpdateSystem = gameLogicUpdateSystem;
        }
        public void ConvertAsync(string filePath, Action<Texture2D> onResultReady, bool isLog = true)
        {
            GameLogicUpdateSystem.StartCoroutine(Converting(filePath, onResultReady, isLog));
        }

        public void ConvertAsync(List<string> filePaths, Action<List<Texture2D>> onResultReady, bool isLog = true)
        {
            GameLogicUpdateSystem.StartCoroutine(Converting(filePaths, onResultReady, isLog));
        }

        private IEnumerator Converting(List<string> filePaths, Action<List<Texture2D>> onResultReady, bool isLog)
        {
            List<Texture2D> textures = new List<Texture2D>();
            for (int i = 0; i < filePaths.Count; i++)
            {
                yield return new WaitForEndOfFrame();
                yield return Converting(filePaths[i], (tex) => textures.Add(tex), isLog);
            }
            onResultReady?.Invoke(textures);
        }

        private IEnumerator Converting(string filePath, Action<Texture2D> onResultReady, bool isLog)
        {
            yield return StorageClient.ReadingBytesAsync(filePath, (bytes) =>
                {
                    Texture2D texture2D = new Texture2D(32, 32);
                    texture2D.LoadImage(bytes);

                    onResultReady?.Invoke(texture2D);
                }, isLog);
        }
    }
}
