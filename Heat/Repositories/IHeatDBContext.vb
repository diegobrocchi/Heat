Imports System.Data.Entity
Imports Heat.Models

Public Interface IHeatDBContext
    Inherits IDisposable

    Property Customers As DbSet(Of Customer)


    Function SaveChanges() As Integer


End Interface
