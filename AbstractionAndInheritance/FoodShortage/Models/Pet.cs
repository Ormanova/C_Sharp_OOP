
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShortage.Models;

public class Pet : IBirthable, INamable
{
    

    public Pet(string name, string birthdate)
    {
        Name = name;
        Birthdate = birthdate;
    }
    public string Name
    {
        get;
        private set;
    }

    public string Birthdate { get; private set; }
}

