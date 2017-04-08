using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using IESFC_Website.Geetest;
using GeetestSDK;

namespace IESFC_Website
{
    public partial class Apply : System.Web.UI.Page
    {
        SqlConnection sqlconn;
        string conn;
        SqlDataAdapter sa;
        SqlCommandBuilder sb;
        DataTable dt;
        byte[] verificationNumber = new byte[3];
        string competitionName;
        string[] instituteName = { "机电与信息工程学院", "数学与统计学院", "空间科学与物理学院", "韩国学院", "商学院", "法学院", "文化传播学院", "翻译学院", "艺术学院", "海洋学院" };
        string[] majorIE = { "电子信息科学与技术", "通信工程", "计算机科学与技术", "软件工程", "数字媒体技术", "自动化", "测控技术与仪器", "机械设计制造及其自动化", "机械设计制造及其自动化（中澳合办）" };

        protected void Page_Load(object sender, EventArgs e)
        {
            competitionName = Request.QueryString["competitionName"];
            conn = "Data Source=127.0.0.1;Initial Catalog=IESFC member database;Integrated Security=false;Pooling=False;uid=duke;password=D6b4cw";
            sqlconn = new SqlConnection(conn);//链接数据库

            sqlconn.Open();//打开数据库链接

            sa = new SqlDataAdapter("select studentID as 学号, Name as 姓名 from " + competitionName, sqlconn);
            sb = new SqlCommandBuilder(sa);
            dt = new DataTable();
            sa.Fill(dt);

            for (int i = 0; i < instituteName.Length; i++)
                ListInstitute.Items.Add(new ListItem(instituteName[i]));
            for (int i = 0; i < majorIE.Length; i++)
                ListMajor.Items.Add(new ListItem(majorIE[i]));
            for (int i = 1; i < 4; i++)
                ListClass.Items.Add(new ListItem(i + ""));

            ApplyList.Attributes["href"] = "Data.aspx?competitionName=" + competitionName;
            switch (competitionName)
            {
                case "knowledge":
                    headCompetitionName.InnerHtml = "智能车知识竞赛";
                    break;
                default:
                    headCompetitionName.InnerHtml = "未知的竞赛条目";
                    break;
            }
        }

        /*private String getCaptcha()
        {
            GeetestLib geetest = new GeetestLib(ID, Key);
            Byte gtServerStatus = geetest.preProcess();
            Session[GeetestLib.gtServerStatusSessionKey] = gtServerStatus;
            return geetest.getResponseStr();
        }*/
        protected void ButtonApply_Click(object sender, EventArgs e)
        {

            GeetestLib geetest = new GeetestLib(GeetestConfig.publicKey, GeetestConfig.privateKey);
            Byte gt_server_status_code = (Byte)Session[GeetestLib.gtServerStatusSessionKey];
            String userID = (String)Session["userID"];
            int result = 0;
            String challenge = Request.Form.Get(GeetestLib.fnGeetestChallenge);
            String validate = Request.Form.Get(GeetestLib.fnGeetestValidate);
            String seccode = Request.Form.Get(GeetestLib.fnGeetestSeccode);
            if (gt_server_status_code == 1) result = geetest.enhencedValidateRequest(challenge, validate, seccode, userID);
            else result = geetest.failbackValidateRequest(challenge, validate, seccode);
            //if (result == 1) Response.Write("success");
            //else Response.Write("fail");
            if (result == 1)
            {
                if (checkIfEmpty() == 0)
                {
                    string sql = "insert " + competitionName + "(StudentID, Name, Institute, Major, Class, Tel, Team) values(@studentID, @name, @institute, @major, @class, @tel, @team)";
                    SqlCommand sqlcomm = new SqlCommand(sql, sqlconn);
                    sqlcomm.Parameters.Add("@studentID", SqlDbType.Int).Value = TextBoxStudentID.Text;
                    sqlcomm.Parameters.Add("@name", SqlDbType.NChar).Value = TextBoxName.Text;
                    sqlcomm.Parameters.Add("@institute", SqlDbType.NChar).Value = ListInstitute.SelectedItem.Text;
                    sqlcomm.Parameters.Add("@major", SqlDbType.NChar).Value = ListMajor.SelectedItem.Text;
                    sqlcomm.Parameters.Add("@class", SqlDbType.Int).Value = ListClass.SelectedItem.Text;
                    sqlcomm.Parameters.Add("@tel", SqlDbType.Float).Value = TextBoxTel.Text;
                    sqlcomm.Parameters.Add("@team", SqlDbType.NChar).Value = TextBoxTeam.Text;

                    int sqlResult = sqlcomm.ExecuteNonQuery();//返回受影响的行数

                    if (sqlResult > 0)
                        Response.Write("<script>alert('报名成功！');</script>");
                    else
                        Response.Write("<script>alert('报名失败！');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('验证成功')</script>");
            }
        }

        protected void TextBoxStudentID_TextChanged(object sender, EventArgs e)
        {
            Response.Write("<script>alert('测试');</script>");
        }

        protected void ListInstitute_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < majorIE.Length; i++)
                ListInstitute.Items.Add(new ListItem(majorIE[i]));
        }
        protected int checkIfEmpty()
        {
            int flagFailed = 0;
            if (TextBoxStudentID.Text == "")
            {
                LabelValStudentID.Text = "学号不能为空";
                flagFailed = 1;
            }
            else
                LabelValStudentID.Text = "*";
            if (TextBoxName.Text == "")
            {
                LabelValName.Text = "姓名不能为空";
                flagFailed = 1;
            }
            else
                LabelValName.Text = "*";
            if (TextBoxTel.Text == "")
            {
                LabelValTel.Text = "手机不能为空";
                flagFailed = 1;
            }
            else
                LabelValTel.Text = "*";
            if (TextBoxTeam.Text == "")
            {
                LabelValTeam.Text = "队伍名称不能为空";
                flagFailed = 1;
            }
            else
                LabelValTeam.Text = "*";
            return flagFailed;
        }
    }
}