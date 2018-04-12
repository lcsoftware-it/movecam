Module Configuration
    Private Declare Auto Function GetPrivateProfileString Lib "kernel32" (ByVal lpAppName As String,
            ByVal lpKeyName As String,
            ByVal lpDefault As String,
            ByVal lpReturnedString As StringBuilder,
            ByVal nSize As Integer,
            ByVal lpFileName As String) As Integer

    Sub Main()

        Dim res As Integer
        Dim sb As StringBuilder

        sb = New StringBuilder(500)
        res = GetPrivateProfileString("testApp", "KeyName", "", sb, sb.Capacity, "c:\temp\test.ini")
        Console.WriteLine("GetPrivateProfileStrng returned : " & res.ToString())
        Console.WriteLine("KeyName is : " & sb.ToString())
        Console.ReadLine();

    End Sub
End Module
