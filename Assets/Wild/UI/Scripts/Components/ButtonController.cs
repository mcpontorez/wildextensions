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
        public Text TextComponent { get { return _textComponent;} }

        [SerializeField]
        private Button _buttonComponent;
        public Button ButtonComponent { get { return _buttonComponent; } }

        public void OnValidate()
        {
            _buttonComponent = GetComponent<Button>();
            _textComponent = GetComponentInChildren<Text>();
        }

        public string Text { get { return TextComponent.text; } set { TextComponent.text = value; } }

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
