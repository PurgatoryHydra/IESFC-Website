using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IESFC_Website.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            submit.ServerClick += submit_ServerClick;
        }

        protected void submit_ServerClick(object sender, EventArgs e)
        {
            if (UserName.Text == "admin" && Password.Text == "iesfc2016")
            {
                Session["UserName"] = "admin";
                Response.Redirect("Main.aspx?UserName=" + UserName.Text);
            }
        }
    }
}
