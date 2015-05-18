Imports Heat.Models

<TestClass> _
Public Class ContextTests
    Dim mockCtx As New HeatDbContextMock

    <TestInitialize> _
    Public Sub FillContextWithCustomer()
        Dim c1 As New Customer
        Dim c2 As New Customer

        c1.ID = 982
        c1.Name = "Diego Brocchi"
        c1.Telephone1 = "331 1140448"

        c2.ID = 762
        c2.Name = "Antonio Paolini"
        c2.Telephone1 = "333 4568771"

        mockCtx.Customers.Add(c1)
        mockCtx.Customers.Add(c2)

    End Sub


    <TestMethod> _
    Public Sub GetCustomer()
        Dim result As Customer

        result = (From c In mockCtx.Customers
                  Where c.Name = "Diego Brocchi"
                  Select c).FirstOrDefault

        Assert.IsNotNull(result)
        Assert.AreEqual(982, result.ID)

    End Sub
End Class
