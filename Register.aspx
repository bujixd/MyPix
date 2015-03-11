<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" Runat="Server">
    <h2>Registeration</h2>
    
    <p>
                
                full
                
                name:<asp:TextBox ID="name" runat="server"  Width="233px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="nameRequired" runat="server" 
                    ControlToValidate="name" Display="Dynamic" 
                    ErrorMessage="please provide your name" ForeColor="Red"></asp:RequiredFieldValidator>
                
                <asp:RegularExpressionValidator ID="fullnameValid0" runat="server" 
                    ControlToValidate="name" Display="Dynamic" 
                    ErrorMessage="Please provide password no less than 4 characters and no longer than 20 characters" 
                    ForeColor="#FF3300" ValidationExpression="^\w{4,50}$"></asp:RegularExpressionValidator>
                
            </p>
            <p>
                
                user name:<asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" 
                    ControlToValidate="UserName" Display="Dynamic" 
                    ErrorMessage="Please provide user name" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="fullnameValid1" runat="server" 
                    ControlToValidate="UserName" Display="Dynamic" 
                    ErrorMessage="Please provide password no less than 4 characters and no longer than 30 characters" 
                    ForeColor="#FF3300" ValidationExpression="^\w{4,30}$"></asp:RegularExpressionValidator>
                
            </p>
            <p>
                
                password:<asp:TextBox ID="password" runat="server" MaxLength="20" 
                    TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="passwordRequired" runat="server" 
                    ControlToValidate="password" Display="Dynamic" 
                    ErrorMessage="please provide password" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="passwordValid" runat="server" 
                    ControlToValidate="password" Display="Dynamic" 
                    ErrorMessage="Please provide password no less than 4 characters and no longer than 20 characters" 
                    ForeColor="#FF3300" ValidationExpression="^\w{4,20}$"></asp:RegularExpressionValidator>
                <asp:CompareValidator ID="PasswordCompare" runat="server" 
                    ControlToCompare="UserName" ControlToValidate="password" Display="Dynamic" 
                    ErrorMessage="Please do not use your user name as your password" 
                    ForeColor="#FF3300" Operator="NotEqual"></asp:CompareValidator>
                
            </p>
            <p>
                
                Password confirmation:<asp:TextBox ID="passwordConfirm" runat="server" 
                    MaxLength="10" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="PasswordConfirmRequired" runat="server" 
                    ControlToValidate="passwordConfirm" Display="Dynamic" 
                    ErrorMessage="Please confirm your password" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" 
                    ControlToCompare="password" ControlToValidate="passwordConfirm" 
                    Display="Dynamic" ErrorMessage="Please input same password" 
                    ForeColor="#FF3300"></asp:CompareValidator>
                
            </p>
    <p>
                
                email:<asp:TextBox ID="email" runat="server" Width="163px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Please input correct email address" ForeColor="#FF3300" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="email"></asp:RegularExpressionValidator>
                
            </p>
    <p>
                
                email confirmation:<asp:TextBox ID="emailConfirm" runat="server" Width="201px"></asp:TextBox>
                <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="CompareValidator" ControlToCompare="email" ControlToValidate="emailConfirm"></asp:CompareValidator>
                
            </p>
            <p>
                
                User profile:<br />
                <asp:TextBox ID="userProfile" runat="server" Height="62px" 
                    TextMode="MultiLine" Width="539px"></asp:TextBox>
                
            </p>
    <p>
                
                Visually impaired: <asp:CheckBox ID="ChooseADA" runat="server" />
                
            </p>
            <p dir="ltr">
                
                <asp:Button ID="submit" runat="server" Text="submit" Font-Bold="True" 
                    onclick="submit_Click" />
                
            </p>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                ShowMessageBox="True" ShowSummary="False" />
</asp:Content>

<asp:Content ID="Content3" runat="server" contentplaceholderid="link">
    <asp:HyperLink ID="loginUrl" runat="server" NavigateUrl="~/Login.aspx">login</asp:HyperLink>
</asp:Content>


