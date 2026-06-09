# ImageCLI

Command-line tool for optimizing and converting images,
built with C# and System.CommandLine.


## Requirements

- .NET 8 SDK (https://dotnet.microsoft.com/download)
- Visual Studio Code with the C# Dev Kit extension


## Installation

    dotnet new console -n ImageCLI
    cd ImageCLI

    dotnet add package System.CommandLine --version 2.0.0-beta4.22272.1
    dotnet add package SixLabors.ImageSharp --version 3.1.4

    dotnet build


## Project structure

    ImageCLI/
    ├── ImageCLI.csproj
    ├── Program.cs
    ├── Commands/
    │   ├── OptimizeCommand.cs
    │   ├── ConvertCommand.cs
    │   └── InfoCommand.cs
    └── Services/
        ├── ImageOptimizer.cs
        └── ImageConverter.cs


## Commands

### optimize

Reduces file size by adjusting compression quality.

    dotnet run -- optimize <input> [--output <path>] [--quality <1-100>]

Arguments:
  input        Path to the input image (required)
  --output     Output path (default: optimized_<filename>)
  --quality    Compression quality from 1 to 100 (default: 80)

Examples:

    dotnet run -- optimize photo.jpg
    dotnet run -- optimize photo.jpg --quality 60
    dotnet run -- optimize photo.jpg --output result.jpg --quality 70

Supported formats: .jpg, .jpeg, .webp, .png


### convert

Converts an image from one format to another.

    dotnet run -- convert <input> [--format <format>]

Arguments:
  input        Path to the input image (required)
  --format     Target format (default: png)

Available formats:
  png    Images with transparency
  jpg    Photographs
  webp   Modern web, better compression
  bmp    No compression, maximum quality
  gif    Simple animations

Examples:

    dotnet run -- convert photo.jpg --format webp
    dotnet run -- convert logo.png --format jpg
    dotnet run -- convert image.png --format bmp


### info

Displays basic metadata of an image.

    dotnet run -- info <input>

Example:

    dotnet run -- info photo.jpg

Output:

    File     : photo.jpg
    Format   : JPEG
    Size     : 1920 x 1080 px
    Weight   : 348.20 KB


## Publish as a global tool

Add the following lines to ImageCLI.csproj:

    <PropertyGroup>
      <PackAsTool>true</PackAsTool>
      <ToolCommandName>imgcli</ToolCommandName>
    </PropertyGroup>

Then pack and install:

    dotnet pack
    dotnet tool install --global --add-source ./nupkg ImageCLI

From that point you can use it from any folder:

    imgcli optimize photo.jpg --quality 75
    imgcli convert image.png --format webp
    imgcli info photo.jpg


## Dependencies

  System.CommandLine    2.0.0-beta4    CLI argument parsing
  SixLabors.ImageSharp  3.1.4          Image processing


## License

MIT - free for personal and commercial use.
