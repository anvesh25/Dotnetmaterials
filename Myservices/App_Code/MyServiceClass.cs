using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;


/// <summary>
/// Summary description for MyServiceClass
/// </summary>
[WebService]
public class MyServiceClass
{
    [WebMethod]
	public string SayHello(String UserName)
	{
		return string.Format("Hello.. {0}", UserName);
	}
}