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


            StringBuilder fpsText = new StringBuilder(12);
            for (int i = 0; i < _fpsTexts.Length; i++)
            {
                fpsText.Clear();
                int ms = Mathf.RoundToInt(_second / (i > 0 ? i : 1) * 1000);
                _fpsTexts[i] = getFullInfoTemplate(i, ms);
            }
        }

        private const float _second = 1f;

        public int MaxFPSNumber { get; private set; }
        private string[] _fpsTexts;

        public float RawFPS { get { return _second / Time.unscaledDeltaTime; } }

        public int FPS { get { return Mathf.RoundToInt(RawFPS); } }

        public string FullInfo
        {
            get
            {
                int fps = FPS;
                return MaxFPSNumber > fps ? _fpsTexts[fps] : _fpsTexts[MaxFPSNumber];
            }
        }
    }
}
