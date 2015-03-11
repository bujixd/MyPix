<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="photo.aspx.cs" Inherits="photo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" Runat="Server">
    <h2>photo</h2>
    <div style="float:left; margin-right:10px; margin-bottom: 10px;text-align:center">
        <div><asp:Image ID="Image" runat="server" />
        </div>
        <div style="font-size:large">
            title:<asp:Literal ID="title" runat="server"></asp:Literal>
            <asp:Literal ID="Literal1" runat="server" Visible="False"></asp:Literal>
        </div>
    </div>
        <div>
            <asp:Literal ID="content" runat="server"></asp:Literal>
        </div>
    <p>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT Comments.[Tittle ], COUNT(Response.CommentsId) AS Expr1, Comments.CommentsId, Comments.PhotosId FROM Comments LEFT OUTER JOIN Response ON Comments.CommentsId = Response.CommentsId WHERE (Comments.PhotosId = @Id) GROUP BY Comments.[Tittle ], Comments.CommentsId, Comments.PhotosId">
            <SelectParameters>
                <asp:QueryStringParameter DbType="Int32" DefaultValue="<%=Id%>" Name="Id" QueryStringField="Id" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" Width="577px" DataKeyNames="CommentsId" style="margin-right: 0px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <Columns>
                <asp:HyperLinkField DataNavigateUrlFields="CommentsId" DataNavigateUrlFormatString="http://localhost:53206/Comment.aspx?Id={0}" DataTextField="Tittle " HeaderText="Tittle" Target="_blank" >
                <ItemStyle Width="500px" />
                </asp:HyperLinkField>
                <asp:BoundField DataField="Expr1" HeaderText="Response" SortExpression="Expr1" ReadOnly="True" />
            </Columns>
        </asp:GridView>
    </p>
    <div style="text-align:center;clear:left; margin:10px,10px;padding:10px,10px">
        Title: <asp:TextBox ID="ctitle" runat="server" OnTextChanged="ctitle_TextChanged" Width="151px" style="height: 22px"></asp:TextBox>
    </div>
    <div style="text-align:center;padding:10px,10px; margin:10px,10px">
        Comment: <asp:TextBox ID="comment" runat="server" Height="89px" TextMode="MultiLine" Width="418px" style="margin-top: 0px"></asp:TextBox>
    </div>
    <div style="text-align:center">
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Add" />
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click">
            </asp:AsyncPostBackTrigger>
        </Triggers>
    </asp:UpdatePanel>
    <p></p>
</asp:Content>

<asp:Content ID="Content3" runat="server" contentplaceholderid="link">
    <li> <a href="Photos.aspx">photos</a></li>            
    <li> <a href="User.aspx">user</a></li>
    <li> <a href="Upload.aspx">upload</a></li>
    <li> <a href="Tags.aspx">Tag</a></li>
    <li> <a href="Login.aspx">logout</a></li></asp:Content>


