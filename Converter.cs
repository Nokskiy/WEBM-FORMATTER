using System;
using NReco.VideoConverter;

namespace WEBM_FORMATTER;

public static class Converter
{
    public static int Convert(string path, int frameRate = 30)
    {
        if (path == null || !File.Exists(path))
        {
            Console.WriteLine("File not exists");
            return 1;
        }

        var ffMpeg = new FFMpegConverter();
        string outputPath = Path.Combine(
            Path.GetDirectoryName(path)!,
            Path.GetFileNameWithoutExtension(path) + ".webm");

        var outputOptions = new ConvertSettings
        {
            VideoCodec = "libvpx-vp9",
            VideoFrameRate = frameRate,
            CustomOutputArgs = "-pix_fmt yuva420p -b:v 500k -crf 30 -quality good -cpu-used 4 -row-mt 1 -t 3",
        };

        try
        {
            ffMpeg.ConvertMedia(path, null, outputPath, Format.webm, outputOptions);
            Console.WriteLine($"Output:: {outputPath}");
            return 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return 1;
        }
    }
}