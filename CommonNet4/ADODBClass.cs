using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonNet4.DTO;

namespace CommonNet4
{
    public class ADODBClass : IDBSource
    {
        public List<Employee> GetAllEmployees()
        {
            List<Employee> lst = new List<Employee>();
            lst.Add(new Employee() { EmployeeID=1, FirstName="Mario", LastName="Rossi", City="Parma" });
            lst.Add(new Employee() { EmployeeID = 2, FirstName = "Ugo", LastName = "Verdi", City = "Collecchio" });
            return lst;
        }

        public List<Order> GetAllOrders()
        {
            throw new NotImplementedException();
        }

        public Employee GetEmployeeByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetOrderByEmployee(string firstName, string lastName)
        {
            throw new NotImplementedException();
        }
    }
}
