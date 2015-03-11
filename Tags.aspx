<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Tags.aspx.cs" Inherits="Tags" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" Runat="Server">
    <h2>Tags</h2>
    <div class="tag" style="float:left"> <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [Tags], [TagsId] FROM [Tags]"></asp:SqlDataSource>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" DataKeyNames="TagsId" SelectedIndex="0" AllowPaging="True" AllowSorting="True" style="margin-right: 6px">
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:BoundField DataField="TagsId" HeaderText="TagsId" InsertVisible="False" ReadOnly="True" SortExpression="TagsId" />
            <asp:BoundField DataField="Tags" HeaderText="Tags" SortExpression="Tags" />
        </Columns>
        <SelectedRowStyle ForeColor="Red" />
    </asp:GridView>
        </div>
    <div class="tag">
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT Photos.title, Photos.WhenPosted, Tags.TagsId, Photos.PhotosId FROM TagRelations INNER JOIN Photos ON TagRelations.PhotosId = Photos.PhotosId INNER JOIN Tags ON TagRelations.TagId = Tags.TagsId WHERE (Tags.TagsId = @TagsId)">
        <SelectParameters>
            <asp:ControlParameter ControlID="GridView1" Name="TagsId" PropertyName="SelectedValue" />
        </SelectParameters>
    </asp:SqlDataSource>
    
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource2">
        <Columns>
            <asp:HyperLinkField DataNavigateUrlFields="PhotosId" DataNavigateUrlFormatString="http://localhost:53206/photo.aspx?Id={0}" DataTextField="title" HeaderText="title" Target="_self" />
            <asp:BoundField DataField="WhenPosted" HeaderText="WhenPosted" SortExpression="WhenPosted" />
        </Columns>
    </asp:GridView>
        </div>

    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="add" EventName="Click">
            </asp:AsyncPostBackTrigger>
        </Triggers>
    </asp:UpdatePanel>
    <div style="clear:left">
        Tag: <asp:TextBox ID="tagText" runat="server" Width="229px" AutoPostBack="True" Height="22px" style="margin-bottom: 0px"></asp:TextBox>
        <asp:Button ID="add" runat="server" OnClick="add_Click" Text="add" Height="26px" />
    </div>
</asp:Content>

<asp:Content ID="Content3" runat="server" contentplaceholderid="link">
                <li> <a href="Photos.aspx">photos</a></li>            
    <li> <a href="User.aspx">user</a></li>
    <li> <a href="Upload.aspx">upload</a></li>
    <li> <a href="Login.aspx">logout</a></li></asp:Content>


