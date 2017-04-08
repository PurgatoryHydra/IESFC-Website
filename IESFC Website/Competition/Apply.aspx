<%@ Page Title="活动申请" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Apply.aspx.cs" Inherits="IESFC_Website.Apply" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
<link rel="shortcut icon" href="../bitbug_favicon.ico" />
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<script type="text/javascript" src="http://code.jquery.com/jquery-1.12.3.min.js"></script>

    <h1 class="body_head">
    当前开放申请的竞赛或活动</h1>
<h3 id=headCompetitionName runat="server"></h3>
   <table class="detail">
        <tbody>
            <tr>
                <td><label>学号</label></td>
                <td><asp:TextBox ID="TextBoxStudentID" runat="server" MaxLength="12" 
                        ontextchanged="TextBoxStudentID_TextChanged"></asp:TextBox></td>
                <td><asp:Label ID="LabelValStudentID" runat="server" CssClass="Validation" Text="*"></asp:Label></td>
            </tr>
            <tr>
                <td><label>姓名</label></td>
                <td><asp:TextBox ID="TextBoxName" runat="server" MaxLength="4"></asp:TextBox></td>
                <td><asp:Label ID="LabelValName" runat="server" CssClass="Validation" Text="*"></asp:Label></td>
            </tr>
            <tr>
                <td><label>学院</label></td>
                <td><asp:DropDownList ID="ListInstitute" runat="server" 
                        onselectedindexchanged="ListInstitute_SelectedIndexChanged"></asp:DropDownList></td>
                <td><asp:Label ID="LabelValInstitute" runat="server" CssClass="Validation"></asp:Label></td>
            </tr>
            <tr>
                <td><label>专业</label></td>
                <td><asp:DropDownList ID="ListMajor" runat="server"></asp:DropDownList></td>
                <td><asp:Label ID="LabelValMajor" runat="server" CssClass="Validation"></asp:Label></td>
            </tr>
            <tr>
                <td><label>班级</label></td>
                <td><asp:DropDownList ID="ListClass" runat="server"></asp:DropDownList></td>
                <td><asp:Label ID="LabelValClass" runat="server" CssClass="Validation"></asp:Label></td>
            </tr>
            <tr>
                <td><label>手机</label></td>
                <td><asp:TextBox ID="TextBoxTel" runat="server" MaxLength="11"></asp:TextBox></td>
                <td><asp:Label ID="LabelValTel" runat="server" CssClass="Validation" Text="*"></asp:Label></td>
            </tr>
            <tr>
                <td><label>队伍名称</label></td>
                <td><asp:TextBox ID="TextBoxTeam" runat="server" MaxLength="20"></asp:TextBox></td>
                <td><asp:Label ID="LabelValTeam" runat="server" CssClass="Validation" Text="*"></asp:Label></td>
            </tr>
            <tr>
                <td><asp:Button ID="ButtonApply" runat="server" Text="提交" 
                        onclick="ButtonApply_Click"></asp:Button></td>
            </tr>
            <tr>
                <td><a id="ApplyList" href="Data.aspx" target="_blank" runat="server">查看申请成功的名单</a></td>
            </tr>
        </tbody>
   </table>
</asp:Content>