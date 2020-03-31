using UnityEngine;

namespace Wild.UnityObjects
{
    public static class RectExtensions
    {

        public static Rect SetSizeAndCenter(this Rect targetRect, Vector2 size, Vector2 center)
        {
            targetRect.size = size;
            targetRect.center = center;
            
            return targetRect;
        }

        public static Rect SetCenter(this Rect targetRect, Vector2 center)
        {
            targetRect.center = center;
            return targetRect;
        }

        public static Vector2 GetContainsPosition(this Rect targetRect, Vector2 preferPosition)
        {
            Vector2 resultPosition = preferPosition;
            if (!targetRect.Contains(preferPosition))
            {
                if (resultPosition.x < targetRect.xMin)
                    resultPosition.x = targetRect.xMin;
                else if (resultPosition.x > targetRect.xMax)
                    resultPosition.x = targetRect.xMax;

                if (resultPosition.y < targetRect.yMin)
                    resultPosition.y = targetRect.yMin;
                else if (resultPosition.y > targetRect.yMax)
                    resultPosition.y = targetRect.yMax;
            }
            return resultPosition;
        }
    }
}
