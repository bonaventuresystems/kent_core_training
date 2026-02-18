using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DemoWeb
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            myLabel.Text = "Mahesh";
            Literal lt99 = new Literal();
            lt99.ID = "lt99";
            lt99.Text = "<br/>";

            form1.Controls.Add(lt99);
         
        }

    }
}