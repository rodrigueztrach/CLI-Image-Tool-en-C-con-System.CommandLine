using SixLabors.ImageSharp;

namespace ImageCLI.Services;

public static class ImageConverter
{
    public static async Task ConvertAsync(FileInfo input, FileInfo output, string format)
    {
        using var image = await Image.LoadAsync(input.FullName);

        await (format.ToLower() switch
        {
            "jpg" or "jpeg" => image.SaveAsJpegAsync(output.FullName),
            "png"           => image.SaveAsPngAsync(output.FullName),
            "webp"          => image.SaveAsWebpAsync(output.FullName),
            "bmp"           => image.SaveAsBmpAsync(output.FullName),
            "gif"           => image.SaveAsGifAsync(output.FullName),
            _ => throw new NotSupportedException($"Format '{format}' is not supported.")
        });
    }
}