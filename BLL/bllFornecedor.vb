Imports System.Data.SqlClient
Imports System.Web.UI.WebControls
Imports System.Net.Mail
Imports System.Data

Public Class bllFornecedor : Inherits bllBase

#Region "Construtores"

    Sub New()
        MyBase.New()
        Me.objData = New DAL.dalFornecedor()
    End Sub

    Sub New(ByRef objSchema As ShL.schFornecedor)
        Me.New()
        Me.objData.objSchemaBase = objSchema
    End Sub
#End Region

#Region "objData"
    Property objData() As DAL.dalFornecedor
        Get
            Return _objData
        End Get
        Set(ByVal value As DAL.dalFornecedor)
            _objData = value
        End Set
    End Property
#End Region

#Region "Delete"
    Public Overrides Function Delete(ByVal key As System.Web.UI.WebControls.DataKey) As Boolean

    End Function

    Public Overloads Function Delete(ByVal key As Integer) As Boolean
        Dim objFunc As New DAL.dalFornecedor
        Return objFunc.Delete(key)
    End Function
#End Region

#Region "getFornecedor_ByFilter"
    'Public Function getFornecedor_ByFilter(ByVal schSchema As ShL.schContato) As DataTable
    '    Dim objFunc As New DAL.dalContato()
    '    Return objFunc.getFuncionario_ByFilter(schSchema)
    'End Function
#End Region

#Region "Insert"
    Public Function Insert(ByRef objSchema As ShL.schFornecedor) As Boolean

        Dim objSTL As STL.STLBase = New STL.STLBase()
        Dim objCont As DAL.dalFornecedor = Nothing

        objSTL.BeginTransaction()
        objCont = New DAL.dalFornecedor(objSTL)
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

#Region "EnviaEmail"
    'Public Function EnviaEmail(ByRef objSchema As ShL.schFornecedorContato) As Boolean
    '    Dim objSTL As STL.STLBase = New STL.STLBase()
    '    Dim objCont As DAL.dalFornecedor = Nothing
    '    Dim sSMTPeMail As String = ""
    '    Dim sNomeDestinatario As String = ""
    '    Dim seMailDestinatario As String = ""
    '    Dim seMailRemetente As String = ""
    '    Dim sNomeRemetente As String = ""
    '    Dim sAssuntoEmail As String = ""

    '    EnviaEmail = True
    '    Try
    '        If sSMTPeMail.Length = 0 Then
    '            Try
    '                sSMTPeMail = Common.Configuracao.getSMTPeMail()
    '                seMailDestinatario = Common.Configuracao.geteMailDestinatario()
    '                sNomeDestinatario = Common.Configuracao.getNomeDestinatario()
    '                seMailRemetente = Common.Configuracao.geteMailRemetente()
    '                sNomeRemetente = Common.Configuracao.getNomeRemetente()
    '                sAssuntoEmail = Common.Configuracao.getAssuntoEMail()

    '            Catch ex As Exception
    '                Dim erro As New Exception("Falha ao obter configurações de email.")
    '            End Try
    '        End If

    '        Dim sEmailDest As String = seMailDestinatario
    '        Dim Mensagem As MailMessage = New MailMessage()
    '        Dim Mailmsg As New System.Net.Mail.MailMessage()
    '        Dim mSmtpCliente As New SmtpClient(sSMTPeMail)

    '        If objSchema.xx_receber_retorno And objSchema.xx_email.Trim.Contains("@") Then
    '            Mailmsg.From = New MailAddress(objSchema.xx_email, objSchema.no_completo)
    '        Else
    '            Mailmsg.From = New MailAddress(seMailRemetente, sNomeRemetente)
    '        End If

    '        Mailmsg.Subject = sAssuntoEmail & " - " & objSchema.dc_tipo_contato & " - " & objSchema.dc_tipo_publico
    '        Mailmsg.BodyEncoding = System.Text.Encoding.UTF8
    '        Mailmsg.IsBodyHtml = True

    '        Mailmsg.Body = "<HTML><p><span style='font-size:10.0pt;line-height:115%;font-family:""Verdana"",""sans-serif""'>"
    '        Mailmsg.Body += "Origem: <B>" & objSchema.dc_tipo_publico & "</B><BR \>"
    '        Mailmsg.Body += "Meio Utilizado: <B>" & objSchema.xx_origem & "</B><BR \>"
    '        Mailmsg.Body += "Tipo de Contato: <B>" & objSchema.dc_tipo_contato & "</B><BR \>"
    '        Mailmsg.Body += "Mensagem: <B>" & objSchema.dc_mensagem & "</B><BR \>"
    '        Mailmsg.Body += "Gostaria de receber retorno: <B>" & IIf(objSchema.xx_receber_retorno, "Sim", "Não") & "</B><BR \>"
    '        If objSchema.xx_receber_retorno Then
    '            Mailmsg.Body += "&nbsp;&nbsp;Telefone: <B>" & objSchema.nm_telefone & "</B><BR \>"
    '            Mailmsg.Body += "&nbsp;&nbsp;Email: <B>" & objSchema.xx_email & "</B><BR \>"
    '        End If
    '        If objSchema.cd_tipo_publico = "F" Then
    '            Mailmsg.Body += "Empresa: <B>" & objSchema.no_razao_social_empresa & "</B><BR \>"
    '            Mailmsg.Body += "CNPJ: <B>" & objSchema.nm_cnpj & "</B><BR \>"
    '        End If
    '        Mailmsg.Body += "Nome Completo: <B>" & objSchema.no_completo & "</B><BR \>"
    '        Mailmsg.Body += "Cargo: <B>" & objSchema.dc_cargo & "</B><BR \>"
    '        If objSchema.cd_tipo_publico = "C" Then
    '            Mailmsg.Body += "Área: <B>" & objSchema.no_area & "</B><BR \>"
    '            Mailmsg.Body += "Unidade de Negócio: <B>" & objSchema.no_unidade_negocio & "</B><BR \>"
    '        End If

    '        Mailmsg.Body += IIf(objSchema.cd_tipo_publico = "C", "Unidade:", "Cidade:") & " <B>" & objSchema.no_cidade & "</B><BR \>"
    '        Mailmsg.Body += "Estado: <B>" & IIf(objSchema.cd_uf <> "-1", objSchema.cd_uf, "") & "</B><BR \>"
    '        Mailmsg.Body += "</P> </HTML>"

    '        Mailmsg.To.Add(New MailAddress(seMailDestinatario, sNomeDestinatario))

    '        Mailmsg.Attachments.Clear()

    '        Try
    '            mSmtpCliente.Send(Mailmsg)
    '        Catch ex As Exception
    '            EnviaEmail = False
    '            Dim erro As New Exception("Houve um problema ao enviar seu email. Tente Novamente.")
    '            Throw erro
    '        End Try
    '        Mailmsg.Attachments.Dispose()
    '        Mailmsg.Dispose()

    '    Catch ex As Exception
    '        EnviaEmail = False
    '        Dim erro As New Exception("Houve um problema ao enviar seu email. Tente Novamente.")
    '        Throw erro
    '    End Try
    'End Function

