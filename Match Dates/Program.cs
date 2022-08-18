using System;
using System.Text.RegularExpressions;

namespace Match_Dates
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"\b(?<day>[0-9]{2})(?<separator>[-.\/])(?<month>[A-Z][a-z]{2})\k<separator>(?<year>\d{4})\b";

            MatchCollection matches = Regex.Matches(input, pattern);

            foreach (Match match in matches)
            {
                var day = match.Groups["day"];
                var month = match.Groups["month"];
                var year = match.Groups["year"];

                Console.WriteLine($"Day: {day}, Month: {month}, Year: {year}");
            }
        }
    }
}
