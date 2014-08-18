Imports System.Data.SqlClient

Public Class dalTraceAcesso : Inherits dalBase

    Private _objSchema As ShL.schTraceAcesso

    Public Property objSchema() As ShL.schTraceAcesso
        Get
            Return _objSchema
        End Get
        Set(ByVal value As ShL.schTraceAcesso)
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

    Public Overloads Function Delete(ByVal ID_Unidade As Integer) As Integer

    End Function

    Public Overrides Function getAll() As System.Data.DataTable

        Return Nothing
    End Function

    Public Function getUnidadeByPK(ByVal Contato_ID As Integer) As System.Data.DataTable

        Return Nothing
    End Function

    Public Function getUnidadeByUnidadeNegocio(ByVal Contato_ID As Integer) As System.Data.DataTable
        Return Nothing
    End Function

    Public Overrides Function getDetailByPK() As ShL.schBase
        Return Nothing

    End Function

    Public Overrides Function Insert() As Integer

        Dim intRetorno As Integer = 0

        objStoredProcedure.Name = "[st_ODU_trace_acesso_i]"

        'Criar coleção de parâmetros
        objStoredProcedure.Parameters.Add(New SqlParameter("@Pagina", SqlDbType.VarChar))
        objStoredProcedure.Parameters.Add(New SqlParameter("@Origem", SqlDbType.Char))


        'Atribuir valores aos parâmetros
        objStoredProcedure.Parameters("@Pagina").Value = _objSchema.no_pagina
        objStoredProcedure.Parameters("@Origem").Value = _objSchema.xx_origem_acesso

        intRetorno = objStoredProcedure.Run() 'No caso do insert retorna Error
        Return intRetorno

    End Function

    Public Overrides Function Update() As Integer

    End Function

End Class
