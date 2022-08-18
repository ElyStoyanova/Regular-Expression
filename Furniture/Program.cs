using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Furniture
{
    class Program
    {

        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @">>(?<name>[A-Za-z\s]+)<<(?<price>\d+(.\d+)?)!(?<quontity>\d+)";
            List<string> nameOfFurniture = new List<string>();
            double totalPrace = 0;

            while (input != "Purchase")
            {
                Match matches = Regex.Match(input, pattern, RegexOptions.IgnoreCase);

                if (matches.Success)
                {
                    var name = matches.Groups["name"].Value;
                    nameOfFurniture.Add(name);
                    double price = double.Parse(matches.Groups["price"].Value);
                    int quonity = int.Parse(matches.Groups["quontity"].Value);
                    totalPrace += price * quonity;
                }
                input = Console.ReadLine();
            }
            Console.WriteLine("Bought furniture:");
            nameOfFurniture.ForEach(Console.WriteLine);
            Console.WriteLine($"Total money spend: {totalPrace:f2}");
        }
    }
}
