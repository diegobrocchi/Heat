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
	public partial class changeWorkAction1 : DbMigration
	{

		public override void Up()
		{
			DropForeignKey("dbo.WorkActions", "AssignedOperator_ID", "dbo.WorkOperators");
			DropForeignKey("dbo.WorkActions", "Customer_ID", "dbo.Customers");
			DropForeignKey("dbo.WorkActions", "Operation_ID", "dbo.Operations");
			DropIndex("dbo.WorkActions", new string[] { "AssignedOperator_ID" });
			DropIndex("dbo.WorkActions", new string[] { "Customer_ID" });
			DropIndex("dbo.WorkActions", new string[] { "Operation_ID" });
			RenameColumn(table: "dbo.WorkActions", name: "AssignedOperator_ID", newName: "AssignedOperatorID");
			RenameColumn(table: "dbo.WorkActions", name: "Customer_ID", newName: "CustomerID");
			RenameColumn(table: "dbo.WorkActions", name: "Operation_ID", newName: "OperationID");
			AlterColumn("dbo.WorkActions", "AssignedOperatorID", c => c.Int(nullable: false));
			AlterColumn("dbo.WorkActions", "CustomerID", c => c.Int(nullable: false));
			AlterColumn("dbo.WorkActions", "OperationID", c => c.Int(nullable: false));
			CreateIndex("dbo.WorkActions", "CustomerID");
			CreateIndex("dbo.WorkActions", "OperationID");
			CreateIndex("dbo.WorkActions", "AssignedOperatorID");
			AddForeignKey("dbo.WorkActions", "AssignedOperatorID", "dbo.WorkOperators", "ID", cascadeDelete: true);
			AddForeignKey("dbo.WorkActions", "CustomerID", "dbo.Customers", "ID", cascadeDelete: true);
			AddForeignKey("dbo.WorkActions", "OperationID", "dbo.Operations", "ID", cascadeDelete: true);
		}

		public override void Down()
		{
			DropForeignKey("dbo.WorkActions", "OperationID", "dbo.Operations");
			DropForeignKey("dbo.WorkActions", "CustomerID", "dbo.Customers");
			DropForeignKey("dbo.WorkActions", "AssignedOperatorID", "dbo.WorkOperators");
			DropIndex("dbo.WorkActions", new string[] { "AssignedOperatorID" });
			DropIndex("dbo.WorkActions", new string[] { "OperationID" });
			DropIndex("dbo.WorkActions", new string[] { "CustomerID" });
			AlterColumn("dbo.WorkActions", "OperationID", c => c.Int());
			AlterColumn("dbo.WorkActions", "CustomerID", c => c.Int());
			AlterColumn("dbo.WorkActions", "AssignedOperatorID", c => c.Int());
			RenameColumn(table: "dbo.WorkActions", name: "OperationID", newName: "Operation_ID");
			RenameColumn(table: "dbo.WorkActions", name: "CustomerID", newName: "Customer_ID");
			RenameColumn(table: "dbo.WorkActions", name: "AssignedOperatorID", newName: "AssignedOperator_ID");
			CreateIndex("dbo.WorkActions", "Operation_ID");
			CreateIndex("dbo.WorkActions", "Customer_ID");
			CreateIndex("dbo.WorkActions", "AssignedOperator_ID");
			AddForeignKey("dbo.WorkActions", "Operation_ID", "dbo.Operations", "ID");
			AddForeignKey("dbo.WorkActions", "Customer_ID", "dbo.Customers", "ID");
			AddForeignKey("dbo.WorkActions", "AssignedOperator_ID", "dbo.WorkOperators", "ID");
		}
	}
}
