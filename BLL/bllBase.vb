Imports System.Web
Imports System.Data.SqlClient
Imports System
Imports System.Web.UI.WebControls
Imports STL
Public MustInherit Class bllBase
    Inherits Object
    Implements IDisposable

    Private _intAcao As Integer
    Protected _objData As DAL.dalBase

    Public intNumberError As Integer

#Region "eAcao"
    Public Enum enuBaseAcao
        eNone = 0
        eIncluir
        eAlterar
        eExcluir
        ePesquisar
    End Enum
#End Region

#Region "Properties"

#Region "objData"
    Public Property objDataBase() As DAL.dalBase
        Get
            Return _objData
        End Get
        Set(ByVal value As DAL.dalBase)
            _objData = value
        End Set
    End Property
#End Region

#Region "Acao"
    Public Property intAcao() As Integer
        Get
            Return _intAcao
        End Get
        Set(ByVal value As Integer)
            _intAcao = value
        End Set
    End Property
#End Region

#End Region

#Region "Save"
    'Salvar vai chamar o método correto a depender da Acao do Objeto
    Public Overridable Function Save() As Boolean
        Select Case intAcao
            Case enuBaseAcao.eIncluir
                'Chamar método de incluir do DataBase
                _objData.Insert()
            Case enuBaseAcao.eAlterar
                'Chamar método de alterar do DataBase
                _objData.Update()
        End Select
        Return True
    End Function
#End Region

#Region "Delete"
    Public MustOverride Function Delete(ByVal key As DataKey) As Boolean
#End Region

#Region "getAll"
    'Public Function getAll() As DataTable
    '    Return _objData.getAll()
    'End Function
#End Region

#Region "Dispose"
    Private disposedValue As Boolean = False        ' To detect redundant calls
    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If

            If (Not _objData Is Nothing) Then
                _objData.Dispose()
                _objData = Nothing
            End If
        End If
        Me.disposedValue = True
    End Sub

#Region " IDisposable Support "
    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region
#End Region

End Class
