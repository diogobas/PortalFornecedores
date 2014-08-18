Imports System.Data.SqlClient
Imports System.Web.UI.WebControls
Imports System.Net.Mail
Imports System.Data

Public Class bllSolicitacaoChaveAcesso : Inherits bllBase

#Region "Construtores"

    Sub New()
        MyBase.New()
        Me.objData = New DAL.dalSolicitacaoChaveAcesso()
    End Sub

    Sub New(ByRef objSchema As ShL.schSolicitacaoChaveAcesso)
        Me.New()
        Me.objData.objSchemaBase = objSchema
    End Sub
#End Region

#Region "objData"
    Property objData() As DAL.dalSolicitacaoChaveAcesso
        Get
            Return _objData
        End Get
        Set(ByVal value As DAL.dalSolicitacaoChaveAcesso)
            _objData = value
        End Set
    End Property
#End Region

#Region "Delete"
    Public Overrides Function Delete(ByVal key As System.Web.UI.WebControls.DataKey) As Boolean

    End Function

    Public Overloads Function Delete(ByVal key As Integer) As Boolean
        Dim objFunc As New DAL.dalSolicitacaoChaveAcesso
        Return objFunc.Delete(key)
    End Function
#End Region

#Region "getSumario"
    Public Function getSumario() As DataTable
        Dim objSolic As New DAL.dalSolicitacaoChaveAcesso()
        Return objSolic.getSumario()
    End Function
#End Region

#Region "getSolicitacaoChaveAcesso_ByFiltro"
    Public Function getSolicitacaoChaveAcesso_ByFiltro(ByVal oFiltro As ShL.schDadosFiltro) As DataTable
        Dim objSolicitacaoChaveAcesso As New DAL.dalSolicitacaoChaveAcesso()
        Return objSolicitacaoChaveAcesso.getSolicitacaoChaveAcesso_ByFiltro(oFiltro)
    End Function
#End Region

#Region "Insert"
    Public Function Insert(ByRef objSchema As ShL.schSolicitacaoChaveAcesso) As Boolean

        Dim objSTL As STL.STLBase = New STL.STLBase()
        Dim objCont As DAL.dalSolicitacaoChaveAcesso = Nothing

        objSTL.BeginTransaction()
        objCont = New DAL.dalSolicitacaoChaveAcesso(objSTL)
        objCont.objSchema = objSchema
        Try
            objCont.Insert()

            objSTL.Commit()
        Catch ex As SqlException
            objSTL.RollBack()
            Throw ex
        Catch ex As Exception
            objSTL.RollBack()
            Throw ex
        Finally
            objSTL.Dispose()
            objCont.Dispose()
        End Try

        Return True
    End Function
#End Region

#Region "ValidaSolicitacaoChaveAcesso"
    Public Function ValidaSolicitacaoChaveAcesso(ByRef objSchema As ShL.schSolicitacaoChaveAcesso) As Boolean

        Dim objSTL As STL.STLBase = New STL.STLBase()
        Dim objCont As DAL.dalSolicitacaoChaveAcesso = Nothing

        objSTL.BeginTransaction()
        objCont = New DAL.dalSolicitacaoChaveAcesso(objSTL)
        objCont.objSchema = objSchema
        Try
            objCont.ValidaSolicitacaoChaveAcesso()

            objSTL.Commit()
        Catch ex As SqlException
            objSTL.RollBack()
            Throw ex
        Catch ex As Exception
            objSTL.RollBack()
            Throw ex
        Finally
            objSTL.Dispose()
            objCont.Dispose()
        End Try

        Return True
    End Function
#End Region



