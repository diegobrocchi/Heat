@ModelType System.Web.Mvc.HandleErrorInfo

@Code
    ViewBag.Title = "Error"
End Code

 
@*<!DOCTYPE html>
<html>
<head>
    <meta name="viewport" content="width=device-width" />
    <title>Errore inatteso dell'applicazione</title>
</head>
<body>

    <h1>Errore</h1>
    <h2>E' capitato un errore non gestito</h2>


    <p>
        @ViewBag.message
    </p>
     
</body>
</html>*@

<h2>Errore</h2>
<h4>Capita raramente, ma anche Heat sbaglia...</h4>
<h5>Qui sotto c'è la descrizione abbastanza incomprensibile di cosa è successo. <br />Qualcuno capirà.</h5>


<p>
    @ViewBag.message
</p>
