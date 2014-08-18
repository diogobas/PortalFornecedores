Imports System.Data.SqlClient
Imports System.Data
Imports System

'Inteface que deverá ser implementada pelas classes do DAL
Interface iDAL
    Function getAll() As DataTable
    Function getDetailByPK() As ShL.schBase
    Function Insert() As Integer
    Function Update() As Integer
    Function Delete() As Integer
End Interface

'Classe básica de onde todas as classes do data deverão herdar
Public MustInherit Class dalBase
    Implements iDAL, IDisposable

    Protected blnDisposed As Boolean = False
    Public objStoredProcedure As DAL.dalSP = Nothing

#Region " IDisposable Support "
    Public Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
    Protected Overrides Sub Finalize()
        Dispose(False)
        MyBase.Finalize()
    End Sub

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If (Not objStoredProcedure Is Nothing) Then
            objStoredProcedure.Dispose()
            objStoredProcedure = Nothing
        End If
        Me.blnDisposed = True
    End Sub
#End Region

#Region "Construtores"
    Public Sub New()
        Me.objStoredProcedure = New DAL.dalSP()
    End Sub

    Public Sub New(ByRef objSTL As STL.STLBase)
        Me.objStoredProcedure = New DAL.dalSP(objSTL)
    End Sub
#End Region

#Region "Schema"
    Public objSchemaBase As ShL.schBase
#End Region


    Public MustOverride Function Delete() As Integer Implements iDAL.Delete

    Public MustOverride Function getAll() As System.Data.DataTable Implements iDAL.getAll

    Public MustOverride Function getDetailByPK() As ShL.schBase Implements iDAL.getDetailByPK

    Public MustOverride Function Insert() As Integer Implements iDAL.Insert

    Public MustOverride Function Update() As Integer Implements iDAL.Update
End Class
