using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Drawing;

namespace IESFC_Website.news
{
    public partial class uploadArticle : System.Web.UI.Page
    {
        public const int MAX_INDEX_IMAGES = 20;
        public const int MAX_WIDTH_TITLE = 340;
        SqlConnection sqlconn;
        string conn;
        string articleType;
        string type;
        string articleID;
        public int id;
        int countImages = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["UserName"] == null)
            {
                Response.Write("<script>alert('您无权限进行此操作');</script>");
                Server.Transfer("~/Default.aspx");
            }
            else
            {
                conn = "Data Source=127.0.0.1;Initial Catalog=IESFC member database;Integrated Security=false;Pooling=False;uid=duke;password=D6b4cw";
                sqlconn = new SqlConnection(conn);
                sqlconn.Open();
                type = Request.QueryString["type"];

                listArticleType.Items.Add(new ListItem("新闻", "news"));
                listArticleType.Items.Add(new ListItem("通知", "notice"));
                listArticleType.Items.Add(new ListItem("教学", "course"));
                listArticleType.Items.Add(new ListItem("作品", "work"));
                listArticleType.Items.Add(new ListItem("语言", "language"));
                listArticleType.Items.Add(new ListItem("刺刀", "bayonet"));
                listArticleType.Items.Add(new ListItem("军刀", "saber"));
                listArticleType.Items.Add(new ListItem("书籍", "book"));
                if (type == "edit")
                {
                    articleID = Request.QueryString["articleID"];
                    if (IsPostBack == false)
                    {
                        SqlCommand cmd = sqlconn.CreateCommand();
                        cmd.CommandText = "SELECT * FROM article WHERE id = @id";
                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = articleID;
                        SqlDataReader reader = cmd.ExecuteReader();
                        reader.Read();
                        textTitle.Text = (reader.GetString(reader.GetOrdinal("title"))).TrimEnd();
                        textBody.Text = (reader.GetString(reader.GetOrdinal("body"))).TrimEnd();
                        textAuthor.Text = (reader.GetString(reader.GetOrdinal("author"))).TrimEnd();
                        articleType = reader.GetString(reader.GetOrdinal("articleType"));
                        reader.Close();
                        
                        for (int i = 0; i < listArticleType.Items.Count; i++)
                        {
                            if (listArticleType.Items[i].Value.Equals(articleType.TrimEnd()))
                            {
                                ListItem temp = listArticleType.Items[i];
                                listArticleType.Items.Remove(temp);
                                listArticleType.Items.Insert(0, temp);
                            }
                        }
                    }
                    id = int.Parse(articleID);
                }
                else
                {
                    id = getNewId();
                }
                imageRefresh();
            }
        }

        protected void buttonUpload_Click(object sender, EventArgs e)
        {
            int flagFailed = 0;
            if (textTitle.Text == "")
            {
                flagFailed = 1;
                Response.Write("<script>alert('标题不能为空！');</script>");
            }
            if (textBody.Text == "")
            {
                flagFailed = 1;
                Response.Write("<script>alert('文章不能为空！');</script>");
            }
            if (textAuthor.Text == "")
            {
                flagFailed = 1;
                Response.Write("<script>alert('作者不能为空！');</script>");
            }

            if (flagFailed == 0)
            {
                string time;
                SqlCommand sqlcomm = sqlconn.CreateCommand();
                time = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
                if (type == "edit")
                {
                    sqlcomm.CommandText = "UPDATE article SET title = @title, articleType = @articleType, abstract = @abstract, body = @body, author = @author, editedTime = @time WHERE id = @id";
                    sqlcomm.Parameters.Add("@id", SqlDbType.Int).Value = articleID;
                }
                else
                {
                    sqlcomm.CommandText = "insert article(id, articleType, title, abstract, body, author, time, visitedTime, editedTime) values(@id, @articleType, @title, @abstract, @body, @author, @time, '0', @time)";
                    sqlcomm.Parameters.Add("@id", SqlDbType.Int).Value = id;
                }
                sqlcomm.Parameters.Add("@articleType", SqlDbType.NChar).Value = listArticleType.SelectedItem.Value;
                sqlcomm.Parameters.Add("@author", SqlDbType.NChar).Value = textAuthor.Text;
                sqlcomm.Parameters.Add("@title", SqlDbType.NChar).Value = textTitle.Text;
                sqlcomm.Parameters.Add("@body", SqlDbType.NChar).Value = textBody.Text;
                sqlcomm.Parameters.Add("@abstract", SqlDbType.NChar).Value = getSubString(textTitle.Text);
                sqlcomm.Parameters.Add("@time", SqlDbType.DateTime).Value = time;

                int result = sqlcomm.ExecuteNonQuery();

                if (result > 0)
                {
                    Response.Write("<script>alert('添加成功！');</script>");
                    Response.Redirect("/Default.aspx");
                }
                else
                {
                    Response.Write("<script>alert('添加失败！');</script>");
                }
            }
        }

        protected void buttonImageUpload_Click(object sender, EventArgs e)
        {
            int count = 1;
            if (fileImage.HasFile)
            {
                while (File.Exists(Server.MapPath("UploadFiles/Images/" + id + "/" + count + ".jpg")))
                    count++;
                fileImage.SaveAs(Server.MapPath("UploadFiles/Images/" + id + "/" + count + ".jpg"));
                imageRefresh();
            }
            else
            {
                Response.Write("<script>alert('无图片！');</script>");
            }
        }

        private String getSubString(String title)
        {
            bool flag = false;
            System.Drawing.Image img = System.Drawing.Image.FromFile(Server.MapPath("~/shit/1.gif"));
            Graphics graphics = Graphics.FromImage(img);
            Font font = new Font("微软雅黑", 12);
            int length = title.Length;
            while (graphics.MeasureString(title.Substring(0, length), font).Width > MAX_WIDTH_TITLE)
            {
                length--;
                flag = true;
            }
            if(flag)
                return title.Substring(0, length) + "...";
            else
                return title;
        }

        private int getNewId()
        {
            int id = 1;
            int flag;
            SqlCommand cmd = sqlconn.CreateCommand();
            do
            {
                cmd.CommandText = "SELECT id FROM article WHERE id = " + id;
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                try
                {
                    reader.GetInt32(reader.GetOrdinal("id"));
                    id++;
                    flag = 0;
                }
                catch
                {
                    flag = 1;
                }
                reader.Close();
            } while (flag == 0);
            return id;
        }

        private void imageRefresh()
        {
            string strImages = "<table><tbody>";
            countImages = 1;
            List<string> list = Directory.EnumerateFiles(Server.MapPath("UploadFiles/Images/" + id +"/")).ToList();
            list.Sort(new ImageComparer());
            IEnumerator<string> listFile = list.GetEnumerator();
            listFile.MoveNext();
            while (listFile.Current != null)
            {
                string fileName = Path.GetFileName(listFile.Current);
                strImages += "<tr>";
                strImages += "<td><img src=" + "/Article/UploadFiles/Images/" + id + "/" + fileName + " height=100px width=100px alt= /></td>";
                strImages += "<td><a>" + "http://iesfc.top/Article/UploadFiles/Images/" + id + "/" + fileName + "</a></td>";
                //strImages += "<td><a>" + listFile.Current.ToString() + "</a></td>";
                strImages += "<td><a href=deleteArticle.aspx?&articleID=" + id + "&imageName=" + fileName + "&deleteTarget=image target=_blank>删除</a></td>";
                countImages++;
                listFile.MoveNext();
                strImages += "</tr>";
            }
            strImages += "</tbody></table>";
            listImages.InnerHtml = strImages;
            
        }

        protected void buttonRefresh_Click(object sender, EventArgs e)
        {
            imageRefresh();
        }
    }
}