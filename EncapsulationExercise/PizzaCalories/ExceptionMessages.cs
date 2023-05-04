using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories
{
    public static class ExceptionMessages
    {
        public const string TypeExceptionMessage = "Invalid type of dough.";
        public const string WeightExceptionMessage = "Dough weight should be in the range [1..200].";
        public const string TypeToppingExceptionMessage = "Cannot place {0} on top of your pizza.";
        public const string WeightToppingExceptionMessage = "{0} weight should be in the range [1..50].";
        public const string PizzaNameExceptionMessage = "Pizza name should be between 1 and 15 symbols.";
    }
}
