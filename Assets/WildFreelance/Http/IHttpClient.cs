using System;
using System.Collections.Generic;
using Wild.Coroutines;

namespace Wild.Freelance.Http
{
    public delegate void OnDownloadCompleted(bool isNoError);
    public delegate void OnDownloadProgressChanged(int percents);

    public interface IHttpClient
    {
        void GetTextAsync(string url, Action<string> onResultReceived);

        void DownloadFileAsync(string url, string filePath, ICancellationToken cancellationToken, OnDownloadCompleted onCompleted, OnDownloadProgressChanged onProgressChanged);

        void DownloadFileAsync(UrlFilePath urlFilePath, ICancellationToken cancellationToken, OnDownloadCompleted onCompleted, OnDownloadProgressChanged onProgressChanged);

        void DownloadFilesAsync(List<UrlFilePath> urlFilePaths, ICancellationToken cancellationToken, OnDownloadCompleted onCompleted, OnDownloadProgressChanged onProgressChanged);
    }
}
