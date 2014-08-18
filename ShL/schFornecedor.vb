Public Class schFornecedor
    Inherits schBase

    Public nm_cnpj As String = String.Empty
    Public xx_chave_acesso As String = String.Empty
    Public dt_geracao As DateTime = Nothing
    Public objStatus As schStatus = New schStatus
    Public dt_atualizacao As DateTime = Nothing
    Public cd_usuario_atualizacao As String = String.Empty
    Public objDadosBasicos As New ShL.schFornecedorDadosBasicos
    Public objContato As New ShL.schFornecedorContato
    Public objDadosAdicionais As New ShL.schFornecedorDadosAdicionais

End Class
