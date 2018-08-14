﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Product.aspx.cs" Inherits="Pages_Product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table>
        <tr>
            <td rowspan="4">
                <asp:Image ID="imgProduct" runat="server" CssClass="detailsImage" />
            </td>
            <td>
                <h2>
                    <asp:Label ID="lblTitle" runat="server" Text=""></asp:Label>
                    <hr />
                </h2>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblDescription" runat="server" CssClass="detailsDescription" ></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblPrice" runat="server" CssClass="detailsPrice" ></asp:Label><br/>
                Quantity:
                <asp:DropDownList ID="ddlAmount" runat="server"></asp:DropDownList><br/>
                <asp:Button ID="btnAdd" runat="server" Text="Add Product" CssClass="button" OnClick="btnAdd_Click" Height="30px" ToolTip="Add Product" /><br />
                <asp:Label ID="lblResult" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Product No:<asp:Label ID="lblItemNr" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Available" CssClass="productPrice" ></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>

