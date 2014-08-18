Public Class frmCadastramento
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Common.Configuracao.getManutencao() Then
            Response.Redirect("Manutencao.aspx")
        End If

        If Not IsPostBack Then

            If Session("sUsuario") Is Nothing Then
                Response.Redirect("Login.aspx")
            End If

            CarregaCentros()
            CarregaTipoMaterial()
            CarregaTipoServico()
            CarregaPais()
            CarregaCondPgmto()

            btFinalizar.Attributes.Add("onclick", (Me.ClientScript.GetPostBackEventReference(btFinalizar, "") + ";this.value='Aguarde...';this.disabled = true;"))

        End If


    End Sub

    Private Sub CarregaShlnaSessao()
        Dim objSolicitacao As ShL.schSolicitacaoCadastro

        If Session("objSolicitacao") Is Nothing Then
            objSolicitacao = New ShL.schSolicitacaoCadastro
        Else
            objSolicitacao = Session("objSolicitacao")
        End If

        objSolicitacao.objDadosBasicos.no_operacao = ddlOperacao.SelectedValue
        objSolicitacao.objDadosBasicos.no_tipo_solicitacao = "I"
        objSolicitacao.objDadosBasicos.no_categoria = ddlCategoria.SelectedItem.Text
        objSolicitacao.objDadosBasicos.no_razao_social = txtRazaoSocial.Text

        Select Case ddlOperacao.SelectedValue
            Case 1
                objSolicitacao.objDadosBasicos.no_empresa = ddlEmpresa.SelectedItem.Text
                objSolicitacao.objDadosBasicos.no_indicacao = ddlIndicacao.SelectedItem.Text
                objSolicitacao.objDadosBasicos.no_nome_fantasia = txtNomeFantasia.Text

                Select Case ddlCategoria.SelectedValue
                    Case 1
                        objSolicitacao.objDadosBasicos.nm_CNPJ = Common.Functions.RetiraFormatoCNPJ(txtCNPJ.Text)
                    Case 2
                        objSolicitacao.objDadosBasicos.nm_CNPJ = Common.Functions.RetiraFormatoCNPJ(txtCNPJ.Text)
                        objSolicitacao.objDadosBasicos.no_fornecimento = ddlFornecimento.SelectedItem.Text
                        If Not rdbOptante.SelectedItem Is Nothing Then
                            objSolicitacao.objDadosAdicionais.xx_optante = rdbOptante.SelectedItem.Text
                        End If
                    Case 3
                        objSolicitacao.objDadosBasicos.nm_CPF = Common.Functions.RetiraFormatoCNPJ(txtCPF.Text)
                        objSolicitacao.objDadosBasicos.no_fornecimento = ddlFornecimento.SelectedItem.Text
                    Case 4
                        objSolicitacao.objDadosBasicos.nm_CPF = Common.Functions.RetiraFormatoCNPJ(txtCPF.Text)
                        objSolicitacao.objDadosBasicos.no_fornecimento = ddlFornecimento.SelectedItem.Text
                        objSolicitacao.objDadosAdicionais.nm_inscricao_rural = txtInscricaoRural.Text
                    Case 5
                        objSolicitacao.objDadosBasicos.nm_id_fisc = txtNumIdFisc.Text
                        objSolicitacao.objDadosBasicos.no_fornecimento = ddlFornecimento.SelectedItem.Text
                    Case 6
                        objSolicitacao.objDadosBasicos.nm_CNPJ = Common.Functions.RetiraFormatoCNPJ(txtCNPJ.Text)
                        objSolicitacao.objDadosBasicos.no_fornecimento = ddlFornecimento.SelectedItem.Text
                        If Not rdbOptante.SelectedItem Is Nothing Then
                            objSolicitacao.objDadosAdicionais.xx_optante = rdbOptante.SelectedItem.Text
                        End If
                    Case 7
                        objSolicitacao.objDadosBasicos.nm_CPF = Common.Functions.RetiraFormatoCNPJ(txtCPF.Text)
                        objSolicitacao.objDadosBasicos.no_fornecimento = ddlFornecimento.SelectedItem.Text
                    Case 8
                        objSolicitacao.objDadosBasicos.nm_CPF = Common.Functions.RetiraFormatoCNPJ(txtCPF.Text)
                End Select

            Case 2
                objSolicitacao.objDadosBasicos.no_obs = txtMotivo.Text
                objSolicitacao.objDadosBasicos.nm_cod_sap = txtCodSap.Text
                objSolicitacao.objDadosBasicos.no_razao_social = txtRazaoSocial.Text

            Case Else
                objSolicitacao.objDadosBasicos.no_obs = txtMotivo.Text
                objSolicitacao.objDadosBasicos.nm_cod_sap = txtCodSap.Text
                objSolicitacao.objDadosBasicos.no_razao_social = txtRazaoSocial.Text

        End Select

        Select Case ddlFornecimento.SelectedValue
            Case 1
                objSolicitacao.objDadosBasicos.no_tipo_material = ddlTipoMaterial.SelectedItem.Text
                objSolicitacao.objDadosBasicos.nm_inscricao_estadual = txtInscEstadual.Text
            Case 2
                objSolicitacao.objDadosBasicos.no_tipo_servico = ddlServico.SelectedItem.Text
                objSolicitacao.objDadosAdicionais.dc_inss = txtInss.Text
                objSolicitacao.objDadosAdicionais.cd_cbo = txtCbo.Text
                objSolicitacao.objDadosAdicionais.cd_sefip = ddlSefip.SelectedItem.Text
                objSolicitacao.objDadosBasicos.nm_inscricao_municipal = txtInscMunicipal.Text
            Case 3
                objSolicitacao.objDadosBasicos.no_tipo_material = ddlTipoMaterial.SelectedItem.Text
                objSolicitacao.objDadosBasicos.no_tipo_servico = ddlServico.SelectedItem.Text
                objSolicitacao.objDadosAdicionais.dc_inss = txtInss.Text
                objSolicitacao.objDadosAdicionais.cd_cbo = txtCbo.Text
                objSolicitacao.objDadosAdicionais.cd_sefip = ddlSefip.SelectedItem.Text
                objSolicitacao.objDadosBasicos.nm_inscricao_estadual = txtInscEstadual.Text
                objSolicitacao.objDadosBasicos.nm_inscricao_municipal = txtInscMunicipal.Text
        End Select

        objSolicitacao.objDadosBasicos.no_rua = txtEndereco.Text
        objSolicitacao.objDadosBasicos.nm_numero = txtNumero.Text
        objSolicitacao.objDadosBasicos.xx_complemento = txtComplemento.Text
        objSolicitacao.objDadosBasicos.no_bairro = txtBairro.Text
        objSolicitacao.objDadosBasicos.nm_CEP = txtCep.Text
        objSolicitacao.objDadosBasicos.nm_caixa_postal = txtCaixaPostal.Text
        objSolicitacao.objDadosBasicos.no_cidade = txtCidade.Text
        objSolicitacao.objDadosBasicos.sg_estado = ddlEstado.SelectedItem.Text
        objSolicitacao.objDadosBasicos.cd_pais = ddlSiglaPais.SelectedValue

        objSolicitacao.objContato.no_nome = txtNomeContato.Text
        objSolicitacao.objContato.no_sobrenome = txtSobrenomeContato.Text
        objSolicitacao.objContato.no_funcao = txtFuncaoContato.Text
        objSolicitacao.objContato.no_departamento = txtDepartamentoContato.Text
        objSolicitacao.objContato.nm_telefone = txtTelefoneContato.Text
        objSolicitacao.objContato.nm_fax = txtFaxContato.Text
        objSolicitacao.objContato.nm_celular = txtCelularContato.Text
        objSolicitacao.objContato.xx_email = txtEmailContato.Text
        objSolicitacao.objContato.no_nome_solicitante = txtNomeSolicitante.Text
        objSolicitacao.objContato.no_area_solicitante = txtArea.Text
        objSolicitacao.objContato.nm_telefone_solicitante = txtTelefoneSolicitante.Text
        objSolicitacao.objContato.no_observacao_solicitante = txtObs.Text
        objSolicitacao.objDadosAdicionais.cd_condicao_pagamento = ddlCondPgmto.SelectedValue
        objSolicitacao.cd_usuario_solicitacao = Session("sUsuario")

        Session("objSolicitacao") = objSolicitacao

    End Sub

    Protected Sub btProximo_Click(sender As Object, e As EventArgs) Handles btFinalizar.Click
        Dim objSolicitacao As ShL.schSolicitacaoCadastro
        Dim objBllSolicitacao As New BLL.bllSolicitacaoCadastro

        If Not ValidaCampos() Then
            Exit Sub
        End If

        CarregaShlnaSessao()
        objSolicitacao = Session("objSolicitacao")

        Try
            objBllSolicitacao.Insert(objSolicitacao)
            objBllSolicitacao.EnviaEmailRetorno(objSolicitacao)
            objBllSolicitacao.EnviaEmailAnalise(objSolicitacao)
            Session("objSolicitacao") = Nothing
            ExibeMensagemPopUp("Confirmação", "Seu cadastro foi realizado com sucesso!" + Chr(13) + "Seus dados serão analisados por nossa equipe interna.", _
                               "OK", "javascript:window.location.href=""./Login.aspx""; return false;")
        Catch ex As Exception
            If ex.Message.StartsWith("W:") Then
                ExibeMensagemPopUp("Info", ex.Message.Replace("W:", ""), "OK", "")
            Else
                ExibeMensagemPopUp("Mensagem de Erro", "Aconteceu um erro inesperado ao realizadar sua solicitação!" + Chr(13) + ex.Message)
            End If
        End Try

    End Sub

    Private Function ValidaCampos() As Boolean

        If ddlOperacao.SelectedValue = 0 Then
            ExibeMensagemPopUp("Validação", "Informe a Operação.")
            Return False
        End If

        Select Case ddlOperacao.SelectedValue
            Case 1
                If ddlEmpresa.SelectedValue = 0 Then
                    ExibeMensagemPopUp("Validação", "Informe a Empresa.")
                    Return False
                ElseIf ddlCategoria.SelectedValue = 0 Then
                    ExibeMensagemPopUp("Validação", "Informe a Categoria.")
                    Return False
                ElseIf txtRazaoSocial.Text.Length = 0 Then
                    ExibeMensagemPopUp("Validação", "Informe a Razão Social.")
                    Return False
                ElseIf txtNomeFantasia.Text.Length = 0 Then
                    ExibeMensagemPopUp("Validação", "Informe o Nome Fantasia.")
                    Return False
                End If

                Select Case ddlCategoria.SelectedValue
                    Case 1                        
                        If txtCNPJ.Text.Length = 0 Then
                            ExibeMensagemPopUp("Validação", "Informe o CNPJ.")
                            Return False
                        End If
                        If Not validacnpj() Then Return False

                    Case 2
                        If ddlIndicacao.SelectedValue = 0 Then
                            ExibeMensagemPopUp("Validação", "Informe a Indicação.")
                            Return False
                        ElseIf txtCNPJ.Text.Length = 0 Then
                            ExibeMensagemPopUp("Validação", "Informe o CNPJ.")
                            Return False
                        ElseIf ddlFornecimento.SelectedValue = 0 Then
                            ExibeMensagemPopUp("Validação", "Informe o Fornecimento.")
                            Return False
                        End If
                        If Not validacnpj() Then Return False

                    Case 3
                        If ddlIndicacao.SelectedValue = 0 Then
                            ExibeMensagemPopUp("Validação", "Informe a Indicação.")
                            Return False
                        ElseIf txtCPF.Text.Length = 0 Then
                            ExibeMensagemPopUp("Validação", "Informe o CPF.")
                            Return False
                        ElseIf ddlFornecimento.SelectedValue = 0 Then
                            ExibeMensagemPopUp("Validação", "Informe o Fornecimento.")
                            Return False
                        End If

                        If ddlFornecimento.SelectedValue = 2 Or ddlFornecimento.SelectedValue = 3 Then
                            If txtInss.Text.Length = 0 Then
                                ExibeMensagemPopUp("Validação", "Informe o INSS(NIT-PIS-PASEP).")
                                Return False
                            ElseIf txtCbo.Text.Length = 0 Then
                                ExibeMensagemPopUp("Validação", "Informe o Código CBO.")
                                Return False
                            ElseIf ddlSefip.SelectedValue = 0 Then
                                ExibeMensagemPopUp("Validação", "Informe o Cód. da Categoria do Trabalhador - SEFIP.")
                                Return False
                            End If

                            If Not validainss() Then Return False
                        End If

                        If Not validacpf() Then Return False
                    Case 4
                        If ddlIndicacao.SelectedValue = 0 Then
                            ExibeMensagemPopUp("Validação", "Informe a Indicação.")
                            Return False
                        ElseIf txtCPF.Text.Length = 0 Then
                            ExibeMensagemPopUp("Validação", "Informe o CPF.")
                            Return False
                        ElseIf ddlFornecimento.SelectedValue = 0 Then
                            ExibeMensagemPopUp("Validação", "Informe o Fornecimento.")
                            Return False
                        ElseIf txtInscricaoRural.Text.Length = 0 Then
                            ExibeMensagemPopUp("Validação", "Informe o N° de Inscrição (CEI/INSS).")
                            Return False
                        End If
                        If Not validacpf() Then Return False
                    Case 5
                        If ddlIndicacao.SelectedValue = 0 Then
                            ExibeMensagemPopUp("Validação", "Informe a Indicação.")
                            Return False
                        ElseIf ddlFornecimento.SelectedValue = 0 Then
                            ExibeMensagemPopUp("Validação", "Informe o Fornecimento.")
                            Return False
                        End If
                    Case 6
                        If ddlIndicacao.SelectedValue = 0 Then
                            ExibeMensagemPopUp("Validação", "Informe a Indicação.")
                            Return False
                        ElseIf txtCNPJ.Text.Length = 0 Then
                            ExibeMensagemPopUp("Validação", "Informe o CNPJ.")
                            Return False
                        ElseIf ddlFornecimento.SelectedValue = 0 Then
                            ExibeMensagemPopUp("Validação", "Informe o Fornecimento.")
                            Return False
                        End If
                        If Not validacnpj() Then Return False
                    Case 7
                        If txtCPF.Text.Length = 0 Then
                            ExibeMensagemPopUp("Validação", "Informe o CPF.")
                            Return False
                        End If
                        If Not validacpf() Then Return False
                    Case 8
                        If txtCPF.Text.Length = 0 Then
                            ExibeMensagemPopUp("Validação", "Informe o CPF.")
                            Return False
                        End If
                        If Not validacpf() Then Return False
                End Select

                Select Case ddlFornecimento.SelectedValue
                    Case 1
                        If ddlTipoMaterial.SelectedValue = 0 Then
                            ExibeMensagemPopUp("Validação", "Informe o Tipo de Material.")
                            Return False
                        End If
                    Case 2
                        If ddlServico.SelectedValue = 0 Then
                            ExibeMensagemPopUp("Validação", "Informe o Tipo de Serviço.")
                            Return False
                        End If
                    Case 3
                        If ddlTipoMaterial.SelectedValue = 0 Then
                            ExibeMensagemPopUp("Validação", "Informe o Tipo de Material.")
                            Return False
                        ElseIf ddlServico.SelectedValue = 0 Then
                            ExibeMensagemPopUp("Validação", "Informe o Tipo de Serviço.")
                            Return False
                        End If
                    Case 4
                        If txtMotivo.Text.Length = 0 Then
                            ExibeMensagemPopUp("Validação", "Informe o Motivo.")
                            Return False
                        End If
                End Select

                If ddlCategoria.SelectedValue <> 3 And ddlCategoria.SelectedValue <> 4 And ddlCategoria.SelectedValue <> 5 Then
                    Select Case ddlFornecimento.SelectedValue
                        Case 1
                            If txtInscEstadual.Text.Length = 0 Then
                                ExibeMensagemPopUp("Validação", "Informe a Inscrição Estadual.")
                                Return False
                            End If
                        Case 2
                            If txtInscMunicipal.Text.Length = 0 Then
                                ExibeMensagemPopUp("Validação", "Informe a Inscrição Municipal.")
                                Return False
                            End If
                        Case 3
                            If txtInscEstadual.Text.Length = 0 Then
                                ExibeMensagemPopUp("Validação", "Informe a Inscrição Estadual.")
                                Return False
                            ElseIf txtInscMunicipal.Text.Length = 0 Then
                                ExibeMensagemPopUp("Validação", "Informe a Inscrição Municipal.")
                                Return False
                            End If
                    End Select
                End If

                If txtEndereco.Text.Length = 0 Then
                    ExibeMensagemPopUp("Validação", "Informe o Endereço.")
                    Return False
                ElseIf txtNumero.Text.Length = 0 Then
                    ExibeMensagemPopUp("Validação", "Informe o Numero.")
                    Return False
                ElseIf txtBairro.Text.Length = 0 Then
                    ExibeMensagemPopUp("Validação", "Informe o Bairro.")
                    Return False
                ElseIf txtCep.Text.Length = 0 Then
                    ExibeMensagemPopUp("Validação", "Informe o CEP.")
                    Return False
                ElseIf txtCidade.Text.Length = 0 Then
                    ExibeMensagemPopUp("Validação", "Informe a Cidade.")
                    Return False
                ElseIf ddlEstado.SelectedValue = "-" Then
                    ExibeMensagemPopUp("Validação", "Informe o Estado.")
                    Return False
                ElseIf ddlSiglaPais.SelectedValue = "-" Then
                    ExibeMensagemPopUp("Validação", "Informe o País.")
                    Return False
                ElseIf txtNomeContato.Text.Length = 0 Then
                    ExibeMensagemPopUp("Validação", "Informe o Nome de Contato.")
                    Return False
                ElseIf txtSobrenomeContato.Text.Length = 0 Then
                    ExibeMensagemPopUp("Validação", "Informe o Sobrenome.")
                    Return False
                ElseIf txtFuncaoContato.Text.Length = 0 Then
                    If ddlCategoria.SelectedValue < 7 Then
                        ExibeMensagemPopUp("Validação", "Informe a Função.")
                        Return False
                    End If
                ElseIf txtDepartamentoContato.Text.Length = 0 Then
                    If ddlCategoria.SelectedValue < 7 Then
                        ExibeMensagemPopUp("Validação", "Informe o Departamento.")
                        Return False
                    End If
                ElseIf txtTelefoneContato.Text.Length = 0 Then
                    ExibeMensagemPopUp("Validação", "Informe o Telefone de Contato.")
                    Return False
                ElseIf txtEmailContato.Text.Length = 0 Then
                    ExibeMensagemPopUp("Validação", "Informe o Email.")
                    Return False
                End If

                If txtEmailContato.Text.Length > 0 Then
                    If Not Common.Functions.ValidarEmail(txtEmailContato.Text) Then
                        ExibeMensagemPopUp("Validação", "Email inválido.")
                        Return False
                    End If
                End If

                If ddlCategoria.SelectedValue <> 5 Then
                    validacep()
                End If

            Case Else
                If ddlCategoria.SelectedValue = 0 Then
                    ExibeMensagemPopUp("Validação", "Informe a Categoria.")
                    Return False
                ElseIf txtCodSap.Text.Length = 0 Then
                    ExibeMensagemPopUp("Validação", "Informe o Código SAP.")
                    Return False
                ElseIf txtMotivo.Text.Length = 0 Then
                    ExibeMensagemPopUp("Validação", "Informe o Motivo.")
                    Return False
                ElseIf txtRazaoSocial.Text.Length = 0 Then
                    ExibeMensagemPopUp("Validação", "Informe a Razão Social.")
                    Return False
                End If

        End Select

        If txtNomeSolicitante.Text.Length = 0 Then
            ExibeMensagemPopUp("Validação", "Informe o Nome do Solicitante.")
            Return False
        ElseIf txtArea.Text.Length = 0 Then
            ExibeMensagemPopUp("Validação", "Informe a Área do Solicitante.")
            Return False
        ElseIf ddlCentro.SelectedValue = 0 Then
            ExibeMensagemPopUp("Validação", "Informe o Centro do Solicitante.")
            Return False
        ElseIf txtTelefoneSolicitante.Text.Length = 0 Then
            ExibeMensagemPopUp("Validação", "Informe o Telefone do Solicitante.")
            Return False
        End If

        Return True

    End Function

    Private Sub LimpaObrigatorios() 
        lblEmpresa.text = "Empresa:"
        lblCategoria.text = "Categoria Fornecedor:"
        lblIndicacao.text = "Indicação:"
        lblCodSap.text = "Código SAP:"
        lblFornecimento.text = "Fornecimento:"
        lblMotivo.text = "Motivo:"
        lblTipoMaterial.text = "Tipo de Material:"
        lblServico.text = "Tipo de Serviço:"
        lblRazaoSocial.text = "Razão Social:"
        lblNomeFantasia.text = "Nome Fantasia:"
        lblCep.text = "CEP:"
        lblEndereco.text = "Endereço:"
        lblNumero.text = "No.:"
        lblBairro.text = "Bairro:"
        lblCidade.text = "Cidade:"
        lblEstado.Text = "Estado:"        
        lblPais.text = "País:"
        lblNome.text = "Nome:"
        lblSobrenome.text = "Sobrenome:"
        lblFuncao.text = "Função:"
        lblDepartamento.text = "Departamento:"
        lblTelefone.text = "Telefone:"
        lblEmail.text = "Email:"
        lblInss.text = "INSS(NIT-PIS-PASEP):"
        lblCbo.text = "Código CBO:"
        lblSefip.text = "Cod. Categoria Trabalhador-SEFIP:"
        lblOptante.text = "Optante Simples:"
        lblNumIdFisc.text = "N° Id Fiscal:"
        lblInscricaoRural.text = "Nº de Inscrição (CEI / INSS):"
        lblCPFCNPJ.text = "CPF:"
        lblInscEstadual.text = "Insc. Estadual:"
        lblInscMunicipal.text = "Insc. Municipal:"
        lblNomeSolicitante.text = "Nome Solicitante:"
        lblTelefoneSolicitante.text = "Telefone:"
        lblCentro.text = "Centro:"
        lblArea.text = "Área:"
    End Sub

    Private Sub SetaObrigatorios()

        Select Case ddlOperacao.SelectedValue
            Case 1
                lblEmpresa.Text = "Empresa*:"
                lblCategoria.Text = "Categoria Fornecedor*:"
                lblRazaoSocial.Text = "Razão Social*:"
                lblNomeFantasia.Text = "Nome Fantasia*:"

                Select Case ddlCategoria.SelectedValue
                    Case 1
                        lblCPFCNPJ.Text = "CNPJ*:"

                    Case 2
                        lblIndicacao.Text = "Indicação*:"
                        lblCPFCNPJ.Text = "CNPJ*:"
                        lblFornecimento.Text = "Fornecimento*:"

                    Case 3
                        lblIndicacao.Text = "Indicação*:"
                        lblCPFCNPJ.Text = "CPF*:"
                        lblFornecimento.Text = "Fornecimento*:"

                        If ddlFornecimento.SelectedValue = 2 Or ddlFornecimento.SelectedValue = 3 Then
                            lblInss.Text = "INSS(NIT-PIS-PASEP)*:"
                            lblCbo.Text = "Código CBO*:"
                            lblSefip.Text = "Cod. Categoria Trabalhador-SEFIP*:"
                        End If
                    Case 4
                        lblIndicacao.Text = "Indicação*:"
                        lblCPFCNPJ.Text = "CPF*:"
                        lblFornecimento.Text = "Fornecimento*:"
                        lblInscricaoRural.Text = "Nº de Inscrição (CEI / INSS)*:"
                    Case 5
                        lblIndicacao.Text = "Indicação*:"
                        lblFornecimento.Text = "Fornecimento*:"
                    Case 6
                        lblIndicacao.Text = "Indicação*:"
                        lblCPFCNPJ.Text = "CNPJ*:"
                        lblFornecimento.Text = "Fornecimento*:"
                    Case 7
                        lblCPFCNPJ.Text = "CPF*:"
                    Case 8
                        lblCPFCNPJ.Text = "CPF*:"
                End Select

                Select Case ddlFornecimento.SelectedValue
                    Case 1
                        lblTipoMaterial.Text = "Tipo de Material*:"
                    Case 2
                        lblServico.Text = "Tipo de Serviço*:"
                    Case 3
                        lblTipoMaterial.Text = "Tipo de Material*:"
                        lblServico.Text = "Tipo de Serviço*:"
                    Case 4
                        lblMotivo.Text = "Motivo*:"
                End Select

                If ddlCategoria.SelectedValue <> 3 And ddlCategoria.SelectedValue <> 4 And ddlCategoria.SelectedValue <> 5 Then
                    Select Case ddlFornecimento.SelectedValue
                        Case 1
                            lblInscEstadual.Text = "Insc. Estadual*:"
                        Case 2
                            lblInscMunicipal.Text = "Insc. Municipal*:"
                        Case 3
                            lblInscEstadual.Text = "Insc. Estadual*:"
                            lblInscMunicipal.Text = "Insc. Municipal*:"
                    End Select
                End If

                lblEndereco.Text = "Endereço*:"
                lblNumero.Text = "No.*:"
                lblBairro.Text = "Bairro*:"
                lblCep.Text = "CEP*:"
                lblCidade.Text = "Cidade*:"
                lblEstado.Text = "Estado*:"
                lblPais.Text = "País*:"
                lblNome.Text = "Nome*:"
                lblSobrenome.Text = "Sobrenome*:"
                lblFuncao.Text = "Função*:"
                lblDepartamento.Text = "Departamento*:"
                lblTelefone.Text = "Telefone*:"
                lblEmail.Text = "Email*:"

            Case Else
                lblCategoria.Text = "Categoria Fornecedor*:"
                lblCodSap.Text = "Código SAP*:"
                lblMotivo.Text = "Motivo*:"
                lblRazaoSocial.Text = "Razão Social*:"

        End Select

        lblNomeSolicitante.Text = "Nome Solicitante*:"
        lblTelefoneSolicitante.Text = "Telefone*:"
        lblCentro.Text = "Centro*:"
        lblArea.Text = "Área*:"

    End Sub

    Private Sub ExibeMensagemPopUp(sTitulo As String, sMensagem As String)
        Dim sFinalizar As String
        sFinalizar = "Finalizar"
        sMensagem = sMensagem.Replace(vbCrLf, "<BR>")
        sMensagem = sMensagem.Replace(Chr(13), "<BR>")
        sMensagem = sMensagem.Replace("'", "")
        sMensagem = sMensagem.Replace(";", "-")

        Dim sJavaScript As String = "javascript:exibeMessagepopUp('" + sTitulo + "','" + sMensagem + "');"
        Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyScript", sJavaScript, True)
    End Sub

    Private Sub ExibeMensagemPopUp(sTitulo As String, sMensagem As String, sNomeAcao As String, sAcao As String)
        sMensagem = sMensagem.Replace(Chr(13), "<BR>")
        Dim sJavaScript As String = "javascript:exibeMessagepopUp('" + sTitulo + "','" + sMensagem + "','" + sNomeAcao + "','" + sAcao + "');"
        Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyScript", sJavaScript, True)
    End Sub

    Protected Sub ddlOperacao_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlOperacao.SelectedIndexChanged
        LimpaObrigatorios()
        SetaObrigatorios()

        MostraDadosContato(False)

        Select Case ddlOperacao.SelectedValue
            Case 1
                lblEmpresa.Visible = True
                ddlEmpresa.Visible = True
                lblCategoria.Visible = True
                ddlCategoria.Visible = True
                ddlCategoria.SelectedValue = 0

                lblCodSap.Visible = False
                txtCodSap.Visible = False
                lblRazaoSocial.Visible = False
                txtRazaoSocial.Visible = False
                lblMotivo.Visible = False
                txtMotivo.Visible = False

            Case 2
                lblCodSap.Visible = True
                txtCodSap.Visible = True
                lblRazaoSocial.Visible = True
                txtRazaoSocial.Visible = True

                lblEmpresa.Visible = False
                ddlEmpresa.Visible = False
                lblCategoria.Visible = True
                ddlCategoria.Visible = True
                ddlCategoria.SelectedValue = 0
                lblIndicacao.Visible = False
                ddlIndicacao.Visible = False

                lblFornecimento.Visible = False
                ddlFornecimento.Visible = False
                lblTipoMaterial.Visible = False
                ddlTipoMaterial.Visible = False
                lblServico.Visible = False
                ddlServico.Visible = False
                lblMotivo.Visible = True
                txtMotivo.Visible = True


            Case Else
                lblMotivo.Visible = True
                txtMotivo.Visible = True
                lblCodSap.Visible = True
                txtCodSap.Visible = True
                lblRazaoSocial.Visible = True
                txtRazaoSocial.Visible = True

                lblEmpresa.Visible = False
                ddlEmpresa.Visible = False
                lblCategoria.Visible = True
                ddlCategoria.Visible = True
                ddlCategoria.SelectedValue = 0
                lblIndicacao.Visible = False
                ddlIndicacao.Visible = False

                lblFornecimento.Visible = False
                ddlFornecimento.Visible = False
                lblTipoMaterial.Visible = False
                ddlTipoMaterial.Visible = False
                lblServico.Visible = False
                ddlServico.Visible = False
        End Select

    End Sub

    Protected Sub ddlCategoria_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlCategoria.SelectedIndexChanged

        LimpaObrigatorios()
        SetaObrigatorios()

        If ddlOperacao.SelectedValue > 2 Then
            Exit Sub
        End If

        ddlFornecimento.SelectedValue = 0
        ddlFornecimento_SelectedIndexChanged(New Object, New EventArgs)

        Select Case ddlCategoria.SelectedValue
            Case 1
                lblIndicacao.Visible = False
                ddlIndicacao.Visible = False
                lblRazaoSocial.Visible = True
                txtRazaoSocial.Visible = True
                lblNomeFantasia.Visible = True
                txtNomeFantasia.Visible = True
                lblNumIdFisc.Visible = False
                txtNumIdFisc.Visible = False
                lblCPFCNPJ.Visible = True
                'lblCPFCNPJ.Text = "CNPJ:"
                txtCNPJ.Visible = True
                txtCPF.Visible = False
                lblFornecimento.Visible = False
                ddlFornecimento.Visible = False
                lblOptante.Visible = False
                rdbOptante.Visible = False
                lblInscricaoRural.Visible = False
                txtInscricaoRural.Visible = False

                If ddlEstado.Items.Item(0).ToString.Trim.Contains(("EX").ToString.Trim) Then
                    ddlEstado.Items.RemoveAt(0)
                End If
                ddlEstado.Enabled = True

            Case 2
                lblIndicacao.Visible = True
                ddlIndicacao.Visible = True
                lblRazaoSocial.Visible = True
                txtRazaoSocial.Visible = True
                lblNomeFantasia.Visible = True
                txtNomeFantasia.Visible = True
                lblNumIdFisc.Visible = False
                txtNumIdFisc.Visible = False
                lblCPFCNPJ.Visible = True
                'lblCPFCNPJ.Text = "CNPJ:"
                txtCNPJ.Visible = True
                txtCPF.Visible = False
                If ddlOperacao.SelectedValue = 1 Then
                    lblFornecimento.Visible = True
                    ddlFornecimento.Visible = True
                ElseIf ddlOperacao.SelectedValue = 2 Then
                    lblFornecimento.Visible = False
                    ddlFornecimento.Visible = False
                    lblInscEstadual.Visible = True
                    txtInscEstadual.Visible = True
                    lblInscMunicipal.Visible = True
                    txtInscMunicipal.Visible = True
                End If
                lblOptante.Visible = True
                rdbOptante.Visible = True
                lblInscricaoRural.Visible = False
                txtInscricaoRural.Visible = False

                If ddlEstado.Items.Item(0).ToString.Trim.Contains(("EX").ToString.Trim) Then
                    ddlEstado.Items.RemoveAt(0)
                End If
                ddlEstado.Enabled = True

            Case 3
                lblIndicacao.Visible = True
                ddlIndicacao.Visible = True
                lblRazaoSocial.Visible = True
                txtRazaoSocial.Visible = True
                lblNomeFantasia.Visible = True
                txtNomeFantasia.Visible = True
                lblNumIdFisc.Visible = False
                txtNumIdFisc.Visible = False
                lblCPFCNPJ.Visible = True
                'lblCPFCNPJ.Text = "CPF:"
                txtCPF.Visible = True
                txtCNPJ.Visible = False
                If ddlOperacao.SelectedValue = 1 Then
                    lblFornecimento.Visible = True
                    ddlFornecimento.Visible = True
                ElseIf ddlOperacao.SelectedValue = 2 Then
                    lblFornecimento.Visible = False
                    ddlFornecimento.Visible = False
                    lblInscEstadual.Visible = True
                    txtInscEstadual.Visible = True
                    lblInscMunicipal.Visible = True
                    txtInscMunicipal.Visible = True
                    lblInss.Visible = True
                    txtInss.Visible = True
                    lblCbo.Visible = True
                    txtCbo.Visible = True
                    lblSefip.Visible = True
                    ddlSefip.Visible = True
                End If
                lblOptante.Visible = False
                rdbOptante.Visible = False
                lblInscricaoRural.Visible = False
                txtInscricaoRural.Visible = False

                If ddlEstado.Items.Item(0).ToString.Trim.Contains(("EX").ToString.Trim) Then
                    ddlEstado.Items.RemoveAt(0)
                End If
                ddlEstado.Enabled = True

            Case 4
                lblIndicacao.Visible = True
                ddlIndicacao.Visible = True
                lblRazaoSocial.Visible = True
                txtRazaoSocial.Visible = True
                lblNomeFantasia.Visible = True
                txtNomeFantasia.Visible = True
                lblNumIdFisc.Visible = False
                txtNumIdFisc.Visible = False
                lblCPFCNPJ.Visible = True
                'lblCPFCNPJ.Text = "CPF:"
                txtCPF.Visible = True
                txtCNPJ.Visible = False
                If ddlOperacao.SelectedValue = 1 Then
                    lblFornecimento.Visible = True
                    ddlFornecimento.Visible = True
                ElseIf ddlOperacao.SelectedValue = 2 Then
                    lblFornecimento.Visible = False
                    ddlFornecimento.Visible = False
                    lblInscEstadual.Visible = True
                    txtInscEstadual.Visible = True
                    lblInscMunicipal.Visible = True
                    txtInscMunicipal.Visible = True
                End If
                lblOptante.Visible = False
                rdbOptante.Visible = False
                lblInscricaoRural.Visible = True
                txtInscricaoRural.Visible = True

                If ddlEstado.Items.Item(0).ToString.Trim.Contains(("EX").ToString.Trim) Then
                    ddlEstado.Items.RemoveAt(0)
                End If
                ddlEstado.Enabled = True

            Case 5
                lblIndicacao.Visible = True
                ddlIndicacao.Visible = True
                lblRazaoSocial.Visible = True
                txtRazaoSocial.Visible = True
                lblNomeFantasia.Visible = True
                txtNomeFantasia.Visible = True
                lblNumIdFisc.Visible = True
                txtNumIdFisc.Visible = True
                lblCPFCNPJ.Visible = False
                txtCPF.Visible = False
                txtCNPJ.Visible = False
                If ddlOperacao.SelectedValue = 1 Then
                    lblFornecimento.Visible = True
                    ddlFornecimento.Visible = True
                ElseIf ddlOperacao.SelectedValue = 2 Then
                    lblFornecimento.Visible = False
                    ddlFornecimento.Visible = False
                End If
                lblOptante.Visible = False
                rdbOptante.Visible = False
                lblInscricaoRural.Visible = False
                txtInscricaoRural.Visible = False
                ddlEstado.Items.Insert(0, "EX")
                ddlEstado.SelectedIndex = 0
                ddlEstado.Enabled = False
                txtCep.Text = ""
                txtCep.Attributes.Remove("onkeyup")
            Case 6
                lblRazaoSocial.Visible = True
                txtRazaoSocial.Visible = True
                lblNomeFantasia.Visible = True
                txtNomeFantasia.Visible = True
                lblNumIdFisc.Visible = False
                txtNumIdFisc.Visible = False
                lblCPFCNPJ.Visible = True
                'lblCPFCNPJ.Text = "CNPJ:"
                txtCNPJ.Visible = True
                txtCPF.Visible = False
                If ddlOperacao.SelectedValue = 1 Then
                    lblFornecimento.Visible = True
                    ddlFornecimento.Visible = True
                ElseIf ddlOperacao.SelectedValue = 2 Then
                    lblFornecimento.Visible = False
                    ddlFornecimento.Visible = False
                    lblInscEstadual.Visible = True
                    txtInscEstadual.Visible = True
                    lblInscMunicipal.Visible = True
                    txtInscMunicipal.Visible = True
                End If
                lblOptante.Visible = True
                rdbOptante.Visible = True
                lblInscricaoRural.Visible = False
                txtInscricaoRural.Visible = False

                If ddlEstado.Items.Item(0).ToString.Trim.Contains(("EX").ToString.Trim) Then
                    ddlEstado.Items.RemoveAt(0)
                End If
                ddlEstado.Enabled = True

            Case 7
                lblIndicacao.Visible = False
                ddlIndicacao.Visible = False
                lblRazaoSocial.Visible = True
                txtRazaoSocial.Visible = True
                lblNomeFantasia.Visible = True
                txtNomeFantasia.Visible = True
                lblNumIdFisc.Visible = False
                txtNumIdFisc.Visible = False
                lblCPFCNPJ.Visible = True
                'lblCPFCNPJ.Text = "CPF:"
                txtCPF.Visible = True
                txtCNPJ.Visible = False
                lblFornecimento.Visible = False
                ddlFornecimento.Visible = False
                lblOptante.Visible = False
                rdbOptante.Visible = False
                lblInscricaoRural.Visible = False
                txtInscricaoRural.Visible = False

                If ddlEstado.Items.Item(0).ToString.Trim.Contains(("EX").ToString.Trim) Then
                    ddlEstado.Items.RemoveAt(0)
                End If
                ddlEstado.Enabled = True

            Case 8
                lblIndicacao.Visible = False
                ddlIndicacao.Visible = False
                lblRazaoSocial.Visible = True
                txtRazaoSocial.Visible = True
                lblNomeFantasia.Visible = True
                txtNomeFantasia.Visible = True
                lblNumIdFisc.Visible = False
                txtNumIdFisc.Visible = False
                lblCPFCNPJ.Visible = True
                'lblCPFCNPJ.Text = "CPF:"
                txtCPF.Visible = True
                txtCNPJ.Visible = False
                lblFornecimento.Visible = False
                ddlFornecimento.Visible = False
                lblOptante.Visible = False
                rdbOptante.Visible = False
                lblInscricaoRural.Visible = False
                txtInscricaoRural.Visible = False

                If ddlEstado.Items.Item(0).ToString.Trim.Contains(("EX").ToString.Trim) Then
                    ddlEstado.Items.RemoveAt(0)
                End If
                ddlEstado.Enabled = True

        End Select

        If ddlOperacao.SelectedValue = 2 Then
            txtCPF.Visible = False
            txtCNPJ.Visible = False
            lblCPFCNPJ.Visible = False
        End If

        MostraDadosContato(ddlCategoria.SelectedValue)

    End Sub

    Private Sub MostraDadosContato(mostrar As Boolean)
        lblEndereco.Visible = mostrar
        txtEndereco.Visible = mostrar
        lblNumero.Visible = mostrar
        txtNumero.Visible = mostrar
        lblComplemento.Visible = mostrar
        txtComplemento.Visible = mostrar
        lblEndereco.Visible = mostrar
        txtEndereco.Visible = mostrar
        lblBairro.Visible = mostrar
        txtBairro.Visible = mostrar
        lblCep.Visible = mostrar
        txtCep.Visible = mostrar
        lblCaixaPostal.Visible = mostrar
        txtCaixaPostal.Visible = mostrar
        lblCidade.Visible = mostrar
        txtCidade.Visible = mostrar
        lblEstado.Visible = mostrar
        ddlEstado.Visible = mostrar
        lblPais.Visible = mostrar
        ddlSiglaPais.Visible = mostrar
        lblNome.Visible = mostrar
        txtNomeContato.Visible = mostrar
        lblSobrenome.Visible = mostrar
        txtSobrenomeContato.Visible = mostrar
        lblFuncao.Visible = mostrar
        txtFuncaoContato.Visible = mostrar
        lblDepartamento.Visible = mostrar
        txtDepartamentoContato.Visible = mostrar
        lblTelefone.Visible = mostrar
        txtTelefoneContato.Visible = mostrar
        lblFax.Visible = mostrar
        txtFaxContato.Visible = mostrar
        lblCelular.Visible = mostrar
        txtCelularContato.Visible = mostrar
        lblEmail.Visible = mostrar
        txtEmailContato.Visible = mostrar
    End Sub

    Protected Sub ddlFornecimento_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlFornecimento.SelectedIndexChanged
        LimpaObrigatorios()
        SetaObrigatorios()

        If ddlFornecimento.SelectedValue = 0 Then
            'lblMotivo.Visible = False
            'txtMotivo.Visible = False
            lblTipoMaterial.Visible = False
            ddlTipoMaterial.Visible = False
            lblServico.Visible = False
            ddlServico.Visible = False
            lblInscEstadual.Visible = False
            txtInscEstadual.Visible = False
            lblInscMunicipal.Visible = False
            txtInscMunicipal.Visible = False
            lblInss.Visible = False
            txtInss.Visible = False
            lblCbo.Visible = False
            txtCbo.Visible = False
            lblSefip.Visible = False
            ddlSefip.Visible = False
        End If

        If ddlFornecimento.SelectedValue = 1 Then
            lblMotivo.Visible = False
            txtMotivo.Visible = False
            lblTipoMaterial.Visible = True
            ddlTipoMaterial.Visible = True
            lblServico.Visible = False
            ddlServico.Visible = False
            If ddlCategoria.SelectedValue <> 5 Then
                lblInscEstadual.Visible = True
                txtInscEstadual.Visible = True
                lblInscMunicipal.Visible = False
                txtInscMunicipal.Visible = False
            End If
            If ddlCategoria.SelectedValue = 3 Then
                lblInss.Visible = False
                txtInss.Visible = False
                lblCbo.Visible = False
                txtCbo.Visible = False
                lblSefip.Visible = False
                ddlSefip.Visible = False
            End If
        End If

        If ddlFornecimento.SelectedValue = 2 Then
            lblMotivo.Visible = False
            txtMotivo.Visible = False
            lblServico.Visible = True
            ddlServico.Visible = True
            lblTipoMaterial.Visible = False
            ddlTipoMaterial.Visible = False
            If ddlCategoria.SelectedValue <> 5 Then
                lblInscEstadual.Visible = False
                txtInscEstadual.Visible = False
                lblInscMunicipal.Visible = True
                txtInscMunicipal.Visible = True
            End If
            If ddlCategoria.SelectedValue = 3 Then
                lblInss.Visible = True
                txtInss.Visible = True
                lblCbo.Visible = True
                txtCbo.Visible = True
                lblSefip.Visible = True
                ddlSefip.Visible = True
            End If
        End If

        If ddlFornecimento.SelectedValue = 3 Then
            lblMotivo.Visible = False
            txtMotivo.Visible = False
            lblTipoMaterial.Visible = True
            ddlTipoMaterial.Visible = True
            lblServico.Visible = True
            ddlServico.Visible = True
            If ddlCategoria.SelectedValue <> 5 Then
                lblInscEstadual.Visible = True
                txtInscEstadual.Visible = True
                lblInscMunicipal.Visible = True
                txtInscMunicipal.Visible = True
            End If
            If ddlCategoria.SelectedValue = 3 Then
                lblInss.Visible = True
                txtInss.Visible = True
                lblCbo.Visible = True
                txtCbo.Visible = True
                lblSefip.Visible = True
                ddlSefip.Visible = True
            End If
        End If

        If ddlFornecimento.SelectedValue = 4 Then
            lblMotivo.Visible = True
            txtMotivo.Visible = True
            lblTipoMaterial.Visible = False
            ddlTipoMaterial.Visible = False
            lblServico.Visible = False
            ddlServico.Visible = False
            lblInscEstadual.Visible = False
            txtInscEstadual.Visible = False
            lblInscMunicipal.Visible = False
            txtInscMunicipal.Visible = False
            lblInss.Visible = False
            txtInss.Visible = False
            lblCbo.Visible = False
            txtCbo.Visible = False
            lblSefip.Visible = False
            ddlSefip.Visible = False
        End If


    End Sub

    Private Sub CarregaCentros()
        Dim objCentro As New BLL.bllSolicitacaoCadastro
        With ddlCentro
            .DataSource = objCentro.getAllCentros
            .DataTextField = "dc_centro"
            .DataValueField = "cd_centro"
            .DataBind()
        End With
        ddlCentro.Items.Insert(0, New ListItem("Selecione...", "0"))
    End Sub

    Private Sub CarregaTipoMaterial()
        Dim objTipoMaterial As New BLL.bllSolicitacaoCadastro
        With ddlTipoMaterial
            .DataSource = objTipoMaterial.getAllTipoMaterial
            .DataTextField = "dc_material"
            .DataValueField = "cd_material"
            .DataBind()
        End With
        ddlTipoMaterial.Items.Insert(0, New ListItem("Selecione...", "0"))
    End Sub

    Private Sub CarregaTipoServico()
        Dim objTipoServico As New BLL.bllSolicitacaoCadastro
        With ddlServico
            .DataSource = objTipoServico.getAllTipoServico
            .DataTextField = "dc_servico"
            .DataValueField = "cd_servico"
            .DataBind()
        End With
        ddlServico.Items.Insert(0, New ListItem("Selecione...", "0"))
    End Sub

    Private Sub CarregaPais()
        Dim objPais As New BLL.bllSolicitacaoCadastro
        With ddlSiglaPais
            .DataSource = objPais.getAllPais
            .DataTextField = "dc_pais"
            .DataValueField = "cd_pais"
            .DataBind()
        End With
        ddlSiglaPais.SelectedValue = "BR"
    End Sub

    Private Sub CarregaCondPgmto()
        Dim objCondPgmto As New BLL.bllSolicitacaoCadastro
        With ddlCondPgmto
            .DataSource = objCondPgmto.getAllCondPgmto
            .DataTextField = "Texto"
            .DataValueField = "cd_condicao_pagamento"
            .DataBind()
        End With
        ddlCondPgmto.Items.Insert(0, New ListItem("Selecione...", "0"))
    End Sub

    Private Function validacnpj() As Boolean
        Dim oValidacao As New Common.Validacao
        Try
            oValidacao.cnpj = txtCNPJ.Text
            Return True
        Catch ex As Exception
            ExibeMensagemPopUp("Dados Incorretos", "CNPJ Inválido.")
            txtCNPJ.Focus()
            Return False
        End Try
    End Function

    Private Function validacpf() As Boolean
        Dim oValidacao As New Common.Validacao
        Try
            oValidacao.cpf = txtCPF.Text
            Return True
        Catch ex As Exception
            ExibeMensagemPopUp("Dados Incorretos", "CPF Inválido.")
            txtCPF.Focus()
            Return False
        End Try
    End Function

    Private Sub validacep()
        Dim oValidacao As New Common.Validacao
        Try
            oValidacao.cep = txtCep.Text
            txtCep.Focus()
        Catch ex As Exception
            ExibeMensagemPopUp("Dados Incorretos", "CEP Inválido.")
            txtCep.Text = ""
            Exit Sub
        End Try
    End Sub

    Private Function validainss() As Boolean
        Dim oValidacao As New Common.Validacao
        Try
            oValidacao.inss = txtInss.Text
            Return True
        Catch ex As Exception
            ExibeMensagemPopUp("Dados Incorretos", "INSS Inválido.")
            Return false
        End Try
    End Function

    Sub BuscaCep()
        Dim objCEP As New BLL.bllSolicitacaoCadastro
        Dim oDataTable As New Data.DataTable

        'lblErro.Visible = False

        Try
            oDataTable = objCEP.getCEPByText(txtCep.Text)

            If oDataTable Is Nothing Then
                'lblErro.Visible = True
                txtEndereco.Text = ""
                txtCidade.Text = ""
                txtBairro.Text = ""
                ddlEstado.SelectedValue = "-"
                Exit Sub
            Else
                txtEndereco.Text = oDataTable.Rows(0)("no_rua").ToString()
                txtCidade.Text = oDataTable.Rows(0)("dc_cidade").ToString()
                txtBairro.Text = oDataTable.Rows(0)("no_bairro").ToString()
                ddlEstado.Text = oDataTable.Rows(0)("cd_UF").ToString()
                ddlEstado.SelectedValue = oDataTable.Rows(0)("cd_UF").ToString()
            End If

        Catch
            ExibeMensagemPopUp("Dados Incorretos", "CEP Não Encontrado.")
            Exit Sub
        End Try

    End Sub

    Protected Sub txtCep_TextChanged(sender As Object, e As EventArgs) Handles txtCep.TextChanged
        If ddlEstado.Items.Item(0).ToString.Trim.Contains(("EX").ToString.Trim) Then
            txtEndereco.Text = ""
            txtCidade.Text = ""
            txtBairro.Text = ""
            Exit Sub
        Else
            BuscaCep()
        End If
    End Sub

    'Protected Sub txtCPF_TextChanged(sender As Object, e As EventArgs) Handles txtCPF.TextChanged
    '    validacpf()
    'End Sub

    'Protected Sub txtCNPJ_TextChanged(sender As Object, e As EventArgs) Handles txtCNPJ.TextChanged
    '    validacnpj()
    'End Sub
End Class