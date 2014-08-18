Imports System.Data.SqlClient
Imports System.Web.UI.WebControls
Imports System.Net.Mail
Imports System.Data

Public Class bllCAT : Inherits bllBase

#Region "Construtores"

    Sub New()
        MyBase.New()
        Me.objData = New DAL.dalCAT()
    End Sub

    Sub New(ByRef objSchema As ShL.schCAT)
        Me.New()
        Me.objData.objSchemaBase = objSchema
    End Sub
#End Region

#Region "objData"
    Property objData() As DAL.dalCAT
        Get
            Return _objData
        End Get
        Set(ByVal value As DAL.dalCAT)
            _objData = value
        End Set
    End Property
#End Region

#Region "Delete"
    Public Overrides Function Delete(ByVal key As System.Web.UI.WebControls.DataKey) As Boolean

    End Function
#End Region

#Region "Insert"
    Public Function Insert(ByRef objSchema As ShL.schCAT) As Boolean
    End Function
#End Region

#Region "getPermissoes_ByUsuario"
    Public Sub getPermissoes_ByUsuario(ByRef schSchema As ShL.schCAT)
        Dim objCAT As New DAL.dalCAT()
        Dim oDataTable As Data.DataTable = objCAT.getPermissoes_ByUsuario(schSchema)
        If oDataTable Is Nothing Then
            schSchema.bLogado = False
        Else
            schSchema.bLogado = True
            schSchema.aPermissoes(0) = Common.Functions.DataTableToArray(oDataTable, "cd_transacao")
            schSchema.aPermissoes(1) = Common.Functions.DataTableToArray(oDataTable, "id_funcao")
        End If
    End Sub
#End Region

#Region "ValidaUsuario"
    Public Function ValidaUsuario(ByRef schSchema As ShL.schCAT) As Boolean
        getPermissoes_ByUsuario(schSchema)
        Return schSchema.bLogado
    End Function
#End Region

    Public Function ValidaPermissao(ByVal schSchema As ShL.schCAT, ByVal sTransacao As String, ByVal sFuncao As String) As Boolean
        Dim iIndex As Int16 = Array.IndexOf(schSchema.aPermissoes(0), sTransacao)
        If iIndex = -1 Then
            Return False
        End If

        Dim sPermissao = schSchema.aPermissoes(1)(iIndex)
        If sPermissao = sFuncao Then
            Return True
        End If

        If sFuncao = "C" Then
            Return True
        End If

        Return False
    End Function

#Region "getCATByPk"
    'Public Function getCATByPk(ByVal Funcionario_ID As Integer) As DataTable
    '    Dim objCAT As New DAL.dalCAT()
    '    Return objCAT.getCATByPk(Funcionario_ID)
    'End Function
#End Region


End Class
