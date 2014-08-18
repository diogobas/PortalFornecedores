Public Class Site
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If (Not IsPostBack) Then
                'Dim objTrace As BLL.bllTraceAcesso = Nothing
                'Dim objSchema As New ShL.schTraceAcesso
                'objSchema.no_pagina = Me.Page.AppRelativeVirtualPath.Replace("~/", "")

                'objTrace = New BLL.bllTraceAcesso
                'objTrace.Insert(objSchema)

            End If

        Catch ex As Exception

        End Try

    End Sub

End Class