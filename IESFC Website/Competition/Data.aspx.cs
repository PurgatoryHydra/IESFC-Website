using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace IESFC_Website
{
    public partial class Data : System.Web.UI.Page
    {
        SqlConnection sqlconn;
        string conn;
        SqlDataAdapter sa;
        SqlCommandBuilder sb;
        DataTable dt;
        string competitionName;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack == false)
            {
                competitionName = Request.QueryString["competitionName"];
                conn = "Data Source=127.0.0.1;Initial Catalog=IESFC member database;Integrated Security=false;Pooling=False;uid=duke;password=D6b4cw";
                sqlconn = new SqlConnection(conn);//链接数据库

                sqlconn.Open();//打开数据库链接

                SqlCommand cmd = sqlconn.CreateCommand();
                cmd.CommandText = "SELECT COUNT(DISTINCT team) AS number FROM knowledge";
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                Int32 numberTeam = reader.GetInt32(reader.GetOrdinal("number"));
                reader.Close();
                number.InnerHtml = "报名记录数: " + numberTeam;

                sa = new SqlDataAdapter("select studentID as 学号, Name as 姓名 , Team as 队伍名 from " + competitionName + " order by Team asc", sqlconn);
                sb = new SqlCommandBuilder(sa);
                dt = new DataTable();
                sa.Fill(dt);
                GridViewMember.DataSource = dt;
                GridViewMember.DataBind();

                switch (competitionName)
                {
                    case "knowledge":
                        head.InnerHtml = "智能车知识竞赛";
                        break;
                    default:
                        head.InnerHtml = "未知的竞赛条目";
                        break;
                }
            }
        }
    }
}