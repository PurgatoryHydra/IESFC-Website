<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="default.aspx.cs" Inherits="IESFC_Website._Default" %>
    
<%@import Namespace="System.Data" %>
<%@import Namespace="System.Data.SqlClient" %>
<script language="C#" runat="server">
    void addlist(string listName, string name)
    {
        const int MAX_INDEX = 8;
        SqlCommand cmd = sqlconn.CreateCommand();
        int number = getNumber(listName);
        int max = 0;
        if (number > 0)
            max = (number < MAX_INDEX) ? number : MAX_INDEX;
        cmd.CommandText = "SELECT * FROM article WHERE articleType = @type ORDER BY time DESC";
        cmd.Parameters.Add("@type", SqlDbType.NChar, 10).Value = listName;
        reader = cmd.ExecuteReader();
        
        Response.Write("<td class=news>");
            Response.Write("<fieldset>");
                Response.Write("<legend>" + name + "</legend>");
                    Response.Write("<div class=vm>");
                        Response.Write("<ul>");
        for (int i = 0; i < max; i++)
        {
            reader.Read();
            string id = reader.GetInt32(reader.GetOrdinal("id")).ToString();
            string articleAbstract = reader.GetString(reader.GetOrdinal("abstract"));
            string title = reader.GetString(reader.GetOrdinal("title"));
            Response.Write("<li><a title=" + title + " href=Article/" + id + ".htm>" + articleAbstract + "</a></li>");
        }
        Response.Write("<li style=text-align:right; vertical-align:bottom;><a href=Article/ManageArticle.aspx?articleType=" + listName + "&pageCount=0>更多</a></li>");
        reader.Close();
                    Response.Write("</ul>");
                Response.Write("</div>");
            Response.Write("</fieldset>");
        Response.Write("</td>");
    }
</script>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
<link rel="shortcut icon" href="bitbug_favicon.ico" />
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<link rel="stylesheet" href="/luara/css/style.css"/>
<link rel="stylesheet" href="/luara/css/luara.css"/>
<script type="text/javascript" src="luara/js/jquery-1.8.3.min.js"></script>
<script type="text/javascript" src="luara/js/jquery.luara.0.0.1.min.js"></script>
<script type="text/javascript">
    $(function () {
        $(".example").luara({ width: "300", height: "180", interval: 4000, selected: "seleted" });
    });
</script>
<table>
    <tbody>
        <tr>
            <td class="Bar" style="vertical-align:top">
                <div class="vm">
                    <p>竞赛报名</p>
                    <ul>
                        <li><a href="Competition/Apply.aspx?competitionName=knowledge" target="_blank">智能车知识竞赛</a></li>
                        <li><a href="Competition/Apply.aspx?competitionName=SDUHITDomestic" target="_blank">山哈联赛校内赛</a></li>
                        <li><a href="Competition/Apply.aspx?competitionName=SDUHITInterSchool" target="_blank">山哈联赛校际赛</a></li>
                    </ul>
                    <p>竞赛介绍</p>
                    <ul>
                        <li><a href="Competition/About.aspx?competitionName=knowledge">智能车知识竞赛</a></li>
                        <li><a href="Competition/About.aspx?competitionName=SDUHITDomestic">山哈联赛校内赛</a></li>
                        <li><a href="Competition/About.aspx?competitionName=SDUHITInterSchool">山哈联赛校际赛</a></li>
                    </ul>
                    <p>竞赛部门</p>
                    <ul>
                        <li><a href="http://www.sduwh646.cn/" target="_blank">智能车竞赛部</a></li>
                        <li><a>电赛竞赛部</a></li>
                    </ul>
                    <p>资料下载</p>
                    <ul>
                        <li><a href="http://www.sduwh646.cn/" target="_blank">资料简介</a></li>
                        <li><a href="Softwares.aspx">常用软件</a></li>
                    </ul>
                </div>
            </td>
            <td>
                <table>
                    <tbody>
                        <tr>
                            <%
                                addlist("news", "协会新闻");
                                addlist("notice", "协会通知");
                                %>
                        </tr>
                        <tr>
                            <%
                                addlist("course", "教学资料");
                                addlist("work", "作品展示");
                                %>
                        </tr>
                        <tr>
                            <%
                                addlist("language", "程序语言");
                                addlist("bayonet", "Bayonet STM32");
                                 %>
                        </tr>
                        <tr>
                            <%
                                addlist("saber", "Saber STM32");
                                addlist("book", "书籍");
                                 %>
                        </tr>
                        <tr>
                            <td class="news">
                                <fieldset>
                                    <legend>近期照片</legend>
                                    <div class="example">
                                        <ul>
                                            <li><img src="luara/images/1.jpg" alt="1"/></li>
                                            <li><img src="luara/images/2.jpg" alt="2"/></li>
                                            <li><img src="luara/images/3.jpg" alt="3"/></li>
                                            <li><img src="luara/images/4.jpg" alt="4"/></li>
                                        </ul>
                                        <ol>
                                            <li></li>
                                            <li></li>
                                            <li></li>
                                            <li></li>
                                        </ol>
                                    </div>
                                </fieldset>
                            </td>
                            <td class="news">
                                <fieldset>
                                    <legend>宣传视频</legend>
                                        <iframe height=180 width=300 style="padding-left:0px;padding-top:0px;" src='http://player.youku.com/embed/XMTc4NDM5MTI4NA==' frameborder=0 'allowfullscreen'></iframe>
                                </fieldset>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </td>
        </tr>
    </tbody>
</table>
</asp:Content>
