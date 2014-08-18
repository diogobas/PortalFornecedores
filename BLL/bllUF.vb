Imports System.Data.SqlClient
Imports System.Web.UI.WebControls
Imports System.Net.Mail
Imports System.Data

Public Class bllUF : Inherits bllBase

#Region "Construtores"

    Sub New()
        MyBase.New()
        Me.objData = New DAL.dalUF()
    End Sub

    Sub New(ByRef objSchema As ShL.schUF)
        Me.New()
        Me.objData.objSchemaBase = objSchema
    End Sub
#End Region

#Region "objData"
    Property objData() As DAL.dalUF
        Get
            Return _objData
        End Get
        Set(ByVal value As DAL.dalUF)
            _objData = value
        End Set
    End Property
#End Region

#Region "Delete"
    Public Overrides Function Delete(ByVal key As System.Web.UI.WebControls.DataKey) As Boolean

    End Function
#End Region

#Region "Insert"
    Public Function Insert(ByRef objSchema As ShL.schUF) As Boolean
    End Function
#End Region

#Region "getUF_ByFilter"
    'Public Function getFuncionario_ByFilter(ByVal schSchema As ShL.schUF) As DataTable
    '    Dim objUF As New DAL.dalUF()
    '    Return objUF.getFuncionario_ByFilter(schSchema)
    'End Function
#End Region

#Region "Insert"

#End Region

#Region "getAllUF"
    Public Function getAllUF() As DataTable
        Dim objUF As New DAL.dalUF()
        Return objUF.getAll
    End Function
#End Region

#Region "Update"
    Public Function Update(ByRef objSchema As ShL.schUF) As Boolean

    End Function
#End Region

#Region "getUFByPk"
    'Public Function getUFByPk(ByVal Funcionario_ID As Integer) As DataTable
    '    Dim objUF As New DAL.dalUF()
    '    Return objUF.getUFByPk(Funcionario_ID)
    'End Function
#End Region


End Class
