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
// <auto-generated />
using System.CodeDom.Compiler;
using System.Data.Entity.Migrations;
using System.Data.Entity.Migrations.Infrastructure;
using System.Resources;

namespace Heat.Migrations
{
	[GeneratedCode("EntityFramework.Migrations", "6.1.3-40302")]
	public sealed partial class HeatTransferFluid : IMigrationMetadata
	{

		private readonly ResourceManager Resources = new ResourceManager(typeof(HeatTransferFluid));

		private string IMigrationMetadata_Id {
			get { return "201508310959056_HeatTransferFluid"; }
		}
		string IMigrationMetadata.Id {
			get { return IMigrationMetadata_Id; }
		}

		private string IMigrationMetadata_Source {
			get { return Resources.GetString("Source"); }
		}
		string IMigrationMetadata.Source {
			get { return IMigrationMetadata_Source; }
		}

		private string IMigrationMetadata_Target {
			get { return Resources.GetString("Target"); }
		}
		string IMigrationMetadata.Target {
			get { return IMigrationMetadata_Target; }
		}
	}
}