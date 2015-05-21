@* Template view per il tipo Enum Periodicity, mostra il valore del DisplayAttribute *@
@Imports system.componentmodel.dataannotation
@modeltype Periodicity
@Code
    Layout = Nothing
    Dim field = Model.GetType().GetField(Model.ToString)
    If Not IsNothing(field) Then
        Dim display = field.GetCustomAttributes(GetType(DisplayAttribute), False).FirstOrDefault
        If Not IsNothing(field) Then
            @display.name
        End If
End If
End Code
