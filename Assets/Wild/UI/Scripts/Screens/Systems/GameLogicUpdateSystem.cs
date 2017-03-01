using System;
using UnityEngine;
using Wild.InterfacesMB;

namespace Wild.UI.Screens.Systems
{
    public class GameLogicUpdateSystem : MonoBehaviour, IUpdate, IFixedUpdate, ILateUpdate
    {
        public event Action OnUpdated;
        public event Action OnFixedUpdated;
        public event Action OnLateUpdated;

        public void Update()
        {
            if (OnUpdated != null)
                OnUpdated();
        }

        public void LateUpdate()
        {
            if (OnLateUpdated != null)
                OnLateUpdated();
        }

        public void FixedUpdate()
        {
            if (OnFixedUpdated != null)
                OnFixedUpdated();
        }
    }
}
