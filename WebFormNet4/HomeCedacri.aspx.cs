using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormNet4
{
    public partial class HomeCedacri : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Trace.IsEnabled = true;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            this.ListBox1.Items.Add(this.TextBox1.Text);
            this.TextBox1.Text = "";
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ListBox1.Items.Add(this.DropDownList1.SelectedItem.ToString());
        }
    }
}