Public Class schSolicitacaoCadastro
    Inherits schBase

    Public id_solicitacao As Int32 = Nothing
    Public xx_chave_acesso As String = String.Empty
    Public dt_solicitacao As DateTime = Nothing
    Public objStatus As schStatus = New schStatus
    Public dt_atualizacao As DateTime = Nothing
    Public cd_usuario_atualizacao As String = String.Empty
    Public cd_usuario_solicitacao As String = String.Empty
    Public dc_motivo_recusa As String = String.Empty
    Public objDadosBasicos As New ShL.schSolicitacaoCadastroDadosBasicos
    Public objContato As New ShL.schSolicitacaoCadastroContato
    Public objDadosAdicionais As New ShL.schSolicitacaoCadastroDadosAdicionais

End Class
