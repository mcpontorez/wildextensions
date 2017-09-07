using UnityEngine;
using UnityEngine.UI;

namespace Wild.UI.Components
{
    public class ButtonController : Clickable, IButton
    {
        [SerializeField]
        private TextController _textController;
        public TextController TextController { get { return _textController; } }

        [SerializeField]
        private Button _buttonComponent;
        public Button ButtonComponent { get { return _buttonComponent; } }

        protected virtual void OnValidate()
        {
            _buttonComponent = GetComponent<Button>();
            _textController = GetComponentInChildren<TextController>();
        }

        public virtual string Text { get { return TextController.Text; } set { TextController.Text = value; } }
    }
}
