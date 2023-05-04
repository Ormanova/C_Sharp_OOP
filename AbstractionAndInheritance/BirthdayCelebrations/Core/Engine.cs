using BirthdayCelebrations.Core.Interfaces;
using BirthdayCelebrations.IO.Interfaces;
using BirthdayCelebrations.Models;
using BirthdayCelebrations.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayCelebrations.Core;

public class Engine : IEngine
{
    private IReader reader;
    private IWriter writer;

    public Engine(IReader reader, IWriter writer)
    {
        this.reader = reader;
        this.writer = writer;
    }
    public void Run()
    {
        //Citizen <name> <age> <id> <birthdate>
        //"Robot <model> <id>"
        //"Pet <name> <birthdate"
        List<IBirthable> members = new List<IBirthable>();  
        while (true)
        {
            string input = reader.ReadLine();
            if (input == "End")
            {
                break;
            }
            string[] tockens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (tockens[0] == "Citizen")
            {
                string name = tockens[1];
                int age = int.Parse(tockens[2]);
                string id = tockens[3];
                string birthdate = tockens[4];
                IBirthable citizen = new Citizen(name, age, id, birthdate);
                members.Add(citizen);
            }
            else if(tockens[0] == "Robot")
            {
                string name = tockens[1];
                string birthdate = tockens[2];
                IBirthable robot = new Robot(name, birthdate);
                members.Add(robot);
            }
            else if (tockens[0] == "Pet")
            {
                string name = tockens[1];
                string birthdate = tockens[2];
                IBirthable pet = new Robot(name, birthdate);
                members.Add(pet);
            }
        }
        string year = reader.ReadLine();
       
        foreach (var item in members)
        {
            if (item.Birthdate.EndsWith(year))
            {
                writer.WriteLine(item.Birthdate);
               
            }
        }
        
    }
}

