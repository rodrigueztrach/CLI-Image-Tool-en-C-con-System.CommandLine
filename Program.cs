using System.CommandLine;
using ImageCLI.Commands;

var rootCommand = new RootCommand("ImageCLI - Optimizador y conversor de imágenes");

rootCommand.AddCommand(OptimizeCommand.Build());
rootCommand.AddCommand(ConvertCommand.Build());
rootCommand.AddCommand(InfoCommand.Build());

return await rootCommand.InvokeAsync(args);