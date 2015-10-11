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
using System.Data.Entity;
using Heat.Models;
namespace Heat
{

	public interface IHeatDBContext : IDisposable
	{

		DbSet<Address> Addresses { get; set; }
		DbSet<AddressType> AddressTypes { get; set; }
		DbSet<Customer> Customers { get; set; }
		DbSet<Contact> Contacts { get; set; }
		DbSet<Numbering> Numberings { get; set; }
		DbSet<SerialScheme> SerialSchemes { get; set; }
		DbSet<CausalWarehouse> CausalWarehouses { get; set; }
		DbSet<CausalWarehouseGroup> CausalWarehouseGroups { get; set; }
		DbSet<Warehouse> Warehouses { get; set; }
		DbSet<WarehouseMovement> WarehouseMovements { get; set; }
		DbSet<Seller> Sellers { get; set; }
		DbSet<Invoice> Invoices { get; set; }
		DbSet<InvoiceRow> InvoiceRows { get; set; }
		DbSet<DocumentType> DocumentTypes { get; set; }
		DbSet<Product> Products { get; set; }
		DbSet<Payment> Payments { get; set; }
		DbSet<ProductInvoiceRow> ProductInvoiceRows { get; set; }
		DbSet<DescriptiveInvoiceRow> DescriptiveInvoiceRows { get; set; }
		DbSet<ActionType> ActionTypes { get; set; }
		DbSet<WorkOperator> WorkOperators { get; set; }
		DbSet<WorkAction> WorkActions { get; set; }
		DbSet<Operation> Operations { get; set; }
		DbSet<Manifacturer> Manifacturers { get; set; }
		DbSet<ManifacturerModel> ManifacturerModels { get; set; }

		DbSet<HeatTransferFluid> HeatTransferFluids { get; set; }
		DbSet<ThermalUnitKind> ThermalUnitKinds { get; set; }
		DbSet<Plant> Plants { get; set; }
		DbSet<PlantType> PlantTypes { get; set; }
		DbSet<PlantClass> PlantClasses { get; set; }
		DbSet<PlantService> PlantServices { get; set; }
		DbSet<ThermalUnit> ThermalUnits { get; set; }
		DbSet<Fuel> Fuels { get; set; }
		DbSet<Heater> Heaters { get; set; }
		DbSet<Medium> Media { get; set; }
		DbSet<OutboundCall> OutboundCalls { get; set; }

		DbSet<ProposedOutBoundCall> ProposedOutboundCalls { get; set; }


		int SaveChanges();


		void SetModified(object entity);
	}
}
