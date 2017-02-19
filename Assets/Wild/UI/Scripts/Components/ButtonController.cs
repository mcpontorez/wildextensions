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
        private TextController _textComponent;
        public TextController TextComponent { get { return _textComponent;} }

        [SerializeField]
        private Button _buttonComponent;
        public Button ButtonComponent { get { return _buttonComponent; } }

        public void OnValidate()
        {
            _buttonComponent = GetComponent<Button>();
            _textComponent = GetComponentInChildren<TextController>();
        }

        public string Text { get { return TextComponent.Text; } set { TextComponent.Text = value; } }

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
