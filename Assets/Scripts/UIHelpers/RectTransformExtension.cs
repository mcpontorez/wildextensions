using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WildUI.UIHelpers
{
    public static class RectTransformExtension
    {
        public static void SetAnchors(this RectTransform rectTransform, Vector2 anchorMin, Vector2 anchorMax)
        {
            rectTransform.anchorMin = anchorMin;
            rectTransform.anchorMax = anchorMax;
            rectTransform.offsetMin = Vector2.zero;
            rectTransform.offsetMax = Vector2.zero;
        }

        public static void SetOffsets(this RectTransform rectTransform, Vector2 offsetMin, Vector2 offsetMax)
        {
            rectTransform.offsetMin = offsetMin;
            rectTransform.offsetMax = offsetMax;
            rectTransform.localScale = Vector3.one;
        }
    }
}
