Imports System.Data.SqlClient
Imports System.Web.UI.WebControls
Imports System.Net.Mail
Imports System.Data

Public Class bllConfiguracao : Inherits bllBase

#Region "Construtores"

    Sub New()
        MyBase.New()
        Me.objData = New DAL.dalConfiguracao()
    End Sub

    Sub New(ByRef objSchema As ShL.schConfiguracao)
        Me.New()
        Me.objData.objSchemaBase = objSchema
    End Sub
#End Region

#Region "objData"
    Property objData() As DAL.dalConfiguracao
        Get
            Return _objData
        End Get
        Set(ByVal value As DAL.dalConfiguracao)
            _objData = value
        End Set
    End Property
#End Region

#Region "Delete"
    Public Overrides Function Delete(ByVal key As System.Web.UI.WebControls.DataKey) As Boolean

    End Function
#End Region

#Region "Insert"
    Public Function Insert(ByRef objSchema As ShL.schConfiguracao) As Boolean
    End Function
#End Region

#Region "Insert"

#End Region

#Region "getAllConfiguracao"
    Public Function getAllConfiguracao() As DataTable
        Dim objConfiguracao As New DAL.dalConfiguracao()
        Return objConfiguracao.getAll
    End Function
#End Region

#Region "getConfiguracao"
    Public Shared Function getConfiguracao() As ShL.schConfiguracao
        Dim objConfiguracao As New DAL.dalConfiguracao()
        Dim oDataTable = objConfiguracao.getAll
        Dim oSchConfiguracao As New ShL.schConfiguracao

        oSchConfiguracao.xx_servidor_smtp = oDataTable.Rows(0).Item("xx_servidor_smtp")
        oSchConfiguracao.xx_email_remetente = oDataTable.Rows(0).Item("xx_email_remetente")
        oSchConfiguracao.xx_nome_remetente = oDataTable.Rows(0).Item("xx_nome_remetente")
        oSchConfiguracao.xx_email_destinatario_eventos = oDataTable.Rows(0).Item("xx_email_destinatario_eventos")
        oSchConfiguracao.xx_envia_email_solicitacao_cadastro = oDataTable.Rows(0).Item("xx_envia_email_solicitacao_cadastro")
        oSchConfiguracao.xx_envia_email_solicitacao_chave = oDataTable.Rows(0).Item("xx_envia_email_solicitacao_chave")
        oSchConfiguracao.xx_envia_email_solicitacao_alteracao = oDataTable.Rows(0).Item("xx_envia_email_solicitacao_alteracao")
        oSchConfiguracao.xx_envia_email_retorno_solicitacao_cadastro = oDataTable.Rows(0).Item("xx_envia_email_retorno_solicitacao_cadastro")
        oSchConfiguracao.xx_envia_email_retorno_solicitacao_chave = oDataTable.Rows(0).Item("xx_envia_email_retorno_solicitacao_chave")
        oSchConfiguracao.xx_envia_email_retorno_solicitacao_alteracao = oDataTable.Rows(0).Item("xx_envia_email_retorno_solicitacao_alteracao")

        Return oSchConfiguracao

    End Function
#End Region


#Region "Update"
    Public Function Update(ByRef objSchema As ShL.schConfiguracao) As Boolean

    End Function
#End Region

#Region "getConfiguracaoByPk"
    'Public Function getConfiguracaoByPk(ByVal Funcionario_ID As Integer) As DataTable
    '    Dim objConfiguracao As New DAL.dalConfiguracao()
    '    Return objConfiguracao.getConfiguracaoByPk(Funcionario_ID)
    'End Function
#End Region


End Class
