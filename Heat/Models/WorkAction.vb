Imports System.ComponentModel.DataAnnotations

Namespace Models

    ''' <summary>
    ''' Rappresenta un intervento di lavoro.
    ''' </summary>
    ''' <remarks></remarks>
    Public Class WorkAction

        Property ID As Integer
        
        Property ActionDate As DateTime
        Property OperationID As Integer
        Property Operation As Operation
        Property AssignedOperatorID As Integer
        Property AssignedOperator As WorkOperator
        Property TypeID As Integer
        Property Type As ActionType
        Property PlantID As Integer
        Property Plant As Plant

    End Class

End Namespace

