Imports Heat.ViewModels.WorkActions

Public Class WorkActionModelViewBuilder
    Private _db As IHeatDBContext

    Sub New(dbContext As IHeatDBContext)
        _db = dbContext
    End Sub

    Function GetCreateWorkActionViewModel(plantID As Integer) As CreateWorkActionViewModel
        Dim result As New CreateWorkActionViewModel

        result.PlantID = plantID
        result.ActionDate = Now

        BindSelectListItems(result)
        
        Return result
    End Function

    ''' <summary>
    ''' Crea le associazioni delle proprietà con le liste delle opzioni tra cui l'utente sceglie.
    ''' E' necessario ricreare le liste di SelectListItem per le SelectList, dopo il POST.
    ''' </summary>
    ''' <param name="model"></param>
    ''' <remarks></remarks>
    Sub BindSelectListItems(model As CreateWorkActionViewModel)

        model.TypeList = _db.ActionTypes.OrderBy(Function(x) x.Description).ToList.ToSelectListItems(Function(x) x.Description, Function(x) x.ID, model.TypeID)
        model.OperationList = _db.Operations.OrderBy(Function(x) x.Description).ToList.ToSelectListItems(Function(x) x.Description, Function(x) x.ID, model.OperationID)
        model.AssignedOperatorList = _db.WorkOperators.OrderBy(Function(x) x.Name).ToList.ToSelectListItems(Function(x) x.Name, Function(x) x.ID, model.AssignedOperatorID)

    End Sub
End Class
