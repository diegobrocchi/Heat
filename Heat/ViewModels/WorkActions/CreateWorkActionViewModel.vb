Imports System.ComponentModel.DataAnnotations

Namespace ViewModels.WorkActions
    Public Class CreateWorkActionViewModel

        Property PlantID As Integer
        <Display(name:="Riferita all'impianto")> _
        Property PlantDescription As String

        <Display(name:="Data di esecuzione")> _
        <DataType(DataType.Date)> _
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

