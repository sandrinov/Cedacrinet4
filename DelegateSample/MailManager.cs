using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateSample
{
    public class Email
    {
        public String From { get; set; }
        public String Body { get; set; }
    }

    public delegate void MailArrivedEventHandler(Object sender, Email e);

    public class MailManager
    {
        public event MailArrivedEventHandler MailArrived;

        public void SimulateMailArrived(Email e)
        {
            //MailArrived?.Invoke(this, e);

            if (MailArrived != null)
            {
                Delegate[] arrayOfDelegates = MailArrived.GetInvocationList();
                foreach (Delegate item in arrayOfDelegates)
                {
                    MailArrivedEventHandler ptr = (MailArrivedEventHandler)item;
                    ptr(this, e);
                }
            }


        }
    }
}
