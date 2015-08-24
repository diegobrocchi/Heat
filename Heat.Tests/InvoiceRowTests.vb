Imports Heat.Models
<TestClass> _
Public Class InvoiceRowTests
    <TestMethod> _
    Public Sub DiscountedAmount_NoDiscountSet_ReturnsGrossAmount()
        Dim ir As New ProductInvoiceRow
        ir.UnitPrice = 100
        ir.Quantity = 2

        Assert.AreEqual(ir.GrossAmount, ir.DiscountedAmount)

    End Sub

    <TestMethod> _
    Public Sub DiscountedAmount_OneDiscountSet_ReturnsValue()
        Dim ir As New ProductInvoiceRow
        ir.UnitPrice = 100
        ir.Quantity = 3
        ir.RateDiscount1 = 10

        Assert.AreEqual(270D, ir.DiscountedAmount)
    End Sub

    <TestMethod> _
    Public Sub DiscountedAmount_TwoDiscountSet_returnsValue()
        Dim ir As New ProductInvoiceRow
        ir.UnitPrice = 100
        ir.Quantity = 1
        ir.RateDiscount1 = 10
        ir.RateDiscount2 = 10

        Assert.AreEqual(81D, ir.DiscountedAmount)

    End Sub

    <TestMethod> _
    Public Sub DiscountedAmount_threeDiscountSet_ReturnsValue()
        Dim ir As New ProductInvoiceRow
        ir.UnitPrice = 100
        ir.Quantity = 1
        ir.RateDiscount1 = 10
        ir.RateDiscount2 = 5
        ir.RateDiscount3 = 1

        Assert.AreEqual(84.645D, ir.DiscountedAmount)
    End Sub

    <TestMethod> _
    Public Sub TaxAmount_NoVat_ReturnsZero()
        Dim ir As New ProductInvoiceRow
        ir.UnitPrice = 100
        ir.Quantity = 42
        ir.RateDiscount1 = 10
        ir.RateDiscount2 = 2
        ir.RateDiscount3 = 0

        Assert.AreEqual(0D, ir.TaxAmount)
    End Sub

    <TestMethod> _
    Public Sub TaxAmount_VatSet_ReturnsValue()
        Dim ir As New ProductInvoiceRow
        ir.UnitPrice = 100
        ir.Quantity = 1
        ir.VAT_Rate = 9

        Assert.AreEqual(9D, ir.TaxAmount)
    End Sub

    <TestMethod> _
    Public Sub TotalAmount_NoVat_ReturnSameAsDiscounted()
        Dim ir As New ProductInvoiceRow
        ir.UnitPrice = 100
        ir.RateDiscount1 = 10
        ir.RateDiscount2 = 5
        ir.RateDiscount3 = 1

        Assert.AreEqual(ir.DiscountedAmount, ir.TotalAmount)
    End Sub

    <TestMethod> _
    Public Sub TotalAmount_VatSet_returnsValue()
        Dim ir As New ProductInvoiceRow
        ir.UnitPrice = 100
        ir.Quantity = 3
        ir.RateDiscount1 = 10
        ir.RateDiscount2 = 5
        ir.RateDiscount3 = 3
        ir.VAT_Rate = 20

        Assert.AreEqual(298.566D, ir.TotalAmount)
    End Sub
End Class
