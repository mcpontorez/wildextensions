using System;
using UnityEngine;
using UnityEngine.UI;
using Wild.InterfacesMB;
using Wild.UI.Helpers;

namespace Wild.UI.Components
{
    public class ToggleController : UIMonoBehaviourBase, IOnValidate, ILabel, IAwake
    {
        public bool IsOn { get { return TogleComponent.isOn; } set { TogleComponent.isOn = value; } }
        public event Action<bool> OnValueChanged;

        [SerializeField]
        private Toggle _togleComponent;
        public Toggle TogleComponent { get { return _togleComponent; } }

        [SerializeField]
        private TextController _textController;
        public TextController TextController { get { return _textController; } }

        public string Text { get { return TextController.Text; } set { TextController.Text = value; } }

        public void OnValidate()
        {
            _togleComponent = GetComponent<Toggle>();
            _textController = GetComponentInChildren<TextController>();
        }

        public void Awake()
        {
            _togleComponent.onValueChanged.AddListener(OnValueChange);
        }

        private void OnValueChange(bool isOn)
        {
            if (OnValueChanged != null)
                OnValueChanged(isOn);
        }

        public void ClearOnValueChanged()
        {
            OnValueChanged = null;
            _togleComponent.onValueChanged.RemoveAllListeners();
        }
    }
}
