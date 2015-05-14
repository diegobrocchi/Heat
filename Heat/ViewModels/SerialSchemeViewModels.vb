Imports System.ComponentModel.DataAnnotations

Public Class AddNewSerialSchemeViewModel

    <Key> _
    Property ID As Integer

    <Required> _
    <Display(Name:="Valore iniziale della serie")>
    Property InitialValue As Integer

    <Required> _
    <Display(name:="Incremento")> _
    Property Increment As Integer
    <Display(name:="Valore minimo assegnabile (può essere lasciato vuoto se non esiste il minimo)")> _
    Property MinValue As Nullable(Of Integer)

    <Display(name:="Valore massimo assegnabile (può essere lasciato vuoto se non esiste il massimo)")> _
    Property MaxValue As Nullable(Of Integer)

    <Display(name:="Schema di generazione del testo corrispondente al numero di serie")> _
    Property FormatMask As String

    <Display(name:="Data di scadenza dello schema")> _
    <DataType(DataType.Date), DisplayFormat(dataformatstring:="{0:yyyy-MM-dd}", applyFormatInEditMode:=True)> _
    Property ExpiryDate As Nullable(Of DateTime)

    <Display(name:="Riparte dal valore iniziale quando si supera la data di scadenza")> _
    Property RecycleWhenExpired As Boolean

    <Display(name:="Periodicità")> _
    Property Period As Nullable(Of Periodicity)

    <Display(name:="Riparte dal valore iniziale quando raggiunge il valore massimo")> _
    Property RecycleWhenMaxIsReached As Boolean





End Class
