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
	public partial class removeTelephoneFromPlant : DbMigration
	{

		public override void Up()
		{
			DropColumn("dbo.Plants", "PlantTelephone1");
			DropColumn("dbo.Plants", "PlantTelephone2");
			DropColumn("dbo.Plants", "PlantTelephone3");
		}

		public override void Down()
		{
			AddColumn("dbo.Plants", "PlantTelephone3", c => c.String());
			AddColumn("dbo.Plants", "PlantTelephone2", c => c.String());
			AddColumn("dbo.Plants", "PlantTelephone1", c => c.String());
		}
	}
}