#Region "EnviaEmailAnalise"
    Public Function EnviaEmailAnalise(ByRef objSchema As ShL.schSolicitacaoChaveAcesso) As Boolean
        Dim objSTL As STL.STLBase = New STL.STLBase()
        Dim objCont As DAL.dalSolicitacaoChaveAcesso = Nothing
        Dim sSMTPeMail As String = ""
        Dim sNomeDestinatario As String = ""
        Dim seMailDestinatario As String = ""
        Dim seMailRemetente As String = ""
        Dim sNomeRemetente As String = ""
        Dim sAssuntoEmail As String = ""
        Dim sNBSP As String = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"

        EnviaEmailAnalise = True
        Try
            Try
                Dim oSchConfiguracao As ShL.schConfiguracao = BLL.bllConfiguracao.getConfiguracao
                If Not oSchConfiguracao.xx_envia_email_solicitacao_chave Then
                    Exit Function
                End If

                sSMTPeMail = oSchConfiguracao.xx_servidor_smtp
                seMailDestinatario = oSchConfiguracao.xx_email_destinatario_eventos
                sNomeDestinatario = oSchConfiguracao.xx_email_destinatario_eventos
                seMailRemetente = oSchConfiguracao.xx_email_remetente
                sNomeRemetente = oSchConfiguracao.xx_nome_remetente
                sAssuntoEmail = "Portal de Fornecedores (Chave de Acesso)"

            Catch ex As Exception
                Dim erro As New Exception("Falha ao obter configurações de email.")
            End Try

            Dim sEmailDest As String = seMailDestinatario
            Dim Mensagem As MailMessage = New MailMessage()
            Dim Mailmsg As New System.Net.Mail.MailMessage()
            Dim mSmtpCliente As New SmtpClient(sSMTPeMail)

            Mailmsg.From = New MailAddress(seMailRemetente, sNomeRemetente)

            Mailmsg.Subject = sAssuntoEmail & " - " & objSchema.no_razao_social
            Mailmsg.BodyEncoding = System.Text.Encoding.UTF8
            Mailmsg.IsBodyHtml = True

            Mailmsg.Body = "<HTML>"
            Mailmsg.Body += "<p><span style='font-size:10.0pt;line-height:115%;font-family:""Verdana"",""sans-serif""'>"
            Mailmsg.Body += "Uma nova solicitação de chave de acesso foi realizada através do Portal de Fornecedores.<BR \>"
            Mailmsg.Body += "Seguem abaixo os dados para análise.<BR \>"
            Mailmsg.Body += "</p>"

            Mailmsg.Body += "<p><span style='font-size:10.0pt;line-height:115%;font-family:""Verdana"",""sans-serif""'>"
            Mailmsg.Body += "<B><U>Dados da Solicitação</U></B><BR \>"
            Mailmsg.Body += "</p>"
            Mailmsg.Body += "<p><span style='font-size:10.0pt;line-height:115%;font-family:""Verdana"",""sans-serif""'>"
            Mailmsg.Body += sNBSP & "CNPJ: <B>" & Convert.ToInt64(objSchema.nm_cnpj).ToString("00\.000\.000\/0000\-00") & "</B><BR \>"
            Mailmsg.Body += sNBSP & "Razão Social: <B>" & objSchema.no_razao_social & "</B><BR \>"
            Mailmsg.Body += sNBSP & "Nome do solicitante: <B>" & objSchema.no_solicitante & "</B><BR \>"
            Mailmsg.Body += sNBSP & "Email do Solicitante: <B>" & objSchema.xx_email & "</B><BR \>"
            Mailmsg.Body += "</P>"

            Mailmsg.Body += "<P><span style='font-size:10.0pt;line-height:115%;font-family:""Verdana"",""sans-serif""'>"
            Mailmsg.Body += "Portal de Fornecedores Duratex <BR />"
            Mailmsg.Body += "<A href=http://www.duratex.com.br>www.duratex.com.br</a>"
            Mailmsg.Body += "</P>"

            Mailmsg.Body += "</HTML>"

            Mailmsg.To.Add(New MailAddress(seMailDestinatario, sNomeDestinatario))

            Mailmsg.Attachments.Clear()

            Try
                mSmtpCliente.Send(Mailmsg)
            Catch ex As Exception
                EnviaEmailAnalise = False
                Dim erro As New Exception("Houve um problema ao enviar seu email. Tente Novamente.")
                Throw erro
            End Try
            Mailmsg.Attachments.Dispose()
            Mailmsg.Dispose()

        Catch ex As Exception
            EnviaEmailAnalise = False
            Dim erro As New Exception("Houve um problema ao enviar seu email. Tente Novamente.")
            Throw erro
        End Try
    End Function
