<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Pages_Account_Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">
        function userValid() 
        {
            var UserName, Password, ConfPassword, FirstName, LastName, Address, PostalCode;
            UserName = document.getElementById("<%=txtUserName.ClientID%>").value;
            Password = document.getElementById("<%=txtPassword.ClientID%>").value;
            ConfPassword = document.getElementById("<%=txtConfirmPassword.ClientID%>").value;
            FirstName = document.getElementById("<%=txtFirstName.ClientID%>").value;
            LastName = document.getElementById("<%=txtLastName.ClientID%>").value;
            Address = document.getElementById("<%=txtAddress.ClientID%>").value;
            PostalCode = document.getElementById("<%=txtPostalCode.ClientID%>").value;
            if (UserName == '' && Password=='' && ConfPassword=='' && FirstName==''&& LastName==''&& Address=='' && PostalCode=='')
            {
                alert("All fields are required");
                return false;
            }
            if (UserName == '') {
                alert("User name is required");
                document.getElementById("<%=txtUserName.ClientID%>").Style.add("border", "solid 1px red");
                return false;
            }
            if (Password == '') {
                alert("Password is required");
                document.getElementById("<%=txtPassword.ClientID%>").Style.add("border", "solid 1px red");
                return false;
            }
            if (Password == '') {
                alert("Confirm Password is required");
                document.getElementById("<%=txtConfirmPassword.ClientID%>").Style.add("border", "solid 1px red");
                return false;
            }
            if (FirstName == '')
            {
                alert("Please Enter first name");
                document.getElementById("<%=txtFirstName.ClientID%>").Style.add("border", "solid 1px red");
                return false;
            }
            if (LastName == '')
            {
                alert("Please Enter last name");
                document.getElementById("<%=txtLastName.ClientID%>").Style.add("border", "solid 1px red");
                return false;
            }
            if (Address == '')
            {
                alert("Please Enter first name");
                document.getElementById("<%=txtAddress.ClientID%>").Style.add("border", "solid 1px red");
                return false;
            }
            if (PostalCode == '')
            {
                alert("Please Enter first name");
                document.getElementById("<%=txtPostalCode.ClientID%>").Style.add("border", "solid 1px red");
                return false;
            }
        }
        
    </script>
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
        Confirm Password:</p>
    <p>
        <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="inputs" TextMode="Password"></asp:TextBox>
    </p>
<p>
        FirstName:</p>
<p>
        <asp:TextBox ID="txtFirstName" runat="server" CssClass="inputs"></asp:TextBox>
    </p>
<p>
        last Name:</p>
<p>
        <asp:TextBox ID="txtLastName" runat="server" CssClass="inputs"></asp:TextBox>
    </p>
<p>
        Address:</p>
<p>
        <asp:TextBox ID="txtAddress" runat="server" CssClass="inputs"></asp:TextBox>
    </p>
<p>
        Postal Code:</p>
<p>
        <asp:TextBox ID="txtPostalCode" runat="server" CssClass="inputs"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="btnSignUp" runat="server" CssClass="button" OnClick="btnSignUp_Click" OnClientClick="return userValid()" Text="Sign Up" />
    </p>
</asp:Content>

