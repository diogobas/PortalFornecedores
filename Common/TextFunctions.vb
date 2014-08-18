Imports System
Imports System.IO

Interface ITextFunctionsCOM
    Sub EscreveTexto(ByRef pNomeArquivo As String, ByRef pTexto As String)
End Interface

Public Class TextW
    Implements ITextFunctionsCOM
    Public Sub EscreveTexto(ByRef pNomeArquivo As String, ByRef pTexto As String) Implements ITextFunctionsCOM.EscreveTexto
        TextFunctions.EscreveTexto(pNomeArquivo, pTexto)
    End Sub
End Class

Public Class TextFunctions

    Public Shared Sub EscreveTexto(ByRef pNomeArquivo As String, ByRef pTexto As String)
        'Este procedimento ser� utilizado para gerar o arquivo de Jogo e Tamb�m de LOG
        Dim strmWriter As StreamWriter

        'Testar se o Arquivo existe
        If Not File.Exists(pNomeArquivo) Then
            strmWriter = File.CreateText(pNomeArquivo)
        Else
            strmWriter = File.AppendText(pNomeArquivo)
        End If

        Try
            strmWriter.WriteLine(pTexto)
            strmWriter.Flush()
            strmWriter.Close()
        Catch ex As Exception
            strmWriter.Close()
        End Try

        strmWriter = Nothing
    End Sub

    Public Shared Function trataUrl(ByVal strUrl As String) As String
        'Esta fun��o devolve o nome da url atual sem a extens�o e sem o prefixo, "pgn" ou "frm"
        Dim posIni As Integer
        Dim posFim As Integer
        Dim tmpStr As String


        posFim = InStrRev(strUrl, ".aspx") - 1
        tmpStr = strUrl.Substring(0, posFim)
        posIni = InStrRev(tmpStr, "/")
        tmpStr = Mid(tmpStr, posIni + 4)
        strUrl = Mid(tmpStr, 1, posFim)
        Return strUrl
    End Function
End Class
