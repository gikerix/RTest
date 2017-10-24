using System;

namespace InflationaryEnglishConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please input the phrase:");
            var phrase = Console.ReadLine().Trim();
            if (string.IsNullOrEmpty(phrase))
            {
                Console.WriteLine("Your input is empty. Try again.");
                Console.ReadLine();
                return;
            }
            var convertor = new InflationaryEnglishCore.PhraseConverter();
            var result = convertor.Convert(phrase);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
