using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaToppings.Data
{
    class ToppingCollection
    {
        public List<string> Toppings { get; set; }
        public int Count { get; set; }

        public ToppingCollection(List<string> toppings, int count)
        {
            Toppings = new List<string>();
            foreach (string topping in toppings)
            {
                Toppings.Add(topping);
            }
            Count = count;
        }
    }
}
