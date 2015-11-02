using System;
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
        DbSet<AssignedOutboundCall> AssignedOutboundCalls { get; set; }

		int SaveChanges();


		void SetModified(object entity);
	}
}
