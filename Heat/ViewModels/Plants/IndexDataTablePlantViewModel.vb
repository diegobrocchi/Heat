Namespace ViewModels.Plants
    ''' <summary>
    ''' Modello che viene mostrato nel datatable jQuery.
    ''' E' un subset di Plant e contiene solo le proprietà da mostrare.
    ''' </summary>
    Public Class IndexDataTablePlantViewModel
        Property ID As Integer
        Property Name As String
        'Property PlantClass As String
        'Property PlantType As String
        Property PlantDistinctCode As String
    End Class
End Namespace

