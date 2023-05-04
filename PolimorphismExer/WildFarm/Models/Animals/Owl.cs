using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Food;
using WildFarm.Models.Interfaces;

namespace WildFarm.Models.Animals
{
    public class Owl : Bird
    {
        private const double OwlWeightIncrement = 0.25;
        public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override IReadOnlyCollection<Type> PreferredFood => new HashSet<Type>() { typeof(Meat) };

        protected override double WeightIncrement => OwlWeightIncrement;

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }
    }
}
