﻿using FoodShortage.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShortage.Models;

public class Rebel : INamable,IBuyer
{
    private const int FoodIncrement = 5;
    public Rebel( string name, int age, string group)
    {
        Name = name;
        Age = age;
        Group = group;
    }

    public string Name { get; private set; }
    public int Age { get; private set; }
    public string Group { get; private set; }



    public int Food { get; private set; }

    public void BuyFood()
    {
        Food += FoodIncrement;
    }
}

