using Wild.InterfacesMB;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Wild.UI.Helpers;

namespace Wild.UI.Components
{
    public class ListViewController : UIMonoBehaviourBase, IOnValidate
    {
        [SerializeField]
        private ScrollRect _scrollRect;

        private List<UIMonoBehaviourBase> _items = new List<UIMonoBehaviourBase>();

        public void OnValidate()
        {
            _scrollRect = GetComponent<ScrollRect>();
        }

        public void SetItems<T>(T sampleItem, int count, System.Action<T, int> onItemInit) where T : UIMonoBehaviourBase
        {
            Clear();
            
            for (int i = 0; i < count; i++)
            {
                T item = Instantiate(sampleItem, _scrollRect.content, false);
                _items.Add(item);
                onItemInit(item, i);
            }

            ResetScrollPosition();
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
            _scrollRect.normalizedPosition = Vector2.one;
        }
    }
}
