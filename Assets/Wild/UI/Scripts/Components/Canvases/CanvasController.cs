using UnityEngine;
using UnityEngine.UI;
using Wild.InterfacesMB;
using Wild.UI.Helpers;

namespace Wild.UI.Components.Canvases
{
    public class CanvasController : UIMonoBehaviourBase, ICanvasController
    {
        [SerializeField]
        private RectTransform _rootLayout;
        public RectTransform RootLayout => _rootLayout;

        [SerializeField]
        private Canvas _canvas;
        public Canvas Canvas => _canvas;

        [SerializeField]
        private CanvasScaler _canvasScaler;
        public CanvasScaler CanvasScaler => _canvasScaler;

        [SerializeField]
        private CanvasGroup _canvasGroup;
        public CanvasGroup CanvasGroup => _canvasGroup;

        [SerializeField]
        private GraphicRaycaster _graphicRaycaster;
        public GraphicRaycaster GraphicRaycaster => _graphicRaycaster;

        protected override void OnValidate()
        {
            _canvas = GetComponent<Canvas>();
            _canvasScaler = GetComponent<CanvasScaler>();
            _canvasGroup = GetComponent<CanvasGroup>();
            _graphicRaycaster = GetComponent<GraphicRaycaster>();
        }
    }
}
