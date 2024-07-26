using System;
using System.Collections.Generic;
using System.Linq;


public class Student
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public float Grade { get; set; }

    public Student(string firstName, string lastName, float grade)
    {
        FirstName = firstName;
        LastName = lastName;
        Grade = grade;
    }
}


public class Program
{
    public static void Main(string[] args)
    {
        
        int numberOfStudents = int.Parse(Console.ReadLine());
        List<Student> students = new List<Student>();

        for (int i = 0; i < numberOfStudents; i++)
        {
            string[] studentData = Console.ReadLine().Split(' ');
            string firstName = studentData[0];
            string lastName = studentData[1];
            float grade = float.Parse(studentData[2]);

            Student student = new Student(firstName, lastName, grade);
            students.Add(student);
        }

        
        var sortedStudents = students.OrderByDescending(s => s.Grade).ToList();

        
        foreach (Student student in sortedStudents)
        {
            Console.WriteLine($"{student.FirstName} {student.LastName}: {student.Grade:F2}");
        }
    }
}
