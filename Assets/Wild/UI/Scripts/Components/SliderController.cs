using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Wild.UI.Helpers;

namespace Wild.UI.Components
{
    public sealed class SliderController : Clickable, ISlider
    {
        private bool _needsValueChangedInvokeEvent = true;

        public float Value { get { return SliderComponent.value; } set { SetValue(value, false); } }

        public void SetValue(float value, bool needsValueChangedInvokeEvent = true)
        {
            _needsValueChangedInvokeEvent = needsValueChangedInvokeEvent;
            SliderComponent.value = value;
        }

        public event Action<float> OnValueChanged;       

        [SerializeField]
        private Slider _sliderComponent;
        public Slider SliderComponent { get { return _sliderComponent; } }

        [SerializeField]
        private Manipulable _sliderManipulable;
        public IManipulable SliderManipulable => _sliderManipulable;

        [SerializeField]
        private TextController _textController;
        public TextController TextController { get { return _textController; } }

        public string Text { get { return TextController.Text; } set { TextController.Text = value; } }

        protected override void OnValidate()
        {
            _sliderComponent = GetComponentInChildren<Slider>();
            _textController = GetComponentInChildren<TextController>();
        }

        private void Awake()
        {
            SliderComponent.onValueChanged.AddListener(OnValueChange);
        }

        private void OnValueChange(float value)
        {
            if(_needsValueChangedInvokeEvent)
                OnValueChanged?.Invoke(value);
            _needsValueChangedInvokeEvent = true;
        }

        public void ClearOnValueChanged()
        {
            OnValueChanged = null;
            SliderComponent.onValueChanged.RemoveAllListeners();
        }
    }
}
