Public Class frmSolicitacoesChave
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim sPageName As String = Request.FilePath.Substring(1, Request.FilePath.Length - 6)
        If Common.Configuracao.getManutencao() Then
            Response.Redirect("Manutencao.aspx")
        End If

        If Not IsPostBack Then
            Session("objSolicitacaoChaveAcesso") = Nothing

            'Verifica autorização de acesso a página
            If Session("objCAT") Is Nothing Then
                Response.Redirect("Login.aspx")
            Else
                Dim objSchCAT = Session("objCAT")
                Dim objCAT As New BLL.bllCAT

                If Not objCAT.ValidaPermissao(objSchCAT, sPageName, "A") Then
                    Response.Redirect("frmAcessoNegado.aspx")
                End If
            End If

            If Not Session("oSchDadosFiltro") Is Nothing Then
                Dim oSchDadosFiltro As ShL.schDadosFiltro = Session("oSchDadosFiltro")
                txtDataIni.Text = IIf(oSchDadosFiltro.dt_inicial = Nothing, "", oSchDadosFiltro.dt_inicial.ToString(System.Globalization.CultureInfo.CreateSpecificCulture("pt-BR")).Substring(0, 10))
                txtDataFim.Text = IIf(oSchDadosFiltro.dt_final = Nothing, "", oSchDadosFiltro.dt_final.ToString(System.Globalization.CultureInfo.CreateSpecificCulture("pt-BR")).Substring(0, 10))
                cmbStatus.SelectedValue = oSchDadosFiltro.cd_status
            End If

            btBusca_Click(sender, e)
        End If
    End Sub

    Protected Sub btVoltar_Click(sender As Object, e As EventArgs) Handles btVoltar.Click
        Response.Redirect("Login.aspx")
    End Sub

    Protected Sub btBusca_Click(sender As Object, e As EventArgs) Handles btBusca.Click
        Try
            grdSolicitacoes.PageIndex = 0
            BindGrid()
        Catch ex As Exception
            If ex.Message.StartsWith("W:") Then
                ExibeMensagemPopUp("Info", ex.Message.Replace("W:", ""))
            Else
                ExibeMensagemPopUp("Mensagem de Erro", "Aconteceu um erro inesperado!" + Chr(13) + ex.Message)
            End If

        End Try

    End Sub

    Private Sub grdSolicitacoes_DataBinding(sender As Object, e As System.EventArgs) Handles grdSolicitacoes.DataBinding

    End Sub

    Private Sub grdSolicitacoes_PageIndexChanging(sender As Object, e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdSolicitacoes.PageIndexChanging
        grdSolicitacoes.PageIndex = e.NewPageIndex
        BindGrid()
    End Sub

    Private Sub BindGrid()
        Dim objSolicitacaoChaveAcesso As New BLL.bllSolicitacaoChaveAcesso
        Dim oDataTable As Data.DataTable
        Dim oSchDadosFiltro As New ShL.schDadosFiltro

        oSchDadosFiltro = GetFiltro()

        oDataTable = objSolicitacaoChaveAcesso.getSolicitacaoChaveAcesso_ByFiltro(oSchDadosFiltro)
        If Not oDataTable Is Nothing Then
            lblQtdRegistros.Text = "Qtd. Registros: " & oDataTable.Rows.Count.ToString
            lblQtdRegistros.Visible = True
        Else
            lblQtdRegistros.Visible = False
        End If
        grdSolicitacoes.DataSource = oDataTable
        grdSolicitacoes.DataBind()

        Session("oSchDadosFiltro") = oSchDadosFiltro
    End Sub

    Private Function GetFiltro() As ShL.schDadosFiltro
        Dim oSchDadosFiltro As New ShL.schDadosFiltro

        Try
            Dim oDataIni As DateTime = Convert.ToDateTime(txtDataIni.Text, System.Globalization.CultureInfo.CreateSpecificCulture("pt-BR"))
            Dim oDataFim As DateTime = Convert.ToDateTime(txtDataFim.Text, System.Globalization.CultureInfo.CreateSpecificCulture("pt-BR"))
            oSchDadosFiltro.dt_inicial = oDataIni
            oSchDadosFiltro.dt_final = oDataFim
        Catch ex As Exception
            oSchDadosFiltro.dt_inicial = Nothing
            oSchDadosFiltro.dt_final = Nothing
        End Try

        oSchDadosFiltro.cd_status = cmbStatus.SelectedValue

        Return oSchDadosFiltro

    End Function

    Protected Sub cmbStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbStatus.SelectedIndexChanged
        btBusca_Click(sender, e)
    End Sub

    Private Sub grdSolicitacoes_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdSolicitacoes.RowCommand
        If e.CommandName = "Detalhar" Then
            Dim iID As Int32 = 0
            iID = grdSolicitacoes.Rows(Convert.ToInt16(e.CommandArgument)).Cells(0).Text

            Dim oSolicitacaoChaveAcesso As New BLL.bllSolicitacaoChaveAcesso
            Dim objSchSolicitacaoChaveAcesso As ShL.schSolicitacaoChaveAcesso
            objSchSolicitacaoChaveAcesso = oSolicitacaoChaveAcesso.getSolicitacaoChaveAcessoByPK(iID)

            Session("objSolicitacaoChaveAcesso") = objSchSolicitacaoChaveAcesso
            Response.Redirect("frmDetalheSolicitacaoChaveAcesso.aspx")

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