''' <summary>
''' Rappresenta una causale di movimento di magazzino.
''' </summary>
''' <remarks></remarks>
Public Class CausalWarehouse
    Property ID As Integer
    Property Code As String
    Property Sign As Integer
    Property Type As CausalWarehouseGroup
    Property Transaction As Boolean
End Class
