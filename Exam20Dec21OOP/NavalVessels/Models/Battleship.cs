using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavalVessels.Models
{
    public class Battleship : Vessel, IBattleship
    {

        private const int InitialArmorThickness = 300;
        private const int WeaponCaliberIncrement = 40;
        private const int SpeedDecrement = 5;

        public Battleship(string name, double mainWeaponCaliber, double speed) : base(name, mainWeaponCaliber, speed, InitialArmorThickness)
        {
            this.SonarMode = false; //SonarMode - bool  "false" by default
        }

        public bool SonarMode { get; private set; }

        public override void RepairVessel()
        {
            this.ArmorThickness = InitialArmorThickness;
        }

        public void ToggleSonarMode()
        {
            if (!this.SonarMode) //When SubmergeMode is activated (false -> true):,т.е текущото му състояние е false
            {
                this.MainWeaponCaliber += WeaponCaliberIncrement;
                this.Speed -= SpeedDecrement;
            }
            else //текущото състояние е true и  превключваме на false
            {
                this.MainWeaponCaliber -= WeaponCaliberIncrement;
                this.Speed += SpeedDecrement;
            }
            this.SonarMode = !this.SonarMode; //Ако е включен го изключваме и обратно;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            string sonarPosition = this.SonarMode ? "ON" : "OFF";
            sb.AppendLine($" *Sonar mode: {sonarPosition}");
            return sb.ToString().TrimEnd();
        }
    }
}
