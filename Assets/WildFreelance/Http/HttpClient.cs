using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Wild.Coroutines;
using Wild.Systems;

namespace Wild.Freelance.Http
{
    public sealed class HttpClient : IHttpClient
    {
        private IGameLogicUpdateSystem GameLogicUpdateSystem { get; set; }

        public HttpClient(IGameLogicUpdateSystem gameLogicUpdateSystem)
        {
            GameLogicUpdateSystem = gameLogicUpdateSystem;
        }

        public void GetTextAsync(string url, Action<string> onResultReceived) =>
            GameLogicUpdateSystem.StartCoroutine(GettingTextAsync(url, onResultReceived));

        private IEnumerator GettingTextAsync(string url, Action<string> onResultReceived)
        {
            string text = string.Empty;

            using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
            {
                yield return webRequest.SendWebRequest();                
                Debug.Log(webRequest.isNetworkError ? webRequest.error : $"{nameof(HttpClient)}: Complete get from {url}");
                text = webRequest.downloadHandler.text;
            }
            onResultReceived?.Invoke(text);
        }

        public void DownloadFileAsync(string url, string filePath, ICancellationToken cancellationToken, OnDownloadCompleted onCompleted, OnDownloadProgressChanged onProgressChanged)
            => GameLogicUpdateSystem.StartCoroutine(DownloadingFile(url, filePath, cancellationToken, onCompleted, onProgressChanged));

        public void DownloadFileAsync(UrlFilePath urlFilePath, ICancellationToken cancellationToken, OnDownloadCompleted onCompleted, OnDownloadProgressChanged onProgressChanged)
            => DownloadFileAsync(urlFilePath.Url, urlFilePath.FilePath, cancellationToken, onCompleted, onProgressChanged);

        private IEnumerator DownloadingFile(string url, string filePath, ICancellationToken cancellationToken, OnDownloadCompleted onCompleted, OnDownloadProgressChanged onProgressChanged)
        {
            bool anyError = true;
            using (UnityWebRequest unityWebRequest = new UnityWebRequest(url, UnityWebRequest.kHttpVerbGET))
            {
                unityWebRequest.downloadHandler = new DownloadHandlerFile(filePath) { removeFileOnAbort = true };
                UnityWebRequestAsyncOperation asyncOperation = unityWebRequest.SendWebRequest();

                int lastPercents = 0;
                while(!asyncOperation.isDone)
                {
                    yield return new WaitForEndOfFrame();

                    if (cancellationToken.Canceled)
                    {
                        unityWebRequest.Abort();
                        break;
                    }

                    int currentPercents = Mathf.RoundToInt(asyncOperation.progress * 100f);
                    if (lastPercents < currentPercents)
                    {
                        onProgressChanged?.Invoke(currentPercents);
                        lastPercents = currentPercents;
                    }
                }

                anyError = unityWebRequest.isNetworkError || unityWebRequest.isHttpError;
                if (anyError)
                    Debug.LogError(unityWebRequest.error);
                else
                    Debug.Log($"{nameof(HttpClient)}: File successfully downloaded and saved to " + filePath);
            }
            onCompleted?.Invoke(!anyError);
        }

        public void DownloadFilesAsync(List<UrlFilePath> urlFilePaths, ICancellationToken cancellationToken, OnDownloadCompleted onCompleted, OnDownloadProgressChanged onProgressChanged)
            => GameLogicUpdateSystem.StartCoroutine(DownloadingFiles(urlFilePaths, cancellationToken, onCompleted, onProgressChanged));
        public IEnumerator DownloadingFiles(List<UrlFilePath> urlFilePaths, ICancellationToken cancellationToken, OnDownloadCompleted onCompleted, OnDownloadProgressChanged onProgressChanged)
        {
            bool noError = true;
            for (int i = 0; i < urlFilePaths.Count; i++)
            {
                if (cancellationToken.Canceled)
                {
                    noError = false;
                    break;
                }
                int currentI = i;
                int currentCount = urlFilePaths.Count;
                UrlFilePath item = urlFilePaths[i];
                yield return GameLogicUpdateSystem.StartCoroutine(DownloadingFile(item.Url, item.FilePath, cancellationToken,
                    (ne) => { if (!ne) noError = ne; },
                    (percents) =>
                    {
                        int currentPercents = Mathf.RoundToInt((100 * currentI + percents) / (float)currentCount);
                        onProgressChanged?.Invoke(currentPercents);
                    }));
            }
            onCompleted?.Invoke(noError);
        }
    }
}
