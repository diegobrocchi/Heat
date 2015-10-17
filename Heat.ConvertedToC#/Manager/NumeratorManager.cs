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
using Heat.Repositories;
using Heat.Models;

namespace Heat.Manager
{

	public sealed class NumeratorManager
	{
		private static readonly Lazy<NumeratorManager> lazy = new Lazy<NumeratorManager>(() => new NumeratorManager());

		private static readonly object _lockObject = new object();
		public static NumeratorManager Instance {
			get { return lazy.Value; }
		}

		private NumeratorManager()
		{
		}

		/// <summary>
		/// Ritorna il successivo numero di serie di tipo temporaneo per il numeratore assegnato e aggiorna lo stesso numeratore.
		/// </summary>
		/// <param Name="numbering"></param>
		/// <returns></returns>
		/// <remarks></remarks>
		public SerialNumber GetNextTemp(ref Numbering numbering)
		{

			lock (_lockObject) {
				SerialNumber currentserial = null;
				SerialNumber NextSerial = null;

				currentserial = numbering.LastTempSerial;

				try {
					NextSerial = currentserial.Increment(numbering.TempSerialSchema);
					if (NextSerial.IsValid) {
						numbering.LastTempSerial = NextSerial;
						return NextSerial;
					} else {
						throw new Exception("Impossibile generare un seriale valido per il numeratore!");
					}
				} catch (Exception ex) {
					throw;
				}

			}


		}

		/// <summary>
		/// Ritorna il primo numero seriale di tipo definitivo per il numeratore assegnato
		/// </summary>
		/// <param Name="numbering"></param>
		/// <returns></returns>
		/// <remarks></remarks>
		public SerialNumber GetNextFinal(Numbering numbering)
		{
			lock (_lockObject) {
				SerialNumber currentSerial = null;
				SerialNumber nextSerial = null;

				currentSerial = numbering.LastFinalSerial;
				try {
					nextSerial = currentSerial.Increment(numbering.FinalSerialSchema);
					if (nextSerial.IsValid) {
						numbering.LastFinalSerial = nextSerial;
						return nextSerial;
					} else {
						throw new Exception("Impossibile generare un serial valido per il numeratore!");
					}
				} catch (Exception ex) {
					throw;
				}
			}
		}




		public static DateTime EndOfWeek()
		{
			DateTime startDayOfCurrentWeek = default(DateTime);
			startDayOfCurrentWeek = DateAndTime.Now.AddDays(- (double) DateAndTime.Now.DayOfWeek).AddDays(7);
			return DateAndTime.Now.AddDays(- (double) DateAndTime.Now.DayOfWeek).AddDays(7);
		}
	}


}
