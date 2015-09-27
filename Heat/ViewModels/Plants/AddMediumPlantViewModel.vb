Imports System.ComponentModel.DataAnnotations
Imports Heat.Models

Namespace ViewModels.Plants
    Public Class AddMediumPlantViewModel

        Property PlantId As Integer

        <Required>
        <Display(Name:="Descrizione immagine")>
        Property Description As String

        <Display(Name:="Etichette")>
        Property Tags As String

        <Display(Name:="File")>
        <DataType(DataType.Upload)>
        Property UploadFile As HttpPostedFileBase

    End Class

End Namespace
