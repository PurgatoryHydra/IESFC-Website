<%@ Page Title="管理中心" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Main.aspx.cs" Inherits="IESFC_Website.Account.Main" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
<link rel="shortcut icon" href="../bitbug_favicon.ico" />
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h1 id="head" runat="server">管理中心</h1><table>
        <tbody>
            <tr>
                <td class="Bar">
                    <div class="vm">
                        <p>上传文章</p>
                        <ul>
                            <li><a href="/Article/uploadArticle.aspx?type=upload">上传文章</a></li>
                        </ul>
                        <p>管理文章</p>
                        <ul>
                            <li><a href="/Article/manageArticle.aspx?articleType=news&pageCount=0">管理新闻</a></li>
                            <li><a href="/Article/manageArticle.aspx?articleType=notice&pageCount=0">管理通知</a></li>
                            <li><a href="/Article/manageArticle.aspx?articleType=course&pageCount=0">管理教学</a></li>
                            <li><a href="/Article/manageArticle.aspx?articleType=work&pageCount=0">管理作品</a></li>
                            <li><a href="/Article/manageArticle.aspx?articleType=language&pageCount=0">管理语言</a></li>
                            <li><a href="/Article/manageArticle.aspx?articleType=bayonet&pageCount=0">管理刺刀</a></li>
                            <li><a href="/Article/manageArticle.aspx?articleType=saber&pageCount=0">管理军刀</a></li>
                            <li><a href="/Article/manageArticle.aspx?articleType=book&pageCount=0">管理书籍</a></li>
                        </ul>
                        <p>竞赛管理</p>
                        <ul>
                            <li><a href="/Competition/ManageCompetition.aspx?competitionName=knowledge">知识竞赛</a></li>
                            <li><a href="/Competition/ManageCompetition.aspx?competitionName=SDUHITInterSchool">山哈联赛</a></li>
                            <li><a href="/Competition/ManageCompetition.aspx?competitionName=electronics">电子竞赛</a></li>
                        </ul>
                    </div>
                </td>
                <td style="vertical-align:top">
                    <div>
                        <ul>
                            <li><asp:Button ID="test1" runat="server" Text="测试按钮1" onclick="test1_Click"/></li>
                            <li><asp:Button ID="test2" runat="server" Text="测试按钮2"/></li>
                            <li><asp:Button ID="test3" runat="server" Text="测试按钮3"/></li>
                            <li><p>快速部署测试文本</p></li>
                            <li><p>快速部署测试本文2</p></li>
                        </ul>
                    </div>
                </td>
            </tr>
        </tbody>
    </table>
</asp:Content>
