Public Class frmSair
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim sPageName As String = Request.FilePath.Substring(1, Request.FilePath.Length - 6)

        Session("objCAT") = Nothing
        Session("objSolicitacao") = Nothing
        Session("oSchDadosFiltro") = Nothing
        Session("objSolicitacaoAlteracao") = Nothing
        Session("objSolicitacaoChaveAcesso") = Nothing

        Dim sJavaScript As String = "javascript:window.close();"
        Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyScript", sJavaScript, True)

        'Response.Redirect("Login.aspx")


    End Sub

End Class