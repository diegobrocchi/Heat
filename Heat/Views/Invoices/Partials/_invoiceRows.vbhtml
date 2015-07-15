@modeltype Models.InvoiceRow

@Html.HiddenFor(Function(m) m.Invoice.ID)

@Html.DisplayFor(Function(m) m.Product.Description)

