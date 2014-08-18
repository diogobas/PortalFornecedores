Imports System.Data.SqlClient
Imports System.Web.UI.WebControls
Imports System.Net.Mail
Imports System.Data

Public Class bllSolicitacaoCadastro : Inherits bllBase

#Region "Construtores"

    Sub New()
        MyBase.New()
        Me.objData = New DAL.dalSolicitacaoCadastro()
    End Sub

    Sub New(ByRef objSchema As ShL.schSolicitacaoCadastro)
        Me.New()
        Me.objData.objSchemaBase = objSchema
    End Sub
#End Region

#Region "objData"
    Property objData() As DAL.dalSolicitacaoCadastro
        Get
            Return _objData
        End Get
        Set(ByVal value As DAL.dalSolicitacaoCadastro)
            _objData = value
        End Set
    End Property
#End Region

#Region "Delete"
    Public Overrides Function Delete(ByVal key As System.Web.UI.WebControls.DataKey) As Boolean

    End Function

    Public Overloads Function Delete(ByVal key As Integer) As Boolean
        Dim objFunc As New DAL.dalSolicitacaoCadastro
        Return objFunc.Delete(key)
    End Function
#End Region

#Region "getSolicitacaoCadastro_ByFilter"
    'Public Function getSolicitacaoCadastro_ByFilter(ByVal schSchema As ShL.schContato) As DataTable
    '    Dim objFunc As New DAL.dalContato()
    '    Return objFunc.getFuncionario_ByFilter(schSchema)
    'End Function
#End Region

#Region "getSumario"
    Public Function getSumario() As DataTable
        Dim objSolic As New DAL.dalSolicitacaoCadastro()
        Return objSolic.getSumario()
    End Function
#End Region

#Region "getCEPByText"
    Public Function getCEPByText(ByVal cep As String) As DataTable
        Dim objSolicitacaoCadastro As New DAL.dalSolicitacaoCadastro()
        Return objSolicitacaoCadastro.getCEPByText(cep)
    End Function
#End Region

#Region "getSolicitacaoCadastro_ByFiltro"
    Public Function getSolicitacaoCadastro_ByFiltro(ByVal oFiltro As ShL.schDadosFiltro) As DataTable
        Dim objSolicitacaoCadastro As New DAL.dalSolicitacaoCadastro()
        Return objSolicitacaoCadastro.getSolicitacaoCadastro_ByFiltro(oFiltro)
    End Function
#End Region

#Region "Insert"
    Public Function Insert(ByRef objSchema As ShL.schSolicitacaoCadastro) As Boolean

        Dim objSTL As STL.STLBase = New STL.STLBase()
        Dim objCont As DAL.dalSolicitacaoCadastro = Nothing

        objSTL.BeginTransaction()
        objCont = New DAL.dalSolicitacaoCadastro(objSTL)
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

#Region "ValidaSolicitacaoCadastro"
    Public Function ValidaSolicitacaoCadastro(ByRef objSchema As ShL.schSolicitacaoCadastro) As Boolean

        Dim objSTL As STL.STLBase = New STL.STLBase()
        Dim objCont As DAL.dalSolicitacaoCadastro = Nothing

        objSTL.BeginTransaction()
        objCont = New DAL.dalSolicitacaoCadastro(objSTL)
        objCont.objSchema = objSchema
        Try
            objCont.ValidaSolicitacaoCadastro()

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

