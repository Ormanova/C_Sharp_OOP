using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionHierarchy.Models.Interfaces;

public interface IMylist : IRemovable
{
    public int Used { get; }
}

