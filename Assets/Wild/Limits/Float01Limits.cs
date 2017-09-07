using UnityEngine;

namespace Wild.Limits
{
    [System.Serializable]
    public class Float01Limits : ILimits<float>
    {
        public Float01Limits() { }

        public Float01Limits(float min, float max)
        {
            this.min = min;
            this.max = max;
        }

        [Range(0f, 1f)]
        public float min = 0f;
        public float Min { get { return min; } set { min = value; } }

        [Range(0f, 1f)]
        public float max = 1f;
        public float Max { get { return max; } set { max = value; } }

        public virtual float GetRandomValue()
        {
            return Random.Range(min, max);
        }
    }
}
