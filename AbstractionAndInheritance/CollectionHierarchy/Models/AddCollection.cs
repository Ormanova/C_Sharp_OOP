using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollectionHierarchy.Models.Interfaces;

namespace CollectionHierarchy.Models;

public class AddCollection : IAddable
{
    private readonly List<string> data;

    public AddCollection()
    {
        data = new List<string>();
    }
    public int Add(string item)
    {
        data.Add(item);
        return data.Count - 1;
    }
}

