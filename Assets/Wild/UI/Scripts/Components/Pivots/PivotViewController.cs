using System;
using System.Collections.Generic;
using UnityEngine;
using Wild.UI.Helpers;

namespace Wild.UI.Components.Pivots
{
    public class PivotViewController : UIMonoBehaviourBase
    {
        [SerializeField]
        protected TextController _mainTitle;
        public int SelectedTitleIndex { get; private set; }

        [SerializeField]
        protected RectTransform _titlesPanel;
        [SerializeField]
        protected ButtonController _samleTitle;

        protected List<ButtonController> _titles = new List<ButtonController>();

        public void AddTitle(string text, Action onSelected)
        {
            ButtonController title = Instantiate(_samleTitle, _titlesPanel, false);
            _titles.Add(title);

            title.Text = text;
            int index = _titles.Count - 1;
            title.OnClick += () =>
            {
                SetTitleAsMainTitle(index);

                onSelected();
            };

            if (_titles.Count == 1)
                SelectTitle(0);
        }

        protected void SetTitleAsMainTitle(int index)
        {
            ButtonController title = _titles[index];
            while(title.RectTransform.GetSiblingIndex() > 0)
            {
                Transform otherTitle = _titlesPanel.GetChild(0);
                otherTitle.SetAsLastSibling();
                otherTitle.gameObject.SetActive(true);
            }
            title.gameObject.SetActive(false);

            _mainTitle.Text = title.Text;
            SelectedTitleIndex = index;
        }

        public void Clear()
        {
            foreach (var item in _titles)
            {
                Destroy(item);
            }
            _titles.Clear();
        }

        public void SelectTitle(int index)
        {
            if (index >= _titles.Count)
                index = 0;
            else if (index < 0)
                index = _titles.Count - 1;

            _titles[index].InvokeOnCliсk();
        }

        public void SelectNextTitle()
        {
            SelectTitle(SelectedTitleIndex + 1);
        }

        public void SelectPreviousTitle()
        {
            SelectTitle(SelectedTitleIndex - 1);
        }

        public void ReselectCurrentTitle()
        {
            SelectTitle(SelectedTitleIndex);
        }
    }
}
