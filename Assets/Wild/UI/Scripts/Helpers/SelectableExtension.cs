using UnityEngine.UI;

namespace Wild.UI.Helpers
{
    public static class SelectableExtension
    {
        public static void SetNavigationMode(this Selectable source, Navigation.Mode mode)
        {
            Navigation navigation = source.navigation;
            navigation.mode = mode;
            source.navigation = navigation;
        }
    }
}
