Public Class frmDetalheSolicitacaoChaveAcesso
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


            If Not Session("objSolicitacaoChaveAcesso") Is Nothing Then
                Dim objSolicitacaoChaveAcesso As ShL.schSolicitacaoChaveAcesso = Session("objSolicitacaoChaveAcesso")
                CarregaTela(objSolicitacaoChaveAcesso)
            Else
                Response.Redirect("frmSolicitacoesChave.aspx")
            End If
        End If

        btOK.Attributes.Add("onclick", (Me.ClientScript.GetPostBackEventReference(btOK, "") + ";this.value='Aguarde...';this.disabled = true;"))

    End Sub

    Private Sub CarregaTela(objSolicitacao As ShL.schSolicitacaoChaveAcesso)

        If objSolicitacao.objStatus.cd_status <> 0 Then
            btValidar.Visible = False
        End If

        txtDataSolicitacao.Text = objSolicitacao.dt_solicitacao.ToString("dd/MM/yyyy")
        txtStatusSolicitacao.Text = objSolicitacao.objStatus.dc_status

        txtRazaoSocial.Text = objSolicitacao.no_razao_social
        txtNomeSolicitante.Text = objSolicitacao.no_solicitante
        txtCNPJ.Text = Convert.ToInt64(objSolicitacao.nm_cnpj).ToString("00\.000\.000\/0000\-00")
        txtEmailSolicitante.Text = objSolicitacao.xx_email
    End Sub

    Protected Sub btVoltar_Click(sender As Object, e As EventArgs) Handles btVoltar.Click
        Session("objSolicitacaoChaveAcesso") = Nothing
        Response.Redirect("frmSolicitacoesChave.aspx")
    End Sub

    Protected Sub btValidar_Click(sender As Object, e As EventArgs) Handles btValidar.Click
        ExibeMensagemPopUp("Confirmação", "Confirma validação da solicitação da chave de acesso?", "Confirma")
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

    Private Sub EfetivaValidacao()
        Try
            Dim objSolicitacaoChaveAcesso As BLL.bllSolicitacaoChaveAcesso
            Dim oSchSolicitacaoCadastro As New ShL.schSolicitacaoChaveAcesso
            Dim objSchCAT As ShL.schCAT = Session("objCAT")

            oSchSolicitacaoCadastro = Session("objSolicitacaoChaveAcesso")
            objSolicitacaoChaveAcesso = New BLL.bllSolicitacaoChaveAcesso()
            oSchSolicitacaoCadastro.cd_usuario_atualizacao = objSchCAT.sUsuario
            objSolicitacaoChaveAcesso.ValidaSolicitacaoChaveAcesso(oSchSolicitacaoCadastro)
            objSolicitacaoChaveAcesso.EnviaEmailValidacao(oSchSolicitacaoCadastro)
            Session("objSolicitacaoChaveAcesso") = Nothing
            ExibeMensagemPopUp("Confirmação", "Solicitação de Chave validada com sucesso!" + Chr(13) + "Um email com a chave de acesso foi enviada para o email " + oSchSolicitacaoCadastro.xx_email, _
                   "OK", "javascript:window.location.href=""./frmSolicitacoesChave.aspx""; return false;")
        Catch ex As Exception
            If ex.Message.StartsWith("W:") Then
                ExibeMensagemPopUp("Info", ex.Message.Replace("W:", ""))
            Else
                ExibeMensagemPopUp("Mensagem de Erro", "Aconteceu um erro inesperado!" + Chr(13) + ex.Message)
            End If
        End Try
    End Sub

    Protected Sub btOK_Click(sender As Object, e As EventArgs) Handles btOK.Click
        EfetivaValidacao()
    End Sub
End Class