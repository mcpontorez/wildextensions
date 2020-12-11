using UnityEngine;
using Wild.Generics;
using Wild.UI.ScreenManagement.Data;

namespace Wild.UI.ScreenManagement
{
    public abstract class ResourceScreenBase : ScreenBase
    {
        protected abstract string DataPath { get; }

        protected override ScreenData InitScreenData()
        {
            ScreenData data = Resources.Load<ScreenData>(DataPath);
            return Object.Instantiate(Data);
        }
    }
}
