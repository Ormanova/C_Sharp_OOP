using NavalVessels.Models.Contracts;
using NavalVessels.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavalVessels.Models
{
    public abstract class Vessel : IVessel
    {
        private string name;
        
        private ICaptain captain;

        public Vessel(string name, double mainWeaponCaliber, double speed, double armorThickness)
        {
            this.Name = name;
            this.MainWeaponCaliber = mainWeaponCaliber;
            this.Speed = speed;
            this.ArmorThickness = armorThickness;
            this.Targets = new List<string>();
        }
        public string Name
        {
            get { return this.name; }
           private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidVesselName));
                }
                this.name = value; 
            }
        }
        public double MainWeaponCaliber
        {
            get;
            protected set;
        }
        public double ArmorThickness
        {
            get;
            set;
        }
        public double Speed
        {
            get;
            protected set;
        }

        public ICaptain Captain
        {
            get { return this.captain; }
            set 
            {
                if (value == null)
                {
                    throw new NullReferenceException(ExceptionMessages.InvalidCaptainToVessel);
                }
                this.captain = value;
            }
        }

        public ICollection<string> Targets { get; private set; }



        public void Attack(IVessel target)
        {
            if (target == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.InvalidTarget));
            }
            target.ArmorThickness -= this.MainWeaponCaliber;
            if (target.ArmorThickness < 0)
            {
                target.ArmorThickness = 0;
            }
            this.Targets.Add(target.Name);
        }

        //Set the vessel’s initial armor thickness to the default value based on the vessel type. Оставяме го абстрацтен за да може да се имплементира специфично за всеки подклас.
        public abstract void RepairVessel();
       
        public override string ToString()
        {

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"- {Name}");
            sb.AppendLine($" *Type: {this.GetType().Name}");
            sb.AppendLine($" *Armor thickness: {ArmorThickness}");
            sb.AppendLine($" *Main weapon caliber: {MainWeaponCaliber}");
            sb.AppendLine($" *Speed: {Speed} knots");
            sb.AppendLine($" *Targets: {(this.Targets.Any() ? String.Join(", ", this.Targets) : "None")}");
            return sb.ToString().TrimEnd();


        }
    }
}
