Imports System.Runtime.CompilerServices

Public Module EnumerableExtensions

    <Extension> _
    Public Function ToSelectListItems(Of T)(items As IEnumerable(Of T), name As Func(Of T, String), value As Func(Of T, String), selectedValue As String) As IEnumerable(Of SelectListItem)
        Return items.ToSelectListItems(name, value, selectedValue, False)
    End Function

    <Extension> _
    Public Function ToSelectListItems(Of T)(items As IEnumerable(Of T), name As Func(Of T, String), value As Func(Of T, String), selectedValue As String, includeNotApplicable As Boolean, Optional notApplicableValue As String = "", _
        Optional notApplicableText As String = "(Not Applicable)") As IEnumerable(Of SelectListItem)
        Return items.ToSelectListItems(name, value, Function(x) value(x) = selectedValue, includeNotApplicable, notApplicableValue, notApplicableText)
    End Function

    <Extension> _
    Public Function ToSelectListItems(Of T)(items As IEnumerable(Of T), name As Func(Of T, String), value As Func(Of T, String), isSelected As Func(Of T, Boolean)) As IEnumerable(Of SelectListItem)
        Return items.ToSelectListItems(name, value, isSelected, False)
    End Function

    <Extension> _
    Public Function ToSelectListItems(Of T)(items As IEnumerable(Of T), name As Func(Of T, String), value As Func(Of T, String), isSelected As Func(Of T, Boolean), includeNotApplicable As Boolean, Optional notApplicableValue As String = "", _
        Optional notApplicableText As String = "(Not Applicable)") As IEnumerable(Of SelectListItem)
        If includeNotApplicable Then
            Dim returnItems = New List(Of SelectListItem)() From { _
                New SelectListItem() With { _
                     .Text = notApplicableText, _
                     .Value = notApplicableValue, _
                     .Selected = False _
                } _
            }

            If items IsNot Nothing Then
                returnItems.AddRange(items.[Select](Function(item) New SelectListItem() With { _
                    .Text = name(item), _
                     .Value = value(item), _
                     .Selected = isSelected(item) _
                }))
            End If
            Return returnItems
        End If

        If items Is Nothing Then
            Return New List(Of SelectListItem)()
        End If

        Return items.[Select](Function(item) New SelectListItem() With { _
             .Text = name(item), _
             .Value = value(item), _
             .Selected = isSelected(item) _
        })
    End Function

    <Extension> _
    Public Function ToMultiSelectListItems(Of T)(items As IEnumerable(Of T), name As Func(Of T, String), value As Func(Of T, String), selectedValues As IEnumerable(Of Integer)) As IEnumerable(Of SelectListItem)
        If selectedValues Is Nothing Then
            selectedValues = New List(Of Integer)()
        End If
        Return items.ToMultiSelectListItems(name, value, selectedValues.[Select](Function(x) x.ToString()))
    End Function

    <Extension> _
    Public Function ToMultiSelectListItems(Of T)(items As IEnumerable(Of T), name As Func(Of T, String), value As Func(Of T, String), selectedValues As IEnumerable(Of Long)) As IEnumerable(Of SelectListItem)
        If selectedValues Is Nothing Then
            selectedValues = New List(Of Long)()
        End If
        Return items.ToMultiSelectListItems(name, value, selectedValues.[Select](Function(x) x.ToString()))
    End Function

    <Extension> _
    Public Function ToMultiSelectListItems(Of T)(items As IEnumerable(Of T), name As Func(Of T, String), value As Func(Of T, String), selectedValues As IEnumerable(Of Double)) As IEnumerable(Of SelectListItem)
        If selectedValues Is Nothing Then
            selectedValues = New List(Of Double)()
        End If
        Return items.ToMultiSelectListItems(name, value, selectedValues.[Select](Function(x) x.ToString()))
    End Function

    <Extension> _
    Public Function ToMultiSelectListItems(Of T)(items As IEnumerable(Of T), name As Func(Of T, String), value As Func(Of T, String), selectedValues As IEnumerable(Of Decimal)) As IEnumerable(Of SelectListItem)
        If selectedValues Is Nothing Then
            selectedValues = New List(Of Decimal)()
        End If
        Return items.ToMultiSelectListItems(name, value, selectedValues.[Select](Function(x) x.ToString()))
    End Function

    <System.Runtime.CompilerServices.Extension> _
    Public Function ToMultiSelectListItems(Of T)(items As IEnumerable(Of T), name As Func(Of T, String), value As Func(Of T, String), selectedValues As IEnumerable(Of String)) As IEnumerable(Of SelectListItem)
        If items Is Nothing Then
            Return New List(Of SelectListItem)()
        End If

        If selectedValues Is Nothing Then
            selectedValues = New List(Of String)()
        End If

        Return items.ToMultiSelectListItems(name, value, Function(x) selectedValues.Contains(value(x)))
    End Function

    <Extension> _
    Public Function ToMultiSelectListItems(Of T)(items As IEnumerable(Of T), name As Func(Of T, String), value As Func(Of T, String), isSelected As Func(Of T, Boolean)) As IEnumerable(Of SelectListItem)
        If items Is Nothing Then
            Return New List(Of SelectListItem)()
        End If

        Return items.[Select](Function(item) New SelectListItem() With { _
             .Text = name(item), _
             .Value = value(item), _
             .Selected = isSelected(item) _
        })
    End Function

End Module

