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
                strRet = "Sua sess�o expirou ou voc� n�o est� logado.<br>Favor efetuar logon."
            Case Messages.MessageIndex.errLoginFailed
                strRet = "Login e/ou Senha incorreta."
            Case Messages.MessageIndex.errPermissao
                strRet = "Voc� n�o tem permiss�o para acessar esta funcionalidade."
            Case Messages.MessageIndex.errChaveForenkey
                strRet = "Registro n�o pode ser exclu�do, verifique as depend�ncias do mesmo."
            Case Messages.MessageIndex.errPesquisa
                strRet = "Erro ao fazer pesquisa. Tente novamente ou entre em contato com o administrador do sistema."
        End Select

        Return strRet
    End Function

End Class
