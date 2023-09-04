using System;
using System.Collections;
using UnityEngine;
using Wild.Systems;

namespace Wild.UserAcrivites
{
    public sealed class UserActivityWatcher : IDisposable, IUserActivityWatcher
    {
        private readonly float _userActiveWaitTime;
        public bool IsEnabled { get; private set; } = false;
        public void Enable()
        {
            IsEnabled = true;
            _isLastAnyKey = !Input.anyKey;
            StartWaiting();
        }
        public void Disable()
        {
            IsEnabled = false;
            StopWaiting();
        }

        private Coroutine _waiting;
        private readonly IGameLogicUpdateSystem _gameLogicUpdateSystem;

        public event Action UserNotActiveDetected;
        public UserActivityWatcher(IGameLogicUpdateSystem gameLogicUpdateSystem, float userActiveWaitTime)
        {
            _gameLogicUpdateSystem = gameLogicUpdateSystem;
            _userActiveWaitTime = userActiveWaitTime;

            _gameLogicUpdateSystem.Updated += Update;
        }

        private void StopWaiting() => _gameLogicUpdateSystem.StopNullableCoroutine(_waiting);
        private void StartWaiting()
        {
            StopWaiting();
            _waiting = _gameLogicUpdateSystem.StartCoroutine(Wait());
        }

        private bool _isLastAnyKey = true;

        private void Update()
        {
            if (IsEnabled)
            {
                if (Input.anyKey != _isLastAnyKey)
                {
                    _isLastAnyKey = Input.anyKey;
                    if (_isLastAnyKey)
                    {
                        StopWaiting();
                    }
                    else
                        StartWaiting();
                }
            }
        }

        private IEnumerator Wait()
        {
            yield return new WaitForSeconds(_userActiveWaitTime);
            UserNotActiveDetected.Invoke();
        }

        #region IDispose implementation
        private bool _isDisposed = false;

        public void Dispose()
        {
            if (_isDisposed)
                return;

            _gameLogicUpdateSystem.Updated -= Update;

            _isDisposed = true;
        }
        #endregion
    }
}
