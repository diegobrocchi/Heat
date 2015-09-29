@ModelType Heat.DetailsMediaPlantViewModel
 
 <div>
     @For Each Item In Model.Media
          @<img src="@Url.Content(Path.Combine(Model.BaseHref, Item.UploadFilename))"  alt="@Item.OriginalFilename" width="200" height="200" />
     Next
 </div>