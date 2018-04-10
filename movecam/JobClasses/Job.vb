Public Class Job

    Private _filePath As String

    Public Property FilePath As String
        Get
            Return _filePath
        End Get
        Set(value As String)
            _filePath = value
        End Set
    End Property

    Public Sub New(fp As String)
        Me.FilePath = fp
    End Sub
End Class
