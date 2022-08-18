using System;
using System.Text.RegularExpressions;

namespace SoftUni_Bar_Income
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"%(?<customer>[A-Z][a-z]+)%[^|%$.]*<(?<product>[\w]+)>[^|%$.]*\|(?<quontity>[\d]+)\|[^|%$.]*?(?<price>[\d]+.?[\d]+)?\$";
            double totalPrice = 0;
            double totalIncome = 0;

            while (input!= "end of shift")
            {
                Regex regex = new Regex(pattern);
                bool isValid = regex.IsMatch(input);

                if (isValid)
                {
                    string customerName = regex.Match(input).Groups["customer"].Value;
                    string product = regex.Match(input).Groups["product"].Value;
                    int quontity = int.Parse(regex.Match(input).Groups["quontity"].Value);
                    double price =double.Parse( regex.Match(input).Groups["price"].Value);
                    totalPrice = quontity * price;
                    totalIncome += totalPrice;
                    Console.WriteLine($"{customerName}: {product} - {totalPrice:f2}");
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"Total income: {totalIncome:f2}");
        }
    }
}
