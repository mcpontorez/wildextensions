using UnityEngine;
using UnityEngine.UI;
using Wild.UI.Helpers;
using Wild.Strings;

namespace Wild.UI.Components
{
    public class TextController : UIMonoBehaviourBase, ILabel
    {
        [SerializeField]
        private CaseTypes _casing = CaseTypes.AsIs;
        public CaseTypes Casing { get { return _casing; } set { _casing = value; Text = Text; } }
        [SerializeField]
        private Text _textComponent;
        public Text TextComponent { get { return _textComponent; } }

        protected override void OnValidate()
        {
            base.OnValidate();
            if (_textComponent == null)
                _textComponent = GetComponentInChildren<Text>();
        }

        protected override void Start()
        {
            Casing = Casing;
        }

        public string Text { get { return TextComponent.text; } set { TextComponent.text = value.ToCase(Casing); } }
    }
}
