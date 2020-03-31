using System;
using System.IO;
using UnityEngine;

namespace Wild.Screenshots
{
    public sealed class Screenshoter : MonoBehaviour
    {
        public KeyCode ScreenshotKey = KeyCode.P;

        private void Update()
        {
            if (Input.GetKeyDown(ScreenshotKey))
                CaptureScreenshot();
        }

        public void CaptureScreenshot()
        {
            string filePath = Path.Combine(Directory.CreateDirectory("Screenshots").FullName, 
                $"{nameof(Application.productName)} {DateTime.Now.ToString("yyyy.MM.dd HH.mm.ss")}.png");
            ScreenCapture.CaptureScreenshot(filePath);
            Debug.Log(nameof(ScreenCapture) + "to file: " + filePath);
        }
    }
}
