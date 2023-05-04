using MilitaryElite.Enums;
using MilitaryElite.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite.Models;

public class Mission : IMission
{
    //A mission holds a code name and a state (inProgress or Finished). A Mission can be finished through the method CompleteMission().
    public Mission(string codeName, State state)
    {
        CodeName = codeName;
        State = state;
    }
    public string CodeName { get; private set; }

    public State State { get; private set; }

  

    public void CompleteMission()
    {
        State = State.Finished;
    }
    public override string ToString()
        => $"Code Name: {CodeName} State: {State}";
}

