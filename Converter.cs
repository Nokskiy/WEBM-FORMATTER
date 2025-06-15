using System;
using NReco.VideoConverter;

namespace WEBM_FORMATTER;

public static class Converter
{
    public static int Convert(string path, int frameRate = 30)
    {
        if (path == null) return 1;

        var ffMpeg = new FFMpegConverter();

        var outputOptions = new ConvertSettings();
        outputOptions.VideoCodec = "libvpx-vp9"; // Use VP9 for WebM with alpha channel support
        outputOptions.VideoFrameRate = frameRate;

        string outputPath = Path.GetDirectoryName(path) + @"\" + Path.GetFileNameWithoutExtension(path) + ".WEBM";

        Console.WriteLine("Output - " + outputPath);

        ffMpeg.ConvertMedia(path, null, outputPath, Format.webm, outputOptions);
        return 0;
    }
}