
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonNet4
{
    public interface IDBSource
    {
        DTO.Employee GetEmployeeByID(int id);
        List<DTO.Employee> GetAllEmployees();
        List<DTO.Order> GetAllOrders();
        List<DTO.Order> GetOrderByEmployee(String firstName, String lastName);
        List<DTO.Order> GetOrdersByEmployeeID(int employeeID);
        List<DTO.Order> GetOrdersByEmployeeID(int employeeID, int page, int size);
        int GetOrdersCountByEmployeeID(int employeeID);
    }
}
