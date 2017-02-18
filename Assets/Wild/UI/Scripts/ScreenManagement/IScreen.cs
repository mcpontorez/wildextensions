using Wild.UI.ScreenManagement.Data;

namespace Wild.UI.ScreenManagement
{
    public interface IScreen
    {
        ScreenData Data { get; }

        void Init();

        void Show();

        void Hide();

        void Destroy();
    }
}
