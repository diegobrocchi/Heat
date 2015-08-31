Imports Heat.Models
Public Class PlantModelViewBuilder

    Private _db As IHeatDBContext

    Sub New(dbcontext As IHeatDBContext)
        _db = dbcontext
    End Sub

End Class
