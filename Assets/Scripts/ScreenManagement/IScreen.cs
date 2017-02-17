namespace Wild.UI.ScreenManagement
{
    public interface IScreen
    {
        void Init();

        void Show();

        void Hide();

        void Destroy();
    }
}
