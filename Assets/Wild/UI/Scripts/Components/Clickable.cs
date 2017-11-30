using System;
using UnityEngine.EventSystems;
using Wild.UI.Helpers;

namespace Wild.UI.Components
{
    public class Clickable : UIMonoBehaviourBase, IClickable, IPointerClickHandler, ISubmitHandler
    {
        public event Action OnClick;
        public virtual void InvokeOnCliсk()
        {
            OnClick?.Invoke();
        }
        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            InvokeOnCliсk();
        }
        void ISubmitHandler.OnSubmit(BaseEventData eventData)
        {
            InvokeOnCliсk();
        }

        public void ClearOnClick()
        {
            OnClick = null;
        }
    }
}
