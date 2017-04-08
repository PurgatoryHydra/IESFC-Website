<%@ Page Title="文章上传" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="uploadArticle.aspx.cs" Inherits="IESFC_Website.news.uploadArticle" ValidateRequest="false"%>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
<link rel="shortcut icon" href="../bitbug_favicon.ico" />
<script type="text/javascript" src="../ckeditor/ckeditor.js"></script>
<script type="text/javascript" async
  src="https://cdnjs.cloudflare.com/ajax/libs/mathjax/2.7.0/MathJax.js?config=TeX-MML-AM_CHTML">
</script>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="upld">
    <h1 id="head" runat="server">文章上传</h1>
    <table>
        <tbody>
            <tr>
                <td><p class="upld">文章标题</p></td>
                <td><asp:TextBox id="textTitle" runat="server" Width="500px" MaxLength="40"></asp:TextBox></td>
            </tr>
            <tr>
                <td>文章类别</td>
                <td><asp:DropDownList ID="listArticleType" runat="server"></asp:DropDownList></td>
            </tr>
            <tr>
                <td><label>编辑</label></td>
                <td><asp:TextBox ID="textAuthor" runat="server" Width="200px" MaxLength="15"></asp:TextBox></td>
            </tr>
        </tbody>
    </table>
    <asp:TextBox id="textBody" runat="server" TextMode="MultiLine" class="ckeditor" Height="500px" MaxLength="3500"></asp:TextBox>
    <script type="text/javascript">CKEDITOR.replace('textBody');</script>
    <table>
        <tbody>
            <tr>
                <td><p>先点击browse选中图片后点击上传图片，复制最下方生成的图片地址，点击编辑器的图片按钮，复制地址到里面，就可以插入图片了</p></td>
                <td><asp:label ID="labelRef" runat="server"></asp:label></td>
            </tr>
            <tr>
                <td><asp:FileUpload id="fileImage" runat="server"/></td>
                <td><asp:Button id="buttonImageUpload" Text="图片上传" runat="server" 
                        onclick="buttonImageUpload_Click" /></td>
            </tr>
        </tbody>
    </table>
</div>
<div>
    <table>
        <tbody>
            <tr><td><asp:Button ID="buttonUpload" Text="文章上传" runat="server" onclick="buttonUpload_Click"></asp:Button></td></tr>
            <tr><td><asp:Button ID="buttonRefresh" Text="图片刷新" runat="server" 
                    onclick="buttonRefresh_Click"></asp:Button></td></tr>
        </tbody>
    </table>
</div>
<div id="listImages" runat="server"></div>
</asp:Content>
