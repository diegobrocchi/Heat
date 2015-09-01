Imports Heat.ViewModels.PlantServices

Public Class PlantServiceModelViewBuilder

    Private _db As IHeatDBContext

    Sub New(dbContext As IHeatDBContext)
        _db = dbContext
    End Sub

    Public Function GetCreatePlantServiceViewModel(plantID As Integer) As CreatePlantServiceViewModel
        Dim result As New CreatePlantServiceViewModel

        result.PlantID = plantID
        result.PlantDescription = _db.Plants.Find(plantID).Name

        Return result

    End Function

End Class
