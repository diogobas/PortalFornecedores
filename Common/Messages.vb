Public Class Messages
    Public Enum MessageIndex
        errSessionExpired
        errLoginFailed
        errPermissao
        errServer
        errChaveForenkey = 5
        errPesquisa
    End Enum

    Public Shared Function getMessage(ByVal intMsgIndex As Integer) As String
        Dim strRet As String = ""

        Select Case intMsgIndex
            Case Messages.MessageIndex.errSessionExpired
                strRet = "Sua sessão expirou ou você não está logado.<br>Favor efetuar logon."
            Case Messages.MessageIndex.errLoginFailed
                strRet = "Login e/ou Senha incorreta."
            Case Messages.MessageIndex.errPermissao
                strRet = "Você não tem permissão para acessar esta funcionalidade."
            Case Messages.MessageIndex.errChaveForenkey
                strRet = "Registro não pode ser excluído, verifique as dependências do mesmo."
            Case Messages.MessageIndex.errPesquisa
                strRet = "Erro ao fazer pesquisa. Tente novamente ou entre em contato com o administrador do sistema."
        End Select

        Return strRet
    End Function

End Class
