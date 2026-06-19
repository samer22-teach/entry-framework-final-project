public class Student
{
    public int StudentID { get; set; }
    public string StudentName { get; set; }
}
using System.Data.Entity;

public class SchoolContext : DbContext
{
    public SchoolContext() : base("SchoolDB") 
    {
    }

    public DbSet<Student> Students { get; set; }
}
using System;

class Program
{
    static void Main(string[] args)
    {
        using (var db = new SchoolContext())
        {
            // Create a new student
            var newStudent = new Student { StudentName = "John Doe" };

            // Add to database
            db.Students.Add(newStudent);
            db.SaveChanges();

            Console.WriteLine("Student added successfully!");
        }
    }
}

