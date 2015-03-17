Imports System.Web.Mvc

Namespace Controllers
    Public Class SearchController
        Inherits Controller

        <HttpPost> _
        Function Index(searchquery As String, fromcontroller As String) As ActionResult
            Select Case fromcontroller
                Case "Customers"
                    ViewBag.message = "Search results for " & searchquery & " in Customers"
                Case "PlantClasses"
                    ViewBag.message = "Search results for " & searchquery & " in  PlantClasses"
                Case "Plants"
                    ViewBag.message = "Search results for " & searchquery & " in  Plant"
                Case "PlantTypes"
                    ViewBag.message = "Search results for " & searchquery & " in  PlantTypes"

            End Select
            Return View()
        End Function
    End Class
End Namespace