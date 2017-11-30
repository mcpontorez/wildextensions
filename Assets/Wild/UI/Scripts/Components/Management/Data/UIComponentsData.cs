using Wild.InterfacesMB;
using UnityEngine;
using UnityEngine.UI;
using Wild.UI.Components.Canvases;

namespace Wild.UI.Components.Data
{
    [CreateAssetMenu(fileName = "UIComponentsData", menuName = "Wild/UI/UIComponentsData")]
    public class UIComponentsData : ScriptableObject, IOnValidate
    {
        public CanvasController canvas;
        public ButtonController button;
        public RectTransform panel;
        public CollectionViewController collectionView;
        public TextController text;
        public ToggleController toggle;
        public SliderController slider;

        public void OnValidate()
        {

        }
    }
}
