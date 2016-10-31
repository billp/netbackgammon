<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCreate
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCreate))
        Me.lblNickname = New System.Windows.Forms.Label
        Me.txtNickname = New System.Windows.Forms.TextBox
        Me.lblCheckerColor = New System.Windows.Forms.Label
        Me.btnCreate = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnServerSettings = New System.Windows.Forms.Button
        Me.gpGameSettings = New System.Windows.Forms.GroupBox
        Me.lblRoundTime = New System.Windows.Forms.Label
        Me.txtRoundTime = New System.Windows.Forms.TextBox
        Me.lblWins = New System.Windows.Forms.Label
        Me.txtWins = New System.Windows.Forms.TextBox
        Me.lblSecs = New System.Windows.Forms.Label
        Me.pbChkWhite = New System.Windows.Forms.PictureBox
        Me.pbChkBlack = New System.Windows.Forms.PictureBox
        Me.gpGameSettings.SuspendLayout()
        CType(Me.pbChkWhite, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbChkBlack, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblNickname
        '
        Me.lblNickname.AutoSize = True
        Me.lblNickname.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblNickname.Location = New System.Drawing.Point(52, 31)
        Me.lblNickname.Name = "lblNickname"
        Me.lblNickname.Size = New System.Drawing.Size(75, 16)
        Me.lblNickname.TabIndex = 0
        Me.lblNickname.Text = "Nickname:"
        '
        'txtNickname
        '
        Me.txtNickname.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtNickname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNickname.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.txtNickname.Location = New System.Drawing.Point(133, 26)
        Me.txtNickname.MaxLength = 10
        Me.txtNickname.Name = "txtNickname"
        Me.txtNickname.Size = New System.Drawing.Size(137, 26)
        Me.txtNickname.TabIndex = 1
        '
        'lblCheckerColor
        '
        Me.lblCheckerColor.AutoSize = True
        Me.lblCheckerColor.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblCheckerColor.Location = New System.Drawing.Point(25, 140)
        Me.lblCheckerColor.Name = "lblCheckerColor"
        Me.lblCheckerColor.Size = New System.Drawing.Size(102, 16)
        Me.lblCheckerColor.TabIndex = 4
        Me.lblCheckerColor.Text = "Checker Color:"
        '
        'btnCreate
        '
        Me.btnCreate.Enabled = False
        Me.btnCreate.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.btnCreate.Location = New System.Drawing.Point(265, 192)
        Me.btnCreate.Name = "btnCreate"
        Me.btnCreate.Size = New System.Drawing.Size(75, 32)
        Me.btnCreate.TabIndex = 6
        Me.btnCreate.Text = "Create"
        Me.btnCreate.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(7, 192)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 32)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnServerSettings
        '
        Me.btnServerSettings.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.btnServerSettings.ForeColor = System.Drawing.Color.Red
        Me.btnServerSettings.Location = New System.Drawing.Point(143, 192)
        Me.btnServerSettings.Name = "btnServerSettings"
        Me.btnServerSettings.Size = New System.Drawing.Size(116, 32)
        Me.btnServerSettings.TabIndex = 5
        Me.btnServerSettings.Text = "Server Settings"
        Me.btnServerSettings.UseVisualStyleBackColor = True
        '
        'gpGameSettings
        '
        Me.gpGameSettings.Controls.Add(Me.lblSecs)
        Me.gpGameSettings.Controls.Add(Me.lblRoundTime)
        Me.gpGameSettings.Controls.Add(Me.txtRoundTime)
        Me.gpGameSettings.Controls.Add(Me.lblWins)
        Me.gpGameSettings.Controls.Add(Me.txtWins)
        Me.gpGameSettings.Controls.Add(Me.pbChkWhite)
        Me.gpGameSettings.Controls.Add(Me.lblNickname)
        Me.gpGameSettings.Controls.Add(Me.txtNickname)
        Me.gpGameSettings.Controls.Add(Me.pbChkBlack)
        Me.gpGameSettings.Controls.Add(Me.lblCheckerColor)
        Me.gpGameSettings.Location = New System.Drawing.Point(7, 2)
        Me.gpGameSettings.Name = "gpGameSettings"
        Me.gpGameSettings.Size = New System.Drawing.Size(333, 184)
        Me.gpGameSettings.TabIndex = 10
        Me.gpGameSettings.TabStop = False
        Me.gpGameSettings.Text = "Game Settings"
        '
        'lblRoundTime
        '
        Me.lblRoundTime.AutoSize = True
        Me.lblRoundTime.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblRoundTime.Location = New System.Drawing.Point(38, 95)
        Me.lblRoundTime.Name = "lblRoundTime"
        Me.lblRoundTime.Size = New System.Drawing.Size(89, 16)
        Me.lblRoundTime.TabIndex = 9
        Me.lblRoundTime.Text = "Round Time:"
        '
        'txtRoundTime
        '
        Me.txtRoundTime.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtRoundTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRoundTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.txtRoundTime.Location = New System.Drawing.Point(133, 90)
        Me.txtRoundTime.MaxLength = 4
        Me.txtRoundTime.Name = "txtRoundTime"
        Me.txtRoundTime.Size = New System.Drawing.Size(51, 26)
        Me.txtRoundTime.TabIndex = 3
        '
        'lblWins
        '
        Me.lblWins.AutoSize = True
        Me.lblWins.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblWins.Location = New System.Drawing.Point(84, 63)
        Me.lblWins.Name = "lblWins"
        Me.lblWins.Size = New System.Drawing.Size(43, 16)
        Me.lblWins.TabIndex = 7
        Me.lblWins.Text = "Wins:"
        '
        'txtWins
        '
        Me.txtWins.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtWins.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtWins.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.txtWins.Location = New System.Drawing.Point(133, 58)
        Me.txtWins.MaxLength = 2
        Me.txtWins.Name = "txtWins"
        Me.txtWins.Size = New System.Drawing.Size(31, 26)
        Me.txtWins.TabIndex = 2
        '
        'lblSecs
        '
        Me.lblSecs.AutoSize = True
        Me.lblSecs.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblSecs.Location = New System.Drawing.Point(187, 95)
        Me.lblSecs.Name = "lblSecs"
        Me.lblSecs.Size = New System.Drawing.Size(35, 16)
        Me.lblSecs.TabIndex = 11
        Me.lblSecs.Text = "secs"
        '
        'pbChkWhite
        '
        Me.pbChkWhite.Image = Global.NetBackgammon.My.Resources.Resources.pouli_aspro
        Me.pbChkWhite.Location = New System.Drawing.Point(133, 122)
        Me.pbChkWhite.Name = "pbChkWhite"
        Me.pbChkWhite.Size = New System.Drawing.Size(51, 50)
        Me.pbChkWhite.TabIndex = 5
        Me.pbChkWhite.TabStop = False
        '
        'pbChkBlack
        '
        Me.pbChkBlack.Image = Global.NetBackgammon.My.Resources.Resources.pouli_mauro
        Me.pbChkBlack.Location = New System.Drawing.Point(190, 122)
        Me.pbChkBlack.Name = "pbChkBlack"
        Me.pbChkBlack.Size = New System.Drawing.Size(52, 50)
        Me.pbChkBlack.TabIndex = 6
        Me.pbChkBlack.TabStop = False
        '
        'frmCreate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(344, 227)
        Me.Controls.Add(Me.gpGameSettings)
        Me.Controls.Add(Me.btnServerSettings)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnCreate)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCreate"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Create Game"
        Me.gpGameSettings.ResumeLayout(False)
        Me.gpGameSettings.PerformLayout()
        CType(Me.pbChkWhite, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbChkBlack, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblNickname As System.Windows.Forms.Label
    Friend WithEvents txtNickname As System.Windows.Forms.TextBox
    Friend WithEvents lblCheckerColor As System.Windows.Forms.Label
    Friend WithEvents pbChkWhite As System.Windows.Forms.PictureBox
    Friend WithEvents pbChkBlack As System.Windows.Forms.PictureBox
    Friend WithEvents btnCreate As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnServerSettings As System.Windows.Forms.Button
    Friend WithEvents gpGameSettings As System.Windows.Forms.GroupBox
    Friend WithEvents lblWins As System.Windows.Forms.Label
    Friend WithEvents txtWins As System.Windows.Forms.TextBox
    Friend WithEvents lblRoundTime As System.Windows.Forms.Label
    Friend WithEvents txtRoundTime As System.Windows.Forms.TextBox
    Friend WithEvents lblSecs As System.Windows.Forms.Label
End Class
