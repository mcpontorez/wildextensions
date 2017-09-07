using System;
using UnityEngine;
using UnityEngine.UI;
using Wild.InterfacesMB;
using Wild.UI.Helpers;

namespace Wild.UI.Components
{
    public class SliderController : Clickable, ILabel, IOnValidate, IAwake
    {
        public float Value { get { return SliderComponent.value; } set { SliderComponent.value = value; } }
        public event Action<float> OnValueChanged;

        [SerializeField]
        private Slider _sliderComponent;
        public Slider SliderComponent { get { return _sliderComponent; } }

        [SerializeField]
        private TextController _textController;
        public TextController TextController { get { return _textController; } }

        public string Text { get { return TextController.Text; } set { TextController.Text = value; } }

        public void OnValidate()
        {
            _sliderComponent = GetComponentInChildren<Slider>();
            _textController = GetComponentInChildren<TextController>();
        }

        public void Awake()
        {
            SliderComponent.onValueChanged.AddListener(OnValueChange);
        }

        private void OnValueChange(float value)
        {
            if (OnValueChanged != null)
                OnValueChanged(value);
        }

        public void ClearOnValueChanged()
        {
            OnValueChanged = null;
            SliderComponent.onValueChanged.RemoveAllListeners();
        }
    }
}
