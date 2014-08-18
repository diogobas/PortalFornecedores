Imports System.Data.SqlClient

Public Class dalSolicitacaoAlteracao : Inherits dalBase

    Private _objSchema As ShL.schSolicitacaoAlteracao

    Public Property objSchema() As ShL.schSolicitacaoAlteracao
        Get
            Return _objSchema
        End Get
        Set(ByVal value As ShL.schSolicitacaoAlteracao)
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

    Public Function InsertSolicitacaoAlteracao() As Integer
        Dim intRetorno As Integer = 0

        objStoredProcedure.Name = "st_PFD_solicitacao_alteracao_I"

        'Criar coleção de parâmetros
        objStoredProcedure.Parameters.Add(New SqlParameter("@id_solicitacao", SqlDbType.Int))
        objStoredProcedure.Parameters.Add(New SqlParameter("@cnpj", SqlDbType.VarChar))
        objStoredProcedure.Parameters.Add(New SqlParameter("@rua", SqlDbType.VarChar))
        objStoredProcedure.Parameters.Add(New SqlParameter("@numero", SqlDbType.VarChar))
        objStoredProcedure.Parameters.Add(New SqlParameter("@complemento", SqlDbType.VarChar))
        objStoredProcedure.Parameters.Add(New SqlParameter("@bairro", SqlDbType.VarChar))
        objStoredProcedure.Parameters.Add(New SqlParameter("@CEP", SqlDbType.VarChar))
        objStoredProcedure.Parameters.Add(New SqlParameter("@caixa_postal", SqlDbType.VarChar))
        objStoredProcedure.Parameters.Add(New SqlParameter("@cidade", SqlDbType.VarChar))
        objStoredProcedure.Parameters.Add(New SqlParameter("@estado", SqlDbType.VarChar))
        objStoredProcedure.Parameters.Add(New SqlParameter("@pais", SqlDbType.VarChar))

        objStoredProcedure.Parameters.Add(New SqlParameter("@nome", SqlDbType.VarChar))
        objStoredProcedure.Parameters.Add(New SqlParameter("@sobrenome", SqlDbType.VarChar))
        objStoredProcedure.Parameters.Add(New SqlParameter("@funcao", SqlDbType.VarChar))
        objStoredProcedure.Parameters.Add(New SqlParameter("@departamento", SqlDbType.VarChar))
        objStoredProcedure.Parameters.Add(New SqlParameter("@telefone", SqlDbType.VarChar))
        objStoredProcedure.Parameters.Add(New SqlParameter("@fax", SqlDbType.VarChar))
        objStoredProcedure.Parameters.Add(New SqlParameter("@celular", SqlDbType.VarChar))
        objStoredProcedure.Parameters.Add(New SqlParameter("@email", SqlDbType.VarChar))

        objStoredProcedure.Parameters.Add(New SqlParameter("@servicos", SqlDbType.VarChar))
        objStoredProcedure.Parameters.Add(New SqlParameter("@materiais", SqlDbType.VarChar))

        'Atribuir valores aos parâmetros
        objStoredProcedure.Parameters("@id_solicitacao").Direction = ParameterDirection.Output
        objStoredProcedure.Parameters("@cnpj").Value = _objSchema.objDadosBasicos.nm_CNPJ
        objStoredProcedure.Parameters("@rua").Value = _objSchema.objDadosBasicos.no_rua
        objStoredProcedure.Parameters("@numero").Value = _objSchema.objDadosBasicos.nm_numero
        objStoredProcedure.Parameters("@complemento").Value = _objSchema.objDadosBasicos.xx_complemento
        objStoredProcedure.Parameters("@bairro").Value = _objSchema.objDadosBasicos.no_bairro
        objStoredProcedure.Parameters("@CEP").Value = _objSchema.objDadosBasicos.nm_CEP
        objStoredProcedure.Parameters("@caixa_postal").Value = _objSchema.objDadosBasicos.nm_caixa_postal
        objStoredProcedure.Parameters("@cidade").Value = _objSchema.objDadosBasicos.no_cidade
        objStoredProcedure.Parameters("@estado").Value = _objSchema.objDadosBasicos.sg_estado
        objStoredProcedure.Parameters("@pais").Value = _objSchema.objDadosBasicos.cd_pais

        objStoredProcedure.Parameters("@nome").Value = _objSchema.objContato.no_nome
        objStoredProcedure.Parameters("@sobrenome").Value = _objSchema.objContato.no_sobrenome
        objStoredProcedure.Parameters("@funcao").Value = _objSchema.objContato.no_funcao
        objStoredProcedure.Parameters("@departamento").Value = _objSchema.objContato.no_departamento
        objStoredProcedure.Parameters("@telefone").Value = _objSchema.objContato.nm_telefone
        objStoredProcedure.Parameters("@fax").Value = _objSchema.objContato.nm_fax
        objStoredProcedure.Parameters("@celular").Value = _objSchema.objContato.nm_celular
        objStoredProcedure.Parameters("@email").Value = _objSchema.objContato.xx_email

        objStoredProcedure.Parameters("@servicos").Value = _objSchema.objDadosAdicionais.dc_servicos
        objStoredProcedure.Parameters("@materiais").Value = _objSchema.objDadosAdicionais.dc_materiais

        intRetorno = objStoredProcedure.Run() 'No caso do insert retorna Error
        _objSchema.id_solicitacao = objStoredProcedure.Parameters("@id_solicitacao").Value
    End Function

