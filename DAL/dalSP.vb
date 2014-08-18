Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Reflection
Imports System.Runtime.InteropServices

Public NotInheritable Class dalSP
    Implements IDisposable

    Private objCommand As SqlCommand
#Region "Parameters"
    Public ReadOnly Property Parameters() As SqlParameterCollection
        Get
            Return Me.objCommand.Parameters
        End Get
    End Property
#End Region

#Region "Name"
    Public Property Name() As String
        Get
            Return Me.objCommand.CommandText
        End Get
        Set(ByVal value As String)
            Me.objCommand.CommandText = value
            Me.objCommand.Parameters.Clear() '
            objCommand.Parameters.Add(New SqlParameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.ReturnValue, False, 0, 0, String.Empty, DataRowVersion.Default, Nothing))
        End Set
    End Property
#End Region

#Region "Constructors"

    '''	<summary>
    '''	Construtor de uma stored procedure    
    ''' </summary>
    Public Sub New()
        objCommand = (New SqlConnection(Common.getSqlConnection)).CreateCommand
        objCommand.CommandType = CommandType.StoredProcedure
        objCommand.Parameters.Add(New SqlParameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.ReturnValue, False, 0, 0, String.Empty, DataRowVersion.Default, Nothing))
    End Sub
    '''	<summary>
    '''	Construtor de uma stored procedure
    '''	<param name='STL'>
    ''' Controle de transacao </param>    
    ''' </summary>
    Public Sub New(ByRef STL As STL.STLBase)
        objCommand = STL.objConnection.CreateCommand
        objCommand.Transaction = STL.objTransaction
        objCommand.CommandType = CommandType.StoredProcedure
        objCommand.Parameters.Add(New SqlParameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.ReturnValue, False, 0, 0, String.Empty, DataRowVersion.Default, Nothing))
    End Sub
#End Region

#Region "Dispose"
    '''	<summary>
    '''	Dispose de StoredProcedure.
    ''' </summary>
    Public Sub Dispose() Implements IDisposable.Dispose
        If Not (objCommand Is Nothing) Then
            Dim objConex As SqlConnection
            Try
                objConex = objCommand.Connection
                Debug.Assert(Not (objCommand Is Nothing))
                If (Not objCommand Is Nothing) Then
                    objCommand.Dispose()
                End If
                If (Not objConex Is Nothing) Then
                    objConex.Dispose()

                End If
            Catch ex As Exception

            Finally
                objCommand = Nothing
                objConex = Nothing

            End Try

        End If
    End Sub
#End Region

#Region "run"
    '''	<summary>
    ''' Executa esta stored procedure.
    '''	<returns>Um valor Int32 retornado pela stored procedure</returns>
    ''' </summary>
    Public Function Run() As Integer
        If (objCommand Is Nothing) Then
            Throw New ObjectDisposedException([GetType].FullName)
        End If
        'Abrir conexão
        If objCommand.Connection.State = ConnectionState.Closed Then
            objCommand.Connection.Open()
        End If
        objCommand.ExecuteNonQuery()
        Return CInt(objCommand.Parameters("ReturnValue").Value)
    End Function

    ''' <summary>
    '''	Preenche um DataSet com o resultado da execução desta stored procedure.
    ''' <param name='dataTable'>
    ''' DataTable preenchido com o resultado da execução da stored procedure</param>
    ''' <returns>
    ''' Um valor Int32 retornado pela stored procedure</returns>
    ''' </summary>
    Public Function Run(ByRef dt As DataTable) As Integer
        If (objCommand Is Nothing) Then
            Throw New ObjectDisposedException([GetType].FullName)
        End If

        Dim objDataAdapter As New SqlDataAdapter
        objDataAdapter.SelectCommand = objCommand
        objDataAdapter.Fill(dt)

        Return dt.Rows.Count 'CInt(objCommand.Parameters("ReturnValue").Value)
    End Function

    Public Function Run(ByRef ds As DataSet) As Integer
        If (objCommand Is Nothing) Then
            Throw New ObjectDisposedException([GetType].FullName)
        End If

        Dim objDataAdapter As New SqlDataAdapter
        objDataAdapter.SelectCommand = objCommand
        objDataAdapter.Fill(ds)

        Return ds.Tables.Count
    End Function
#End Region
End Class
