using System;

namespace Wild.UI.Components
{
    public interface IClickable
    {
        bool Interactable { get; set; }

        event Action OnFirstClick;
        event Action OnClick;
        event Action OnSingleClick;
        event Action OnDoubleClick;
        event Action<int> OnLastClick;

        void InvokeOnCliсk();
        void InvokeOnCliсk(int clickCount);
    }
}
