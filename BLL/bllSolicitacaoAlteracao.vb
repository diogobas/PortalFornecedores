Imports System.Data.SqlClient
Imports System.Web.UI.WebControls
Imports System.Net.Mail
Imports System.Data

Public Class bllSolicitacaoAlteracao : Inherits bllBase

#Region "Construtores"

    Sub New()
        MyBase.New()
        Me.objData = New DAL.dalSolicitacaoAlteracao()
    End Sub

    Sub New(ByRef objSchema As ShL.schSolicitacaoAlteracao)
        Me.New()
        Me.objData.objSchemaBase = objSchema
    End Sub
#End Region

#Region "objData"
    Property objData() As DAL.dalSolicitacaoAlteracao
        Get
            Return _objData
        End Get
        Set(ByVal value As DAL.dalSolicitacaoAlteracao)
            _objData = value
        End Set
    End Property
#End Region

#Region "Delete"
    Public Overrides Function Delete(ByVal key As System.Web.UI.WebControls.DataKey) As Boolean

    End Function

    Public Overloads Function Delete(ByVal key As Integer) As Boolean
        Dim objFunc As New DAL.dalSolicitacaoAlteracao
        Return objFunc.Delete(key)
    End Function
#End Region

#Region "getSumario"
    Public Function getSumario() As DataTable
        Dim objSolic As New DAL.dalSolicitacaoAlteracao()
        Return objSolic.getSumario()
    End Function
#End Region


#Region "getSolicitacaoAlteracao_ByFiltro"
    Public Function getSolicitacaoAlteracao_ByFiltro(ByVal oFiltro As ShL.schDadosFiltro) As DataTable
        Dim objSolicitacaoAlteracao As New DAL.dalSolicitacaoAlteracao()
        Return objSolicitacaoAlteracao.getSolicitacaoAlteracao_ByFiltro(oFiltro)
    End Function
#End Region

#Region "Insert"
    Public Function Insert(ByRef objSchema As ShL.schSolicitacaoAlteracao) As Boolean

        Dim objSTL As STL.STLBase = New STL.STLBase()
        Dim objCont As DAL.dalSolicitacaoAlteracao = Nothing

        objSTL.BeginTransaction()
        objCont = New DAL.dalSolicitacaoAlteracao(objSTL)
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

