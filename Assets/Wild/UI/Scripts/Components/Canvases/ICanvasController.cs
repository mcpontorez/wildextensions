using UnityEngine;
using UnityEngine.UI;
using Wild.UI.Helpers;

namespace Wild.UI.Components.Canvases
{
    public interface ICanvasController : IUIMonoBehaviour
    {
        RectTransform RootLayout { get; }

        Canvas Canvas { get; }

        CanvasScaler CanvasScaler { get; }

        CanvasGroup CanvasGroup { get; }
    }
}
