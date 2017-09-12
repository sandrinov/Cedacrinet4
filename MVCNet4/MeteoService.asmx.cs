using MVCNet4.App_Start;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Services;

namespace MVCNet4
{
    /// <summary>
    /// Summary description for MeteoService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class MeteoService : System.Web.Services.WebService
    {
        private CommonNet4.IDBSource _db;

        [Inject]
        public CommonNet4.IDBSource db
        {
            get { return _db; }
            set { _db = value; }
        }
        //public MeteoService(CommonNet4.IDBSource db)
        //{
        //    _db = db;
        //}

        //public MeteoService()
        //{
        //    _db = new EFDataSource.DBClass();
        //}

        public MeteoService()
        {
            NinjectWebCommon.CurrentKernel.Inject(this);
        }

        [WebMethod]
        public List<CommonNet4.DTO.Employee> GetEmployeesViaASMX()
        {
            return _db.GetAllEmployees();
        }

        [WebMethod]
        public string GetPrevisione(String citta)
        {
            Thread.Sleep(5000);
            if (citta == "Parma")
                return "SUN";
            else
                return "CLOUDY";
        }

        [WebMethod]
        public double GetTemperatura(String citta)
        {
            if (citta == "Parma")
                return 14.5;
            else
                return 11.6;
        }
    }
}
