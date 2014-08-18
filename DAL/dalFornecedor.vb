Imports System.Data.SqlClient

Public Class dalFornecedor : Inherits dalBase

    Private _objSchema As ShL.schFornecedor

    Public Property objSchema() As ShL.schFornecedor
        Get
            Return _objSchema
        End Get
        Set(ByVal value As ShL.schFornecedor)
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

    Public Function InsertContato() As Integer
        Dim intRetorno As Integer = 0

        objStoredProcedure.Name = "st_PFD_fornecedor_contato_I"

        'Criar coleção de parâmetros
        objStoredProcedure.Parameters.Add(New SqlParameter("@id_solicitacao", SqlDbType.Int))
        objStoredProcedure.Parameters.Add(New SqlParameter("@nome", SqlDbType.VarChar))
        objStoredProcedure.Parameters.Add(New SqlParameter("@sobrenome", SqlDbType.VarChar))
        objStoredProcedure.Parameters.Add(New SqlParameter("@funcao", SqlDbType.VarChar))
        objStoredProcedure.Parameters.Add(New SqlParameter("@departamento", SqlDbType.VarChar))
        objStoredProcedure.Parameters.Add(New SqlParameter("@telefone", SqlDbType.VarChar))
        objStoredProcedure.Parameters.Add(New SqlParameter("@fax", SqlDbType.VarChar))
        objStoredProcedure.Parameters.Add(New SqlParameter("@celular", SqlDbType.VarChar))
        objStoredProcedure.Parameters.Add(New SqlParameter("@email", SqlDbType.VarChar))

        'Atribuir valores aos parâmetros
        objStoredProcedure.Parameters("@nm_cnpj").Value = _objSchema.nm_cnpj
        objStoredProcedure.Parameters("@nome").Value = _objSchema.objContato.no_nome
        objStoredProcedure.Parameters("@sobrenome").Value = _objSchema.objContato.no_sobrenome
        objStoredProcedure.Parameters("@funcao").Value = _objSchema.objContato.no_funcao
        objStoredProcedure.Parameters("@departamento").Value = _objSchema.objContato.no_departamento
        objStoredProcedure.Parameters("@telefone").Value = _objSchema.objContato.nm_telefone
        objStoredProcedure.Parameters("@fax").Value = _objSchema.objContato.nm_fax
        objStoredProcedure.Parameters("@celular").Value = _objSchema.objContato.nm_celular
        objStoredProcedure.Parameters("@email").Value = _objSchema.objContato.xx_email

        intRetorno = objStoredProcedure.Run() 'No caso do insert retorna Error
    End Function

    Public Function InsertFornecedor() As Integer
        Dim intRetorno As Integer = 0

        objStoredProcedure.Name = "st_PFD_fornecedor_I"

        'Criar coleção de parâmetros
        objStoredProcedure.Parameters.Add(New SqlParameter("@CNPJ", SqlDbType.VarChar, 16))
        objStoredProcedure.Parameters.Add(New SqlParameter("@razao_social", SqlDbType.VarChar, 70))
        objStoredProcedure.Parameters.Add(New SqlParameter("@nome_fantasia", SqlDbType.VarChar, 70))
        objStoredProcedure.Parameters.Add(New SqlParameter("@inscricao_estadual", SqlDbType.VarChar))
        objStoredProcedure.Parameters.Add(New SqlParameter("@inscricao_municipal", SqlDbType.VarChar))
        objStoredProcedure.Parameters.Add(New SqlParameter("@rua", SqlDbType.VarChar))
        objStoredProcedure.Parameters.Add(New SqlParameter("@numero", SqlDbType.VarChar))
        objStoredProcedure.Parameters.Add(New SqlParameter("@complemento", SqlDbType.VarChar))
        objStoredProcedure.Parameters.Add(New SqlParameter("@bairro", SqlDbType.VarChar))
        objStoredProcedure.Parameters.Add(New SqlParameter("@CEP", SqlDbType.VarChar))
        objStoredProcedure.Parameters.Add(New SqlParameter("@caixa_postal", SqlDbType.VarChar))
        objStoredProcedure.Parameters.Add(New SqlParameter("@cidade", SqlDbType.VarChar))
        objStoredProcedure.Parameters.Add(New SqlParameter("@estado", SqlDbType.VarChar))
        objStoredProcedure.Parameters.Add(New SqlParameter("@pais", SqlDbType.VarChar))

        'Atribuir valores aos parâmetros
        objStoredProcedure.Parameters("@CNPJ").Value = _objSchema.objDadosBasicos.nm_CNPJ
        objStoredProcedure.Parameters("@razao_social").Value = _objSchema.objDadosBasicos.no_razao_social
        objStoredProcedure.Parameters("@nome_fantasia").Value = _objSchema.objDadosBasicos.no_nome_fantasia
        objStoredProcedure.Parameters("@inscricao_estadual").Value = _objSchema.objDadosBasicos.nm_inscricao_estadual
        objStoredProcedure.Parameters("@inscricao_municipal").Value = _objSchema.objDadosBasicos.nm_inscricao_municipal
        objStoredProcedure.Parameters("@rua").Value = _objSchema.objDadosBasicos.no_rua
        objStoredProcedure.Parameters("@numero").Value = _objSchema.objDadosBasicos.nm_numero
        objStoredProcedure.Parameters("@complemento").Value = _objSchema.objDadosBasicos.xx_complemento
        objStoredProcedure.Parameters("@bairro").Value = _objSchema.objDadosBasicos.no_bairro
        objStoredProcedure.Parameters("@CEP").Value = _objSchema.objDadosBasicos.nm_CEP
        objStoredProcedure.Parameters("@caixa_postal").Value = _objSchema.objDadosBasicos.nm_caixa_postal
        objStoredProcedure.Parameters("@cidade").Value = _objSchema.objDadosBasicos.no_cidade
        objStoredProcedure.Parameters("@estado").Value = _objSchema.objDadosBasicos.sg_estado
        objStoredProcedure.Parameters("@pais").Value = _objSchema.objDadosBasicos.cd_pais

        intRetorno = objStoredProcedure.Run() 'No caso do insert retorna Error
    End Function

    Public Function InsertDadosAdicionais() As Integer
        Dim intRetorno As Integer = 0

        objStoredProcedure.Name = "[st_PFD_fornecedor_dados_adicionais_I]"

        'Criar coleção de parâmetros
        objStoredProcedure.Parameters.Add(New SqlParameter("@nm_cnpj", SqlDbType.VarChar))
        objStoredProcedure.Parameters.Add(New SqlParameter("@como_conheceu", SqlDbType.Int))
        objStoredProcedure.Parameters.Add(New SqlParameter("@contato", SqlDbType.VarChar))
        objStoredProcedure.Parameters.Add(New SqlParameter("@servicos", SqlDbType.VarChar))
        objStoredProcedure.Parameters.Add(New SqlParameter("@materiais", SqlDbType.VarChar))

        'Atribuir valores aos parâmetros
        objStoredProcedure.Parameters("@nm_cnpj").Value = _objSchema.nm_cnpj
        objStoredProcedure.Parameters("@como_conheceu").Value = _objSchema.objDadosAdicionais.objComoConheceu.cd_como_conheceu
        objStoredProcedure.Parameters("@contato").Value = _objSchema.objDadosAdicionais.no_contato
        objStoredProcedure.Parameters("@servicos").Value = _objSchema.objDadosAdicionais.dc_servicos
        objStoredProcedure.Parameters("@materiais").Value = _objSchema.objDadosAdicionais.dc_materiais

        intRetorno = objStoredProcedure.Run() 'No caso do insert retorna Error
    End Function

    Public Overrides Function Insert() As Integer
        Dim intRetorno As Integer = 0

        InsertFornecedor()
        InsertContato()
        InsertDadosAdicionais()

    End Function

    Public Overrides Function Update() As Integer

    End Function

