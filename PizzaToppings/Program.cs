using System;
using System.Collections.Generic;
using PizzaToppings.Food;
using Newtonsoft.Json;
using System.IO;

namespace PizzaToppings
{
    class Program
    {
        static void Main(string[] args)
        {
           
           List<Pizza> pizzaList = new List<Pizza>();
           List<Pizza> pizzaList2 = new List<Pizza>();

           string pizzaStr = new String(File.ReadAllText(@"..\..\..\Data\pizzas.json"));

           // Pizza pizzaObj= JsonConvert.DeserializeObject<Pizza>(pizzaJson);
           pizzaList = JsonConvert.DeserializeObject<List<Pizza>>(File.ReadAllText(@"..\..\..\Data\pizzas.json"));


            foreach(var pizza in pizzaList)
            {
                Console.WriteLine(String.Join(", ", pizza.toppings));
            }

        }
    }
}
