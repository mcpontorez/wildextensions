using System;
using System.Collections.Generic;
using UnityEngine;

namespace Wild.UnityObjects
{
    public static class VectorUtils
    {
        public static Vector3 ToVector3(this float value) => new Vector3(value, value, value);
        public static Vector4 ToVector4(this float value) => new Vector4(value, value, value, value);

        public static Vector3 SetY(this Vector3 target, float value)
        {
            target.y = value;
            return target;
        }
        public static Vector3 SetZ(this Vector3 target, float value)
        {
            target.z = value;
            return target;
        }

        public static Vector3 AddY(this Vector3 target, float value)
        {
            target.y += value;
            return target;
        }

        public static Vector3 AddZ(this Vector3 target, float value)
        {
            target.z += value;
            return target;
        }
    }
}
