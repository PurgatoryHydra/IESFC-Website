using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace IESFC_Website.news
{
    public partial class article : System.Web.UI.Page
    {
        SqlConnection sqlconn;
        string conn;
        public int articleID;
        public string articleTitle;
        public string articleTimeString;
        public string editedTimeString;
        public int visitedTime;
        protected void Page_Load(object sender, EventArgs e)
        {
            articleID = int.Parse(Request.QueryString["articleID"]);
            conn = "Data Source=127.0.0.1;Initial Catalog=IESFC member database;Integrated Security=false;Pooling=False;uid=duke;password=D6b4cw";
            sqlconn = new SqlConnection(conn);//链接数据库
            sqlconn.Open();

            SqlCommand cmd = sqlconn.CreateCommand();
            cmd.CommandText = "select * from article where id=" + articleID;
            SqlDataReader reader = cmd.ExecuteReader();

            reader.Read();
            articleTitle = reader.GetString(reader.GetOrdinal("title"));
            articleBody.InnerHtml = reader.GetString(reader.GetOrdinal("body"));
            articleAuthor.InnerHtml = "编辑： " + reader.GetString(reader.GetOrdinal("author"));
            DateTime datetime = reader.GetDateTime(reader.GetOrdinal("time"));
            DateTime editedTime = reader.GetDateTime(reader.GetOrdinal("editedTime"));
            articleTimeString = datetime.ToShortDateString() + " " + datetime.ToShortTimeString();
            editedTimeString = editedTime.ToShortDateString() + " " + editedTime.ToShortTimeString();
            string articleType = reader.GetString(reader.GetOrdinal("articleType"));
            visitedTime = reader.GetInt32(reader.GetOrdinal("visitedTime"));
            reader.Close();

            visitedTime++;
            cmd.CommandText = "UPDATE article SET visitedTime = " + visitedTime + " WHERE id = " + articleID;
            cmd.ExecuteNonQuery();
            this.Title = articleTitle;
            reader.Close();
        }
    }
}