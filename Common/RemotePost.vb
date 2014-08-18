Public Class RemotePost

    Private Inputs As System.Collections.Specialized.NameValueCollection = New System.Collections.Specialized.NameValueCollection

    Public Url As String = ""

    Public Method As String = "post"

    Public FormName As String = "form1"

    Public Sub Add(ByVal name As String, ByVal value As String)
        Inputs.Add(name, value)
    End Sub

    Public Sub Post()
        System.Web.HttpContext.Current.Response.Clear()
        System.Web.HttpContext.Current.Response.Write("")
        System.Web.HttpContext.Current.Response.Write(String.Format("", FormName))
        System.Web.HttpContext.Current.Response.Write(String.Format("", FormName, Method, Url))
        Dim i As Integer = 0
        Do While (i < Inputs.Keys.Count)
            System.Web.HttpContext.Current.Response.Write(String.Format("", Inputs.Keys(i), Inputs(Inputs.Keys(i))))
            i = (i + 1)
        Loop
        System.Web.HttpContext.Current.Response.Write("")
        System.Web.HttpContext.Current.Response.Write("")
        System.Web.HttpContext.Current.Response.End()
    End Sub
End Class

