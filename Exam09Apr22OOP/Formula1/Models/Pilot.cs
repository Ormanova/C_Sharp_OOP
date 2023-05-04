using Formula1.Models.Contracts;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formula1.Models
{
    public class Pilot : IPilot
    {
        private string fullName;
        private IFormulaOneCar car;
        private int numberOfWins;
        private bool canRace;

        public Pilot(string fullName)
        {
            FullName = fullName;

        }

        public string FullName
        {
            get { return fullName; }
            private set 
            {
                if (String.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidPilot, value));
                }
                fullName = value;
            }
        }
        public IFormulaOneCar Car
        {
            get { return car; }
            private set 
            {
                if (value == null)
                {
                    throw new NullReferenceException(string.Format(ExceptionMessages.InvalidCarForPilot));
                }
                car = value;
            }
        }
        public int NumberOfWins
        {
            get { return numberOfWins; }
            private set { numberOfWins = value; }
        }

        public bool CanRace
        {
            get { return canRace; }
            private set { canRace = value; } //oShould be set to false as default 
        }

        public void AddCar(IFormulaOneCar car)
        {
            //Sets a car to the pilot, and set CanRace to true.
            Car = car;
            CanRace = true;
        }

        public void WinRace()
        {
           NumberOfWins++;  
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Pilot { fullName } has { numberOfWins} wins.");

            return sb.ToString().Trim();
        }
    }
}
