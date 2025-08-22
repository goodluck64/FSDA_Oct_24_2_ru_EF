using System.Diagnostics;
using Patterns.Proxy;

var imageManager = new ImagerManager();
var imageManagerProxy = new ImageManagerProxy(imageManager);
var path = imageManagerProxy.GetImagePathByUrl(
    @"https://hips.hearstapps.com/hmg-prod/images/white-cat-breeds-kitten-in-grass-67bf648a54a3b.jpg");

var fullPath = Path.Combine(Directory.GetCurrentDirectory(), path!);

Process.Start("mspaint", new List<string>() { fullPath });