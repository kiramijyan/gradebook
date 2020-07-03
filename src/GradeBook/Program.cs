using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            IBook book = new DiskBook("Johns's Grade Book");
            book.GradeAdded += OnGradeAdded;

            EnterGrades(book);

            var stats = book.GetStatistics();

            Console.WriteLine($"For the book named {book.Name}");
            Console.WriteLine($"The Lowest grade is: {stats.Low}");
            Console.WriteLine($"The Highest Grade is: {stats.High}");
            Console.WriteLine($"The Average Grade is: {stats.Average:N1}");
            Console.WriteLine($"The Letter Grade is: {stats.Letter}");

        }

        private static void EnterGrades(IBook book)
        {
            while (true)
            {
                Console.WriteLine("Please enter a grade or 'q' to quit");

                string input = Console.ReadLine();
                if (input == "q")
                {
                    break;
                }
                try
                {
                    double grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (System.ArgumentException e)
                {
                    Console.WriteLine("Error:" + e.Message);
                }
                catch (System.FormatException e)
                {
                    Console.WriteLine("Error:" + e.Message);
                }
                finally
                {
                    Console.WriteLine("***");
                }


            }
        }

        static void OnGradeAdded(object sender, EventArgs args)
        {
            Console.WriteLine("A Grade was added");
        }
    }
}
