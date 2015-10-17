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
using System.ComponentModel.DataAnnotations;
namespace Heat
{

	public class ExternalLoginConfirmationViewModel
	{
		[Required()]
		[Display(Name = "Email")]
		public string Email { get; set; }
	}
}
namespace Heat
{

	public class ExternalLoginListViewModel
	{
		public string ReturnUrl { get; set; }
	}
}
namespace Heat
{

	public class SendCodeViewModel
	{
		public string SelectedProvider { get; set; }
		public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
		public string ReturnUrl { get; set; }
		public bool RememberMe { get; set; }
	}
}
namespace Heat
{

	public class VerifyCodeViewModel
	{
		[Required()]
		public string Provider { get; set; }

		[Required()]
		[Display(Name = "Code")]
		public string Code { get; set; }

		public string ReturnUrl { get; set; }

		[Display(Name = "Remember this browser?")]
		public bool RememberBrowser { get; set; }

		public bool RememberMe { get; set; }
	}
}
namespace Heat
{

	public class ForgotViewModel
	{
		[Required()]
		[Display(Name = "Email")]
		public string Email { get; set; }
	}
}
namespace Heat
{

	public class LoginViewModel
	{
		[Required()]
		[Display(Name = "UserName")]
		public string UserName { get; set; }

		//<Required>
		//<Display(Name:="Email")>
		//<EmailAddress>
		//Public Property Email As String

		[Required()]
		[DataType(DataType.Password)]
		[Display(Name = "Password")]
		public string Password { get; set; }

		[Display(Name = "Remember me?")]
		public bool RememberMe { get; set; }
	}
}
namespace Heat
{

	public class RegisterViewModel
	{
		[Required()]
		[EmailAddress()]
		[Display(Name = "Email")]
		public string Email { get; set; }

		[Required()]
		[Display(Name = "UserName")]
		public string UserName { get; set; }

		[Required()]
		[StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
		[DataType(DataType.Password)]
		[Display(Name = "Password")]
		public string Password { get; set; }

		[DataType(DataType.Password)]
		[Display(Name = "Confirm password")]
		[System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
		public string ConfirmPassword { get; set; }
	}
}
namespace Heat
{

	public class ResetPasswordViewModel
	{
		[Required()]
		[EmailAddress()]
		[Display(Name = "Email")]
		public string Email { get; set; }

		[Required()]
		[StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
		[DataType(DataType.Password)]
		[Display(Name = "Password")]
		public string Password { get; set; }

		[DataType(DataType.Password)]
		[Display(Name = "Confirm password")]
		[System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
		public string ConfirmPassword { get; set; }

		public string Code { get; set; }
	}
}
namespace Heat
{

	public class ForgotPasswordViewModel
	{
		[Required()]
		[EmailAddress()]
		[Display(Name = "Email")]
		public string Email { get; set; }
	}
}
