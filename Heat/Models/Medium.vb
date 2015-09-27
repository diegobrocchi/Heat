Namespace Models

    ''' <summary>
    ''' Rappresenta un oggetto di tipo grafico o audio o video o whatever caricata come allegato ad un'altra entità.
    ''' </summary>
    Public Class Medium

        Property ID As Integer
        Property OriginalFilename As String
        Property UploadFilename As String
        Property RelativePath As String
        Property AbsolutePath As String
        Property Lenght As Integer
        Property Extension As String
        Property ContentType As String
        Property Description As String
        Property Tags As String

    End Class
End Namespace

