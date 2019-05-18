using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDemo
{
    public class SqrtPrecalculated
    {
        public const int MAX_VALUE = 10000;
        // Static field 
        public static int Max_SqrtNumber = MAX_VALUE;
        private static int[] sqrtValues;
        
        // Static constructor
        static SqrtPrecalculated()
        {
            sqrtValues = new int[MAX_VALUE + 1];
            for (int i = 0; i < sqrtValues.Length; i++)
            {
                sqrtValues[i] = (int)Math.Sqrt(i);
            }
        }

        // Static method 
        public static int GetSqrt(int value)
        {
            return sqrtValues[value];
        }
    }
}
