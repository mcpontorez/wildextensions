using System;
using UnityEngine;
using UnityEngine.UI;
using Wild.UI.Helpers;

namespace Wild.UI.Components
{
    [RequireComponent(typeof(CollectionGrouper))]
    public abstract class FillGridLayoutBase : UIMonoBehaviourBase
    {
        [SerializeField]
        private CollectionGrouper _collectionGrouper;
        public CollectionGrouper CollectionGrouper => _collectionGrouper;

        protected override void OnValidate()
        {
            base.OnValidate();

            _collectionGrouper = GetComponent<CollectionGrouper>();
        }

        private void Update()
        {
            int cellCount = RectTransform.childCount;
            if (cellCount == 0)
                return;

            CollectionGrouper.SetAsGrid(GetCellSize(RectTransform.rect.size, cellCount));
        }

        protected abstract Vector2 GetCellSize(Vector2 parentSize, int cellCount);
    }
}
