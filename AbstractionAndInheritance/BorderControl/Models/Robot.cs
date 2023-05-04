﻿using BorderControl.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorderControl.Models;

public class Robot : IIdentifiable
{
    private string model;
    private int id;

    public Robot(string id, string model)
    {
        Id = id;
        Model = model;
    }
    public string Id { get; private set; }
    public string Model { get; private set; }

}

