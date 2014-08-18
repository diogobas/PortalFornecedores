Imports System.Data.SqlClient

Public Class dalUF : Inherits dalBase

    Private _objSchema As ShL.schUF

    Public Property objSchema() As ShL.schUF
        Get
            Return _objSchema
        End Get
        Set(ByVal value As ShL.schUF)
            _objSchema = value
        End Set
    End Property

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByRef objSTL As STL.STLBase)
        MyBase.New(objSTL)
    End Sub

    Public Overrides Function Delete() As Integer

    End Function

    Public Overloads Function Delete(ByVal Funcionario_ID As Integer) As Integer

    End Function

    Public Overrides Function getAll() As System.Data.DataTable
        objStoredProcedure.Name = "st_ODU_uf_s"

        Dim objDt As New DataTable("UF")

        If objStoredProcedure.Run(objDt) > 0 Then
            Return objDt
        End If

        Return Nothing

    End Function

    Public Overrides Function getDetailByPK() As ShL.schBase
        Return Nothing

    End Function

    Public Overrides Function Insert() As Integer

    End Function

    Public Overrides Function Update() As Integer

    End Function

End Class
