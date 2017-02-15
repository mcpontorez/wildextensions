using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WildUI.ScreenManagement.Data
{
    [Serializable]
    public class UIContainerData
    {
        public UIContainerData(UIContainerTag containerTag, UIContainer container)
        {
            _containerTag = containerTag;
            _container = container;
        }

        [SerializeField]
        private UIContainerTag _containerTag;
        public UIContainerTag ContainerTag { get { return _containerTag; } }

        [SerializeField]
        private UIContainer _container;
        public UIContainer Container { get { return _container; } }

    }
}