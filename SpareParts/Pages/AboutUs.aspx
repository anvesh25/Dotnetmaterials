<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AboutUs.aspx.cs" Inherits="Pages_AboutUs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">
        function userValid() 
        {
            var Name, EmailId, emailExp, Subject, Message;
            Name = document.getElementById("<%=txtName.ClientID%>").value;
            EmailId = document.getElementById("<%=txtEmail.ClientID%>").value;
            emailExp = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([com\co\.\in])+$/; // to validate email id
            Subject = document.getElementById("<%=txtSubject.ClientID%>").value;
            Message = document.getElementById("<%=txtMessage.ClientID%>").value;

            if (Name == '' && EmailId == '' && Subject=='' && Message=='')
            {
                alert("Enter All Fields");
                document.getElementById("<%=txtName.ClientID%>").Style.add("border", "solid 1px red");
                document.getElementById("<%=txtEmail.ClientID%>").Style.add("border", "solid 1px red");
                document.getElementById("<%=txtSubject.ClientID%>").Style.add("border", "solid 1px red");
                document.getElementById("<%=txtMessage.ClientID%>").Style.add("border", "solid 1px red");
                return false;
            }
            if (Name == '') 
            {
                alert("Please Enter Login ID");
                document.getElementById("<%=txtName.ClientID%>").Style.add("border", "solid 1px red");
                return false;
            }
            if (EmailId == '')
            {
                document.getElementById("<%=txtEmail.ClientID%>").Style.add("border", "solid 1px red");
                alert("Email Id Is Required");
                return false;
            }
            if (EmailId != '')
            {
                if (!EmailId.match(emailExp))
                {
                    document.getElementById("<%=txtEmail.ClientID%>").Style.add("border", "solid 1px red");
                    alert( "Invalid Email Id");
                    return false;
                }
            }
            if (Subject == '')
            {
                document.getElementById("<%=txtSubject.ClientID%>").Style.add("border", "solid 1px red");
                alert("Subject Is Required");
                return false;
            }
            if (Message == '')
            {
                document.getElementById("<%=txtMessage.ClientID%>").Style.add("border", "solid 1px red");
                alert("Message Is Required");
                return false;
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <p>
        Name:</p>
    <p>
        <asp:TextBox ID="txtName" runat="server" CssClass="inputs"></asp:TextBox>
    </p>
    <p>
        Email Id:</p>
    <p>
        <asp:TextBox ID="txtEmail" runat="server" CssClass="inputs"></asp:TextBox>
    </p>
    <p>
        Subject</p>
    <p>
        <asp:TextBox ID="txtSubject" runat="server" CssClass="inputs"></asp:TextBox>
    </p>
    <p>
        Message:</p>
    <p>
        <asp:TextBox ID="txtMessage" runat="server" CssClass="inputs" Height="101px" MaxLength="800" TextMode="MultiLine" Width="443px"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="btnSubmit" runat="server" CssClass="button" Text="Submit" OnClientClick="return userValid()" OnClick="btnSubmit_Click" />
    </p>
<p>
        <asp:Label ID="lbltxt" runat="server" ForeColor="#00CC00"></asp:Label>
    </p>
    
</asp:Content>

