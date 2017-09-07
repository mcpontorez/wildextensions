using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Wild.UI.Helpers;

namespace Wild.UI.Components
{
    public class PointerSelecter : UIMonoBehaviourBase, IPointerEnterHandler, IDeselectHandler
    {
        [SerializeField]
        private Selectable _selectable;

        private void OnValidate()
        {
            _selectable = GetComponent<Selectable>();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (_selectable.navigation.mode != Navigation.Mode.None)
                EventSystem.current.SetSelectedGameObject(this.gameObject);
        }

        public void OnDeselect(BaseEventData eventData)
        {
            _selectable.OnPointerExit(new PointerEventData(EventSystem.current));
        }
    }
}
