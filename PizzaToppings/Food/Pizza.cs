using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaToppings.Food 
{
    class Pizza : IEquatable<Pizza>
    {
        public List<string> toppings { get; set; }

        // Newtonsoft doesn't work with this constructor.
        /*
        public Pizza(List<string> toppingList)
        {
            toppings= new List<string>();
            foreach(var topping in toppingList)
            {
                toppings.Add(topping);
            }
        }
        */
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Pizza objasPizza = obj as Pizza;
            if (objasPizza == null) return false;
            else return Equals(objasPizza);
        }
        public bool Equals(Pizza cmpPizza)
        {
            int i = 0;
            if (cmpPizza == null) {
                return false;
            }

            if(this.toppings.Count != cmpPizza.toppings.Count)
            {
                return false;
            }
            else
            {
                var thisUniqueList = toppings.Distinct().OrderBy(toppings => toppings);
                var cmpUniqueList = cmpPizza.toppings.Distinct().OrderBy(toppings => toppings);
                for ( i = 0 ; i < thisUniqueList.Count(); i++)
                {
                    if (String.Compare(thisUniqueList.ElementAt(i),  cmpUniqueList.ElementAt(i)) != 0)
                    {
                        return false;
                    }

                }
            }
            return true;
        }

        public override int GetHashCode()
        {
            int hashToppings = toppings == null ? 0 : toppings.GetHashCode();
            return hashToppings;
        }
    }
}
