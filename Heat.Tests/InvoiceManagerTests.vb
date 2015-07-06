Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Heat.Manager
Imports Heat.Models

<TestClass()> Public Class InvoiceManagerTests

    <TestMethod()> _
    Public Sub GetTemporaryDocument_CustomerID_ReturnsInvoice()
        Dim im As New InvoiceManager(New HeatDbContextMock)
        Dim r As Invoice = im.GetTemporaryDocument(23)

        Assert.IsInstanceOfType(r, GetType(Invoice))

    End Sub

End Class