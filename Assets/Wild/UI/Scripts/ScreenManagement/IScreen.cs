using Wild.UI.ScreenManagement.Data;

namespace Wild.UI.ScreenManagement
{
    public interface IScreen
    {
        ScreenData Data { get; }

        IScreenManager ScreenManager { get; set; }

        void Init();

        void Show();

        void Hide();

        void Destroy();
    }
}
