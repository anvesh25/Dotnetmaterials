<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LoginRegistration._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registration</title>
    <script language="javascript" type="text/javascript">
        function validate()
        {
            var summary = "";
            summary += isvaliduser();
            summary += isvalidpassword();
            summary += isvalidCOnfirmpassword();
            summary += isvalidFirstname();
            summary += isvalidLastname();
            summary += isvalidEmail();
            summary += isvalidphoneno();
            summary += isvalidLocation();
            if (summary != "")
            {
                alert(summary);
                return false;
            }
            else
            {
                return true;
            }

        }
        function isvaliduser()
        {
            var uid;
            var temp = document.getElementById("<%=txtUserName.ClientID %>");
            uid = temp.value;
            if (uid == "")
            {
                return ("Please Enter UserName" + "\n");
            }
            else
            {
                return "";
            }
        }
        function isvalidpassword()
        {
            var uid;
            var temp = document.getElementById("<%=txtPassword.ClientID %>");
            uid = temp.value;
            if (uid == "")
            {
                return ("Please enter password" + "\n");
            }
            else
            {
                return "";
            }
        }
        function isvalidCOnfirmpassword()
        {
            var uid;
            var temp = document.getElementById("<%=txtConfirmPassword.ClientID %>");
            uid = temp.value;
            if (uid == "")
            {
                return ("Please enter Confirmpassword" + "\n");
            }
            else
            {
                return "";
            }
        }
        function isvalidFirstname()
        {
            var uid;
            var temp = document.getElementById("<%=txtFirstName.ClientID %>");
            uid = temp.value;
            if (uid == "")
            {
                return ("Please enter firstname" + "\n");
            }
            else
            {
                return "";
            }
        }
        function isvalidLastname()
        {
            var uid;
            var temp = document.getElementById("<%=txtLastName.ClientID %>");
            uid = temp.value;
            if (uid == "")
            {
                return ("Please enter lastname" + "\n");
            }
            else
            {
                return "";
            }
        }
        function isvalidEmail()
        {
            var uid;
            var temp = document.getElementById("<%=txtEmail.ClientID %>");
            uid = temp.value;
            var re = /\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*/;
            if (uid == "")
            {
                return ("Please Enter Email" + "\n");
            }
            else if (re.test(uid))
            {
                return "";
            }

            else
            {
                return ("Email should be in the form ex:abc@xyz.com" + "\n");
            }
        }
        function isvalidphoneno()
        {
            var uid;
            var temp = document.getElementById("<%=txtPhoneNo.ClientID %>");
            uid = temp.value;
            var re;
            re = /^[0-9]+$/;
            var digits = /\d(10)/;
            if (uid == "")
            {
                return ("Please enter phoneno" + "\n");
            }
            else if (re.test(uid))
            {
                return "";
            }
            else
            {
                return ("Phoneno should be digits only" + "\n");
            }
        }
        function isvalidLocation()
        {
            var uid;
            var temp = document.getElementById("<%=txtLocation.ClientID %>");
            uid = temp.value;
            if (uid == "")
            {
                return ("Please enter Location" + "\n");
            }
            else
            {
                return "";
            }
        }
    </script>
    <style type="text/css">
        .auto-style1 
        {
            width: 162px;
        }
        .auto-style2 
        {
            width: 195px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table align="center">
                <tr> 
                    <td align="center" class="auto-style1">Registration Form</td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="lblUserName" runat="server" Text="User Name"></asp:Label>
                    </td>
                    <td class="auto-style2">
                        <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
                    </td>
                    <td class="auto-style2">
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="lblConfirmPassword" runat="server" Text="Confirm Password"></asp:Label>
                    </td>
                    <td class="auto-style2">
                        <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="lblFirstName" runat="server" Text="First Name"></asp:Label>
                    </td>
                    <td class="auto-style2">
                        <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="lblLastName" runat="server" Text="Last Name"></asp:Label>
                    </td>
                    <td class="auto-style2">
                        <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
                    </td>
                    <td class="auto-style2">
                        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="lblPhoneNo" runat="server" Text="Phone No"></asp:Label>
                    </td>
                    <td class="auto-style2">
                        <asp:TextBox ID="txtPhoneNo" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="lblLocation" runat="server" Text="Location"></asp:Label>
                    </td>
                    <td class="auto-style2">
                        <asp:TextBox ID="txtLocation" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="lblCreatedBy" runat="server" Text="Created By"></asp:Label>
                    </td>
                    <td class="auto-style2">
                        <asp:TextBox ID="txtCreatedBy" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                    
                    </td>
                    <td class="auto-style2">
                        <asp:Button ID="btnSubmit" runat="server" Text="SignUp" OnClick="btnSubmit_Click" />
                        <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" />
                    </td>
                </tr>  
            </table>
            <span style= "color:Green; font-weight :bold"> <asp:Label ID="lblErrorMsg" runat="server"></asp:Label></span>
        </div>
    </form>
</body>
</html>
