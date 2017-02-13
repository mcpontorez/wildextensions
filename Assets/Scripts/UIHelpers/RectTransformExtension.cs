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
    }
}
