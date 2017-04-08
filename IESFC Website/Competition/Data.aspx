<%@ Page Title="申请成功信息" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Data.aspx.cs" Inherits="IESFC_Website.Data" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
<link rel="shortcut icon" href="../bitbug_favicon.ico" />
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h1 id="head" runat="server">已经录入的成员名单</h1>
    <p id="number" runat="server"></p>
    <asp:GridView ID="GridViewMember" runat="server"></asp:GridView>
</asp:Content>
