Imports Microsoft.AspNet.Identity.EntityFramework
Imports Microsoft.AspNet.Identity
Imports log4net

Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Private _logger As ILog

    Sub New()
        _logger = LogManager.GetLogger(GetType(HomeController))
    End Sub

    Function Index() As ActionResult
        _logger.Debug("Index function entered")
        Return View()
    End Function

    Function About() As ActionResult
        ViewData("Message") = "Your application description page."

        Return View()
    End Function

    Function Contact() As ActionResult
        ViewData("Message") = "Your contact page."

        Return View()
    End Function

    Function test() As ActionResult
        Return View()
    End Function
End Class
