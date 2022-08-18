using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string helthPattern = @"[^\*0-9\.\+\-\/,]";
            string damagePattern = @"-?\d+\.?\d*";
            string multiplayDivadePattern = @"[\*\/]";
            string splitPattern = @"[,\s]+";

            string input = Console.ReadLine();
            string[] demons = Regex.Split(input, splitPattern).OrderBy(x => x).ToArray();

            for (
                int i = 0; i < demons.Length; i++)
            {
                var helthMatched = Regex.Matches(demons[i], helthPattern);
                int health = 0;

                foreach (Match item in helthMatched)
                {
                    char currHealth = char.Parse(item.ToString());
                    health += currHealth;
                }

                var damegeMatched = Regex.Matches(demons[i], damagePattern);
                double sumDamage = 0;

                foreach (Match item in damegeMatched)
                {
                    sumDamage += double.Parse(item.ToString());
                }

                var split = Regex.Matches(demons[i], multiplayDivadePattern);

                foreach (Match item in split)
                {
                    char newItem = char.Parse(item.ToString());

                    switch (newItem)
                    {
                        case '*':
                            sumDamage *= 2;
                            break;
                        case '/':
                            sumDamage /= 2;
                            break;

                    }
                }
                Console.WriteLine($"{ demons[i]} - {health} health, {sumDamage:f2} damage");
            }

        }
    }
}

