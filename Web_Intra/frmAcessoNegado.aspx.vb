Public Class frmAcessoNegado
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim sPageName As String = Request.FilePath.Substring(1, Request.FilePath.Length - 6)
        If Common.Configuracao.getManutencao() Then
            Response.Redirect("Manutencao.aspx")
        End If

    End Sub
    
End Class