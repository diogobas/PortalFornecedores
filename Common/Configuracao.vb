Imports System
'Módulo com funções genéricas principalmente de acesso ao arquivo de conficuração da aplicação
Public Module Configuracao
    Private strKey As String = "Br@z1lH3x@C@mp3@0"

    Public Function getCKey() As String
        Return strKey
    End Function

    Public Function getSqlConnection() As String
        Dim app As New System.Configuration.AppSettingsReader
        Dim strRetorno As String = ""
        Try
            'strRetorno = Common.Criptografia.Decifrar(CStr(app.GetValue("SqlConnection", GetType(System.String))), getCKey())
            strRetorno = CStr(app.GetValue("SqlConnection", GetType(System.String)))
            Return strRetorno
        Finally
            strRetorno = Nothing
        End Try
    End Function
    Public Function getAppPath() As String
        Dim app As New System.Configuration.AppSettingsReader
        Dim strRetorno As String = CType(app.GetValue("JBAppPath", GetType(System.String)), String)
        Try
            Return strRetorno
        Finally
            strRetorno = Nothing
        End Try

    End Function
    Public Function getLogPath() As String
        Dim app As New System.Configuration.AppSettingsReader
        Dim strRetorno As String = CType(app.GetValue("JBLogPath", GetType(System.String)), String)
        Try
            Return strRetorno
        Finally
            strRetorno = Nothing
        End Try
    End Function

    Public Function showTechError() As Boolean
        Dim app As New System.Configuration.AppSettingsReader
        Return CBool(app.GetValue("showTechError", GetType(System.Int32)))
    End Function

    Public Function getManutencao() As Boolean
        Dim app As New System.Configuration.AppSettingsReader
        Return CBool(app.GetValue("manutencao", GetType(System.Int32)))
    End Function

    Public Function getGravaContatoBD() As Boolean
        Dim app As New System.Configuration.AppSettingsReader
        Return CBool(app.GetValue("GravaContatoBD", GetType(System.Int32)))
    End Function

    Public Function getSMTPeMail() As String
        Dim app As New System.Configuration.AppSettingsReader
        Dim strRetorno As String = CType(app.GetValue("SMTPeMail", GetType(System.String)), String)
        Try
            Return strRetorno
        Finally
            strRetorno = Nothing
        End Try
    End Function

    Public Function geteMailRemetente() As String
        Dim app As New System.Configuration.AppSettingsReader
        Dim strRetorno As String = CType(app.GetValue("eMailRemetente", GetType(System.String)), String)
        Try
            Return strRetorno
        Finally
            strRetorno = Nothing
        End Try
    End Function

    Public Function getNomeRemetente() As String
        Dim app As New System.Configuration.AppSettingsReader
        Dim strRetorno As String = CType(app.GetValue("NomeRemetente", GetType(System.String)), String)
        Try
            Return strRetorno
        Finally
            strRetorno = Nothing
        End Try
    End Function

    Public Function geteMailDestinatario() As String
        Dim app As New System.Configuration.AppSettingsReader
        Dim strRetorno As String = CType(app.GetValue("eMailDestinatario", GetType(System.String)), String)
        Try
            Return strRetorno
        Finally
            strRetorno = Nothing
        End Try
    End Function

    Public Function getNomeDestinatario() As String
        Dim app As New System.Configuration.AppSettingsReader
        Dim strRetorno As String = CType(app.GetValue("NomeDestinatario", GetType(System.String)), String)
        Try
            Return strRetorno
        Finally
            strRetorno = Nothing
        End Try
    End Function

    Public Function getAssuntoEMail() As String
        Dim app As New System.Configuration.AppSettingsReader
        Dim strRetorno As String = CType(app.GetValue("AssuntoEMail", GetType(System.String)), String)
        Try
            Return strRetorno
        Finally
            strRetorno = Nothing
        End Try
    End Function

    Public Function getVisaoSite() As String
        Dim app As New System.Configuration.AppSettingsReader
        Dim strRetorno As String = CType(app.GetValue("VisaoSite", GetType(System.String)), String)
        Try
            Return strRetorno
        Finally
            strRetorno = Nothing
        End Try
    End Function
End Module
