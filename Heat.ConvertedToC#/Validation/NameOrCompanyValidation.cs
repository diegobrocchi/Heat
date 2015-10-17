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

	/// <summary>
	/// Inmpone che la proprietà sia valorizzata se un'altra è nulla.
	/// </summary>
	/// <remarks></remarks>
	public class RequiredIfEmpty : ValidationAttribute
	{

		private string _other;
		/// <summary>
		/// La proprietà di cui deve essere controllata la presenza per validare la corrente.
		/// </summary>
		/// <value></value>
		/// <returns></returns>
		/// <remarks></remarks>
		public string Other {
			get { return _other; }
			private set { _other = value; }
		}



		public RequiredIfEmpty(string other)
		{
			_other = other;
		}

		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{

			//se il valore della proprietà non è nullo allora è valido.
			if ((value != null)) {
				return ValidationResult.Success;
			} else {
				//se il valore è nullo allora non deve essere nullo quello dell'altra proprietà.
				var pi = validationContext.ObjectType.GetProperty(Other);
				if ((pi != null)) {
					if (string.IsNullOrEmpty(pi.GetValue(validationContext.ObjectInstance).ToString())) {
						return new ValidationResult(string.Format("Questo valore è richiesto se {0} è nullo", Other));
					} else {
						return ValidationResult.Success;
					}
				} else {
					return new ValidationResult(string.Format("Non esiste la proprietà {0}", Other));
				}

			}
		}

	}
}
