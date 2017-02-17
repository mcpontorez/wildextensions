using UnityEngine;
using Wild.UI.Helpers;

namespace Wild.UI.Components
{
    public class CanvasController : UIMonoBehaviourBase
    {
        [SerializeField]
        private RectTransform _rootLayout;

        public RectTransform RootLayout { get { return _rootLayout; } }
    }
}
