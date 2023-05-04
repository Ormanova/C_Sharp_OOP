using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Students
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            // за да събираме обектите от типа студент правим лист:
            List<Student> students = new List<Student>();
            for (int i = 1; i <= n; i++)
            {
                string[] studentArg = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).ToArray();
                string currStudentFirstName = studentArg[0];
                string currStudentLastName = studentArg[1];
                double currStudentGrade =  double.Parse(studentArg[2]);

                // създаваме нов студент(обект)
                Student currentStudent = new Student(currStudentFirstName, currStudentLastName, currStudentGrade);

                // на всяка итерация добавяме обект(студент) с текущите данни към списъка с обекти
                students.Add(currentStudent);
            }
            //сортиране на обектите в списъка:
            List<Student> orderedStudentss = students.OrderByDescending(s => s.Grade).ToList();
            // отпечатване
            foreach (Student student in orderedStudentss)
            {
                Console.WriteLine(student);
            }
        }
    }
    class Student
    {
        public Student(string firstName, string lastName, double grade)
        {
             //Always called ehen new student is being created
             this.FirstName = firstName;
            this.LastName = lastName;
            this.Grade = grade; 
        }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public double Grade { get; set; }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName}: {this.Grade:f2}";
        }

    }
}
