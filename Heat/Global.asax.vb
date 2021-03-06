﻿Imports System.Web.Optimization
Imports System.Web.Helpers
Imports System.Security.Claims
Imports System.IdentityModel.Services
Imports AutoMapper
Imports Heat.Models
Imports System.Security.Principal

Public Class MvcApplication
    Inherits System.Web.HttpApplication

    Protected Sub Application_Start()
        AreaRegistration.RegisterAllAreas()
        FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters)
        RouteConfig.RegisterRoutes(RouteTable.Routes)
        BundleConfig.RegisterBundles(BundleTable.Bundles)

        'http://www.codeproject.com/Articles/639458/Claims-Based-Authentication-and-Authorization
        AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.Name

        'rimuove il motore di render per le pagine aspx
        ViewEngines.Engines.Clear()
        ViewEngines.Engines.Add(New RazorViewEngine())

        ModelBinders.Binders.Add(GetType(Decimal), New DecimalModelBinder())
        ModelBinders.Binders.Add(GetType(IPrincipal), New PrincipalModelBinder())

        DataTables.AspNet.Mvc5.Configuration.Register()

        DoAutomapperConfig()

    End Sub

    Private Sub DoAutomapperConfig()

        'Mapper.CreateMap(of SOURCE, DESTINATION).ForMember(UNA_PROPRIETA_NON_MAPPATA_DEL_DESTINATION, OPT.IGNORA)

        Mapper.CreateMap(Of SerialScheme, CreateSerialSchemeViewModel)().Bidirectional()
        Mapper.CreateMap(Of SerialScheme, IndexSerialSchemeViewModel)()

        Mapper.CreateMap(Of Numbering, CreateNumberingViewModel)().
            ForMember(Function(dest) dest.TempSerialSchemaList, Sub(opt) opt.Ignore()).
            ForMember(Function(dest) dest.FinalSerialSchemaList, Sub(opt) opt.Ignore())

        Mapper.CreateMap(Of CreateNumberingViewModel, Numbering)(). _
            ForMember(Function(dest) dest.ID, Sub(opt) opt.Ignore()). _
            ForMember(Function(dest) dest.LastTempSerial, Sub(opt) opt.Ignore()). _
            ForMember(Function(dest) dest.LastFinalSerial, Sub(opt) opt.Ignore()). _
            ForMember(Function(dest) dest.FinalSerialSchema, Sub(opt) opt.Ignore()). _
            ForMember(Function(dest) dest.TempSerialSchema, Sub(opt) opt.Ignore())

        Mapper.CreateMap(Of Numbering, EditNumberingViewModel)().ForMember(Function(dest) dest.FinalSerialSchemaList, Sub(opt) opt.Ignore()).ForMember(Function(dest) dest.TempSerialSchemaList, Sub(opt) opt.Ignore())
        Mapper.CreateMap(Of EditNumberingViewModel, Numbering)(). _
            ForMember(Function(dest) dest.LastFinalSerial, Sub(opt) opt.Ignore()). _
            ForMember(Function(dest) dest.LastTempSerial, Sub(opt) opt.Ignore()). _
            ForMember(Function(dest) dest.FinalSerialSchema, Sub(opt) opt.Ignore()). _
            ForMember(Function(dest) dest.TempSerialSchema, Sub(opt) opt.Ignore())

        Mapper.CreateMap(Of Numbering, IndexNumberingViewModel)(). _
            ForMember(Function(dest) dest.FinalSerialSchema, Sub(opt) opt.MapFrom(Function(source) source.FinalSerialSchema.Description)). _
            ForMember(Function(dest) dest.TempSerialSchema, Sub(opt) opt.MapFrom(Function(source) source.TempSerialSchema.Description))

        Mapper.CreateMap(Of Customer, ViewModels.Customers.IndexCustomerGridViewModel)()

        Mapper.CreateMap(Of ViewModels.Customers.CreateCustomerViewModel, Customer)() _
            .ForMember(Function(dest) dest.ID, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.Addresses, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.CreationDate, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.DisableDate, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.EnableDate, Sub(opt) opt.Ignore())

        Mapper.CreateMap(Of ViewModels.Customers.EditCustomerViewModel, Customer)() _
            .ForMember(Function(dest) dest.Addresses, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.CreationDate, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.DisableDate, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.EnableDate, Sub(opt) opt.Ignore()).Bidirectional()

        Mapper.CreateMap(Of ViewModels.ManifacturerModels.CreateManifacturerModelViewModel, ManifacturerModel)() _
            .ForMember(Function(dest) dest.ID, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.Services, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.Manifacturer, Sub(opt) opt.Ignore())

        Mapper.CreateMap(Of ViewModels.ManifacturerModels.EditManifacturerModelViewModel, ManifacturerModel)() _
            .ForMember(Function(dest) dest.Services, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.Manifacturer, Sub(opt) opt.Ignore())

        Mapper.CreateMap(Of ViewModels.ThermalUnits.CreateThermalUnitViewModel, ThermalUnit)() _
            .ForMember(Function(dest) dest.ID, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.DismissDate, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.Manifacturer, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.Model, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.Fuel, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.HeatTransferFluid, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.Heaters, Sub(opt) opt.Ignore())

        Mapper.CreateMap(Of ViewModels.Heaters.CreateHeaterViewModel, Heater) _
            .ForMember(Function(dest) dest.ID, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.DismissDate, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.Fuel, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.Manifacturer, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.ThermalUnit, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.Model, Sub(opt) opt.Ignore())

        Mapper.CreateMap(Of ViewModels.PlantServices.CreatePlantServiceViewModel, PlantService) _
            .ForMember(Function(dest) dest.ID, Sub(opt) opt.Ignore())
        '.ForMember(Function(dest) dest.Plant, Sub(opt) opt.Ignore())

        Mapper.CreateMap(Of ViewModels.WorkActions.CreateWorkActionViewModel, WorkAction) _
            .ForMember(Function(dest) dest.ID, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.AssignedOperator, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.Operation, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.Plant, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.Type, Sub(opt) opt.Ignore())

        Mapper.CreateMap(Of ViewModels.Plants.CreatePlantViewModel, PlantBuilding)()

        Mapper.CreateMap(Of ViewModels.Plants.CreatePlantViewModel, Plant) _
            .ForMember(Function(dest) dest.ID, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.PlantClass, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.PlantDistinctCode, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.PlantType, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.Service, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.ThermalUnit, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.Media, Sub(opt) opt.Ignore()) _
        .ForMember(Function(dest) dest.Contacts, Sub(opt) opt.Ignore()) _
        .ForMember(Function(dest) dest.BuildingAddress, Sub(opt) opt.MapFrom(Function(src) Mapper.Map(Of ViewModels.Plants.CreatePlantViewModel, PlantBuilding)(src)))

        Mapper.CreateMap(Of ViewModels.Plants.AddContactPlantViewModel, Address)() _
            .ForMember(Function(dest) dest.ID, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.AddressType, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.State, Sub(opt) opt.Ignore())


        Mapper.CreateMap(Of ViewModels.Plants.AddContactPlantViewModel, Contact) _
            .ForMember(Function(dest) dest.ID, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.Address, Sub(opt) opt.MapFrom(Function(src) Mapper.Map(Of ViewModels.Plants.AddContactPlantViewModel, Address)(src)))

        Mapper.CreateMap(Of ViewModels.Plants.AddThermInfoPlantViewModel, PlantBuilding) _
            .ForMember(Function(dest) dest.Address, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.Apartment, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.Area, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.Building, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.City, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.District, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.PostalCode, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.Stair, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.StreetNumber, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.Zone, Sub(opt) opt.Ignore())

        Mapper.CreateMap(Of PlantBuilding, ViewModels.Plants.DetailsIdentifyPlantViewModel)() _
            .ForMember(Function(dest) dest.ID, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.Name, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.PlantDistinctCode, Sub(opt) opt.Ignore())

        Mapper.CreateMap(Of Plant, ViewModels.Plants.DetailsIdentifyPlantViewModel)() _
            .ForMember(Function(dest) dest.Address, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.Apartment, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.Area, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.Building, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.City, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.District, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.PostalCode, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.Stair, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.StreetNumber, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.Zone, Sub(opt) opt.Ignore())

        Mapper.CreateMap(Of Plant, ViewModels.Plants.DetailsThermalPlantViewModel)() _
            .ForMember(Function(dest) dest.FirstStartUp, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.Fuel, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.HeatTransferFluid, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.InstallationDate, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.Kind, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.Manifacturer, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.Model, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.NominalThermalPowerMax, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.PlantClass, Sub(opt) opt.MapFrom(Function(src) src.PlantClass.Name)) _
            .ForMember(Function(dest) dest.PlantType, Sub(opt) opt.MapFrom(Function(src) src.PlantType.Name)) _
            .ForMember(Function(dest) dest.SerialNumber, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.ThermalEfficiencyPowerMax, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.Warranty, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.WarrantyExpiration, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.IsSingleUnit, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.EnergyCategory, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.GrossCooledVolumeM3, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.GrossHeatedVolumeM3, Sub(opt) opt.Ignore())

        Mapper.CreateMap(Of PlantBuilding, ViewModels.Plants.DetailsThermalPlantViewModel)() _
            .ForMember(Function(dest) dest.ID, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.PlantClass, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.PlantType, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.Manifacturer, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.Model, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.SerialNumber, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.InstallationDate, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.FirstStartUp, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.Warranty, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.WarrantyExpiration, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.Fuel, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.HeatTransferFluid, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.NominalThermalPowerMax, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.ThermalEfficiencyPowerMax, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.Kind, Sub(opt) opt.Ignore())


        Mapper.CreateMap(Of ThermalUnit, ViewModels.Plants.DetailsThermalPlantViewModel) _
            .ForMember(Function(dest) dest.EnergyCategory, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.Fuel, Sub(opt) opt.MapFrom(Function(src) src.Fuel.Name)) _
            .ForMember(Function(dest) dest.GrossCooledVolumeM3, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.GrossHeatedVolumeM3, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.HeatTransferFluid, Sub(opt) opt.MapFrom(Function(src) src.HeatTransferFluid.Name)) _
            .ForMember(Function(dest) dest.ID, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.IsSingleUnit, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.Manifacturer, Sub(opt) opt.MapFrom(Function(src) src.Manifacturer.Name)) _
            .ForMember(Function(dest) dest.Model, Sub(opt) opt.MapFrom(Function(src) src.Model.Model)) _
            .ForMember(Function(dest) dest.PlantClass, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.PlantType, Sub(opt) opt.Ignore())

        Mapper.CreateMap(Of Customer, ViewModels.Customers.IndexDataTableCustomerViewModel)()

        Mapper.CreateMap(Of Plant, ViewModels.Plants.IndexDataTablePlantViewModel)()

        Mapper.CreateMap(Of Product, ViewModels.Product.IndexDataTableProductViewModel)()


        Mapper.AssertConfigurationIsValid()
    End Sub

End Class
