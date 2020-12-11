using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Wild.Singletons;

namespace Wild.UI.ScreenManagement.Data
{
    public sealed class ScreenDatasSceneSingleton : ForceSingletonMonoBehaviour<ScreenDatasSceneSingleton>
    {
        [SerializeField]
        private ScreenData[] _datas;
        private Dictionary<string, ScreenData> _nameDataPairs;
        public IReadOnlyDictionary<string, ScreenData> NameDataPairs => _nameDataPairs ?? (_nameDataPairs = _datas.ToDictionary(d => d.name));

        public ScreenData GetScreenData(string name) =>
            NameDataPairs.TryGetValue(name, out var screenData) ? screenData : throw new ArgumentException($"{nameof(screenData)} by name {name} is not Found!");
    }
}
