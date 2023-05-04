using MilitaryElite.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite.Models;

public class Private : Soldier, IPrivate
{
    //В първите скоби параметрите, които ще нъдат подадени при създаването на обекта, а след base тези параметри, които вече ги има в базовия клас( за да няма повторение), сетваме само Салари, защото е от интерфейса.
    public Private(int id, string firstName, string lastName, decimal salary) : base (id, firstName, lastName)
    {
        Salary = salary;
    }
    public decimal Salary { get; private set; }

    public override string ToString() => base.ToString() + $" Salary: {Salary:f2}";
}

