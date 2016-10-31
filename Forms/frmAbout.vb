Public NotInheritable Class frmAbout


    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
        frmMain.Show()
    End Sub



    Private Sub frmAbout_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Text = My.Application.Info.Title & " - " & "About"
        txtDevelopers.Text = "Ανδρεάδης Χρήστος" & vbCrLf & "Βαρσάμης Ιωάννης (iovarsamis@gmail.com)" & vbCrLf & "Παναγιωτόπουλος Βασίλης (mazz3x@gmail.com)" & vbCrLf & "Σταλίκας Γρηγόρης (grstalikas@gmail.com)"
        txtVersion.Text = My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor
    End Sub
End Class
