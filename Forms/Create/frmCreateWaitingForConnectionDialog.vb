Public Class frmCreateWaitingForConnectionDialog

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        frmCreate.serverThread.UpdateUI("abort")
    End Sub
End Class