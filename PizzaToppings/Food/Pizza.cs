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
        public bool Equals(Pizza cmpPizza)
        {
            if (cmpPizza == null)
            {
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
                for ( int i = 0 ; i < thisUniqueList.Count(); i++)
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