#End Region

#Region "Update"
    Public Function Update(ByRef objSchema As ShL.schFornecedorContato) As Boolean

    End Function
#End Region

#Region "getContatoByPk"
    'Public Function getContatoByPk(ByVal Funcionario_ID As Integer) As DataTable
    '    Dim objFunc As New DAL.dalContato()
    '    Return objFunc.getContatoByPk(Funcionario_ID)
    'End Function
#End Region


#Region "ValidaFornecedor"
    Public Function ValidaFornecedor(ByVal CNPJ As String, ChaveAcesso As String) As DataTable
        Dim objFunc As New DAL.dalFornecedor()
        Dim objSchema As New ShL.schFornecedor

        objSchema.nm_cnpj = CNPJ
        objSchema.xx_chave_acesso = ChaveAcesso

        Return objFunc.ValidaFornecedor(objSchema)
    End Function
#End Region

#Region "ValidaRecuperaChave"
    Public Function ValidaRecuperaChave(ByVal CNPJ As String, Email As String) As DataTable
        Dim objFunc As New DAL.dalFornecedor()
        Dim objSchema As New ShL.schFornecedor

        objSchema.nm_cnpj = CNPJ
        objSchema.objContato.xx_email = Email

        Return objFunc.ValidaRecuperaChave(objSchema)
    End Function
#End Region


#Region "getFornecedorByCNPJ"
    Public Function getFornecedorByCNPJ(ByVal CNPJ As String) As ShL.schFornecedor
        Dim objSchema As New ShL.schFornecedor
        Dim objSolic As New DAL.dalFornecedor
        Dim oDataTable As DataTable

        oDataTable = objSolic.getFornecedorByCNPJ(CNPJ)
        CarregaSchemaFromDataTable(objSchema, oDataTable)

        oDataTable = objSolic.getFornecedorDadosBasicosByPK(objSchema.nm_cnpj)
        CarregaSchemaDadosBasicosFromDataTable(objSchema, oDataTable)

        oDataTable = objSolic.getFornecedorContatoByPK(objSchema.nm_cnpj)
        CarregaSchemaContatoFromDataTable(objSchema, oDataTable)

        oDataTable = objSolic.getFornecedorDadosAdicionaisByPK(objSchema.nm_cnpj)
        CarregaSchemaDadosAdicionaisFromDataTable(objSchema, oDataTable)

        Return objSchema
    End Function
