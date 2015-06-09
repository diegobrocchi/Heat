Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports Heat
Imports Heat.Repositories

Namespace Controllers
    Public Class CausalWarehousesController
        Inherits System.Web.Mvc.Controller

        Private _db As IHeatDBContext

        Public Sub New(context As IHeatDBContext)
            _db = context
        End Sub

        ' GET: CausalWarehouses
        Function Index() As ActionResult
            Dim causalWarehouses = _db.CausalWarehouses.Include(Function(c) c.Type)
            Return View(causalWarehouses.ToList())
        End Function

        ' GET: CausalWarehouses/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim causalWarehouse As CausalWarehouse = _db.CausalWarehouses.Find(id)
            If IsNothing(causalWarehouse) Then
                Return HttpNotFound()
            End If
            Return View(causalWarehouse)
        End Function

        ' GET: CausalWarehouses/Create
        Function Create() As ActionResult
            ViewBag.TypeID = New SelectList(_db.CausalWarehouseGroups, "ID", "Code")
            Return View()
        End Function

        ' POST: CausalWarehouses/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="ID,Code,Sign,TypeID,Transaction")> ByVal causalWarehouse As CausalWarehouse) As ActionResult
            If ModelState.IsValid Then
                _db.CausalWarehouses.Add(causalWarehouse)
                _db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.TypeID = New SelectList(_db.CausalWarehouseGroups, "ID", "Code", causalWarehouse.TypeID)
            Return View(causalWarehouse)
        End Function

        ' GET: CausalWarehouses/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim causalWarehouse As CausalWarehouse = _db.CausalWarehouses.Find(id)
            If IsNothing(causalWarehouse) Then
                Return HttpNotFound()
            End If
            ViewBag.TypeID = New SelectList(_db.CausalWarehouseGroups, "ID", "Code", causalWarehouse.TypeID)
            Return View(causalWarehouse)
        End Function

        ' POST: CausalWarehouses/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="ID,Code,Sign,TypeID,Transaction")> ByVal causalWarehouse As CausalWarehouse) As ActionResult
            If ModelState.IsValid Then
                _db.SetModified(causalWarehouse) '.State = EntityState.Modified
                _db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.TypeID = New SelectList(_db.CausalWarehouseGroups, "ID", "Code", causalWarehouse.TypeID)
            Return View(causalWarehouse)
        End Function

        ' GET: CausalWarehouses/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim causalWarehouse As CausalWarehouse = _db.CausalWarehouses.Find(id)
            If IsNothing(causalWarehouse) Then
                Return HttpNotFound()
            End If
            Return View(causalWarehouse)
        End Function

        ' POST: CausalWarehouses/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim causalWarehouse As CausalWarehouse = _db.CausalWarehouses.Find(id)
            _db.CausalWarehouses.Remove(causalWarehouse)
            _db.SaveChanges()
            Return RedirectToAction("Index")
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                _db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
