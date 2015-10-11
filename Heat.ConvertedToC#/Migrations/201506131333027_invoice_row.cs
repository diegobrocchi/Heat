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
	public partial class invoice_row : DbMigration
	{

		public override void Up()
		{
			AddColumn("dbo.Invoices", "InvoiceDate", c => c.DateTime(nullable: false));
			AddColumn("dbo.Invoices", "TaxableAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
			AddColumn("dbo.Invoices", "TaxRate", c => c.Decimal(nullable: false, precision: 18, scale: 2));
			AddColumn("dbo.Invoices", "TaxesAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
			AddColumn("dbo.Invoices", "TotalAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
			AddColumn("dbo.Invoices", "SelfBilling", c => c.Boolean(nullable: false));
			AddColumn("dbo.Invoices", "IsTaxExempt", c => c.Boolean(nullable: false));
			AddColumn("dbo.Invoices", "TaxExemption", c => c.String());
			AddColumn("dbo.InvoiceRows", "VAT_Rate", c => c.Decimal(nullable: false, precision: 18, scale: 2));
			AddColumn("dbo.InvoiceRows", "RateDiscount1", c => c.Decimal(nullable: false, precision: 18, scale: 2));
			AddColumn("dbo.InvoiceRows", "RateDiscount2", c => c.Decimal(nullable: false, precision: 18, scale: 2));
			AddColumn("dbo.InvoiceRows", "RateDiscount3", c => c.Decimal(nullable: false, precision: 18, scale: 2));
			DropColumn("dbo.Invoices", "Sum");
			DropColumn("dbo.InvoiceRows", "VAT");
		}

		public override void Down()
		{
			AddColumn("dbo.InvoiceRows", "VAT", c => c.Double(nullable: false));
			AddColumn("dbo.Invoices", "Sum", c => c.Decimal(nullable: false, precision: 18, scale: 2));
			DropColumn("dbo.InvoiceRows", "RateDiscount3");
			DropColumn("dbo.InvoiceRows", "RateDiscount2");
			DropColumn("dbo.InvoiceRows", "RateDiscount1");
			DropColumn("dbo.InvoiceRows", "VAT_Rate");
			DropColumn("dbo.Invoices", "TaxExemption");
			DropColumn("dbo.Invoices", "IsTaxExempt");
			DropColumn("dbo.Invoices", "SelfBilling");
			DropColumn("dbo.Invoices", "TotalAmount");
			DropColumn("dbo.Invoices", "TaxesAmount");
			DropColumn("dbo.Invoices", "TaxRate");
			DropColumn("dbo.Invoices", "TaxableAmount");
			DropColumn("dbo.Invoices", "InvoiceDate");
		}
	}
}
