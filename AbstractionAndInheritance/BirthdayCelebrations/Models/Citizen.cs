using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BirthdayCelebrations.Models.Interfaces;


namespace BirthdayCelebrations.Models;

public class Citizen : IBirthable, IIdentifiable, INamable
{
    //Citizen <name> <age> <id> <birthdate>

    
    private int age;
    

    public Citizen(string name, int age, string id, string birthdate)
    {
        Name = name;
        Age = age;
        Id = id;
        Birthdate = birthdate;
    }
    public string Name { get; private set; }
    public int Age { get; private set; }
    public string Id { get; private set; }
    public string Birthdate { get; private set; }
}

