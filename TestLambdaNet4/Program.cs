using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLambdaNet4
{
    public delegate bool IntFilter(int i);
    public class Common
    {
        public static List<int> FilterArrayOfInts(List<int> ints, IntFilter filter)
        {
            List<int> resultlist = new List<int>();
            foreach (int i in ints)
            {
                if (filter(i))
                    resultlist.Add(i);
            }
            return resultlist;
        }
    }

    public static class StringConversions
    {
        public static double ToDouble(this string s)
        {
            return Double.Parse(s);
        }
        public static bool ToBool(this string s)
        {
            return Boolean.Parse(s);
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            //UsingLambda();
            //UsingExtensionMethods();

            var user = new {FirstName="Mario", LastName="Rossi", Age=99, HireDate = DateTime.Now.AddDays(-3650) };
            var user2 = new { FirstName = "Mario", LastName = "Rossi", Age = 99, HireDate = DateTime.Now.AddDays(-3650) };
            Console.WriteLine(user.GetType().ToString());
            Console.WriteLine(user2.GetType().ToString());


        }

        private static void UsingExtensionMethods()
        {
            String spi = "3.1415926535";
            Double d = spi.ToDouble();
            char[] chrlst = spi.ToArray();

            int? j = null;

            if (j.HasValue)
                j = 10 * j.Value;
        }

        private static void UsingLambda()
        {
            List<int> ints = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            #region Explicit Method
            //IntFilter ptr = new IntFilter(IsOdd);
            //List<int> resultList = Common.FilterArrayOfInts(ints, ptr);
            #endregion

            #region Anonymous method
            //List<int> resultList = Common.FilterArrayOfInts(ints, delegate (int i) { return ((i & 1) == 1); });
            #endregion

            #region Lambda expression
            //List<int> resultList = Common.FilterArrayOfInts(ints,   i => ((i & 1) == 1)   );
            List<int> resultList = Common.FilterArrayOfInts(ints, i =>
            {
                if ((i % 5) == 0)
                    return true;
                else
                    return false;

                //return IsOdd(i);
            });
            #endregion

            foreach (var i in resultList)
            {
                Console.WriteLine(i);
            }
        }
        public static bool IsOdd(int i)
        {
            return ((i & 1) == 1);
        }
    }
}
