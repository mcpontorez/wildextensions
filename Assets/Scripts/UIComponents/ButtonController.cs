using Wild.InterfacesMB;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Wild.UI.Helpers;

namespace Wild.UI.Components
{
    public class ButtonController : UIMonoBehaviourBase, IOnValidate, IPointerClickHandler
    {
        [SerializeField]
        private Text _textComponent;

        public void OnValidate()
        {
            _textComponent = GetComponentInChildren<Text>();
        }

        public string Text { get { return _textComponent.text; } set { _textComponent.text = value; } }

        public event Action OnClick;
        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            if(OnClick != null)
                OnClick();
        }

        public void ClearOnClick()
        {
            OnClick = null;
        }
    }
}
