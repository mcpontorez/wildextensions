using Wild.Freelance.Storage;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Wild.Systems;

namespace Wild.Freelance.AssetServices
{
    public sealed class PersistentFileToSpriteConverter
    {
        private IGameLogicUpdateSystem GameLogicUpdateSystem { get; set; }

        public PersistentFileToSpriteConverter(IGameLogicUpdateSystem gameLogicUpdateSystem)
        {
            GameLogicUpdateSystem = gameLogicUpdateSystem;
        }
        public void ConvertAsync(string filePath, Action<Sprite> onResultReady)
        {
            GameLogicUpdateSystem.StartCoroutine(Converting(filePath, onResultReady));
        }

        public void ConvertAsync(List<string> filePaths, Action<List<Sprite>> onResultReady)
        {
            GameLogicUpdateSystem.StartCoroutine(Converting(filePaths, onResultReady));
        }

        private IEnumerator Converting(List<string> filePaths, Action<List<Sprite>> onResultReady)
        {
            List<Sprite> sprites = new List<Sprite>();
            for (int i = 0; i < filePaths.Count; i++)
            {
                yield return new WaitForEndOfFrame();
                yield return Converting(filePaths[i], (spr) => sprites.Add(spr));
            }
            onResultReady?.Invoke(sprites);
        }

        private IEnumerator Converting(string filePath, Action<Sprite> onResultReady)
        {
            yield return StorageClient.ReadingBytesAsync(filePath, (bytes) =>
                {
                    Texture2D texture2D = new Texture2D(32, 32);
                    texture2D.LoadImage(bytes);
                    Sprite sprite = Sprite.Create(texture2D, new Rect(1f,1f,1f,1f), Vector2.zero);
                    sprite.name = Path.GetFileNameWithoutExtension(filePath);
                    onResultReady?.Invoke(sprite);
                }, true);
        }
    }
}