#Region "ValidaSolicitacaoAlteracao"
    Public Function ValidaSolicitacaoAlteracao(ByRef objSchema As ShL.schSolicitacaoAlteracao) As Boolean

        Dim objSTL As STL.STLBase = New STL.STLBase()
        Dim objCont As DAL.dalSolicitacaoAlteracao = Nothing

        objSTL.BeginTransaction()
        objCont = New DAL.dalSolicitacaoAlteracao(objSTL)
        objCont.objSchema = objSchema
        Try
            objCont.ValidaSolicitacaoAlteracao()

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
    Public Function EnviaEmailAnalise(ByRef objSchema As ShL.schSolicitacaoAlteracao) As Boolean
        Dim objSTL As STL.STLBase = New STL.STLBase()
        Dim objCont As DAL.dalSolicitacaoAlteracao = Nothing
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
                If Not oSchConfiguracao.xx_envia_email_solicitacao_alteracao Then
                    Exit Function
                End If

                sSMTPeMail = oSchConfiguracao.xx_servidor_smtp
                seMailDestinatario = oSchConfiguracao.xx_email_destinatario_eventos
                sNomeDestinatario = oSchConfiguracao.xx_email_destinatario_eventos
                seMailRemetente = oSchConfiguracao.xx_email_remetente
                sNomeRemetente = oSchConfiguracao.xx_nome_remetente
                sAssuntoEmail = "Portal de Fornecedores (Alteração)"

            Catch ex As Exception
                Dim erro As New Exception("Falha ao obter configurações de email.")
            End Try

            Dim sEmailDest As String = seMailDestinatario
            Dim Mensagem As MailMessage = New MailMessage()
            Dim Mailmsg As New System.Net.Mail.MailMessage()
            Dim mSmtpCliente As New SmtpClient(sSMTPeMail)

            Mailmsg.From = New MailAddress(seMailRemetente, sNomeRemetente)

            Mailmsg.Subject = sAssuntoEmail & " - " & objSchema.objDadosBasicos.no_razao_social
            Mailmsg.BodyEncoding = System.Text.Encoding.UTF8
            Mailmsg.IsBodyHtml = True

            Mailmsg.Body = "<HTML>"
            Mailmsg.Body += "<p><span style='font-size:10.0pt;line-height:115%;font-family:""Verdana"",""sans-serif""'>"
            Mailmsg.Body += "Uma nova solicitação de alteração de dados foi realizada através do Portal de Fornecedores.<BR \>"
            Mailmsg.Body += "Seguem abaixo os dados para análise.<BR \>"
            Mailmsg.Body += "</p>"

            Mailmsg.Body += "<p><span style='font-size:10.0pt;line-height:115%;font-family:""Verdana"",""sans-serif""'>"
            Mailmsg.Body += "<B><U>Dados Básicos do Fornecedor</U></B><BR \>"
            Mailmsg.Body += "</p>"
            Mailmsg.Body += "<p><span style='font-size:10.0pt;line-height:115%;font-family:""Verdana"",""sans-serif""'>"
            Mailmsg.Body += sNBSP & "CNPJ: <B>" & Convert.ToInt64(objSchema.objDadosBasicos.nm_CNPJ).ToString("00\.000\.000\/0000\-00") & "</B><BR \>"
            Mailmsg.Body += sNBSP & "Razão Social: <B>" & objSchema.objDadosBasicos.no_razao_social & "</B><BR \>"
            Mailmsg.Body += sNBSP & "Enredeço: <B>" & objSchema.objDadosBasicos.no_rua & ", " & objSchema.objDadosBasicos.nm_numero & " - " & objSchema.objDadosBasicos.no_bairro & "</B><BR \>"
            Mailmsg.Body += sNBSP & "Cidade: <B>" & objSchema.objDadosBasicos.no_cidade & " - " & objSchema.objDadosBasicos.sg_estado & " </B> / Pais: <B>" & objSchema.objDadosBasicos.cd_pais & "</B><BR \>"
            Mailmsg.Body += sNBSP & "CEP: <B>" & objSchema.objDadosBasicos.nm_CEP & " </B> / Caixa Postal: <B>" & objSchema.objDadosBasicos.nm_caixa_postal & "</B><BR \>"
            Mailmsg.Body += "</P>"

            Mailmsg.Body += "<p><span style='font-size:10.0pt;line-height:115%;font-family:""Verdana"",""sans-serif""'>"
            Mailmsg.Body += "<B><U>Dados de Contato</U></B><BR/>"
            Mailmsg.Body += "</P>"
            Mailmsg.Body += "<p><span style='font-size:10.0pt;line-height:115%;font-family:""Verdana"",""sans-serif""'>"
            Mailmsg.Body += sNBSP & "Nome: <B>" & objSchema.objContato.no_nome & " " & objSchema.objContato.no_sobrenome & "</B><BR \>"
            Mailmsg.Body += sNBSP & "Função: <B>" & objSchema.objContato.no_funcao & " </B> / Departamento: <B>" & objSchema.objContato.no_departamento & "</B><BR \>"
            Mailmsg.Body += sNBSP & "Telefone: <B>" & objSchema.objContato.nm_telefone & "</B> / Fax: <B>" & objSchema.objContato.nm_fax & "</B><BR \>"
            Mailmsg.Body += sNBSP & "Celular: <B>" & objSchema.objContato.nm_celular & "</B> / Email: <B>" & objSchema.objContato.xx_email & "</B><BR \>"
            Mailmsg.Body += "</P>"

            Mailmsg.Body += "<p><span style='font-size:10.0pt;line-height:115%;font-family:""Verdana"",""sans-serif""'>"
            Mailmsg.Body += "<B><U>Dados Adicionais</U></B><BR/>"
            Mailmsg.Body += "</P>"
            Mailmsg.Body += "<p><span style='font-size:10.0pt;line-height:115%;font-family:""Verdana"",""sans-serif""'>"
            Mailmsg.Body += sNBSP & "Serviços: <B>" & objSchema.objDadosAdicionais.dc_servicos.Replace(vbCrLf, "<BR>" & sNBSP & sNBSP & sNBSP & sNBSP & sNBSP) & "</B><BR \>"
            Mailmsg.Body += sNBSP & "Materiais: <B>" & objSchema.objDadosAdicionais.dc_materiais.Replace(vbCrLf, "<BR>" & sNBSP & sNBSP & sNBSP & sNBSP & sNBSP) & "</B><BR \>"
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
    Public Function EnviaEmailRetorno(ByRef objSchema As ShL.schSolicitacaoAlteracao) As Boolean
        Dim objSTL As STL.STLBase = New STL.STLBase()
        Dim objCont As DAL.dalSolicitacaoAlteracao = Nothing
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
                If Not oSchConfiguracao.xx_envia_email_retorno_solicitacao_alteracao Then
                    Exit Function
                End If

                sSMTPeMail = oSchConfiguracao.xx_servidor_smtp
                seMailDestinatario = objSchema.objContato.xx_email
                sNomeDestinatario = objSchema.objContato.no_nome & " " & objSchema.objContato.no_sobrenome
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
            Mailmsg.Body += "Prezado(a) <B>" & objSchema.objContato.no_nome & " " & objSchema.objContato.no_sobrenome & "</B>, <BR \>"
            Mailmsg.Body += "</P>"

            Mailmsg.Body += "<p><span style='font-size:10.0pt;line-height:115%;font-family:""Verdana"",""sans-serif""'>"
            Mailmsg.Body += sNBSP & "Sua solicitação de alteração foi registrada no Portal de Fornecedores Duratex.<BR \>"
            Mailmsg.Body += sNBSP & "Os dados serão analisados por nossa equipe interna.<BR \>"
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

