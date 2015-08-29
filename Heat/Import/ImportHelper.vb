Imports System.IO
Imports Heat.Repositories

Public Class ImportHelper

    Private _context As HeatDBContext
    Public Sub New(context As HeatDBContext)
        _context = context
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="fileContent"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Customer(fileContent As String) As Boolean
        Dim fileRows() As String
        Dim fileRowFields() As String
        Dim NewCustomersList As New List(Of Models.Customer)

        Try
            'controlla se la prima riga è nel formato giusto
            fileRows = fileContent.Split(vbCrLf)

            If Not String.IsNullOrEmpty(fileRows(0)) Then
                fileRowFields = fileRows(0).Split(";")

                If fileRowFields.Count = 16 Then
                    For i = 1 To fileRows.Count - 2
                        fileRowFields = fileRows(i).Split(";")

                        Dim newCustomer As New Models.Customer
                        newCustomer.Address = fileRowFields(4)
                        newCustomer.City = fileRowFields(5)
                        newCustomer.District = fileRowFields(7)
                        newCustomer.IBAN = fileRowFields(13)
                        newCustomer.Name = fileRowFields(3)
                        newCustomer.PostalCode = fileRowFields(6)
                        newCustomer.Taxcode = fileRowFields(11)
                        newCustomer.Telephone1 = fileRowFields(8)
                        newCustomer.Telephone2 = fileRowFields(9)
                        newCustomer.Telephone3 = fileRowFields(10)
                        newCustomer.VAT_Number = fileRowFields(12)

                        newCustomer.IsEnabled = True
                        newCustomer.CreationDate = Now
                        newCustomer.EnableDate = Now
                        
                        NewCustomersList.Add(newCustomer)
                    Next
                End If
            End If
            _context.Customers.RemoveRange(_context.Customers.ToList)
            For Each c In NewCustomersList
                _context.Customers.Add(c)
            Next
            _context.SaveChanges()

            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function


    Public Function Plant(fileContent As String) As Boolean
        Dim fileRows() As String
        Dim fileRowFields() As String
        Dim newPlantList As New List(Of Plant)

        Try
            fileRows = fileContent.Split(vbCrLf)
            If Not String.IsNullOrEmpty(fileRows(0)) Then
                fileRowFields = fileRows(0).Split(";")
                If fileRowFields.Count = 19 Then
                    For i = 1 To fileRows.Count - 2
                        fileRowFields = fileRows(i).Split(";")

                        Dim newPlant As New Plant
                        newPlant.Address = fileRowFields(4)
                        newPlant.Area = fileRowFields(16)
                        newPlant.City = fileRowFields(12)
                        newPlant.Code = fileRowFields(2)
                        newPlant.Fuel = fileRowFields(17)
                        newPlant.Name = fileRowFields(3)
                        Dim sPlantClass As String = fileRowFields(9)
                        newPlant.PlantClass = _context.PlantClasses.Where(Function(pc) pc.Name = sPlantClass).FirstOrDefault
                        newPlant.PlantDistictCode = fileRowFields(11)
                        newPlant.PlantTelephone1 = fileRowFields(6)
                        newPlant.PlantTelephone2 = fileRowFields(7)
                        newPlant.PlantTelephone3 = fileRowFields(8)
                        Dim sPlantType As String = fileRowFields(10)
                        newPlant.PlantType = _context.PlantTypes.Where(Function(pt) pt.Name = sPlantType).FirstOrDefault
                        newPlant.PostalCode = fileRowFields(13)
                        newPlant.StreetNumber = fileRowFields(5)
                        newPlant.Zone = fileRowFields(16)

                        newPlantList.Add(newPlant)
                    Next

                End If
            End If
            _context.Plants.RemoveRange(_context.Plants.ToList)
            _context.Plants.AddRange(newPlantList)
            _context.SaveChanges()
            Return True
        Catch ex As Exception
            Return False

        End Try


    End Function
End Class
