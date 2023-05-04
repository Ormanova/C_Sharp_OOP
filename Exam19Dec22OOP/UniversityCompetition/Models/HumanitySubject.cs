using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Models.Contracts;

namespace UniversityCompetition.Models
{
    public class HumanitySubject : Subject
    {
        private const double HumSubjectRate = 1.15;

        public HumanitySubject(int subjectId, string subjectName) : base(subjectId, subjectName, HumSubjectRate)
        {
        }
    }
}
