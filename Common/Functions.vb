Public Class Functions

    'Função para converter string em datetime no formato dd/mm/aaaa
    Public Shared Function converteStringToDate(ByVal strString As String) As DateTime
        Dim sdtDateTime As DateTime
        'Dim sdtFormat As New System.Globalization.CultureInfo("pt-br", True)

        ''sdtDateTime = Date.Parse(strString, sdtFormat, System.Globalization.DateTimeStyles.AdjustToUniversal)

        sdtDateTime = Date.ParseExact(strString, "dd/MM/yyyy", New Globalization.CultureInfo("pt-br"))

        Return sdtDateTime

    End Function

    'Função para converter string em double
    Public Shared Function converteStringToDouble(ByVal strString As String) As Double
        Dim result As Double
        Dim sdtFormat As New System.Globalization.CultureInfo("pt-BR", True)

        If strString <> "" Then
            result = Double.Parse(strString, sdtFormat)
        Else
            result = 0.0
        End If

        Return result

    End Function

    Public Sub ExportarDataGrid(ByRef dt As System.Web.UI.WebControls.GridView)

        Dim oResponse As System.Web.HttpResponse = System.Web.HttpContext.Current.Response
        oResponse.Clear()
        oResponse.AddHeader("Content-Disposition", "attachment; filename=Relatorio_" + Guid.NewGuid.ToString + ".xls")
        oResponse.ContentType = "application/vnd.ms-excel"
        Dim stringWrite As New System.IO.StringWriter
        Dim htmlWrite As New System.Web.UI.HtmlTextWriter(stringWrite)
        dt.RenderControl(htmlWrite)
        oResponse.Write(stringWrite.ToString)
        oResponse.End()

    End Sub

    Public Shared Function ValidarEmail(emailaddress As String) As Boolean
        Try
            Dim m As New System.Net.Mail.MailAddress(emailaddress)
            Return True
        Catch generatedExceptionName As FormatException
            Return False
        End Try
    End Function

    Public Shared Function RetiraFormatoCNPJ(sCnpj As String) As String
        Try
            Return sCnpj.Replace(".", "").Replace("-", "").Replace("/", "")
        Catch generatedExceptionName As FormatException
            Return False
        End Try
    End Function

    Public Shared Function DataTableToArray(ByVal oDataTable As Data.DataTable, ByVal sColumn As String, Optional ByVal bIncluirVazio As Boolean = False) As String()
        Dim oRow As Data.DataRow
        Dim oArray(oDataTable.Rows.Count - 1) As String
        Dim i As Int32 = 0
        If bIncluirVazio Then
            ReDim oArray(oDataTable.Rows.Count)
            oArray(0) = ""
            i = 1
        End If
        For Each oRow In oDataTable.Rows
            oArray(i) = Trim(oRow.Item(sColumn).ToString)
            i += 1
        Next
        Return oArray
    End Function

End Class
