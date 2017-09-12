using EFDataSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleNet4
{

    public delegate int GetLengthHandler(String s);

    public class MyClass
    {
        public int LengthResponse(String s)
        {
            return s.Length;
        }
    }
    public class YourClass
    {
        public void ManageLength(GetLengthHandler ptr)
        {
            Console.WriteLine(  ptr("aaaaaaaaaaaaaaaaaaaaaaaaaaaaa") );
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //DelegateTest();
            DBClass db = new DBClass();
            //List<Order> result = db.GetAllOrders();

            //List<Order> result = db.GetOrderByEmployee("Nancy", "Davolio");
            List<EmployeesTable> result = db.GetAllEmployees();

            //EmployeesTable nancy = result.ElementAt(0);


            foreach (var emp in result)
            {
                Console.WriteLine("Name:" + emp.FirstName);
                foreach (var order in emp.Orders)
                {
                    Console.WriteLine(order.ShipName);
                }
            }

        }

        private static void DelegateTest()
        {
            MyClass mc = new MyClass();
            YourClass yc = new YourClass();
            GetLengthHandler ptr = new GetLengthHandler(mc.LengthResponse);
            //Console.WriteLine(ptr("ijijoijojojojojojoiio"));
            yc.ManageLength(ptr);
        }
    }
}
