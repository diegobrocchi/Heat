Imports System.ComponentModel.DataAnnotations

Namespace ViewModels.Plants
    Public Class AddThermInfoPlantViewModel

        Property PlantID As Integer

        <Display(name:="Classe impianto")> _
        Property PlantClassID As Integer
        Property PlantClassList As IEnumerable(Of SelectListItem)

        <Display(name:="Tipologia impianto")> _
        Property PlantTypeID As Integer
        Property PlantTypeList As IEnumerable(Of SelectListItem)


        <Display(name:="Codice dell'impianto per la provincia")> _
        Property PlantDistinctCode As String


        <Display(name:="Singola unità abitativa")> _
        Property IsSingleUnit As Boolean

        <Display(name:="Categoria energetica")> _
        Property EnergyCategory As EnergyCategoryEnum

        <Display(name:="Volume lordo riscaldato (m³)")> _
        Property GrossHeatedVolumeM3 As Single

        <Display(name:="Volume lordo raffrescato (m³)")> _
        Property GrossCooledVolumeM3 As Single
    End Class
End Namespace

