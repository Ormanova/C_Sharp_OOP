

namespace Restaurant;

    public class Cake : Dessert
    {
        private const double CakeGrams = 250;
        private const double CakeCalories = 1000;
        private const decimal Cakeprice = 5M;
        public Cake(string name) : base(name, Cakeprice, CakeGrams, CakeCalories)
        {
        }
    }

