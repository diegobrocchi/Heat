Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> _
Public Class SerialNumberTests
    <TestMethod> _
    <ExpectedException(GetType(Exception))> _
    Public Sub Increment_InvalidSerial_ThrowsException()
        Dim s As New SerialNumber
        Dim scheme As New SerialScheme

        '***
        s.IsValid = False
        '***
        s.SerialInteger = 100
        s.SerialString = "100"
        s.InvalidError = String.Empty

        s.Increment(scheme)

    End Sub

    <TestMethod()> _
    Public Sub Increment_NullExpiryDateInScheme_ReturnsMaxDateInExpiryDate()
        Dim s As New SerialNumber
        Dim scheme As New SerialScheme

        s.IsValid = True
        s.InvalidError = String.Empty
        s.SerialInteger = 1
        s.SerialString = "1"
        '***
        scheme.ExpiryDate = Nothing
        '***
        scheme.FormatMask = String.Empty
        scheme.ID = 1
        scheme.Increment = 1
        scheme.InitialValue = 1
        scheme.MaxValue = Nothing
        scheme.MinValue = Nothing
        scheme.Period = Periodicity.Daily
        scheme.RecycleWhenExpired = False
        scheme.RecycleWhenMaxIsReached = False

        s.Increment(scheme)

        Assert.IsTrue(scheme.ExpiryDate.Equals(DateTime.MaxValue))

    End Sub

    <TestMethod> _
    <ExpectedException(GetType(ArgumentException))> _
    Public Sub Increment_RecycleWithNullPeriod_throwsException()
        Dim s As New SerialNumber
        Dim scheme As New SerialScheme

        s.InvalidError = String.Empty
        s.IsValid = True
        s.SerialInteger = 1
        s.SerialString = "1"

        scheme.ExpiryDate = New DateTime(2104, 12, 30, 23, 59, 59, 999)
        scheme.FormatMask = String.Empty
        scheme.ID = 1
        scheme.Increment = 1
        scheme.InitialValue = 1
        scheme.MaxValue = Nothing
        scheme.MinValue = Nothing
        '***
        scheme.RecycleWhenExpired = True
        scheme.Period = Nothing
        '***
        scheme.RecycleWhenMaxIsReached = False

        s.Increment(scheme)
    End Sub

    <TestMethod> _
    <ExpectedException(GetType(ArgumentException))> _
    Public Sub Increment_RecycleWithNullMax_throwsException()
        Dim s As New SerialNumber
        Dim scheme As New SerialScheme

        s.InvalidError = String.Empty
        s.IsValid = True
        s.SerialInteger = 1
        s.SerialString = "1"

        scheme.ExpiryDate = New DateTime(2104, 12, 30, 23, 59, 59, 999)
        scheme.FormatMask = String.Empty
        scheme.ID = 1
        scheme.Increment = 1
        scheme.InitialValue = 1
        scheme.MinValue = Nothing
        scheme.RecycleWhenExpired = False
        scheme.Period = Nothing
        '***
        scheme.MaxValue = Nothing
        scheme.RecycleWhenMaxIsReached = True
        '***

        s.Increment(scheme)
    End Sub

    <TestMethod> _
    Public Sub Increment_SchemeNotExpired_AND_MaxReached_AND_DoRecycle_ReturnsInitialValue()
        Dim s As New SerialNumber
        Dim result As SerialNumber
        Dim expected As New SerialNumber

        Dim scheme As New SerialScheme

        s.InvalidError = String.Empty
        s.IsValid = True
        s.SerialInteger = 999
        s.SerialString = "999"

        scheme.ExpiryDate = Now.AddDays(1) 'this scheme does never expires!
        scheme.FormatMask = String.Empty
        scheme.ID = 99
        scheme.Increment = 23
        scheme.InitialValue = 34
        scheme.MaxValue = 999
        scheme.MinValue = Nothing
        scheme.Period = Periodicity.None
        scheme.RecycleWhenExpired = False
        scheme.RecycleWhenMaxIsReached = True

        result = s.Increment(scheme)

        expected.IsValid = True
        expected.InvalidError = String.Empty
        expected.SerialInteger = 34
        expected.SerialString = "34"

        Assert.IsInstanceOfType(result, GetType(SerialNumber))
        Assert.IsTrue(result.IsValid)
        Assert.IsTrue(result.Equals(expected))

    End Sub

    <TestMethod> _
    Public Sub Increment_SchemeNotExpired_AND_MaxReached_AND_DoNOTRecycle_ReturnsInvalidSerialNumber()
        Dim s As New SerialNumber
        Dim result As SerialNumber

        Dim scheme As New SerialScheme

        s.InvalidError = String.Empty
        s.IsValid = True
        s.SerialInteger = 987
        s.SerialString = "987"

        scheme.ExpiryDate = Now.AddDays(1)
        scheme.FormatMask = String.Empty
        scheme.Increment = 37
        scheme.InitialValue = 51
        scheme.MaxValue = 999
        scheme.MinValue = Nothing
        scheme.Period = Periodicity.None
        scheme.RecycleWhenExpired = True
        '***
        scheme.RecycleWhenMaxIsReached = False

        result = s.Increment(scheme)

        Assert.IsFalse(result.IsValid)

    End Sub

    <TestMethod> _
    Public Sub Increment_Scheme_ReturnsValidIncrement()
        Dim s As New SerialNumber
        Dim result As SerialNumber
        Dim expected As New SerialNumber
        Dim scheme As New SerialScheme

        s.InvalidError = String.Empty
        s.IsValid = True
        s.SerialInteger = 42
        s.SerialString = "42"

        scheme.ExpiryDate = Now.AddDays(1)
        scheme.FormatMask = ""
        scheme.ID = 98
        scheme.Increment = 31
        scheme.InitialValue = 1
        scheme.MaxValue = Nothing
        scheme.MinValue = Nothing
        scheme.Period = Periodicity.None
        scheme.RecycleWhenExpired = False
        scheme.RecycleWhenMaxIsReached = False

        result = s.Increment(scheme)

        expected.InvalidError = String.Empty
        expected.IsValid = True
        expected.SerialInteger = 73
        expected.SerialString = "73"

        Assert.AreEqual(expected, result)

    End Sub

    <TestMethod> _
    Public Sub Increment_SchemeExpired_AND_DoRecycle_AND_DailyPeriod_ReturnsFirstElement()
        Dim s As New SerialNumber
        Dim result As SerialNumber
        Dim expected As New SerialNumber
        Dim scheme As New SerialScheme

        s.InvalidError = String.Empty
        s.IsValid = True
        s.SerialInteger = 1023
        s.SerialString = "1023"

        scheme.ExpiryDate = Now.AddDays(-1)
        scheme.FormatMask = String.Empty
        scheme.ID = 90
        scheme.Increment = 23
        scheme.InitialValue = 3
        scheme.MaxValue = Nothing
        scheme.MinValue = Nothing
        scheme.Period = Periodicity.Daily
        scheme.RecycleWhenExpired = True
        scheme.RecycleWhenMaxIsReached = False

        expected.InvalidError = String.Empty
        expected.IsValid = True
        expected.SerialInteger = 3
        expected.SerialString = "3"

        result = s.Increment(scheme)

        Assert.IsTrue(result.IsValid)
        Assert.AreEqual(expected, result)



    End Sub

    <TestMethod> _
    Public Sub Increment_SchemeExpired_AND_DoRecycle_AND_DailyPeriod_ChangeSchemaExpiration()
        Dim s As New SerialNumber
        Dim scheme As New SerialScheme
        Dim result As SerialNumber

        Dim initialExpiryDate As DateTime = Now.AddDays(-1)

        s.InvalidError = String.Empty
        s.IsValid = True
        s.SerialInteger = 982
        s.SerialString = "982"

        scheme.ExpiryDate = initialExpiryDate
        scheme.FormatMask = String.Empty
        scheme.ID = 9
        scheme.Increment = 23
        scheme.InitialValue = 7
        scheme.MaxValue = Nothing
        scheme.MinValue = Nothing
        scheme.Period = Periodicity.Daily
        scheme.RecycleWhenExpired = True
        scheme.RecycleWhenMaxIsReached = False

        result = s.Increment(scheme)

        Assert.AreNotEqual(initialExpiryDate, scheme.ExpiryDate)
        Assert.AreEqual(scheme.FormatMask, String.Empty)
        Assert.AreEqual(scheme.ID, 9)
        Assert.AreEqual(scheme.Increment, 23)
        Assert.AreEqual(scheme.InitialValue, 7)
        Assert.IsNull(scheme.MaxValue)
        Assert.IsNull(scheme.MinValue)
        Assert.AreEqual(scheme.Period, Periodicity.Daily)
        Assert.IsFalse(scheme.RecycleWhenMaxIsReached)
        Assert.IsTrue(scheme.RecycleWhenExpired)


    End Sub

    <TestMethod> _
    Public Sub Increment_SchemeExpired_AND_DoRecycle_AND_WeeklyPeriod_ReturnsFirstElement()
        Dim s As New SerialNumber
        Dim result As SerialNumber
        Dim expected As New SerialNumber
        Dim scheme As New SerialScheme

        s.InvalidError = String.Empty
        s.IsValid = True
        s.SerialInteger = 1023
        s.SerialString = "1023"

        scheme.ExpiryDate = Now.AddDays(-1)
        scheme.FormatMask = String.Empty
        scheme.ID = 90
        scheme.Increment = 23
        scheme.InitialValue = 3
        scheme.MaxValue = Nothing
        scheme.MinValue = Nothing
        scheme.Period = Periodicity.Weekly
        scheme.RecycleWhenExpired = True
        scheme.RecycleWhenMaxIsReached = False

        expected.InvalidError = String.Empty
        expected.IsValid = True
        expected.SerialInteger = 3
        expected.SerialString = "3"

        result = s.Increment(scheme)

        Assert.IsTrue(result.IsValid)
        Assert.AreEqual(expected, result)
    End Sub

    <TestMethod> _
    Public Sub Increment_SchemeExpired_AND_DoRecycle_AND_WeeklyPeriod_ChangeSchemaExpiration()
        Dim s As New SerialNumber
        Dim scheme As New SerialScheme
        Dim result As SerialNumber

        Dim initialExpiryDate As DateTime = Now.AddDays(-1)

        s.InvalidError = String.Empty
        s.IsValid = True
        s.SerialInteger = 982
        s.SerialString = "982"

        scheme.ExpiryDate = initialExpiryDate
        scheme.FormatMask = String.Empty
        scheme.ID = 9
        scheme.Increment = 23
        scheme.InitialValue = 7
        scheme.MaxValue = Nothing
        scheme.MinValue = Nothing
        scheme.Period = Periodicity.Weekly
        scheme.RecycleWhenExpired = True
        scheme.RecycleWhenMaxIsReached = False

        result = s.Increment(scheme)

        Assert.AreNotEqual(initialExpiryDate, scheme.ExpiryDate)
        Assert.AreEqual(scheme.FormatMask, String.Empty)
        Assert.AreEqual(scheme.ID, 9)
        Assert.AreEqual(scheme.Increment, 23)
        Assert.AreEqual(scheme.InitialValue, 7)
        Assert.IsNull(scheme.MaxValue)
        Assert.IsNull(scheme.MinValue)
        Assert.AreEqual(scheme.Period, Periodicity.Weekly)
        Assert.IsFalse(scheme.RecycleWhenMaxIsReached)
        Assert.IsTrue(scheme.RecycleWhenExpired)

    End Sub

    <TestMethod> _
    Public Sub Increment_SchemeExpired_AND_DoRecycle_AND_MonthlyPeriod_ReturnsFirstElement()
        Dim s As New SerialNumber
        Dim result As SerialNumber
        Dim expected As New SerialNumber
        Dim scheme As New SerialScheme

        s.InvalidError = String.Empty
        s.IsValid = True
        s.SerialInteger = 1023
        s.SerialString = "1023"

        scheme.ExpiryDate = Now.AddDays(-1)
        scheme.FormatMask = String.Empty
        scheme.ID = 90
        scheme.Increment = 23
        scheme.InitialValue = 3
        scheme.MaxValue = Nothing
        scheme.MinValue = Nothing
        scheme.Period = Periodicity.Monthly
        scheme.RecycleWhenExpired = True
        scheme.RecycleWhenMaxIsReached = False

        expected.InvalidError = String.Empty
        expected.IsValid = True
        expected.SerialInteger = 3
        expected.SerialString = "3"

        result = s.Increment(scheme)

        Assert.IsTrue(result.IsValid)
        Assert.AreEqual(expected, result)
    End Sub

    <TestMethod> _
    Public Sub Increment_SchemeExpired_AND_DoRecycle_AND_MonthlyPeriod_ChangeSchemeExpiration()
        Dim s As New SerialNumber
        Dim scheme As New SerialScheme
        Dim result As SerialNumber

        Dim initialExpiryDate As DateTime = Now.AddDays(-1)

        s.InvalidError = String.Empty
        s.IsValid = True
        s.SerialInteger = 982
        s.SerialString = "982"

        scheme.ExpiryDate = initialExpiryDate
        scheme.FormatMask = String.Empty
        scheme.ID = 9
        scheme.Increment = 23
        scheme.InitialValue = 7
        scheme.MaxValue = Nothing
        scheme.MinValue = Nothing
        scheme.Period = Periodicity.Monthly
        scheme.RecycleWhenExpired = True
        scheme.RecycleWhenMaxIsReached = False

        result = s.Increment(scheme)

        Assert.AreNotEqual(initialExpiryDate, scheme.ExpiryDate)
        Assert.AreEqual(scheme.FormatMask, String.Empty)
        Assert.AreEqual(scheme.ID, 9)
        Assert.AreEqual(scheme.Increment, 23)
        Assert.AreEqual(scheme.InitialValue, 7)
        Assert.IsNull(scheme.MaxValue)
        Assert.IsNull(scheme.MinValue)
        Assert.AreEqual(scheme.Period, Periodicity.Monthly)
        Assert.IsFalse(scheme.RecycleWhenMaxIsReached)
        Assert.IsTrue(scheme.RecycleWhenExpired)

    End Sub

    <TestMethod> _
    Public Sub Increment_SchemaExpired_AND_DORecycle_AND_QuarterlyPeriod_ReturnsFirstElement()
        Dim s As New SerialNumber
        Dim result As SerialNumber
        Dim expected As New SerialNumber
        Dim scheme As New SerialScheme

        s.InvalidError = String.Empty
        s.IsValid = True
        s.SerialInteger = 1027
        s.SerialString = "1027"

        scheme.ExpiryDate = Now.AddDays(-1)
        scheme.FormatMask = String.Empty
        scheme.ID = 90
        scheme.Increment = 31
        scheme.InitialValue = 11
        scheme.MaxValue = Nothing
        scheme.MinValue = Nothing
        scheme.Period = Periodicity.Quarterly
        scheme.RecycleWhenExpired = True
        scheme.RecycleWhenMaxIsReached = False

        expected.InvalidError = String.Empty
        expected.IsValid = True
        expected.SerialInteger = 11
        expected.SerialString = "11"

        result = s.Increment(scheme)

        Assert.IsTrue(result.IsValid)
        Assert.AreEqual(expected, result)
    End Sub

    <TestMethod> _
    Public Sub Increment_SchemeExpired_AND_DoRecycle_AND_QuarterlyPeriod_ChangeSchemeExpiration()
        Dim s As New SerialNumber
        Dim scheme As New SerialScheme
        Dim result As SerialNumber

        Dim initialExpiryDate As DateTime = Now.AddDays(-1)

        s.InvalidError = String.Empty
        s.IsValid = True
        s.SerialInteger = 982
        s.SerialString = "982"

        scheme.ExpiryDate = initialExpiryDate
        scheme.FormatMask = String.Empty
        scheme.ID = 9
        scheme.Increment = 23
        scheme.InitialValue = 7
        scheme.MaxValue = Nothing
        scheme.MinValue = Nothing
        scheme.Period = Periodicity.Quarterly
        scheme.RecycleWhenExpired = True
        scheme.RecycleWhenMaxIsReached = False

        result = s.Increment(scheme)

        Assert.AreNotEqual(initialExpiryDate, scheme.ExpiryDate)
        Assert.AreEqual(scheme.FormatMask, String.Empty)
        Assert.AreEqual(scheme.ID, 9)
        Assert.AreEqual(scheme.Increment, 23)
        Assert.AreEqual(scheme.InitialValue, 7)
        Assert.IsNull(scheme.MaxValue)
        Assert.IsNull(scheme.MinValue)
        Assert.AreEqual(scheme.Period, Periodicity.Quarterly)
        Assert.IsFalse(scheme.RecycleWhenMaxIsReached)
        Assert.IsTrue(scheme.RecycleWhenExpired)
    End Sub

    <TestMethod> _
    Public Sub Increment_SchemeExpired_AND_DoRecycle_AND_YearlyPeriod_ReturnsFirstElement()
        Dim s As New SerialNumber
        Dim result As SerialNumber
        Dim expected As New SerialNumber
        Dim scheme As New SerialScheme

        s.InvalidError = String.Empty
        s.IsValid = True
        s.SerialInteger = 324
        s.SerialString = "324"

        scheme.ExpiryDate = Now.AddDays(-1)
        scheme.FormatMask = String.Empty
        scheme.ID = 90
        scheme.Increment = 31
        scheme.InitialValue = 1567
        scheme.MaxValue = Nothing
        scheme.MinValue = Nothing
        scheme.Period = Periodicity.Yearly
        scheme.RecycleWhenExpired = True
        scheme.RecycleWhenMaxIsReached = False

        expected.InvalidError = String.Empty
        expected.IsValid = True
        expected.SerialInteger = 1567
        expected.SerialString = "1567"

        result = s.Increment(scheme)

        Assert.IsTrue(result.IsValid)
        Assert.AreEqual(expected, result)
    End Sub


    <TestMethod> _
    Public Sub Increment_SchemeExpired_AND_DoRecycle_AND_YearlyPeriod_ChangeSchemeExpiration()
        Dim s As New SerialNumber
        Dim scheme As New SerialScheme
        Dim result As SerialNumber

        Dim initialExpiryDate As DateTime = Now.AddDays(-1)

        s.InvalidError = String.Empty
        s.IsValid = True
        s.SerialInteger = 982
        s.SerialString = "982"

        scheme.ExpiryDate = initialExpiryDate
        scheme.FormatMask = String.Empty
        scheme.ID = 9
        scheme.Increment = 23
        scheme.InitialValue = 7
        scheme.MaxValue = Nothing
        scheme.MinValue = Nothing
        scheme.Period = Periodicity.Yearly
        scheme.RecycleWhenExpired = True
        scheme.RecycleWhenMaxIsReached = False

        result = s.Increment(scheme)

        Assert.AreNotEqual(initialExpiryDate, scheme.ExpiryDate)
        Assert.AreEqual(scheme.FormatMask, String.Empty)
        Assert.AreEqual(scheme.ID, 9)
        Assert.AreEqual(scheme.Increment, 23)
        Assert.AreEqual(scheme.InitialValue, 7)
        Assert.IsNull(scheme.MaxValue)
        Assert.IsNull(scheme.MinValue)
        Assert.AreEqual(scheme.Period, Periodicity.Yearly)
        Assert.IsFalse(scheme.RecycleWhenMaxIsReached)
        Assert.IsTrue(scheme.RecycleWhenExpired)

    End Sub

    <TestMethod> _
    Public Sub Increment_SchemeExpired_AND_DoNotRecycle_ReturnsInvalidSerial()
        Dim s As New SerialNumber
        Dim result As SerialNumber
        Dim expected As New SerialNumber
        Dim scheme As New SerialScheme

        s.InvalidError = String.Empty
        s.IsValid = True
        s.SerialInteger = 324
        s.SerialString = "324"

        scheme.ExpiryDate = Now.AddDays(-1)
        scheme.FormatMask = String.Empty
        scheme.ID = 90
        scheme.Increment = 31
        scheme.InitialValue = 1567
        scheme.MaxValue = Nothing
        scheme.MinValue = Nothing
        scheme.Period = Periodicity.Yearly
        scheme.RecycleWhenExpired = False
        scheme.RecycleWhenMaxIsReached = False

        expected.InvalidError = String.Empty
        expected.IsValid = True
        expected.SerialInteger = 1567
        expected.SerialString = "1567"

        result = s.Increment(scheme)

        Assert.IsFalse(result.IsValid)

    End Sub


    <TestMethod> _
    Public Sub Stringify_EmptyFormatMask_ReturnsString()
        Dim s As New SerialNumber
        Dim scheme As New SerialScheme

        's.IsValid = True
        's.SerialInteger = 23
        's.SerialString = "ftc-23"

        scheme.FormatMask = String.Empty

        Assert.IsTrue(s.Stringify(24, scheme) = "24")
    End Sub

    <TestMethod> _
    Public Sub Stringify_SchemeWithFixedText_ReturnsFixedText()
        Dim s As New SerialNumber
        Dim scheme As New SerialScheme

        scheme.FormatMask = "FTC-{0}"

        Assert.AreEqual(s.Stringify(42, scheme), "FTC-42")
    End Sub

    <TestMethod> _
    Public Sub Stringify_SchemeWithFixedTextSpacing_ReturnsZeroLeftPad()
        Dim s As New SerialNumber
        Dim scheme As New SerialScheme

        scheme.FormatMask = "FTX-{0,8:D8}"

        Assert.AreEqual(s.Stringify(8, scheme), "FTX-00000008")
    End Sub

    <TestMethod> _
    Public Sub Stringify_SchemeWithYear_ReturnsYear()
        Dim s As New SerialNumber
        Dim scheme As New SerialScheme

        scheme.FormatMask = "FTC-{0,5:D5}-{{yyyy}}"

        Assert.AreEqual(s.Stringify(3, scheme), "FTC-00003-" & Now.Year)
    End Sub

    <TestMethod> _
    Public Sub Stringify_SchemeWithWeek_ReturnsWeek()
        Dim s As New SerialNumber
        Dim scheme As New SerialScheme

        scheme.FormatMask = "ABC/{0,4:D4}/{{ww}}"

        Assert.AreEqual(s.Stringify(9, scheme), "ABC/0009/" & Now.WeekOfTheYear)
    End Sub

    <TestMethod> _
    Public Sub Stringify_SchemeEmpty_DoNotThrowsErrors()
        Dim s As New SerialNumber
        Dim scheme As New SerialScheme

        scheme.FormatMask = String.Empty

        Assert.IsInstanceOfType(s.Stringify(1, scheme), GetType(String))

    End Sub
End Class