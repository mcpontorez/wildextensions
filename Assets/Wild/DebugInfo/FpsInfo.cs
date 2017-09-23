using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Wild.DebugInfo
{
    public class FpsInfo
    {
        public FpsInfo(int maxFpsNumber = 60, Func<int, int, string> getFullInfoTemplate = null)
        {
            if (maxFpsNumber < 0)
                throw new ArgumentException($"{nameof(maxFpsNumber)} cannot be less than zero", nameof(maxFpsNumber));

            MaxFPSNumber = maxFpsNumber;
            _fpsTexts = new string[MaxFPSNumber + 1];

            if(getFullInfoTemplate == null)
                getFullInfoTemplate = (fpsCount, ms) => new StringBuilder(14).Append("FPS ").Append(fpsCount).Append("  ").Append(ms).Append("ms").ToString();

            for (int i = 0; i < _fpsTexts.Length; i++)
            {
                int ms = Mathf.RoundToInt(_second / (i > 0 ? i : 1) * 1000);
                _fpsTexts[i] = getFullInfoTemplate(i, ms);
            }
        }

        private const float _second = 1f;

        public int MaxFPSNumber { get; private set; }
        private string[] _fpsTexts;

        public float RawFps { get { return _second / Time.unscaledDeltaTime; } }

        public int Fps { get { return Mathf.RoundToInt(RawFps); } }

        public string FullInfo
        {
            get
            {
                int fps = Fps;
                return MaxFPSNumber > fps ? _fpsTexts[fps] : _fpsTexts[MaxFPSNumber];
            }
        }
    }
}
