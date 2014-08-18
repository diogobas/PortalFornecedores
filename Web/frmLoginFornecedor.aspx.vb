Public Class frmLoginFornecedor
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
            txtCNPJ.Focus()
            Exit Function
        End If
        Try
            oValidacao.cnpj = txtCNPJ.Text
        Catch ex As Exception
            ExibeMensagemPopUp("Dados Incorretos", "CNPJ Inválido.")
            txtCNPJ.Text = ""
            txtCNPJ.Focus()
            Exit Function
        End Try

        If txtChaveAcesso.Text.Length = 0 Then
            ExibeMensagemPopUp("Dados Incorretos", "Informe a chave de acesso.")
            txtChaveAcesso.Focus()
            Exit Function
        End If
        Return True
    End Function

    Protected Sub btAcessoFornecedores_Click(sender As Object, e As EventArgs) Handles btAcessoFornecedores.Click
        Dim objFornecedor As New BLL.bllFornecedor
        Dim objSchSolicitacao As New ShL.schSolicitacaoCadastro
        Dim objSchFornecedor As New ShL.schFornecedor
        Dim oDataTable As Data.DataTable

        If Not ValidaCamposAcesso() Then
            Exit Sub
        End If
        Try
            oDataTable = objFornecedor.ValidaFornecedor(Common.Functions.RetiraFormatoCNPJ(txtCNPJ.Text), txtChaveAcesso.Text)
            If Not oDataTable Is Nothing Then
                If oDataTable.Rows(0).Item("cd_status_chave_acesso") = 0 Then
                    Dim oSolicitacaoCadastro As New BLL.bllSolicitacaoCadastro
                    objSchSolicitacao = oSolicitacaoCadastro.getSolicitacaoCadastroByCNPJ(Common.Functions.RetiraFormatoCNPJ(txtCNPJ.Text))
                    Session("objSolicitacao") = objSchSolicitacao
                    Response.Redirect("frmStatusCadastramento.aspx")
                Else
                    objSchFornecedor = objFornecedor.getFornecedorByCNPJ(Common.Functions.RetiraFormatoCNPJ(txtCNPJ.Text))
                    Session("objSessaoFornecedor") = objSchFornecedor

                    Response.Redirect("frmAreaRestrita.aspx")
                End If
            Else
                ExibeMensagemPopUp("Dados Incorretos", "Credenciais informadas inválidas.")
                txtCNPJ.Text = ""
                txtChaveAcesso.Text = ""
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

End Class