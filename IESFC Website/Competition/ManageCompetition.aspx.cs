using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace IESFC_Website.Account
{
    public partial class ManageCompetition : System.Web.UI.Page
    {
        SqlConnection sqlconn;
        string conn;
        string competitionName;
        protected void Page_Load(object sender, EventArgs e)
        {
            competitionName = Request.QueryString["competitionName"];
            conn = "Data Source=127.0.0.1;Initial Catalog=IESFC member database;Integrated Security=false;Pooling=False;uid=duke;password=D6b4cw";
            sqlconn = new SqlConnection(conn);//链接数据库
            sqlconn.Open();

            string sql = "SELECT * FROM competition WHERE Name = " + competitionName;
            SqlCommand cmd = new SqlCommand(sql, sqlconn);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            DateTime startDateTime = reader.GetDateTime(reader.GetOrdinal("startTime"));
            DateTime endDateTime = reader.GetDateTime(reader.GetOrdinal("endTime"));
            reader.Close();
            instruction.InnerHtml = "开始" + startDateTime.ToShortDateString() + " " + startDateTime.ToShortTimeString() + "结束" + endDateTime.ToShortDateString() + endDateTime.ToShortTimeString();
            
        }

        protected void buttonSubmit_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "UPDATE competition SET startTime = " + dateStart.Value + " " + timeStart.Text + ", endTime = " + dateEnd.Value + " " + timeEnd.Text;
            int result = cmd.ExecuteNonQuery();
            
            if (result > 0)
            {
                Response.Write("<script>alert('修改成功！');</script>");
            }
            else
            {
                Response.Write("<script>alert('修改失败！');</script>");
            }
        }
    }
}