using UnityEngine;
using UnityEngine.UI;

namespace Wild.UI.Helpers
{
    public static class SliderExtensions
    {
        public static void SetRangeValue(this Slider target, float minValue, float maxValue)
        {
            target.minValue = minValue;
            target.maxValue = maxValue;
        }

        public static void SetRangeValue(this Slider target, float minMaxValue)
        {
            minMaxValue = Mathf.Abs(minMaxValue);
            target.minValue = -minMaxValue;
            target.maxValue = minMaxValue;
        }
    }
}
