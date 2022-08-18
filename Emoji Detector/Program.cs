using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Emoji_Detector
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            long cool = 1;

            string paternEmodji = @"(:{2}|\*{2})(?<emodji>[A-Z][a-z]{2,})\1";
            string digitPattern = @"\d";

            MatchCollection matchesEmodji = Regex.Matches(text, paternEmodji);
         
            MatchCollection matchesColl = Regex.Matches(text, digitPattern);

            foreach (Match digit in matchesColl)
            {
                cool *= long.Parse(digit.Value);
            }
            Console.WriteLine($"Cool threshold: {cool}");
            Console.WriteLine($"{matchesEmodji.Count} emojis found in the text. The cool ones are:");

            foreach (Match emodji in matchesEmodji)
            {
                string newEmodji = emodji.Groups["emodji"].Value;
                long emodjiLetters = newEmodji.ToCharArray().Sum(c=>c);

                if (emodjiLetters>cool)
                {
                        Console.WriteLine(emodji.Value);    
                }
            }
        }
    }
}
