@modeltype models.customer
@Code
    ViewData("Title") = "Selezione cliente"
End Code

<div class="row ">
    <div class="col-md-12">
        <div class="panel panel-primary">

            <div class="panel-heading">
                <h3 class="panel-title">Seleziona un cliente</h3>
            </div>
            <div class="panel-body">
                <div class="form-horizontal">
                    @Using Html.BeginForm
                        @Html.AntiForgeryToken()

                        @Html.HiddenFor(Function(m) m.ID)

                        @<div class="col-md-4">
                            <div class="form-group">
                                @Html.LabelFor(Function(x) x.Name, htmlAttributes:=New With {.class = "control-label"})
                                <div class="input-group">
                                    @Html.EditorFor(Function(x) x.Name, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                                    <span class="input-group-btn">
                                        @Ajax.ActionLink("Cerca...", "CustomerSearch", "Customers", Nothing, New AjaxOptions With {.HttpMethod = "GET",
                                                                     .InsertionMode = InsertionMode.Replace,
                                                                     .OnBegin = "showCustomerSearchModal",
                                                                     .OnFailure = "searchFailed",
                                                                     .UpdateTargetId = "customerSearchResult"},
                                                                 New With {.class = "btn btn-primary", .data_toggle = "modal", .data_target = "#customerSearch"})
                                    </span>
                                </div>

                            </div>
                        </div>

                    End Using
                </div>

                <input type="submit" value="Conferma" class="btn btn-default" />
            </div>


        </div>

    </div>
</div>

    <!-- Modal -->
    <div class="modal" id="customerSearch" tabindex="-1" role="dialog">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title">Selezione cliente</h4>
                </div>
                <div class="modal-body">
                    <div id="customerSearchResult">

                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Chiudi</button>
                    <button type="button" class="btn btn-primary">Conferma</button>
                </div>
            </div>
        </div>
    </div>
