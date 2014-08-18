Imports System
Imports System.Security.Cryptography
Imports System.IO
Imports System.Text
Imports System.Math


Public Class Criptografia
    '   *********************************************************************
    '   ***** Função responsável por Cifrar a sua String                *****
    '   ***** Use da seguinte forma:                                    *****
    '   ***** Call Cifrar("Palavra", "SuaChaveSecreta(Ex.2345)")        *****
    '   *********************************************************************

    Public Shared Function Cifrar(ByVal vstrTextToBeEncrypted As String, ByVal vstrEncryptionKey As String) As String

        Dim bytValue() As Byte
        Dim bytKey() As Byte
        Dim bytEncoded() As Byte = Nothing
        Dim bytIV() As Byte = {121, 241, 10, 1, 132, 74, 11, 39, 255, 91, 45, 78, 14, 211, 22, 62}
        Dim intLength As Integer
        Dim intRemaining As Integer
        Dim objMemoryStream As New MemoryStream
        Dim objCryptoStream As CryptoStream
        Dim objRijndaelManaged As RijndaelManaged


        '   **********************************************************************
        '   ****** Descarta todos os caracteres nulos da palavra a ser cifrada****  
        '   **********************************************************************

        vstrTextToBeEncrypted = TiraCaracteresNulos(vstrTextToBeEncrypted)

        '   **********************************************************************
        '   ******  O valor deve estar dentro da tabela ASCII (i.e., no DBCS chars)
        '   **********************************************************************

        bytValue = Encoding.ASCII.GetBytes(vstrTextToBeEncrypted.ToCharArray)

        intLength = Len(vstrEncryptionKey)

        '   ********************************************************************
        '   ******   A chave cifrada será de 256 bits long (32 bytes)     ******
        '   ******   Se for maior que 32 bytes então será truncado.       ******
        '   ******   Se for menor que 32 bytes será alocado.              ******
        '   ******   Usando upper-case Xs.                                ****** 
        '   ********************************************************************

        If intLength >= 32 Then
            vstrEncryptionKey = Strings.Left(vstrEncryptionKey, 32)
        Else
            intLength = Len(vstrEncryptionKey)
            intRemaining = 32 - intLength
            vstrEncryptionKey = vstrEncryptionKey & Strings.StrDup(intRemaining, "X")
        End If

        bytKey = Encoding.ASCII.GetBytes(vstrEncryptionKey.ToCharArray)

        objRijndaelManaged = New RijndaelManaged

        '   ***********************************************************************
        '   ******  Cria o valor a ser crifrado e depois escreve             ******
        '   ******  Convertido em uma disposição do byte                     ******
        '   ***********************************************************************

        Try

            objCryptoStream = New CryptoStream(objMemoryStream, objRijndaelManaged.CreateEncryptor(bytKey, bytIV), CryptoStreamMode.Write)
            objCryptoStream.Write(bytValue, 0, bytValue.Length)

            objCryptoStream.FlushFinalBlock()

            bytEncoded = objMemoryStream.ToArray
            objMemoryStream.Close()
            objCryptoStream.Close()
        Catch

        End Try

        '   ***********************************************************************
        '   ****** Retorna o valor cifrado (convertido de byte para base64 )  *****
        '   ***********************************************************************

        Return Convert.ToBase64String(bytEncoded)

    End Function

    '   *********************************************************************
    '   ***** Função Responsável por Decifrar a sua String Cifrada       *****
    '   ***** Use da seguinte forma:                                    *****
    '   ***** Call Decifrar("Palavra", "SuaChaveSecreta(Ex.2345)")      *****
    '   *********************************************************************
    Public Shared Function Decifrar(ByVal vstrStringToBeDecrypted As String, ByVal vstrDecryptionKey As String) As String

        Dim bytDataToBeDecrypted() As Byte
        Dim bytTemp() As Byte
        Dim bytIV() As Byte = {121, 241, 10, 1, 132, 74, 11, 39, 255, 91, 45, 78, 14, 211, 22, 62}
        Dim objRijndaelManaged As New RijndaelManaged
        Dim objMemoryStream As MemoryStream
        Dim objCryptoStream As CryptoStream
        Dim bytDecryptionKey() As Byte

        Dim intLength As Integer
        Dim intRemaining As Integer
        Dim strReturnString As String = String.Empty

        '   *****************************************************************
        '   ******   Convert base64 cifrada para byte array            ******
        '   ******   Convert base64 cifrada para byte array            ******
        '   *****************************************************************

        bytDataToBeDecrypted = Convert.FromBase64String(vstrStringToBeDecrypted)

        '   ********************************************************************
        '   ******   A chave cifrada sera de 256 bits long (32 bytes)     ******
        '   ******   Se for maior que 32 bytes então será truncado.       ******
        '   ******   Se for menor que 32 bytes será alocado.              ******
        '   ******   Usando upper-case Xs.                                ****** 
        '   ********************************************************************

        intLength = Len(vstrDecryptionKey)

        If intLength >= 32 Then
            vstrDecryptionKey = Strings.Left(vstrDecryptionKey, 32)
        Else
            intLength = Len(vstrDecryptionKey)
            intRemaining = 32 - intLength
            vstrDecryptionKey = vstrDecryptionKey & Strings.StrDup(intRemaining, "X")
        End If

        bytDecryptionKey = Encoding.ASCII.GetBytes(vstrDecryptionKey.ToCharArray)

        ReDim bytTemp(bytDataToBeDecrypted.Length)

        objMemoryStream = New MemoryStream(bytDataToBeDecrypted)

        '   ***********************************************************************
        '   ******  Escrever o valor decifrado depois que é convertido       ******
        '   ***********************************************************************

        Try

            objCryptoStream = New CryptoStream(objMemoryStream, _
               objRijndaelManaged.CreateDecryptor(bytDecryptionKey, bytIV), _
               CryptoStreamMode.Read)

            objCryptoStream.Read(bytTemp, 0, bytTemp.Length)

            objCryptoStream.FlushFinalBlock()
            objMemoryStream.Close()
            objCryptoStream.Close()

        Catch

        End Try

        '   ***********************************************************************
        '   ******  Retorna o valor decifrado                                ******
        '   ***********************************************************************

        Return TiraCaracteresNulos(Encoding.ASCII.GetString(bytTemp))

    End Function

    '   *********************************************************************
    '   ***** Função responvel por tirar os espaços em branco da        *****
    '   ***** variável a ser cifrada                                    *****
    '   ***** Esta função é chamada internamente                        *****
    '   *********************************************************************

    Public Shared Function TiraCaracteresNulos(ByVal vstrStringWithNulls As String) As String

        Dim intPosition As Integer
        Dim strStringWithOutNulls As String

        intPosition = 1
        strStringWithOutNulls = vstrStringWithNulls

        Do While intPosition > 0
            intPosition = InStr(intPosition, vstrStringWithNulls, vbNullChar)

            If intPosition > 0 Then
                strStringWithOutNulls = Left$(strStringWithOutNulls, intPosition - 1) & _
                                  Right$(strStringWithOutNulls, Len(strStringWithOutNulls) - intPosition)
            End If

            If intPosition > strStringWithOutNulls.Length Then
                Exit Do
            End If
        Loop

        Return strStringWithOutNulls

    End Function

    Public Shared Function Dec2Bin(ByVal DecNum As Integer) As String
        Dim DivNum As Integer

        If (DecNum = 0) Then
            Return ""
        End If

        'Establish how many divisions will be done, +1 for number rounding        
        DivNum = CInt(Log(DecNum) / (Log(2)) + 1)

        'Create array with number of columns needed according to 'DivNum'       
        Dim BinNums(DivNum, 2) As Integer

        'Assign 'DecNum' to column 1, row 0 of array       
        BinNums(0, 1) = CInt(DecNum)
        Dim RowNum As Integer = 1

        'Divisions loop counter        
        Dim RevBinNum As String = ""

        'Calculate divisions       
        For RowNum = 1 To UBound(BinNums)
            'To highest subscript of array            
            'Divide previous value by 2            
            BinNums(RowNum, 1) = CInt(BinNums(RowNum - 1, 1) \ 2)
            'Calculate modulus            
            BinNums(RowNum, 2) = CInt(BinNums(RowNum - 1, 1) Mod 2)
            'Make binary number string           
            RevBinNum &= CStr(BinNums(RowNum, 2))
        Next
        Dim FinalBinNum As String

        'Assign string to 'RevBinNum'" (reverse the string, as the binary number is backwards)        
        FinalBinNum = StrReverse(RevBinNum)

        'Remove leading zeros        
        FinalBinNum = FinalBinNum.TrimStart("0"c)

        'Output binary number     
        Return FinalBinNum

    End Function
    Public Shared Function Bin2Dec(ByVal Num As String) As Integer
        Dim n As Integer
        Dim a As Integer
        Dim iRet As Integer
        Dim x As String
        n = Num.Length - 1
        a = n
        Do While n > -1
            x = Mid(Num, ((a + 1) - n), 1)
            iRet = CInt(IIf((x = "1"), iRet + (2 ^ (n)), iRet))
            n = n - 1
        Loop
        Return iRet
    End Function
End Class
