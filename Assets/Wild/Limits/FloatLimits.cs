using UnityEngine;

namespace Wild.Limits
{
    [System.Serializable]
    public class FloatLimits : ILimits<float>
    {
        public FloatLimits() { }

        public FloatLimits(float min, float max)
        {
            this.min = min;
            this.max = max;
        }

        public float min = 0f;
        public float Min { get { return min; } set { min = value; } }

        public float max = 1f;
        public float Max { get { return max; } set { max = value; } }

        public virtual float GetRandomValue()
        {
            return Random.Range(min, max);
        }
    }
}
