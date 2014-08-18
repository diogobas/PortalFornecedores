Public Class frmEntradaPagamentos
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
        End If
    End Sub

    Protected Sub btnSair_Click(sender As Object, e As EventArgs) Handles btnSair.Click
        Session("objSessaoFornecedor") = Nothing
        Response.Redirect("Default.aspx")
    End Sub
End Class