using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.Formats.Webp;
using Task = System.Threading.Tasks.Task;
using FileInfo = System.IO.FileInfo;

namespace ImageCLI.Services;

public static class ImageOptimizer
{
    public static async Task OptimizeAsync(FileInfo input, FileInfo output, int quality)
    {
        using var image = await Image.LoadAsync(input.FullName);
        var ext = output.Extension.ToLower();

        if (ext == ".jpg" || ext == ".jpeg")
        {
            var encoder = new JpegEncoder { Quality = quality };
            await image.SaveAsJpegAsync(output.FullName, encoder);
        }
        else if (ext == ".webp")
        {
            var encoder = new WebpEncoder { Quality = quality };
            await image.SaveAsWebpAsync(output.FullName, encoder);
        }
        else
        {
            var encoder = new PngEncoder
            {
                CompressionLevel = PngCompressionLevel.BestCompression
            };
            await image.SaveAsPngAsync(output.FullName, encoder);
        }
    }
}