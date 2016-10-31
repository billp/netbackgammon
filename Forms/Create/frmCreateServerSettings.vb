Imports System.Threading
Imports System.Text.RegularExpressions

Public Class frmCreateServerSettings
    Public Shared loaded As Boolean = False

    Private Sub frmCreateServerSettings_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtPortNumber.Text = My.Settings.ServerPort

        txtLocalIp.Text = TCPIP.localIP

        'checkFields()

        Dim retrieveAddressThread As New Thread(AddressOf setRemoteIpAddress)
        retrieveAddressThread.Start()

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        My.Settings.ServerPort = CInt(txtPortNumber.Text)
        My.Settings.Save()
        Me.Close()
    End Sub

    Private Sub setRemoteIpAddress()
        'set the  remote ip address
        AsyncUpdate.TextBox.setText(txtRemoteIp, "retrieving...")

        Try
            AsyncUpdate.setText(txtRemoteIp, TCPIP.retrieveRemoteIpV4)
        Catch er As Net.WebException
            AsyncUpdate.TextBox.setText(txtRemoteIp, "n/a")
        End Try

    End Sub

    Private Sub btnCopyAllServerInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopyAllServerInfo.Click
        Clipboard.SetText("Local IP: " & txtLocalIp.Text & ", Remote IP: " & txtRemoteIp.Text & ", Port: " & txtPortNumber.Text)
    End Sub

    Private Sub checkFields()
        If Not Regex.IsMatch(txtPortNumber.Text, "^[0-9]+$") Then
            btnSave.Enabled = False
            Exit Sub
        End If

        Try
            'elegxos gia to katallhlo port range
            If CInt(txtPortNumber.Text) < 0 Or CInt(txtPortNumber.Text) > 65535 Then
                btnSave.Enabled = False
                Exit Sub
            End If
        Catch e As Exception
        End Try

        btnSave.Enabled = True
    End Sub

    Private Sub txtPortNumber_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPortNumber.TextChanged
        checkFields()
    End Sub

End Class