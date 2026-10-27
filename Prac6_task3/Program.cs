using System;
using System.Text.Json;

class Student
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public double AverageGrade { get; set; }
}

class Program
{
    static void Main()
    {
        List<Student> students = new List<Student>
        {
            new Student { Id = 1, Name = "San", AverageGrade = 89.5 },
            new Student { Id = 2, Name = "Mingi", AverageGrade = 95.2 },
            new Student { Id = 3, Name = "Wooyoung", AverageGrade = 91.7 },
            new Student { Id = 4, Name = "Jongho", AverageGrade = 84.3 },
            new Student { Id = 5, Name = "Felix", AverageGrade = 97.8 }
        };

        string json = JsonSerializer.Serialize(
            students,
            new JsonSerializerOptions { WriteIndented = true }
        );

        File.WriteAllText("students.json", json);

        Console.WriteLine("Students saved to students.json");

        string jsonFromFile = File.ReadAllText("students.json");

        List<Student>? loadedStudents = JsonSerializer.Deserialize<List<Student>>(jsonFromFile);

        if (loadedStudents != null && loadedStudents.Count > 0)
        {
            Student bestStudent = loadedStudents[0];

            foreach (Student student in loadedStudents)
            {
                if (student.AverageGrade > bestStudent.AverageGrade)
                {
                    bestStudent = student;
                }
            }

            Console.WriteLine("\nStudent with the highest average grade:");
            Console.WriteLine($"Id: {bestStudent.Id}");
            Console.WriteLine($"Name: {bestStudent.Name}");
            Console.WriteLine($"Average grade: {bestStudent.AverageGrade}");
        }
    }
}