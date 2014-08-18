Imports System.Data.SqlClient

Public Class dalCAT : Inherits dalBase

    Private _objSchema As ShL.schCAT

    Public Property objSchema() As ShL.schCAT
        Get
            Return _objSchema
        End Get
        Set(ByVal value As ShL.schCAT)
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

    Public Overrides Function getAll() As System.Data.DataTable

        Return Nothing

    End Function

    Public Overrides Function getDetailByPK() As ShL.schBase
        Return Nothing

    End Function

    Public Overrides Function Insert() As Integer

    End Function

    Public Overrides Function Update() As Integer

    End Function

#Region "getPermissoes_ByUsuario"
    Public Function getPermissoes_ByUsuario(objSchema As ShL.schCAT) As System.Data.DataTable
        objStoredProcedure.Name = "st_PFD_CAT_usuario_sistema_transacao_s"

        objStoredProcedure.Parameters.Add(New SqlParameter("@Usuario", SqlDbType.VarChar))
        objStoredProcedure.Parameters("@Usuario").Value = objSchema.sUsuario

        objStoredProcedure.Parameters.Add(New SqlParameter("@Sistema", SqlDbType.VarChar))
        objStoredProcedure.Parameters("@Sistema").Value = "PFD"

        Dim objDt As New DataTable("CAT")
        If (objStoredProcedure.Run(objDt) > 0) Then
            Return objDt
        End If

        Return Nothing
    End Function
#End Region


End Class
