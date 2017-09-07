using System;

namespace Wild.UI.Components
{
    public interface IClickable
    {
        event Action OnClick;
        void InvokeOnCliсk();
    }
}
