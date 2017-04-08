using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace IESFC_Website
{
    public partial class _Default : System.Web.UI.Page
    {
        public SqlConnection sqlconn;
        public SqlCommand cmd;
        public SqlDataReader reader;
        string conn;
        public string Name = "报名";
        protected void Page_Load(object sender, EventArgs e)
        {
            conn = "Data Source=127.0.0.1;Initial Catalog=IESFC member database;Integrated Security=false;Pooling=False;uid=duke;password=D6b4cw";
            sqlconn = new SqlConnection(conn);
            sqlconn.Open();
        }

        public int getNumber(string module)
        {
            cmd = sqlconn.CreateCommand();
            cmd.CommandText = "SELECT COUNT(id) AS number FROM article WHERE articleType = @type";
            cmd.Parameters.Add("@type", SqlDbType.NChar, 10).Value = module;
            reader = cmd.ExecuteReader();
            reader.Read();
            Int32 number = reader.GetInt32(reader.GetOrdinal("number"));
            reader.Close();

            return number;
        }

        public void message(string msg)
        {
            Response.Write("<script>alert('" + msg + "');</script>");
        }

        protected void buttonSearch_Click(object sender, EventArgs e)
        {
            cmd = sqlconn.CreateCommand();
            cmd.CommandText = "SELECT * FROM article WHERE title = @title";
            //cmd.Parameters.Add("@title", SqlDbType.NChar).Value = textBoxSearch.Text;
            reader = cmd.ExecuteReader();
            reader.Read();
            Int32 number = reader.GetInt32(reader.GetOrdinal("number"));
            reader.Close();
        }
    }
}
