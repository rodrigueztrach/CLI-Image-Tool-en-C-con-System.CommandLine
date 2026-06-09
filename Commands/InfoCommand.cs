using System.CommandLine;
using SixLabors.ImageSharp;

namespace ImageCLI.Commands;

public static class InfoCommand
{
    public static Command Build()
    {
        var inputArg = new Argument<FileInfo>("input", "Image file to analyze");

        var cmd = new Command("info", "Display information about an image")
        {
            inputArg
        };

        cmd.SetHandler(async (input) =>
        {
            using var image = await Image.LoadAsync(input.FullName);
            Console.WriteLine($"File: {input.Name}");
            Console.WriteLine($"Format: {image.Metadata.DecodedImageFormat.Name}");
            Console.WriteLine($"Dimensions: {image.Width}x{image.Height}");
            Console.WriteLine($"Size: {input.Length / 1024.0:F2} KB");
        }, inputArg);

        return cmd;
    }
}