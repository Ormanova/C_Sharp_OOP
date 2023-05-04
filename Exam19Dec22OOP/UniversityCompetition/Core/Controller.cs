using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Core.Contracts;
using UniversityCompetition.Models;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories;
using UniversityCompetition.Repositories.Contracts;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Core
{
    public class Controller : IController
    {
        private SubjectRepository subjects;
        private StudentRepository students;
        private UniversityRepository universities;
        private readonly List<string> subjectTypes = new List<string>() { "EconomicalSubject", "HumanitySubject", "TechnicalSubject" };
        public Controller()
        {
            subjects = new SubjectRepository();
            students = new StudentRepository();
            universities = new UniversityRepository();
        }

        public string AddSubject(string subjectName, string subjectType)
        {
            //oThe Id property will take its value upon adding the entity to the SubjectRepository. Every new Subject will take the next consecutive number in the repository, starting from 1. The property will be set in the AddSubject method from the Controller class.
            if (!subjectTypes.Contains(subjectType))
            {
                return String.Format(OutputMessages.SubjectTypeNotSupported, subjectType);
            }
            if (subjects.FindByName(subjectName) != null)
            {
                return String.Format(OutputMessages.AlreadyAddedSubject, subjectType);
            }

            Subject subject = null;
            if (subjectType == typeof(TechnicalSubject).Name)
            {
                subject = new TechnicalSubject(0, subjectName);
            }
            if (subjectType == typeof(EconomicalSubject).Name)
            {
                subject = new EconomicalSubject(0, subjectName);
            }
            if (subjectType == typeof(HumanitySubject).Name)
            {
                subject = new HumanitySubject(0, subjectName);
            }
            subjects.AddModel(subject);
            //If none of the above cases is reached, create a new Subject from the appropriate type and add it to the SubjectRepository. Return the following message: "{subjectType} {subjectName} is created and added to the {relevantRepositoryTypeName}!"
            return String.Format(OutputMessages.SubjectAddedSuccessfully, subject.GetType().Name, subjectName, subjects.GetType().Name);
        }
        public string AddUniversity(string universityName, string category, int capacity, List<string> requiredSubjects)
        {
            if (universities.FindByName(universityName) != null)
            {
                return String.Format(OutputMessages.AlreadyAddedUniversity, universityName);
            }
            //If the above case is not reached, convert the given collection of requiredSubjects into collection of integers, containing every required subject’s id. The subjects will be already added into the SubjectRepository. Create a new University and add it to the UniversityRepository. Return the following message: "{universityName} university is created and added to the {relevantRepositoryTypeName}!"
            List<int> ids = requiredSubjects.Select(s => subjects.FindByName(s).Id).ToList();
            University university = new University(0, universityName, category, capacity, ids);
            universities.AddModel(university);
            return String.Format(OutputMessages.UniversityAddedSuccessfully, universityName, universities.GetType().Name);
        }

        public string AddStudent(string firstName, string lastName)
        {
            if (students.FindByName($"{firstName} {lastName}") != null)
            {
                return String.Format(OutputMessages.AlreadyAddedStudent, firstName, lastName);
            }
            students.AddModel(new Student(0, firstName, lastName));
            return String.Format(OutputMessages.StudentAddedSuccessfully, firstName, lastName, students.GetType().Name);
        }

        public string TakeExam(int studentId, int subjectId)
        {
            IStudent student = students.FindById(studentId);
            if (student == null)
            {
                return String.Format(OutputMessages.InvalidStudentId);
            }
            ISubject subject = subjects.FindById(subjectId);
            if (subject == null)
            {
                return String.Format(OutputMessages.InvalidSubjectId);

            }
            //If the Student with the given studentId has already covered the exam (check in the CoveredExam collection of the Student) on the Subject with the given subjectId, return the following message: "{studentFirstName} {studentLastName} has already covered exam of {subjectName}."
            if (student.CoveredExams.Contains(subjectId))
            {
                return String.Format(OutputMessages.StudentAlreadyCoveredThatExam, student.FirstName, student.LastName, subject.Name);
            }
            //If none of the above cases is reached, add the given subjectId to the collection CoveredExams of the Student with the given studentId. Return the following message: "{studentFirstName} {studentLastName} covered {subjectName} exam!"
            student.CoverExam(subject);
            return String.Format(OutputMessages.StudentSuccessfullyCoveredExam, student.FirstName, student.LastName, subject.Name);
        }
        public string ApplyToUniversity(string studentName, string universityName)
        {
            
            IStudent student = students.FindByName(studentName);
            if (student == null)
            {
                return String.Format($"{studentName} is not registered in the application!");
            }
            IUniversity university = universities.FindByName(universityName);
            if (university == null)
            {
                return String.Format(OutputMessages.UniversityNotRegitered, universityName);
            }
            //If the Student with the given studentName has not covered all the required exams for the University with the given name, return the following message: "{studentName} has not covered all the required exams for {universityName} university!"
            foreach (var requiredExam in university.RequiredSubjects)
            {
                if (!student.CoveredExams.Contains(requiredExam))
                {
                    return String.Format(OutputMessages.StudentHasToCoverExams, studentName, universityName);
                }
            }

            //If the Student with the given studentName has already joined the University with the given universityName, return the following message: "{studentFirstName} {studentLastName} has already joined {UniversityName}."
            if (student.University != null && student.University.Name == university.Name)
            {
                return String.Format(OutputMessages.StudentAlreadyJoined, student.FirstName, student.LastName, universityName);
            }
            student.JoinUniversity(university);
            return String.Format(OutputMessages.StudentSuccessfullyJoined, student.FirstName, student.LastName, universityName);
        }



        public string UniversityReport(int universityId)
        {
            IUniversity university = universities.FindById(universityId);
            int admittedSudents = CountStudentsInUni(university);
            int capacityLeft = university.Capacity - admittedSudents;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"*** {university.Name} ***");
            sb.AppendLine($"Profile: {university.Category}");
            sb.AppendLine($"Students admitted: {admittedSudents}");
            sb.AppendLine($"University vacancy: {capacityLeft}");
            return sb.ToString().TrimEnd();
        }
        private int CountStudentsInUni(IUniversity university)
        {
            int count = 0;
            foreach (var student in students.Models)
            {
                if (student.University?.Id == university.Id)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
