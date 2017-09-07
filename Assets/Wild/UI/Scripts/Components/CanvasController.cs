using UnityEngine;
using UnityEngine.UI;
using Wild.InterfacesMB;
using Wild.UI.Helpers;

namespace Wild.UI.Components
{
    public class CanvasController : UIMonoBehaviourBase, IOnValidate
    {
        [SerializeField]
        private RectTransform _rootLayout;
        public RectTransform RootLayout { get { return _rootLayout; } }

        [SerializeField]
        private Canvas _canvasComponent;
        public Canvas CanvasComponent { get { return _canvasComponent; } }

        [SerializeField]
        private CanvasScaler _canvasScalerComponent;
        public CanvasScaler CanvasScalerComponent { get { return _canvasScalerComponent; } }

        public void OnValidate()
        {
            _canvasComponent = GetComponent<Canvas>();
            _canvasScalerComponent = GetComponent<CanvasScaler>();
        }
    }
}
