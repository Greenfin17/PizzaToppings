using System;
using System.Collections.Generic;
using PizzaToppings.Food;
using PizzaToppings.Data;
using Newtonsoft.Json;
using System.IO;
using System.Linq;

namespace PizzaToppings
{
    class Program
    {
        static bool IsUnique(ref List<ToppingCollection> uTL, List<string> pizzaToppings)
        {
            pizzaToppings.Sort();
            bool returnVal = true;
            int i;
            for (int j = 0; j < uTL.Count; j++)
            {
                if (uTL[j].Toppings.Count() == pizzaToppings.Count())
                {
                    for (i = 0; i < pizzaToppings.Count(); i++)
                    {
                        if (uTL[j].Toppings[i] != pizzaToppings[i])
                        {
                            break;
                        }
                    }
                    if (i == pizzaToppings.Count())
                    {
                        returnVal = false;
                        uTL[j].Count++;
                        break;
                    }
                }
            }
            return returnVal;
        }
        static void Main(string[] args)
        {

            List<Pizza> pizzaList = new List<Pizza>();
            pizzaList = JsonConvert.DeserializeObject<List<Pizza>>(File.ReadAllText(@"..\..\..\Data\pizzas.json"));

            // Find unique topping combinations
            List<ToppingCollection> uniqueToppingsList = new List<ToppingCollection>();
            foreach (var pizza in pizzaList)
            {
                pizza.toppings.Sort();
                if (IsUnique(ref uniqueToppingsList, pizza.toppings))
                {
                    ToppingCollection tempObj = new ToppingCollection(pizza.toppings, 1);
                    tempObj.Toppings.Sort();
                    uniqueToppingsList.Add(tempObj);
                }
            }

            // Sort the results
            uniqueToppingsList.Sort((a, b) => b.Count - a.Count);

            // Display results
            Console.WriteLine("     The 20 most popular topping combinations are: ");
            for( int i = 0; i < 20 && i < uniqueToppingsList.Count; i++)
            {
                Console.WriteLine("          Count: {0:G} {1}", uniqueToppingsList[i].Count, String.Join(", ", uniqueToppingsList[i].Toppings));
            }
        }
    }
}
