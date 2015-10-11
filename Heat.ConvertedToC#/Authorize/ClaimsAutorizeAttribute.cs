using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Xml.Linq;
using System.Diagnostics;
using System.Collections.Specialized;
using System.Configuration;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using System.Web.Routing;
using System.Web.SessionState;
using System.Web.Security;
using System.Web.Profile;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Security.Claims;
namespace Heat
{

	public class ClaimsAutorizeAttribute : AuthorizeAttribute
	{

		private string _claimType;

		private string _claimValue;
		public ClaimsAutorizeAttribute()
		{
		}

		public ClaimsAutorizeAttribute(string type, string value)
		{
			_claimType = type;
			_claimValue = value;
		}

		//Public Overrides Sub OnAuthorization(filterContext As AuthorizationContext)
		//    Dim questoUtente = DirectCast(filterContext.HttpContext.User, ClaimsPrincipal)
		//    'Dim user As ClaimsPrincipal = filterContext.HttpContext.User
		//    'Dim ide As ClaimsIdentity = questoUtente.Identity
		//    Dim cl As New List(Of Claim)
		//    For Each cx In questoUtente.Claims
		//        cl.Add(cx)
		//    Next
		//    'Dim c As String = ide.Claims.Where(Function(cl) cl.Type = _claimType And cl.Value = _claimValue).Select(Function(d) d.Value).FirstOrDefault
		//    Dim c As String = questoUtente.Claims.Where(Function(cla) cla.Type = _claimType And cla.Value = _claimValue).Select(Function(cs) cs.Value).FirstOrDefault
		//    If Not IsNothing(c) Then
		//        MyBase.OnAuthorization(filterContext)
		//    Else
		//        MyBase.HandleUnauthorizedRequest(filterContext)
		//    End If
		//End Sub
	}
}