#Region "RecusaSolicitacaoCadastro"
    Public Function RecusaSolicitacaoCadastro(ByRef objSchema As ShL.schSolicitacaoCadastro) As Boolean

        Dim objSTL As STL.STLBase = New STL.STLBase()
        Dim objCont As DAL.dalSolicitacaoCadastro = Nothing

        objSTL.BeginTransaction()
        objCont = New DAL.dalSolicitacaoCadastro(objSTL)
        objCont.objSchema = objSchema
        Try
            objCont.RecusaSolicitacaoCadastro()

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
    Public Function EnviaEmailAnalise(ByRef objSchema As ShL.schSolicitacaoCadastro) As Boolean
        Dim objSTL As STL.STLBase = New STL.STLBase()
        Dim objCont As DAL.dalSolicitacaoCadastro = Nothing
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
                If Not oSchConfiguracao.xx_envia_email_solicitacao_cadastro Then
                    Exit Function
                End If

                sSMTPeMail = oSchConfiguracao.xx_servidor_smtp
                seMailDestinatario = oSchConfiguracao.xx_email_destinatario_eventos
                sNomeDestinatario = oSchConfiguracao.xx_email_destinatario_eventos
                seMailRemetente = oSchConfiguracao.xx_email_remetente
                sNomeRemetente = oSchConfiguracao.xx_nome_remetente
                sAssuntoEmail = "Portal de Fornecedores (Nova Solicitação)"

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
            Mailmsg.Body += "Uma nova solicitação foi realizada através do Portal de Fornecedores.<BR \>"
            Mailmsg.Body += "Seguem abaixo os dados para análise.<BR \>"
            Mailmsg.Body += "</p>"

            Mailmsg.Body += "<p><span style='font-size:10.0pt;line-height:115%;font-family:""Verdana"",""sans-serif""'>"
            Mailmsg.Body += "<B><U>Dados Básicos do Fornecedor</U></B><BR \>"
            Mailmsg.Body += "</p>"
            Mailmsg.Body += "<p><span style='font-size:10.0pt;line-height:115%;font-family:""Verdana"",""sans-serif""'>"
            Mailmsg.Body += sNBSP & "Origem da Solicitação: <B>" & IIf(objSchema.objDadosBasicos.no_tipo_solicitacao = "I", "Interna", "Externa") & "</B><BR \>"
            If objSchema.objDadosBasicos.nm_CNPJ <> "" Then
                Mailmsg.Body += sNBSP & "CNPJ: <B>" & Convert.ToInt64(objSchema.objDadosBasicos.nm_CNPJ).ToString("00\.000\.000\/0000\-00") & "</B><BR \>"
            ElseIf (objSchema.objDadosBasicos.nm_CPF <> "") Then
                Mailmsg.Body += sNBSP & "CPF: <B>" & Convert.ToInt64(objSchema.objDadosBasicos.nm_CPF).ToString("000\.000\.000\-00") & "</B><BR \>"
            ElseIf (objSchema.objDadosBasicos.nm_cod_sap <> "") Then
                Mailmsg.Body += sNBSP & "Cod. SAP: <B>" & Convert.ToInt64(objSchema.objDadosBasicos.nm_cod_sap).ToString() & "</B><BR \>"
            End If
            Mailmsg.Body += sNBSP & "Razão Social: <B>" & objSchema.objDadosBasicos.no_razao_social & "</B><BR \>"
            Mailmsg.Body += sNBSP & "Nome Fantasia: <B>" & objSchema.objDadosBasicos.no_nome_fantasia & "</B><BR \>"
            Mailmsg.Body += sNBSP & "Inscrição Estadual: <B>" & objSchema.objDadosBasicos.nm_inscricao_estadual & "</B><BR \>"
            Mailmsg.Body += sNBSP & "Inscrição Municipal: <B>" & objSchema.objDadosBasicos.nm_inscricao_municipal & "</B><BR \>"
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

            If objSchema.objDadosBasicos.no_tipo_solicitacao = "E" Then
                Mailmsg.Body += "<p><span style='font-size:10.0pt;line-height:115%;font-family:""Verdana"",""sans-serif""'>"
                Mailmsg.Body += "<B><U>Dados Adicionais</U></B><BR/>"
                Mailmsg.Body += "</P>"
                Mailmsg.Body += "<p><span style='font-size:10.0pt;line-height:115%;font-family:""Verdana"",""sans-serif""'>"
                Mailmsg.Body += sNBSP & "Como conheceu a Duratex: <B>" & objSchema.objDadosAdicionais.objComoConheceu.dc_como_conheceu & "</B><BR \>"
                If objSchema.objDadosAdicionais.no_contato.Length > 0 Then
                    Mailmsg.Body += sNBSP & "Nome do Contato Duratex: <B>" & objSchema.objDadosAdicionais.no_contato & "</B><BR \>"
                End If

                Mailmsg.Body += sNBSP & "Serviços: <B>" & objSchema.objDadosAdicionais.dc_servicos.Replace(vbCrLf, "<BR>" & sNBSP & sNBSP & sNBSP & sNBSP & sNBSP) & "</B><BR \>"
                Mailmsg.Body += sNBSP & "Materiais: <B>" & objSchema.objDadosAdicionais.dc_materiais.Replace(vbCrLf, "<BR>" & sNBSP & sNBSP & sNBSP & sNBSP & sNBSP) & "</B><BR \>"
            End If
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
    Public Function EnviaEmailRetorno(ByRef objSchema As ShL.schSolicitacaoCadastro) As Boolean
        Dim objSTL As STL.STLBase = New STL.STLBase()
        Dim objCont As DAL.dalSolicitacaoCadastro = Nothing
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
                If Not oSchConfiguracao.xx_envia_email_retorno_solicitacao_cadastro Then
                    Exit Function
                End If

                sSMTPeMail = oSchConfiguracao.xx_servidor_smtp
                If objSchema.objDadosBasicos.no_tipo_solicitacao = "E" Then
                    seMailDestinatario = objSchema.objContato.xx_email
                    sNomeDestinatario = objSchema.objContato.no_nome & " " & objSchema.objContato.no_sobrenome
                Else
                    seMailDestinatario = objSchema.cd_usuario_solicitacao & "@duratex.com.br"
                    sNomeDestinatario = objSchema.cd_usuario_solicitacao & "@duratex.com.br"
                End If

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
            If objSchema.objDadosBasicos.no_tipo_solicitacao = "E" Then
                Mailmsg.Body += "Prezado(a) <B>" & objSchema.objContato.no_nome & " " & objSchema.objContato.no_sobrenome & "</B>, <BR \>"
            Else
                Mailmsg.Body += "Prezado(a) <B>" & objSchema.objContato.no_nome_solicitante & "</B>, <BR \>"
            End If
            Mailmsg.Body += "</P>"

            Mailmsg.Body += "<p><span style='font-size:10.0pt;line-height:115%;font-family:""Verdana"",""sans-serif""'>"
            Mailmsg.Body += sNBSP & "Sua solicitação foi registrada no Portal de Fornecedores Duratex.<BR \>"
            If objSchema.objDadosBasicos.no_tipo_solicitacao = "E" Then
                Mailmsg.Body += sNBSP & "Os dados serão analisados por nossa equipe interna.<BR \>"
                Mailmsg.Body += sNBSP & "Ultilize a chave de acesso abaixo para acompanhar o status da sua solicitação.<BR \>"
            End If
            If objSchema.objDadosBasicos.nm_CNPJ <> "" Then
                Mailmsg.Body += sNBSP & "CNPJ: <B>" & Convert.ToInt64(objSchema.objDadosBasicos.nm_CNPJ).ToString("00\.000\.000\/0000\-00") & "</B><BR \>"
            ElseIf (objSchema.objDadosBasicos.nm_CPF <> "") Then
                Mailmsg.Body += sNBSP & "CPF: <B>" & Convert.ToInt64(objSchema.objDadosBasicos.nm_CPF).ToString("000\.000\.000\-00") & "</B><BR \>"
            ElseIf (objSchema.objDadosBasicos.nm_cod_sap <> "") Then
                Mailmsg.Body += sNBSP & "Cod. SAP: <B>" & Convert.ToInt64(objSchema.objDadosBasicos.nm_cod_sap).ToString() & "</B><BR \>"
            End If
            Mailmsg.Body += sNBSP & "Razão Social: <B>" & objSchema.objDadosBasicos.no_razao_social & "</B><BR \>"
            If objSchema.objDadosBasicos.no_tipo_solicitacao = "E" Then
                Mailmsg.Body += sNBSP & "Chave de Acesso: <B>" & objSchema.xx_chave_acesso & "</B><BR \>"
            Else
                Mailmsg.Body += sNBSP & "Operação: <b>"
                Select Case objSchema.objDadosBasicos.no_operacao
                    Case 1
                        Mailmsg.Body += "Inclusão"
                    Case 2
                        Mailmsg.Body += "Alteração"
                    Case 3
                        Mailmsg.Body += "Bloqueio"
                    Case 4
                        Mailmsg.Body += "Desbloqueio"
                    Case Else
                        Mailmsg.Body += ""
                End Select
                Mailmsg.Body += "</b><BR>"
            End If

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
    Public Function EnviaEmailValidacao(ByRef objSchema As ShL.schSolicitacaoCadastro) As Boolean
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
                If Not oSchConfiguracao.xx_envia_email_retorno_solicitacao_cadastro Then
                    Exit Function
                End If

                sSMTPeMail = oSchConfiguracao.xx_servidor_smtp

                If objSchema.objDadosBasicos.no_tipo_solicitacao = "E" Then
                    seMailDestinatario = objSchema.objContato.xx_email
                    sNomeDestinatario = objSchema.objContato.no_nome & " " & objSchema.objContato.no_sobrenome
                Else
                    seMailDestinatario = objSchema.cd_usuario_solicitacao & "@duratex.com.br"
                    sNomeDestinatario = objSchema.cd_usuario_solicitacao & "@duratex.com.br"
                End If

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
            If objSchema.objDadosBasicos.no_tipo_solicitacao = "E" Then
                Mailmsg.Body += "Prezado(a) <B>" & objSchema.objContato.no_nome & " " & objSchema.objContato.no_sobrenome & "</B>, <BR \>"
            Else
                Mailmsg.Body += "Prezado(a) <B>" & objSchema.objContato.no_nome_solicitante & "</B>, <BR \>"
            End If
            Mailmsg.Body += "</P>"

            Mailmsg.Body += "<p><span style='font-size:10.0pt;line-height:115%;font-family:""Verdana"",""sans-serif""'>"
            If objSchema.objDadosBasicos.no_operacao = "1" Then
                Mailmsg.Body += sNBSP & "Sua solicitação no Portal de Fornecedores Duratex foi atendida, para obter o novo código do fornecedor favor consultá-lo através da transação XK03 no SAP.<BR \>"
            Else
                Mailmsg.Body += sNBSP & "Sua solicitação no Portal de Fornecedores Duratex foi atendida.<BR \>"
            End If

            If objSchema.objDadosBasicos.no_tipo_solicitacao = "E" Then
                Mailmsg.Body += sNBSP & "A partir de agora sua empresa está cadastrada como Fornecedor Duratex.<BR \>"
            Else
                Mailmsg.Body += sNBSP & "Operação: <b>"
                Select Case objSchema.objDadosBasicos.no_operacao
                    Case 1
                        Mailmsg.Body += "Inclusão"
                    Case 2
                        Mailmsg.Body += "Alteração"
                    Case 3
                        Mailmsg.Body += "Bloqueio"
                    Case 4
                        Mailmsg.Body += "Desbloqueio"
                    Case Else
                        Mailmsg.Body += ""
                End Select
                Mailmsg.Body += "</b><BR>"
            End If
            If objSchema.objDadosBasicos.nm_CNPJ <> "" Then
                Mailmsg.Body += sNBSP & "CNPJ: <B>" & Convert.ToInt64(objSchema.objDadosBasicos.nm_CNPJ).ToString("00\.000\.000\/0000\-00") & "</B><BR \>"
            ElseIf (objSchema.objDadosBasicos.nm_CPF <> "") Then
                Mailmsg.Body += sNBSP & "CPF: <B>" & Convert.ToInt64(objSchema.objDadosBasicos.nm_CPF).ToString("000\.000\.000\-00") & "</B><BR \>"
            ElseIf (objSchema.objDadosBasicos.nm_cod_sap <> "") Then
                Mailmsg.Body += sNBSP & "Cod. SAP: <B>" & Convert.ToInt64(objSchema.objDadosBasicos.nm_cod_sap).ToString() & "</B><BR \>"
            End If
            Mailmsg.Body += sNBSP & "Razão Social: <B>" & objSchema.objDadosBasicos.no_razao_social & "</B><BR \>"
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

