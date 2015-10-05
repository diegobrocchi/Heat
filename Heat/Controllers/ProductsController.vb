Imports System.Data.Entity
Imports System.Net
Imports DataTables.AspNet.Core
Imports Heat.Models
Imports Heat.Manager


Namespace Controllers
    Public Class ProductsController
        Inherits Controller

        Private _db As IHeatDBContext
        Private _pm As ProductManager

        Public Sub New(dbcontext As IHeatDBContext)
            _db = dbcontext
            _pm = New ProductManager(_db)
        End Sub

        ' GET: Products
        Function Index() As ActionResult
            Return View(_db.Products.ToList())
        End Function

        ' GET: Products/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim product As Product = _db.Products.Find(id)
            If IsNothing(product) Then
                Return HttpNotFound()
            End If
            Return View(product)
        End Function

        ' GET: Products/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: Products/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="ID,SKU,Description,UnitPrice,Cost,ReorderLevel")> ByVal product As Product) As ActionResult
            If ModelState.IsValid Then
                _db.Products.Add(product)
                _db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(product)
        End Function

        ' GET: Products/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim product As Product = _db.Products.Find(id)
            If IsNothing(product) Then
                Return HttpNotFound()
            End If
            Return View(product)
        End Function

        ' POST: Products/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="ID,SKU,Description,UnitPrice,Cost,ReorderLevel")> ByVal product As Product) As ActionResult
            If ModelState.IsValid Then
                '_db.Entry(product).State = EntityState.Modified
                _db.SetModified(product)
                _db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(product)
        End Function

        ' GET: Products/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim product As Product = _db.Products.Find(id)
            If IsNothing(product) Then
                Return HttpNotFound()
            End If
            Return View(product)
        End Function

        ' POST: Products/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim product As Product = _db.Products.Find(id)
            _db.Products.Remove(product)
            _db.SaveChanges()
            Return RedirectToAction("Index")
        End Function

        <HttpGet>
        Public Function GetPagedProducts(request As IDataTablesRequest) As ActionResult
            If ModelState.IsValid Then
                Return _pm.GetPagedProducts(request)
            Else
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
        End Function


        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                _db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
