<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="User.aspx.cs" Inherits="User" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" Runat="Server">
    <h2>User</h2>
    <p>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [full_name], [user_name], [WhenRegistered], [WhenConfirmed] FROM [Posters]"></asp:SqlDataSource>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" AllowPaging="True" AllowSorting="True">
            <Columns>
                <asp:BoundField DataField="full_name" HeaderText="full_name" SortExpression="full_name" />
                <asp:BoundField DataField="user_name" HeaderText="user_name" SortExpression="user_name" />
                <asp:BoundField DataField="WhenRegistered" HeaderText="WhenRegistered" SortExpression="WhenRegistered" />
                <asp:BoundField DataField="WhenConfirmed" HeaderText="WhenConfirmed" SortExpression="WhenConfirmed" />
            </Columns>
        </asp:GridView>
    </p>
</asp:Content>

<asp:Content ID="Content3" runat="server" contentplaceholderid="link">
                <li> <a href="Photos.aspx">photos</a></li>            
    <li> <a href="Upload.aspx">upload</a></li>
    <li> <a href="Tags.aspx">Tag</a></li>
    <li> <a href="Login.aspx">logout</a></li></asp:Content>


