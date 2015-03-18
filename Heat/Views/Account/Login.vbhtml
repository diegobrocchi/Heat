@ModelType LoginViewModel
@Code
    Layout = Nothing
End Code

@Styles.Render("~/Content/css")

<link type="text/css" href="~/Content/Login.css" rel="stylesheet" />


<div class="container">
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
              </div>
     

@Scripts.Render("~/bundles/jquery")
 @Scripts.Render("~/bundles/jqueryval")
 