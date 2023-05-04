using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories.Models
{
    public class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private double weight;

        private const double baseCaloriesPerGram = 2;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Weight = weight;
        }
        public string FlourType 
        {
            get => flourType;
            private set
            {
                if (value != "white" && value != "wholegrain")
                {
                    throw new ArgumentException(ExceptionMessages.TypeExceptionMessage);
                }
                flourType = value;
            }
        }
        public string BakingTechnique
        {
            get => bakingTechnique;
            private set
            {
                if (value != "crispy" && value != "chewy" && value != "homemade")
                {
                    throw new ArgumentException(ExceptionMessages.TypeExceptionMessage);
                }
                bakingTechnique = value;
            }
        }
        public double Weight
        {
            get => weight;
            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException(ExceptionMessages.WeightExceptionMessage);
                }
                weight = value;
            }
        }
        public double DoughCalories
        {
            get
            {
                return baseCaloriesPerGram * Weight * CalculateCaloriesPerTypeAndTechnique();
            }
        }
     

        private double CalculateCaloriesPerTypeAndTechnique()
        {
            double modifierForType = 0;
            double modifierForTechnique = 0;
            switch (FlourType)
            {
                case "white":
                    modifierForType = 1.5;
                    break;
                case "wholegrain":
                    modifierForType = 1.0;
                    break;
                
            }
            switch (BakingTechnique)
            {
                case "crispy":
                    modifierForTechnique = 0.9;
                    break;
                case "chewy":
                    modifierForTechnique = 1.1;
                    break;
                case "homemade":
                    modifierForTechnique = 1.0;
                    break;
            }
            return modifierForType * modifierForTechnique;
        }
    }
}
