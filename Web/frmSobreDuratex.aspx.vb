Public Class frmSobreDuratex
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Common.Configuracao.getManutencao() Then
            Response.Redirect("Manutencao.aspx")
        End If
    End Sub

    Protected Sub btVoltar_Click(sender As Object, e As EventArgs) Handles btVoltar.Click
        Response.Redirect("Default.aspx")
    End Sub
End Class