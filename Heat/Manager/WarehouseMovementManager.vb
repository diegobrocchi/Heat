Imports Heat.Models

Public Class WarehouseMovementManager
    Private _db As IHeatDBContext

    Public Sub New(db As IHeatDBContext)
        _db = db
    End Sub

    ''' <summary>
    ''' Inserisce un movimento di magazzino
    ''' </summary>
    ''' <param name="wareMov"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Insert(wareMov As WarehouseMovement) As Boolean
        'controlla se il movimento è di prelievo o di versamento.
        'se è di prelievo controlla se il magazzino richiede la verifica della giacenza.
        If wareMov.CausalWarehouse.Type = CausalWarehouseTypeEnum.Prelievo And wareMov.Source.CheckStockBefore Then
            Dim InStock As Decimal
            InStock = _db.WarehouseMovement.Where(Function(x) x.Product.Equals(wareMov.Product)).Where(Function(x) x.Source.Equals(wareMov.Source)).Sum(Function(m) m.Quantity)
            If InStock > wareMov.Quantity Then
                _db.WarehouseMovement.Add(wareMov)
                Return True
            Else
                Return False
            End If
        Else
            _db.WarehouseMovement.Add(wareMov)
            Return True
        End If
    End Function

    
End Class
