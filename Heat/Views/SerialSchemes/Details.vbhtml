@ModelType Heat.createSerialSchemeviewmodel
@Code
    ViewData("Title") = "Details"
End Code

<div class="page-header">
    <h1>
        Dettagli dello schema di numerazione
    </h1>

</div>

<div>
    
    <div class="panel panel-default">
        <div class="panel-heading">
        <div class="panel-title">
            Schema di numerazione
        </div>
        </div>
        <div class="panel-body">
            <div class="list-group">
                <div class="list-group-item">
                    <dl class="dl-horizontal ">
                        <dt>
                            @Html.DisplayNameFor(Function(model) model.Name)
                        </dt>
                        <dd>
                            @Html.DisplayFor(Function(model) model.Name)
                        </dd>
                    </dl>
                    
                </div>
                <div class="list-group-item">
                    <dl class="dl-horizontal ">
                        <dt>
                            @Html.DisplayNameFor(Function(model) model.Description)
                        </dt>
                        <dd>
                            @Html.DisplayFor(Function(model) model.Description)
                        </dd>
                    </dl>

                </div>
                <div class="list-group-item">
                    <dl class="dl-horizontal ">
                        <dt>
                            @Html.DisplayNameFor(Function(model) model.InitialValue)
                        </dt>

                        <dd>
                            @Html.DisplayFor(Function(model) model.InitialValue)
                        </dd>
                    </dl>
                    
                </div>
                <div class="list-group-item">
                    <dl class="dl-horizontal ">
                        <dt>
                            @Html.DisplayNameFor(Function(model) model.Increment)
                        </dt>

                        <dd>
                            @Html.DisplayFor(Function(model) model.Increment)
                        </dd>
                    </dl>

                </div>
                <div class="list-group-item">
                    <dl class="dl-horizontal ">
                        <dt>
                            @Html.DisplayNameFor(Function(model) model.MinValue)
                        </dt>

                        <dd>
                            @Html.DisplayFor(Function(model) model.MinValue)
                        </dd>
                    </dl>

                </div>
                <div class="list-group-item">
                    <dl class="dl-horizontal ">

                        <dt>
                            @Html.DisplayNameFor(Function(model) model.MaxValue)
                        </dt>

                        <dd>
                            @Html.DisplayFor(Function(model) model.MaxValue)
                        </dd>

                    </dl>

                </div>
                <div class="list-group-item">
                    <dl class="dl-horizontal ">
                        <dt>
                            @Html.DisplayNameFor(Function(model) model.FormatMask)
                        </dt>

                        <dd>
                            @Html.DisplayFor(Function(model) model.FormatMask)
                        </dd>
                    </dl>

                </div>
                <div class="list-group-item">
                    <dl class="dl-horizontal ">
                        <dt>
                            @Html.DisplayNameFor(Function(model) model.ExpiryDate)
                        </dt>

                        <dd>
                            @Html.DisplayFor(Function(model) model.ExpiryDate)
                        </dd>
                    </dl>

                </div>
                <div class="list-group-item">
                    <dl class="dl-horizontal ">
                        <dt>
                            @Html.DisplayNameFor(Function(model) model.RecycleWhenExpired)
                        </dt>

                        <dd>
                            @Html.DisplayFor(Function(model) model.RecycleWhenExpired)
                        </dd>
                    </dl>

                </div>
                <div class="list-group-item">
                    <dl class="dl-horizontal ">
                        <dt>
                            @Html.DisplayNameFor(Function(model) model.Period)
                        </dt>

                        <dd>
                            @Html.DisplayFor(Function(model) model.Period)
                        </dd>
                    </dl>

                </div>
                <div class="list-group-item">
                    <dl class="dl-horizontal ">
                        <dt>
                            @Html.DisplayNameFor(Function(model) model.RecycleWhenMaxIsReached)
                        </dt>

                        <dd>
                            @Html.DisplayFor(Function(model) model.RecycleWhenMaxIsReached)
                        </dd>
                    </dl>

                </div>
                

            </div>
        </div>

    
<p>
    @Html.ActionLink("Modifica", "Edit", New With {.id = Model.ID}) |
    @Html.ActionLink("Torna alla lista", "Index")
</p>
    </div> 
</div>
