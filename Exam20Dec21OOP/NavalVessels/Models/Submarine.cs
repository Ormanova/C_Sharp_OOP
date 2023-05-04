using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavalVessels.Models
{
    public class Submarine : Vessel, ISubmarine
    {
        private const int InitialArmorThickness = 200;
        private const int WeaponCaliberIncrement = 40;
        private const int SpeedDecrement = 4;

        public Submarine(string name, double mainWeaponCaliber, double speed) : base(name, mainWeaponCaliber, speed, InitialArmorThickness)
        {
            this.SubmergeMode = false;
        }

        public bool SubmergeMode {get; private set;}

        public override void RepairVessel()
        {
            this.ArmorThickness = InitialArmorThickness;
        }

        public void ToggleSubmergeMode()
        {
            if (!this.SubmergeMode) //When SubmergeMode is activated (false -> true):,т.е текущото му състояние е false
            {
                this.MainWeaponCaliber += WeaponCaliberIncrement;
                this.Speed -= SpeedDecrement;
            }
            else //текущото състояние е true и  превключваме на false
            {
                this.MainWeaponCaliber -= WeaponCaliberIncrement;
                this.Speed += SpeedDecrement;
            }
            this.SubmergeMode = !this.SubmergeMode;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            string sonarPosition = this.SubmergeMode ? "ON" : "OFF";
            sb.AppendLine($" *Sonar mode: {sonarPosition}");
            return sb.ToString().TrimEnd();
        }
    }
}
