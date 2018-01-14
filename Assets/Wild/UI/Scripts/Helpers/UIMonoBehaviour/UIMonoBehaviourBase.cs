using System;
using UnityEngine;namespace Wild.UI.Helpers{
    public class UIMonoBehaviourBase : MonoBehaviour, IUIMonoBehaviour
    {
        private RectTransform _rectTransform;
        public RectTransform RectTransform
        {
            get
            {
                if (_rectTransform == null)
                    _rectTransform = (RectTransform)transform;
                return _rectTransform;
            }
        }

        protected virtual void OnValidate()
        {

        }

        /// <summary>
        /// Использовать для подготовки объекта к уничтожению. Например отписка от событий
        /// </summary>
        public event Action OnPrepareToDestoy;
        protected virtual void OnDestroy()
        {
            if (OnPrepareToDestoy != null)
                OnPrepareToDestoy();
        }
    }
}