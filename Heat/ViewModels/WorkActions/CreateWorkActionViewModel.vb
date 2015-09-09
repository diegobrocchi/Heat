Imports System.ComponentModel.DataAnnotations

Namespace ViewModels.WorkActions
    Public Class CreateWorkActionViewModel

        <Display(name:="Impianto")> _
        Property PlantID As Integer
        <Display(name:="Riferita all'impianto")> _
        Property PlantDescription As String
        Property PlantList As IEnumerable(Of SelectListItem)
        Property PlantIDSelected As Boolean

        <Display(name:="Data di esecuzione")> _
        <DataType(DataType.Date)> _
        <DisplayFormat(DataFormatString:="{0:yyyy-MM-dd}", ApplyFormatInEditMode:=True)> _
        Property ActionDate As DateTime

        <Display(name:="Tipo di operazione")> _
        Property OperationID As Integer
        Property OperationList As IEnumerable(Of SelectListItem)

        <Display(name:="Operatore assegnato")> _
        Property AssignedOperatorID As Integer
        Property AssignedOperatorList As IEnumerable(Of SelectListItem)

        <Display(name:="Tipo di operazione")> _
        Property TypeID As Integer
        Property TypeList As IEnumerable(Of SelectListItem)

    End Class
End Namespace

