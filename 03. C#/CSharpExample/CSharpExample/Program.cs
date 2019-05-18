using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Cat obj = new Cat();
            obj.Say();
            Console.ReadLine();

            //=================

            Console.WriteLine(obj.GetOriginal()); 
            Console.ReadLine();

            Cat obj1 = new Cat("My");
            //string catOriginal = "The cat original from:" + obj1.GetOriginal();
            string catOriginal = string.Format("{0}: {1}", "The cat original from", obj1.GetOriginal());
            Console.WriteLine(catOriginal);
            Console.ReadLine();

            Console.WriteLine(Cat.Magic);
            Console.WriteLine(Cat.Magic);
            Console.WriteLine(Cat.Magic);
            Console.WriteLine(Cat.Magic);
            Console.ReadLine();

            //================

            Cat obj2 = new Cat("Nhat ban", "Black");
            obj2.GetSkin();
            //obj2.Type = "Tam The";
            Console.WriteLine(obj2.Type);
            Console.ReadLine();

            //================
            SqrtPreCalculated.SqrtPrecalculated();
            Console.WriteLine(SqrtPreCalculated.GetSqrt(4));
            Console.ReadLine();

            int i = 5;
            long l = i;

            long l1 = 5;
            int i1 = (int)l1;

            int counter = 0;
            while (counter < 0)
            {
                Console.WriteLine(counter);
                counter++;
            }
            Console.ReadLine();
            //try
            //{
                Sum();
            //}
            //catch (Exception)
            //{
            //    Console.WriteLine("Gia tri nhap vao khong hop le.");
            //}
           
            Console.ReadLine();

            for (int number = 0; number < 10; number++)
            {
                Console.Write(number + " ");
            }
            Console.ReadLine();

            string[] days = {"Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            foreach (string day in days)
            {
                Console.WriteLine(day);
            }
            Console.ReadLine();

            // Declare a list of type int 
            GenericList<int> intList =
              new GenericList<int>();
            // Declare a list of type string
            GenericList<string> stringList =
              new GenericList<string>();

            GenericList<object> objectList =
              new GenericList<object>();
        }

        public class GenericList<T>
        {
            public void Add(T element) { }
        }


        private static void Sum()
        {
            Console.Write("n = ");
            try
            {
                int n = int.Parse(Console.ReadLine());
                int number = 1;
                int sum = 1;
                while (number < n)
                {
                    number++;
                    sum += number;
                }
                Console.WriteLine("Sum = {0}", sum);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Gia tri nhap vao khong hop le.");
                //Ghi log
                //throw ex;
            }
            finally
            {
                Console.WriteLine("Da giai phong doi tuong");
            }
        }
    }
}
