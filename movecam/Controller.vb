Imports System.Runtime.InteropServices
Imports System.Text

Public Class Controller

    Private Declare Function OpenCnc Lib "ComCnc.dll" (ByVal Com As Integer, ByVal CncType As Integer, ByVal Mode As Integer, ByVal Deb As Integer) As Integer
    Private Declare Function CloseCnc Lib "ComCnc.dll" () As Integer
    Private Declare Function TxCnc Lib "ComCnc.dll" (ByVal Command As String, ByVal Response As String) As Integer
    Private Declare Function SetProtocol Lib "ComCnc.dll" (ByVal NewMode As Integer) As Integer

    Private _online As Boolean
    Private _emulated As Boolean
    Private _log As Boolean

    Private _Xaxis As Axis
    Private _Yaxis As Axis
    Private _Zaxis As Axis

    Private Const GET_CNC_STATE = Chr(1) + vbCr
    Private Const CNC_EXEC_PROG = Chr(3) + vbCr
    Private Const GET_CNC_COORDINATES = Chr(23) + vbCr

    Public Sub test()
        Dim errCode As Integer
        'com1 9600 O 8 1
        errCode = OpenCnc(0, 5, 2, 1)
        'txt_errorCode.Text = Convert.ToString(errCode)
        'If errCode = 0 Then
        'cmd_Send.Enabled = True
        'cmd_Close.Enabled = True
        'cmd_Open.Enabled = False
        'End If
        Dim response As String
        Dim txtErrCode As String
        response = New String(vbNullChar, 130)
        sendCmdNoWait("&01,116")
        sendCmdWaitEnd(CNC_EXEC_PROG)
        sendCmdNoWait("&02")
        sendCmdNoWait("G64,0")
        sendCmdNoWait("G64,0")
        sendCmdNoWait("G1X0F10000")
        sendCmdNoWait("G1X300F25000")
        getCoord()
        sendCmdWaitBefore("G68P32")

        sendCmdNoWait("G64,0")
        sendCmdNoWait("G4F1")
        sendCmdNoWait("G67P32")
        sendCmdNoWait("G1X600")
        sendCmdNoWait("G1Y200")
        sendCmdNoWait("G1X100")
        sendCmdNoWait("G1Y300")
        sendCmdNoWait("G1X600Y400")
        sendCmdNoWait("G1X0Y0")
        CloseCnc()


        txtErrCode = Convert.ToString(errCode)

    End Sub

    Private Function sendCmdSyncro(cmd As String, before As Boolean, after As Boolean) As String
        Dim response As String
        If before Then
            While (cmdIsExecuting())
                Application.DoEvents()
            End While
        End If
        response = sendCmdNoWait(cmd)
        If after Then
            While (cmdIsExecuting())
                Application.DoEvents()
            End While
        End If
        Return response
    End Function
    Private Function sendCmdWaitEnd(cmd As String) As Boolean
        sendCmdSyncro(cmd, False, True)
        Return True
    End Function
    Private Function sendCmdWaitBefore(cmd As String) As Boolean
        sendCmdSyncro(cmd, True, False)
        Return True
        Return True
    End Function

    Private Function sendCmdNoWait(cmd As String) As String
        Dim response As String
        response = New String(vbNullChar, 130)
        If Right(cmd, 1) <> vbCr Then
            TxCnc(cmd + vbCr, response)
        Else
            TxCnc(cmd, response)
        End If
        Return response.ToString
    End Function
    Private Function cmdIsExecuting() As Boolean
        Dim cncResponse As String
        Dim exitCode As Integer

        cncResponse = sendCmdNoWait(GET_CNC_STATE)
        exitCode = Val(Mid(cncResponse, 2))
        Return (exitCode And 32)
    End Function
    Public Function getCoord() As String
        Dim cncResponse As String

        cncResponse = sendCmdNoWait(GET_CNC_COORDINATES)
        Return (cncResponse)
    End Function
End Class
