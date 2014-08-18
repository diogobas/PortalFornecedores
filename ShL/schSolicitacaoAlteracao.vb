Public Class schSolicitacaoAlteracao
    Inherits schBase

    Public id_solicitacao As Int32 = Nothing
    Public dt_solicitacao As DateTime = Nothing
    Public objStatus As schStatus = New schStatus
    Public dt_atualizacao As DateTime = Nothing
    Public cd_usuario_atualizacao As String = String.Empty
    Public objDadosBasicos As New ShL.schFornecedorDadosBasicos
    Public objContato As New ShL.schFornecedorContato
    Public objDadosAdicionais As New ShL.schFornecedorDadosAdicionais

End Class
