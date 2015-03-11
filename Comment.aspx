<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Comment.aspx.cs" Inherits="Comment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" Runat="Server">
    <p style="text-align:center;font-size:larger">
        <asp:Literal ID="title" runat="server" ></asp:Literal>
    </p>
    <p style="text-align:center">
        <asp:Literal ID="comments" runat="server"></asp:Literal>
        <asp:Literal ID="Literal1" runat="server" Visible="False"></asp:Literal>
    </p>
    <p>&nbsp;</p>
    <asp:Panel ID="Panel1" runat="server" Width="578px" HorizontalAlign="Center">
        <br />
        <br />
    </asp:Panel>
    <p style="text-align:center">
        <asp:TextBox ID="TextBox1" runat="server" Height="73px" TextMode="MultiLine" Width="478px"></asp:TextBox>
    </p>
    <p style="text-align:center">
        <asp:Button ID="add" runat="server" OnClick="add_Click" Text="add" />
    </p>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="add" EventName="Click">
            </asp:AsyncPostBackTrigger>
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>

<asp:Content ID="Content3" runat="server" contentplaceholderid="link">
                <li> <a href="Photos.aspx">photos</a></li>            
    <li> <a href="User.aspx">user</a></li>
    <li> <a href="Upload.aspx">upload</a></li>
    <li> <a href="Tags.aspx">Tag</a></li>
    <li> <a href="Login.aspx">logout</a></li>
</asp:Content>


