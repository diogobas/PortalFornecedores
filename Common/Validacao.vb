Public Class Validacao
    Private dadosArray() As String = {"111.111.111-11", "222.222.222-22", "333.333.333-33", "444.444.444-44", _
                                        "555.555.555-55", "666.666.666-66", "777.777.777-77", "888.888.888-88", "999.999.999-99"}
    Private Const msgErro As String = "Dados Inválidos"
    Private bValida As Boolean
    Private sCPF As String
    Private sCNPJ As String
    Private sCEP As String
    Private sINSS As String
    Public Property cpf() As String
        Get
            Return sCPF
        End Get
        Set(ByVal Valor As String)
            bValida = ValidaCPF(Valor)
            If bValida Then
                sCPF = Valor
            Else
                Throw (New System.ArgumentException(msgErro, "Numero do CPF"))
            End If
        End Set
    End Property
    Public ReadOnly Property isCpfValido() As Boolean
        Get
            bValida = ValidaCPF(cpf)
            If bValida Then
                Return True
            Else
                Return False
            End If
        End Get
    End Property
    Public Property cnpj() As String
        Get
            Return sCNPJ
        End Get
        Set(ByVal Valor As String)
            bValida = ValidaCNPJ(Valor)
            If bValida Then
                sCNPJ = Valor
            Else
                Throw (New System.ArgumentException(msgErro, "Numero do CNPJ"))
            End If
        End Set
    End Property
    Public Property cep() As String
        Get
            Return sCEP
        End Get
        Set(ByVal Valor As String)
            bValida = ValidaCEP(Valor)
            If bValida Then
                sCEP = Valor
            Else
                Throw (New System.ArgumentException(msgErro, "Numero do CEP"))
            End If
        End Set
    End Property

    Public Property inss() As String
        Get
            Return sINSS
        End Get
        Set(ByVal Valor As String)
            bValida = ValidaINSS(Valor)
            If bValida Then
                sINSS = Valor
            Else
                Throw (New System.ArgumentException(msgErro, "Numero do INSS"))
            End If
        End Set
    End Property

    Public ReadOnly Property isCnpjValido() As Boolean
        Get
            bValida = ValidaCNPJ(cnpj)
            If bValida Then
                Return True
            Else
                Return False
            End If
        End Get
    End Property
    Private Function ValidaCPF(ByVal CPF As String) As Boolean

        Dim i, x, n1, n2 As Integer

        CPF = CPF.Trim

        If CPF = "00000000000" Or CPF = "11111111111" Or CPF = "22222222222" Or CPF = "33333333333" Or CPF = "44444444444" _
        Or CPF = "55555555555" Or CPF = "66666666666" Or CPF = "77777777777" Or CPF = "88888888888" Or CPF = "99999999999" Then
            Return False
        End If


        For i = 0 To dadosArray.Length - 1
            If CPF.Length <> 14 Or dadosArray(i).Equals(CPF) Then
                Return False
            End If
        Next

        'remove a maskara
        CPF = CPF.Substring(0, 3) + CPF.Substring(4, 3) + CPF.Substring(8, 3) + CPF.Substring(12)

        For x = 0 To 1
            n1 = 0

            For i = 0 To 8 + x
                n1 = n1 + Val(CPF.Substring(i, 1)) * (10 + x - i)
            Next

            n2 = 11 - (n1 - (Int(n1 / 11) * 11))

            If n2 = 10 Or n2 = 11 Then n2 = 0

            If n2 <> Val(CPF.Substring(9 + x, 1)) Then
                Return False
            End If

        Next

        Return True

    End Function
    Private Function ValidaCNPJ(ByVal CNPJ As String) As Boolean

        Dim i As Integer
        Dim valida As Boolean

        CNPJ = CNPJ.Trim

        For i = 0 To dadosArray.Length - 1
            If CNPJ.Length <> 18 Or dadosArray(i).Equals(CNPJ) Then
                Return False
            End If
        Next

        'remove a maskara
        CNPJ = CNPJ.Substring(0, 2) + CNPJ.Substring(3, 3) + CNPJ.Substring(7, 3) + CNPJ.Substring(11, 4) + CNPJ.Substring(16)
        valida = efetivaValidacao(CNPJ)

        If valida Then
            ValidaCNPJ = True
        Else
            ValidaCNPJ = False
        End If

    End Function
    Private Function efetivaValidacao(ByVal cnpj As String)
        Dim Numero(13) As Integer
        Dim soma As Integer
        Dim i As Integer
        Dim resultado1 As Integer
        Dim resultado2 As Integer

        If cnpj = "00000000000000" Or cnpj = "11111111111111" Or cnpj = "22222222222222" Or cnpj = "33333333333333" Or cnpj = "44444444444444" _
        Or cnpj = "55555555555555" Or cnpj = "66666666666666" Or cnpj = "77777777777777" Or cnpj = "88888888888888" Or cnpj = "99999999999999" Then
            Return False
        End If

        For i = 0 To Numero.Length - 1
            Numero(i) = CInt(cnpj.Substring(i, 1))
        Next

        soma = Numero(0) * 5 + Numero(1) * 4 + Numero(2) * 3 + Numero(3) * 2 + Numero(4) * 9 + Numero(5) * 8 + Numero(6) * 7 + Numero(7) * 6 + Numero(8) * 5 + Numero(9) * 4 + Numero(10) * 3 + Numero(11) * 2
        soma = soma - (11 * (Int(soma / 11)))
        If soma = 0 Or soma = 1 Then
            resultado1 = 0
        Else
            resultado1 = 11 - soma
        End If

        If resultado1 = Numero(12) Then
            soma = Numero(0) * 6 + Numero(1) * 5 + Numero(2) * 4 + Numero(3) * 3 + Numero(4) * 2 + Numero(5) * 9 + Numero(6) * 8 + Numero(7) * 7 + Numero(8) * 6 + Numero(9) * 5 + Numero(10) * 4 + Numero(11) * 3 + Numero(12) * 2
            soma = soma - (11 * (Int(soma / 11)))
            If soma = 0 Or soma = 1 Then
                resultado2 = 0
            Else
                resultado2 = 11 - soma
            End If
            If resultado2 = Numero(13) Then
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If

    End Function

    Private Function ValidaCEP(ByVal cCep As String) As Boolean

        If Len(cCep) = 9 Then
            Return True
        Else
            Return False
        End If

    End Function

    Private Function ValidaINSS(ByVal cInss As String) As Boolean

        If Len(cInss) = 11 Then
            Return True
        Else
            Return False
        End If

    End Function

End Class