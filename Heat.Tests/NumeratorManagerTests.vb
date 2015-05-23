Imports Heat.Manager

<TestClass> _
Public Class NumeratorManagerTests

    Private _numbering As Numbering
    Private _listOfSerials1 As List(Of SerialNumber)
    Private _listOfSerials2 As List(Of SerialNumber)
    Private _hashTable1 As Hashtable
    Private _hashTable2 As Hashtable
    Private _hashTable3 As Hashtable
    Private _hashTable4 As Hashtable
    Private _hashTable5 As Hashtable
    Private _hashTable6 As Hashtable
    Private _hashTable7 As Hashtable
    Private _hashTable8 As Hashtable
    Private _hashTable9 As Hashtable
    Private _hashTable10 As Hashtable
    Private _hashTable11 As Hashtable
    Private _hashTable12 As Hashtable

    <TestInitialize> _
    Public Sub Init()
        Dim finalScheme As New SerialScheme
        Dim tempScheme As New SerialScheme

        _hashTable1 = New Hashtable
        _hashTable2 = New Hashtable
        _hashTable3 = New Hashtable
        _hashTable4 = New Hashtable
        _hashTable5 = New Hashtable
        _hashTable6 = New Hashtable
        _hashTable7 = New Hashtable
        _hashTable8 = New Hashtable
        _hashTable9 = New Hashtable
        _hashTable10 = New Hashtable
        _hashTable11 = New Hashtable
        _hashTable12 = New Hashtable

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
        Dim t3 As Threading.Thread
        Dim t4 As Threading.Thread
        Dim t5 As Threading.Thread
        Dim t6 As Threading.Thread
        Dim t7 As Threading.Thread
        Dim t8 As Threading.Thread
        Dim t9 As Threading.Thread
        Dim t10 As Threading.Thread
        Dim t11 As Threading.Thread
        Dim t12 As Threading.Thread

        t1 = New Threading.Thread(AddressOf AddSerialsToList)
        t2 = New Threading.Thread(AddressOf AddSerialsToList)
        t3 = New Threading.Thread(AddressOf AddSerialsToList)
        t4 = New Threading.Thread(AddressOf AddSerialsToList)
        t5 = New Threading.Thread(AddressOf AddSerialsToList)
        t6 = New Threading.Thread(AddressOf AddSerialsToList)
        t7 = New Threading.Thread(AddressOf AddSerialsToList)
        t8 = New Threading.Thread(AddressOf AddSerialsToList)
        t9 = New Threading.Thread(AddressOf AddSerialsToList)
        t10 = New Threading.Thread(AddressOf AddSerialsToList)
        t11 = New Threading.Thread(AddressOf AddSerialsToList)
        t12 = New Threading.Thread(AddressOf AddSerialsToList)

        't1.Start(_listOfSerials1)
        't2.Start(_listOfSerials2)

        t1.Start(_hashTable1)
        t2.Start(_hashTable2)
        t3.Start(_hashTable3)
        t4.Start(_hashTable4)
        t5.Start(_hashTable5)
        t6.Start(_hashTable6)
        t7.Start(_hashTable7)
        t8.Start(_hashTable8)
        t9.Start(_hashTable9)
        t10.Start(_hashTable10)
        t11.Start(_hashTable11)
        t12.Start(_hashTable12)

        t1.Join()
        t2.Join()
        t3.Join()
        t4.Join()
        t5.Join()
        t6.Join()
        t7.Join()
        t8.Join()
        t9.Join()
        t10.Join()
        t11.Join()
        t12.Join()


        Assert.IsTrue(_hashTable1.Count = 10001)
        Assert.IsTrue(_hashTable2.Count = 10001)
        Assert.IsTrue(_hashTable3.Count = 10001)
        Assert.IsTrue(_hashTable4.Count = 10001)
        Assert.IsTrue(_hashTable5.Count = 10001)
        Assert.IsTrue(_hashTable6.Count = 10001)
        Assert.IsTrue(_hashTable7.Count = 10001)
        Assert.IsTrue(_hashTable8.Count = 10001)
        Assert.IsTrue(_hashTable9.Count = 10001)
        Assert.IsTrue(_hashTable10.Count = 10001)
        Assert.IsTrue(_hashTable11.Count = 10001)
        Assert.IsTrue(_hashTable12.Count = 10001)

        For Each el In _hashTable1
            Assert.IsNull(_hashTable2(el.key))
            Assert.IsNull(_hashTable3(el.key))
            Assert.IsNull(_hashTable4(el.key))
            Assert.IsNull(_hashTable5(el.key))
            Assert.IsNull(_hashTable6(el.key))
            Assert.IsNull(_hashTable7(el.key))
            Assert.IsNull(_hashTable8(el.key))
            Assert.IsNull(_hashTable9(el.key))
            Assert.IsNull(_hashTable10(el.key))
            Assert.IsNull(_hashTable11(el.key))
            Assert.IsNull(_hashTable12(el.key))
        Next

        For Each el In _hashTable2
            Assert.IsNull(_hashTable1(el.key))
            Assert.IsNull(_hashTable3(el.key))
            Assert.IsNull(_hashTable4(el.key))
            Assert.IsNull(_hashTable5(el.key))
            Assert.IsNull(_hashTable6(el.key))
            Assert.IsNull(_hashTable7(el.key))
            Assert.IsNull(_hashTable8(el.key))
            Assert.IsNull(_hashTable9(el.key))
            Assert.IsNull(_hashTable10(el.key))
            Assert.IsNull(_hashTable11(el.key))
            Assert.IsNull(_hashTable12(el.key))
        Next
        For Each el In _hashTable3
            Assert.IsNull(_hashTable1(el.key))
            Assert.IsNull(_hashTable2(el.key))
            Assert.IsNull(_hashTable4(el.key))
            Assert.IsNull(_hashTable5(el.key))
            Assert.IsNull(_hashTable6(el.key))
            Assert.IsNull(_hashTable7(el.key))
            Assert.IsNull(_hashTable8(el.key))
            Assert.IsNull(_hashTable9(el.key))
            Assert.IsNull(_hashTable10(el.key))
            Assert.IsNull(_hashTable11(el.key))
            Assert.IsNull(_hashTable12(el.key))
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
