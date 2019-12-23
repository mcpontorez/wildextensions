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
        public virtual bool Interactable
        {
            get { return _interactable; }
            set
            {
                _interactable = value;
                OnInteractableChanged(_interactable);
            }
        }
        protected virtual void OnInteractableChanged(bool value) { }

        public event Action FirstClick;
        public event Action Click;
        public event Action SingleClick;
        public event Action DoubleClick;
        public event Action<int> LastClick;

        public virtual void InvokeOnCliсk() => InvokeOnCliсk(1);

        public virtual void InvokeOnCliсk(int clickCount)
        {
            if(Interactable)
                Click?.Invoke();
            if (clickCount == 1)
                FirstClick?.Invoke();
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
                SingleClick?.Invoke();
            else if (clickCount == 2)
                DoubleClick?.Invoke();
            LastClick?.Invoke(clickCount);
        }

        public virtual void ClearOnClickEvents()
        {
            FirstClick = null;
            SingleClick = null;
            DoubleClick = null;
            LastClick = null;
            Click = null;
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            ClearOnClickEvents();
        }
    }
}
