using MilitaryElite.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite.Models;

public class LieutenantGeneral : Private, ILieutenantGeneral
{

    public LieutenantGeneral(int id, string firstName, string lastName, decimal salary, IReadOnlyCollection<Private> privates) : base(id, firstName, lastName, salary)
    {
        Privates = privates;
    }
    public IReadOnlyCollection<Private> Privates { get; private set; }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(base.ToString());
        foreach (var currPrivate in Privates)
        {
            sb.AppendLine($" {currPrivate.ToString()}");
        }
        return sb.ToString().TrimEnd();
    }
}

