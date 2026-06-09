using System.CommandLine;
using ImageCLI.Services;

namespace ImageCLI.Commands;

public static class ConvertCommand
{
    public static Command Build()
    {
        var inputArg  = new Argument<FileInfo>("input", "Image file to convert (format: png, jpg, webp, bmp, gif)");
        var formatOpt = new Option<string>("--format", () => "png",
            "Destination format: png, jpg, webp, bmp, gif");

        var cmd = new Command("convert", "Convert an image to another format")
        {
            inputArg, formatOpt
        };

        cmd.SetHandler(async (input, format) =>
        {
            var outputPath = Path.ChangeExtension(input.FullName, format);
            var output = new FileInfo(outputPath);

            Console.WriteLine($"Converting {input.Name} → {format.ToUpper()}...");
            await ImageConverter.ConvertAsync(input, output, format);
            Console.WriteLine($"Saved to: {output.FullName}");

        }, inputArg, formatOpt);

        return cmd;
    }
}