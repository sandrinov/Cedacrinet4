using EFDataSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCNet4.Controllers
{
    public class NorthwindCedController : Controller
    {
        private CommonNet4.IDBSource _db;
        public NorthwindCedController(CommonNet4.IDBSource db)
        {
            _db = db;
        }
        // GET: Northwind
        public ActionResult AllEmployees()
        {
            return View(_db.GetAllEmployees());
        }
        public ActionResult EmployeeDetails(int id)
        {
            return View(_db.GetEmployeeByID(id));
        }
    }
}