using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Wild.UI.Helpers;

namespace Wild.UI.Components
{
    public sealed class CollectionViewController : UIMonoBehaviourBase, ICollectionView
    {
        [SerializeField]
        private ScrollRect _scrollRectComponent;
        public ScrollRect ScrollRectComponent { get { return _scrollRectComponent; } }

        [SerializeField]
        private CollectionGrouper _collectionGrouper;
        public CollectionGrouper CollectionGrouper { get { return _collectionGrouper; } }

        private ICollectionView _collectionView;
        private ICollectionView CollectionView
        {
            get
            {
                if(_collectionView == null)
                    _collectionView = new CollectionView(ScrollRectComponent.content);
                return _collectionView;
            }
        }

        public IReadOnlyList<Transform> Items => CollectionView.Items;
        public IReadOnlyList<TItem> GetItems<TItem>() => CollectionView.GetItems<TItem>();

        protected override void OnValidate()
        {
            _scrollRectComponent = GetComponent<ScrollRect>() ?? _scrollRectComponent;
            _collectionGrouper = GetComponentInChildren<CollectionGrouper>() ?? _collectionGrouper;
        }

        public void SetItems<TItem>(TItem sampleItem, int count, CollectionItemEventHandler<TItem> onItemInit = null) where TItem : Component
        {
            CollectionView.SetItems(sampleItem, count, onItemInit);

            ResetScrollPosition();
        }

        public void AddItem<T>(T item) where T : Component
        {
            CollectionView.AddItem(item);
        }

        public T CreateItem<T>(T sampleItem) where T : Component
        {            
            return CollectionView.CreateItem(sampleItem);
        }

        public void Clear()
        {
            CollectionView.Clear();

            ResetScrollPosition();
        }

        public void ResetScrollPosition()
        {
            if (ScrollRectComponent != null)
                ScrollRectComponent.normalizedPosition = Vector2.one;
        }
    }
}
