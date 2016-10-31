Public Class Checker
    'orismos grafikwn
    Public Shared blackChecker As System.Drawing.Bitmap = Global.NetBackgammon.My.Resources.pouli_mauro
    Public Shared whiteChecker As System.Drawing.Bitmap = Global.NetBackgammon.My.Resources.pouli_aspro

    Private type As String
    Private graphic As PictureBox
    Private x, y, oldX, oldY As Integer

    Public Sub New(ByVal type As String, ByVal x As Integer, ByVal y As Integer)
        'orismos parametrwn 
        Me.type = type
        Me.x = x
        Me.y = y
        Me.oldX = x
        Me.oldY = y

        'dhmiourgia grafikou
        graphic = New Windows.Forms.PictureBox()
        graphic.Width = 45
        graphic.Height = 45

        'orismos syntetagmenwn
        graphic.Left = x
        graphic.Top = y

        'orismos event on the fly
        AddHandler graphic.MouseMove, AddressOf frmBoard.pbBoard_MouseMove
        AddHandler graphic.DoubleClick, AddressOf frmBoard.pbBoard_DoubleClick
        AddHandler graphic.Click, AddressOf frmBoard.pbBoard_Click

        'allagh xrwmatos se trasnparent
        graphic.BackColor = Color.Transparent

        Select Case type
            Case "white"
                graphic.Image = whiteChecker
                Me.type = "white"
            Case "black"
                graphic.Image = blackChecker
                Me.type = "black"
        End Select
    End Sub

    Public Function getCheckerType() As String
        Return type
    End Function
    Public Function getGraphic() As PictureBox
        Return graphic
    End Function

    Public Sub move(ByVal x As Integer, ByVal y As Integer)
        Me.oldX = Me.x
        Me.oldY = Me.y
        Me.x = x
        Me.y = y

        'metakinisi grafikou
        Me.graphic.Left = x
        Me.graphic.Top = y
    End Sub

    Public Sub undoMove()
        Me.x = Me.oldX
        Me.y = Me.oldY

        Me.graphic.Visible = False
        Me.graphic.Left = Me.x
        Me.graphic.Top = Me.y
        Me.graphic.Visible = True
    End Sub

    Public Sub setParent(ByRef cnt As PictureBox)
        Me.graphic.Parent = cnt
        Me.graphic.BringToFront()
    End Sub

    Public Sub showGraphic(ByVal show As Boolean)
        Me.graphic.Visible = show
    End Sub

End Class
