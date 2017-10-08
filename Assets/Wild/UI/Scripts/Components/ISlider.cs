using System;

namespace Wild.UI.Components
{
    public interface ISlider : IClickable, ILabel
    {
        float Value { get; set; }
        event Action<float> OnValueChanged;

        void ClearOnValueChanged();
    }
}