#Region "ValidaFornecedor"
    Public Function ValidaFornecedor(ByVal schSchema As ShL.schFornecedor) As System.Data.DataTable
        objStoredProcedure.Name = "st_PFD_valida_fornecedor_S"

        objStoredProcedure.Parameters.Add(New SqlParameter("@nm_cnpj", SqlDbType.VarChar))
        objStoredProcedure.Parameters("@nm_cnpj").Value = schSchema.nm_cnpj

        objStoredProcedure.Parameters.Add(New SqlParameter("@xx_chave_acesso", SqlDbType.VarChar))
        objStoredProcedure.Parameters("@xx_chave_acesso").Value = schSchema.xx_chave_acesso

        Dim objDt As New DataTable("Forn")
        If (objStoredProcedure.Run(objDt) > 0) Then
            Return objDt
        End If

        Return Nothing
    End Function
#End Region

#Region "ValidaRecuperaChave"
    Public Function ValidaRecuperaChave(ByVal schSchema As ShL.schFornecedor) As System.Data.DataTable
        objStoredProcedure.Name = "st_PFD_valida_recupera_chave_S"

        objStoredProcedure.Parameters.Add(New SqlParameter("@nm_cnpj", SqlDbType.VarChar))
        objStoredProcedure.Parameters("@nm_cnpj").Value = schSchema.nm_cnpj

        objStoredProcedure.Parameters.Add(New SqlParameter("@xx_email", SqlDbType.VarChar))
        objStoredProcedure.Parameters("@xx_email").Value = schSchema.objContato.xx_email

        Dim objDt As New DataTable("Forn")
        If (objStoredProcedure.Run(objDt) > 0) Then
            Return objDt
        End If

        Return Nothing
    End Function