#Region "EnviaEmailValidacao"
    Public Function EnviaEmailValidacao(ByRef objSchema As ShL.schSolicitacaoAlteracao) As Boolean
        Dim objSTL As STL.STLBase = New STL.STLBase()
        Dim objCont As DAL.dalSolicitacaoAlteracao = Nothing
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
                If Not oSchConfiguracao.xx_envia_email_retorno_solicitacao_alteracao Then
                    Exit Function
                End If

                sSMTPeMail = oSchConfiguracao.xx_servidor_smtp
                seMailDestinatario = objSchema.objContato.xx_email
                sNomeDestinatario = objSchema.objContato.no_nome & " " & objSchema.objContato.no_sobrenome
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
            Mailmsg.Body += "Prezado(a) <B>" & objSchema.objContato.no_nome & " " & objSchema.objContato.no_sobrenome & "</B>, <BR \>"
            Mailmsg.Body += "</P>"

            Mailmsg.Body += "<p><span style='font-size:10.0pt;line-height:115%;font-family:""Verdana"",""sans-serif""'>"
            Mailmsg.Body += sNBSP & "Sua solicitação de alteração de dados foi validada por nossa equipe.<BR \>"
            Mailmsg.Body += sNBSP & "Seus dados foram atualizados conforme sua solicitação.<BR \>"
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
    Public Function Update(ByRef objSchema As ShL.schSolicitacaoAlteracao) As Boolean
        Return True
    End Function
#End Region

#Region "getSolicitacaoAlteracaoByPK"
    Public Function getSolicitacaoAlteracaoByPK(ByVal ID As Integer) As ShL.schSolicitacaoAlteracao
        Dim objSchema As New ShL.schSolicitacaoAlteracao
        Dim objSolic As New DAL.dalSolicitacaoAlteracao
        Dim oDataTable As DataTable

        oDataTable = objSolic.getSolicitacaoAlteracaoByPK(ID)

        If oDataTable Is Nothing Then
            Return Nothing
        End If

        CarregaSchemaFromDataTable(objSchema, oDataTable)
        CarregaSchemaDadosBasicosFromDataTable(objSchema, oDataTable)
        CarregaSchemaContatoFromDataTable(objSchema, oDataTable)
        CarregaSchemaDadosAdicionaisFromDataTable(objSchema, oDataTable)

        Me.objData.objSchemaBase = objSchema

        Return objSchema
    End Function
#End Region

#Region "getSolicitacaoAlteracaoByCNPJ"
    Public Function getSolicitacaoAlteracaoByCNPJ(ByVal CNPJ As String) As ShL.schSolicitacaoAlteracao
        Dim objSchema As New ShL.schSolicitacaoAlteracao
        Dim objSolic As New DAL.dalSolicitacaoAlteracao
        Dim oDataTable As DataTable

        oDataTable = objSolic.getSolicitacaoAlteracaoByCNPJ(CNPJ)

        If oDataTable Is Nothing Then
            Return Nothing
        End If

        CarregaSchemaFromDataTable(objSchema, oDataTable)
        CarregaSchemaDadosBasicosFromDataTable(objSchema, oDataTable)
        CarregaSchemaContatoFromDataTable(objSchema, oDataTable)
        CarregaSchemaDadosAdicionaisFromDataTable(objSchema, oDataTable)

        Me.objData.objSchemaBase = objSchema

        Return objSchema
    End Function
