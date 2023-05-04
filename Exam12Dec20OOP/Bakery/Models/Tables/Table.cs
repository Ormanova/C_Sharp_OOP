using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery.Models.Tables
{
    public abstract class Table : ITable
    {
        private List<IBakedFood> bakedFoods;
        private List<IDrink> drinks;
        private int capacity;
        private int numberOfPeople;

        public Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.PricePerPerson = pricePerPerson;
            bakedFoods = new List<IBakedFood>();
            drinks = new List<IDrink>();
        }
        public int TableNumber { get; private set; }// по условие няма валидация, оставяме само property

        public int Capacity
        {
            get { return capacity; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidTableCapacity);

                }
                capacity = value;
            }
        }
        public int NumberOfPeople
        {
            get { return numberOfPeople; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidNumberOfPeople);
                }
                numberOfPeople = value;
            }
        }
        public decimal PricePerPerson { get; private set; }// по условие няма валидация, оставяме само property

        // IsReserved – bool returns true if the table is reserved
        public bool IsReserved { get; private set; } // по условие няма валидация, оставяме само property

        //Price – calculated property, which calculates the price for all people
        public decimal Price
        {
            get => PricePerPerson * NumberOfPeople;
        }
        public void Reserve(int numberOfPeople)
        {
            IsReserved = true;  //Reserves the table with the count of people given.
            NumberOfPeople = numberOfPeople;
        }
        public void OrderFood(IBakedFood food)
        {
            this.bakedFoods.Add(food);
        }
        public void OrderDrink(IDrink drink)
        {
            this.drinks.Add(drink);
        }
        public void Clear()
        {
            bakedFoods.Clear();
            drinks.Clear();
            this.NumberOfPeople = 0;
            IsReserved = false;
        }

        public decimal GetBill()
        {
            //Returns the bill for all of the ordered drinks and food. - трябва да минем през всяка една храна и напика, да им вземем цената и да я прибавим към сметката
            decimal bill = 0;
            foreach (var food in bakedFoods)
            {
                bill += food.Price;
            }
            foreach (var drink in drinks)
            {
                bill += drink.Price;
            }
            
            return bill;
        }

        public string GetFreeTableInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Table: {this.TableNumber}");
            sb.AppendLine($"Type: {this.GetType().Name}"); // reflection
            sb.AppendLine($"Capacity: {this.Capacity}");
            sb.AppendLine($"Price per Person: {this.PricePerPerson}");
            return sb.ToString().TrimEnd();
        }

    }
}
