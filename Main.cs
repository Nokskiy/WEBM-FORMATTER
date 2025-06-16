using System.Text.RegularExpressions;

namespace WEBM_FORMATTER;

public static class Program
{
    private static void Main()
    {
        while (true)
        {
            Console.WriteLine("Enter input file");
            string input = Console.ReadLine()!.ToString();

            Console.WriteLine("Enter framerate");
            string frameRateInput = Console.ReadLine()!;
            int frameRate = int.TryParse(frameRateInput, out int frameRateRes) && frameRateRes > 0 ? frameRateRes : Converter.Standart.frameRate;

            Console.WriteLine("Enter bitrate");
            string bitRateInput = Console.ReadLine()!;
            int bitRate = int.TryParse(bitRateInput, out int bitRateRes) && bitRateRes > 0 ? bitRateRes : Converter.Standart.frameRate;

            Console.WriteLine("Enter frame size like 512x512");
            string frameSizeInput = Console.ReadLine()!;
            bool isValidFormatForFrameSize(string input)
            {
                return Regex.IsMatch(input, @"^\d+x\d+$", RegexOptions.IgnoreCase);
            }
            string frameSize = isValidFormatForFrameSize(frameSizeInput) ? frameSizeInput : Converter.Standart.frameSize;

            Console.WriteLine("Enter time");
            string timeInput = Console.ReadLine()!;
            int time = int.TryParse(timeInput, out int timeRes) && timeRes > 0 ? timeRes : Converter.Standart.time;

            Converter.Convert(input, frameRate, bitRate, frameSize, time);
        }
    }
}