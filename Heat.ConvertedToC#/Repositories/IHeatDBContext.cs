using System;
using System.Data.Entity;
using Heat.Models;
namespace Heat
{

    public interface IHeatDBContext : IDisposable
	{

		IDbSet<Address> Addresses { get; set; }
		IDbSet<AddressType> AddressTypes { get; set; }
		DbSet<Customer> Customers { get; set; }
		IDbSet<Contact> Contacts { get; set; }
		DbSet<Numbering> Numberings { get; set; }
		IDbSet<SerialScheme> SerialSchemes { get; set; }
		IDbSet<CausalWarehouse> CausalWarehouses { get; set; }
		IDbSet<CausalWarehouseGroup> CausalWarehouseGroups { get; set; }
		IDbSet<Warehouse> Warehouses { get; set; }
		IDbSet<WarehouseMovement> WarehouseMovements { get; set; }
		IDbSet<Seller> Sellers { get; set; }
		IDbSet<Invoice> Invoices { get; set; }
		IDbSet<InvoiceRow> InvoiceRows { get; set; }
		IDbSet<DocumentType> DocumentTypes { get; set; }
		IDbSet<Product> Products { get; set; }
		IDbSet<Payment> Payments { get; set; }
		IDbSet<ProductInvoiceRow> ProductInvoiceRows { get; set; }
		IDbSet<DescriptiveInvoiceRow> DescriptiveInvoiceRows { get; set; }
		IDbSet<ActionType> ActionTypes { get; set; }
		IDbSet<WorkOperator> WorkOperators { get; set; }
		IDbSet<WorkAction> WorkActions { get; set; }
		IDbSet<Operation> Operations { get; set; }
		DbSet<Manifacturer> Manifacturers { get; set; }
		DbSet<ManifacturerModel> ManifacturerModels { get; set; }

		IDbSet<HeatTransferFluid> HeatTransferFluids { get; set; }
		IDbSet<ThermalUnitKind> ThermalUnitKinds { get; set; }
		DbSet<Plant> Plants { get; set; }
		DbSet<PlantType> PlantTypes { get; set; }
		DbSet<PlantClass> PlantClasses { get; set; }
		IDbSet<PlantService> PlantServices { get; set; }
		DbSet<ThermalUnit> ThermalUnits { get; set; }
		DbSet<Fuel> Fuels { get; set; }
		IDbSet<Heater> Heaters { get; set; }
		IDbSet<Medium> Media { get; set; }
		IDbSet<OutboundCall> OutboundCalls { get; set; }

		DbSet<ProposedOutBoundCall> ProposedOutboundCalls { get; set; }
        DbSet<AssignedOutboundCall> AssignedOutboundCalls { get; set; }
        DbSet<ProposedCallsGeneration> ProposedCallsGenerations { get; set; }

		int SaveChanges();
		void SetModified(object entity);
	}
}
