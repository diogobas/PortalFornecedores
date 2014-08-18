Public Class frmAtualizacaoCadastro2
    Inherits System.Web.UI.Page

    Private objSessaoFornecedor As ShL.schFornecedor

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Common.Configuracao.getManutencao() Then
            Response.Redirect("Manutencao.aspx")
        End If

        If Not IsPostBack Then
            If Not Session("objSessaoFornecedor") Is Nothing Then
                objSessaoFornecedor = Session("objSessaoFornecedor")
                lblFornecedor.Text = objSessaoFornecedor.objDadosBasicos.no_razao_social
            Else
                Response.Redirect("frmLoginFornecedor.aspx")
            End If

            If Not Session("objSolicitacaoAlteracao") Is Nothing Then
                CarregaTelacomSessao()
            End If

        End If
    End Sub

    Private Sub CarregaShlnaSessao()
        Dim objSolicitacaoAlteracao As New ShL.schSolicitacaoAlteracao

        objSolicitacaoAlteracao = Session("objSolicitacaoAlteracao")
        objSolicitacaoAlteracao.objDadosAdicionais.dc_servicos = txtServicos.Text.ToUpper
        objSolicitacaoAlteracao.objDadosAdicionais.dc_materiais = txtMateriais.Text.ToUpper

        Session("objSolicitacao") = objSolicitacaoAlteracao

    End Sub

    Private Sub CarregaTelacomSessao()
        Dim objSolicitacaoAlteracao As ShL.schSolicitacaoAlteracao

        objSolicitacaoAlteracao = Session("objSolicitacaoAlteracao")
        txtServicos.Text = objSolicitacaoAlteracao.objDadosAdicionais.dc_servicos
        txtMateriais.Text = objSolicitacaoAlteracao.objDadosAdicionais.dc_materiais

    End Sub


    Protected Sub btnSair_Click(sender As Object, e As EventArgs) Handles btnSair.Click
        Session("objSessaoFornecedor") = Nothing
        Response.Redirect("Default.aspx")
    End Sub
    Protected Sub btVoltar_Click(sender As Object, e As EventArgs) Handles btVoltar.Click
        CarregaShlnaSessao()
        Response.Redirect("frmAtualizacaoCadastro.aspx")
    End Sub

    Protected Sub btFinalizar_Click(sender As Object, e As EventArgs) Handles btSalvar.Click
        Dim objSolicitacaoAlteracao As ShL.schSolicitacaoAlteracao
        Dim objBllSolicitacaoAlteracao As New BLL.bllSolicitacaoAlteracao

        CarregaShlnaSessao()
        objSolicitacaoAlteracao = Session("objSolicitacao")

        Try
            objBllSolicitacaoAlteracao.Insert(objSolicitacaoAlteracao)
            objBllSolicitacaoAlteracao.EnviaEmailRetorno(objSolicitacaoAlteracao)
            objBllSolicitacaoAlteracao.EnviaEmailAnalise(objSolicitacaoAlteracao)
            Session("objSolicitacaoAlteracao") = Nothing
            ExibeMensagemPopUp("Confirmação", "Sua solicitação de alteração foi realizada com sucesso!" + Chr(13) + "Seus dados serão analisados por nossa equipe interna.", _
                               "OK", "javascript:window.location.href=""./frmAreaRestrita.aspx""; return false;")
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

End Class