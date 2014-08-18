'Classe base para as classes de schema.
Public Class schBase

    Public Function Clone() As schBase
        Return DirectCast(Me.MemberwiseClone(), schBase)
    End Function


End Class
