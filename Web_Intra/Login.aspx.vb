Public Class Login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Common.Configuracao.getManutencao() Then
            Response.Redirect("Manutencao.aspx")
        End If

        If Not IsPostBack Then
            Session("objSolicitacao") = Nothing
            Session("oSchDadosFiltro") = Nothing

            If Session("objCAT") Is Nothing Then
                Dim sUsuario As String

                If Not Request.Params("HTTP_REFERER") Is Nothing AndAlso Request.Params("HTTP_REFERER").Contains("duratex.com.br") Then
                    sUsuario = Request.Form("Usuario")
                ElseIf Not Request.Params("HTTP_REFERER") Is Nothing AndAlso Request.Params("HTTP_REFERER").Contains("www.sistemas.intranet") Then
                    sUsuario = Request.QueryString("Usuario")
                Else
                    sUsuario = Replace(Request.ServerVariables("LOGON_USER"), "DTX\", "")
                End If

                If sUsuario <> "" Then
                    Dim objSchCAT As New ShL.schCAT
                    Dim objCAT As New BLL.bllCAT
                    Try
                        objSchCAT.sUsuario = sUsuario
                        objSchCAT.sSistema = "PFD"
                        Session("sUsuario") = sUsuario
                        If objCAT.ValidaUsuario(objSchCAT) Then
                            Session("objCAT") = objSchCAT
                        Else
                            Response.Redirect("./HomeAnonymous.aspx")
                        End If
                    Catch ex As Exception
                        If ex.Message.StartsWith("W:") Then
                            ExibeMensagemPopUp("Info", ex.Message.Replace("W:", ""))
                        Else
                            ExibeMensagemPopUp("Mensagem de Erro", "Aconteceu um erro inesperado!" + Chr(13) + ex.Message)
                        End If
                    End Try
                Else
                    Response.Redirect("http://www.sistemas.intranet?exp=2")
                End If
            End If

            PrencheSumario()
        End If

    End Sub

    Private Sub PrencheSumario()
        Dim oDataTable As Data.DataTable

        ' Solicitações de Cadastro 
        oDataTable = (New BLL.bllSolicitacaoCadastro).getSumario
        If Not oDataTable Is Nothing Then
            For Each oRow As Data.DataRow In oDataTable.Rows
                If oRow.Item("cd_status") = 0 Then
                    lblQtdSolicCadPendentes.Text = oRow.Item("qt_solicitacoes")
                Else
                    If oRow.Item("cd_status") = 1 Then
                        lblQtdSolicCadValidadas.Text = oRow.Item("qt_solicitacoes")
                    End If
                End If
            Next
        End If

        ' Solicitações de Alteração 
        oDataTable = (New BLL.bllSolicitacaoAlteracao).getSumario
        If Not oDataTable Is Nothing Then
            For Each oRow As Data.DataRow In oDataTable.Rows
                If oRow.Item("cd_status") = 0 Then
                    lblQtdSolicAltPendentes.Text = oRow.Item("qt_solicitacoes")
                Else
                    If oRow.Item("cd_status") = 1 Then
                        lblQtdSolicAltValidadas.Text = oRow.Item("qt_solicitacoes")
                    End If
                End If
            Next
        End If

        ' Solicitações de Chave de Acesso 
        oDataTable = (New BLL.bllSolicitacaoChaveAcesso).getSumario
        If Not oDataTable Is Nothing Then
            For Each oRow As Data.DataRow In oDataTable.Rows
                If oRow.Item("cd_status") = 0 Then
                    lblQtdSolicChavePendentes.Text = oRow.Item("qt_solicitacoes")
                Else
                    If oRow.Item("cd_status") = 1 Then
                        lblQtdSolicChaveValidadas.Text = oRow.Item("qt_solicitacoes")
                    End If
                End If
            Next
        End If


    End Sub
    Private Sub ExibeMensagemPopUp(sTitulo As String, sMensagem As String)
        sMensagem = sMensagem.Replace(vbCrLf, "<BR>")
        sMensagem = sMensagem.Replace(Chr(13), "<BR>")
        sMensagem = sMensagem.Replace("'", "")
        sMensagem = sMensagem.Replace(";", "-")
        Dim sJavaScript As String = "javascript:exibeMessagepopUp('" + sTitulo + "','" + sMensagem + "');"
        Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyScript", sJavaScript, True)
    End Sub

    Private Sub ExibeMensagemPopUp(sTitulo As String, sMensagem As String, sNomeAcaoASP As String)
        sMensagem = sMensagem.Replace(vbCrLf, "<BR>")
        sMensagem = sMensagem.Replace(Chr(13), "<BR>")
        sMensagem = sMensagem.Replace("'", "")
        sMensagem = sMensagem.Replace(";", "-")
        Dim sJavaScript As String = "javascript:exibeMessagepopUp('" + sTitulo + "','" + sMensagem + "', null, null, '" + sNomeAcaoASP + "');"
        Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyScript", sJavaScript, True)
    End Sub


    Private Sub ExibeMensagemPopUp(sTitulo As String, sMensagem As String, sNomeAcao As String, sAcao As String, sNomeAcaoASP As String)
        sMensagem = sMensagem.Replace(Chr(13), "<BR>")
        Dim sJavaScript As String = "javascript:exibeMessagepopUp('" + sTitulo + "','" + sMensagem + "','" + sNomeAcao + "','" + sAcao + "', true, '" + sNomeAcaoASP + "');"
        Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyScript", sJavaScript, True)
    End Sub

    Private Sub ExibeMensagemPopUp(sTitulo As String, sMensagem As String, sNomeAcao As String, sAcao As String)
        sMensagem = sMensagem.Replace(Chr(13), "<BR>")
        Dim sJavaScript As String = "javascript:exibeMessagepopUp('" + sTitulo + "','" + sMensagem + "','" + sNomeAcao + "','" + sAcao + "');"
        Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyScript", sJavaScript, True)
    End Sub



End Class