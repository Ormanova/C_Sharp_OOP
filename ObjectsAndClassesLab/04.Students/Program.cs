using System;
using System.Collections.Generic;

namespace _04.Students
{
    class Student
    {
        
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
                string[] currArg = comand.Split(' ',StringSplitOptions.RemoveEmptyEntries);
                string firstName = currArg[0];
                string lastName = currArg[1];
                int age = int.Parse(currArg[2]);
                string homeTown = currArg[3];
                Student student = new Student()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Age = age,
                    HomeTown = homeTown    
                };
                students.Add(student);

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
    }
}
