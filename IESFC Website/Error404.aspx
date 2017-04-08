<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Error404.aspx.cs" Inherits="IESFC_Website.Error404" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
<link rel="shortcut icon" href="bitbug_favicon.ico" />
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <%
        string path = Request.QueryString["aspxerrorpath"];
        Response.Write("<p>对不起，您索引的页面\"http://www.iesfc.top" + path + "\"未找到或参数不完整。</p>");
         %>
    <p style="font-size:400px; text-align:center;">404</p>
</asp:Content>
