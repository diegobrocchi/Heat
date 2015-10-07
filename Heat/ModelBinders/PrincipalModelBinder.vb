Imports System.Security.Principal

Public Class PrincipalModelBinder
    Implements IModelBinder

    Public Function BindModel(controllerContext As ControllerContext, bindingContext As ModelBindingContext) As Object Implements IModelBinder.BindModel
        If IsNothing(controllerContext) Then
            Throw New ArgumentNullException("ControllerContext!")
        End If
        If IsNothing(bindingContext) Then
            Throw New ArgumentNullException("BindingContext!")
        End If

        Dim p As IPrincipal = controllerContext.HttpContext.User
        Return p

    End Function
End Class
