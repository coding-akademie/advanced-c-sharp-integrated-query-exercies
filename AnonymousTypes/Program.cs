using System;
using System.Linq;

namespace AnonymousTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            // create some variables with anonymous types
            var a = new { ID = 0, Name = "Fritz" };
            var b = new { ID = 1, Name = "Hans" };
            var c = new { ID = 2, FirstName = "Franz", LastName = "Huber" };


            // check which types are equal
            Console.WriteLine("a.GetType() == b.GetType(): " + (a.GetType() == b.GetType()));

            Console.WriteLine("a.GetType() == c.GetType(): " + (a.GetType() == c.GetType()));


            // construct a new type based on existing ones
            var d = new { c.ID, FullName = c.FirstName + " " + c.LastName };

            Console.WriteLine("\nID: " + d.ID + ", FullName: " + d.FullName);


            // nested types
            var e = new
            {
                ID = 0,
                Name = "Max Müller",
                Interests = new[] 
                {
                    new { Name = "Music", InterestRate = 9 },
                    new { Name = "Electronics", InterestRate = 8 },
                    new { Name = "Sports", InterestRate = 7 },
                }
            };

            // read only!
            // e.Name = "Max Mustermann";

            Console.WriteLine("\nInterests of " + e.Name + ":");

            e.Interests.ToList().ForEach(interest => Console.WriteLine(interest.Name + " " + interest.InterestRate));
        }
    }
}
