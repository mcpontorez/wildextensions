using System;
using System.Collections.Generic;
using UnityEngine;

namespace Wild.UI.Components
{
    public interface ICollectionView
    {
        IReadOnlyList<Transform> Items { get; }
        IReadOnlyList<TItem> GetItems<TItem>();

        void SetItems<TItem>(TItem sampleItem, int count, CollectionItemEventHandler<TItem> onItemInit = null) where TItem : Component;

        void AddItem<TItem>(TItem item) where TItem : Component;

        TItem CreateItem<TItem>(TItem sampleItem) where TItem : Component;

        void Clear();
    }
}
