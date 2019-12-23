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
        private PathPare _pathPare;
        [SerializeField]
        private PathPare PathPare => _pathPare;

        [SerializeField]
        private RawImage _imageComponent;
        private RawImage ImageComponent => _imageComponent;

        [SerializeField]
        private AspectRatioFitter _imageAspectRatio;
        [SerializeField]
        private AspectRatioFitter ImageAspectRatio => _imageAspectRatio;


        protected override void Start()
        {
            base.Start();

            SetImage();
        }

        private void SetImage(bool isLog = true)
        {
            Clear();

            string path = PathPare.ToAbsolutePath();
            Byte[] bytes = File.ReadAllBytes(path);            
            Texture2D texture = new Texture2D(32, 32);
            texture.LoadImage(bytes);

            Debug.Log($"Image load from {path}");

            ImageComponent.texture = texture;
            ImageComponent.color = Color.white;

            _imageAspectRatio.aspectRatio = texture.width / (float)texture.height;
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
    }
}
