using UnityEngine.EventSystems;
using Wild.Generics;
using Wild.Systems.Management;

namespace Wild.UI.ScreenManagement
{
    public interface IScreenManager
    {
        ScreenManagerContainer Container { get; }

        EventSystem EventSystem { get; set; }

        SystemManager SystemManager { get; }

        TScreen ShowScreen<TScreen>(int? sortOrder = null) where TScreen : IScreen, new();

        TScreen ShowScreen<TScreen>(IGenericNewTypeContainer<TScreen> screenTypeContainer, int? sortOrder = null) where TScreen : IScreen;

        void HideScreen<T>() where T : IScreen;

        void DestroyScreen<T>() where T : IScreen;
    }
}
