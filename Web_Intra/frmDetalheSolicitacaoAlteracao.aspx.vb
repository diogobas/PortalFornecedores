Public Class frmDetalheSolicitacaoAlteracao
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

            If Not Session("objSolicitacaoAlteracao") Is Nothing Then
                Dim objSolicitacaoAlteracao As ShL.schSolicitacaoAlteracao = Session("objSolicitacaoAlteracao")
                CarregaTela(objSolicitacaoAlteracao)
            Else
                Response.Redirect("frmSolicitacoesAlteracao.aspx")
            End If
        End If

        btOK.Attributes.Add("onclick", (Me.ClientScript.GetPostBackEventReference(btOK, "") + ";this.value='Aguarde...';this.disabled = true;"))

    End Sub

    Private Sub CarregaTela(objSolicitacao As ShL.schSolicitacaoAlteracao)

        If objSolicitacao.objStatus.cd_status <> 0 Then
            btValidar.Visible = False
        End If

        txtDataSolicitacao.Text = objSolicitacao.dt_solicitacao.ToString("dd/MM/yyyy")
        txtStatusSolicitacao.Text = objSolicitacao.objStatus.dc_status

        txtRazaoSocial.Text = objSolicitacao.objDadosBasicos.no_razao_social
        txtNomeFantazia.Text = objSolicitacao.objDadosBasicos.no_nome_fantasia
        txtCNPJ.Text = Convert.ToInt64(objSolicitacao.objDadosBasicos.nm_CNPJ).ToString("00\.000\.000\/0000\-00")
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

        txtNomeContato.Text = objSolicitacao.objContato.no_nome
        txtSobrenomeContato.Text = objSolicitacao.objContato.no_sobrenome
        txtFuncaoContato.Text = objSolicitacao.objContato.no_funcao
        txtDepartamentoContato.Text = objSolicitacao.objContato.no_departamento
        txtTelefoneContato.Text = objSolicitacao.objContato.nm_telefone
        txtFaxContato.Text = objSolicitacao.objContato.nm_fax
        txtCelularContato.Text = objSolicitacao.objContato.nm_celular
        txtEmailContato.Text = objSolicitacao.objContato.xx_email

        txtServicos.Text = objSolicitacao.objDadosAdicionais.dc_servicos
        txtMateriais.Text = objSolicitacao.objDadosAdicionais.dc_materiais

    End Sub

    Protected Sub btVoltar_Click(sender As Object, e As EventArgs) Handles btVoltar.Click
        Session("objSolicitacaoAlteracao") = Nothing
        Response.Redirect("frmSolicitacoesAlteracao.aspx")
    End Sub

    Protected Sub btValidar_Click(sender As Object, e As EventArgs) Handles btValidar.Click
        ExibeMensagemPopUp("Confirmação", "Confirma validação da solicitação de alteração?", "Confirma")
    End Sub

    Private Sub ExibeMensagemPopUp(sTitulo As String, sMensagem As String)
        sMensagem = sMensagem.Replace(vbCrLf, "<BR>")
        sMensagem = sMensagem.Replace(Chr(13), "<BR>")
        sMensagem = sMensagem.Replace("'", "")
        sMensagem = sMensagem.Replace(";", "-")
        Dim sJavaScript As String = "javascript:exibeMessagepopUp('" + sTitulo + "','" + sMensagem + "');"
        Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyScript", sJavaScript, True)
    End Sub

    Private Sub ExibeMensagemPopUp(sTitulo As String, sMensagem As String, sNomeAcaoASP As String)
        sMensagem = sMensagem.Replace(vbCrLf, "<BR>")
        sMensagem = sMensagem.Replace(Chr(13), "<BR>")
        sMensagem = sMensagem.Replace("'", "")
        sMensagem = sMensagem.Replace(";", "-")
        Dim sJavaScript As String = "javascript:exibeMessagepopUp('" + sTitulo + "','" + sMensagem + "', null, null, '" + sNomeAcaoASP + "');"
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

    Protected Sub btOK_Click(sender As Object, e As EventArgs) Handles btOK.Click
        EfetivaValidacao()
    End Sub

    Private Sub EfetivaValidacao()
        Try
            Dim objSolicitacaoAlteracao As BLL.bllSolicitacaoAlteracao
            Dim oSchSolicitacaoCadastro As New ShL.schSolicitacaoAlteracao
            Dim objSchCAT As ShL.schCAT = Session("objCAT")

            oSchSolicitacaoCadastro = Session("objSolicitacaoAlteracao")
            objSolicitacaoAlteracao = New BLL.bllSolicitacaoAlteracao()
            oSchSolicitacaoCadastro.cd_usuario_atualizacao = objSchCAT.sUsuario
            objSolicitacaoAlteracao.ValidaSolicitacaoAlteracao(oSchSolicitacaoCadastro)
            objSolicitacaoAlteracao.EnviaEmailValidacao(oSchSolicitacaoCadastro)
            Session("objSolicitacaoAlteracao") = Nothing
            ExibeMensagemPopUp("Confirmação", "Solicitação de Alteração de Dados validada com sucesso!", _
                   "OK", "javascript:window.location.href=""./frmSolicitacoesAlteracao.aspx""; return false;")
        Catch ex As Exception
            If ex.Message.StartsWith("W:") Then
                ExibeMensagemPopUp("Info", ex.Message.Replace("W:", ""))
            Else
                ExibeMensagemPopUp("Mensagem de Erro", "Aconteceu um erro inesperado!" + Chr(13) + ex.Message)
            End If

        End Try
    End Sub
End Class