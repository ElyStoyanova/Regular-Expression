using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Race
{
    class Program
    {
        static void Main(string[] args)
        {
            var name = Console.ReadLine().Split(", ").ToList();

            var listOfparticipant = new Dictionary<string, int>();

            string patternName = @"(?<name>[A-Za-z]+)";
            Regex regexName = new Regex(patternName);

            string patternDigit = @"(?<digits>\d+)";
            Regex regexDigit = new Regex(patternDigit);

            int sumOfDigits = 0;

            string input = Console.ReadLine();

            while (input!= "end of race")
            {
                MatchCollection matchedNames = regexName.Matches(input);
                string currName = string.Join("", matchedNames);

                MatchCollection matchedDigits = regexDigit.Matches(input);
                string currDigit = string.Join("", matchedDigits);

                sumOfDigits = 0;

                for (int i = 0; i < currDigit.Length; i++)
                {
                    sumOfDigits += int.Parse(currDigit[i].ToString());  //превръщане елемент от стринга в число
                }

                if (name.Contains(currName))
                {
                    if (!listOfparticipant.ContainsKey(currName))      // проверка дали го има в речника
                    {
                        listOfparticipant.Add(currName, sumOfDigits);  //добавяме елемент към речника
                    }
                    else
                    {
                        listOfparticipant[currName] += sumOfDigits;   //корегираме км /value/
                    }
                }
                input = Console.ReadLine();
            }
            var winners = listOfparticipant.OrderByDescending(x => x.Value).Take(3);  //намираме първите трима победители
            var firstPlace = winners.Take(1);  //намираме първия

            var secondPlace = winners.OrderByDescending(x => x.Value).Take(2).OrderBy(x => x.Value).Take(1); // втория

            var thirdPlace = winners.OrderBy(x => x.Value).Take(1);  //третия

            foreach (var first in firstPlace)
            {
                Console.WriteLine($"1st place: {first.Key}");
            }
            foreach(var second in secondPlace)
            {
                Console.WriteLine($"2nd place: {second.Key}");
            }
            foreach(var third in thirdPlace)
            {
                Console.WriteLine($"3rd place: {third.Key}");
            }

        }
    }
}
