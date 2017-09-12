using EFDataSource;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MVCNet4.Controllers
{
    /// <summary>
    /// Controller with Ninject as Ioc 
    /// </summary>
    public class NorthwindCedController : Controller
    {
        //private CommonNet4.IDBSource _db;
        private HttpClient client = new HttpClient();
        public NorthwindCedController(CommonNet4.IDBSource db)
        {
            //_db = db;
            client.BaseAddress = new Uri("http://localhost:17570/");
        }
        // GET: Northwind
        public async Task<ActionResult> AllEmployees()
        {
            //return View(_db.GetAllEmployees());
            var api_url = "api/employees";
            HttpResponseMessage egsResponse = await client.GetAsync(api_url);

            if (egsResponse.IsSuccessStatusCode)
            {
                string content = await egsResponse.Content.ReadAsStringAsync();
                var lstEmployees =
                    JsonConvert.DeserializeObject<IEnumerable<CommonNet4.DTO.Employee>>(content);
                return View(lstEmployees);
            }
            else
            {
                return Content("An error occurred.");
            }

        }
        public ActionResult EmployeeDetails(int id)
        {
            //return View(_db.GetEmployeeByID(id));
            return View();
        }
    }
}