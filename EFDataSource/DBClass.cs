﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonNet4.DTO;

namespace EFDataSource
{
    public class DBClass : CommonNet4.IDBSource
    {
        private NorthwindEntities ctx;
        private EmployeeFactory empFactory;
        private OrderFactory ordFactory;
        public DBClass()
        {
            ctx = new NorthwindEntities();
            ctx.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
            empFactory = new EmployeeFactory();
            ordFactory = new OrderFactory();
        }

        public CommonNet4.DTO.Employee GetEmployeeByID(int id)
        {
            var entity =  ctx.Employees.Where(e => e.EmployeeID == id).FirstOrDefault();
            return empFactory.GetDTO(entity);
        }
        public List<CommonNet4.DTO.Employee> GetAllEmployees()
        {
            List<CommonNet4.DTO.Employee> dtoList = new List<CommonNet4.DTO.Employee>();

            var result = from e in ctx.Employees
                         orderby e.LastName
                         select e;
            foreach (var item in result.ToList())
            {
                dtoList.Add(empFactory.GetDTO(item));
            }

            //return ctx.EmployeesTables.ToList();

            //var sql = ((System.Data.Entity.Core.Objects.ObjectQuery)result)
            //.ToTraceString();

            // var sql = ((System.Data.Objects.ObjectQuery)result).ToTraceString();

            return dtoList;
        }
        public List<CommonNet4.DTO.Order> GetAllOrders()
        {
            var result = from o in ctx.Orders
                         orderby o.OrderDate
                         select o;
            //return result.ToList();

            //return ctx.Orders.ToList();

            return null;

        }
        public List<CommonNet4.DTO.Order> GetOrderByEmployee(String firstName, String lastName)
        {
            List<CommonNet4.DTO.Order> dtoList = new List<CommonNet4.DTO.Order>();

            var result = from o in ctx.Orders
                         join e in ctx.Employees on o.EmployeeID equals e.EmployeeID
                         where (e.FirstName == firstName && e.LastName == lastName)
                         orderby o.OrderDate
                         select o;

            foreach (var item in result.ToList())
            {
                dtoList.Add(ordFactory.GetDTO(item));
            }
            return dtoList;
        }

        public List<CommonNet4.DTO.Order> GetOrdersByEmployeeID(int employeeID)
        {
            List<CommonNet4.DTO.Order> lstOrders = new List<CommonNet4.DTO.Order>();
            var employee = ctx.Employees
                               .Where(e => e.EmployeeID == employeeID)
                               .FirstOrDefault();
            if (employee != null)
            {
                var lstEntities = employee.Orders.ToList();
                foreach (var entity in lstEntities)
                {
                    lstOrders.Add(ordFactory.GetDTO(entity));
                }
            }
            return lstOrders;
        }

        public List<CommonNet4.DTO.Order> GetOrdersByEmployeeID(int employeeID, int page, int size)
        {
            List<CommonNet4.DTO.Order> lstOrders = new List<CommonNet4.DTO.Order>();
            var employee = ctx.Employees
                           .Where(e => e.EmployeeID == employeeID)
                           .FirstOrDefault();
            if (employee != null)
            {
                var lstEntities = employee.Orders
                                          .OrderBy(o=>o.OrderDate)
                                          .ThenBy(o => o.OrderID)
                                          .Skip(size * (page - 1))
                                          .Take(size)
                                          .ToList();


                foreach (var entity in lstEntities)
                {
                    lstOrders.Add(ordFactory.GetDTO(entity));
                }
            }
            return lstOrders;

        }

        public int GetOrdersCountByEmployeeID(int employeeID)
        {
            int count = 0;
            var employee = ctx.Employees
                          .Where(e => e.EmployeeID == employeeID)
                          .FirstOrDefault();
            if (employee != null)
            {
                count = employee.Orders.Count;
            }
            return count;
        }
    }
}
