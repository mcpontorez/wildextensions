using System;
using UnityEngine.EventSystems;
using Wild.UI.Helpers;

namespace Wild.UI.Components
{
    public class Clickable : UIMonoBehaviourBase, IClickable, IPointerClickHandler, ISubmitHandler
    {
        private bool _interactable = true;
        public bool Interactable
        {
            get { return _interactable; }
            set
            {
                _interactable = value;
                OnInteractableChanged(_interactable);
            }
        }
        protected virtual void OnInteractableChanged(bool value) { }

        public event Action OnClick;
        public virtual void InvokeOnCliсk()
        {
            if(Interactable)
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
