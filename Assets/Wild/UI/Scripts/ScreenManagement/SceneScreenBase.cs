using System;
using UnityEngine;
using Wild.UI.ScreenManagement.Data;

namespace Wild.UI.ScreenManagement
{
    public abstract class SceneScreenBase : ScreenBase
    {
        protected abstract string DataName { get; }

        protected override ScreenData InitScreenData()
            => ScreenDatasSceneSingleton.Instance.GetScreenData(DataName);
    }
}
