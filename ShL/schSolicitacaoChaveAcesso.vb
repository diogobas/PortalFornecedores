Public Class schSolicitacaoChaveAcesso
    Inherits schBase

    Public id_solicitacao_chave_acesso As Int32 = Nothing
    Public nm_cnpj As String = String.Empty
    Public no_razao_social As String = String.Empty
    Public no_solicitante As String = String.Empty
    Public xx_email As String = String.Empty
    Public dt_solicitacao As DateTime = Nothing
    Public objStatus As schStatus = New schStatus
    Public dt_atualizacao As DateTime = Nothing
    Public cd_usuario_atualizacao As String = String.Empty

    Public xx_chave_acesso As String = String.Empty

End Class
