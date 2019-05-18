using System;
using System.Linq;

class SelectManyExample
{
    static void Main()
    {
        var students =
        new[] {  
            new { Name = "NTTung", Courses = new string[] {".NET", "PHP" }},
            new { Name = "NTTung", Courses = new string[] {"Java", "PHP" , "SQL"}},
            new { Name = "NTTung", Courses = new string[] {"Java", "PHP" }},
            new { Name = "NTTung", Courses = new string[] {".NET", "Java" }}
        };

        var courses = students.SelectMany(s => s.Courses).Distinct().OrderBy(c => c);
        
        foreach (var c in courses)
        {
            Console.WriteLine(c);
        }
    }
}
