Imports System.Threading
Imports System.Net

Public Class frmMain
    Private checkForUpdateThread As CallBackThread
    Private updResponse As String

    Private Sub btnAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbout.Click
        frmAbout.ShowDialog()
    End Sub

    Private Sub btnCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreate.Click
        Me.Hide()

        'orizw ton player
        'Dim player As New Player("Maria", 0, "white", "server")
        'Board.localPlayer = player
        'Board.controlledBy = player
        frmCreate.Show()
        'frmBoard.Show()
    End Sub

    Private Sub frmMain_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        End
    End Sub

    Private Sub frmMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ctrls() = {btnCreate, btnJoin, btnAbout, btnExit}
        For Each ctr As Control In ctrls
            ctr.Parent = pbBackground
        Next

        Me.Text = My.Application.Info.Title & " v" & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor
        checkForUpdateThread = New CallBackThread(Me, AddressOf checkForUpdateWork, AddressOf checkForUpdateCb)
        'elegxos gia update
        checkForUpdateThread.Start()

        Me.Activate()
    End Sub

    Private Sub btnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnJoin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnJoin.Click
        Me.Hide()

        'orizw ton player
        'Dim player As New Player("Lelos", 0, "black", "client")
        'Board.localPlayer = player
        'Board.controlledBy = player
        'frmBoard.Show()
        frmJoin.Show()
    End Sub

    Private Sub checkForUpdateWork()
        Dim wc As WebClient = New WebClient()

        Try

            updResponse = wc.DownloadString("http://aetos.it.teithe.gr/~vpanag/netbackgammon/update.php?v=" & My.Application.Info.Version.ToString)

            If updResponse <> "" Then
                checkForUpdateThread.UpdateUI(New Object() {"displaymsg", "Μία νέα έκδοση του " & My.Application.Info.Title & " είναι διαθέσιμη." & vbCrLf _
                                                    & "Θέλετε να την κατεβάσετε τώρα;"})
            End If

        Catch e As Exception
            Console.WriteLine(e.Message)
        End Try

    End Sub

    Private Sub checkForUpdateCb(ByRef obj As Object)
        If TypeOf obj(0) Is String Then
            If obj(0) = "displaymsg" Then
                Dim answer = MsgBox(obj(1), MsgBoxStyle.YesNo + MsgBoxStyle.Information, "Έλεγχος ενημερώσεων")

                If answer = MsgBoxResult.Yes Then
                    Process.Start(updResponse)
                    End
                End If
            End If
        End If
    End Sub
End Class