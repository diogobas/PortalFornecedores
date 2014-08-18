Imports System.Data.SqlClient
Imports System.Web.UI.WebControls
Imports System.Net.Mail
Imports System.Data

Public Class bllTraceAcesso : Inherits bllBase

#Region "Construtores"

    Sub New()
        MyBase.New()
        Me.objData = New DAL.dalTraceAcesso()
    End Sub

    Sub New(ByRef objSchema As ShL.schTraceAcesso)
        Me.New()
        Me.objData.objSchemaBase = objSchema
    End Sub
#End Region

#Region "objData"
    Property objData() As DAL.dalTraceAcesso
        Get
            Return _objData
        End Get
        Set(ByVal value As DAL.dalTraceAcesso)
            _objData = value
        End Set
    End Property
#End Region

#Region "Delete"
    Public Overrides Function Delete(ByVal key As System.Web.UI.WebControls.DataKey) As Boolean

    End Function
#End Region

#Region "Insert"
    Public Function Insert(ByRef objSchema As ShL.schTraceAcesso) As Boolean
        Dim objSTL As STL.STLBase = New STL.STLBase()
        Dim objCont As DAL.dalTraceAcesso = Nothing

        objSTL.BeginTransaction()
        objCont = New DAL.dalTraceAcesso(objSTL)
        objCont.objSchema = objSchema
        Try
            objCont.Insert()

            objSTL.Commit()
        Catch ex As SqlException
            objSTL.RollBack()
            Throw
        Catch ex As Exception
            objSTL.RollBack()
            Throw
        Finally
            objSTL.Dispose()
            objCont.Dispose()
        End Try

        Return True
    End Function
#End Region


End Class