#End Region

#Region "getFornecedorByCNPJ"
    Public Function getFornecedorByCNPJ(ByVal CNPJ As String) As System.Data.DataTable
        objStoredProcedure.Name = "st_PFD_fornecedor_S"

        objStoredProcedure.Parameters.Add(New SqlParameter("@CNPJ", SqlDbType.VarChar))
        objStoredProcedure.Parameters("@CNPJ").Value = CNPJ

        Dim objDt As New DataTable("Forn")
        If (objStoredProcedure.Run(objDt) > 0) Then
            Return objDt
        End If

        Return Nothing
    End Function
#End Region

#Region "getFornecedorDadosBasicosByPK"
    Public Function getFornecedorDadosBasicosByPK(ByVal CNPJ As String) As System.Data.DataTable
        objStoredProcedure.Name = "st_PFD_fornecedor_dados_basicos_S"

        objStoredProcedure.Parameters.Add(New SqlParameter("@CNPJ", SqlDbType.VarChar))
        objStoredProcedure.Parameters("@CNPJ").Value = CNPJ

        Dim objDt As New DataTable("Forn")
        If (objStoredProcedure.Run(objDt) > 0) Then
            Return objDt
        End If

        Return Nothing
    End Function
#End Region

#Region "getFornecedorContatoByPK"
    Public Function getFornecedorContatoByPK(ByVal CNPJ As String) As System.Data.DataTable
        objStoredProcedure.Name = "st_PFD_fornecedor_contato_S"

        objStoredProcedure.Parameters.Add(New SqlParameter("@CNPJ", SqlDbType.VarChar))
        objStoredProcedure.Parameters("@CNPJ").Value = CNPJ

        Dim objDt As New DataTable("Forn")
        If (objStoredProcedure.Run(objDt) > 0) Then
            Return objDt
        End If

        Return Nothing
    End Function
#End Region

#Region "getFornecedorDadosAdicionaisByPK"
    Public Function getFornecedorDadosAdicionaisByPK(ByVal CNPJ As String) As System.Data.DataTable
        objStoredProcedure.Name = "st_PFD_fornecedor_dados_adicionais_S"

        objStoredProcedure.Parameters.Add(New SqlParameter("@CNPJ", SqlDbType.VarChar))
        objStoredProcedure.Parameters("@CNPJ").Value = CNPJ

        Dim objDt As New DataTable("Forn")
        If (objStoredProcedure.Run(objDt) > 0) Then
            Return objDt
        End If

        Return Nothing
    End Function
#End Region



End Class
