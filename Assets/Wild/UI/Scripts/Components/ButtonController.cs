using UnityEngine;
using UnityEngine.UI;

namespace Wild.UI.Components
{
    public class ButtonController : Clickable, IButton
    {
        [SerializeField]
        private TextControllerBase _textController;
        public TextControllerBase TextController { get { return _textController; } }

        [SerializeField]
        private Button _buttonComponent;
        public Button ButtonComponent { get { return _buttonComponent; } }

        public virtual string Text { get { return TextController.Text; } set { TextController.Text = value; } }

        protected override void OnInteractableChanged(bool value)
        {
            base.OnInteractableChanged(value);
            ButtonComponent.interactable = value;
        }

        protected override void Start()
        {
            base.Start();
            ButtonComponent.onClick.AddListener(InvokeOnCliсk);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            ButtonComponent.onClick.RemoveListener(InvokeOnCliсk);
        }
    }
}