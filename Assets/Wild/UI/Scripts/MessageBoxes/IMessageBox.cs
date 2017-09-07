using System;

namespace Wild.UI.MessageBoxes
{
    public interface IMessageBox
    {
        string Title { get; set; }

        void AddButton(string text, Action onClick, bool isSecelected = false);
    }
}
