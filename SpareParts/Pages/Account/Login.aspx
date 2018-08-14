﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Pages_Account_Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
    <asp:Literal ID="litStatus" runat="server"></asp:Literal>
</p>
<p>
    UserName:</p>
<p>
    <asp:TextBox ID="txtUserName" runat="server" CssClass="inputs"></asp:TextBox>
</p>
<p>
    Password:</p>
<p>
    <asp:TextBox ID="txtPassword" runat="server" CssClass="inputs" TextMode="Password"></asp:TextBox>
</p>
<p>
    <asp:Button ID="btnLogin" runat="server" CssClass="button" OnClick="btnLogin_Click" Text="Log In" />
</p>
</asp:Content>

