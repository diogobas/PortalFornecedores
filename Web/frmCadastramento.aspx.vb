Public Class frmCadastramento
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Common.Configuracao.getManutencao() Then
            Response.Redirect("Manutencao.aspx")
        End If

        If Not IsPostBack Then
            If Not Session("objSolicitacao") Is Nothing Then
                CarregaTelacomSessao()
            Else
                If Not Session("CNPJ") Is Nothing Then
                    txtCNPJ.Text = Session("CNPJ")
                Else
                    Response.Redirect("Default.aspx")
                End If
            End If
        End If

    End Sub

    Private Sub CarregaShlnaSessao()
        Dim objSolicitacao As ShL.schSolicitacaoCadastro

        If Session("objSolicitacao") Is Nothing Then
            objSolicitacao = New ShL.schSolicitacaoCadastro
        Else
            objSolicitacao = Session("objSolicitacao")

        End If

        objSolicitacao.objDadosBasicos.no_tipo_solicitacao = "E"
        objSolicitacao.objDadosBasicos.no_operacao = "1"
        objSolicitacao.objDadosBasicos.no_razao_social = txtRazaoSocial.Text
        objSolicitacao.objDadosBasicos.no_nome_fantasia = txtNomeFantazia.Text
        objSolicitacao.objDadosBasicos.nm_CNPJ = txtCNPJ.Text.Replace(".", "").Replace("-", "").Replace("/", "")
        objSolicitacao.objDadosBasicos.nm_inscricao_estadual = txtInscEstadual.Text
        objSolicitacao.objDadosBasicos.nm_inscricao_municipal = txtInscMunicipal.Text
        objSolicitacao.objDadosBasicos.no_rua = txtEndereco.Text
        objSolicitacao.objDadosBasicos.nm_numero = txtNumero.Text
        objSolicitacao.objDadosBasicos.xx_complemento = txtComplemento.Text
        objSolicitacao.objDadosBasicos.no_bairro = txtBairro.Text
        objSolicitacao.objDadosBasicos.nm_CEP = txtCep.Text
        objSolicitacao.objDadosBasicos.nm_caixa_postal = txtCaixaPostal.Text
        objSolicitacao.objDadosBasicos.no_cidade = txtCidade.Text
        objSolicitacao.objDadosBasicos.sg_estado = ddlEstado.SelectedValue
        objSolicitacao.objDadosBasicos.cd_pais = ddlSiglaPais.SelectedValue

        objSolicitacao.objContato.no_nome = txtNomeContato.Text
        objSolicitacao.objContato.no_sobrenome = txtSobrenomeContato.Text
        objSolicitacao.objContato.no_funcao = txtFuncaoContato.Text
        objSolicitacao.objContato.no_departamento = txtDepartamentoContato.Text
        objSolicitacao.objContato.nm_telefone = txtTelefoneContato.Text
        objSolicitacao.objContato.nm_fax = txtFaxContato.Text
        objSolicitacao.objContato.nm_celular = txtCelularContato.Text
        objSolicitacao.objContato.xx_email = txtEmailContato.Text

        Session("objSolicitacao") = objSolicitacao

    End Sub

    Private Sub CarregaTelacomSessao()
        Dim objSolicitacao As ShL.schSolicitacaoCadastro

        objSolicitacao = Session("objSolicitacao")

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
        ddlEstado.SelectedValue = objSolicitacao.objDadosBasicos.sg_estado
        ddlSiglaPais.SelectedValue = objSolicitacao.objDadosBasicos.cd_pais

        txtNomeContato.Text = objSolicitacao.objContato.no_nome
        txtSobrenomeContato.Text = objSolicitacao.objContato.no_sobrenome
        txtFuncaoContato.Text = objSolicitacao.objContato.no_funcao
        txtDepartamentoContato.Text = objSolicitacao.objContato.no_departamento
        txtTelefoneContato.Text = objSolicitacao.objContato.nm_telefone
        txtFaxContato.Text = objSolicitacao.objContato.nm_fax
        txtCelularContato.Text = objSolicitacao.objContato.nm_celular
        txtEmailContato.Text = objSolicitacao.objContato.xx_email

    End Sub

    Protected Sub btProximo_Click(sender As Object, e As EventArgs) Handles btProximo.Click

        If Not ValidaCampos() Then
            Exit Sub
        End If
        CarregaShlnaSessao()

        Response.Redirect("frmCadastramento2.aspx")
    End Sub

    Private Function ValidaCampos() As Boolean

        If txtRazaoSocial.Text.Length = 0 Then
            ExibeMensagemPopUp("Validação", "Informe a Razão Social.")
            Return False
        ElseIf txtNomeFantazia.Text.Length = 0 Then
            ExibeMensagemPopUp("Validação", "Informe um Nome Fantasia.")
            Return False
        ElseIf txtCNPJ.Text.Length = 0 Then
            ExibeMensagemPopUp("Validação", "Informe o seu CNPJ.")
            Return False
        ElseIf txtInscEstadual.Text.Length = 0 And txtInscMunicipal.Text.Length = 0 Then
            ExibeMensagemPopUp("Validação", "Informe a Inscrição Estadual ou Municipal.")
            Return False
        ElseIf txtEndereco.Text.Length = 0 Then
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