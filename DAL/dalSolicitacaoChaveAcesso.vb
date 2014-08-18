Imports System.Data.SqlClient

Public Class dalSolicitacaoChaveAcesso : Inherits dalBase

    Private _objSchema As ShL.schSolicitacaoChaveAcesso

    Public Property objSchema() As ShL.schSolicitacaoChaveAcesso
        Get
            Return _objSchema
        End Get
        Set(ByVal value As ShL.schSolicitacaoChaveAcesso)
            _objSchema = value
        End Set
    End Property

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByRef objSTL As STL.STLBase)
        MyBase.New(objSTL)
    End Sub

#Region "Delete"
    Public Overrides Function Delete() As Integer

    End Function

    Public Overloads Function Delete(ByVal Contato_ID As Integer) As Integer
        'objStoredProcedure.Name = "P_DEL_FUNCIONARIO"

        'objStoredProcedure.Parameters.Add(New SqlParameter("@Contato_ID", SqlDbType.Int))
        'objStoredProcedure.Parameters("@Contato_ID").Value = Contato_ID

        Return objStoredProcedure.Run()
    End Function
#End Region

    Public Overrides Function getAll() As System.Data.DataTable

        Return Nothing
    End Function

    Public Overrides Function getDetailByPK() As ShL.schBase
        Return Nothing
    End Function

    Public Function InsertSolicitacaoChaveAcesso() As Integer
        Dim intRetorno As Integer = 0

        objStoredProcedure.Name = "st_PFD_solicitacao_chave_acesso_I"

        'Criar coleção de parâmetros
        objStoredProcedure.Parameters.Add(New SqlParameter("@cnpj", SqlDbType.VarChar))
        objStoredProcedure.Parameters.Add(New SqlParameter("@razao_social", SqlDbType.VarChar))
        objStoredProcedure.Parameters.Add(New SqlParameter("@solicitante", SqlDbType.VarChar))
        objStoredProcedure.Parameters.Add(New SqlParameter("@email", SqlDbType.VarChar))

        'Atribuir valores aos parâmetros
        objStoredProcedure.Parameters("@cnpj").Value = _objSchema.nm_cnpj
        objStoredProcedure.Parameters("@razao_social").Value = _objSchema.no_razao_social
        objStoredProcedure.Parameters("@solicitante").Value = _objSchema.no_solicitante
        objStoredProcedure.Parameters("@email").Value = _objSchema.xx_email

        intRetorno = objStoredProcedure.Run() 'No caso do insert retorna Error
    End Function

    Public Overrides Function Insert() As Integer
        Dim intRetorno As Integer = 0

        InsertSolicitacaoChaveAcesso()

    End Function

    Public Overrides Function Update() As Integer

    End Function

    Public Function ValidaSolicitacaoChaveAcesso() As Integer
        Dim intRetorno As Integer = 0

        objStoredProcedure.Name = "st_PFD_valida_solicitacao_chave_acesso_G"

        'Criar coleção de parâmetros
        objStoredProcedure.Parameters.Add(New SqlParameter("@id_solicitacao", SqlDbType.Int))
        objStoredProcedure.Parameters.Add(New SqlParameter("@CNPJ", SqlDbType.VarChar, 16))
        objStoredProcedure.Parameters.Add(New SqlParameter("@usuario", SqlDbType.VarChar, 10))

        objStoredProcedure.Parameters.Add(New SqlParameter("@ChaveAcesso", SqlDbType.VarChar, 11))

        'Atribuir valores aos parâmetros
        objStoredProcedure.Parameters("@id_solicitacao").Value = _objSchema.id_solicitacao_chave_acesso
        objStoredProcedure.Parameters("@CNPJ").Value = _objSchema.nm_cnpj
        objStoredProcedure.Parameters("@usuario").Value = _objSchema.cd_usuario_atualizacao

        objStoredProcedure.Parameters("@ChaveAcesso").Direction = ParameterDirection.Output

        intRetorno = objStoredProcedure.Run() 'No caso do insert retorna Error
        _objSchema.xx_chave_acesso = objStoredProcedure.Parameters("@ChaveAcesso").Value

    End Function


#Region "getSolicitacaoAlteracao_ByFiltro"
    Public Function getSolicitacaoChaveAcesso_ByFiltro(oFiltro As ShL.schDadosFiltro) As System.Data.DataTable
        objStoredProcedure.Name = "st_PFD_solicitacao_chave_by_filtro_S"

        objStoredProcedure.Parameters.Add(New SqlParameter("@DataIni", SqlDbType.SmallDateTime))
        objStoredProcedure.Parameters("@DataIni").Value = IIf(oFiltro.dt_inicial = Nothing, DBNull.Value, oFiltro.dt_inicial)

        objStoredProcedure.Parameters.Add(New SqlParameter("@DataFim", SqlDbType.SmallDateTime))
        objStoredProcedure.Parameters("@DataFim").Value = IIf(oFiltro.dt_final = Nothing, DBNull.Value, oFiltro.dt_final)

        objStoredProcedure.Parameters.Add(New SqlParameter("@Status", SqlDbType.Int))
        objStoredProcedure.Parameters("@Status").Value = IIf(oFiltro.cd_status = -1, DBNull.Value, oFiltro.cd_status)

        Dim objDt As New DataTable("SolicCadastro")
        If (objStoredProcedure.Run(objDt) > 0) Then
            Return objDt
        End If

        Return Nothing
    End Function
#End Region

#Region "getSolicitacaoChaveAcessoByCNPJ"
    Public Function getSolicitacaoChaveAcessoByCNPJ(ByVal CNPJ As String) As System.Data.DataTable
        objStoredProcedure.Name = "st_PFD_solicitacao_chave_by_PK_S"

        objStoredProcedure.Parameters.Add(New SqlParameter("@CNPJ", SqlDbType.VarChar))
        objStoredProcedure.Parameters("@CNPJ").Value = CNPJ

        Dim objDt As New DataTable("SolicChave")
        If (objStoredProcedure.Run(objDt) > 0) Then
            Return objDt
        End If

        Return Nothing
    End Function
#End Region

#Region "getSolicitacaoChaveAcessoByPK"
    Public Function getSolicitacaoChaveAcessoByPK(ByVal ID As Int16) As System.Data.DataTable
        objStoredProcedure.Name = "st_PFD_solicitacao_chave_by_PK_S"

        objStoredProcedure.Parameters.Add(New SqlParameter("@ID", SqlDbType.Int))
        objStoredProcedure.Parameters("@ID").Value = ID

        Dim objDt As New DataTable("SolicChave")
        If (objStoredProcedure.Run(objDt) > 0) Then
            Return objDt
        End If

        Return Nothing
    End Function
#End Region

#Region "getSumario"
    Public Function getSumario() As System.Data.DataTable
        objStoredProcedure.Name = "st_PFD_sumario_solicitacao_chave_acesso_S"


        Dim objDt As New DataTable("Sumario")
        If (objStoredProcedure.Run(objDt) > 0) Then
            Return objDt
        End If

        Return Nothing
    End Function
#End Region



End Class