#Region "EnviaEmailRecusa"
    Public Function EnviaEmailRecusa(ByRef objSchema As ShL.schSolicitacaoCadastro) As Boolean
        Dim objSTL As STL.STLBase = New STL.STLBase()
        Dim objCont As DAL.dalSolicitacaoAlteracao = Nothing
        Dim sSMTPeMail As String = ""
        Dim sNomeDestinatario As String = ""
        Dim seMailDestinatario As String = ""
        Dim seMailRemetente As String = ""
        Dim sNomeRemetente As String = ""
        Dim sAssuntoEmail As String = ""
        Dim sNBSP As String = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"

        EnviaEmailRecusa = True
        Try
            Try
                Dim oSchConfiguracao As ShL.schConfiguracao = BLL.bllConfiguracao.getConfiguracao
                If Not oSchConfiguracao.xx_envia_email_retorno_solicitacao_cadastro Then
                    Exit Function
                End If

                sSMTPeMail = oSchConfiguracao.xx_servidor_smtp

                If objSchema.objDadosBasicos.no_tipo_solicitacao = "E" Then
                    seMailDestinatario = objSchema.objContato.xx_email
                    sNomeDestinatario = objSchema.objContato.no_nome & " " & objSchema.objContato.no_sobrenome
                Else
                    seMailDestinatario = objSchema.cd_usuario_solicitacao & "@duratex.com.br"
                    sNomeDestinatario = objSchema.cd_usuario_solicitacao & "@duratex.com.br"
                End If

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
            If objSchema.objDadosBasicos.no_tipo_solicitacao = "E" Then
                Mailmsg.Body += "Prezado(a) <B>" & objSchema.objContato.no_nome & " " & objSchema.objContato.no_sobrenome & "</B>, <BR \>"
            Else
                Mailmsg.Body += "Prezado(a) <B>" & objSchema.objContato.no_nome_solicitante & "</B>, <BR \>"
            End If
            Mailmsg.Body += "</P>"

            Mailmsg.Body += "<p><span style='font-size:10.0pt;line-height:115%;font-family:""Verdana"",""sans-serif""'>"
            If objSchema.objDadosBasicos.no_operacao = "1" Then
                Mailmsg.Body += sNBSP & "Sua solicitação no Portal de Fornecedores Duratex foi recusada. O motivo foi: " & objSchema.dc_motivo_recusa & ". <BR \>"
            End If

            If objSchema.objDadosBasicos.no_tipo_solicitacao = "E" Then
                Mailmsg.Body += sNBSP & "Entre em contato o quanto antes para regularizarmos sua situação.<BR \>"
            Else
                Mailmsg.Body += sNBSP & "Operação: <b>"
                Select Case objSchema.objDadosBasicos.no_operacao
                    Case 1
                        Mailmsg.Body += "Inclusão"
                    Case 2
                        Mailmsg.Body += "Alteração"
                    Case 3
                        Mailmsg.Body += "Bloqueio"
                    Case 4
                        Mailmsg.Body += "Desbloqueio"
                    Case Else
                        Mailmsg.Body += ""
                End Select
                Mailmsg.Body += "</b><BR>"
            End If
            If objSchema.objDadosBasicos.nm_CNPJ <> "" Then
                Mailmsg.Body += sNBSP & "CNPJ: <B>" & Convert.ToInt64(objSchema.objDadosBasicos.nm_CNPJ).ToString("00\.000\.000\/0000\-00") & "</B><BR \>"
            ElseIf (objSchema.objDadosBasicos.nm_CPF <> "") Then
                Mailmsg.Body += sNBSP & "CPF: <B>" & Convert.ToInt64(objSchema.objDadosBasicos.nm_CPF).ToString("000\.000\.000\-00") & "</B><BR \>"
            ElseIf (objSchema.objDadosBasicos.nm_cod_sap <> "") Then
                Mailmsg.Body += sNBSP & "Cod. SAP: <B>" & Convert.ToInt64(objSchema.objDadosBasicos.nm_cod_sap).ToString() & "</B><BR \>"
            End If
            Mailmsg.Body += sNBSP & "Razão Social: <B>" & objSchema.objDadosBasicos.no_razao_social & "</B><BR \>"
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
                EnviaEmailRecusa = False
                Dim erro As New Exception("Houve um problema ao enviar seu email. Tente Novamente.")
                Throw erro
            End Try
            Mailmsg.Attachments.Dispose()
            Mailmsg.Dispose()

        Catch ex As Exception
            EnviaEmailRecusa = False
            Dim erro As New Exception("Houve um problema ao enviar seu email. Tente Novamente.")
            Throw erro
        End Try
    End Function

