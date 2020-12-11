using System;
using UnityEngine;
using UnityEngine.UI;
using Wild.UI.Helpers;

namespace Wild.UI.Components
{
    public class ToggleController : UIMonoBehaviourBase, ILabel
    {
        public bool IsOn { get { return TogleComponent.isOn; } set { TogleComponent.isOn = value; } }
        public event Action<bool> ValueChanged;

        [SerializeField]
        private Toggle _togleComponent;
        public Toggle TogleComponent { get { return _togleComponent; } }

        [SerializeField]
        private TextControllerBase _textController;
        public TextControllerBase TextController { get { return _textController; } }

        public string Text { get { return TextController.Text; } set { TextController.Text = value; } }

        protected override void Awake()
        {
            base.Awake();
            _togleComponent.onValueChanged.AddListener(OnValueChange);
        }

        private void OnValueChange(bool isOn)
        {
            ValueChanged?.Invoke(isOn);
        }

        public void ClearOnValueChanged()
        {
            ValueChanged = null;
            _togleComponent.onValueChanged.RemoveAllListeners();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            _togleComponent.onValueChanged.RemoveListener(OnValueChange);
        }
    }
}
