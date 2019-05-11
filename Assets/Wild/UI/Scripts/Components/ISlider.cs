using System;

namespace Wild.UI.Components
{
    public interface ISlider : IClickable, ILabel
    {
        float Value { get; set; }
        void SetValue(float value, bool needsValueChangedInvokeEvent = true);
        event Action<float> OnValueChanged;

        IManipulable SliderManipulable { get; }

        void ClearOnValueChanged();
    }
}
