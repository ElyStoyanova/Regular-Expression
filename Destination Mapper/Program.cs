using System;
using System.Collections.Generic;

namespace Destination_Mapper
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPlant = int.Parse(Console.ReadLine());
            Dictionary<string, PlantInformation> plants = new Dictionary<string, PlantInformation>();

            for (int i = 0; i < numberOfPlant; i++)
            {
                string[] input = Console.ReadLine().Split("<->");
                string currentPlant = input[0];
                int cuurentPlantRarity = int.Parse(input[1]);

                if (!plants.ContainsKey(currentPlant))
                {
                    PlantInformation plant = new PlantInformation(cuurentPlantRarity);
                    plants.Add(currentPlant, plant);
                }
                else
                {
                    plants[currentPlant].Rarity = cuurentPlantRarity;
                }
            }
            string inputCommand = Console.ReadLine();

            while (inputCommand!= "Exhibition")
            {
                inputCommand = inputCommand.Replace("-"," ");
                string[] tokans = inputCommand.Split(" ");
                string command = tokans[0];
                string currPlant = tokans[1];

                switch (command)
                {
                    case "Rate:":
                        double currPlantRating = double.Parse(tokans[2]);

                        if (plants.ContainsKey(currPlant))
                        {
                            plants[currPlant].Rating.Add(currPlantRating);
                        }
                        else
                        {
                            Console.WriteLine("error");
                        }
                        break;

                    case "Update:":
                        int newRarity = int.Parse(tokans[2]);

                        if (plants.ContainsKey(currPlant))
                        {
                            plants[currPlant].Rarity = newRarity;
                        }
                        else
                        {
                            Console.WriteLine("error");
                        }
                        break;

                    case "Reset:":

                        if (plants.ContainsKey(currPlant))
                        {
                            plants[currPlant].Rating.RemoveRange(0, plants[currPlant].Rating.Count);
                        }
                        else
                        {
                            Console.WriteLine("error");
                        }
                        break;
                }
                inputCommand = Console.ReadLine();
            }
            Console.WriteLine("Plants for the exhibition:") ;
          
            foreach (var plant in plants)
            {
                double averageRairing = 0;

                if (plant.Value.Rating.Count!=0)
                {
                    for (int i = 0; i < plant.Value.Rating.Count; i++)
                    {
                        averageRairing += plant.Value.Rating[i];     
                    }
                    averageRairing /= plant.Value.Rating.Count;
                }
                Console.WriteLine($"- {plant.Key}; Rarity: {plant.Value.Rarity}; Rating: {averageRairing:f2}");
            }

        }
    }
    class PlantInformation
    {
        public PlantInformation(int rarity)
        {
            this.Rarity = rarity;
        }
        public int Rarity { get; set; }
        public List<double> Rating { get; set; } = new List<double>();
    }
}