#End Region


#Region "Update"
    Public Function Update(ByRef objSchema As ShL.schSolicitacaoCadastroContato) As Boolean

    End Function
#End Region

#Region "getContatoByPk"
    'Public Function getContatoByPk(ByVal Funcionario_ID As Integer) As DataTable
    '    Dim objFunc As New DAL.dalContato()
    '    Return objFunc.getContatoByPk(Funcionario_ID)
    'End Function
#End Region

#Region "getSolicitacaoCadastroByCNPJ"
    Public Function getSolicitacaoCadastroByCNPJ(ByVal CNPJ As String) As ShL.schSolicitacaoCadastro
        Dim objSchema As New ShL.schSolicitacaoCadastro
        Dim objSolic As New DAL.dalSolicitacaoCadastro
        Dim oDataTable As DataTable

        oDataTable = objSolic.getSolicitacaoCadastroByCNPJ(CNPJ)
        CarregaSchemaFromDataTable(objSchema, oDataTable)

        oDataTable = objSolic.getSolicitacaoCadastroDadosBasicosByPK(objSchema.id_solicitacao)
        CarregaSchemaDadosBasicosFromDataTable(objSchema, oDataTable)

        oDataTable = objSolic.getSolicitacaoCadastroContatoByPK(objSchema.id_solicitacao)
        CarregaSchemaContatoFromDataTable(objSchema, oDataTable)

        oDataTable = objSolic.getSolicitacaoCadastroDadosAdicionaisByPK(objSchema.id_solicitacao)
        CarregaSchemaDadosAdicionaisFromDataTable(objSchema, oDataTable)

        Me.objData.objSchemaBase = objSchema

        Return objSchema
    End Function
