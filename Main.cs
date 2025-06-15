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
            string? framerateLine = Console.ReadLine();

            Console.WriteLine("Enter bitrate");
            string? bitrateLine = Console.ReadLine();

            int framerate = framerateLine != string.Empty ? int.Parse(framerateLine!) : 0;
            int bitrate = bitrateLine != string.Empty ? int.Parse(bitrateLine!) : 0;


            if (framerate >= 1)
                if (bitrate != 0)
                    Converter.Convert(input, framerate, bitrate);
                else
                    Converter.Convert(input, framerate);
            else
                Converter.Convert(input);
        }
    }
}