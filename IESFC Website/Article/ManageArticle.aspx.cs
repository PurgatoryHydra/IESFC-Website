using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

namespace IESFC_Website.news
{
    public partial class ManageArticle : System.Web.UI.Page
    {
        public const int MAX_INDEX = 20;
        public SqlConnection sqlconn;
        string conn;
        public SqlCommand cmd;
        public SqlDataReader reader;
        public string headContent;
        public string articleType;
        public int pageCount = 0;
        public string[] keyWords;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            articleType = Request.QueryString["articleType"];
            pageCount = int.Parse(Request.QueryString["pageCount"]);
            if (articleType == "searchResult")
            {
                string keyWord = Request.QueryString["keyWord"];
                 keyWords = keyWord.Split(' ');
            }

            conn = "Data Source=127.0.0.1;Initial Catalog=IESFC member database;Integrated Security=false;Pooling=False;uid=duke;password=D6b4cw";
            sqlconn = new SqlConnection(conn);//链接数据库
            sqlconn.Open();

            cmd = sqlconn.CreateCommand();
            refresh();
        }

        protected void Refresh_Click(object sender, EventArgs e)
        {
            refresh();
        }

        public string searchQuery()
        {
            string command;
            if (keyWords.Length == 1)
                command = "FROM article WHERE title like '%" + keyWords[0] + "%'";
            else
            {
                command = "SELECT * FROM article WHERE title like '%" + keyWords[0] + "%'";
                for (int i = 1; i < keyWords.Length; i++)
                {
                    command = "SELECT * FROM (" + command + ") AS anwser" + i + " WHERE title like '%" + keyWords[i] + "%'";
                    if (i == keyWords.Length - 1)
                        command = "FROM (" + command + ") AS anwser" + i + " WHERE title like '%" + keyWords[i] + "%'";
                }
            }
            return command;
        }

        private void refresh()
        {
            if (articleType == "searchResult")
                cmd.CommandText = "SELECT COUNT(*) AS number FROM (SELECT ROW_NUMBER() over (ORDER BY TIME DESC) rn, * " + searchQuery() + ") article WHERE rn BETWEEN " + pageCount * MAX_INDEX + " AND " + ((pageCount + 1) * MAX_INDEX - 1);
            else
                cmd.CommandText = "SELECT COUNT(*) AS number FROM (SELECT ROW_NUMBER() over (ORDER BY TIME DESC) rn, * FROM article WHERE articleType = '" + articleType + "') article WHERE rn BETWEEN " + pageCount * MAX_INDEX + " AND " + ((pageCount + 1) * MAX_INDEX - 1);
            reader = cmd.ExecuteReader();
            reader.Read();
            Int32 number = reader.GetInt32(reader.GetOrdinal("number"));
            reader.Close();
            int max = 0;
            if (number > 0)
                max = (number > MAX_INDEX) ? MAX_INDEX : number;

            if (articleType == "searchResult")
                cmd.CommandText = "SELECT * FROM (SELECT ROW_NUMBER() over (ORDER BY TIME DESC) rn, *" + searchQuery() + ") article WHERE rn BETWEEN " + pageCount * MAX_INDEX + " AND " + ((pageCount + 1) * MAX_INDEX - 1);
            else
                cmd.CommandText = "SELECT * FROM (SELECT ROW_NUMBER() over (ORDER BY TIME DESC) rn, * FROM article WHERE articleType = '" + articleType + "') article WHERE rn BETWEEN " + pageCount * MAX_INDEX + " AND " + ((pageCount + 1) * MAX_INDEX - 1);
            reader = cmd.ExecuteReader();
            string list = "<table><tbody>";
            for (int i = 0; i < max; i++)
            {
                reader.Read();

                Int32 id = reader.GetInt32(reader.GetOrdinal("id"));
                list += "<tr>";
                list += "<td><a href=" + id + ".htm>" + reader.GetString(reader.GetOrdinal("title")) + "</a></td>";
                if (Session["UserName"] != null)
                {
                    list += "<td><a href=UploadArticle.aspx?&articleID=" + id + "&type=edit>编辑</a></td>";
                    list += "<td><a target=_blank href=deleteArticle.aspx?&articleID=" + id + "&deleteTarget=article>删除</a></td>";
                }
                list += "</tr>";
            }
            reader.Close();
            list += "</tbody></table>";
            listArticles.InnerHtml = list;
        }
    }
}