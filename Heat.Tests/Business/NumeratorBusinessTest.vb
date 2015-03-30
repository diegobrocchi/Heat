Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Heat.Business
Imports System.Web.Mvc
Imports Heat.Repositories

<TestClass()>
Public Class NumeratorBusinessTest

    <TestMethod> _
    Public Sub GetNext_ReturnsNext()
        Dim n As New Numerator
        Dim db As New HeatDBContext

        n.Code = "ABCD"
        n.Description = "ambaraba"
        n.LastValue = 0

        db.Numerators.Add(n)
        db.SaveChanges()

        Assert.IsTrue(NumeratorManager.GetNext(n) > 0)

        db.Numerators.Remove(n)
        db.SaveChanges()




    End Sub

End Class
