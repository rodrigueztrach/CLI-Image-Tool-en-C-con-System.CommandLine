using System.CommandLine;
using ImageCLI.Commands;

namespace ImageCLI.Commands
{
    public class OptimizeCommand
    {
        public static Command Build()
        {
            var inputArg = new Argument<fileInfo>("input", "file image to optimize");
            var outputArg = new Argument<fileInfo>("output", "optimized image output path");
            var qualityOpt = new Option<int>("--quality", () => 80, "quality of the optimized image (0-100)");
        
        var cmd = new Command("optimize", "Optimize an image")
        {
            inputArg,
            outputArg,
            qualityOpt
        };

        cmd.sethandler(async(input, output, quality) =>
        {
            output ??= new FileInfo(Path.Combine(input.DirectoryName, $"{Path.GetFileNameWithoutExtension(input.Name)}_optimized{input.Extension}"));

            Console.WriteLine($"Optimizing {input.Name} to {output.Name} with quality {quality}...");
            await ImageProcessor.OptimizeImageAsync(input.FullName, output.FullName, quality);
            Console.WriteLine("Optimization completed.");

        },inputArg, outputArg, qualityOpt);

        return cmd;
        }
    }
}