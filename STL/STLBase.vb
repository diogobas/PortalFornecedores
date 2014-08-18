Imports System.Data.SqlClient
Imports System
Public Class STLBase
    Inherits Object
    Implements IDisposable

    Private blnDisposedValue As Boolean = False        ' To detect redundant calls

#Region "Contructor"
    Public Sub New()
        Me._objConnection = New SqlConnection(Common.getSqlConnection)
    End Sub
#End Region

#Region "SqlConnection"
    Protected _objConnection As SqlConnection
    Public ReadOnly Property objConnection() As SqlConnection
        Get
            Return _objConnection
        End Get
    End Property
#End Region

#Region "SqlTransaction"

    Protected _objTransaction As SqlTransaction
    Public ReadOnly Property objTransaction() As SqlTransaction
        Get
            Return _objTransaction
        End Get
    End Property

#End Region

#Region "Connect"
    Public Function Connect() As Boolean
        Return Me.Connect(Common.getSqlConnection)
    End Function

    Public Function Connect(ByVal stringconnection As String) As Boolean
        Try
            If (Me._objConnection Is Nothing) Then
                Me._objConnection = New SqlConnection(stringconnection)
            End If

            If (Me._objConnection.State = ConnectionState.Closed) Then
                Me._objConnection.Open()
            End If
            Return True
        Catch ex As Exception
            Throw New Exception("Erro ao conectar base de dados", ex)
        End Try
    End Function
#End Region

#Region "BeginTransaction"
    Public Function BeginTransaction() As Boolean
        Try
            Me.Connect()
            Me._objTransaction = Me._objConnection.BeginTransaction()
        Catch ex As Exception
            Throw New Exception("BeginTransaction")
        End Try
    End Function

    Public Function BeginTransaction(ByVal iso As System.Data.IsolationLevel, ByVal transactionName As String) As Boolean
        Try
            Me.Connect()
            Me._objTransaction = Me._objConnection.BeginTransaction(iso, transactionName)
        Catch ex As Exception
            Throw New Exception("BeginTransaction")
        End Try
    End Function

    Public Function BeginTransaction(ByVal transactionName As String) As Boolean
        Try
            Me.Connect()
            Me._objTransaction = Me._objConnection.BeginTransaction(transactionName)
        Catch ex As Exception
            Throw New Exception("BeginTransaction")
        End Try
    End Function


    Public Function BeginTransaction(ByVal iso As System.Data.IsolationLevel) As Boolean
        Try
            Me.Connect()
            Me._objTransaction = Me._objConnection.BeginTransaction(iso)
        Catch ex As Exception
            Throw New Exception("BeginTransaction")
        End Try
    End Function

#End Region

#Region "RollBack"
    Public Function RollBack() As Boolean
        Try
            If (Not Me._objTransaction Is Nothing) Then
                Me._objTransaction.Rollback()
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
#End Region

#Region "Commit"
    Public Function Commit() As Boolean
        Try
            Me._objTransaction.Commit()
        Catch ex As Exception
            Return False
        End Try
    End Function
#End Region

#Region "Dispose"

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal blnDisposing As Boolean)
        If Not blnDisposedValue Then
            If blnDisposing Then

            End If

            If (Not Me._objConnection Is Nothing) Then
                Me._objConnection = Nothing
            End If

            If (Not Me.objTransaction Is Nothing) Then
                Me._objTransaction = Nothing
            End If
        End If
        Me.blnDisposedValue = True
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
