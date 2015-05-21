Imports System.Data.Entity
Imports Heat.Models

Public Interface IHeatDBContext
    Inherits IDisposable

    Property Customers As DbSet(Of Customer)
    Property Numberings As DbSet(Of Numbering)
    Property SerialSchemes As DbSet(Of SerialScheme)


    Function SaveChanges() As Integer


End Interface
