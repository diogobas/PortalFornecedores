Imports System.Data.SqlClient

Public Class dalSolicitacaoCadastro : Inherits dalBase

    Private _objSchema As ShL.schSolicitacaoCadastro

    Public Property objSchema() As ShL.schSolicitacaoCadastro
        Get
            Return _objSchema
        End Get
        Set(ByVal value As ShL.schSolicitacaoCadastro)
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

        objStoredProcedure.Name = "st_PFD_solicitacao_cadastro_contato_I"

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
        objStoredProcedure.Parameters.Add(New SqlParameter("@nome_solicitante", SqlDbType.VarChar))
        objStoredProcedure.Parameters.Add(New SqlParameter("@area_solicitante", SqlDbType.VarChar))
        objStoredProcedure.Parameters.Add(New SqlParameter("@telefone_solicitante", SqlDbType.VarChar))
        objStoredProcedure.Parameters.Add(New SqlParameter("@observacao_solicitante", SqlDbType.VarChar))

        'Atribuir valores aos parâmetros
        objStoredProcedure.Parameters("@id_solicitacao").Value = _objSchema.id_solicitacao
        objStoredProcedure.Parameters("@nome").Value = _objSchema.objContato.no_nome
        objStoredProcedure.Parameters("@sobrenome").Value = _objSchema.objContato.no_sobrenome
        objStoredProcedure.Parameters("@funcao").Value = _objSchema.objContato.no_funcao
        objStoredProcedure.Parameters("@departamento").Value = _objSchema.objContato.no_departamento
        objStoredProcedure.Parameters("@telefone").Value = _objSchema.objContato.nm_telefone
        objStoredProcedure.Parameters("@fax").Value = _objSchema.objContato.nm_fax
        objStoredProcedure.Parameters("@celular").Value = _objSchema.objContato.nm_celular
        objStoredProcedure.Parameters("@email").Value = _objSchema.objContato.xx_email
        objStoredProcedure.Parameters("@nome_solicitante").Value = _objSchema.objContato.no_nome_solicitante
        objStoredProcedure.Parameters("@area_solicitante").Value = _objSchema.objContato.no_area_solicitante
        objStoredProcedure.Parameters("@telefone_solicitante").Value = _objSchema.objContato.nm_telefone_solicitante
        objStoredProcedure.Parameters("@observacao_solicitante").Value = _objSchema.objContato.no_observacao_solicitante

        intRetorno = objStoredProcedure.Run() 'No caso do insert retorna Error
    End Function

    Public Function InsertSolicitacaoCadastro() As Integer
        Dim intRetorno As Integer = 0

        objStoredProcedure.Name = "st_PFD_solicitacao_cadastro_I"

        'Criar coleção de parâmetros
        objStoredProcedure.Parameters.Add(New SqlParameter("@id_solicitacao", SqlDbType.Int))
        objStoredProcedure.Parameters.Add(New SqlParameter("@xx_chave_acesso", SqlDbType.VarChar, 11))
        objStoredProcedure.Parameters.Add(New SqlParameter("@tipo_solicitacao", SqlDbType.VarChar, 2))
        objStoredProcedure.Parameters.Add(New SqlParameter("@operacao", SqlDbType.VarChar, 15))
        objStoredProcedure.Parameters.Add(New SqlParameter("@empresa", SqlDbType.VarChar, 50))
        objStoredProcedure.Parameters.Add(New SqlParameter("@categoria", SqlDbType.VarChar, 50))
        objStoredProcedure.Parameters.Add(New SqlParameter("@indicacao", SqlDbType.VarChar, 50))
        objStoredProcedure.Parameters.Add(New SqlParameter("@fornecimento", SqlDbType.VarChar, 50))
        objStoredProcedure.Parameters.Add(New SqlParameter("@id_fisc", SqlDbType.VarChar, 50))
        objStoredProcedure.Parameters.Add(New SqlParameter("@cod_sap", SqlDbType.VarChar, 50))
        objStoredProcedure.Parameters.Add(New SqlParameter("@obs", SqlDbType.Text))
        objStoredProcedure.Parameters.Add(New SqlParameter("@tipo_material", SqlDbType.VarChar, 50))
        objStoredProcedure.Parameters.Add(New SqlParameter("@tipo_servico", SqlDbType.VarChar, 50))
        objStoredProcedure.Parameters.Add(New SqlParameter("@CPF", SqlDbType.VarChar, 14))
        objStoredProcedure.Parameters.Add(New SqlParameter("@CNPJ", SqlDbType.VarChar, 16))
        objStoredProcedure.Parameters.Add(New SqlParameter("@razao_social", SqlDbType.VarChar, 70))
        objStoredProcedure.Parameters.Add(New SqlParameter("@razao_social_empresa", SqlDbType.VarChar, 70))
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
        objStoredProcedure.Parameters.Add(New SqlParameter("@usuario_solicitacao", SqlDbType.VarChar))

        'Atribuir valores aos parâmetros
        objStoredProcedure.Parameters("@id_solicitacao").Direction = ParameterDirection.Output
        objStoredProcedure.Parameters("@xx_chave_acesso").Direction = ParameterDirection.Output
        objStoredProcedure.Parameters("@tipo_solicitacao").Value = _objSchema.objDadosBasicos.no_tipo_solicitacao
        objStoredProcedure.Parameters("@operacao").Value = _objSchema.objDadosBasicos.no_operacao        
        objStoredProcedure.Parameters("@empresa").Value = _objSchema.objDadosBasicos.no_empresa
        objStoredProcedure.Parameters("@categoria").Value = _objSchema.objDadosBasicos.no_categoria
        objStoredProcedure.Parameters("@indicacao").Value = _objSchema.objDadosBasicos.no_indicacao
        objStoredProcedure.Parameters("@fornecimento").Value = _objSchema.objDadosBasicos.no_fornecimento
        objStoredProcedure.Parameters("@id_fisc").Value = _objSchema.objDadosBasicos.nm_id_fisc
        objStoredProcedure.Parameters("@cod_sap").Value = _objSchema.objDadosBasicos.nm_cod_sap
        objStoredProcedure.Parameters("@obs").Value = _objSchema.objDadosBasicos.no_obs
        objStoredProcedure.Parameters("@tipo_material").Value = _objSchema.objDadosBasicos.no_tipo_material
        objStoredProcedure.Parameters("@tipo_servico").Value = _objSchema.objDadosBasicos.no_tipo_servico
        objStoredProcedure.Parameters("@CPF").Value = _objSchema.objDadosBasicos.nm_CPF
        objStoredProcedure.Parameters("@CNPJ").Value = _objSchema.objDadosBasicos.nm_CNPJ
        objStoredProcedure.Parameters("@razao_social").Value = _objSchema.objDadosBasicos.no_razao_social
        objStoredProcedure.Parameters("@razao_social_empresa").Value = _objSchema.objDadosBasicos.no_razao_social
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
        objStoredProcedure.Parameters("@usuario_solicitacao").Value = _objSchema.cd_usuario_solicitacao

        intRetorno = objStoredProcedure.Run() 'No caso do insert retorna Error
        _objSchema.id_solicitacao = objStoredProcedure.Parameters("@id_solicitacao").Value
        _objSchema.xx_chave_acesso = objStoredProcedure.Parameters("@xx_chave_acesso").Value
    End Function

    Public Function ValidaSolicitacaoCadastro() As Integer
        Dim intRetorno As Integer = 0

        objStoredProcedure.Name = "st_PFD_valida_solicitacao_cadastro_G"

        'Criar coleção de parâmetros
        objStoredProcedure.Parameters.Add(New SqlParameter("@id_solicitacao", SqlDbType.Int))
        objStoredProcedure.Parameters.Add(New SqlParameter("@CNPJ", SqlDbType.VarChar, 16))
        objStoredProcedure.Parameters.Add(New SqlParameter("@usuario", SqlDbType.VarChar, 10))
        objStoredProcedure.Parameters.Add(New SqlParameter("@motivo", SqlDbType.Text))

        'Atribuir valores aos parâmetros
        objStoredProcedure.Parameters("@id_solicitacao").Value = _objSchema.id_solicitacao
        objStoredProcedure.Parameters("@CNPJ").Value = _objSchema.objDadosBasicos.nm_CNPJ
        objStoredProcedure.Parameters("@usuario").Value = _objSchema.cd_usuario_atualizacao
        objStoredProcedure.Parameters("@motivo").Value = _objSchema.dc_motivo_recusa

        intRetorno = objStoredProcedure.Run() 'No caso do insert retorna Error
    End Function

    Public Function RecusaSolicitacaoCadastro() As Integer
        Dim intRetorno As Integer = 0

        objStoredProcedure.Name = "st_PFD_recusa_solicitacao_cadastro_G"

        'Criar coleção de parâmetros
        objStoredProcedure.Parameters.Add(New SqlParameter("@id_solicitacao", SqlDbType.Int))
        objStoredProcedure.Parameters.Add(New SqlParameter("@CNPJ", SqlDbType.VarChar, 16))
        objStoredProcedure.Parameters.Add(New SqlParameter("@usuario", SqlDbType.VarChar, 10))
        objStoredProcedure.Parameters.Add(New SqlParameter("@motivo", SqlDbType.Text))

        'Atribuir valores aos parâmetros
        objStoredProcedure.Parameters("@id_solicitacao").Value = _objSchema.id_solicitacao
        objStoredProcedure.Parameters("@CNPJ").Value = _objSchema.objDadosBasicos.nm_CNPJ
        objStoredProcedure.Parameters("@usuario").Value = _objSchema.cd_usuario_atualizacao
        objStoredProcedure.Parameters("@motivo").Value = _objSchema.dc_motivo_recusa

        intRetorno = objStoredProcedure.Run() 'No caso do insert retorna Error
    End Function

    Public Function InsertDadosAdicionais() As Integer
        Dim intRetorno As Integer = 0

        objStoredProcedure.Name = "[st_PFD_solicitacao_cadastro_dados_adicionais_I]"

        'Criar coleção de parâmetros
        objStoredProcedure.Parameters.Add(New SqlParameter("@id_solicitacao", SqlDbType.Int))
        objStoredProcedure.Parameters.Add(New SqlParameter("@como_conheceu", SqlDbType.Int))
        objStoredProcedure.Parameters.Add(New SqlParameter("@contato", SqlDbType.VarChar))
        objStoredProcedure.Parameters.Add(New SqlParameter("@servicos", SqlDbType.VarChar))
        objStoredProcedure.Parameters.Add(New SqlParameter("@materiais", SqlDbType.VarChar))
        objStoredProcedure.Parameters.Add(New SqlParameter("@optante", SqlDbType.VarChar))
        objStoredProcedure.Parameters.Add(New SqlParameter("@inss", SqlDbType.VarChar))
        objStoredProcedure.Parameters.Add(New SqlParameter("@cbo", SqlDbType.VarChar))
        objStoredProcedure.Parameters.Add(New SqlParameter("@sefip", SqlDbType.VarChar))
        objStoredProcedure.Parameters.Add(New SqlParameter("@inscricao_rural", SqlDbType.VarChar))
        objStoredProcedure.Parameters.Add(New SqlParameter("@condicao_pagamento", SqlDbType.VarChar))

        'Atribuir valores aos parâmetros
        objStoredProcedure.Parameters("@id_solicitacao").Value = _objSchema.id_solicitacao
        objStoredProcedure.Parameters("@como_conheceu").Value = _objSchema.objDadosAdicionais.objComoConheceu.cd_como_conheceu
        objStoredProcedure.Parameters("@contato").Value = _objSchema.objDadosAdicionais.no_contato
        objStoredProcedure.Parameters("@servicos").Value = _objSchema.objDadosAdicionais.dc_servicos
        objStoredProcedure.Parameters("@materiais").Value = _objSchema.objDadosAdicionais.dc_materiais
        objStoredProcedure.Parameters("@optante").Value = _objSchema.objDadosAdicionais.xx_optante
        objStoredProcedure.Parameters("@inss").Value = _objSchema.objDadosAdicionais.dc_inss
        objStoredProcedure.Parameters("@cbo").Value = _objSchema.objDadosAdicionais.cd_cbo
        objStoredProcedure.Parameters("@sefip").Value = _objSchema.objDadosAdicionais.cd_sefip
        objStoredProcedure.Parameters("@inscricao_rural").Value = _objSchema.objDadosAdicionais.nm_inscricao_rural
        objStoredProcedure.Parameters("@condicao_pagamento").Value = _objSchema.objDadosAdicionais.cd_condicao_pagamento

        intRetorno = objStoredProcedure.Run() 'No caso do insert retorna Error
    End Function

    Public Overrides Function Insert() As Integer
        Dim intRetorno As Integer = 0

        InsertSolicitacaoCadastro()
        InsertContato()
        InsertDadosAdicionais()

    End Function

    Public Overrides Function Update() As Integer

    End Function

