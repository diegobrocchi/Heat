Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Heat.Manager
Imports Heat.Repositories

<TestClass()> Public Class NumeratorManagerTests

    <TestMethod()> _
    Public Sub GetNextTemp_FirstCall_ReturnsFirstValue()
        Dim nm As NumeratorManager
        nm = NumeratorManager.Instance
        Dim actual As SerialNumber


        Dim aNumbering As New Numbering

        Dim aTempScheme As New SerialScheme
        Dim aFinalScheme As New SerialScheme

        aNumbering.Code = "AAA"
        aNumbering.Description = "Un numeratore a caso"
        aNumbering.LastFinalSerial = New SerialNumber(0, String.Empty, True, String.Empty)
        aNumbering.LastTempSerial = New SerialNumber(0, String.Empty, True, String.Empty)
        aNumbering.FinalSerialSchema = aFinalScheme
        aNumbering.TempSerialSchema = aTempScheme

        aTempScheme.ExpiryDate = New DateTime(9999, 12, 31, 23, 59, 59, 999)
        aTempScheme.FormatMask = String.Empty
        aTempScheme.Increment = 1
        aTempScheme.InitialValue = 1
        aTempScheme.RecycleWhenExpired = False
        aTempScheme.MaxValue = Integer.MaxValue
        aTempScheme.MinValue = Integer.MinValue
        aTempScheme.Period = Periodicity.None



        actual = nm.GetNextTemp(aNumbering)


        Assert.IsTrue(actual.SerialInteger = 1)
        Assert.IsTrue(actual.SerialString = "1")


    End Sub

End Class