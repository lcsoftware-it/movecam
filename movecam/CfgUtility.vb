Imports System.Globalization


Module CfgUtility

    Private Function valFromString(str As String) As String
        'opera su stringhe di formato <key>=<value>, restituisce la sola parte <value> di tipo stringa
        Return Mid(str, InStr(str, "=") + 1)
    End Function
    Public Function doubleFromConfig(str As String) As Double
        'opera su stringhe di formato <key>=<value>, restituisce la sola parte <value> di tipo double
        Return CDbl(Replace(valFromString(str), ",", NumberFormatInfo.CurrentInfo.NumberDecimalSeparator))
    End Function
    Public Function intFromConfig(str As String) As Integer
        'opera su stringhe di formato <key>=<value>, restituisce la sola parte <value> di tipo int
        Return CInt(valFromString(str))
    End Function
    Public Function booleanFromConfig(str As String) As Boolean
        'opera su stringhe di formato <key>=<value>, restituisce la sola parte <value> di tipo boolean
        Return UCase(str) = "TRUE" Or str = "1"
    End Function
    Public Function colorFromConfig(row As String) As Color
        'opera su stringhe di formato <key>=<value>, restituisce la sola parte <value> di tipo Color
        Dim v As String
        Dim r As Integer
        Dim g As Integer
        Dim b As Integer
        Dim pos As Integer

        v = valFromString(row)
        r = CInt(v)
        pos = InStr(row, ",")
        g = CInt(Mid(row, pos + 1))
        pos = InStr(pos + 1, row, ",")
        b = CInt(Mid(row, pos + 1))

        Return Color.FromArgb(0, r, g, b)
    End Function

End Module
