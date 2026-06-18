using System;
using System.Data.Entity;
using System.Linq;

namespace CodeFirstStudentApp
{
    // 1. Define the Domain Class (The Model)
    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public decimal Height { get; set; }
        public float Weight { get; set; }
    }

    // 2. Define the Context Class (Manages database connection and data operations)
    public class SchoolContext : DbContext
    {
        // The name of the connection string or database can be passed to the base constructor
        public SchoolContext() : base("SchoolDB")
        {
        }

        public DbSet<Student> Students { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 3. Initialize the Context and Add a New Student
            using (var ctx = new SchoolContext())
            {
                Console.WriteLine("Adding a new student to the database...");

                var stud = new Student() { StudentName = "Alex Mercer" };

                ctx.Students.Add(stud);
                ctx.SaveChanges(); // This line triggers the creation of the database and saves the record

                Console.WriteLine("Student saved successfully!");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}

