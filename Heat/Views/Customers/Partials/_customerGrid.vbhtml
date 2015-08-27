@modeltype IEnumerable(Of Heat.ViewModels.Customers.IndexCustomerGridViewModel)


<table id="index_table" class="table table-bordered table-hover table-striped">
    <thead>
        <tr>
            <th class="col-md-3">
                @Html.DisplayNameFor(Function(model) model.Name)
            </th>
            <th class="col-md-2">
                @Html.DisplayNameFor(Function(model) model.Address)
            </th>
            <th class="col-md-3">
                @Html.DisplayNameFor(Function(model) model.City)
            </th>
            <th class="col-md-1">
                @Html.DisplayNameFor(Function(model) model.Telephone1)
            </th>
            <th class="col-md-1">
                @Html.DisplayNameFor(Function(model) model.Telephone2)
            </th>
            <th class="col-md-1">
            </th>
            <th class="col-md-1">
            </th>
        </tr>

    </thead>
    <tbody>


        @For Each item In Model

            @<tr class=@Iif(item.IsEnabled,"","danger")>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.Name)
                </td>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.Address)
                </td>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.City)
                </td>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.Telephone1)
                </td>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.Telephone2)
                </td>
                <td>
                    @*@Html.ActionLink("Modifica", "Edit", New With {.id = item.ID}, New With {.class = "btn btn-primary btn-sm"})*@
                    @*@Html.ActionLink("Dettagli", "Details", New With {.id = item.ID}, New With {.class = "btn btn-primary btn-sm"})*@
                    <!-- Single button -->
                    <div class="btn-group">
                        <button type="button" class="btn btn-primary btn-sm dropdown-toggle " data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                            Azioni <span class="caret"></span>
                        </button>
                        <ul class="dropdown-menu">
                            <li>@Html.ActionLink("Modifica", "Edit", New With {.ID = item.ID}, Nothing)</li>
                            <li>@Html.ActionLink("Dettagli", "Details", New With {.ID = item.ID}, Nothing)</li>
                            <li role="separator" class="divider"></li>
                            @code
                            If item.IsEnabled Then
                            @<li>@Html.ActionLink("Disabilita", "DisableCustomer", New With {.ID = item.ID}, Nothing)</li>
                            Else
                            @<li>@Html.ActionLink("Riabilita", "EnableCustomer", New With {.ID= item.ID}, Nothing)</li>
                            End If
                            End Code
                            <li>@Html.ActionLink("Elimina", "delete", New With {.ID = item.ID}, Nothing)</li>
                        </ul>
                    </div>
                </td>
                <td>
                    <!-- Single button -->
                    <div class="btn-group">
                        <button type="button" class="btn btn-primary btn-sm dropdown-toggle " data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                            Documenti <span class="caret"></span>
                        </button>
                        <ul class="dropdown-menu">
                            <li>@Html.ActionLink("Fattura", "create", "invoices", New With {.customerID = item.ID}, Nothing)</li>
                            <li>@Html.ActionLink("Preventivo", "create", "quotation", New With {.customerID = item.ID}, Nothing)</li>
                        </ul>
                    </div>
                </td>
            </tr>
        Next
    </tbody>

</table>

