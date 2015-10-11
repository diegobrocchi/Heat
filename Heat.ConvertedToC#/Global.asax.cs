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
using System.Web.Optimization;
using System.Web.Helpers;
using System.Security.Claims;
using System.IdentityModel.Services;
using AutoMapper;
using Heat.Models;
using System.Security.Principal;
namespace Heat
{

	public class MvcApplication : System.Web.HttpApplication
	{

		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);

			//http://www.codeproject.com/Articles/639458/Claims-Based-Authentication-and-Authorization
			AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.Name;

			//rimuove il motore di render per le pagine aspx
			ViewEngines.Engines.Clear();
			ViewEngines.Engines.Add(new RazorViewEngine());

			ModelBinders.Binders.Add(typeof(decimal), new DecimalModelBinder());
			ModelBinders.Binders.Add(typeof(IPrincipal), new PrincipalModelBinder());

			DataTables.AspNet.Mvc5.Configuration.Register();

			DoAutomapperConfig();

		}


		private void DoAutomapperConfig()
		{
			//Mapper.CreateMap(of SOURCE, DESTINATION).ForMember(UNA_PROPRIETA_NON_MAPPATA_DEL_DESTINATION, OPT.IGNORA)

			Mapper.CreateMap<SerialScheme, CreateSerialSchemeViewModel>().Bidirectional();
			Mapper.CreateMap<SerialScheme, IndexSerialSchemeViewModel>();

			Mapper.CreateMap<Numbering, CreateNumberingViewModel>().ForMember(dest => dest.TempSerialSchemaList, opt => opt.Ignore()).ForMember(dest => dest.FinalSerialSchemaList, opt => opt.Ignore());

			Mapper.CreateMap<CreateNumberingViewModel, Numbering>().ForMember(dest => dest.ID, opt => opt.Ignore()).ForMember(dest => dest.LastTempSerial, opt => opt.Ignore()).ForMember(dest => dest.LastFinalSerial, opt => opt.Ignore()).ForMember(dest => dest.FinalSerialSchema, opt => opt.Ignore()).ForMember(dest => dest.TempSerialSchema, opt => opt.Ignore());

			Mapper.CreateMap<Numbering, EditNumberingViewModel>().ForMember(dest => dest.FinalSerialSchemaList, opt => opt.Ignore()).ForMember(dest => dest.TempSerialSchemaList, opt => opt.Ignore());
			Mapper.CreateMap<EditNumberingViewModel, Numbering>().ForMember(dest => dest.LastFinalSerial, opt => opt.Ignore()).ForMember(dest => dest.LastTempSerial, opt => opt.Ignore()).ForMember(dest => dest.FinalSerialSchema, opt => opt.Ignore()).ForMember(dest => dest.TempSerialSchema, opt => opt.Ignore());

			Mapper.CreateMap<Numbering, IndexNumberingViewModel>().ForMember(dest => dest.FinalSerialSchema, opt => opt.MapFrom(source => source.FinalSerialSchema.Description)).ForMember(dest => dest.TempSerialSchema, opt => opt.MapFrom(source => source.TempSerialSchema.Description));

			Mapper.CreateMap<Customer, ViewModels.Customers.IndexCustomerGridViewModel>();

			Mapper.CreateMap<ViewModels.Customers.CreateCustomerViewModel, Customer>().ForMember(dest => dest.ID, opt => opt.Ignore()).ForMember(dest => dest.Addresses, opt => opt.Ignore()).ForMember(dest => dest.CreationDate, opt => opt.Ignore()).ForMember(dest => dest.DisableDate, opt => opt.Ignore()).ForMember(dest => dest.EnableDate, opt => opt.Ignore());

			Mapper.CreateMap<ViewModels.Customers.EditCustomerViewModel, Customer>().ForMember(dest => dest.Addresses, opt => opt.Ignore()).ForMember(dest => dest.CreationDate, opt => opt.Ignore()).ForMember(dest => dest.DisableDate, opt => opt.Ignore()).ForMember(dest => dest.EnableDate, opt => opt.Ignore()).Bidirectional();

			Mapper.CreateMap<ViewModels.ManifacturerModels.CreateManifacturerModelViewModel, ManifacturerModel>().ForMember(dest => dest.ID, opt => opt.Ignore()).ForMember(dest => dest.Services, opt => opt.Ignore()).ForMember(dest => dest.Manifacturer, opt => opt.Ignore());

			Mapper.CreateMap<ViewModels.ManifacturerModels.EditManifacturerModelViewModel, ManifacturerModel>().ForMember(dest => dest.Services, opt => opt.Ignore()).ForMember(dest => dest.Manifacturer, opt => opt.Ignore());

			Mapper.CreateMap<ViewModels.ThermalUnits.CreateThermalUnitViewModel, ThermalUnit>().ForMember(dest => dest.ID, opt => opt.Ignore()).ForMember(dest => dest.DismissDate, opt => opt.Ignore()).ForMember(dest => dest.Manifacturer, opt => opt.Ignore()).ForMember(dest => dest.Model, opt => opt.Ignore()).ForMember(dest => dest.Fuel, opt => opt.Ignore()).ForMember(dest => dest.HeatTransferFluid, opt => opt.Ignore()).ForMember(dest => dest.Heaters, opt => opt.Ignore());

			Mapper.CreateMap<ViewModels.Heaters.CreateHeaterViewModel, Heater>().ForMember(dest => dest.ID, opt => opt.Ignore()).ForMember(dest => dest.DismissDate, opt => opt.Ignore()).ForMember(dest => dest.Fuel, opt => opt.Ignore()).ForMember(dest => dest.Manifacturer, opt => opt.Ignore()).ForMember(dest => dest.ThermalUnit, opt => opt.Ignore()).ForMember(dest => dest.Model, opt => opt.Ignore());

			Mapper.CreateMap<ViewModels.PlantServices.CreatePlantServiceViewModel, PlantService>().ForMember(dest => dest.ID, opt => opt.Ignore());
			//.ForMember(Function(dest) dest.Plant, Sub(opt) opt.Ignore())

			Mapper.CreateMap<ViewModels.WorkActions.CreateWorkActionViewModel, WorkAction>().ForMember(dest => dest.ID, opt => opt.Ignore()).ForMember(dest => dest.AssignedOperator, opt => opt.Ignore()).ForMember(dest => dest.Operation, opt => opt.Ignore()).ForMember(dest => dest.Plant, opt => opt.Ignore()).ForMember(dest => dest.Type, opt => opt.Ignore());

			Mapper.CreateMap<ViewModels.Plants.CreatePlantViewModel, PlantBuilding>();

			Mapper.CreateMap<ViewModels.Plants.CreatePlantViewModel, Plant>().ForMember(dest => dest.ID, opt => opt.Ignore()).ForMember(dest => dest.PlantClass, opt => opt.Ignore()).ForMember(dest => dest.PlantDistinctCode, opt => opt.Ignore()).ForMember(dest => dest.PlantType, opt => opt.Ignore()).ForMember(dest => dest.Service, opt => opt.Ignore()).ForMember(dest => dest.ThermalUnit, opt => opt.Ignore()).ForMember(dest => dest.Media, opt => opt.Ignore()).ForMember(dest => dest.Contacts, opt => opt.Ignore()).ForMember(dest => dest.BuildingAddress, opt => opt.MapFrom(src => Mapper.Map<ViewModels.Plants.CreatePlantViewModel, PlantBuilding>(src)));

			Mapper.CreateMap<ViewModels.Plants.AddContactPlantViewModel, Address>().ForMember(dest => dest.ID, opt => opt.Ignore()).ForMember(dest => dest.AddressType, opt => opt.Ignore()).ForMember(dest => dest.State, opt => opt.Ignore());


			Mapper.CreateMap<ViewModels.Plants.AddContactPlantViewModel, Contact>().ForMember(dest => dest.ID, opt => opt.Ignore()).ForMember(dest => dest.Address, opt => opt.MapFrom(src => Mapper.Map<ViewModels.Plants.AddContactPlantViewModel, Address>(src)));

			Mapper.CreateMap<ViewModels.Plants.AddThermInfoPlantViewModel, PlantBuilding>().ForMember(dest => dest.Address, opt => opt.Ignore()).ForMember(dest => dest.Apartment, opt => opt.Ignore()).ForMember(dest => dest.Area, opt => opt.Ignore()).ForMember(dest => dest.Building, opt => opt.Ignore()).ForMember(dest => dest.City, opt => opt.Ignore()).ForMember(dest => dest.District, opt => opt.Ignore()).ForMember(dest => dest.PostalCode, opt => opt.Ignore()).ForMember(dest => dest.Stair, opt => opt.Ignore()).ForMember(dest => dest.StreetNumber, opt => opt.Ignore()).ForMember(dest => dest.Zone, opt => opt.Ignore());

			Mapper.CreateMap<PlantBuilding, ViewModels.Plants.DetailsIdentifyPlantViewModel>().ForMember(dest => dest.ID, opt => opt.Ignore()).ForMember(dest => dest.Name, opt => opt.Ignore()).ForMember(dest => dest.PlantDistinctCode, opt => opt.Ignore());

			Mapper.CreateMap<Plant, ViewModels.Plants.DetailsIdentifyPlantViewModel>().ForMember(dest => dest.Address, opt => opt.Ignore()).ForMember(dest => dest.Apartment, opt => opt.Ignore()).ForMember(dest => dest.Area, opt => opt.Ignore()).ForMember(dest => dest.Building, opt => opt.Ignore()).ForMember(dest => dest.City, opt => opt.Ignore()).ForMember(dest => dest.District, opt => opt.Ignore()).ForMember(dest => dest.PostalCode, opt => opt.Ignore()).ForMember(dest => dest.Stair, opt => opt.Ignore()).ForMember(dest => dest.StreetNumber, opt => opt.Ignore()).ForMember(dest => dest.Zone, opt => opt.Ignore());

			Mapper.CreateMap<Plant, ViewModels.Plants.DetailsThermalPlantViewModel>().ForMember(dest => dest.FirstStartUp, opt => opt.Ignore()).ForMember(dest => dest.Fuel, opt => opt.Ignore()).ForMember(dest => dest.HeatTransferFluid, opt => opt.Ignore()).ForMember(dest => dest.InstallationDate, opt => opt.Ignore()).ForMember(dest => dest.Kind, opt => opt.Ignore()).ForMember(dest => dest.Manifacturer, opt => opt.Ignore()).ForMember(dest => dest.Model, opt => opt.Ignore()).ForMember(dest => dest.NominalThermalPowerMax, opt => opt.Ignore()).ForMember(dest => dest.PlantClass, opt => opt.MapFrom(src => src.PlantClass.Name)).ForMember(dest => dest.PlantType, opt => opt.MapFrom(src => src.PlantType.Name)).ForMember(dest => dest.SerialNumber, opt => opt.Ignore()).ForMember(dest => dest.ThermalEfficiencyPowerMax, opt => opt.Ignore()).ForMember(dest => dest.Warranty, opt => opt.Ignore()).ForMember(dest => dest.WarrantyExpiration, opt => opt.Ignore()).ForMember(dest => dest.IsSingleUnit, opt => opt.Ignore()).ForMember(dest => dest.EnergyCategory, opt => opt.Ignore()).ForMember(dest => dest.GrossCooledVolumeM3, opt => opt.Ignore()).ForMember(dest => dest.GrossHeatedVolumeM3, opt => opt.Ignore());

			Mapper.CreateMap<PlantBuilding, ViewModels.Plants.DetailsThermalPlantViewModel>().ForMember(dest => dest.ID, opt => opt.Ignore()).ForMember(dest => dest.PlantClass, opt => opt.Ignore()).ForMember(dest => dest.PlantType, opt => opt.Ignore()).ForMember(dest => dest.Manifacturer, opt => opt.Ignore()).ForMember(dest => dest.Model, opt => opt.Ignore()).ForMember(dest => dest.SerialNumber, opt => opt.Ignore()).ForMember(dest => dest.InstallationDate, opt => opt.Ignore()).ForMember(dest => dest.FirstStartUp, opt => opt.Ignore()).ForMember(dest => dest.Warranty, opt => opt.Ignore()).ForMember(dest => dest.WarrantyExpiration, opt => opt.Ignore()).ForMember(dest => dest.Fuel, opt => opt.Ignore()).ForMember(dest => dest.HeatTransferFluid, opt => opt.Ignore()).ForMember(dest => dest.NominalThermalPowerMax, opt => opt.Ignore()).ForMember(dest => dest.ThermalEfficiencyPowerMax, opt => opt.Ignore()).ForMember(dest => dest.Kind, opt => opt.Ignore());


			Mapper.CreateMap<ThermalUnit, ViewModels.Plants.DetailsThermalPlantViewModel>().ForMember(dest => dest.EnergyCategory, opt => opt.Ignore()).ForMember(dest => dest.Fuel, opt => opt.MapFrom(src => src.Fuel.Name)).ForMember(dest => dest.GrossCooledVolumeM3, opt => opt.Ignore()).ForMember(dest => dest.GrossHeatedVolumeM3, opt => opt.Ignore()).ForMember(dest => dest.HeatTransferFluid, opt => opt.MapFrom(src => src.HeatTransferFluid.Name)).ForMember(dest => dest.ID, opt => opt.Ignore()).ForMember(dest => dest.IsSingleUnit, opt => opt.Ignore()).ForMember(dest => dest.Manifacturer, opt => opt.MapFrom(src => src.Manifacturer.Name)).ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Model.Model)).ForMember(dest => dest.PlantClass, opt => opt.Ignore()).ForMember(dest => dest.PlantType, opt => opt.Ignore());

			Mapper.CreateMap<Customer, ViewModels.Customers.IndexDataTableCustomerViewModel>();

			Mapper.CreateMap<Plant, ViewModels.Plants.IndexDataTablePlantViewModel>();

			Mapper.CreateMap<Product, ViewModels.Product.IndexDataTableProductViewModel>();


			Mapper.AssertConfigurationIsValid();
		}

	}
}
