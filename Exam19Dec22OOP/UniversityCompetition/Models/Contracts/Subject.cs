﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Models.Contracts
{
    public abstract class Subject : ISubject
    {
        private int id;
        private string name;
        private double rate;

        public Subject(int subjectId, string subjectName, double subjectRate)
        {
            Id = subjectId;
            Name = subjectName;
            Rate = subjectRate;
            
        }

        public int Id
        {
            get { return id; }
            private set { id = value; }
        }

        public string Name
        {
            get { return name; }
            private set 
            { 
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }
                name = value; 
            }
        }

        public double Rate
        {
            get { return rate; }
            private set { rate = value; }
        }


    }
}
