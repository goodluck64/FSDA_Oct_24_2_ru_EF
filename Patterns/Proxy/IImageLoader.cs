using System.Diagnostics;
using System.Net;

namespace Patterns.Proxy;

internal interface IImageManager
{
    void LoadImage(string url);
    string? GetImagePathByUrl(string url);
}

internal interface IImageOpener
{
    string OpenImage(string url);
}

internal sealed class ImagerManager : IImageManager
{
    public void LoadImage(string url)
    {
        var webClient = new WebClient();
        var filePath = ImageManagerHelpers.GetFilePathWithUrl(url);

        webClient.DownloadFile(url, filePath);
    }

    public string? GetImagePathByUrl(string url)
    {
        Console.WriteLine("[ImagerManager::GetImagePathByUrl]");

        try
        {
            LoadImage(url);

            return ImageManagerHelpers.GetFilePathWithUrl(url);
        }
        catch
        {
            return null;
        }
    }
}

internal sealed class ImageManagerProxy : IImageManager
{
    private readonly IImageManager _imageManager;

    public ImageManagerProxy(IImageManager imageManager)
    {
        _imageManager = imageManager;
    }

    public void LoadImage(string url)
    {
        var filePath = ImageManagerHelpers.GetFilePathWithUrl(url);

        if (!File.Exists(filePath))
        {
            _imageManager.LoadImage(url);
        }
    }

    public string? GetImagePathByUrl(string url)
    {
        Console.WriteLine("[ImageManagerProxy::GetImagePathByUrl]");
        
        var filePath = ImageManagerHelpers.GetFilePathWithUrl(url);
        
        if (File.Exists(filePath))
        {
            return filePath;
        }

        return _imageManager.GetImagePathByUrl(url);
    }
}

internal static class ImageManagerHelpers
{
    public static string GetFilePathWithUrl(string url)
    {
        return Path.Combine("Images", Helpers.GetFileNameFromUrl(url));
    }
}

internal static class Helpers
{
    public static string GetFileNameFromUrl(string url)
    {
        // https://www.google.com/site/image.png

        var split = url.Split('/');

        if (split.Length > 1)
        {
            return split.Last();
        }

        throw new InvalidOperationException("No filename here.");
    }
}