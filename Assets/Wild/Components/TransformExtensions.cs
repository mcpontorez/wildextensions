using System;
using System.Collections.Generic;
using UnityEngine;

namespace Wild.Components
{
    public static class TransformExtensions
    {
        public static List<Transform> GetChilds(this Transform target)
        {
            List<Transform> childs = new List<Transform>();
            for (int i = 0; i < target.childCount; i++)
            {
                childs.Add(target.GetChild(i));
            }
            return childs;
        }
    }
}
