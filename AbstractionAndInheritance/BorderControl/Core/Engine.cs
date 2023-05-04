using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BorderControl.Core.Interfaces;
using BorderControl.IO.Interfaces;
using BorderControl.Models;
using BorderControl.Models.Interfaces;

namespace BorderControl.Core;

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
        List<IIdentifiable> society = new();
        while (true)
        {
            string input = reader.ReadLine();
            if (input == "End")
            {
                break;
            }
            string[] tockens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
           
            if (tockens.Length == 3)
            {
                IIdentifiable citizen = new Citizen(tockens[2], tockens[0], int.Parse(tockens[1]));
                society.Add(citizen);
            }
            else
            {
                IIdentifiable robot = new Robot(tockens[1], tockens[0]);
                society.Add(robot);
            }
        }
        string fakeNumber = reader.ReadLine();

        foreach (var element in society)
        {
            if (element.Id.EndsWith(fakeNumber))
            {
                writer.WriteLine(element.Id);
            }
        }
    }
}

