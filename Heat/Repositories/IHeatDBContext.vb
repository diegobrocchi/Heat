Imports System.Data.Entity
Imports Heat.Models

Public Interface IHeatDBContext
    Inherits IDisposable

    Property Customers As IDbSet(Of Customer)

End Interface
