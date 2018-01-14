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

        public bool IsDowned { get; private set; } = false;
        public event Action OnPointerDown;
        public event Action OnPointerUp;

        public bool IsPointerOver { get; private set; } = false;

        public bool IsManipulated => IsDragged || IsDowned || IsPointerOver;

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
            IsDowned = true;
            OnPointerDown?.Invoke();
        }

        void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
        {
            IsDowned = false;
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
    }
}
