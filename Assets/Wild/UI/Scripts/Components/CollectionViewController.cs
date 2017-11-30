using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Wild.UI.Helpers;

namespace Wild.UI.Components
{
    public class CollectionViewController : UIMonoBehaviourBase, ICollectionView
    {
        [SerializeField]
        private ScrollRect _scrollRectComponent;
        public ScrollRect ScrollRectComponent { get { return _scrollRectComponent; } }

        [SerializeField]
        private CollectionGrouper _collectionGrouper;
        public CollectionGrouper CollectionGrouper { get { return _collectionGrouper; } }

        private List<Component> _items = new List<Component>();

        private void OnValidate()
        {
            _scrollRectComponent = GetComponent<ScrollRect>();
            _collectionGrouper = GetComponentInChildren<CollectionGrouper>();
        }

        public void SetItems<T>(T sampleItem, int count, System.Action<T, int> onItemInit) where T : Component
        {
            Clear();
            
            for (int i = 0; i < count; i++)
            {
                T item = Instantiate(sampleItem);
                AddItem(item);
                onItemInit(item, i);
            }

            ResetScrollPosition();
        }

        public void AddItem<T>(T item) where T : Component
        {
            item.transform.SetParent(_scrollRectComponent.content, false);
            _items.Add(item);
        }

        public T CreateItem<T>(T sampleItem) where T : Component
        {
            T item = Instantiate(sampleItem);
            AddItem(item);
            return item;
        }

        public void Clear()
        {
            foreach (var item in _items)
            {
                Destroy(item.gameObject);
            }
            _items.Clear();

            ResetScrollPosition();
        }

        public void ResetScrollPosition()
        {
            if (_scrollRectComponent != null)
            _scrollRectComponent.normalizedPosition = Vector2.one;
        }
    }
}
