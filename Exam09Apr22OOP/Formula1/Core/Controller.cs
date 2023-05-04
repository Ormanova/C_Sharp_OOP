using Formula1.Core.Contracts;
using Formula1.Models;
using Formula1.Models.Contracts;
using Formula1.Repositories;
using Formula1.Repositories.Contracts;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formula1.Core
{
    public class Controller : IController
    {
        private PilotRepository pilotRepository;
        private RaceRepository raceRepository;
        private FormulaOneCarRepository formulaOneCarRepository;

        public Controller()
        {
            pilotRepository = new PilotRepository();
            raceRepository = new RaceRepository();
            formulaOneCarRepository = new FormulaOneCarRepository();
        }
        public string CreatePilot(string fullName)
        {
            //If a pilot with the given full name exists, throw a InvalidOperationException with the following message: "Pilot { full name } is already created."
            if (pilotRepository.FindByName(fullName) != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotExistErrorMessage, fullName));
            }
            IPilot pilot = new Pilot(fullName);
            pilotRepository.Add(pilot);
            return String.Format(OutputMessages.SuccessfullyCreatePilot, fullName);
        }
        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            //If a car with the given model exists, throw an InvalidOperationException with a message: "Formula one car { model } is already created."
            if (formulaOneCarRepository.FindByName(model) != null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.CarExistErrorMessage, model));
            }
            IFormulaOneCar car = null;
            if (type == "Ferrari")
            {
                car = new Ferrari(model, horsepower, engineDisplacement);

            }
            else if (type == "Williams")
            {
                car = new Williams(model, horsepower, engineDisplacement);
            }
            else
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidTypeCar, type));
            }
            formulaOneCarRepository.Add(car);
            return String.Format(OutputMessages.SuccessfullyCreateCar, type, model);
        }
        public string CreateRace(string raceName, int numberOfLaps)
        {
            if (raceRepository.FindByName(raceName) != null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceExistErrorMessage, raceName));
            }
            IRace race = new Race(raceName, numberOfLaps);
            raceRepository.Add(race);

            return String.Format(OutputMessages.SuccessfullyCreateRace, raceName);
        }
        public string AddCarToPilot(string pilotName, string carModel)
        {
            //If the pilot does not exist, or the pilot already has a car, throw a InvalidOperationException with the following message: "Pilot { pilot name } does not exist or has a car."
            IPilot pilot = pilotRepository.FindByName(pilotName);
            if (pilot == null || pilot.Car != null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.PilotDoesNotExistOrHasCarErrorMessage, pilotName));
            }

            //If the car model does not exist, throw a NullReferenceException with the following message: "Car { model } does not exist."
            IFormulaOneCar car = formulaOneCarRepository.FindByName(carModel);
            if (car == null)
            {
                throw new NullReferenceException(String.Format(ExceptionMessages.CarDoesNotExistErrorMessage, carModel));
            }


            //Adds a car with the given car model to a pilot with the given name. After successfully adding a car to a pilot, remove the car from the FormulaOneCarRepository:
            pilot.AddCar(car);
            formulaOneCarRepository.Remove(car);


            //"Pilot { pilot name } will drive a {type of car} { model } car."
            string carType = car.GetType().Name;
            return String.Format(OutputMessages.SuccessfullyPilotToCar, pilotName, carType, carModel);
        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            //If the race does not exist, throw a NullReferenceException with the following message: "Race { race name } does not exist."
            IRace race = raceRepository.FindByName(raceName);
            if (race == null)
            {
                throw new NullReferenceException(String.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }

            //If the pilot does not exist, or the pilot can not race, or the pilot is already in the race, throw a InvalidOperationException with the following message: "Can not add pilot { pilot full name } to the race."

            IPilot pilot = pilotRepository.FindByName(pilotFullName);
            if (pilot == null || pilot.CanRace == false)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.PilotDoesNotExistErrorMessage, pilotFullName));
            }
            race.AddPilot(pilot);
            return String.Format(OutputMessages.SuccessfullyAddPilotToRace, pilotFullName, raceName);
        }
        public string StartRace(string raceName)
        {
            //If the race does not exist, throw a NullReferenceException with the following message: "Race { race name } does not exist."
            IRace race = raceRepository.FindByName(raceName);


            if (race == null)
            {
                throw new NullReferenceException(String.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }

            //If the race has less than 3 pilots, throw an InvalidOperationException with the following message: "Race { race name } cannot start with less than three participants."
            if (race.Pilots.Count < 3)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidRaceParticipants, raceName));
            }
            if (race.TookPlace == true)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceTookPlaceErrorMessage, raceName));
            }
            //sort all riders in descending order by the result of the RaceScoreCalculator method in FormulaOneCar object
            List<IPilot> orderedPilots = race.Pilots.OrderByDescending(p => p.Car.RaceScoreCalculator(race.NumberOfLaps)).ToList();
            race.TookPlace = true;
            orderedPilots[0].WinRace();

            //"Pilot { pilot full name } wins the { race name } race.
            //Pilot { pilot full name } is second in the { race name } race.
            //Pilot { pilot full name } is third in the { race name } race."
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Pilot {orderedPilots[0].FullName} wins the {raceName} race.");
            sb.AppendLine($"Pilot {orderedPilots[1].FullName} is second in the {raceName} race.");
            sb.AppendLine($"Pilot {orderedPilots[2].FullName} is third in the {raceName} race.");
            return sb.ToString().Trim();
        }
        public string RaceReport()
        {
            //Returns information about each race that has been executed. You can use the RaceInfo method in the Race class.
            List<IRace> races = raceRepository.Models.Where(r => r.TookPlace).ToList();
                StringBuilder sb = new StringBuilder();
            foreach (var race in races)
            {
                sb.AppendLine(race.RaceInfo());
            }
            return sb.ToString().Trim();
        }

        public string PilotReport()
        {
            List<IPilot> pilots = pilotRepository.Models.OrderByDescending(x => x.NumberOfWins).ToList();
            StringBuilder sb = new StringBuilder();
            foreach (var pilot in pilots)
            {
                sb.AppendLine(pilot.ToString());
            }
            return sb.ToString().Trim();
        }
    }
}