#End Region


    Private Sub CarregaSchemaFromDataTable(ByRef objSchema As ShL.schSolicitacaoAlteracao, oDataTable As Data.DataTable)
        objSchema.id_solicitacao = IIf(Not oDataTable.Rows(0).Item("id_solicitacao_alteracao") Is DBNull.Value, oDataTable.Rows(0).Item("id_solicitacao_alteracao"), Nothing)
        objSchema.dt_solicitacao = IIf(Not oDataTable.Rows(0).Item("dt_solicitacao") Is DBNull.Value, oDataTable.Rows(0).Item("dt_solicitacao"), Nothing)
        objSchema.objStatus.cd_status = IIf(Not oDataTable.Rows(0).Item("cd_status_solicitacao_alteracao") Is DBNull.Value, oDataTable.Rows(0).Item("cd_status_solicitacao_alteracao"), Nothing)
        objSchema.objStatus.dc_status = IIf(Not oDataTable.Rows(0).Item("dc_status") Is DBNull.Value, oDataTable.Rows(0).Item("dc_status"), Nothing)
        objSchema.dt_atualizacao = IIf(Not oDataTable.Rows(0).Item("dt_atualizacao") Is DBNull.Value, oDataTable.Rows(0).Item("dt_atualizacao"), Nothing)
        objSchema.cd_usuario_atualizacao = IIf(Not oDataTable.Rows(0).Item("cd_usuario_atualizacao") Is DBNull.Value, oDataTable.Rows(0).Item("cd_usuario_atualizacao"), Nothing)
    End Sub

    Private Sub CarregaSchemaDadosBasicosFromDataTable(ByRef objSchema As ShL.schSolicitacaoAlteracao, oDataTable As Data.DataTable)
        objSchema.objDadosBasicos.nm_CNPJ = oDataTable.Rows(0).Item("nm_CNPJ").ToString
        objSchema.objDadosBasicos.no_razao_social = oDataTable.Rows(0).Item("no_razao_social").ToString
        objSchema.objDadosBasicos.no_nome_fantasia = oDataTable.Rows(0).Item("no_nome_fantasia").ToString
        objSchema.objDadosBasicos.nm_inscricao_estadual = oDataTable.Rows(0).Item("nm_inscricao_estadual").ToString
        objSchema.objDadosBasicos.nm_inscricao_municipal = oDataTable.Rows(0).Item("nm_inscricao_municipal").ToString
        objSchema.objDadosBasicos.no_rua = oDataTable.Rows(0).Item("no_rua").ToString
        objSchema.objDadosBasicos.nm_numero = oDataTable.Rows(0).Item("nm_numero").ToString
        objSchema.objDadosBasicos.xx_complemento = oDataTable.Rows(0).Item("xx_complemento").ToString
        objSchema.objDadosBasicos.no_bairro = oDataTable.Rows(0).Item("no_bairro").ToString
        objSchema.objDadosBasicos.nm_CEP = oDataTable.Rows(0).Item("nm_CEP").ToString
        objSchema.objDadosBasicos.nm_caixa_postal = oDataTable.Rows(0).Item("nm_caixa_postal").ToString
        objSchema.objDadosBasicos.no_cidade = oDataTable.Rows(0).Item("no_cidade").ToString
        objSchema.objDadosBasicos.sg_estado = oDataTable.Rows(0).Item("sg_estado").ToString
        objSchema.objDadosBasicos.cd_pais = oDataTable.Rows(0).Item("cd_pais").ToString
    End Sub

    Private Sub CarregaSchemaContatoFromDataTable(ByRef objSchema As ShL.schSolicitacaoAlteracao, oDataTable As Data.DataTable)
        objSchema.objContato.no_nome = oDataTable.Rows(0).Item("no_nome").ToString
        objSchema.objContato.no_sobrenome = oDataTable.Rows(0).Item("no_sobrenome").ToString
        objSchema.objContato.no_funcao = oDataTable.Rows(0).Item("no_funcao").ToString
        objSchema.objContato.no_departamento = oDataTable.Rows(0).Item("no_departamento").ToString
        objSchema.objContato.nm_telefone = oDataTable.Rows(0).Item("nm_telefone").ToString
        objSchema.objContato.nm_fax = oDataTable.Rows(0).Item("nm_fax").ToString
        objSchema.objContato.nm_celular = oDataTable.Rows(0).Item("nm_celular").ToString
        objSchema.objContato.xx_email = oDataTable.Rows(0).Item("xx_email").ToString
    End Sub

    Private Sub CarregaSchemaDadosAdicionaisFromDataTable(ByRef objSchema As ShL.schSolicitacaoAlteracao, oDataTable As Data.DataTable)
        objSchema.objDadosAdicionais.dc_servicos = oDataTable.Rows(0).Item("dc_servicos").ToString
        objSchema.objDadosAdicionais.dc_materiais = oDataTable.Rows(0).Item("dc_materiais").ToString
    End Sub

End Class
