using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WildUI.UIHelpers;

namespace WildUI.UIComponents
{
    public class ListViewController : UIMonoBehaviourBase
    {
        [SerializeField]
        private RectTransform _content;

        private List<UIMonoBehaviourBase> _items = new List<UIMonoBehaviourBase>();

        public void SetItems<T>(T sampleItem, int count, System.Action<T, int> onItemInit) where T : UIMonoBehaviourBase
        {
            Clear();

            for (int i = 0; i < count; i++)
            {
                T item = Instantiate(sampleItem, _content, false);
                _items.Add(item);
                onItemInit(item, i);
            }
        }

        public void Clear()
        {
            for (int i = _items.Count - 1; i >= 0; i--)
            {
                Destroy(_items[i]);
                _items.RemoveAt(i);
            }
        }
    }
}
