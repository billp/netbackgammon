<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmJoin
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmJoin))
        Me.gpGameSettings = New System.Windows.Forms.GroupBox
        Me.txtPortNumber = New System.Windows.Forms.TextBox
        Me.lblPortNumber = New System.Windows.Forms.Label
        Me.txtServerIp = New System.Windows.Forms.TextBox
        Me.lblServerIp = New System.Windows.Forms.Label
        Me.lblNickname = New System.Windows.Forms.Label
        Me.txtNickname = New System.Windows.Forms.TextBox
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnJoin = New System.Windows.Forms.Button
        Me.gpGameSettings.SuspendLayout()
        Me.SuspendLayout()
        '
        'gpGameSettings
        '
        Me.gpGameSettings.Controls.Add(Me.txtPortNumber)
        Me.gpGameSettings.Controls.Add(Me.lblPortNumber)
        Me.gpGameSettings.Controls.Add(Me.txtServerIp)
        Me.gpGameSettings.Controls.Add(Me.lblServerIp)
        Me.gpGameSettings.Controls.Add(Me.lblNickname)
        Me.gpGameSettings.Controls.Add(Me.txtNickname)
        Me.gpGameSettings.Location = New System.Drawing.Point(6, 3)
        Me.gpGameSettings.Name = "gpGameSettings"
        Me.gpGameSettings.Size = New System.Drawing.Size(328, 133)
        Me.gpGameSettings.TabIndex = 11
        Me.gpGameSettings.TabStop = False
        Me.gpGameSettings.Text = "Game Settings"
        '
        'txtPortNumber
        '
        Me.txtPortNumber.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtPortNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPortNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.txtPortNumber.Location = New System.Drawing.Point(117, 88)
        Me.txtPortNumber.MaxLength = 10
        Me.txtPortNumber.Name = "txtPortNumber"
        Me.txtPortNumber.Size = New System.Drawing.Size(75, 26)
        Me.txtPortNumber.TabIndex = 3
        '
        'lblPortNumber
        '
        Me.lblPortNumber.AutoSize = True
        Me.lblPortNumber.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblPortNumber.Location = New System.Drawing.Point(19, 93)
        Me.lblPortNumber.Name = "lblPortNumber"
        Me.lblPortNumber.Size = New System.Drawing.Size(92, 16)
        Me.lblPortNumber.TabIndex = 12
        Me.lblPortNumber.Text = "Port Number:"
        '
        'txtServerIp
        '
        Me.txtServerIp.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtServerIp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtServerIp.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.txtServerIp.Location = New System.Drawing.Point(117, 56)
        Me.txtServerIp.Name = "txtServerIp"
        Me.txtServerIp.Size = New System.Drawing.Size(175, 26)
        Me.txtServerIp.TabIndex = 2
        '
        'lblServerIp
        '
        Me.lblServerIp.AutoSize = True
        Me.lblServerIp.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblServerIp.Location = New System.Drawing.Point(40, 61)
        Me.lblServerIp.Name = "lblServerIp"
        Me.lblServerIp.Size = New System.Drawing.Size(71, 16)
        Me.lblServerIp.TabIndex = 14
        Me.lblServerIp.Text = "Server IP:"
        '
        'lblNickname
        '
        Me.lblNickname.AutoSize = True
        Me.lblNickname.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblNickname.Location = New System.Drawing.Point(36, 29)
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
        Me.txtNickname.Location = New System.Drawing.Point(117, 24)
        Me.txtNickname.MaxLength = 10
        Me.txtNickname.Name = "txtNickname"
        Me.txtNickname.Size = New System.Drawing.Size(144, 26)
        Me.txtNickname.TabIndex = 1
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(6, 142)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 32)
        Me.btnCancel.TabIndex = 13
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnJoin
        '
        Me.btnJoin.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.btnJoin.Location = New System.Drawing.Point(259, 142)
        Me.btnJoin.Name = "btnJoin"
        Me.btnJoin.Size = New System.Drawing.Size(75, 32)
        Me.btnJoin.TabIndex = 12
        Me.btnJoin.Text = "Join"
        Me.btnJoin.UseVisualStyleBackColor = True
        '
        'frmJoin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(342, 180)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnJoin)
        Me.Controls.Add(Me.gpGameSettings)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmJoin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Join Game"
        Me.gpGameSettings.ResumeLayout(False)
        Me.gpGameSettings.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gpGameSettings As System.Windows.Forms.GroupBox
    Friend WithEvents lblNickname As System.Windows.Forms.Label
    Friend WithEvents txtNickname As System.Windows.Forms.TextBox
    Friend WithEvents txtServerIp As System.Windows.Forms.TextBox
    Friend WithEvents lblServerIp As System.Windows.Forms.Label
    Friend WithEvents txtPortNumber As System.Windows.Forms.TextBox
    Friend WithEvents lblPortNumber As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnJoin As System.Windows.Forms.Button
End Class
