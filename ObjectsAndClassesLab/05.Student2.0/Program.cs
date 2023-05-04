using System;
using System.Collections.Generic;

namespace _05.Student2._0
{
    class Student
    {
        public Student(
            string firstName,
            string lastName,
            int age,
            string homeTown)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.HomeTown = homeTown;

        }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string HomeTown { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            string comand = Console.ReadLine();
            while (comand != "end")
            {
                string[] currArg = comand.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string firstName = currArg[0];
                string lastName = currArg[1];
                int age = int.Parse(currArg[2]);
                string homeTown = currArg[3];
                

                if (DoesStudentExist(students, firstName, lastName))
                {
                    var existingStudent = GetExistingStudent(students, firstName, lastName);
                    existingStudent.FirstName = firstName;
                    existingStudent.LastName = lastName;
                    existingStudent.Age = age;
                    
                }
                else
                {
                    Student newStudent = new Student(
                                                firstName,
                                                lastName,
                                                age,
                                                homeTown);
                    students.Add(newStudent);
                }

                comand = Console.ReadLine();
            }
            string city = Console.ReadLine();
            foreach (Student student in students)
            {
                if (student.HomeTown == city)
                {
                    Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
                }
            }
        }

        private static Student GetExistingStudent(List<Student> students, string firstName, string lastName)
        {
            foreach (var student in students)
            {
                if (student.FirstName == firstName && student.LastName == lastName)
                {
                    return student;
                }
            }
            return null;
        }

        static bool DoesStudentExist(List<Student> students, string firstName, string lastName)
        {
            foreach (Student student in students)
            {
                if (student.FirstName == firstName && student.LastName == lastName)
                {
                    return true;
                }
                
            }
            return false;
        }
    }
}
