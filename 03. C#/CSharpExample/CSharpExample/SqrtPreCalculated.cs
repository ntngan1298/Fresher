using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpExample
{
    class SqrtPreCalculated
    {
        public const int MAX_VALUE = 10;

        // Static field public static int Max_SqrtNumber = MAX_VALUE;
        private static int[] sqrtValues;

        public static void SqrtPrecalculated()
        {
            sqrtValues = new int[MAX_VALUE + 1];
            for (int i = 0; i < sqrtValues.Length; i++)
            {
                sqrtValues[i] = (int)Math.Sqrt(i);
            }
        }  // Static method 

        public static int GetSqrt(int value)
        {
            return sqrtValues[value];
        }
    }
}
