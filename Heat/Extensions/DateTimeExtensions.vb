Imports System.Runtime.CompilerServices
Imports System.Globalization

Public Module DateTimeExtensions
    <Extension>
    Public Function EndOfDay(currentDate As DateTime) As DateTime
        Return New DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 23, 59, 59, 999)
    End Function

    <Extension> _
    Public Function EndOfWeek(currentDate As DateTime) As DateTime
        Dim lastDayOfWeek As DateTime
        lastDayOfWeek = currentDate.AddDays(-currentDate.DayOfWeek).AddDays(7)
        Return New DateTime(lastDayOfWeek.Year, lastDayOfWeek.Month, lastDayOfWeek.Day, 23, 59, 59, 999)

    End Function

    <Extension> _
    Public Function EndOfMonth(currentDate As DateTime) As DateTime
        Return New DateTime(currentDate.Year, currentDate.Month, DateTime.DaysInMonth(currentDate.Year, currentDate.Month), 23, 59, 59, 999)
    End Function

    <Extension> _
    Public Function EndOfQuarter(currentDate As DateTime) As DateTime
        Select Case currentDate.Month
            Case Is <= 3
                Return New DateTime(currentDate.Year, 3, 31, 23, 59, 59, 999)
            Case Is <= 6
                Return New DateTime(currentDate.Year, 6, 30, 23, 59, 59, 999)
            Case Is <= 9
                Return New DateTime(currentDate.Year, 9, 30, 23, 59, 59, 999)
            Case Else
                Return New DateTime(currentDate.Year, 12, 31, 23, 59, 59, 999)
        End Select
    End Function

    <Extension> _
    Public Function EndOfYear(currentDate As DateTime) As DateTime
        Dim year As Integer = currentDate.Year

        Return New DateTime(year, 12, 31, 23, 59, 59, 999)


    End Function

    <Extension> _
    Public Function WeekOfTheYear(currentDate As DateTime) As Integer
        Dim day As DayOfWeek = currentDate.DayOfWeek

        If day >= DayOfWeek.Monday And day <= DayOfWeek.Wednesday Then
            currentDate = currentDate.AddDays(3)
        End If

        Return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(currentDate, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday)
    End Function
End Module


