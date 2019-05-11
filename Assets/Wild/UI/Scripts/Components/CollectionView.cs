using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Wild.Components;

namespace Wild.UI.Components
{
    public class CollectionView : ICollectionView
    {
        public Transform Content { get; private set; }

        public IReadOnlyList<Transform> Items => Content.GetChilds();

        public IReadOnlyList<TItem> GetItems<TItem>() => Items.Select(i => i.GetComponentInChildren<TItem>()).ToList();

        public CollectionView(Transform content)
        {
            Content = content;
        }

        public void SetItems<TItem>(TItem sampleItem, int count, CollectionItemEventHandler<TItem> onItemInit = null) where TItem : Component
        {
            Clear();
            
            for (int i = 0; i < count; i++)
            {
                var item = CreateItem(sampleItem);
                onItemInit?.Invoke(this, new CollectionItemEventArgs<TItem>(item, i));
            }
        }

        public void AddItem<T>(T item) where T : Component
        {
            item.transform.SetParent(Content, false);
        }

        public T CreateItem<T>(T sampleItem) where T : Component
        {
            T item = UnityEngine.Object.Instantiate(sampleItem);
            AddItem(item);
            return item;
        }

        public void Clear()
        {
            foreach (var item in Items)
            {
                UnityEngine.Object.Destroy(item.gameObject);
            }
        }
    }
}
