using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Food;

namespace WildFarm.Models.Animals
{
    public class Hen : Bird
    {
        private const double HenWeightIncrement = 0.35;
        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override IReadOnlyCollection<Type> PreferredFood => new HashSet<Type>() { typeof(Vegetable), typeof(Fruit), typeof(Seeds), typeof(Meat) };

        protected override double WeightIncrement => HenWeightIncrement;

        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}
