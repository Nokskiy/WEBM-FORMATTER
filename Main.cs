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

            int framerate = framerateLine != string.Empty ? int.Parse(framerateLine!) : 0;

            if (framerate >= 1)
                Converter.Convert(input, framerate);
            else
                Converter.Convert(input);
        }
    }
}