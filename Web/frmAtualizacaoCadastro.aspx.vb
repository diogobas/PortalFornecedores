Public Class frmAtualizacaoCadastro
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
                Session("objSolicitacaoAlteracao") = Nothing
            End If

            If Session("objSolicitacaoAlteracao") Is Nothing Then
                Dim objSchSolicitacaoAlteracao As New ShL.schSolicitacaoAlteracao
                Dim objSolicitacaoAlteracao As New BLL.bllSolicitacaoAlteracao

                objSchSolicitacaoAlteracao = objSolicitacaoAlteracao.getSolicitacaoAlteracaoByCNPJ(objSessaoFornecedor.objDadosBasicos.nm_CNPJ)

                If (Not objSchSolicitacaoAlteracao Is Nothing) AndAlso objSchSolicitacaoAlteracao.objStatus.cd_status = 0 Then
                    Session("objSolicitacaoAlteracao") = objSchSolicitacaoAlteracao
                    Response.Redirect("frmStatusAlteracaoCadastro.aspx")
                Else
                    objSchSolicitacaoAlteracao = New ShL.schSolicitacaoAlteracao
                    objSchSolicitacaoAlteracao.objDadosBasicos = objSessaoFornecedor.objDadosBasicos.Clone
                    objSchSolicitacaoAlteracao.objContato = objSessaoFornecedor.objContato.Clone
                    objSchSolicitacaoAlteracao.objDadosAdicionais = objSessaoFornecedor.objDadosAdicionais.Clone
                    Session("objSolicitacaoAlteracao") = objSchSolicitacaoAlteracao
                End If

            End If

            CarregaTelacomSessao()

        End If
    End Sub

    Protected Sub btnSair_Click(sender As Object, e As EventArgs) Handles btnSair.Click
        Session("objSessaoFornecedor") = Nothing
        Response.Redirect("Default.aspx")
    End Sub

    Private Sub CarregaTelacomSessao()
        Dim objSolicitacaoAlteracao As ShL.schSolicitacaoAlteracao

        objSolicitacaoAlteracao = Session("objSolicitacaoAlteracao")

        txtEndereco.Text = objSolicitacaoAlteracao.objDadosBasicos.no_rua
        txtNumero.Text = objSolicitacaoAlteracao.objDadosBasicos.nm_numero
        txtComplemento.Text = objSolicitacaoAlteracao.objDadosBasicos.xx_complemento
        txtBairro.Text = objSolicitacaoAlteracao.objDadosBasicos.no_bairro
        txtCep.Text = objSolicitacaoAlteracao.objDadosBasicos.nm_CEP
        txtCaixaPostal.Text = objSolicitacaoAlteracao.objDadosBasicos.nm_caixa_postal
        txtCidade.Text = objSolicitacaoAlteracao.objDadosBasicos.no_cidade
        ddlEstado.SelectedValue = objSolicitacaoAlteracao.objDadosBasicos.sg_estado
        ddlSiglaPais.SelectedValue = objSolicitacaoAlteracao.objDadosBasicos.cd_pais

        txtNomeContato.Text = objSolicitacaoAlteracao.objContato.no_nome
        txtSobrenomeContato.Text = objSolicitacaoAlteracao.objContato.no_sobrenome
        txtFuncaoContato.Text = objSolicitacaoAlteracao.objContato.no_funcao
        txtDepartamentoContato.Text = objSolicitacaoAlteracao.objContato.no_departamento
        txtTelefoneContato.Text = objSolicitacaoAlteracao.objContato.nm_telefone
        txtFaxContato.Text = objSolicitacaoAlteracao.objContato.nm_fax
        txtCelularContato.Text = objSolicitacaoAlteracao.objContato.nm_celular
        txtEmailContato.Text = objSolicitacaoAlteracao.objContato.xx_email

    End Sub

    Private Function ValidaCampos() As Boolean

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
        ElseIf txtNomeContato.Text.Length = 0 Then
            ExibeMensagemPopUp("Validação", "Informe o Nome de Contato.")
            Return False
        ElseIf txtSobrenomeContato.Text.Length = 0 Then
            ExibeMensagemPopUp("Validação", "Informe o Sobrenome.")
            Return False
        ElseIf txtFuncaoContato.Text.Length = 0 Then
            ExibeMensagemPopUp("Validação", "Informe a Função.")
            Return False
        ElseIf txtDepartamentoContato.Text.Length = 0 Then
            ExibeMensagemPopUp("Validação", "Informe o Departamento.")
            Return False
        ElseIf txtTelefoneContato.Text.Length = 0 Then
            ExibeMensagemPopUp("Validação", "Informe o Telefone de Contato.")
            Return False
        End If

        If txtEmailContato.Text.Length = 0 Then
            ExibeMensagemPopUp("Validação", "Informe um email para contato.")
            Return False
        Else
            If Not Common.Functions.ValidarEmail(txtEmailContato.Text) Then
                ExibeMensagemPopUp("Validação", "Email inválido.")
                Return False
            End If
        End If

        Return True

    End Function

    Protected Sub btProximo_Click(sender As Object, e As EventArgs) Handles btProximo.Click

        If Not ValidaCampos() Then
            Exit Sub
        End If
        CarregaShlnaSessao()

        Response.Redirect("frmAtualizacaoCadastro2.aspx")

    End Sub

    Private Sub CarregaShlnaSessao()
        Dim objSolicitacaoAlteracao As ShL.schSolicitacaoAlteracao

        If Session("objSolicitacaoAlteracao") Is Nothing Then
            objSolicitacaoAlteracao = New ShL.schSolicitacaoAlteracao
        Else
            objSolicitacaoAlteracao = Session("objSolicitacaoAlteracao")

        End If

        objSessaoFornecedor = Session("objSessaoFornecedor")

        objSolicitacaoAlteracao.objDadosBasicos.no_rua = txtEndereco.Text.ToUpper
        objSolicitacaoAlteracao.objDadosBasicos.nm_numero = txtNumero.Text.ToUpper
        objSolicitacaoAlteracao.objDadosBasicos.xx_complemento = txtComplemento.Text.ToUpper
        objSolicitacaoAlteracao.objDadosBasicos.no_bairro = txtBairro.Text.ToUpper
        objSolicitacaoAlteracao.objDadosBasicos.nm_CEP = txtCep.Text.ToUpper
        objSolicitacaoAlteracao.objDadosBasicos.nm_caixa_postal = txtCaixaPostal.Text.ToUpper
        objSolicitacaoAlteracao.objDadosBasicos.no_cidade = txtCidade.Text.ToUpper
        objSolicitacaoAlteracao.objDadosBasicos.sg_estado = ddlEstado.SelectedValue
        objSolicitacaoAlteracao.objDadosBasicos.cd_pais = ddlSiglaPais.SelectedValue

        objSolicitacaoAlteracao.objContato.no_nome = txtNomeContato.Text.ToUpper
        objSolicitacaoAlteracao.objContato.no_sobrenome = txtSobrenomeContato.Text.ToUpper
        objSolicitacaoAlteracao.objContato.no_funcao = txtFuncaoContato.Text.ToUpper
        objSolicitacaoAlteracao.objContato.no_departamento = txtDepartamentoContato.Text.ToUpper
        objSolicitacaoAlteracao.objContato.nm_telefone = txtTelefoneContato.Text.ToUpper
        objSolicitacaoAlteracao.objContato.nm_fax = txtFaxContato.Text
        objSolicitacaoAlteracao.objContato.nm_celular = txtCelularContato.Text
        objSolicitacaoAlteracao.objContato.xx_email = txtEmailContato.Text.ToUpper

        Session("objSolicitacaoAlteracao") = objSolicitacaoAlteracao

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