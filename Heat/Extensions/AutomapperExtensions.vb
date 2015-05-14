Imports System.Runtime.CompilerServices
Imports AutoMapper

Public Module AutomapperExtensions
    <Extension> _
    Public Sub Bidirectional(Of TSource, TDestination)(this As IMappingExpression(Of TSource, TDestination))
        Mapper.CreateMap(Of TDestination, TSource)()
    End Sub






End Module
