using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using Wild.Components;
using Wild.UI.Helpers;

namespace Wild.UI.Components
{
    public class Clickable : UIMonoBehaviourBase, IClickable, IPointerDownHandler, IPointerClickHandler, ISubmitHandler
    {
        private Coroutine _waitAndInvokeCoroutine;

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

        public event Action OnFirstClick;
        public event Action OnClick;
        public event Action OnSingleClick;
        public event Action OnDoubleClick;
        public event Action<int> OnLastClick;

        public virtual void InvokeOnCliсk() => InvokeOnCliсk(1);

        public virtual void InvokeOnCliсk(int clickCount)
        {
            if(Interactable)
                OnClick?.Invoke();
            if (clickCount == 1)
                OnFirstClick?.Invoke();
            StopAndStartWaintAndInvoke(clickCount);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            StopWaintAndInvoke();
        }

        public virtual void OnPointerClick(PointerEventData eventData)
        {
            InvokeOnCliсk(eventData.clickCount);
        }
        public virtual void OnSubmit(BaseEventData eventData)
        {
            InvokeOnCliсk(1);
        }

        private void StopWaintAndInvoke()
        {
            this.StopNullableCoroutine(_waitAndInvokeCoroutine);
        }

        private void StopAndStartWaintAndInvoke(int clickCount)
        {
            StopWaintAndInvoke();
            _waitAndInvokeCoroutine = this.TryStartCoroutine(WaitAndInvoke(clickCount));
        }

        private IEnumerator WaitAndInvoke(int clickCount)
        {
            yield return new WaitForSeconds(0.2f);
            if (clickCount == 1)
                OnSingleClick?.Invoke();
            else if (clickCount == 2)
                OnDoubleClick?.Invoke();
            OnLastClick?.Invoke(clickCount);
        }

        public virtual void ClearOnClickEvents()
        {
            OnFirstClick = null;
            OnSingleClick = null;
            OnDoubleClick = null;
            OnLastClick = null;
            OnClick = null;
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            ClearOnClickEvents();
        }
    }
}
