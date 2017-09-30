using Wild.Generics;

namespace Wild.UI.ScreenManagement
{
    public interface INextScreen<TScreen> where TScreen : IScreen
    {
        IGenericNewTypeContainer<TScreen> PreviousScreenType { get; }
    }
}
