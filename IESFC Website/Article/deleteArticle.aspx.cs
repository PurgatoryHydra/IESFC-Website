using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace IESFC_Website.news
{
    public partial class deleteArticle : System.Web.UI.Page
    {
        SqlConnection sqlconn;
        string conn;
        SqlCommand cmd;
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
                string deleteTarget = Request.QueryString["deleteTarget"];
                string id = Request.QueryString["articleID"];

                if (deleteTarget == "article")
                {
                    cmd = sqlconn.CreateCommand();
                    cmd.CommandText = "DELETE FROM article WHERE id=" + id;
                    int Result = cmd.ExecuteNonQuery();

                    if (Result > 0)
                    {
                        Response.Write("<script>alert('删除成功');</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('删除失败');</script>");
                    }
                }
                else if (deleteTarget == "image")
                {
                    string imageName = Request.QueryString["imageName"];
                    try
                    {
                        File.Delete(Server.MapPath("UploadFiles/Images/" + id + "/" + imageName));
                        Response.Write("<script>alert('删除成功');</script>");
                    }
                    catch
                    {
                        Response.Write("<script>alert('删除失败');</script>");
                    }
                }
            }
        }
    }
}