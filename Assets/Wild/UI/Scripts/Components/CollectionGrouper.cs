using System;
using UnityEngine;
using UnityEngine.UI;
using Wild.InterfacesMB;
using Wild.UI.Helpers;

namespace Wild.UI.Components
{
    [RequireComponent(typeof(GridLayoutGroup))]
    public class CollectionGrouper : UIMonoBehaviourBase
    {
        [SerializeField]
        private GridLayoutGroup _gridLayoutGroup;
        public GridLayoutGroup GridLayoutGroup { get { return _gridLayoutGroup; } }

        [SerializeField]
        private Scrollbar _scrollbar;
        public Scrollbar Scrollbar { get { return _scrollbar; } }

        protected override void OnValidate()
        {
            base.OnValidate();

            _gridLayoutGroup = GetComponent<GridLayoutGroup>();
        }

        public void SetAsGrid(Vector2 cellSize, Vector2? spacing = null, RectOffset padding = null)
        {
            OnRegroup += (gridLayoutGroup) =>
            {
                gridLayoutGroup.cellSize = cellSize;
                if(spacing != null)
                    gridLayoutGroup.spacing = spacing.Value;
                if(padding != null)
                    gridLayoutGroup.padding = padding;
            };
        }

        public void SetAsList(float cellHeight, float spacingVertical = 0f, RectOffset padding = null)
        {
            OnRegroup += (gridLayoutGroup) =>
            {
                float width = Scrollbar ? RectTransform.rect.width - Scrollbar.handleRect.rect.width * 2f : RectTransform.rect.width;
                gridLayoutGroup.cellSize = new Vector2(width, cellHeight);
                gridLayoutGroup.spacing = new Vector2(0f, spacingVertical);
                if (padding != null)
                    gridLayoutGroup.padding = padding;
            };
        }

        /// <summary>
        /// ПОдписываться для перегруппировки Cell в GridLayoutGroup
        /// </summary>
        public event Action<GridLayoutGroup> OnRegroup;

        public void LateUpdate()
        {
            if (OnRegroup == null)
                return;
            OnRegroup(GridLayoutGroup);
            OnRegroup = null;
        }
    }
}
