Public Class ucrContentTop
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Me.Page.AppRelativeVirtualPath.ToLower.Contains("default.aspx") Then
            MenuInterno_001.Attributes.Item("class") = "link_pg_internas_active"
        ElseIf Me.Page.AppRelativeVirtualPath.ToLower.Contains("contato.aspx") Then
            MenuInterno_002.Attributes.Item("class") = "link_pg_internas_active"
        ElseIf Me.Page.AppRelativeVirtualPath.ToLower.Contains("duvidasfrequentes.aspx") Then
            MenuInterno_003.Attributes.Item("class") = "link_pg_internas_active"
        ElseIf Me.Page.AppRelativeVirtualPath.ToLower.Contains("codigoetica.aspx") Then
            MenuInterno_004.Attributes.Item("class") = "link_pg_internas_active"
        End If

    End Sub

End Class