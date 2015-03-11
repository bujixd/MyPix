<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Upload.aspx.cs" Inherits="Upload" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" Runat="Server">
    <h2>Upload</h2>
    <p>
    
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="上传" /><br />
        <asp:Label ID="Label1" runat="server"></asp:Label>
    </p>
    <p>
    
        <asp:Image ID="Image" runat="server" />
    </p>
</asp:Content>

<asp:Content ID="Content3" runat="server" contentplaceholderid="link">
                <li> <a href="Photos.aspx">photos</a></li>            
    <li> <a href="User.aspx">user</a></li>
    <li> <a href="Tags.aspx">Tag</a></li>
    <li> <a href="Login.aspx">logout</a></li></asp:Content>


