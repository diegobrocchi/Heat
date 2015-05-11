Imports Heat.Manager

<TestClass> _
Public Class NumeratorManagerTests

    Private _numbering As Numbering
    Private _listOfSerials1 As List(Of SerialNumber)
    Private _listOfSerials2 As List(Of SerialNumber)
    Private _hashTable1 As Hashtable
    Private _hashTable2 As Hashtable

    <TestInitialize> _
    Public Sub Init()
        Dim finalScheme As New SerialScheme
        Dim tempScheme As New SerialScheme

        _hashTable1 = New Hashtable
        _hashTable2 = New Hashtable

        _listOfSerials1 = New List(Of SerialNumber)
        _listOfSerials2 = New List(Of SerialNumber)

        finalScheme.Increment = 1
        finalScheme.RecycleWhenExpired = False

        tempScheme.Increment = 1
        tempScheme.RecycleWhenExpired = False

        _numbering = New Numbering

        _numbering.Code = "ZXY"
        _numbering.Description = "Temp"
        _numbering.FinalSerialSchema = finalScheme
        _numbering.TempSerialSchema = tempScheme
        _numbering.ID = 99
        _numbering.LastFinalSerial = New SerialNumber(1, "1", True, String.Empty)
        _numbering.LastTempSerial = New SerialNumber(1, "1", True, String.Empty)

    End Sub


    <TestMethod> _
    Public Sub GetNextTemp_Valid_ReturnsValid()
        Dim nm As NumeratorManager
        Dim num As New Numbering
        Dim scheme As New SerialScheme
        Dim result As SerialNumber


        scheme.ExpiryDate = Now.AddDays(1)
        scheme.Increment = 1
        scheme.InitialValue = 1
        scheme.MaxValue = Nothing
        scheme.MinValue = Nothing
        scheme.Period = Periodicity.Yearly
        scheme.RecycleWhenExpired = True
        scheme.RecycleWhenMaxIsReached = False

        num.TempSerialSchema = scheme
        num.LastTempSerial = New SerialNumber(23, "23", True, String.Empty)

        nm = NumeratorManager.Instance
        result = nm.GetNextTemp(num)

        Assert.IsTrue(result.IsValid)
    End Sub

    <TestMethod> _
    Public Sub GetNextTemp_Valid_UpdateNumbering()
        Dim nm As NumeratorManager
        Dim num As New Numbering
        Dim scheme As New SerialScheme
        Dim result As SerialNumber

        scheme.ExpiryDate = Now.AddDays(1)
        scheme.Increment = 1
        scheme.InitialValue = 1
        scheme.MaxValue = Nothing
        scheme.MinValue = Nothing
        scheme.FormatMask = String.Empty
        scheme.Period = Periodicity.Yearly
        scheme.RecycleWhenExpired = True
        scheme.RecycleWhenMaxIsReached = False

        num.TempSerialSchema = scheme
        num.LastTempSerial = New SerialNumber(1, "1", True, String.Empty)

        nm = NumeratorManager.Instance
        result = nm.GetNextTemp(num)

        Assert.IsTrue(num.LastTempSerial.Equals(result))

    End Sub


    <TestMethod> _
    Public Sub GetNextTemp_IsThreadSafe()
        Dim t1 As Threading.Thread
        Dim t2 As Threading.Thread

        t1 = New Threading.Thread(AddressOf AddSerialsToList)
        t2 = New Threading.Thread(AddressOf AddSerialsToList)

        't1.Start(_listOfSerials1)
        't2.Start(_listOfSerials2)

        t1.Start(_hashTable1)
        t2.Start(_hashTable2)

        t1.Join()
        t2.Join()

        'Assert.IsTrue(_listOfSerials1.Count = 10001)
        'Assert.IsTrue(_listOfSerials2.Count = 10001)

        'For Each ser In _listOfSerials1
        '    Assert.IsFalse(_listOfSerials2.Exists(Function(s) s.Equals(ser)))
        'Next

        'For Each ser In _listOfSerials2
        '    Assert.IsFalse(_listOfSerials1.Exists(Function(s) s.Equals(ser)))
        'Next
        Assert.IsTrue(_hashTable1.Count = 10001)
        Assert.IsTrue(_hashTable2.Count = 10001)
        For Each el In _hashTable1
            Assert.IsNull(_hashTable2(el.key))
        Next

        For Each el In _hashTable2
            Assert.IsNull(_hashTable1(el.key))
        Next
    End Sub

    Private Sub AddSerialsToList(h As Hashtable)
        Dim nm As NumeratorManager
        Dim result As SerialNumber

        nm = NumeratorManager.Instance

        For i = 0 To 10000
            result = nm.GetNextTemp(_numbering)
            h.Add(result.SerialInteger, result)
        Next



    End Sub
End Class