#Region "getSolicitacaoCadastro_ByFilter"
    'Public Function getContato_ByFilter(ByVal schSchema As ShL.schSolicitacaoCadastro) As System.Data.DataTable
    '    objStoredProcedure.Name = "st_PFD_valida_fornecedor_S"

    '    objStoredProcedure.Parameters.Add(New SqlParameter("@EnteJuridico_Id", SqlDbType.Int))
    '    objStoredProcedure.Parameters("@EnteJuridico_Id").Value = IIf(schSchema.EnteJuridico_Id = Nothing, DBNull.Value, schSchema.EnteJuridico_Id)

    '    objStoredProcedure.Parameters.Add(New SqlParameter("@vchNome", SqlDbType.VarChar))
    '    objStoredProcedure.Parameters("@vchNome").Value = IIf(schSchema.vchNome = "", DBNull.Value, schSchema.vchNome)

    '    objStoredProcedure.Parameters.Add(New SqlParameter("@chrSexo", SqlDbType.Char))
    '    objStoredProcedure.Parameters("@chrSexo").Value = IIf(schSchema.chrSexo = "-1", DBNull.Value, schSchema.chrSexo)

    '    objStoredProcedure.Parameters.Add(New SqlParameter("@bitAtivo", SqlDbType.Bit))
    '    objStoredProcedure.Parameters("@bitAtivo").Value = IIf(schSchema.Situacao = "-1", DBNull.Value, schSchema.Situacao)

    '    objStoredProcedure.Parameters.Add(New SqlParameter("@vchMatricula", SqlDbType.VarChar))
    '    objStoredProcedure.Parameters("@vchMatricula").Value = IIf(schSchema.vchMatricula = "", DBNull.Value, schSchema.vchMatricula)

    '    objStoredProcedure.Parameters.Add(New SqlParameter("@Cargo_ID", SqlDbType.Int))
    '    objStoredProcedure.Parameters("@Cargo_ID").Value = IIf(schSchema.Cargo_Id = Nothing, DBNull.Value, schSchema.Cargo_Id)

    '    Dim objDt As New DataTable("Func")
    '    If (objStoredProcedure.Run(objDt) > 0) Then
    '        Return objDt
    '    End If

    '    Return Nothing
    'End Function