#End Region

    Private Sub CarregaSchemaFromDataTable(ByRef objSchema As ShL.schFornecedor, oDataTable As Data.DataTable)
        If oDataTable Is Nothing Then
            Exit Sub
        End If
        objSchema.nm_cnpj = IIf(Not oDataTable.Rows(0).Item("nm_cnpj") Is DBNull.Value, oDataTable.Rows(0).Item("nm_cnpj"), Nothing)
        objSchema.xx_chave_acesso = IIf(Not oDataTable.Rows(0).Item("id_chave_acesso") Is DBNull.Value, oDataTable.Rows(0).Item("id_chave_acesso"), Nothing)
        objSchema.objStatus.cd_status = IIf(Not oDataTable.Rows(0).Item("cd_status_chave_acesso") Is DBNull.Value, oDataTable.Rows(0).Item("cd_status_chave_acesso"), Nothing)
        objSchema.objStatus.dc_status = IIf(Not oDataTable.Rows(0).Item("dc_status_chave_acesso") Is DBNull.Value, oDataTable.Rows(0).Item("dc_status_chave_acesso"), Nothing)
        objSchema.dt_atualizacao = IIf(Not oDataTable.Rows(0).Item("dt_atualizacao") Is DBNull.Value, oDataTable.Rows(0).Item("dt_atualizacao"), Nothing)
        objSchema.cd_usuario_atualizacao = IIf(Not oDataTable.Rows(0).Item("cd_usuario_atualizacao") Is DBNull.Value, oDataTable.Rows(0).Item("cd_usuario_atualizacao"), Nothing)
    End Sub

    Private Sub CarregaSchemaDadosBasicosFromDataTable(ByRef objSchema As ShL.schFornecedor, oDataTable As Data.DataTable)
        If oDataTable Is Nothing Then
            Exit Sub
        End If
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

    Private Sub CarregaSchemaContatoFromDataTable(ByRef objSchema As ShL.schFornecedor, oDataTable As Data.DataTable)
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
    End Sub

    Private Sub CarregaSchemaDadosAdicionaisFromDataTable(ByRef objSchema As ShL.schFornecedor, oDataTable As Data.DataTable)
        If oDataTable Is Nothing Then
            Exit Sub
        End If
        objSchema.objDadosAdicionais.objComoConheceu.cd_como_conheceu = oDataTable.Rows(0).Item("cd_como_conheceu")
        objSchema.objDadosAdicionais.objComoConheceu.dc_como_conheceu = oDataTable.Rows(0).Item("dc_como_conheceu").ToString
        objSchema.objDadosAdicionais.no_contato = oDataTable.Rows(0).Item("no_contato").ToString.ToString
        objSchema.objDadosAdicionais.dc_servicos = oDataTable.Rows(0).Item("dc_servicos").ToString.ToString
        objSchema.objDadosAdicionais.dc_materiais = oDataTable.Rows(0).Item("dc_materiais").ToString.ToString
    End Sub

#Region "EnviaEmailRecuperaChave"
    Public Function EnviaEmailRecuperaChave(sCNPJ As String, sEmail As String, sChaveAcesso As String) As Boolean
        Dim objSTL As STL.STLBase = New STL.STLBase()
        Dim objCont As DAL.dalSolicitacaoCadastro = Nothing
        Dim sSMTPeMail As String = ""
        Dim sNomeDestinatario As String = ""
        Dim seMailDestinatario As String = ""
        Dim seMailRemetente As String = ""
        Dim sNomeRemetente As String = ""
        Dim sAssuntoEmail As String = ""
        Dim sNBSP As String = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"

        EnviaEmailRecuperaChave = True
        Try
            Try
                Dim oSchConfiguracao As ShL.schConfiguracao = BLL.bllConfiguracao.getConfiguracao
                If Not oSchConfiguracao.xx_envia_email_retorno_solicitacao_cadastro Then
                    Exit Function
                End If

                sSMTPeMail = oSchConfiguracao.xx_servidor_smtp
                seMailDestinatario = sEmail
                sNomeDestinatario = ""
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
            Mailmsg.Body += "Prezado Fornecedor, <BR \>"
            Mailmsg.Body += "</P>"

            Mailmsg.Body += "<p><span style='font-size:10.0pt;line-height:115%;font-family:""Verdana"",""sans-serif""'>"
            Mailmsg.Body += sNBSP & "Segue Chave de Acesso conforme solicitado.<BR \>"
            Mailmsg.Body += sNBSP & "CNPJ: <B>" & sCNPJ & "</B><BR \>"
            Mailmsg.Body += sNBSP & "Chave de Acesso: <B>" & sChaveAcesso & "</B><BR \>"
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
                EnviaEmailRecuperaChave = False
                Dim erro As New Exception("Houve um problema ao enviar seu email. Tente Novamente.")
                Throw erro
            End Try
            Mailmsg.Attachments.Dispose()
            Mailmsg.Dispose()

        Catch ex As Exception
            EnviaEmailRecuperaChave = False
            Dim erro As New Exception("Houve um problema ao enviar seu email. Tente Novamente.")
            Throw erro
        End Try
    End Function

#End Region

End Class
