﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Models;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories
{
    public class UniversityRepository : IRepository<IUniversity>
    {
        private List<IUniversity> models;
        public UniversityRepository()
        {
            models = new List<IUniversity>();
        }
        public IReadOnlyCollection<IUniversity> Models => this.models.AsReadOnly();

        public void AddModel(IUniversity model)
        {
            University university = new University(models.Count + 1, model.Name, model.Category, model.Capacity, model.RequiredSubjects.ToList());
            models.Add(university);
        }

        public IUniversity FindById(int id)
        {
            return models.FirstOrDefault(x => x.Id == id);
        }

        public IUniversity FindByName(string name)
        {
            return models.FirstOrDefault(x => x.Name == name);
        }
    }
}
