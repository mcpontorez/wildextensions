using System;

namespace Wild.UI.Components
{
    public interface IClickable
    {
        bool Interactable { get; set; }

        event Action OnClick;
        void InvokeOnCliсk();
    }
}
