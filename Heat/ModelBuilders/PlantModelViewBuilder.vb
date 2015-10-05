Imports Heat.Models
Imports Heat.ViewModels.Plants
Imports System.Data.Entity

Public Class PlantModelViewBuilder

    Private _db As IHeatDBContext

    Sub New(dbcontext As IHeatDBContext)
        _db = dbcontext
    End Sub

    'Function GetCreatePlantViewModel() As CreatePlantViewModel
    '    Dim result As New CreatePlantViewModel

    '    Return result
    'End Function

    Function GetAddContactPlantViewModel(plantID As Integer) As AddContactPlantViewModel
        Dim result As New AddContactPlantViewModel

        result.PlantID = plantID
        result.AddressTypeList = _db.AddressTypes.OrderBy(Function(x) x.Description).ToList.ToSelectListItems(Function(x) x.Description, Function(x) x.ID, "")

        Return result


    End Function

    Function GetAddThermInfoPlantViewModel(plantID As Integer) As AddThermInfoPlantViewModel
        Dim result As New AddThermInfoPlantViewModel

        result.PlantID = plantID
        result.PlantClassList = _db.PlantClasses.OrderBy(Function(x) x.Name).ToList.ToSelectListItems(Function(x) x.Name, Function(x) x.ID, "")
        result.PlantTypeList = _db.PlantTypes.OrderBy(Function(x) x.Name).ToList.ToSelectListItems(Function(x) x.Name, Function(x) x.ID, "")

        Return result

    End Function

    Function GetIndexPlantViewModel() As List(Of IndexPlantViewModel)
        Dim result As New List(Of IndexPlantViewModel)

        result = _db.Plants.Include(Function(x) x.BuildingAddress).OrderBy(Function(x) x.PlantDistinctCode) _
            .Select(Function(x) New IndexPlantViewModel With {.ID = x.ID,
                                                              .Address = x.BuildingAddress.Address & " " & x.BuildingAddress.City,
                                                              .Name = x.Name,
                                                              .PlantClass = x.PlantClass.Name,
                                                              .PlantType = x.PlantType.Name,
                                                              .PlantDistinctCode = x.PlantDistinctCode}).ToList

        Return result

    End Function

    ''' <summary>
    ''' Costruisce il modello per la vista di dettaglio dell'impianto.
    ''' La vista di dettaglio è organizzata in tab e in ogni tab una partial con un modello dedicato.
    ''' </summary>
    ''' <param name="id"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetDetailsPlantViewModel(id As Integer) As DetailsPlantViewModel
        Dim result As New DetailsPlantViewModel

        result.IdentifyViewModel = GetDetailsIdentifyPlantViewModel(id)
        result.ContactViewModel = GetDetailsContactPlantViewModel(id)
        result.ThermalViewModel = GetDetailsThermalPlantViewModel(id)
        result.MediaViewModel = GetDetailsMediaPlantViewModel(id)
        result.ServiceViewModel = GetDetailsServicePlantViewModel(id)

        Return result
    End Function

    Function GetDetailsIdentifyPlantViewModel(id As Integer) As DetailsIdentifyPlantViewModel
        Dim result As New DetailsIdentifyPlantViewModel

        Dim p As Plant
        Dim pb As PlantBuilding

        p = _db.Plants.Find(id)
        pb = p.BuildingAddress

        'Map Plant --> DetailsIdentifyPlantViewModel
        'aggiorna le proprietà dell'oggetto di destinazione (result)
        AutoMapper.Mapper.Map(Of Plant, DetailsIdentifyPlantViewModel)(p, result)

        'Map PlantBuilding --> DetailsIdentifyPlantViewModel
        'aggiorna le proprietà dell'oggetto di destinazione (result)
        AutoMapper.Mapper.Map(Of PlantBuilding, DetailsIdentifyPlantViewModel)(pb, result)

        Return result
    End Function

    Function GetDetailsContactPlantViewModel(id As Integer) As DetailsContactPlantViewModel
        Dim result As New DetailsContactPlantViewModel
        Dim cl As List(Of Contact)
        cl = _db.Plants.Include(Function(p) p.Contacts.Select(Function(c) c.Address)).Where(Function(x) x.ID = id).First.Contacts

        'Map Plant --> DetailsContactPlantViewModel
        result.ID = id
        result.Contacts = cl

        Return result
    End Function

    Function GetDetailsThermalPlantViewModel(id As Integer) As DetailsThermalPlantViewModel
        Dim result As New DetailsThermalPlantViewModel
        Dim p As Plant
        Dim pb As PlantBuilding
        Dim tu As ThermalUnit

        p = _db.Plants _
            .Include(Function(x) x.ThermalUnit) _
            .Include(Function(x) x.ThermalUnit.Manifacturer) _
            .Include(Function(x) x.ThermalUnit.Model) _
            .Include(Function(x) x.ThermalUnit.Fuel) _
            .Include(Function(x) x.ThermalUnit.HeatTransferFluid) _
            .Where(Function(x) x.ID = id) _
            .First()

        pb = p.BuildingAddress
        tu = p.ThermalUnit

        'Map Plant --> DetailsThermalPlantViewModel
        AutoMapper.Mapper.Map(Of Plant, DetailsThermalPlantViewModel)(p, result)

        'Map PlantBuilding --> DetailsThermalPlantViewModel
        AutoMapper.Mapper.Map(Of PlantBuilding, DetailsThermalPlantViewModel)(pb, result)

        'Map ThermalUnit --> DetailsThermaPlantViewModel
        AutoMapper.Mapper.Map(Of ThermalUnit, DetailsThermalPlantViewModel)(tu, result)

        Return result
    End Function

    Function GetDetailsMediaPlantViewModel(id As Integer) As DetailsMediaPlantViewModel
        Dim result As New DetailsMediaPlantViewModel
        Dim p As Plant

        p = _db.Plants.Include(Function(x) x.Media).Where(Function(x) x.ID = id).First

        result.ID = id
        result.Media = p.Media

        result.BaseHref = ConfigurationManager.AppSettings("MediaPlantFolder")
        Return result

    End Function

    Function GetDetailsServicePlantViewModel(id As Integer) As DetailsServicePlantViewModel
        Dim result As New DetailsServicePlantViewModel
        Dim ps As PlantService

        ps = _db.Plants.Include(Function(x) x.Service).Where(Function(x) x.ID = id).First.Service

        If Not IsNothing(ps) Then

            result.ID = ps.ID
            result.PlantID = id
            result.LegalExpirationDate = ps.LegalExpirationDate
            result.Periodicity = ps.Periodicity
            result.PlannedServiceDate = ps.PlannedServiceDate
            result.PreviousServiceDate = ps.PreviousServiceDate

        End If

        Return result
    End Function
    Function GetManagePlantViewModel(id As Integer) As ManagePlantViewModel
        Dim result As New ManagePlantViewModel
        Dim p As Plant

        p = _db.Plants.Find(id)

        result.ID = id
        result.Name = p.Name

        Return result
    End Function
End Class
