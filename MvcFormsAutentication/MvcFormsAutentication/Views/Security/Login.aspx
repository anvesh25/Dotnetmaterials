<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Login</title>
</head>
<body>
    <div>
        <form action="CheckUser" method="post">
        Enter user name : <input id="txtUserId" name="txtUserId" type="text" /> <br />
        Enter Password : <input id="txtPassword" name="txtpassword" type ="password" /> <br />
        <input id="Button1" type="Submit" value="Submit" />
        </form>
    </div>
</body>
</html>
