<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBoard
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBoard))
        Me.gbScore = New System.Windows.Forms.GroupBox
        Me.lblRemoteScore = New System.Windows.Forms.Label
        Me.lblLocalScore = New System.Windows.Forms.Label
        Me.lblRemoteName = New System.Windows.Forms.Label
        Me.lblLocalName = New System.Windows.Forms.Label
        Me.btnExit = New System.Windows.Forms.Button
        Me.btnMenu = New System.Windows.Forms.Button
        Me.iLstSixDie = New System.Windows.Forms.ImageList(Me.components)
        Me.lblCountdown = New System.Windows.Forms.Label
        Me.tmrDie = New System.Windows.Forms.Timer(Me.components)
        Me.pbxSixSided2 = New System.Windows.Forms.PictureBox
        Me.pbxSixSided = New System.Windows.Forms.PictureBox
        Me.pbBoard = New System.Windows.Forms.PictureBox
        Me.btnStartGame = New System.Windows.Forms.Button
        Me.tmrRound = New System.Windows.Forms.Timer(Me.components)
        Me.lblMessage = New System.Windows.Forms.Label
        Me.gbRoundTime = New System.Windows.Forms.GroupBox
        Me.tmrWarning = New System.Windows.Forms.Timer(Me.components)
        Me.gbScore.SuspendLayout()
        CType(Me.pbxSixSided2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxSixSided, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbBoard, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbRoundTime.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbScore
        '
        Me.gbScore.BackColor = System.Drawing.Color.Transparent
        Me.gbScore.Controls.Add(Me.lblRemoteScore)
        Me.gbScore.Controls.Add(Me.lblLocalScore)
        Me.gbScore.Controls.Add(Me.lblRemoteName)
        Me.gbScore.Controls.Add(Me.lblLocalName)
        Me.gbScore.Font = New System.Drawing.Font("Nina", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbScore.ForeColor = System.Drawing.Color.White
        Me.gbScore.Location = New System.Drawing.Point(687, 9)
        Me.gbScore.Name = "gbScore"
        Me.gbScore.Size = New System.Drawing.Size(166, 84)
        Me.gbScore.TabIndex = 1
        Me.gbScore.TabStop = False
        Me.gbScore.Text = "Score"
        '
        'lblRemoteScore
        '
        Me.lblRemoteScore.Font = New System.Drawing.Font("Microsoft Sans Serif", 22.0!, System.Drawing.FontStyle.Bold)
        Me.lblRemoteScore.ForeColor = System.Drawing.Color.DarkOrange
        Me.lblRemoteScore.Location = New System.Drawing.Point(88, 40)
        Me.lblRemoteScore.Name = "lblRemoteScore"
        Me.lblRemoteScore.Size = New System.Drawing.Size(72, 36)
        Me.lblRemoteScore.TabIndex = 4
        Me.lblRemoteScore.Text = "0"
        Me.lblRemoteScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblLocalScore
        '
        Me.lblLocalScore.Font = New System.Drawing.Font("Microsoft Sans Serif", 22.0!, System.Drawing.FontStyle.Bold)
        Me.lblLocalScore.ForeColor = System.Drawing.Color.DarkOrange
        Me.lblLocalScore.Location = New System.Drawing.Point(11, 40)
        Me.lblLocalScore.Name = "lblLocalScore"
        Me.lblLocalScore.Size = New System.Drawing.Size(75, 36)
        Me.lblLocalScore.TabIndex = 3
        Me.lblLocalScore.Text = "0"
        Me.lblLocalScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblRemoteName
        '
        Me.lblRemoteName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRemoteName.Location = New System.Drawing.Point(85, 23)
        Me.lblRemoteName.Name = "lblRemoteName"
        Me.lblRemoteName.Size = New System.Drawing.Size(75, 17)
        Me.lblRemoteName.TabIndex = 2
        Me.lblRemoteName.Text = "RemoteN"
        Me.lblRemoteName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblLocalName
        '
        Me.lblLocalName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLocalName.Location = New System.Drawing.Point(12, 23)
        Me.lblLocalName.Name = "lblLocalName"
        Me.lblLocalName.Size = New System.Drawing.Size(74, 17)
        Me.lblLocalName.TabIndex = 0
        Me.lblLocalName.Text = "LocalN"
        Me.lblLocalName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnExit
        '
        Me.btnExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.btnExit.Location = New System.Drawing.Point(683, 602)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(172, 35)
        Me.btnExit.TabIndex = 3
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnMenu
        '
        Me.btnMenu.BackColor = System.Drawing.Color.Transparent
        Me.btnMenu.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.btnMenu.Location = New System.Drawing.Point(683, 562)
        Me.btnMenu.Name = "btnMenu"
        Me.btnMenu.Size = New System.Drawing.Size(172, 35)
        Me.btnMenu.TabIndex = 4
        Me.btnMenu.Text = "Menu"
        Me.btnMenu.UseVisualStyleBackColor = False
        '
        'iLstSixDie
        '
        Me.iLstSixDie.ImageStream = CType(resources.GetObject("iLstSixDie.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.iLstSixDie.TransparentColor = System.Drawing.Color.Transparent
        Me.iLstSixDie.Images.SetKeyName(0, "1.jpg")
        Me.iLstSixDie.Images.SetKeyName(1, "2.jpg")
        Me.iLstSixDie.Images.SetKeyName(2, "3.jpg")
        Me.iLstSixDie.Images.SetKeyName(3, "4.jpg")
        Me.iLstSixDie.Images.SetKeyName(4, "5.jpg")
        Me.iLstSixDie.Images.SetKeyName(5, "6.jpg")
        '
        'lblCountdown
        '
        Me.lblCountdown.BackColor = System.Drawing.Color.Transparent
        Me.lblCountdown.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCountdown.ForeColor = System.Drawing.Color.Gainsboro
        Me.lblCountdown.Location = New System.Drawing.Point(5, 23)
        Me.lblCountdown.Name = "lblCountdown"
        Me.lblCountdown.Size = New System.Drawing.Size(157, 38)
        Me.lblCountdown.TabIndex = 2
        Me.lblCountdown.Text = "0"
        Me.lblCountdown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tmrDie
        '
        Me.tmrDie.Interval = 75
        '
        'pbxSixSided2
        '
        Me.pbxSixSided2.BackColor = System.Drawing.Color.Transparent
        Me.pbxSixSided2.Location = New System.Drawing.Point(317, 326)
        Me.pbxSixSided2.Name = "pbxSixSided2"
        Me.pbxSixSided2.Size = New System.Drawing.Size(48, 48)
        Me.pbxSixSided2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pbxSixSided2.TabIndex = 6
        Me.pbxSixSided2.TabStop = False
        '
        'pbxSixSided
        '
        Me.pbxSixSided.BackColor = System.Drawing.Color.Transparent
        Me.pbxSixSided.Location = New System.Drawing.Point(317, 277)
        Me.pbxSixSided.Name = "pbxSixSided"
        Me.pbxSixSided.Size = New System.Drawing.Size(48, 48)
        Me.pbxSixSided.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pbxSixSided.TabIndex = 5
        Me.pbxSixSided.TabStop = False
        '
        'pbBoard
        '
        Me.pbBoard.Image = Global.NetBackgammon.My.Resources.Resources.board
        Me.pbBoard.Location = New System.Drawing.Point(-1, 0)
        Me.pbBoard.Name = "pbBoard"
        Me.pbBoard.Size = New System.Drawing.Size(862, 646)
        Me.pbBoard.TabIndex = 0
        Me.pbBoard.TabStop = False
        '
        'btnStartGame
        '
        Me.btnStartGame.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!)
        Me.btnStartGame.ForeColor = System.Drawing.Color.Black
        Me.btnStartGame.Location = New System.Drawing.Point(683, 501)
        Me.btnStartGame.Name = "btnStartGame"
        Me.btnStartGame.Size = New System.Drawing.Size(172, 35)
        Me.btnStartGame.TabIndex = 7
        Me.btnStartGame.Text = "Start Game"
        Me.btnStartGame.UseVisualStyleBackColor = True
        '
        'tmrRound
        '
        Me.tmrRound.Interval = 1000
        '
        'lblMessage
        '
        Me.lblMessage.BackColor = System.Drawing.Color.Transparent
        Me.lblMessage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMessage.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessage.ForeColor = System.Drawing.Color.Gold
        Me.lblMessage.Location = New System.Drawing.Point(687, 305)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(166, 66)
        Me.lblMessage.TabIndex = 8
        Me.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblMessage.Visible = False
        '
        'gbRoundTime
        '
        Me.gbRoundTime.BackColor = System.Drawing.Color.Transparent
        Me.gbRoundTime.Controls.Add(Me.lblCountdown)
        Me.gbRoundTime.Font = New System.Drawing.Font("Nina", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbRoundTime.ForeColor = System.Drawing.Color.White
        Me.gbRoundTime.Location = New System.Drawing.Point(687, 102)
        Me.gbRoundTime.Name = "gbRoundTime"
        Me.gbRoundTime.Size = New System.Drawing.Size(166, 68)
        Me.gbRoundTime.TabIndex = 9
        Me.gbRoundTime.TabStop = False
        Me.gbRoundTime.Text = "Round Time"
        Me.gbRoundTime.Visible = False
        '
        'tmrWarning
        '
        Me.tmrWarning.Interval = 6000
        '
        'frmBoard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(860, 642)
        Me.ControlBox = False
        Me.Controls.Add(Me.gbRoundTime)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.btnStartGame)
        Me.Controls.Add(Me.pbxSixSided2)
        Me.Controls.Add(Me.pbxSixSided)
        Me.Controls.Add(Me.btnMenu)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.gbScore)
        Me.Controls.Add(Me.pbBoard)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmBoard"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Board"
        Me.gbScore.ResumeLayout(False)
        CType(Me.pbxSixSided2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxSixSided, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbBoard, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbRoundTime.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pbBoard As System.Windows.Forms.PictureBox
    Friend WithEvents gbScore As System.Windows.Forms.GroupBox
    Friend WithEvents lblRemoteName As System.Windows.Forms.Label
    Friend WithEvents lblLocalName As System.Windows.Forms.Label
    Friend WithEvents lblRemoteScore As System.Windows.Forms.Label
    Friend WithEvents lblLocalScore As System.Windows.Forms.Label
    Friend WithEvents lblCountdown As System.Windows.Forms.Label
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnMenu As System.Windows.Forms.Button
    Friend WithEvents iLstSixDie As System.Windows.Forms.ImageList
    Friend WithEvents tmrDie As System.Windows.Forms.Timer
    Friend WithEvents pbxSixSided2 As System.Windows.Forms.PictureBox
    Friend WithEvents pbxSixSided As System.Windows.Forms.PictureBox
    Friend WithEvents btnStartGame As System.Windows.Forms.Button
    Friend WithEvents tmrRound As System.Windows.Forms.Timer
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents gbRoundTime As System.Windows.Forms.GroupBox
    Friend WithEvents tmrWarning As System.Windows.Forms.Timer

End Class
