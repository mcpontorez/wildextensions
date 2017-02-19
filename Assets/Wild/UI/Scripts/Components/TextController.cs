using Wild.InterfacesMB;
using UnityEngine;
using UnityEngine.UI;
using Wild.UI.Helpers;
using Wild.Strings;

namespace Wild.UI.Components
{
    public class TextController : UIMonoBehaviourBase, ILabel, IOnValidate
    {
        [SerializeField]
        private CaseTypes _casing;
        public CaseTypes Casing { get { return _casing; } set { Text = Text; } }
        [SerializeField]
        private Text _textComponent;
        public Text TextComponent { get { return _textComponent;} }

        public void OnValidate()
        {
            _textComponent = GetComponent<Text>();
        }

        public string Text { get { return TextComponent.text; } set { TextComponent.text = value.ToCase(Casing); } }
    }
}