#End Region

#Region "EnviaEmailRetorno"
    Public Function EnviaEmailRetorno(ByRef objSchema As ShL.schSolicitacaoChaveAcesso) As Boolean
        Dim objSTL As STL.STLBase = New STL.STLBase()
        Dim objCont As DAL.dalSolicitacaoChaveAcesso = Nothing
        Dim sSMTPeMail As String = ""
        Dim sNomeDestinatario As String = ""
        Dim seMailDestinatario As String = ""
        Dim seMailRemetente As String = ""
        Dim sNomeRemetente As String = ""
        Dim sAssuntoEmail As String = ""
        Dim sNBSP As String = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"

        EnviaEmailRetorno = True
        Try
            Try
                Dim oSchConfiguracao As ShL.schConfiguracao = BLL.bllConfiguracao.getConfiguracao
                If Not oSchConfiguracao.xx_envia_email_retorno_solicitacao_chave Then
                    Exit Function
                End If

                sSMTPeMail = oSchConfiguracao.xx_servidor_smtp
                seMailDestinatario = objSchema.xx_email
                sNomeDestinatario = objSchema.no_solicitante
                seMailRemetente = oSchConfiguracao.xx_email_remetente
                sNomeRemetente = oSchConfiguracao.xx_nome_remetente
                sAssuntoEmail = "Portal de Fornecedores Duratex"

            Catch ex As Exception
                Dim erro As New Exception("Falha ao obter configurações de email.")
            End Try

            Dim sEmailDest As String = seMailDestinatario
            Dim Mensagem As MailMessage = New MailMessage()
            Dim Mailmsg As New System.Net.Mail.MailMessage()
            Dim mSmtpCliente As New SmtpClient(sSMTPeMail)

            Mailmsg.From = New MailAddress(seMailRemetente, sNomeRemetente)

            Mailmsg.Subject = sAssuntoEmail
            Mailmsg.BodyEncoding = System.Text.Encoding.UTF8
            Mailmsg.IsBodyHtml = True

            Mailmsg.Body = "<HTML>"
            Mailmsg.Body += "<P><span style='font-size:10.0pt;line-height:115%;font-family:""Verdana"",""sans-serif""'>"
            Mailmsg.Body += "Prezado(a) <B>" & objSchema.no_solicitante & "</B>, <BR \>"
            Mailmsg.Body += "</P>"

            Mailmsg.Body += "<p><span style='font-size:10.0pt;line-height:115%;font-family:""Verdana"",""sans-serif""'>"
            Mailmsg.Body += sNBSP & "Sua solicitação de chave de acesso foi registrada no Portal de Fornecedores Duratex.<BR \>"
            Mailmsg.Body += sNBSP & "Um email com sua Chave de Acesso será enviado após análise de nossa equipe interna.<BR \>"
            Mailmsg.Body += "</P>"

            Mailmsg.Body += "<P><span style='font-size:10.0pt;line-height:115%;font-family:""Verdana"",""sans-serif""'>"
            Mailmsg.Body += "Portal de Fornecedores Duratex <BR />"
            Mailmsg.Body += "<A href=http://www.duratex.com.br>www.duratex.com.br</a>"
            Mailmsg.Body += "</P>"


            Mailmsg.Body += "</HTML>"

            Mailmsg.To.Add(New MailAddress(seMailDestinatario, sNomeDestinatario))

            Mailmsg.Attachments.Clear()

            Try
                mSmtpCliente.Send(Mailmsg)
            Catch ex As Exception
                EnviaEmailRetorno = False
                Dim erro As New Exception("Houve um problema ao enviar seu email. Tente Novamente.")
                Throw erro
            End Try
            Mailmsg.Attachments.Dispose()
            Mailmsg.Dispose()

        Catch ex As Exception
            EnviaEmailRetorno = False
            Dim erro As New Exception("Houve um problema ao enviar seu email. Tente Novamente.")
            Throw erro
        End Try
    End Function

#End Region

