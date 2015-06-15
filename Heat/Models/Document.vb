Namespace Models

    Public MustInherit Class Document
        Property ID As Integer

        Property TemporaryNumber As Integer
        Property TemporaryStringNumber As String
        Property Number As Integer
        Property StringNumber As String
        Property Customer As Customer
        Property PrintDate As DateTime
        Property Numerator As Numbering
        Property CreateUser As HeatUser
        Property CreationDate As DateTime
        Property LastModifyUser As HeatUser
        Property LastModifyDate As DateTime
        Property State As DocumentState
    End Class

    Public Enum DocumentState
        Inserted = 0
        Confirmed = 1
        Deleted = 3

    End Enum
End Namespace

