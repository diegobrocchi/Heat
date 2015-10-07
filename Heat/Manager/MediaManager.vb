Imports System.IO
Imports System.Web
Imports Heat.Models

Namespace Manager
    ''' <summary>
    ''' Esegue le operazioni relative ai media
    ''' </summary>
    Public Class MediaManager
        Private _db As IHeatDBContext
        Private _folder As String

        Public Sub New(dbContext As IHeatDBContext)
            _db = dbContext
        End Sub

        ReadOnly Property Folder As String
            Get
                If String.IsNullOrEmpty(_folder) Then
                    _folder = ConfigurationManager.AppSettings("MediaFolder")
                End If
                Return _folder
            End Get
        End Property


        ''' <summary>
        ''' Trasforma un file caricato dall'utente in un oggetto Medium
        ''' </summary>
        ''' <param name="file"></param>
        ''' <returns></returns>
        Public Function GetMedium(file As HttpPostedFileBase, description As String, tags As String) As Medium

            Dim result As New Medium
            result.Description = If(description, String.Empty)
            result.Tags = If(tags, String.Empty)
            result.OriginalFilename = Path.GetFileName(file.FileName)
            result.Lenght = file.ContentLength
            result.Extension = file.FileName.Substring(file.FileName.IndexOf("."))
            result.ContentType = file.ContentType

            'result.AbsolutePath = server.MapPath(Path.Combine(_folder, file.FileName))
            Return result
        End Function

    End Class
End Namespace
