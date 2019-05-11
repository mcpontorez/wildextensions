using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Wild.UI.Helpers;

namespace Wild.UI.Components
{
    public sealed class Manipulable : UIMonoBehaviourBase, IManipulable, IDragHandler, IEndDragHandler, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
    {
        public bool IsDragged { get; private set; } = false;

        public bool IsPointerDowned { get; private set; } = false;

        public event Action OnPointerDown;
        public event Action OnPointerDowned;
        public event Action OnPointerUp;

        public bool IsPointerOver { get; private set; } = false;

        public bool IsManipulated => IsDragged || IsPointerDowned || IsPointerOver;

        void IDragHandler.OnDrag(PointerEventData eventData)
        {
            IsDragged = true;
        }

        void IEndDragHandler.OnEndDrag(PointerEventData eventData)
        {
            IsDragged = false;
        }

        void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
        {
            IsPointerDowned = true;
            OnPointerDown?.Invoke();
        }

        void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
        {
            IsPointerDowned = false;
            OnPointerUp?.Invoke();
        }

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
        {
            IsPointerOver = true;
        }

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
        {
            IsPointerOver = false;
        }

        void Update()
        {
            if (IsPointerDowned)
                OnPointerDowned?.Invoke();
        }
    }
}
