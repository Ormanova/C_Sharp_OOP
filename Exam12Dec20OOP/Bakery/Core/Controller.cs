using Bakery.Core.Contracts;
using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Core
{
    public class Controller : IController
    {
        private readonly List<IBakedFood> foods;
        private readonly List<IDrink> drinks;
        private readonly List<ITable> tables;
        private decimal totalIncome = 0;
        public Controller()
        {
            foods = new List<IBakedFood>();
            drinks = new List<IDrink>();
            tables = new List<ITable>();
        }
        public string AddFood(string type, string name, decimal price)
        {
            if (type == "Bread")
            {
                this.foods.Add(new Bread(name, price));

            }
            else if (type == "Cake")
            {
                this.foods.Add(new Cake(name, price));

            }
            return $"Added {name} ({type}) to the menu";
        }

        public string AddDrink(string type, string name, int portion, string brand)
        {
            IDrink drink = null;
            if (type == "Tea")
            {
                this.drinks.Add(new Tea(name, portion, brand));
            }
            else if (type == "Water")
            {
                this.drinks.Add(new Water(name, portion, brand));
            }
            return $"Added { name} ({ brand}) to the drink menu";

        }
        public string AddTable(string type, int tableNumber, int capacity)
        {
            if (type == "InsideTable")
            {
                this.tables.Add(new InsideTable(tableNumber, capacity));

            }
            else if (type == "OutsideTable")
            {
                this.tables.Add(new OutsideTable(tableNumber, capacity));

            }
            return $"Added table number {tableNumber} in the bakery";

        }
        public string ReserveTable(int numberOfPeople)
        {
            ITable table = tables.FirstOrDefault(t => !t.IsReserved && t.Capacity >= numberOfPeople);
            if (table == null)
            {
                return $"No available table for {numberOfPeople} people";
            }
            else
            {
                table.Reserve(numberOfPeople);
                return String.Format(OutputMessages.TableReserved, table.TableNumber, numberOfPeople);
            }

        }
        public string OrderFood(int tableNumber, string foodName)
        {
            ITable table = tables.Find(t => t.TableNumber == tableNumber);
            if (table == null)
            {
                return $"Could not find table {tableNumber}";

            }
            else
            {
                IBakedFood food = foods.Find(f => f.Name == foodName);
                if (food == null)
                {
                    return String.Format(OutputMessages.NonExistentFood, foodName);
                }
                else
                {
                    table.OrderFood(food);
                    return String.Format(OutputMessages.FoodOrderSuccessful, tableNumber, foodName);
                }
            }
        }
        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            ITable table = tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            if (table == null)
            {
                return $"Could not find table {tableNumber}";
            }
            else
            {
                IDrink drink = drinks.FirstOrDefault(d => d.Name == drinkName && d.Brand == drinkBrand);
                if (drink == null)
                {
                    return $"There is no {drinkName} {drinkBrand} available";
                }
                else
                {
                    table.OrderDrink(drink);
                    return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
                }

            }

        }
        public string LeaveTable(int tableNumber)
        {
            ITable table = tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            decimal bill = table.GetBill() + table.Price;
            totalIncome += bill;
            table.Clear();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Table: {tableNumber}");
            sb.AppendLine($"Bill: {bill:f2}");
            return sb.ToString().TrimEnd();
        }
        public string GetFreeTablesInfo()
        {
            string result = "";
            List<ITable> freeTables = tables.Where(table => !table.IsReserved).ToList();

            for (int i = 0; i < freeTables.Count; i++)
            {
                if (i != freeTables.Count - 1)
                {
                    result += freeTables[i].GetFreeTableInfo() + Environment.NewLine;
                }
                else
                {
                    result += freeTables[i].GetFreeTableInfo();
                }
            }
            //foreach (var freeTable in freeTables)
            //{
            //    result += freeTable.GetFreeTableInfo() + Environment.NewLine;
            //}

            return result;
        }

        public string GetTotalIncome()
        {
            return $"Total income: {totalIncome:f2}lv";

        }








    }
}
