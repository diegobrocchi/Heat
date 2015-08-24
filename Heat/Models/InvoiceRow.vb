Namespace Models
    Public MustInherit Class InvoiceRow
        Property ID As Integer
        Property Invoice As Invoice
        Property RowID As Integer
        Property ItemOrder As Integer
        'Property Product As Product
        Property Quantity As Double
        Property UnitPrice As Decimal
        Property VAT_Rate As Double
        Property RateDiscount1 As Decimal
        Property RateDiscount2 As Decimal
        Property RateDiscount3 As Decimal

        ''' <summary>
        ''' Totale LORDO nominale: prezzo unitario * quantità
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property GrossAmount As Decimal
            Get
                Return UnitPrice * Quantity
            End Get
        End Property
        ''' <summary>
        ''' Totale IMPONIBILE: LORDO - SCONTI
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property DiscountedAmount As Decimal
            Get
                Dim discountAmount1 As Decimal
                Dim discountAmount2 As Decimal
                Dim discountAmount3 As Decimal

                discountAmount1 = GrossAmount * RateDiscount1 / 100
                Dim partial1 As Decimal

                partial1 = GrossAmount - discountAmount1

                discountAmount2 = partial1 * RateDiscount2 / 100
                Dim partial2 As Decimal

                partial2 = GrossAmount - discountAmount1 - discountAmount2

                discountAmount3 = partial2 * RateDiscount3 / 100

                Return GrossAmount - discountAmount1 - discountAmount2 - discountAmount3

            End Get
        End Property

        ''' <summary>
        ''' Importo dell'IVA.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property TaxAmount As Decimal
            Get
                Return DiscountedAmount * VAT_Rate / 100
            End Get
        End Property
        ''' <summary>
        ''' Importo TOTALE.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property TotalAmount As Decimal
            Get
                Return DiscountedAmount + TaxAmount
            End Get
        End Property
    End Class

End Namespace

