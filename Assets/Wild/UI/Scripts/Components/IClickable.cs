using System;

namespace Wild.UI.Components
{
    public interface IClickable
    {
        bool Interactable { get; set; }

        event Action FirstClick;
        event Action Click;
        event Action SingleClick;
        event Action DoubleClick;
        event Action<int> LastClick;

        void InvokeOnCliсk();
        void InvokeOnCliсk(int clickCount);
    }
}
