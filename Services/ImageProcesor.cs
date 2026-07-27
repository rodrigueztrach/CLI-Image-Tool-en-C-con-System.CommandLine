using System;
using System.IO;
using System.Threading.Tasks;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace MiCliDeImagenes.Services
{
    public class ImageProcessor
    {
        public static void ProcesarLote(string origen, string destino, string comodin, int ancho)
        {
            if (!Directory.Exists(origen)) return;
            Directory.CreateDirectory(destino);

            string[] archivos = Directory.GetFiles(origen, comodin);

            Parallel.ForEach(archivos, archivo =>
            {
                try
                {
                    string rutaSalida = Path.Combine(destino, Path.GetFileName(archivo));
                    using (Image image = Image.Load(archivo))
                    {
                        image.Mutate(x => x.Resize(ancho, 0)); // Simplificado
                        image.Save(rutaSalida);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error en {Path.GetFileName(archivo)}: {ex.Message}");
                }
            });
        }
    }
}
