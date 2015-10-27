using System.Configuration;
using System.Web;
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
		/// <param Name="file"></param>
		/// <returns></returns>
		public Medium GetMedium(HttpPostedFileBase file, string description, string tags)
		{

			Medium result = new Medium();
			result.Description = description ?? string.Empty;
			result.Tags = tags ?? string.Empty;
			result.OriginalFileName = Path.GetFileName(file.FileName);
			result.Lenght = file.ContentLength;
			result.Extension = file.FileName.Substring(file.FileName.IndexOf("."));
			result.ContentType = file.ContentType;

			//result.AbsolutePath = server.MapPath(Path.Combine(_folder, file.FileName))
			return result;
		}

	}
}
