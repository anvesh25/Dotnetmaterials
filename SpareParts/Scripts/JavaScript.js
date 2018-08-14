function userValid() 

{

    var Name, EmailId, emailExp, Subject, Message;
    Name = document.getElementById("txtName").value;
    EmailId = document.getElementById("txtEmail").value;
    emailExp = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([com\co\.\in])+$/; // to validate email id
    Subject = document.getElementById("txtSubject").value;
    Message = document.getElementById("txtMessage").value;

    if (Name == '' && EmailId == '' && Subject=='' && Message=='')
    {
        alert( "Enter All Fields");
        return false;
    }
    if (document.getElementById("<%=txtName.ClientID%>").value == "") {
        document.getElementById("<%=txtName.ClientID%>").Style.add("border", "solid 1px red");
        alert("Please Enter Login ID");
        return false;
    }
    if (Name == '') 
    {
        alert("Please Enter Login ID");
        return false;
    }
    if (EmailId == '')
    {
        alert("Email Id Is Required");
        return false;
    }
    if (EmailId != '')
    {
        if (!EmailId.match(emailExp))
        {
            alert( "Invalid Email Id");
            return false;
        }
    }
    if (Subject == '')
    {
        alert("Subject Is Required");
        return false;
    }
    if (Message == '')
    {
        alert("Message Is Required");
        return false;
    }
}

