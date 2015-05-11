Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class DateTimeExtensionsTests

    <TestMethod()> _
    Public Sub EndOfDay_Now_ReturnsTodayMidnight()
        Assert.IsTrue(Now.EndOfDay.Equals(New DateTime(Now.Year, Now.Month, Now.Day, 23, 59, 59, 999)))
    End Sub


    <TestMethod> _
    Public Sub EndOfDay_LastDayOfYear_ReturnsLastDayOfYearMidnight()
        Dim lastDayOfYear As DateTime = New DateTime(2015, 12, 31)

        Assert.IsTrue(lastDayOfYear.EndOfDay.Equals(New DateTime(2015, 12, 31, 23, 59, 59, 999)))

    End Sub

    <TestMethod> _
    Public Sub EndOfDay_FirstDayOfYear_ReturnsFirstDayOfYearMidnight()
        Dim firstDayOfYear As DateTime = New DateTime(2015, 1, 1)

        Assert.IsTrue(firstDayOfYear.EndOfDay.Equals(New DateTime(2015, 1, 1, 23, 59, 59, 999)))

    End Sub

    <TestMethod> _
    Public Sub EndOfDay_LeapDay_ReturnsLeapDayMidnight()
        Dim leapDay As DateTime = New DateTime(2008, 2, 29)

        Assert.IsTrue(leapDay.EndOfDay.Equals(New DateTime(2008, 2, 29, 23, 59, 59, 999)))
    End Sub


    <TestMethod> _
    Public Sub EndOfDay_NotSoSpecialDay_ReturnsMidnight()
        Dim notSoSpecialDay As DateTime = New DateTime(1973, 7, 30)

        Assert.IsTrue(notSoSpecialDay.EndOfDay.Equals(New DateTime(1973, 7, 30, 23, 59, 59, 999)))

    End Sub

    <TestMethod> _
    Public Sub EndOfDay_Midnight_ReturnsMidnight()
        Dim midnight As DateTime = New DateTime(2015, 5, 21, 23, 59, 59)

        Assert.IsTrue(midnight.EndOfDay.Equals(New DateTime(2015, 5, 21, 23, 59, 59, 999)))
    End Sub

    
    <TestMethod> _
    Public Sub EndOfWeek_31122015_Returns03012016()
        Dim DayInTheMiddleOfLastWeekOfYear As DateTime = New DateTime(2015, 12, 31)
        Assert.IsTrue(DayInTheMiddleOfLastWeekOfYear.EndOfWeek.Equals(New DateTime(2016, 1, 3, 23, 59, 59, 999)))
    End Sub

    <TestMethod> _
    Public Sub EndOfMonth_15_January_Returns31_JanuaryMidnight()
        Dim dayInJanuary As DateTime = New DateTime(2015, 1, 15)
        Assert.IsTrue(dayInJanuary.EndOfMonth.Equals(New DateTime(2015, 1, 31, 23, 59, 59, 999)))
    End Sub

    <TestMethod> _
    Public Sub EndOfMonth_LeapMonth_Returns_29FebruaryMidnight()
        Dim dayInLeapMonth As DateTime = New DateTime(2008, 2, 14)
        Assert.IsTrue(dayInLeapMonth.EndOfMonth.Equals(New DateTime(2008, 2, 29, 23, 59, 59, 999)))

    End Sub

    <TestMethod> _
    Public Sub EndOfMonth_LastDayOfYear_ReturnsMidnight()
        Dim lastDayOfYear As DateTime = New DateTime(2015, 12, 31)

        Assert.IsTrue(lastDayOfYear.EndOfMonth.Equals(New DateTime(2015, 12, 31, 23, 59, 59, 999)))

    End Sub

    <TestMethod> _
    Public Sub EndOfYear_dayInJanuary_ReturnsLastDayOfYearMidnight()
        Dim dayINJanuary As DateTime = New DateTime(2015, 1, 17)

        Assert.IsTrue(dayINJanuary.EndOfYear.Equals(New DateTime(2015, 12, 31, 23, 59, 59, 999)))
    End Sub

    <TestMethod> _
    Public Sub EndOfQuarter_dayInJanuary_Returns3103Midnight()
        Dim dayInJanuary As DateTime = New DateTime(2015, 1, 23)

        Assert.IsTrue(dayInJanuary.EndOfQuarter.Equals(New DateTime(2015, 3, 31, 23, 59, 59, 999)))
    End Sub

    <TestMethod> _
    Public Sub EndOfQuarter_leapDay_Returns3103Midnight()
        Dim leapDay As DateTime = New DateTime(2008, 2, 29)

        Assert.IsTrue(leapDay.EndOfQuarter.Equals(New DateTime(2008, 3, 31, 23, 59, 59, 999)))
    End Sub


    <TestMethod> _
    Public Sub EndOfQuarter_dayInApril_Returns3006Midnight()
        Dim dayInApril As DateTime = New DateTime(2015, 4, 25)

        Assert.IsTrue(dayInApril.EndOfQuarter.Equals(New DateTime(2015, 6, 30, 23, 59, 59, 999)))

    End Sub

    <TestMethod> _
    Public Sub EndOfQuarter_dayInJuly_Returns3009Midnight()
        Dim dayInJuly As DateTime = New DateTime(2015, 7, 30)

        Assert.IsTrue(dayInJuly.EndOfQuarter.Equals(New DateTime(2015, 9, 30, 23, 59, 59, 999)))
    End Sub
End Class