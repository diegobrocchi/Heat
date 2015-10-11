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
using System.IO;
using Heat.Models;

namespace Heat.Manager
{
	/// <summary>
	/// Esegue le operazioni relative ai media
	/// </summary>
	public class MediaManager
	{
		private IHeatDBContext _db;

		private string _folder;
		public MediaManager(IHeatDBContext dbContext)
		{
			_db = dbContext;
		}

		public string Folder {
			get {
				if (string.IsNullOrEmpty(_folder)) {
					_folder = ConfigurationManager.AppSettings["MediaFolder"];
				}
				return _folder;
			}
		}


		/// <summary>
		/// Trasforma un file caricato dall'utente in un oggetto Medium
		/// </summary>
		/// <param name="file"></param>
		/// <returns></returns>
		public Medium GetMedium(HttpPostedFileBase file, string description, string tags)
		{

			Medium result = new Medium();
			result.Description = description ?? string.Empty;
			result.Tags = tags ?? string.Empty;
			result.OriginalFilename = Path.GetFileName(file.FileName);
			result.Lenght = file.ContentLength;
			result.Extension = file.FileName.Substring(file.FileName.IndexOf("."));
			result.ContentType = file.ContentType;

			//result.AbsolutePath = server.MapPath(Path.Combine(_folder, file.FileName))
			return result;
		}

	}
}
