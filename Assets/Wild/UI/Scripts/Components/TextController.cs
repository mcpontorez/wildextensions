﻿using UnityEngine;
using UnityEngine.UI;

namespace Wild.UI.Components
{
    public class TextController : TextControllerBase
    {
        [SerializeField]
        private Text _textComponent;
        public Text TextComponent { get { return _textComponent; } }
        public override MonoBehaviour TextComponentBase => TextComponent;

        protected override string GetText() => TextComponent.text;
        protected override void SetText(string value) => TextComponent.text = value;

        protected override void OnValidate()
        {
            base.OnValidate();
            if (_textComponent == null)
                _textComponent = GetComponentInChildren<Text>();
        }
    }
}
