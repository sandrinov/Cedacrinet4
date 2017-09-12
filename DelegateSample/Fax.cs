using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateSample
{
    public class Fax
    {
        private MailManager _mm;
        public Fax(MailManager mm)
        {
            _mm = mm;
            _mm.MailArrived += _mm_MailArrived;
        }

        private void _mm_MailArrived(object sender, Email e)
        {
            Console.WriteLine("FAX: " + e.Body);
        }
    }
}
