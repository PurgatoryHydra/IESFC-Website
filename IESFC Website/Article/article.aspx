<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="article.aspx.cs" Inherits="IESFC_Website.news.article" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
<link rel="shortcut icon" href="../bitbug_favicon.ico" />

<link rel="stylesheet" type="text/css" href="../syntaxhighlighter/styles/shThemeFadeToGrey.css" />
<script type="text/javascript" src="../syntaxhighlighter/src/shCore.js"></script>
<script type="text/javascript" src="../syntaxhighlighter/scripts/shBrushJScript.js"></script>
<script type="text/javascript" src="../syntaxhighlighter/scripts/shBrushCSharp.js"></script>
<script type="text/javascript" src="../syntaxhighlighter/scripts/shBrushBash.js"></script>
<script type="text/javascript" src="../syntaxhighlighter/scripts/shBrushCpp.js"></script>
<script type="text/javascript" src="../syntaxhighlighter/scripts/shBrushCSharp.js"></script>
<script type="text/javascript" src="../syntaxhighlighter/scripts/shBrushCss.js"></script>
<script type="text/javascript" src="../syntaxhighlighter/scripts/shBrushJava.js"></script>
<script type="text/javascript" src="../syntaxhighlighter/scripts/shBrushPowerShell.js"></script>
<script type="text/javascript" src="../syntaxhighlighter/scripts/shBrushPython.js"></script>
<script type="text/javascript" src="../syntaxhighlighter/scripts/shBrushSql.js"></script>
<script type="text/javascript" src="../syntaxhighlighter/scripts/shBrushVb.js"></script>
<script type="text/javascript" src="../syntaxhighlighter/scripts/shBrushXml.js"></script>
<link rel="stylesheet" href="../syntaxhighlighter/styles/shCoreFadeToGrey.css" />

<script type="text/javascript" async
  src="https://cdnjs.cloudflare.com/ajax/libs/mathjax/2.7.0/MathJax.js?config=TeX-MML-AM_CHTML">
</script>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <%
        Response.Write("<h1 style=text-align:center>" + articleTitle + "</h1>"); %>
    <table>
        <tbody>
            <tr>
            <%  
                Response.Write("<td><p style=text-align:left>创建：" + articleTimeString + "</p></td>");
                Response.Write("<td><p style=text-align:left>最后编辑：" + editedTimeString + "</p></td>");
                Response.Write("<td><p>点击次数：" + visitedTime + "</p></td>");
                if (Session["UserName"] != null)
                {
                    Response.Write("<td><a href=UploadArticle.aspx?&articleID=" + articleID + "&type=edit>编辑</a></td>");
                    Response.Write("<td><a target=_blank href=deleteArticle.aspx?&articleID=" + articleID + "&deleteTarget=article>删除</a></td>");
                }
                %>
            </tr>
        </tbody>
    </table>
    <p id="articleBody" runat="server"></p>
    <p style="text-align:right" id="articleAuthor" runat="server"></p>
    <script type="text/javascript">SyntaxHighlighter.all();</script>
</asp:Content>
