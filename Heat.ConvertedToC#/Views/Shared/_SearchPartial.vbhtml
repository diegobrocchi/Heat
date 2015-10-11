 
<div class="col-sm-3 col-md-3 pull-right">

    @Using (Html.BeginForm("Index", "Search", FormMethod.Post, New With {.class = "navbar-form", .role = "search"}))
        @<div class="input-group">
            @Html.TextBox("searchquery", "", New With {.id = "searchquery", .class = "form-control", .placeholder = "Cerca..."})
            <div class="input-group-btn">
                <button class="btn btn-default" type="submit"><i class="glyphicon glyphicon-search"></i></button>
            </div>
        </div>

        @Html.Hidden("fromcontroller", ViewContext.RouteData.Values("controller"), New With {.id = "fromcontroller"})

    End Using

    </div> 
