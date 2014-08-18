Public Class frmSolicitaChave
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Common.Configuracao.getManutencao() Then
            Response.Redirect("Manutencao.aspx")
        End If

        If Not IsPostBack Then
            Session("objSolicitacao") = Nothing
        End If

    End Sub

    Private Function ValidaCamposAcesso() As Boolean
        ValidaCamposAcesso = False
        Dim oValidacao As New Common.Validacao
        If txtCNPJ.Text.Length = 0 Then
            ExibeMensagemPopUp("Dados Incorretos", "Informe o CNPJ.")
            Exit Function
        End If
        Try
            oValidacao.cnpj = txtCNPJ.Text
        Catch ex As Exception
            ExibeMensagemPopUp("Dados Incorretos", "CNPJ Inválido.")
            txtCNPJ.Text = ""
            Exit Function
        End Try

        If txtRazaoSolcial.Text.Length = 0 Then
            ExibeMensagemPopUp("Dados Incorretos", "Informe a Razão Social.")
            Exit Function
        End If

        If txtNome.Text.Length = 0 Then
            ExibeMensagemPopUp("Dados Incorretos", "Informe o Nome.")
            Exit Function
        End If

        If txtEmail.Text.Length = 0 Then
            ExibeMensagemPopUp("Dados Incorretos", "Informe um email para contato.")
            Exit Function
        Else
            If Not Common.Functions.ValidarEmail(txtEmail.Text) Then
                ExibeMensagemPopUp("Validação", "Email inválido.")
                Exit Function
            End If
        End If

        Return True

    End Function

    Protected Sub btSolicitaChave_Click(sender As Object, e As EventArgs) Handles btSolicitaChave.Click
        Dim objFornecedor As New BLL.bllFornecedor
        Dim objSchSolicitacaoChaveAcesso As New ShL.schSolicitacaoChaveAcesso
        Dim objSchFornecedor As New ShL.schFornecedor
        Dim oDataTable As Data.DataTable = Nothing

        If Not ValidaCamposAcesso() Then
            Exit Sub
        End If
        Try
            objSchFornecedor = objFornecedor.getFornecedorByCNPJ(Common.Functions.RetiraFormatoCNPJ(txtCNPJ.Text))
            If objSchFornecedor.xx_chave_acesso.Length > 0 Then
                ExibeMensagemPopUp("Chave de Acesso", "Já existe chave de acesso para este CNPJ.")
            Else
                objSchSolicitacaoChaveAcesso.nm_cnpj = Common.Functions.RetiraFormatoCNPJ(txtCNPJ.Text)
                objSchSolicitacaoChaveAcesso.no_razao_social = txtRazaoSolcial.Text.ToUpper
                objSchSolicitacaoChaveAcesso.no_solicitante = txtNome.Text.ToUpper
                objSchSolicitacaoChaveAcesso.xx_email = txtEmail.Text.ToUpper
                Dim objSolicitacaoChaveAcessso As New BLL.bllSolicitacaoChaveAcesso(objSchSolicitacaoChaveAcesso)
                objSolicitacaoChaveAcessso.Insert(objSchSolicitacaoChaveAcesso)
                objSolicitacaoChaveAcessso.EnviaEmailAnalise(objSchSolicitacaoChaveAcesso)
                objSolicitacaoChaveAcessso.EnviaEmailRetorno(objSchSolicitacaoChaveAcesso)

                ExibeMensagemPopUp("Confirmação", "Sua solicitação de Chave de Acesso foi realizada com sucesso!" + Chr(13) + "Seus dados serão analisados por nossa equipe interna.", _
                   "OK", "javascript:window.location.href=""./Default.aspx""; return false;")

            End If
        Catch ex As Exception
            If ex.Message.StartsWith("W:") Then
                ExibeMensagemPopUp("Info", ex.Message.Replace("W:", ""))
            Else
                ExibeMensagemPopUp("Mensagem de Erro", "Aconteceu um erro inesperado!" + Chr(13) + ex.Message)
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

    Protected Sub btVoltar_Click(sender As Object, e As EventArgs) Handles btVoltar.Click
        Response.Redirect("Default.aspx")
    End Sub
End Class