using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Models.Contracts;

namespace UniversityCompetition.Models
{
    public class TechnicalSubject : Subject
    {
        private const double TechSubjectRate = 1.3;
        public TechnicalSubject(int subjectId, string subjectName) : base(subjectId, subjectName, TechSubjectRate)
        {

        }
    }
}
