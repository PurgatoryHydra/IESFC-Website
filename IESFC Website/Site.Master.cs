using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IESFC_Website
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] != null)
            {
                HeadLoginStatus.InnerHtml = "欢迎，" + Session["UserName"];
                HeadLoginStatus.HRef = "/Account/Main.aspx?UserName=" + Session["UserName"];
            }
        }

        protected void buttonSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Article/ManageArticle.aspx?articleType=searchResult&pageCount=0&keyword=" + TextBoxSearch.Text);
        }
    }
}