#Region "EnviaEmailRetorno"
    Public Function EnviaEmailValidacao(ByRef objSchema As ShL.schSolicitacaoChaveAcesso) As Boolean
        Dim objSTL As STL.STLBase = New STL.STLBase()
        Dim objCont As DAL.dalSolicitacaoChaveAcesso = Nothing
        Dim sSMTPeMail As String = ""
        Dim sNomeDestinatario As String = ""
        Dim seMailDestinatario As String = ""
        Dim seMailRemetente As String = ""
        Dim sNomeRemetente As String = ""
        Dim sAssuntoEmail As String = ""
        Dim sNBSP As String = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"

        EnviaEmailValidacao = True
        Try
            Try
                Dim oSchConfiguracao As ShL.schConfiguracao = BLL.bllConfiguracao.getConfiguracao
                If Not oSchConfiguracao.xx_envia_email_retorno_solicitacao_chave Then
                    Exit Function
                End If

                sSMTPeMail = oSchConfiguracao.xx_servidor_smtp
                seMailDestinatario = objSchema.xx_email
                sNomeDestinatario = objSchema.no_solicitante
                seMailRemetente = oSchConfiguracao.xx_email_remetente
                sNomeRemetente = oSchConfiguracao.xx_nome_remetente
                sAssuntoEmail = "Portal de Fornecedores Duratex"

            Catch ex As Exception
                Dim erro As New Exception("Falha ao obter configurações de email.")
            End Try

            Dim sEmailDest As String = seMailDestinatario
            Dim Mensagem As MailMessage = New MailMessage()
            Dim Mailmsg As New System.Net.Mail.MailMessage()
            Dim mSmtpCliente As New SmtpClient(sSMTPeMail)

            Mailmsg.From = New MailAddress(seMailRemetente, sNomeRemetente)

            Mailmsg.Subject = sAssuntoEmail
            Mailmsg.BodyEncoding = System.Text.Encoding.UTF8
            Mailmsg.IsBodyHtml = True

            Mailmsg.Body = "<HTML>"
            Mailmsg.Body += "<P><span style='font-size:10.0pt;line-height:115%;font-family:""Verdana"",""sans-serif""'>"
            Mailmsg.Body += "Prezado(a) <B>" & objSchema.no_solicitante & "</B>, <BR \>"
            Mailmsg.Body += "</P>"

            Mailmsg.Body += "<p><span style='font-size:10.0pt;line-height:115%;font-family:""Verdana"",""sans-serif""'>"
            Mailmsg.Body += sNBSP & "Sua solicitação de chave de acesso foi validada por nossa equipe.<BR \>"
            Mailmsg.Body += sNBSP & "Segue os dados para acesso ao Portal de Fornecedores Duratex:<BR \>"
            Mailmsg.Body += sNBSP & "CNPJ: <B>" & Convert.ToInt64(objSchema.nm_cnpj).ToString("00\.000\.000\/0000\-00") & "</B><BR \>"
            Mailmsg.Body += sNBSP & "Chave de Acesso: <B>" & objSchema.xx_chave_acesso & "</B><BR \>"

            Mailmsg.Body += "</P>"

            Mailmsg.Body += "<P><span style='font-size:10.0pt;line-height:115%;font-family:""Verdana"",""sans-serif""'>"
            Mailmsg.Body += "Portal de Fornecedores Duratex <BR />"
            Mailmsg.Body += "<A href=http://www.duratex.com.br>www.duratex.com.br</a>"
            Mailmsg.Body += "</P>"


            Mailmsg.Body += "</HTML>"

            Mailmsg.To.Add(New MailAddress(seMailDestinatario, sNomeDestinatario))

            Mailmsg.Attachments.Clear()

            Try
                mSmtpCliente.Send(Mailmsg)
            Catch ex As Exception
                EnviaEmailValidacao = False
                Dim erro As New Exception("Houve um problema ao enviar seu email. Tente Novamente.")
                Throw erro
            End Try
            Mailmsg.Attachments.Dispose()
            Mailmsg.Dispose()

        Catch ex As Exception
            EnviaEmailValidacao = False
            Dim erro As New Exception("Houve um problema ao enviar seu email. Tente Novamente.")
            Throw erro
        End Try
    End Function

#End Region


