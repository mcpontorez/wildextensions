using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WildUI.UIHelpers;

namespace WildUI.UIComponents
{
    public class CanvasController : UIMonoBehaviourBase
    {
        [SerializeField]
        private RectTransform _rootLayout;

        public RectTransform RootLayout { get { return _rootLayout; } }
    }
}
