<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" Runat="Server">
     <h2>&nbsp;login</h2>
<p>User Name:
    <asp:TextBox ID="Userid" runat="server" Width="222px"></asp:TextBox>
    </p>
    <p>password:<asp:TextBox ID="password" runat="server" TextMode="Password" 
            Width="202px"></asp:TextBox>
    </p>
    <p>
        remember me <asp:CheckBox ID="RememberMe" runat="server" />
    </p>
    <p style="text-align: center">
        <asp:Button ID="loginButton" runat="server" onclick="Button1_Click" 
            Text="login" style="height: 26px"/>
    </p>
    <p>
        <asp:Label ID="Warning" runat="server"></asp:Label>
    </p>
</asp:Content>

<asp:Content ID="Content3" runat="server" contentplaceholderid="link">
    <asp:HyperLink ID="register" runat="server" NavigateUrl="~/Register.aspx">I am new</asp:HyperLink>
</asp:Content>


