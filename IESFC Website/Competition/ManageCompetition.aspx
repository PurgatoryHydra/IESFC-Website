<%@ Page Title="管理中心" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="ManageCompetition.aspx.cs" Inherits="IESFC_Website.Account.ManageCompetition" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
<link rel="shortcut icon" href="../bitbug_favicon.ico" />
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<script type="text/javascript" src="/My97DatePicker/WdatePicker.js"></script>
    <table>
        <tbody>
            <tr>
                <td><p id="instruction" runat="server"></p></td>
            </tr>
            <tr>
                <td><p>开始日期</p></td>
                <td><p>结束日期</p></td>
            </tr>
            <tr>
                <td><input id="dateStart" type="text" runat="server"/>
                    <img onclick="WdatePicker({el:'dateStart'})" src="/My97DatePicker/skin/datePicker.gif" width="16" height="22" alt="图片"/></td>
                <td><input id="dateEnd" type="text" runat="server"/>
                    <img onclick="WdatePicker({el:'dateEnd'})" src="/My97DatePicker/skin/datePicker.gif" width="16" height="22" alt="图片"/></td>
            </tr>
            <tr>
                <td><p>开始时间</p></td>
                <td><p>结束时间</p></td>
            </tr>
            <tr>
                <td><asp:TextBox ID="timeStart" runat="server"></asp:TextBox></td>
                <td><asp:TextBox ID="timeEnd" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td><p>时间形如 XX:XX:XX 或者 XX:XX</p></td>
            </tr>
            <tr>
                <td><asp:Button ID="buttonSubmit" runat="server" Text="提交" 
                        onclick="buttonSubmit_Click" /></td>
            </tr>
        </tbody>
    </table>
</asp:Content>