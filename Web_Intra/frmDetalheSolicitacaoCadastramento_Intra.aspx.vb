Public Class frmDetalheSolicitacaoCadastramento_Intra
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim sPageName As String = Request.FilePath.Substring(1, Request.FilePath.Length - 6)
        If Common.Configuracao.getManutencao() Then
            Response.Redirect("Manutencao.aspx")
        End If

        If Not IsPostBack Then

            'Verifica autorização de acesso a página
            If Session("objCAT") Is Nothing Then
                Response.Redirect("Login.aspx")
            Else
                Dim objSchCAT = Session("objCAT")
                Dim objCAT As New BLL.bllCAT

                If Not objCAT.ValidaPermissao(objSchCAT, sPageName, "A") Then
                    Response.Redirect("frmAcessoNegado.aspx")
                End If
            End If

            If Not Session("objSolicitacao") Is Nothing Then
                Dim objSolicitacao As ShL.schSolicitacaoCadastro = Session("objSolicitacao")                
                CarregaTela(objSolicitacao)
            Else
                Response.Redirect("frmSolicitacoesCadastro.aspx")
            End If

        End If

        btOK.Attributes.Add("onclick", (Me.ClientScript.GetPostBackEventReference(btOK, "") + ";this.value='Aguarde...';this.disabled = true;"))

    End Sub

    Private Sub montaTela(objSolicitacao As ShL.schSolicitacaoCadastro)

        txtOperacao.Visible = True
        lblCategoria.Visible = True
        txtCategoria.Visible = True

        Select Case objSolicitacao.objDadosBasicos.no_operacao
            Case 1
                lblEmpresa.Visible = True
                txtEmpresa.Visible = True

                MostraDadosContato(True)
            Case 2
                lblCodSap.Visible = True
                txtCodSap.Visible = True
                lblRazaoSocial.Visible = True
                txtRazaoSocial.Visible = True
                lblMotivo.Visible = True
                txtMotivo.Visible = True

                MostraDadosContato(True)
            Case Else
                lblMotivo.Visible = True
                txtMotivo.Visible = True
                lblCodSap.Visible = True
                txtCodSap.Visible = True
                lblRazaoSocial.Visible = True
                txtRazaoSocial.Visible = True

                Exit Sub
        End Select

        Select Case objSolicitacao.objDadosBasicos.no_categoria
            Case Trim("GOVERNO")
                lblRazaoSocial.Visible = True
                txtRazaoSocial.Visible = True
                lblNomeFantasia.Visible = True
                txtNomeFantasia.Visible = True
                lblCPFCNPJ.Visible = True
                lblCPFCNPJ.Text = "CNPJ:"
                txtCNPJ.Visible = True
            Case Trim("NACIONAL PESSOA JURIDICA")
                lblIndicacao.Visible = True
                txtIndicacao.Visible = True
                lblRazaoSocial.Visible = True
                txtRazaoSocial.Visible = True
                lblNomeFantasia.Visible = True
                txtNomeFantasia.Visible = True
                lblCPFCNPJ.Visible = True
                lblCPFCNPJ.Text = "CNPJ:"
                txtCNPJ.Visible = True
                If objSolicitacao.objDadosBasicos.no_operacao = 1 Then
                    lblFornecimento.Visible = True
                    txtFornecimento.Visible = True
                ElseIf objSolicitacao.objDadosBasicos.no_operacao = 2 Then
                    lblInscEstadual.Visible = True
                    txtInscEstadual.Visible = True
                    lblInscMunicipal.Visible = True
                    txtInscMunicipal.Visible = True
                End If
                lblOptante.Visible = True
                txtOptante.Visible = True

            Case Trim("NACIONAL PESSOA FISICA")
                lblIndicacao.Visible = True
                txtIndicacao.Visible = True
                lblRazaoSocial.Visible = True
                txtRazaoSocial.Visible = True
                lblNomeFantasia.Visible = True
                txtNomeFantasia.Visible = True
                lblCPFCNPJ.Visible = True
                lblCPFCNPJ.Text = "CPF:"
                txtCPF.Visible = True
                If objSolicitacao.objDadosBasicos.no_operacao = 1 Then
                    lblFornecimento.Visible = True
                    txtFornecimento.Visible = True
                ElseIf objSolicitacao.objDadosBasicos.no_operacao = 2 Then
                    lblInscEstadual.Visible = True
                    txtInscEstadual.Visible = True
                    lblInscMunicipal.Visible = True
                    txtInscMunicipal.Visible = True
                    lblInss.Visible = True
                    txtInss.Visible = True
                    lblCbo.Visible = True
                    txtCbo.Visible = True
                    lblSefip.Visible = True
                    txtSefip.Visible = True
                End If

            Case Trim("PRODUTOR RURAL")
                lblIndicacao.Visible = True
                txtIndicacao.Visible = True
                lblRazaoSocial.Visible = True
                txtRazaoSocial.Visible = True
                lblNomeFantasia.Visible = True
                txtNomeFantasia.Visible = True
                lblCPFCNPJ.Visible = True
                lblCPFCNPJ.Text = "CPF:"
                txtCPF.Visible = True
                If objSolicitacao.objDadosBasicos.no_operacao = 1 Then
                    lblFornecimento.Visible = True
                    txtFornecimento.Visible = True
                ElseIf objSolicitacao.objDadosBasicos.no_operacao = 2 Then
                    lblInscEstadual.Visible = True
                    txtInscEstadual.Visible = True
                    lblInscMunicipal.Visible = True
                    txtInscMunicipal.Visible = True
                End If
                lblInscricaoRural.Visible = True
                txtInscricaoRural.Visible = True

            Case Trim("INTERNACIONAL")
                lblIndicacao.Visible = True
                txtIndicacao.Visible = True
                lblRazaoSocial.Visible = True
                txtRazaoSocial.Visible = True
                lblNomeFantasia.Visible = True
                txtNomeFantasia.Visible = True
                lblNumIdFisc.Visible = True
                txtNumIdFisc.Visible = True
                If objSolicitacao.objDadosBasicos.no_operacao = 1 Then
                    lblFornecimento.Visible = True
                    txtFornecimento.Visible = True
                End If

            Case Trim("INTERCOMPANY")
                lblRazaoSocial.Visible = True
                txtRazaoSocial.Visible = True
                lblNomeFantasia.Visible = True
                txtNomeFantasia.Visible = True
                lblCPFCNPJ.Visible = True
                lblCPFCNPJ.Text = "CNPJ:"
                txtCNPJ.Visible = True
                If objSolicitacao.objDadosBasicos.no_operacao = 1 Then
                    lblFornecimento.Visible = True
                    txtFornecimento.Visible = True
                ElseIf objSolicitacao.objDadosBasicos.no_operacao = 2 Then
                    lblInscEstadual.Visible = True
                    txtInscEstadual.Visible = True
                    lblInscMunicipal.Visible = True
                    txtInscMunicipal.Visible = True
                End If
                lblOptante.Visible = True
                txtOptante.Visible = True

            Case Trim("ESPECIAIS/PROCESSO TRABALHISTA")
                lblRazaoSocial.Visible = True
                txtRazaoSocial.Visible = True
                lblNomeFantasia.Visible = True
                txtNomeFantasia.Visible = True
                lblCPFCNPJ.Visible = True
                lblCPFCNPJ.Text = "CPF:"
                txtCPF.Visible = True

            Case Trim("PENSIONISTAS - RH")
                lblRazaoSocial.Visible = True
                txtRazaoSocial.Visible = True
                lblNomeFantasia.Visible = True
                txtNomeFantasia.Visible = True
                lblCPFCNPJ.Visible = True
                lblCPFCNPJ.Text = "CPF:"
                txtCPF.Visible = True
        End Select

        If Trim(objSolicitacao.objDadosBasicos.no_fornecimento) = "Material" Then
            lblTipoMaterial.Visible = True
            txtTipoMaterial.Visible = True
            If Trim(objSolicitacao.objDadosBasicos.no_categoria) <> "INTERNACIONAL" Then
                lblInscEstadual.Visible = True
                txtInscEstadual.Visible = True
            End If
        End If

        If Trim(objSolicitacao.objDadosBasicos.no_fornecimento) = "Serviço" Then
            lblServico.Visible = True
            txtTipoServico.Visible = True
            If Trim(objSolicitacao.objDadosBasicos.no_categoria) <> "INTERNACIONAL" Then
                lblInscMunicipal.Visible = True
                txtInscMunicipal.Visible = True
            End If
            If Trim(objSolicitacao.objDadosBasicos.no_categoria) = "NACIONAL PESSOA FISICA" Then
                lblInss.Visible = True
                txtInss.Visible = True
                lblCbo.Visible = True
                txtCbo.Visible = True
                lblSefip.Visible = True
                txtSefip.Visible = True
            End If
        End If

        If Trim(objSolicitacao.objDadosBasicos.no_fornecimento) = "Material + Serviço" Then
            lblTipoMaterial.Visible = True
            txtTipoMaterial.Visible = True
            lblServico.Visible = True
            txtTipoServico.Visible = True
            If Trim(objSolicitacao.objDadosBasicos.no_categoria) <> "INTERNACIONAL" Then
                lblInscEstadual.Visible = True
                txtInscEstadual.Visible = True
                lblInscMunicipal.Visible = True
                txtInscMunicipal.Visible = True
            End If
            If Trim(objSolicitacao.objDadosBasicos.no_categoria) = "NACIONAL PESSOA FISICA" Then
                lblInss.Visible = True
                txtInss.Visible = True
                lblCbo.Visible = True
                txtCbo.Visible = True
                lblSefip.Visible = True
                txtSefip.Visible = True
            End If
        End If

        If Trim(objSolicitacao.objDadosBasicos.no_fornecimento) = "Ressarcimento" Then
            lblMotivo.Visible = True
            txtMotivo.Visible = True
        End If
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
        txtEstado.Visible = mostrar
        lblPais.Visible = mostrar
        txtSiglaPais.Visible = mostrar
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

    Private Sub CarregaTela(objSolicitacao As ShL.schSolicitacaoCadastro)

        If objSolicitacao.objStatus.cd_status <> 0 Then
            btValidar.Visible = False
            btRecusar.Visible = False
        End If

        txtDataSolicitacao.Text = objSolicitacao.dt_solicitacao.ToString("dd/MM/yyyy HH:mm:ss")
        txtStatusSolicitacao.Text = objSolicitacao.objStatus.dc_status

        txtRazaoSocial.Text = objSolicitacao.objDadosBasicos.no_razao_social
        txtNomeFantasia.Text = objSolicitacao.objDadosBasicos.no_nome_fantasia
        MostrarOperacao(objSolicitacao.objDadosBasicos.no_operacao)
        txtEmpresa.Text = objSolicitacao.objDadosBasicos.no_empresa
        txtCategoria.Text = objSolicitacao.objDadosBasicos.no_categoria
        txtIndicacao.Text = objSolicitacao.objDadosBasicos.no_indicacao
        txtFornecimento.Text = objSolicitacao.objDadosBasicos.no_fornecimento
        txtNumIdFisc.Text = objSolicitacao.objDadosBasicos.nm_id_fisc
        txtCodSap.Text = objSolicitacao.objDadosBasicos.nm_cod_sap
        txtMotivo.Text = objSolicitacao.objDadosBasicos.no_obs
        txtTipoMaterial.Text = objSolicitacao.objDadosBasicos.no_tipo_material
        txtTipoServico.Text = objSolicitacao.objDadosBasicos.no_tipo_servico
        If objSolicitacao.objDadosBasicos.nm_CPF <> "" Then txtCPF.Text = Convert.ToInt64(objSolicitacao.objDadosBasicos.nm_CPF).ToString("000\.000\.000\-00")
        If objSolicitacao.objDadosBasicos.nm_CNPJ <> "" Then txtCNPJ.Text = Convert.ToInt64(objSolicitacao.objDadosBasicos.nm_CNPJ).ToString("00\.000\.000\/0000\-00")        
        txtInscEstadual.Text = objSolicitacao.objDadosBasicos.nm_inscricao_estadual
        txtInscMunicipal.Text = objSolicitacao.objDadosBasicos.nm_inscricao_municipal
        txtEndereco.Text = objSolicitacao.objDadosBasicos.no_rua
        txtNumero.Text = objSolicitacao.objDadosBasicos.nm_numero
        txtComplemento.Text = objSolicitacao.objDadosBasicos.xx_complemento
        txtBairro.Text = objSolicitacao.objDadosBasicos.no_bairro
        txtCep.Text = objSolicitacao.objDadosBasicos.nm_CEP
        txtCaixaPostal.Text = objSolicitacao.objDadosBasicos.nm_caixa_postal
        txtCidade.Text = objSolicitacao.objDadosBasicos.no_cidade
        txtEstado.Text = objSolicitacao.objDadosBasicos.sg_estado
        txtSiglaPais.Text = objSolicitacao.objDadosBasicos.cd_pais

        txtInss.Text = objSolicitacao.objDadosAdicionais.dc_inss
        txtCbo.Text = objSolicitacao.objDadosAdicionais.cd_cbo
        txtSefip.Text = objSolicitacao.objDadosAdicionais.cd_sefip
        txtInscricaoRural.Text = objSolicitacao.objDadosAdicionais.nm_inscricao_rural        
        txtOptante.Text = objSolicitacao.objDadosAdicionais.xx_optante

        If objSolicitacao.objDadosAdicionais.cd_condicao_pagamento.ToString <> "" Then
            txtCondPgmto.Text = CarregaCondPgmto(objSolicitacao.objDadosAdicionais.cd_condicao_pagamento)
        End If

        txtNomeContato.Text = objSolicitacao.objContato.no_nome
        txtSobrenomeContato.Text = objSolicitacao.objContato.no_sobrenome
        txtFuncaoContato.Text = objSolicitacao.objContato.no_funcao
        txtDepartamentoContato.Text = objSolicitacao.objContato.no_departamento
        txtTelefoneContato.Text = objSolicitacao.objContato.nm_telefone
        txtFaxContato.Text = objSolicitacao.objContato.nm_fax
        txtCelularContato.Text = objSolicitacao.objContato.nm_celular
        txtEmailContato.Text = objSolicitacao.objContato.xx_email

        txtNomeSolicitante.Text = objSolicitacao.objContato.no_nome_solicitante
        txtTelefoneSolicitante.Text = objSolicitacao.objContato.nm_telefone_solicitante
        txtCentro.Text = objSolicitacao.objContato.no_area_solicitante
        txtArea.Text = objSolicitacao.objContato.no_area_solicitante
        txtObs.Text = objSolicitacao.objContato.no_observacao_solicitante
        montaTela(objSolicitacao)

    End Sub

    Private Sub MostrarOperacao(codOperacao As String)
        Select Case codOperacao
            Case 1
                txtOperacao.Text = "Inclusão"
            Case 2
                txtOperacao.Text = "Alteração"
            Case 3
                txtOperacao.Text = "Bloqueio"
            Case 4
                txtOperacao.Text = "Desbloqueio"
        End Select
    End Sub

    Protected Sub btVoltar_Click(sender As Object, e As EventArgs) Handles btVoltar.Click
        Session("objSolicitacao") = Nothing
        Response.Redirect("frmSolicitacoesCadastro.aspx")
    End Sub

    Protected Sub btValidar_Click(sender As Object, e As EventArgs) Handles btValidar.Click
        btOK.Text = "Sim"

        ExibeMensagemPopUp("Confirmação", "Confirma validação da solicitação de cadastro?", "Confirma", "Sim", "", "")
    End Sub

    Protected Sub btOK_Click(sender As Object, e As EventArgs) Handles btOK.Click
        If sender.text = "Sim" Then
            EfetivaValidacao()
        ElseIf sender.text = "Recusar" Then
            EfetivaRecusa()
        End If

    End Sub

    Private Sub EfetivaValidacao()
        Try
            Dim objSolicitacaoCadastro As BLL.bllSolicitacaoCadastro
            Dim oSchSolicitacaoCadastro As New ShL.schSolicitacaoCadastro
            Dim objSchCAT As ShL.schCAT = Session("objCAT")

            oSchSolicitacaoCadastro = Session("objSolicitacao")
            objSolicitacaoCadastro = New BLL.bllSolicitacaoCadastro()
            oSchSolicitacaoCadastro.cd_usuario_atualizacao = objSchCAT.sUsuario
            objSolicitacaoCadastro.ValidaSolicitacaoCadastro(oSchSolicitacaoCadastro)
            objSolicitacaoCadastro.EnviaEmailValidacao(oSchSolicitacaoCadastro)
            Session("objSolicitacao") = Nothing
            ExibeMensagemPopUp("Confirmação", "Solicitação de Cadastramento validada com sucesso!", _
                   "OK", "javascript:window.location.href=""./frmSolicitacoesCadastro.aspx""; return false;")
        Catch ex As Exception
            If ex.Message.StartsWith("W:") Then
                ExibeMensagemPopUp("Info", ex.Message.Replace("W:", ""))
            Else
                ExibeMensagemPopUp("Mensagem de Erro", "Aconteceu um erro inesperado!" + Chr(13) + ex.Message)
            End If

        End Try
    End Sub

    Private Function CarregaCondPgmto(Cod As String)
        Dim objCondPgmto As New BLL.bllSolicitacaoCadastro

        Dim oDataTable As Data.DataTable = objCondPgmto.getCondPgmtoByCod(Cod)

        Return oDataTable.Rows(0).Item("Texto")
    End Function

    Private Sub ExibeMensagemPopUp(sTitulo As String, sMensagem As String)
        sMensagem = sMensagem.Replace(vbCrLf, "<BR>")
        sMensagem = sMensagem.Replace(Chr(13), "<BR>")
        sMensagem = sMensagem.Replace("'", "")
        sMensagem = sMensagem.Replace(";", "-")
        Dim sJavaScript As String = "javascript:exibeMessagepopUp('" + sTitulo + "','" + sMensagem + "');"
        Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyScript", sJavaScript, True)
    End Sub

    Private Sub ExibeMensagemPopUp(sTitulo As String, sMensagem As String, sNomeAcaoASP As String, sTextoBotao As String, sTexto As String, sTexto2 As String)
        sMensagem = sMensagem.Replace(vbCrLf, "<BR>")
        sMensagem = sMensagem.Replace(Chr(13), "<BR>")
        sMensagem = sMensagem.Replace("'", "")
        sMensagem = sMensagem.Replace(";", "-")
        Dim sJavaScript As String = "javascript:exibeMessagepopUp('" + sTitulo + "','" + sMensagem + "', '" + sTextoBotao + "', null, '" + sNomeAcaoASP + "');"
        Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyScript", sJavaScript, True)
    End Sub

    Private Sub ExibeMensagemPopUp(sTitulo As String, sMensagem As String, sNomeAcao As String, sAcao As String, sNomeAcaoASP As String)
        sMensagem = sMensagem.Replace(Chr(13), "<BR>")
        Dim sJavaScript As String = "javascript:exibeMessagepopUp('" + sTitulo + "','" + sMensagem + "','" + sNomeAcao + "','" + sAcao + "', true, '" + sNomeAcaoASP + "');"
        Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyScript", sJavaScript, True)
    End Sub

    Private Sub ExibeMensagemPopUp(sTitulo As String, sMensagem As String, sNomeAcao As String, sAcao As String)
        sMensagem = sMensagem.Replace(Chr(13), "<BR>")
        Dim sJavaScript As String = "javascript:exibeMessagepopUp('" + sTitulo + "','" + sMensagem + "','" + sNomeAcao + "','" + sAcao + "');"
        Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyScript", sJavaScript, True)
    End Sub

    Private Sub EfetivaRecusa()
        Try
            Dim objSolicitacaoCadastro As BLL.bllSolicitacaoCadastro
            Dim oSchSolicitacaoCadastro As New ShL.schSolicitacaoCadastro
            Dim objSchCAT As ShL.schCAT = Session("objCAT")

            oSchSolicitacaoCadastro = Session("objSolicitacao")
            objSolicitacaoCadastro = New BLL.bllSolicitacaoCadastro()
            oSchSolicitacaoCadastro.cd_usuario_atualizacao = objSchCAT.sUsuario
            oSchSolicitacaoCadastro.dc_motivo_recusa = txtMotivoRecusa.Text
            objSolicitacaoCadastro.RecusaSolicitacaoCadastro(oSchSolicitacaoCadastro)
            objSolicitacaoCadastro.EnviaEmailRecusa(oSchSolicitacaoCadastro)
            Session("objSolicitacao") = Nothing
            ExibeMensagemPopUp("Confirmação", "Solicitação de Cadastramento recusada com sucesso!", _
                   "OK", "javascript:window.location.href=""./frmSolicitacoesCadastro.aspx""; return false;")
        Catch ex As Exception
            If ex.Message.StartsWith("W:") Then
                ExibeMensagemPopUp("Info", ex.Message.Replace("W:", ""))
            Else
                ExibeMensagemPopUp("Mensagem de Erro", "Aconteceu um erro inesperado!" + Chr(13) + ex.Message)
            End If

        End Try
    End Sub

    Protected Sub btMotivo_Click(sender As Object, e As EventArgs) Handles btMotivo.Click

        If (txtMotivoRecusa.Text = "") Then
            ExibeMensagemPopUp("Dados Incorretos", "Informe o Motivo da Recusa.")
        End If

        btOK.Text = "Recusar"

        ExibeMensagemPopUp("Confirmação", "Confirma recusa da solicitação de cadastro?", "Confirma", "Recusar", "", "")
    End Sub

    Protected Sub btRecusar_Click(sender As Object, e As EventArgs) Handles btRecusar.Click
        btRecusar.Visible = False
        btValidar.Visible = False
        btVoltar.Visible = False
        txtMotivoRecusa.Visible = True
        btMotivo.Visible = True
        btCancelar.Visible = True
        btVoltar2.Visible = True
    End Sub

    Protected Sub btCancelar_Click(sender As Object, e As EventArgs) Handles btCancelar.Click
        btRecusar.Visible = True
        btValidar.Visible = True
        btVoltar.Visible = True
        txtMotivoRecusa.Visible = False
        btMotivo.Visible = False
        btCancelar.Visible = False
        btVoltar2.Visible = False
    End Sub

    Protected Sub btVoltar2_Click(sender As Object, e As EventArgs) Handles btVoltar2.Click
        btVoltar_Click(sender,e)
    End Sub
End Class