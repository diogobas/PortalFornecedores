Public Class frmStatusCadastramento
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Common.Configuracao.getManutencao() Then
            Response.Redirect("Manutencao.aspx")
        End If

        If Not IsPostBack Then
            Dim nvc As NameValueCollection = Request.Form

            If Not Session("objSolicitacao") Is Nothing Then
                Dim objSolicitacao As ShL.schSolicitacaoCadastro = Session("objSolicitacao")
                CarregaTela(objSolicitacao)
                Session("objSolicitacao") = Nothing
            Else
                Response.Redirect("Default.aspx")
            End If
        End If

    End Sub

    Private Sub CarregaTela(objSolicitacao As ShL.schSolicitacaoCadastro)

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

    End Sub

    Protected Sub btProximo_Click(sender As Object, e As EventArgs) Handles btVoltar.Click
        Response.Redirect("Default.aspx")
    End Sub
End Class