using System.CommandLine;
using System.IO;
using System;
using System.Threading.Tasks;

namespace ImageCLI.Commands
{
    public class OptimizeCommand
    {
        public static Command Build()
        {
            var inputArg = new Argument<FileInfo>("input", "file image to optimize");
            var outputArg = new Argument<FileInfo>("output", "optimized image output path");
            var qualityOpt = new Option<int>("--quality", () => 80, "quality of the optimized image (0-100)");

            var cmd = new Command("optimize", "Optimize an image")
            {
                inputArg,
                outputArg,
                qualityOpt
            };

            // SetHandler disponible en 2.x
            cmd.SetHandler(async (FileInfo input, FileInfo output, int quality) =>
            {
                output ??= new FileInfo(Path.Combine(input.DirectoryName, $"{Path.GetFileNameWithoutExtension(input.Name)}_optimized{input.Extension}"));

                Console.WriteLine($"Optimizing {input.Name} to {output.Name} with quality {quality}...");
                await ImageProcessor.OptimizeImageAsync(input.FullName, output.FullName, quality);
                Console.WriteLine("Optimization completed.");
            }, inputArg, outputArg, qualityOpt);

            return cmd;
        }
    }

    public static class ImageProcessor
    {
        public static Task OptimizeImageAsync(string inputPath, string outputPath, int quality)
        {
            Console.WriteLine($"[Simulación] Optimizar {inputPath} -> {outputPath} con calidad {quality}");
            return Task.CompletedTask;
        }
    }
}
