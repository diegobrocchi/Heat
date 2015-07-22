<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>@ViewBag.Title - Heat</title>
    @Styles.Render("~/Content/css")
    @Scripts.Render("~/bundles/modernizr")

    <meta name="description" content="Heat gestionale manutenzione impianti termici" />
</head>
<body>
    <div class="navbar navbar-inverse navbar-fixed-top">
        <div class="container">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                @Html.ActionLink("Heat", "Index", "Home", New With {.area = ""}, New With {.class = "navbar-brand"})
            </div>
            <div class="navbar-collapse collapse">
                <ul class="nav navbar-nav">
                    <li>@Html.ActionLink("Home", "Index", "Home")</li>
                    <li>@Html.ActionLink("Clienti", "Index", "Customers")</li>
                    <li class="dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown" rule="button" aria-expanded="false">Documenti <span class="caret"></span></a>
                        <ul class="dropdown-menu" role="menu">
                            <li>@Html.ActionLink("Fatture", "index", "invoices")</li>
                            <li>@Html.ActionLink("Preventivi", "index", "preventivi")</li>
                        </ul>
                    </li>
                    <li>@Html.ActionLink("Attività", "Index", "Operations")</li>
                    <li class="dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false">Gestione <span class="caret"></span></a>
                        <ul class="dropdown-menu" role="menu">
                            <li>@Html.ActionLink("Articoli", "index", "products",Nothing,"")</li>
                    <li>@Html.ActionLink("Settings", "Index", "Settings")</li>
                        </ul>
                    </li>
                </ul>
                    @Html.Partial("_SearchPartial")
                    @Html.Partial("_LoginPartial")
            </div>
            
             
        </div>
    </div>
    <div class="container body-content">
        @RenderBody()
        <hr />
        <footer>
            <p>&copy; @DateTime.Now.Year - Heat - DB</p>
        </footer>
    </div>

    @Scripts.Render("~/bundles/jquery")
    @Scripts.Render("~/bundles/jqueryval")
    @Scripts.Render("~/bundles/bootstrap")
    @RenderSection("scripts", required:=False)
</body>
</html>
