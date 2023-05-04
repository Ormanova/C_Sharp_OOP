using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BorderControl.IO.Interfaces;
using BorderControl.Models.Interfaces;

namespace BorderControl.Models;

public class Citizen : IIdentifiable
{
   
    public Citizen(string id, string name, int age)
    {
        Id = id;
        Name = name;
        Age = age;
    }
    public string Id { get; private set; }
    public string Name { get; private set; }

    public int Age { get; private set; }

}

