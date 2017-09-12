using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateSample
{
    class Program
    {
        static void Main(string[] args)
        {
            MailManager mm = new MailManager();
            Fax fax = new Fax(mm);
            Printer prn = new Printer(mm);


            mm.SimulateMailArrived(new Email()
            {

                From = "Topolino",
                Body = "Cara Minni usciamo?"
            });
            mm.SimulateMailArrived(new Email()
            {
                From = "Minni",
                Body = "No, esco con Pippo"
            });
        }
    }
}