#End Region

#Region "getSolicitacaoCadastro_ByFiltro"
    Public Function getSolicitacaoCadastro_ByFiltro(oFiltro As ShL.schDadosFiltro) As System.Data.DataTable
        objStoredProcedure.Name = "st_PFD_solicitacao_cadastro_by_filtro_S"

        objStoredProcedure.Parameters.Add(New SqlParameter("@DataIni", SqlDbType.SmallDateTime))
        objStoredProcedure.Parameters("@DataIni").Value = IIf(oFiltro.dt_inicial = Nothing, DBNull.Value, oFiltro.dt_inicial)

        objStoredProcedure.Parameters.Add(New SqlParameter("@DataFim", SqlDbType.SmallDateTime))
        objStoredProcedure.Parameters("@DataFim").Value = IIf(oFiltro.dt_final = Nothing, DBNull.Value, oFiltro.dt_final)

        objStoredProcedure.Parameters.Add(New SqlParameter("@Status", SqlDbType.Int))
        objStoredProcedure.Parameters("@Status").Value = IIf(oFiltro.cd_status = -1, DBNull.Value, oFiltro.cd_status)

        objStoredProcedure.Parameters.Add(New SqlParameter("@Origem", SqlDbType.VarChar))
        objStoredProcedure.Parameters("@Origem").Value = IIf(oFiltro.cd_origem = "", DBNull.Value, oFiltro.cd_origem)

        objStoredProcedure.Parameters.Add(New SqlParameter("@Operacao", SqlDbType.Int))
        objStoredProcedure.Parameters("@Operacao").Value = IIf(oFiltro.cd_operacao = -1, DBNull.Value, oFiltro.cd_operacao)

        Dim objDt As New DataTable("SolicCadastro")
        If (objStoredProcedure.Run(objDt) > 0) Then
            Return objDt
        End If

        Return Nothing
    End Function
