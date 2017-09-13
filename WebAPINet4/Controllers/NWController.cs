using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebAPINet4.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class NWController : ApiController
    {
        private CommonNet4.IDBSource _db;

        public NWController(CommonNet4.IDBSource db)
        {
            _db = db;
        }

        [Route("api/employees")]
        public IHttpActionResult Get()
        {
            return Ok(_db.GetAllEmployees());
        }
        [Route("api/orders")]
        public IHttpActionResult GetOrders(int EmployeeID, int page, int size)
        {
            //return Ok(_db.GetOrdersByEmployeeID(EmployeeID));

            return Ok(_db.GetOrdersByEmployeeID(EmployeeID, page, size));
        }
        [Route("api/orderscount")]
        public IHttpActionResult GetOrdersCount(int EmployeeID)
        {
            //return Ok(_db.GetOrdersByEmployeeID(EmployeeID));

            return Ok(_db.GetOrdersCountByEmployeeID(EmployeeID));
        }
    }
}
