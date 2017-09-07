using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Wild.UI.Helpers;

namespace Wild.UI.Components
{
    public class SelectedHighlighter : UIMonoBehaviourBase, ISelectHandler, IDeselectHandler
    {
        [SerializeField]
        private List<GameObject> _highlightedObjects;

        private void Awake()
        {
            IsHiglihted = false;
        }

        public void OnSelect(BaseEventData eventData)
        {
            IsHiglihted = true;
        }

        public void OnDeselect(BaseEventData eventData)
        {
            IsHiglihted = false;
        }

        private bool _isHiglihted = false;
        public bool IsHiglihted
        {
            get { return _isHiglihted; }
            set
            {
                _isHiglihted = value;
                foreach (GameObject item in _highlightedObjects)
                {
                    item.SetActive(_isHiglihted);
                } 
            }
        }
    }
}
