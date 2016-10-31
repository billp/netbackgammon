Imports System.Text.RegularExpressions

Public Class frmJoin
    Private connectErrorCheck = False

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
        frmMain.Show()
    End Sub


    Private Sub frmJoin_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtNickname.Text = My.Settings.ClientNickname
        txtServerIp.Text = My.Settings.ClientIp
        txtPortNumber.Text = My.Settings.ClientPort


        'error handler
        AddHandler TCPIP.tcpConnectError, AddressOf connectError
    End Sub

    Private Sub btnJoin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnJoin.Click
        My.Settings.ClientNickname = txtNickname.Text
        My.Settings.ClientIp = txtServerIp.Text
        My.Settings.ClientPort = txtPortNumber.Text
        My.Settings.Save()

        Board.tcpConnection = New TCPIP(My.Settings.ClientIp, My.Settings.ClientPort, "client")

        If connectErrorCheck Then
            connectErrorCheck = False
            Exit Sub
        End If

        'Ksekinaw thn syndehs me ton server
        Protocol.sendConnectRequest()

        Dim serverResponse As String() = Protocol.getServerResponse
        Dim serverStatus As String = serverResponse(0)
        Dim serverVersion As String = serverResponse(1)

        If serverStatus = "fail" Then
            MsgBox("Incompatible versions: " & vbCrLf & " -server: " & serverVersion & vbCrLf _
                                                     & " -client: " & My.Application.Info.Version.ToString.ToString, _
                                                     MsgBoxStyle.Information)

            Exit Sub
        End If

        'Lamvanw ton player apo ton server
        Board.remotePlayer = Protocol.getPlayer()

        'lamvanw ta board settings
        Dim bSettings() As Integer = Protocol.getBoardSettings()

        'orizw tis nikes
        Board.wins = bSettings(0)
        'orizw ton xrono ka8e gyrou
        Board.roundTime = bSettings(1)

        'orizw ton remote player
        'Board.remotePlayer = CType(response(2), Player)

        'epilegw to xrwma tou client (vasei tou xrwmatos pou epele3e o server)
        Dim checkerColor = If(Board.remotePlayer.getColor = "white", "black", "white")

        'dhmiourgia tou paixth
        Board.localPlayer = New Player(My.Settings.ClientNickname, checkerColor, "client")

        'apostolh tou client ston server
        Protocol.sendPlayer(Board.localPlayer)

        Me.Close()

        frmBoard.Show()

    End Sub

    Private Sub checkFields()
        If txtNickname.Text = "" Then
            btnJoin.Enabled = False
            Exit Sub
        End If

        If Not Regex.IsMatch(txtServerIp.Text, "^([0-9]{1,3}\.){3}[0-9]{1,3}$") Then
            btnJoin.Enabled = False
            Exit Sub
        End If
        If Not Regex.IsMatch(txtPortNumber.Text, "^[0-9]+$") Then
            btnJoin.Enabled = False
            Exit Sub
        End If

        'elegxos gia to katallhlo port range
        If CInt(txtPortNumber.Text) < 0 Or CInt(txtPortNumber.Text) > 65535 Then
            btnJoin.Enabled = False
            Exit Sub
        End If

        btnJoin.Enabled = True
    End Sub

    Private Sub txtPortNumber_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPortNumber.TextChanged
        checkFields()
    End Sub

    Private Sub txtServerIp_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtServerIp.TextChanged
        checkFields()
    End Sub

    Public Sub connectError(ByVal errMsg As String)
        connectErrorCheck = True
        Console.WriteLine(errMsg)
        MsgBox(errMsg, MsgBoxStyle.Exclamation, "Unable to connect!")
    End Sub

    Private Sub txtNickname_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNickname.TextChanged
        checkFields()
    End Sub
End Class