#End Region

#Region "getSumario"
    Public Function getSumario() As System.Data.DataTable
        objStoredProcedure.Name = "st_PFD_sumario_solicitacao_cadastro_S"


        Dim objDt As New DataTable("Sumario")
        If (objStoredProcedure.Run(objDt) > 0) Then
            Return objDt
        End If

        Return Nothing
    End Function
#End Region

#Region "getSolicitacaoCadastroByCNPJ"
    Public Function getSolicitacaoCadastroByCNPJ(ByVal CNPJ As String) As System.Data.DataTable
        objStoredProcedure.Name = "st_PFD_solicitacao_cadastro_S"

        objStoredProcedure.Parameters.Add(New SqlParameter("@CNPJ", SqlDbType.VarChar))
        objStoredProcedure.Parameters("@CNPJ").Value = CNPJ

        Dim objDt As New DataTable("Forn")
        If (objStoredProcedure.Run(objDt) > 0) Then
            Return objDt
        End If

        Return Nothing
    End Function
#End Region

#Region "getSolicitacaoCadastroById"
    Public Function getSolicitacaoCadastroById(ByVal ID As Integer) As System.Data.DataTable
        objStoredProcedure.Name = "st_PFD_solicitacao_cadastro_by_id_S"

        objStoredProcedure.Parameters.Add(New SqlParameter("@ID", SqlDbType.VarChar))
        objStoredProcedure.Parameters("@ID").Value = ID

        Dim objDt As New DataTable("Forn")
        If (objStoredProcedure.Run(objDt) > 0) Then
            Return objDt
        End If

        Return Nothing
    End Function
