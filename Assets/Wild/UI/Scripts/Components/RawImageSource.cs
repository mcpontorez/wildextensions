using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using Wild.Storage;
using Wild.UI.Helpers;

namespace Wild.UI.Components
{
    public class RawImageSource : UIMonoBehaviourBase
    {
        [SerializeField]
        private bool _isAutoLoadImage = true;
        [SerializeField]
        private PathData _pathData;
        public PathData PathData { get => _pathData; set => _pathData = value; }

        [SerializeField]
        private RawImage _imageComponent;
        private RawImage ImageComponent => _imageComponent;


        protected override void Start()
        {
            base.Start();

            if(_isAutoLoadImage)
                LoadImage();
        }

        public void LoadImage(bool isLog = true)
        {
            Clear();

            string path = PathData.ToAbsolutePath();
            if(!GetValidateFileExtension(path))
            {
                Log($"Invalid file extension. Not imagefile extension {path}", isLog);
                return;
            }
            byte[] bytes = File.ReadAllBytes(path);            
            Texture2D texture = new Texture2D(32, 32) { wrapMode = TextureWrapMode.Clamp};
            texture.LoadImage(bytes);

            Log($"Image load from {path}", isLog);

            ImageComponent.texture = texture;
            ImageComponent.color = Color.white;
        }

        public void Clear()
        {
            _imageComponent.color = Color.clear;

            Texture texture = _imageComponent.texture;
            _imageComponent.texture = null;
            if (texture != null)
                Destroy(texture);
        }

        protected override void OnDestroy()
        {
            Clear();
            base.OnDestroy();
        }

        private bool GetValidateFileExtension(string path)
        {
            string extension = Path.GetExtension(path);
            return extension == ".png" || extension == ".jpg";
        }

        private void Log(string message, bool isLog = true)
        {
            if (isLog) Debug.Log(message);
        }
    }
}
