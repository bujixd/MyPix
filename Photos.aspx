<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Photos.aspx.cs" Inherits="Photos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" Runat="Server">
    <h2>Photos</h2>
    <p>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT Photos.photo, Photos.title, Tags.Tags, Posters.user_name, Photos.PhotosId FROM Posters INNER JOIN Photos ON Posters.PosterId = Photos.PostersId LEFT OUTER JOIN Tags INNER JOIN TagRelations ON Tags.TagsId = TagRelations.TagId ON Photos.PhotosId = TagRelations.PhotosId"></asp:SqlDataSource>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AllowPaging="True" AllowSorting="True" DataKeyNames="PhotosId">
            <Columns>
                <asp:TemplateField HeaderText="photo" SortExpression="photo">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("photo") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("photo") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Tags" HeaderText="Tags" SortExpression="Tags" />
                <asp:BoundField DataField="user_name" HeaderText="user_name" SortExpression="user_name" />
                <asp:HyperLinkField DataNavigateUrlFields="PhotosId" DataNavigateUrlFormatString="http://localhost:53206/photo.aspx?Id={0}" DataTextField="title" HeaderText="title" Target="_self" />
            </Columns>
        </asp:GridView>
    </p>
</asp:Content>

<asp:Content ID="Content3" runat="server" contentplaceholderid="link">
    <li> <a href="User.aspx">user</a></li>
    <li> <a href="Upload.aspx">upload</a></li>
    <li> <a href="Tags.aspx">Tag</a></li>
    <li> <a href="Login.aspx">logout</a></li>
    
</asp:Content>


