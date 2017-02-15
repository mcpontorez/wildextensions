using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WildUI.ScreenManagement
{
    public interface IScreen
    {
        void Init();

        void Show();

        void Hide();

        void Destroy();
    }
}
