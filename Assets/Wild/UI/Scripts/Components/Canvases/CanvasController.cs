using UnityEngine;
using UnityEngine.UI;
using Wild.InterfacesMB;
using Wild.UI.Helpers;

namespace Wild.UI.Components.Canvases
{
    public class CanvasController : UIMonoBehaviourBase, ICanvasController, IOnValidate
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

        public void OnValidate()
        {
            _canvas = GetComponent<Canvas>();
            _canvasScaler = GetComponent<CanvasScaler>();
            _canvasGroup = GetComponent<CanvasGroup>();
        }
    }
}
