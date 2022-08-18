using System;
using System.Collections.Generic;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            var heros = new Dictionary<string, List<int>>();

            for (int i = 0; i < number; i++)
            {
                string[] input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                string name = input[0];
                int hitPoints = int.Parse(input[1]);
                int manaPoints = int.Parse(input[2]);

                if (!heros.ContainsKey(name))
                {
                    heros.Add(name, new List<int>());
                    heros[name].Add(hitPoints);
                    heros[name].Add(manaPoints);
                }
            }
            string command = Console.ReadLine();

            while (command!="End")
            {
                string[] tokans = command.Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                string action = tokans[0];

                switch (action)
                {
                    case "CastSpell":
                        CastSpel(tokans[1],int.Parse(tokans[2]),tokans[3],heros);
                        break;
                    case "TakeDamage":
                        TakeDamage(tokans[1],int.Parse(tokans[2]),tokans[3],heros);
                        break;
                    case "Recharge":
                        Recharge(tokans[1],int.Parse(tokans[2]),heros);
                        break;
                    case "Heal":
                        Heal(tokans[1],int.Parse(tokans[2]),heros);
                        break;
                }


                command = Console.ReadLine();
            }
            foreach (var hero in heros)
            {
                Console.WriteLine(hero.Key);
                Console.WriteLine($"  HP: {hero.Value[0]}");
                Console.WriteLine($"  MP: {hero.Value[1]}");
             
               
            }
        }

         static void CastSpel(string name, int manaNeeded, string spellName, Dictionary<string, List<int>> heros)
        {
            if (heros[name][1]>=manaNeeded)
            {
                heros[name][1] -= manaNeeded;
                Console.WriteLine($"{name} has successfully cast {spellName} and now has {heros[name][1]} MP!");  
            }
            else
            {
                Console.WriteLine($"{name} does not have enough MP to cast {spellName}!");
            }
        }

        static void TakeDamage(string name, int damage, string attacker, Dictionary<string, List<int>> heros)
        {
            heros[name][0] -= damage;

            if (heros[name][0]>0)
            {
                Console.WriteLine($"{name} was hit for {damage} HP by {attacker} and now has {heros[name][0]} HP left!");
            }
            else
            {
                Console.WriteLine($"{name} has been killed by {attacker}!");
                heros.Remove(name);
            }
        }

        static void Recharge(string name, int amount, Dictionary<string, List<int>> heros)
        {
            int oldManaPoints = heros[name][1];
            heros[name][1] += amount;

            if (heros[name][1] > 200)
            {
                heros[name][1] = 200;
            }
                Console.WriteLine($"{name} recharged for {heros[name][1]-oldManaPoints} MP!");
            
        }

        static void Heal(string name, int amount, Dictionary<string, List<int>> heros)
        {
            int originalHP = heros[name][0];
            heros[name][0] += amount;

            if (heros[name][0]>100)
            {
                heros[name][0] = 100;
            }
            Console.WriteLine($"{name} healed for {heros[name][0] - originalHP} HP!");
        }
    }
}
