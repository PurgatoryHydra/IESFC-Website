<%@ Page Title="管理新闻" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="ManageArticle.aspx.cs" Inherits="IESFC_Website.news.ManageArticle" %>

<script language="C#" runat="server">
    void msg()
    {
        string script = "<script>alert('aa')</scritp>";
        ClientScript.RegisterStartupScript(this.GetType(), "success", script);
    }
</script>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
<link rel="shortcut icon" href="../bitbug_favicon.ico" />
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h1 id="head" runat="server">
    <%
        if (articleType == "news")
            Response.Write("所有新闻");
        else if (articleType == "notice")
            Response.Write("所有通知");
        else if (articleType == "course")
            Response.Write("所有教学");
        else if (articleType == "course")
            Response.Write("所有作品");
        else if (articleType == "language")
            Response.Write("所有语言笔记");
        else if (articleType == "bayonet")
            Response.Write("所有刺刀STM32文章");
        else if (articleType == "searchResult")
            Response.Write("搜索结果");
            %></h1>
            
<div id="listArticles" runat="server">
</div>
        <table>
            <tbody>
            <tr>
                <td>
                    <table>
                        <tbody>
                            <tr>
                                <%
                                    if (articleType != "searchResult")
                                    {
                                        cmd.CommandText = "SELECT COUNT(id) AS number FROM article WHERE articleType = @type";
                                        cmd.Parameters.Add("@type", System.Data.SqlDbType.NChar).Value = articleType;
                                    }
                                    else
                                        cmd.CommandText = "SELECT COUNT(*) AS number " + searchQuery();
                                    reader = cmd.ExecuteReader();
                                    reader.Read();
                                    Int32 number = reader.GetInt32(reader.GetOrdinal("number"));
                                    int maxPage = number / MAX_INDEX;
                                    for (int i = 0; i <= maxPage; i++)
                                        Response.Write("<td style=padding-left:10px;><u><a href=ManageArticle.aspx?articleType=" + articleType + "&pageCount=" + i + ">" + (i + 1) + "</a></u></td>");
                                    reader.Close();
                                     %>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
            <tr>
                <td><asp:Button ID="Refresh" runat="server" Text="刷新" onclick="Refresh_Click"/></td>
            </tr>
        </tbody>
    </table>
</asp:Content>