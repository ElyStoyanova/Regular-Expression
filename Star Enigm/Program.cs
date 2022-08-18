using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Star_Enigm
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"@(?<name>[A-z]+)[^@\-!:>]*:(?<population>[\d]+)[^@\-!:>]*!(?<attack>[A,D])![^@\-!:>]*->(?<count>[\d]+)";
            int lineInput = int. Parse(Console.ReadLine());
            int sum = 0;
            string descriptedMessage = string.Empty;
            var attacked = new List<string>();
            var destroyed = new List<string>();

            Regex regex = new Regex(pattern);

            for (int i = 0; i < lineInput; i++)
            {
                string message = Console.ReadLine();
                string messageCount = message.ToLower();
                sum = messageCount.Count(x => x == 's' || x == 't' || x == 'a' || x == 'r');

                foreach (var symbol in message)
                {
                    descriptedMessage += (char)(symbol - sum);
                }

                Match matches = Regex.Match(descriptedMessage, pattern, RegexOptions.IgnoreCase);

                if (matches.Success)
                {
                    string name = matches.Groups["name"].Value;
                    int population =int.Parse( matches.Groups["population"].Value);
                    char attack = char.Parse(matches.Groups["attack"].Value);
                    int count = int.Parse(matches.Groups["count"].Value);

                    switch (attack)
                    {
                        case 'A':
                            attacked.Add(name);
                            break;
                        case 'D':
                            destroyed.Add(name);
                            break;
                    }
                }
                sum = 0;
                descriptedMessage = string.Empty;
            }
            int countAttacked = attacked.Count;

                if (countAttacked==0)
                {
                    Console.WriteLine("Attacked planets: 0");
                }
                else
                {
                    attacked = attacked.OrderBy(x => x).ToList();
                    Console.WriteLine($"Attacked planets: { countAttacked}");
                    Console.Write("-> ");
                    Console.WriteLine(string.Join("\n-> ", attacked));
                }
            int countDestroyed = destroyed.Count;

                if (countDestroyed==0)
                {
                    Console.WriteLine("Destroyed planets: 0");
                }
                else
                {
                    destroyed = destroyed.OrderBy(x => x).ToList();
                    Console.WriteLine($"Destroyed planets: { countDestroyed}");
                    Console.Write("-> ");
                    Console.WriteLine(string.Join("\n-> ", destroyed));
                }
           
        }
    }
}  
            


            
        
