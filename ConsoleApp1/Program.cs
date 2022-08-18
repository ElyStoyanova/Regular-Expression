using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Destination_Mapper
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"([=\/])(?<destination>[A-Z][A-Za-z]{2,})\1";
           

           MatchCollection matches = Regex.Matches(input, pattern);

            string[] destination = matches.Select(x => x.Groups["destination"].Value).ToArray();
            int travelPoints = destination.Select(d => d.Length).Sum();

            Console.WriteLine($"Destinations: {string.Join(", ",destination)} ");
            
            Console.WriteLine($"Travel Points: {travelPoints}");
        }
    }
}
