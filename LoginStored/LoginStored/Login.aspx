<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LoginStored.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="lblId" runat="server" style="z-index: 1; left: 227px; top: 14px; position: absolute" Text="ID"></asp:Label>
        <asp:TextBox ID="txtId" runat="server" style="z-index: 1; left: 327px; top: 14px; position: absolute"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lblPassword" runat="server" style="z-index: 1; left: 226px; top: 56px; position: absolute" Text="Password"></asp:Label>
        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" style="z-index: 1; left: 294px; top: 191px; position: absolute" Text="Submit" />
        <asp:TextBox ID="txtPassword" runat="server" style="z-index: 1; left: 327px; top: 54px; position: absolute"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lblConfirmPassword" runat="server" style="z-index: 1; left: 176px; top: 91px; position: absolute" Text="Confirm Password"></asp:Label>
        <br />
        <br />
        <asp:TextBox ID="txtConfirmPassword" runat="server" style="z-index: 1; left: 329px; top: 92px; position: absolute"></asp:TextBox>
        <br />
        <br />
        <br />
        <asp:Label ID="lblEmail" runat="server" style="z-index: 1; left: 237px; top: 130px; position: absolute; height: 19px" Text="Email Id"></asp:Label>
        <br />
        <br />
        <br />
    
    </div>
        <asp:TextBox ID="txtEmailId" runat="server" style="z-index: 1; left: 325px; top: 130px; position: absolute"></asp:TextBox>
    </form>
</body>
</html>
