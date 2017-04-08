using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace IESFC_Website.Account
{
    public partial class Main : System.Web.UI.Page
    {
        SqlConnection sqlconn;
        string conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Write("<script>alert('您无权限进行此操作');</script>");
                Server.Transfer("~/Default.aspx");
            }
            else
            {
                conn = "Data Source=127.0.0.1;Initial Catalog=IESFC member database;Integrated Security=false;Pooling=False;uid=duke;password=D6b4cw";
                sqlconn = new SqlConnection(conn);//链接数据库
                sqlconn.Open();
            }
        }

        protected void test1_Click(object sender, EventArgs e)
        {
        }
    }
}