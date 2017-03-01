using Wild.InterfacesMB;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Wild.UI.Helpers;

namespace Wild.UI.Components
{
    public class ButtonController : UIMonoBehaviourBase, ILabel, IOnValidate, IPointerClickHandler
    {
        [SerializeField]
        private TextController _textController;
        public TextController TextController { get { return _textController; } }

        [SerializeField]
        private Button _buttonComponent;
        public Button ButtonComponent { get { return _buttonComponent; } }

        public void OnValidate()
        {
            _buttonComponent = GetComponent<Button>();
            _textController = GetComponentInChildren<TextController>();
        }

        public string Text { get { return TextController.Text; } set { TextController.Text = value; } }

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