#End Region

#Region "getSolicitacaoCadastroByID"
    Public Function getSolicitacaoCadastroByID(ByVal ID As String) As ShL.schSolicitacaoCadastro
        Dim objSchema As New ShL.schSolicitacaoCadastro
        Dim objSolic As New DAL.dalSolicitacaoCadastro
        Dim oDataTable As DataTable

        oDataTable = objSolic.getSolicitacaoCadastroById(ID)
        CarregaSchemaFromDataTable(objSchema, oDataTable)

        oDataTable = objSolic.getSolicitacaoCadastroDadosBasicosByPK(objSchema.id_solicitacao)
        CarregaSchemaDadosBasicosFromDataTable(objSchema, oDataTable)

        oDataTable = objSolic.getSolicitacaoCadastroContatoByPK(objSchema.id_solicitacao)
        CarregaSchemaContatoFromDataTable(objSchema, oDataTable)

        oDataTable = objSolic.getSolicitacaoCadastroDadosAdicionaisByPK(objSchema.id_solicitacao)
        CarregaSchemaDadosAdicionaisFromDataTable(objSchema, oDataTable)

        Me.objData.objSchemaBase = objSchema

        Return objSchema
    End Function

#Region "getAllTipoMaterial"
    Public Function getAllTipoMaterial() As DataTable
        Dim objTipoMaterial As New DAL.dalSolicitacaoCadastro()
        Return objTipoMaterial.getTipoMaterial
    End Function
