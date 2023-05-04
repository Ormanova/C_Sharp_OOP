using MilitaryElite.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite.Models;

public class SpecialisedSoldier : Private, ISpecialisedSoldier
{
    //SpecialisedSoldier - general class for all specialized Soldiers - holds the corps of the Soldier.
    public SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, Corps corps) : base(id, firstName, lastName, salary)
    {
        Corps = corps;
    }
    public Corps Corps { get; private set; }

    public override string ToString() => base.ToString() + $"{Environment.NewLine}Corps: {Corps}";
}

