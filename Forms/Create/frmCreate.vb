Imports System.Text.RegularExpressions
Imports System.Threading
Imports System.Net.Sockets

Public Class frmCreate
    Private checkerColor As String
    Public serverThread As CallBackThread
    Public serverThreadAbort As Boolean


    Private Sub pbChkWhite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbChkWhite.Click
        pbChkWhite.BorderStyle = BorderStyle.Fixed3D
        pbChkBlack.BorderStyle = BorderStyle.None
        checkerColor = "white"

        checkFields()
    End Sub


    Private Sub txtNickname_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNickname.TextChanged
        checkFields()
    End Sub
    Private Sub txtWins_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtWins.TextChanged
        checkFields()
    End Sub
    Private Sub txtRoundTime_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRoundTime.TextChanged
        checkFields()
    End Sub


    Private Sub pbChkBlack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbChkBlack.Click
        pbChkWhite.BorderStyle = BorderStyle.None
        pbChkBlack.BorderStyle = BorderStyle.Fixed3D
        checkerColor = "black"

        checkFields()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub checkFields()

        If txtNickname.Text = "" Or Not Regex.IsMatch(txtWins.Text, "^[0-9]+") _
                Or Not Regex.IsMatch(txtRoundTime.Text, "^[0-9]+") Or checkerColor Is Nothing Then

            btnCreate.Enabled = False
            Exit Sub
        End If

        If CInt(txtWins.Text) = 0 Then
            btnCreate.Enabled = False
            Exit Sub
        End If

        'na min mporei na valei < 20 defterolepta
        If CInt(txtRoundTime.Text) < 20 Then
            btnCreate.Enabled = False
            Exit Sub
        End If

        btnCreate.Enabled = True
    End Sub


    Private Sub frmCreate_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        frmMain.Show()
    End Sub

    Private Sub frmCreate_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'set the local ip address
        TCPIP.localIP = TCPIP.retrieveLocalIpV4()

        txtNickname.Text = My.Settings.ServerNickname
        txtWins.Text = My.Settings.ServerWins
        txtRoundTime.Text = My.Settings.ServerRoundTime
    End Sub

    Private Sub btnServerSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnServerSettings.Click
        frmCreateServerSettings.Show()
    End Sub

    Private Sub btnCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreate.Click
        My.Settings.ServerNickname = txtNickname.Text
        My.Settings.ServerWins = CInt(txtWins.Text)
        My.Settings.ServerRoundTime = CInt(txtRoundTime.Text)
        Board.roundTime = My.Settings.ServerRoundTime
        My.Settings.Save()

        frmCreateWaitingForConnectionDialog.Show()

        serverThread = New CallBackThread(Me, AddressOf startServer, AddressOf startSterverCallback)
        serverThread.Start()

        Me.Hide()

    End Sub


    Private Sub startServer()
        Dim tcpServer As TCPListener

        Board.tcpConnection = New TCPIP(TCPIP.localIP, My.Settings.ServerPort, "server")
        tcpServer = Board.tcpConnection.getTCPServer

        While True
            If tcpServer.Pending Then
                Dim tcpClient As TcpClient = tcpServer.AcceptTcpClient()
                Board.tcpConnection.setTCPStream(tcpClient.GetStream)

                'Console.WriteLine("connected")
                'Exit While

                If Protocol.checkConnection() Then
                    Protocol.sendServerResponse("success")
                    Exit While
                Else
                    'Board.tcpConnection.sendData("<init><status>fail</status><version>" & my.Application.Info.Version.ToString & </version></init>")
                    Protocol.sendServerResponse("fail")
                    Board.tcpConnection.getTCPStream.Close()
                End If
            End If
        End While

        Thread.Sleep(100)

        'Dhmiourgw ton player
        Board.localPlayer = New Player(My.Settings.ServerNickname, checkerColor, "server")

        'Stelnw ton player (server) ston o client
        Protocol.sendPlayer(Board.localPlayer)
        Thread.Sleep(100)

        'Stelnw tis epipleon ry8miseis (boardSettings) pou orise o server 
        Board.wins = My.Settings.ServerWins
        Protocol.sendBoardSettings(My.Settings.ServerWins, My.Settings.ServerRoundTime)


        'apo8hkeush tou client Player
        Board.remotePlayer = Protocol.getPlayer()

        'close the form
        serverThread.UpdateUI("success")
    End Sub

    Private Sub startSterverCallback(ByRef msg As Object)
        If CType(msg, String) = "success" Then
            frmCreateWaitingForConnectionDialog.Close()
            frmBoard.Show()
        ElseIf CType(msg, String) = "abort" Then
            serverThread.Dispose()
            Board.tcpConnection.close()
            Board.tcpConnection = Nothing
            frmCreateWaitingForConnectionDialog.Close()
            Me.Show()
            Me.Activate()
        End If
    End Sub
End Class