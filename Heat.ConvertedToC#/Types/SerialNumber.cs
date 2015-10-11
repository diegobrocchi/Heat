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
namespace Heat.Models
{



	/// <summary>
	/// Rappresenta un numero di serie. Controllare la proprietà IsValid prima di utilizzarlo nel programma.
	/// 
	/// </summary>
	/// <remarks></remarks>
	public class SerialNumber
	{
		public SerialNumber()
		{
		}

		public SerialNumber(int serialInt, string serialString, bool isValid, string invalidError)
		{
			_SerialInteger = serialInt;
			_SerialString = serialString;
			_IsValid = isValid;
			_InvalidError = invalidError;
		}

		public int SerialInteger { get; set; }
		public string SerialString { get; set; }
		public bool IsValid { get; set; }
		public string InvalidError { get; set; }
		/// <summary>
		/// TODO!!!
		/// </summary>
		/// <param name="value"></param>
		/// <param name="scheme"></param>
		/// <returns></returns>
		/// <remarks></remarks>
		public string Stringify(int value, SerialScheme scheme)
		{
			string result = null;

			scheme.FormatMask = scheme.FormatMask.Replace("{{yyyy}}", DateAndTime.Now.Year);
			scheme.FormatMask = scheme.FormatMask.Replace("{{ww}}", DateAndTime.Now.WeekOfTheYear());
			if (!string.IsNullOrEmpty(scheme.FormatMask)) {
				result = string.Format(scheme.FormatMask, value);
			} else {
				result = value.ToString();
			}
			return result;
		}

		/// <summary>
		/// Restituisce il successivo elemento in base allo schema passato. 
		/// Controlla la scadenza dello schema, la sua periodicità, i valori massimi e minimi e genera il successivo.
		/// La proprietà IsValid indica se è stato possibile generare un numero di serie conforme allo schema.
		/// </summary>
		/// <param name="scheme"></param>
		/// <returns></returns>
		/// <remarks></remarks>
		public SerialNumber Increment(SerialScheme scheme)
		{
			if (!_IsValid) {
				throw new Exception("Cannot increment invalid SerialNumber!");
			}
			if ((scheme.ExpiryDate == null)) {
				scheme.ExpiryDate = DateTime.MaxValue;
			}

			if (scheme.RecycleWhenExpired & (scheme.Period == null)) {
				throw new ArgumentException("Scheme recyles but period is null!");
			}

			if ((scheme.MaxValue == null) & scheme.RecycleWhenMaxIsReached) {
				throw new ArgumentException("Scheme recycles on Max reached, but MaxValue in null!");
			}

			if ((scheme.FormatMask == null)) {
				scheme.FormatMask = string.Empty;
			}
			SerialNumber result = new SerialNumber();
			//se lo schema è scaduto e non ricicla, restituisce un serial con IsValid = false.
			//se lo schema ha raggiunto il massimo e non ricicla, restituisce un serial con IsValid = false.
			//se lo schema è scaduto e ricicla, ricicla lo schema.
			//se lo schema ha raggiunto il massimo e ricicla, ricicla lo schema.

			if (scheme.ExpiryDate > DateAndTime.Now) {
				//lo schema non è scaduto
				if (this.SerialInteger + scheme.Increment > scheme.MaxValue) {
					//lo schema non è scaduto, ma ha raggiunto il limite massimo
					if (scheme.RecycleWhenMaxIsReached) {
						return new SerialNumber(scheme.InitialValue, Stringify(scheme.InitialValue, scheme), true, string.Empty);
					} else {
						return new SerialNumber(0, string.Empty, false, "Raggiunto il valore massimo dello schema!");
					}
				} else {
					//lo schema non è scaduto e non ha raggiunto il limite massimo: 
					return new SerialNumber(_SerialInteger + scheme.Increment, Stringify(_SerialInteger + scheme.Increment, scheme), true, string.Empty);
				}
			} else {
				//lo schema è scaduto
				if (scheme.RecycleWhenExpired) {
					//rinnova lo schema
					switch (scheme.Period) {
						case Periodicity.Daily:
							scheme.ExpiryDate = DateAndTime.Now.EndOfDay();
							break;
						case Periodicity.Weekly:
							scheme.ExpiryDate = DateAndTime.Now.EndOfWeek();
							break;
						case Periodicity.Monthly:
							scheme.ExpiryDate = DateAndTime.Now.EndOfMonth();
							break;
						case Periodicity.Quarterly:
							scheme.ExpiryDate = DateAndTime.Now.EndOfQuarter();
							break;
						case Periodicity.Yearly:
							scheme.ExpiryDate = DateAndTime.Now.EndOfYear();
							break;
						default:
							return new SerialNumber(0, string.Empty, false, "Periodicità non definita");
					}

					return new SerialNumber(scheme.InitialValue, Stringify(scheme.InitialValue, scheme), true, string.Empty);
				} else {
					//lo schema è scaduto e non ricicla.
					return new SerialNumber(0, string.Empty, false, "Lo schema è scaduto e non ammette il riciclo!");
				}
			}



		}

		public override bool Equals(object obj)
		{
			if ((obj == null)) {
				return false;
			}

			SerialNumber other = obj as SerialNumber;

			if ((other == null)) {
				return false;
			}


			if (IsValid == other.IsValid & SerialInteger == other.SerialInteger & SerialString == other.SerialString & InvalidError == other.InvalidError) {
				return true;
			} else {
				return false;

			}

		}

		public override int GetHashCode()
		{

			int hash = 0;
			hash = 13;
			hash = hash * this.IsValid.GetHashCode();
			hash = hash * this.SerialInteger.GetHashCode();
			hash = hash * this.SerialString.GetHashCode();
			hash = hash * this.InvalidError.GetHashCode();

			return hash;
		}

	}
}
