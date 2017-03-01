using System;
using System.Collections.Generic;
using UnityEngine;

namespace Wild.DebugInfo
{
    public class FpsInfo
    {
        public FpsInfo(uint maxFpsNumber)
        {
            _maxFPSNumber = Convert.ToInt32(maxFpsNumber);

            for (uint i = 0; i <= maxFpsNumber; i++)
            {
                string ms = Mathf.RoundToInt(_second / (i > 0 ? i : 1) * 1000).ToString();
                _fpsTexts.Add("FPS " + i + "  " + ms + "ms");
            }
        }

        private const float _second = 1f;

        private int _maxFPSNumber;
        private List<string> _fpsTexts = new List<string>();

        public float RawFPS { get { return _second / Time.deltaTime; } }

        public int FPS { get { return Mathf.RoundToInt(RawFPS); } }

        public string FullInfo
        {
            get
            {
                int fps = FPS;
                return _maxFPSNumber > fps ? _fpsTexts[fps] : _fpsTexts[_maxFPSNumber];
            }
        }
    }
}
