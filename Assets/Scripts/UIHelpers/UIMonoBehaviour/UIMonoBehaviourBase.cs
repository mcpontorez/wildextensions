﻿using UnityEngine;
    public class UIMonoBehaviourBase : MonoBehaviour, IUIMonoBehaviour
    {
        private RectTransform _rectTransform;
        public RectTransform rectTransform
        {
            get
            {
                if (_rectTransform == null)
                    _rectTransform = (RectTransform)transform;
                return _rectTransform;
            }
        }
    }
}