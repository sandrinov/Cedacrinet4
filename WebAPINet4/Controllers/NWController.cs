using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPINet4.Controllers
{
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
    }
}
