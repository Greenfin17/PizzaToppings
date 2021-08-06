using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaToppings.Food
{
    class Pizza
    {
        public IList<string> toppings { get; set; }

        /*
        public Pizza(IList<string> toppingList)
        {
            toppings= new List<string>();
            foreach(var topping in toppingList)
            {
                toppings.Add(topping);
            }
        }
        */
    }
}
