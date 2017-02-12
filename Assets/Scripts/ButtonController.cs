using InterfacesMB;
using System.Collections;
using System.Collections.Generic;
using UIMonoBehaviourHelpers;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace WildUI.UIComponents
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
            OnClick();
        }
    }
}
