Public Class frmCadastramento2
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Common.Configuracao.getManutencao() Then
            Response.Redirect("Manutencao.aspx")
        End If

        If Not IsPostBack Then
            If Not Session("objSolicitacao") Is Nothing Then
                CarregaTelacomSessao()
                lblNomeContato.Visible = cmbComoConheceu.SelectedValue = 9
                txtNomeContato.Visible = cmbComoConheceu.SelectedValue = 9
            End If
        End If
    End Sub

    Protected Sub btVoltar_Click(sender As Object, e As EventArgs) Handles btVoltar.Click
        CarregaShlnaSessao()
        Response.Redirect("frmCadastramento.aspx")
    End Sub

    Private Sub CarregaShlnaSessao()
        Dim objSolicitacao As New ShL.schSolicitacaoCadastro

        objSolicitacao = Session("objSolicitacao")
        objSolicitacao.objDadosAdicionais.objComoConheceu.cd_como_conheceu = IIf(cmbComoConheceu.SelectedValue.Length = 0, 0, cmbComoConheceu.SelectedValue)
        objSolicitacao.objDadosAdicionais.no_contato = txtNomeContato.Text.ToUpper
        objSolicitacao.objDadosAdicionais.dc_servicos = txtServicos.Text.ToUpper
        objSolicitacao.objDadosAdicionais.dc_materiais = txtMateriais.Text.ToUpper

        Session("objSolicitacao") = objSolicitacao

    End Sub

    Private Sub CarregaTelacomSessao()
        Dim objSolicitacao As ShL.schSolicitacaoCadastro

        objSolicitacao = Session("objSolicitacao")
        cmbComoConheceu.SelectedValue = objSolicitacao.objDadosAdicionais.objComoConheceu.cd_como_conheceu
        txtNomeContato.Text = objSolicitacao.objDadosAdicionais.no_contato
        txtServicos.Text = objSolicitacao.objDadosAdicionais.dc_servicos
        txtMateriais.Text = objSolicitacao.objDadosAdicionais.dc_materiais

    End Sub
    Protected Sub btFinalizar_Click(sender As Object, e As EventArgs) Handles btFinalizar.Click
        Dim objSolicitacao As ShL.schSolicitacaoCadastro
        Dim objBllSolicitacao As New BLL.bllSolicitacaoCadastro

        CarregaShlnaSessao()
        objSolicitacao = Session("objSolicitacao")

        Try
            objBllSolicitacao.Insert(objSolicitacao)
            objBllSolicitacao.EnviaEmailRetorno(objSolicitacao)
            objBllSolicitacao.EnviaEmailAnalise(objSolicitacao)
            Session("objSolicitacao") = Nothing
            ExibeMensagemPopUp("Confirmação", "Sua solicitação de cadastramento foi realizada com sucesso!" + Chr(13) + "Seus dados serão analisados por nossa equipe interna." + Chr(13) + "Ultilize a chave de acesso abaixo para acompanhar o status da sua solicitação." + Chr(13) + "Chave de acesso: " & objSolicitacao.xx_chave_acesso, _
                               "OK", "javascript:window.location.href=""./Default.aspx""; return false;")
        Catch ex As Exception
            If ex.Message.StartsWith("W:") Then
                ExibeMensagemPopUp("Info", ex.Message.Replace("W:", ""))
            Else
                ExibeMensagemPopUp("Mensagem de Erro", "Aconteceu um erro inesperado ao realizadar sua solicitação!" + Chr(13) + ex.Message)
            End If
        End Try
    End Sub

    Private Sub ExibeMensagemPopUp(sTitulo As String, sMensagem As String)
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

    Protected Sub cmbComoConheceu_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbComoConheceu.SelectedIndexChanged
        lblNomeContato.Visible = cmbComoConheceu.SelectedValue = 9
        txtNomeContato.Visible = cmbComoConheceu.SelectedValue = 9
        If cmbComoConheceu.SelectedValue <> 9 Then
            txtNomeContato.Text = ""
        End If
    End Sub
End Class