#End Region

#Region "getSolicitacaoCadastroDadosBasicosByPK"
    Public Function getSolicitacaoCadastroDadosBasicosByPK(ByVal ID As Int32) As System.Data.DataTable
        objStoredProcedure.Name = "st_PFD_solicitacao_cadastro_dados_empresa_S"

        objStoredProcedure.Parameters.Add(New SqlParameter("@ID", SqlDbType.Int))
        objStoredProcedure.Parameters("@ID").Value = ID

        Dim objDt As New DataTable("Forn")
        If (objStoredProcedure.Run(objDt) > 0) Then
            Return objDt
        End If

        Return Nothing
    End Function
#End Region

#Region "getCEPByText"
    Public Function getCEPByText(ByVal CEP As String) As System.Data.DataTable
        objStoredProcedure.Name = "st_PFD_solicitacao_cep_S"

        objStoredProcedure.Parameters.Add(New SqlParameter("@CEP", SqlDbType.VarChar))
        objStoredProcedure.Parameters("@CEP").Value = CEP

        Dim objDt As New DataTable("Forn")
        If (objStoredProcedure.Run(objDt) > 0) Then
            Return objDt
        End If

        Return Nothing
    End Function
#End Region


#Region "getSolicitacaoCadastroContatoByPK"
    Public Function getSolicitacaoCadastroContatoByPK(ByVal ID As Int32) As System.Data.DataTable
        objStoredProcedure.Name = "st_PFD_solicitacao_cadastro_contato_S"

        objStoredProcedure.Parameters.Add(New SqlParameter("@ID", SqlDbType.Int))
        objStoredProcedure.Parameters("@ID").Value = ID

        Dim objDt As New DataTable("Forn")
        If (objStoredProcedure.Run(objDt) > 0) Then
            Return objDt
        End If

        Return Nothing
    End Function
