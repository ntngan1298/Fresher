using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Cat catObject = new Cat();
            catObject.Say();
            Console.ReadLine();

            catObject.Name = "Tom";
            catObject.SayWithName();
            Console.ReadLine();

            catObject = new Cat("Peter", "Hai");
            catObject.SayWithName();
            Console.ReadLine();

            Console.WriteLine(MathConstants.PI_SYMBOL);
            Console.ReadLine();

            ReadOnly readOnlyObject = new ReadOnly(10);
            readOnlyObject.GetSize();
            Console.ReadLine();

            Console.WriteLine(catObject.OriginalGet);
            Console.ReadLine();
            catObject.OriginalSet = "America";
            Console.WriteLine(catObject.OriginalGet);
            Console.ReadLine();

            Console.WriteLine(catObject.GetName());
            Console.ReadLine();
            Console.WriteLine(catObject.GetAge());
            Console.ReadLine();

            Console.WriteLine(SqrtPrecalculated.Max_SqrtNumber);
            Console.WriteLine(SqrtPrecalculated.GetSqrt(64));
            Console.ReadLine();

            //=======================================

            int i = 5;
            long l = i;
            //i = l;//error
            //i = (int)l;//OK

            if (i == 5)
            {
                Console.WriteLine("i = {0}", i);
            }
            else
            {
                Console.WriteLine("i != {0}", i);
            }
            Console.ReadLine();

            switch (l)
            {
                case 0:
                    break;
                case 1:
                case 5:
                    Console.WriteLine("l = {0}", i);
                    break;
                default:
                    Console.WriteLine("l != {0}", i);
                    break;
            }
            Console.ReadLine();

            //=======================================

            int counter = 0;
            while (counter < 10)
            {
                Console.WriteLine("Number : {0}", counter);
                //if (counter == 5)
                //{
                //    break;
                //}
                counter++;
            }
            Console.ReadLine();

            Sum();

            //========================================

            for (int number = 0; number < 10; number++)
            {
                if (number == 8)
                {
                    continue;
                }
                Console.Write(number + " ");
            }
            Console.ReadLine();

            //========================================

            string[] days = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            foreach (string day in days)
            {
                Console.WriteLine(day);
            }
            Console.ReadLine();

            //=======================================

            // Declare a list of type int 
            GenericList<int> intList = new GenericList<int>();
            intList.Add(4);
            // Declare a list of type string
            GenericList<string> stringList = new GenericList<string>();
            stringList.Add("Tung");

            //========================================

            TestEvent obj = new TestEvent();
            TestEvent.StringParse d = new TestEvent.StringParse(Sum);
            d();

            obj.ExecuteCompleted += Obj_ExecuteCompleted;
            obj.ActionCompleted += (x) =>
            {
                Console.WriteLine(x.ToString());
            };
            obj.Execute();
            obj.CompareTwoNumber = ((x, y) => { return x > y; });
            Console.WriteLine(obj.CompareTwoNumber(2, 3));
            Console.ReadLine();
        }

        private static void Obj_ExecuteCompleted(object sender, EventArgs e)
        {
            Console.WriteLine("ExecutedCompleted was run");
        }

        public static void Sum()
        {
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());
            int number = 1;
            int sum = 1;
            Console.Write("The sum 1");
            while (number < n)
            {
                number++;
                sum += number;
                Console.Write("+{0}", number);
            }
            Console.WriteLine(" = {0}", sum);
            //try
            //{
            //}
            //catch (FormatException ex)
            //{
            //    Console.WriteLine("Invalid integer number!");
            //}
            //catch (OverflowException ex)
            //{
            //    Console.WriteLine(
            //       "The number is too big to fit in Int32!");
            //    throw;
            //}

            Console.ReadLine();
        }
    }
}
