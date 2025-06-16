using NReco.VideoConverter;

namespace WEBM_FORMATTER;

public static class Converter
{

    public struct Standart
    {
        public const int frameRate = 30;
        public const int bitRate = 500;
        public const string frameSize = "512x512";
        public const int time = 3;
    }


    public static int Convert(string path, int frameRate = Standart.frameRate, int bitRate = Standart.bitRate, string frameSize = Standart.frameSize, int time = Standart.time)
    {
        if (path == null || !File.Exists(path))
        {
            Console.WriteLine("File not exists");
            return 1;
        }

        var ffMpeg = new FFMpegConverter();

        string outputPath = Path.Combine(Path.GetDirectoryName(path)!, Path.GetFileNameWithoutExtension(path) + ".webm");

        var outputOptions = new ConvertSettings
        {
            VideoCodec = "libvpx-vp9",
            VideoFrameRate = frameRate,
            VideoFrameSize = frameSize,
            CustomOutputArgs = $"-pix_fmt yuva420p -b:v {bitRate}k -crf 30 -quality best -cpu-used 4 -row-mt 1 -t {time}",
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