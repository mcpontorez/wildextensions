using System;

namespace Wild.UserAcrivites
{
    public interface IUserActivityWatcher
    {
        bool IsEnabled { get; }
        event Action UserNotActiveDetected;
        void Enable();
        void Disable();
    }
}