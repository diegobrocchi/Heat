@ModelType Heat.DetailsMediaPlantViewModel
 
 @*<div>
     @For Each Item In Model.Media
         @<a href="" class="thumbnail">
          <img src="@Url.Content(Path.Combine(Model.BaseHref, Item.UploadFilename))"  alt="Item.OriginalFilename" />
        </a>
     Next
 </div>*@

<div class="row">
    <div class="col-md-12">
        @Html.ActionLink("Aggiungi...", "addMedium", New With {.ID = Model.ID}, New With {.class = "btn btn-success"})
    </div>
</div>

<div Class="row">
@For Each Item In Model.Media
    @<div Class="col-sm-6 col-md-3">
        <div Class="thumbnail">
            <img src = "@Url.Content(Path.Combine(Model.BaseHref, Item.UploadFilename))" alt="Item.OriginalFilename" />
            <div Class="caption">
                <h3> @Item.Description </h3>
                <p> @Item.Tags </p>
            </div>
        </div>
    </div>
Next
</div>
 