#End Region

#Region "getSolicitacaoCadastroDadosAdicionaisByPK"
    Public Function getSolicitacaoCadastroDadosAdicionaisByPK(ByVal ID As Int32) As System.Data.DataTable
        objStoredProcedure.Name = "st_PFD_solicitacao_cadastro_dados_adicionais_S"

        objStoredProcedure.Parameters.Add(New SqlParameter("@ID", SqlDbType.Int))
        objStoredProcedure.Parameters("@ID").Value = ID

        Dim objDt As New DataTable("Forn")
        If (objStoredProcedure.Run(objDt) > 0) Then
            Return objDt
        End If

        Return Nothing
    End Function
#End Region

#Region "getTipoMaterial"
    Public Function getTipoMaterial() As System.Data.DataTable
        objStoredProcedure.Name = "st_PFD_tipo_material_S"

        Dim objDt As New DataTable("Forn")
        If (objStoredProcedure.Run(objDt) > 0) Then
            Return objDt
        End If

        Return Nothing
    End Function
#End Region

#Region "getPais"
    Public Function getPais() As System.Data.DataTable
        objStoredProcedure.Name = "st_PFD_pais_S"

        Dim objDt As New DataTable("Forn")
        If (objStoredProcedure.Run(objDt) > 0) Then
            Return objDt
        End If

        Return Nothing
    End Function
#End Region

#Region "getCondPgmto"
    Public Function getCondPgmto(ByVal Cod As String) As System.Data.DataTable
        objStoredProcedure.Name = "st_PFD_cond_pgmto_S"

        objStoredProcedure.Parameters.Add(New SqlParameter("@Codigo", SqlDbType.VarChar))
        objStoredProcedure.Parameters("@Codigo").Value = Cod

        Dim objDt As New DataTable("Forn")
        Dim objDc As New DataColumn
        Dim i As Integer

        objDc.ColumnName = "Texto"
        objDc.Caption = "Texto"

        objDt.Columns.Add(objDc)

        If (objStoredProcedure.Run(objDt) > 0) Then
            For i = 0 To objDt.Rows.Count - 1
                objDt.Rows(i)("Texto") = objDt.Rows(i)("cd_condicao_pagamento").ToString & " - " & objDt.Rows(i)("dc_condicao_pagamento").ToString
            Next

            Return objDt
        End If

        Return Nothing
    End Function
#End Region

#Region "getAllCentros"
    Public Function getAllCentros() As System.Data.DataTable
        objStoredProcedure.Name = "st_PFD_centro_S"

        Dim objDt As New DataTable("Forn")
        If (objStoredProcedure.Run(objDt) > 0) Then
            Return objDt
        End If

        Return Nothing
    End Function
#End Region

#Region "getTipoServico"
    Public Function getTipoServico() As System.Data.DataTable
        objStoredProcedure.Name = "st_PFD_tipo_servico_S"

        Dim objDt As New DataTable("Forn")
        If (objStoredProcedure.Run(objDt) > 0) Then
            Return objDt
        End If

        Return Nothing
    End Function
#End Region




End Class
