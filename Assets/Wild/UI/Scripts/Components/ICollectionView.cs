using UnityEngine;

namespace Wild.UI.Components
{
    public interface ICollectionView
    {
        void SetItems<T>(T sampleItem, int count, System.Action<T, int> onItemInit) where T : Component;

        void AddItem<T>(T item) where T : Component;

        T CreateItem<T>(T sampleItem) where T : Component;

        void Clear();
    }
}
