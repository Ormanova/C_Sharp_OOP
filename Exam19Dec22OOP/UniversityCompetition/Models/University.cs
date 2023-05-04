﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Models
{
    public class University : IUniversity
    {
        private int id;
        private string name;
        private string category;
        private int capacity;
        private List<int> requiredSubjects;
        private readonly List<string> categories = new List<string>() { "Technical", "Economical", "Humanity" };

        public University(int universityId, string universityName, string category, int capacity, ICollection<int> requiredSubjects)
        {
            Id = universityId;
            Name = universityName;
            Category = category;
            Capacity = capacity;
            this.requiredSubjects = requiredSubjects.ToList();
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
        public string Category
        {
            get { return category; }
            private set 
            {
                if (!categories.Contains(value))
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.CategoryNotAllowed, value));
                }
                category = value; 
            }
        }

        public int Capacity
        {
            get { return capacity; }
            private set 
            {
                if (value < 0)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.CapacityNegative));
                }
                capacity = value; 
            }
        }

        //RequiredSubjects – IReadOnlyCollection<int> - A collection of integer values, representing the subject ids of all the subjects on which the student has to have the exams covered.
        public IReadOnlyCollection<int> RequiredSubjects {get{ return requiredSubjects.AsReadOnly(); } }
    }
}
