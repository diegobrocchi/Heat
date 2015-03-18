Imports System.Web.Mvc

Namespace Controllers
    <Authorize> _
    Public Class SettingsController
        Inherits Controller

        ' GET: Settings
        Function Index() As ActionResult
            Return View()
        End Function


    End Class
End Namespace