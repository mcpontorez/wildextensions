using System;
using UnityEngine;

namespace Wild.UI.Components
{
    public interface IManipulable
    {
        bool IsDragged { get; }

        bool IsPointerDowned { get; }
        event Action OnPointerDown;
        event Action OnPointerDowned;
        event Action OnPointerUp;

        bool IsPointerOver { get; }

        bool IsManipulated { get; }
    }
}
