using System;
using UnityEngine;

namespace Wild.UI.Components
{
    public sealed class ToggleButton : ButtonController
    {
        [SerializeField]
        private GameObject _onObject;
        [SerializeField]
        private GameObject _offObject;

        public event Action<bool> OnValueChanged;

        private bool _isOn = true;
        public bool IsOn
        {
            get { return _isOn; }
            set { SetIsOn(value); }
        }

        public void SetIsOn(bool isOn, bool invokeCallback = false)
        {
            _isOn = isOn;
            _offObject.SetActive(!_isOn);
            _onObject.SetActive(_isOn);
            if (invokeCallback)
                OnValueChanged?.Invoke(_isOn);
        }

        public override void InvokeOnCliсk()
        {
            base.InvokeOnCliсk();

            SetIsOn(!IsOn, true);
        }
    }
}
