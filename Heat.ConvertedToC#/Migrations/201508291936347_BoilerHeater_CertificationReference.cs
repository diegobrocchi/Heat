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
using System.Data.Entity.Migrations;

namespace Heat.Migrations
{
	public partial class BoilerHeater_CertificationReference : DbMigration
	{

		public override void Up()
		{
			AddColumn("dbo.BoilerHeaters", "CertificationReference", c => c.String());
			AddColumn("dbo.BoilerServices", "PreviousServiceDate", c => c.DateTime(nullable: false));
			AddColumn("dbo.BoilerServices", "Periodicity", c => c.Int(nullable: false));
			AddColumn("dbo.BoilerServices", "LegalExpirationDate", c => c.DateTime(nullable: false));
			AddColumn("dbo.BoilerServices", "PlannedServiceDate", c => c.DateTime(nullable: false));
		}

		public override void Down()
		{
			DropColumn("dbo.BoilerServices", "PlannedServiceDate");
			DropColumn("dbo.BoilerServices", "LegalExpirationDate");
			DropColumn("dbo.BoilerServices", "Periodicity");
			DropColumn("dbo.BoilerServices", "PreviousServiceDate");
			DropColumn("dbo.BoilerHeaters", "CertificationReference");
		}
	}
}
