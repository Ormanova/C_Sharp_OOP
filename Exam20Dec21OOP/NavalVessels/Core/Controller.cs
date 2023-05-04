using NavalVessels.Core.Contracts;
using NavalVessels.Models;
using NavalVessels.Models.Contracts;
using NavalVessels.Repositories;
using NavalVessels.Repositories.Contracts;

using NavalVessels.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavalVessels.Core
{

    public class Controller : IController
    {

        //vessels - VesselRepository
        private readonly IRepository<IVessel> vessels;

        //captains - a collection of ICaptain
        private readonly ICollection<ICaptain> captains;
        //private readonly IVesselFactory vesselFactory;
        public Controller() //сетваме полетата в конструктура;
        {
            this.vessels = new VesselRepository();
            this.captains = new HashSet<ICaptain>();

           // this.vesselFactory = new VesselFactory();
        }

        public string HireCaptain(string fullName)
        {

            ICaptain captain = new Captain(fullName);
            if (this.captains.Any(c => c.FullName == fullName))
            {
                return string.Format(OutputMessages.CaptainIsAlreadyHired, fullName);
            }
            this.captains.Add(captain);
            return string.Format(OutputMessages.SuccessfullyAddedCaptain, fullName);

        }
        public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
        {
            IVessel vesselExist = this.vessels.FindByName(name);
            if (vesselExist != null)
            {
                return string.Format(OutputMessages.VesselIsAlreadyManufactured, vesselExist.GetType().Name, name);
            }
            //try
            //{
            //    IVessel producedVessel = this.vesselFactory.Produce(vesselType, name, mainWeaponCaliber, speed);
            //    this.vessels.Add(producedVessel);
            //    return string.Format(OutputMessages.SuccessfullyCreateVessel,
            //        vesselType, name, mainWeaponCaliber, speed);
            //}
            //catch (InvalidOperationException ioe)
            //{
            //    return ioe.Message;
            //}
            //catch (Exception e)
            //{
            //    throw e.InnerException;
            //}
            IVessel vesselProduced = null;
            if (vesselType == "Battleship")
            {
                vesselProduced = new Battleship(name, mainWeaponCaliber, speed);
            }
            else if (vesselType == "Submarine")
            {
                vesselProduced = new Submarine(name, mainWeaponCaliber, speed);

            }
            else
            {
                return String.Format(OutputMessages.InvalidVesselType);
            }
            this.vessels.Add(vesselProduced);
            return string.Format(OutputMessages.SuccessfullyCreateVessel, vesselType, name, mainWeaponCaliber, speed);
        }

        public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
        {
            ICaptain captain = this.captains.FirstOrDefault(c => c.FullName == selectedCaptainName);
            if (captain == null)
            {
                return String.Format(OutputMessages.CaptainNotFound, selectedCaptainName);

            }

            IVessel vessel = this.vessels.FindByName(selectedVesselName);
            if (vessel == null)
            {
                return String.Format(OutputMessages.VesselNotFound, selectedVesselName);

            }
            if (vessel.Captain != null)
            {
                return String.Format(OutputMessages.VesselOccupied, selectedVesselName);
            }
            vessel.Captain = captain;
            captain.AddVessel(vessel);
            return string.Format(OutputMessages.SuccessfullyAssignCaptain, selectedCaptainName, selectedVesselName);
        }
        public string CaptainReport(string captainFullName)
        {
            ICaptain assighnedCaptain = this.captains.First(c => c.FullName == captainFullName);

            return assighnedCaptain.Report();

        }
        public string VesselReport(string vesselName)
        {
            IVessel vessel = this.vessels.FindByName(vesselName);
            return vessel?.ToString();
        }
        public string ToggleSpecialMode(string vesselName)
        {
            IVessel vessel = this.vessels.FindByName(vesselName);
            if (vessel == null)
            {
                return String.Format(OutputMessages.VesselNotFound, vesselName);

            }
            if (vessel.GetType() == typeof(Battleship))
            {
                Battleship battleshipVessel = (Battleship)vessel;
                battleshipVessel.ToggleSonarMode();
                return string.Format(OutputMessages.ToggleBattleshipSonarMode, vesselName);
            }
            else
            {
                Submarine submarineVessel = (Submarine)vessel;
                submarineVessel.ToggleSubmergeMode();
                return string.Format(OutputMessages.ToggleSubmarineSubmergeMode, vesselName);
            }

        }
        public string ServiceVessel(string vesselName)
        {
            IVessel vessel = this.vessels.FindByName(vesselName);
            if (vessel == null)
            {
                return string.Format(OutputMessages.VesselNotFound, vesselName);
            }
            vessel.RepairVessel();
            return string.Format(OutputMessages.SuccessfullyRepairVessel, vesselName);
        }


        public string AttackVessels(string attackingVesselName, string defendingVesselName)
        {
            IVessel attackingVessel = this.vessels.FindByName(attackingVesselName);
            if (attackingVessel == null)
            {
                return string.Format(OutputMessages.VesselNotFound, attackingVesselName);
            }
            IVessel defendingVessel = this.vessels.FindByName(defendingVesselName);
            if (defendingVessel == null)
            {
                return string.Format(OutputMessages.VesselNotFound, defendingVesselName);

            }
            if (attackingVessel.ArmorThickness == 0)
            {
                return string.Format(OutputMessages.AttackVesselArmorThicknessZero, attackingVesselName);

            }
            if (defendingVessel.ArmorThickness == 0)
            {
                return string.Format(OutputMessages.AttackVesselArmorThicknessZero, defendingVesselName);

            }
            attackingVessel.Attack(defendingVessel);
            attackingVessel.Captain.IncreaseCombatExperience();
            defendingVessel.Captain.IncreaseCombatExperience();
                return string.Format(OutputMessages.SuccessfullyAttackVessel, defendingVesselName, attackingVesselName, defendingVessel.ArmorThickness);


        }

    }
}
