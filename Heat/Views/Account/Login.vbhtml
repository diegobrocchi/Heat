@ModelType LoginViewModel
@Code
    Layout = Nothing
End Code

@Styles.Render("~/Content/css")
<link type="text/css" href="~/Content/signin.css" rel="stylesheet" />

 
    <div class="container">
        <div class="row">
            <div class="col-sm-6 col-md-4 col-md-offset-4">
                <div class="panel">
                    @Using Html.BeginForm("Login", "Account", New With {.returnUrl = ViewBag.returnurl}, FormMethod.Post, New With {.class = "form-signin", .role = "form"})
                        @Html.AntiForgeryToken()

                        @<h3 class="form-signin-heading">Accedi</h3>
                         
                        @<div class="form-group">
                            @Html.LabelFor(Function(m) m.Username, htmlAttributes:=New With {.class = "sr-only"})
                            @Html.TextBoxFor(Function(m) m.Username, New With {.class = "form-control", .placeholder = "Username", .autofocus="autofocus"})
                            @Html.ValidationMessageFor(Function(m) m.Username, "", New With {.class = "valError"})
                        </div>
                        @<div class="form-group">
                            @Html.LabelFor(Function(m) m.Password, htmlAttributes:=New With {.class = "sr-only"})
                            @Html.PasswordFor(Function(m) m.Password, New With {.class = "form-control", .placeholder = "Password"})
                            @Html.ValidationMessageFor(Function(m) m.Password, "", New With {.class = "valError"})
                        </div>
                        @<div class="checkbox">
                            <label>
                                @Html.CheckBoxFor(Function(m) m.RememberMe)Ricordami
                            </label>
                        </div>

                        @<input type="submit" value="Entra" class="btn btn-lg btn-success btn-block" />

                    End Using
                </div>

            </div>
        </div>
       
    </div>
 

    @*<link type="text/css" href="~/Content/Login.css" rel="stylesheet" />*@


    @*<div class="container">
        <div class="row">
            <div class="col-md-12">
                <div class="wrap">
                    <div class="panel">
                        <p class="form-title">
                            Accedi
                        </p>
                        @Using Html.BeginForm("Login", "Account", New With {.ReturnUrl = ViewBag.ReturnUrl}, FormMethod.Post, New With {.class = "login", .role = "form"})
                            @Html.AntiForgeryToken()
                            @<div class="form-group">
                            @Html.LabelFor(Function(m) m.Username)
                            @Html.TextBoxFor(Function(m) m.Username, New With {.placeholder = "Username"})
                            @Html.ValidationMessageFor(Function(m) m.Username, "", New With {.class = "valError"})
                        </div>

    @<div class="form-group">
                            @Html.LabelFor(Function(m) m.Password)
                            @Html.PasswordFor(Function(m) m.Password, New With {.placeholder = "Password"})
                            @Html.ValidationMessageFor(Function(m) m.Password, "", New With {.class = "valError"})
                        </div>

                            @<input type="submit" value="Entra" class="btn btn-success btn-sm" />

                            @<div class="remember-forgot">
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="checkbox">
                                            <label>
                                                @Html.CheckBoxFor(Function(m) m.RememberMe)
                                                Ricordami
                                            </label>
                                        </div>
                                    </div>
                                    <div class="col-md-6 forgot-pass-content">
                                        @Html.ActionLink("Password dimenticata?", "ForgotPassword")
                                    </div>
                                </div>
                            </div>
                        End Using
                    </div>
                    </div>

                </div>
            </div>
                  </div>*@
     

@Scripts.Render("~/bundles/jquery")
 @Scripts.Render("~/bundles/jqueryval")
 