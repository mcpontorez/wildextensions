using UnityEngine;
using UnityEngine.UI;
using Wild.UI.Helpers;
using Wild.Strings;

namespace Wild.UI.Components
{
    public abstract class TextControllerBase : UIMonoBehaviourBase, ILabel
    {
        [SerializeField]
        private CaseTypes _casing = CaseTypes.AsIs;
        public CaseTypes Casing { get { return _casing; } set { _casing = value; Text = Text; } }

        public string Text { get => GetText(); set => SetText(value.ToCase(Casing)); }
        protected abstract string GetText();
        protected abstract void SetText(string value);
        public abstract MonoBehaviour TextComponentBase { get; }

        protected override void Start()
        {
            Casing = Casing;
        }
    }
}
