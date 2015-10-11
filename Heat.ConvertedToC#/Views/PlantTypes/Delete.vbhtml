@ModelType Heat.PlantType
@Code
    ViewData("Title") = "Elimina un tipo di impianto"
End Code

<h2>Elimina</h2>

<h3>Sei sicuro di voler eliminare questo?</h3>
<div>
    <h4>Tipo di impianto</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Name)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Name)
        </dd>

    </dl>
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-actions no-color">
            <input type="submit" value="Elimina" class="btn btn-default" /> |
            @Html.ActionLink("Torna alla lista", "Index")
        </div>
    End Using
</div>
