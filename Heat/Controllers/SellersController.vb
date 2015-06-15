Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports Heat.Models
Imports Heat.Repositories

Namespace Controllers
    Public Class SellersController
        Inherits System.Web.Mvc.Controller

        Private db As New HeatDBContext

        ' GET: Sellers
        Function Index() As ActionResult
            Return View(db.Seller.ToList())
        End Function

        ' GET: Sellers/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim seller As Seller = db.Seller.Find(id)
            If IsNothing(seller) Then
                Return HttpNotFound()
            End If
            Return View(seller)
        End Function

        ' GET: Sellers/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: Sellers/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="ID,FiscalCode,IBAN,Logo,Name,Vat_Number")> ByVal seller As Seller) As ActionResult
            If ModelState.IsValid Then
                db.Seller.Add(seller)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(seller)
        End Function

        ' GET: Sellers/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim seller As Seller = db.Seller.Find(id)
            If IsNothing(seller) Then
                Return HttpNotFound()
            End If
            Return View(seller)
        End Function

        ' POST: Sellers/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="ID,FiscalCode,IBAN,Logo,Name,Vat_Number")> ByVal seller As Seller) As ActionResult
            If ModelState.IsValid Then
                db.Entry(seller).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(seller)
        End Function

        ' GET: Sellers/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim seller As Seller = db.Seller.Find(id)
            If IsNothing(seller) Then
                Return HttpNotFound()
            End If
            Return View(seller)
        End Function

        ' POST: Sellers/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim seller As Seller = db.Seller.Find(id)
            db.Seller.Remove(seller)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