#End Region

#Region "getAllPais"
    Public Function getAllPais() As DataTable
        Dim objPais As New DAL.dalSolicitacaoCadastro()
        Return objPais.getPais
    End Function
#End Region

#Region "getAllCondPgmto"
    Public Function getAllCondPgmto() As DataTable
        Dim objPais As New DAL.dalSolicitacaoCadastro()
        Return objPais.getCondPgmto("")
    End Function
#End Region

#Region "getCondPgmtoByCod"
    Public Function getCondPgmtoByCod(Cod As String) As DataTable
        Dim objPais As New DAL.dalSolicitacaoCadastro()
        Return objPais.getCondPgmto(Cod)
    End Function
#End Region

#Region "getAllCentros"
    Public Function getAllCentros() As DataTable
        Dim objTipoMaterial As New DAL.dalSolicitacaoCadastro()
        Return objTipoMaterial.getAllCentros
    End Function
#End Region


#Region "getAllTipoServico"
    Public Function getAllTipoServico() As DataTable
        Dim objTipoServico As New DAL.dalSolicitacaoCadastro()
        Return objTipoServico.getTipoServico
    End Function
#End Region

#End Region

    Private Sub CarregaSchemaFromDataTable(ByRef objSchema As ShL.schSolicitacaoCadastro, oDataTable As Data.DataTable)
        objSchema.id_solicitacao = IIf(Not oDataTable.Rows(0).Item("id_solicitacao") Is DBNull.Value, oDataTable.Rows(0).Item("id_solicitacao"), Nothing)
        objSchema.dt_solicitacao = IIf(Not oDataTable.Rows(0).Item("dt_solicitacao") Is DBNull.Value, oDataTable.Rows(0).Item("dt_solicitacao"), Nothing)
        objSchema.objStatus.cd_status = IIf(Not oDataTable.Rows(0).Item("cd_status_solicitacao") Is DBNull.Value, oDataTable.Rows(0).Item("cd_status_solicitacao"), Nothing)
        objSchema.objStatus.dc_status = IIf(Not oDataTable.Rows(0).Item("dc_status") Is DBNull.Value, oDataTable.Rows(0).Item("dc_status"), Nothing)
        objSchema.dt_atualizacao = IIf(Not oDataTable.Rows(0).Item("dt_atualizacao") Is DBNull.Value, oDataTable.Rows(0).Item("dt_atualizacao"), Nothing)
        objSchema.cd_usuario_atualizacao = IIf(Not oDataTable.Rows(0).Item("cd_usuario_atualizacao") Is DBNull.Value, oDataTable.Rows(0).Item("cd_usuario_atualizacao"), Nothing)
        objSchema.cd_usuario_solicitacao = IIf(Not oDataTable.Rows(0).Item("cd_usuario_solicitacao") Is DBNull.Value, oDataTable.Rows(0).Item("cd_usuario_solicitacao"), Nothing)
    End Sub

    Private Sub CarregaSchemaDadosBasicosFromDataTable(ByRef objSchema As ShL.schSolicitacaoCadastro, oDataTable As Data.DataTable)
        If oDataTable Is Nothing Then
            Exit Sub
        End If
        objSchema.objDadosBasicos.no_tipo_solicitacao = oDataTable.Rows(0).Item("no_tipo_solicitacao").ToString
        objSchema.objDadosBasicos.no_operacao = oDataTable.Rows(0).Item("no_operacao").ToString
        objSchema.objDadosBasicos.no_empresa = oDataTable.Rows(0).Item("no_empresa").ToString
        objSchema.objDadosBasicos.no_categoria = oDataTable.Rows(0).Item("no_categoria").ToString
        objSchema.objDadosBasicos.no_indicacao = oDataTable.Rows(0).Item("no_indicacao").ToString
        objSchema.objDadosBasicos.no_fornecimento = oDataTable.Rows(0).Item("no_fornecimento").ToString
        objSchema.objDadosBasicos.nm_id_fisc = oDataTable.Rows(0).Item("nm_id_fisc").ToString
        objSchema.objDadosBasicos.nm_cod_sap = oDataTable.Rows(0).Item("nm_cod_sap").ToString
        objSchema.objDadosBasicos.no_obs = oDataTable.Rows(0).Item("no_obs").ToString
        objSchema.objDadosBasicos.no_tipo_material = oDataTable.Rows(0).Item("no_tipo_material").ToString
        objSchema.objDadosBasicos.no_tipo_servico = oDataTable.Rows(0).Item("no_tipo_servico").ToString
        objSchema.objDadosBasicos.nm_CPF = oDataTable.Rows(0).Item("nm_CPF").ToString
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

    Private Sub CarregaSchemaContatoFromDataTable(ByRef objSchema As ShL.schSolicitacaoCadastro, oDataTable As Data.DataTable)
        If oDataTable Is Nothing Then
            Exit Sub
        End If
        objSchema.objContato.no_nome = oDataTable.Rows(0).Item("no_nome").ToString
        objSchema.objContato.no_sobrenome = oDataTable.Rows(0).Item("no_sobrenome").ToString
        objSchema.objContato.no_funcao = oDataTable.Rows(0).Item("no_funcao").ToString
        objSchema.objContato.no_departamento = oDataTable.Rows(0).Item("no_departamento").ToString
        objSchema.objContato.nm_telefone = oDataTable.Rows(0).Item("nm_telefone").ToString
        objSchema.objContato.nm_fax = oDataTable.Rows(0).Item("nm_fax").ToString
        objSchema.objContato.nm_celular = oDataTable.Rows(0).Item("nm_celular").ToString
        objSchema.objContato.xx_email = oDataTable.Rows(0).Item("xx_email").ToString
        objSchema.objContato.no_nome_solicitante = oDataTable.Rows(0).Item("no_nome_solicitante").ToString
        objSchema.objContato.no_area_solicitante = oDataTable.Rows(0).Item("no_area_solicitante").ToString
        objSchema.objContato.nm_telefone_solicitante = oDataTable.Rows(0).Item("nm_telefone_solicitante").ToString
        objSchema.objContato.no_observacao_solicitante = oDataTable.Rows(0).Item("no_observacao_solicitante").ToString        
    End Sub

    Private Sub CarregaSchemaDadosAdicionaisFromDataTable(ByRef objSchema As ShL.schSolicitacaoCadastro, oDataTable As Data.DataTable)
        If oDataTable Is Nothing Then
            Exit Sub
        End If
        objSchema.objDadosAdicionais.objComoConheceu.cd_como_conheceu = oDataTable.Rows(0).Item("cd_como_conheceu")
        objSchema.objDadosAdicionais.objComoConheceu.dc_como_conheceu = oDataTable.Rows(0).Item("dc_como_conheceu").ToString
        objSchema.objDadosAdicionais.no_contato = oDataTable.Rows(0).Item("no_contato").ToString
        objSchema.objDadosAdicionais.dc_servicos = oDataTable.Rows(0).Item("dc_servicos").ToString
        objSchema.objDadosAdicionais.dc_materiais = oDataTable.Rows(0).Item("dc_materiais").ToString
        objSchema.objDadosAdicionais.xx_optante = oDataTable.Rows(0).Item("xx_optante").ToString
        objSchema.objDadosAdicionais.dc_inss = oDataTable.Rows(0).Item("dc_inss").ToString
        objSchema.objDadosAdicionais.cd_cbo = oDataTable.Rows(0).Item("cd_cbo").ToString
        objSchema.objDadosAdicionais.cd_sefip = oDataTable.Rows(0).Item("cd_sefip").ToString
        objSchema.objDadosAdicionais.nm_inscricao_rural = oDataTable.Rows(0).Item("nm_inscricao_rural").ToString
        objSchema.objDadosAdicionais.cd_condicao_pagamento = oDataTable.Rows(0).Item("cd_condicao_pagamento").ToString
    End Sub

End Class
