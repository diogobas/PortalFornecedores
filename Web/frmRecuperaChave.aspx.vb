Public Class frmRecuperaChave
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
        Dim objSchFornecedor As New ShL.schFornecedor
        Dim oDataTable As Data.DataTable = Nothing

        If Not ValidaCamposAcesso() Then
            Exit Sub
        End If
        Try
            objSchFornecedor = objFornecedor.getFornecedorByCNPJ(Common.Functions.RetiraFormatoCNPJ(txtCNPJ.Text))
            If objSchFornecedor.xx_chave_acesso.Length = 0 Then
                ExibeMensagemPopUp("Chave de Acesso", "Não existe Chave de Acesso para este CNPJ.")
            Else
                oDataTable = objFornecedor.ValidaRecuperaChave(Common.Functions.RetiraFormatoCNPJ(txtCNPJ.Text), txtEmail.Text)
                If Not oDataTable Is Nothing Then
                    objFornecedor.EnviaEmailRecuperaChave(txtCNPJ.Text, oDataTable.Rows(0).Item("xx_email_contato"), oDataTable.Rows(0).Item("xx_chave_acesso"))
                    ExibeMensagemPopUp("Confirmação", "Chave de Acesso foi enviada para o email " + txtEmail.Text, _
                        "OK", "javascript:window.location.href=""./Default.aspx""; return false;")
                End If
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