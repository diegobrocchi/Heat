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
	public partial class Allineamento_Anagrafica_Futura : DbMigration
	{

		public override void Up()
		{
			AddColumn("dbo.Customers", "Name", c => c.String());
			AddColumn("dbo.Customers", "Address", c => c.String());
			AddColumn("dbo.Customers", "City", c => c.String());
			AddColumn("dbo.Customers", "PostalCode", c => c.String());
			AddColumn("dbo.Customers", "District", c => c.String());
			AddColumn("dbo.Customers", "Telephone1", c => c.String());
			AddColumn("dbo.Customers", "Telephone2", c => c.String());
			AddColumn("dbo.Customers", "Telephone3", c => c.String());
			AddColumn("dbo.Customers", "Taxcode", c => c.String());
			AddColumn("dbo.Customers", "VAT", c => c.String());
			AddColumn("dbo.Customers", "IBAN", c => c.String());
			DropColumn("dbo.Customers", "FirstName");
			DropColumn("dbo.Customers", "Surname");
			DropColumn("dbo.Customers", "CompanyName");
		}

		public override void Down()
		{
			AddColumn("dbo.Customers", "CompanyName", c => c.String());
			AddColumn("dbo.Customers", "Surname", c => c.String());
			AddColumn("dbo.Customers", "FirstName", c => c.String());
			DropColumn("dbo.Customers", "IBAN");
			DropColumn("dbo.Customers", "VAT");
			DropColumn("dbo.Customers", "Taxcode");
			DropColumn("dbo.Customers", "Telephone3");
			DropColumn("dbo.Customers", "Telephone2");
			DropColumn("dbo.Customers", "Telephone1");
			DropColumn("dbo.Customers", "District");
			DropColumn("dbo.Customers", "PostalCode");
			DropColumn("dbo.Customers", "City");
			DropColumn("dbo.Customers", "Address");
			DropColumn("dbo.Customers", "Name");
		}
	}
}
