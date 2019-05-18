using System;
using System.Linq;

class GroupingExample
{
    static void Main()
    {
        var people = new[] { 
            new { Name = "Kiki", Town = "HN" },
            new { Name = "Pepi", Town = "HP" },
            new { Name = "Koko", Town = "HCM" },
            new { Name = "Mimi", Town = "DN" }
        };
        var peopleByTowns = from p in people
                            group p by p.Town;
        foreach (var town in peopleByTowns)
        {
            Console.Write("Town {0}: ", town.Key);
            foreach (var person in town)
                Console.Write("{0} ", person.Name);
            Console.WriteLine();
        }
    }
}