#Region "getSolicitacaoChaveAcesso_ByFiltro"
    Public Function getSolicitacaoAlteracao_ByFiltro(oFiltro As ShL.schDadosFiltro) As System.Data.DataTable
        objStoredProcedure.Name = "st_PFD_solicitacao_alteracao_by_filtro_S"

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

#Region "getSumario"
    Public Function getSumario() As System.Data.DataTable
        objStoredProcedure.Name = "st_PFD_sumario_solicitacao_alteracao_S"


        Dim objDt As New DataTable("Sumario")
        If (objStoredProcedure.Run(objDt) > 0) Then
            Return objDt
        End If

        Return Nothing
    End Function
#End Region



    Public Overrides Function Insert() As Integer
        Dim intRetorno As Integer = 0

        InsertSolicitacaoAlteracao()

    End Function

    Public Overrides Function Update() As Integer

    End Function

    Public Function ValidaSolicitacaoAlteracao() As Integer
        Dim intRetorno As Integer = 0

        objStoredProcedure.Name = "st_PFD_valida_solicitacao_alteracao_G"

        'Criar coleção de parâmetros
        objStoredProcedure.Parameters.Add(New SqlParameter("@id_solicitacao", SqlDbType.Int))
        objStoredProcedure.Parameters.Add(New SqlParameter("@CNPJ", SqlDbType.VarChar, 16))
        objStoredProcedure.Parameters.Add(New SqlParameter("@usuario", SqlDbType.VarChar, 10))

        'Atribuir valores aos parâmetros
        objStoredProcedure.Parameters("@id_solicitacao").Value = _objSchema.id_solicitacao
        objStoredProcedure.Parameters("@CNPJ").Value = _objSchema.objDadosBasicos.nm_CNPJ
        objStoredProcedure.Parameters("@usuario").Value = _objSchema.cd_usuario_atualizacao

        intRetorno = objStoredProcedure.Run() 'No caso do insert retorna Error
    End Function


#Region "getSolicitacaoAlteracaoByCNPJ"
    Public Function getSolicitacaoAlteracaoByCNPJ(ByVal CNPJ As String) As System.Data.DataTable
        objStoredProcedure.Name = "st_PFD_solicitacao_alteracao_S"

        objStoredProcedure.Parameters.Add(New SqlParameter("@CNPJ", SqlDbType.VarChar))
        objStoredProcedure.Parameters("@CNPJ").Value = CNPJ

        Dim objDt As New DataTable("SolicAlteracao")
        If (objStoredProcedure.Run(objDt) > 0) Then
            Return objDt
        End If

        Return Nothing
    End Function
#End Region

#Region "getSolicitacaoAlteracaoByPK"
    Public Function getSolicitacaoAlteracaoByPK(ByVal ID As Int16) As System.Data.DataTable
        objStoredProcedure.Name = "st_PFD_solicitacao_alteracao_by_PK_S"

        objStoredProcedure.Parameters.Add(New SqlParameter("@ID", SqlDbType.Int))
        objStoredProcedure.Parameters("@ID").Value = ID

        Dim objDt As New DataTable("SolicAlteracao")
        If (objStoredProcedure.Run(objDt) > 0) Then
            Return objDt
        End If

        Return Nothing
    End Function
#End Region


End Class