#Region "Update"
    Public Function Update(ByRef objSchema As ShL.schSolicitacaoChaveAcesso) As Boolean

    End Function
#End Region

#Region "getContatoByPk"
    'Public Function getContatoByPk(ByVal Funcionario_ID As Integer) As DataTable
    '    Dim objFunc As New DAL.dalContato()
    '    Return objFunc.getContatoByPk(Funcionario_ID)
    'End Function
#End Region

#Region "getSolicitacaoChaveAcessoByCNPJ"
    Public Function getSolicitacaoChaveAcessoByCNPJ(ByVal CNPJ As String) As ShL.schSolicitacaoChaveAcesso
        Dim objSchema As New ShL.schSolicitacaoChaveAcesso
        Dim objSolic As New DAL.dalSolicitacaoChaveAcesso
        Dim oDataTable As DataTable

        oDataTable = objSolic.getSolicitacaoChaveAcessoByCNPJ(CNPJ)
        CarregaSchemaFromDataTable(objSchema, oDataTable)

        Me.objData.objSchemaBase = objSchema

        Return objSchema
    End Function
#End Region

#Region "getSolicitacaoChaveAcessoByPK"
    Public Function getSolicitacaoChaveAcessoByPK(ByVal ID As Int16) As ShL.schSolicitacaoChaveAcesso
        Dim objSchema As New ShL.schSolicitacaoChaveAcesso
        Dim objSolic As New DAL.dalSolicitacaoChaveAcesso
        Dim oDataTable As DataTable

        oDataTable = objSolic.getSolicitacaoChaveAcessoByPK(ID)
        CarregaSchemaFromDataTable(objSchema, oDataTable)

        Me.objData.objSchemaBase = objSchema

        Return objSchema
    End Function
#End Region

    Private Sub CarregaSchemaFromDataTable(ByRef objSchema As ShL.schSolicitacaoChaveAcesso, oDataTable As Data.DataTable)
        If oDataTable Is Nothing Then
            Exit Sub
        End If
        objSchema.id_solicitacao_chave_acesso = IIf(Not oDataTable.Rows(0).Item("id_solicitacao_chave_acesso") Is DBNull.Value, oDataTable.Rows(0).Item("id_solicitacao_chave_acesso"), Nothing)
        objSchema.nm_cnpj = IIf(Not oDataTable.Rows(0).Item("nm_cnpj") Is DBNull.Value, oDataTable.Rows(0).Item("nm_cnpj"), Nothing)
        objSchema.no_solicitante = IIf(Not oDataTable.Rows(0).Item("no_solicitante") Is DBNull.Value, oDataTable.Rows(0).Item("no_solicitante"), Nothing)
        objSchema.xx_email = IIf(Not oDataTable.Rows(0).Item("xx_email") Is DBNull.Value, oDataTable.Rows(0).Item("xx_email"), Nothing)
        objSchema.no_razao_social = IIf(Not oDataTable.Rows(0).Item("no_razao_social") Is DBNull.Value, oDataTable.Rows(0).Item("no_razao_social"), Nothing)
        objSchema.dt_solicitacao = IIf(Not oDataTable.Rows(0).Item("dt_solicitacao") Is DBNull.Value, oDataTable.Rows(0).Item("dt_solicitacao"), Nothing)
        objSchema.objStatus.cd_status = IIf(Not oDataTable.Rows(0).Item("cd_status_solicitacao_chave") Is DBNull.Value, oDataTable.Rows(0).Item("cd_status_solicitacao_chave"), Nothing)
        objSchema.objStatus.dc_status = IIf(Not oDataTable.Rows(0).Item("dc_status") Is DBNull.Value, oDataTable.Rows(0).Item("dc_status"), Nothing)
        objSchema.dt_atualizacao = IIf(Not oDataTable.Rows(0).Item("dt_atualizacao") Is DBNull.Value, oDataTable.Rows(0).Item("dt_atualizacao"), Nothing)
        objSchema.cd_usuario_atualizacao = IIf(Not oDataTable.Rows(0).Item("cd_usuario_atualizacao") Is DBNull.Value, oDataTable.Rows(0).Item("cd_usuario_atualizacao"), Nothing)
    End Sub

End Class
