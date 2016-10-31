<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCreateServerSettings
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
        Me.btnSave = New System.Windows.Forms.Button
        Me.txtPortNumber = New System.Windows.Forms.TextBox
        Me.lblPortNumber = New System.Windows.Forms.Label
        Me.gpServerSettings = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtRemoteIp = New System.Windows.Forms.TextBox
        Me.lblRemoteIp = New System.Windows.Forms.Label
        Me.txtLocalIp = New System.Windows.Forms.TextBox
        Me.lblLocalIp = New System.Windows.Forms.Label
        Me.btnCopyAllServerInfo = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.gpServerSettings.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnSave
        '
        Me.btnSave.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.btnSave.Location = New System.Drawing.Point(297, 123)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 32)
        Me.btnSave.TabIndex = 6
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'txtPortNumber
        '
        Me.txtPortNumber.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtPortNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPortNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.txtPortNumber.Location = New System.Drawing.Point(110, 18)
        Me.txtPortNumber.MaxLength = 10
        Me.txtPortNumber.Name = "txtPortNumber"
        Me.txtPortNumber.Size = New System.Drawing.Size(75, 26)
        Me.txtPortNumber.TabIndex = 1
        Me.txtPortNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblPortNumber
        '
        Me.lblPortNumber.AutoSize = True
        Me.lblPortNumber.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblPortNumber.Location = New System.Drawing.Point(12, 23)
        Me.lblPortNumber.Name = "lblPortNumber"
        Me.lblPortNumber.Size = New System.Drawing.Size(92, 16)
        Me.lblPortNumber.TabIndex = 9
        Me.lblPortNumber.Text = "Port Number:"
        '
        'gpServerSettings
        '
        Me.gpServerSettings.Controls.Add(Me.Label2)
        Me.gpServerSettings.Controls.Add(Me.Label1)
        Me.gpServerSettings.Controls.Add(Me.txtRemoteIp)
        Me.gpServerSettings.Controls.Add(Me.lblRemoteIp)
        Me.gpServerSettings.Controls.Add(Me.txtLocalIp)
        Me.gpServerSettings.Controls.Add(Me.lblLocalIp)
        Me.gpServerSettings.Controls.Add(Me.txtPortNumber)
        Me.gpServerSettings.Controls.Add(Me.lblPortNumber)
        Me.gpServerSettings.Location = New System.Drawing.Point(7, 2)
        Me.gpServerSettings.Name = "gpServerSettings"
        Me.gpServerSettings.Size = New System.Drawing.Size(366, 115)
        Me.gpServerSettings.TabIndex = 11
        Me.gpServerSettings.TabStop = False
        Me.gpServerSettings.Text = "TCP/IP"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(288, 87)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 16)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "read only"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(288, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 16)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "read only"
        '
        'txtRemoteIp
        '
        Me.txtRemoteIp.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtRemoteIp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRemoteIp.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.txtRemoteIp.Location = New System.Drawing.Point(110, 82)
        Me.txtRemoteIp.Name = "txtRemoteIp"
        Me.txtRemoteIp.ReadOnly = True
        Me.txtRemoteIp.Size = New System.Drawing.Size(175, 26)
        Me.txtRemoteIp.TabIndex = 3
        Me.txtRemoteIp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblRemoteIp
        '
        Me.lblRemoteIp.AutoSize = True
        Me.lblRemoteIp.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblRemoteIp.Location = New System.Drawing.Point(26, 87)
        Me.lblRemoteIp.Name = "lblRemoteIp"
        Me.lblRemoteIp.Size = New System.Drawing.Size(78, 16)
        Me.lblRemoteIp.TabIndex = 14
        Me.lblRemoteIp.Text = "Remote IP:"
        '
        'txtLocalIp
        '
        Me.txtLocalIp.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtLocalIp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLocalIp.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.txtLocalIp.Location = New System.Drawing.Point(110, 50)
        Me.txtLocalIp.Name = "txtLocalIp"
        Me.txtLocalIp.ReadOnly = True
        Me.txtLocalIp.Size = New System.Drawing.Size(175, 26)
        Me.txtLocalIp.TabIndex = 2
        Me.txtLocalIp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblLocalIp
        '
        Me.lblLocalIp.AutoSize = True
        Me.lblLocalIp.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblLocalIp.Location = New System.Drawing.Point(40, 55)
        Me.lblLocalIp.Name = "lblLocalIp"
        Me.lblLocalIp.Size = New System.Drawing.Size(64, 16)
        Me.lblLocalIp.TabIndex = 12
        Me.lblLocalIp.Text = "Local IP:"
        '
        'btnCopyAllServerInfo
        '
        Me.btnCopyAllServerInfo.Location = New System.Drawing.Point(175, 123)
        Me.btnCopyAllServerInfo.Name = "btnCopyAllServerInfo"
        Me.btnCopyAllServerInfo.Size = New System.Drawing.Size(117, 32)
        Me.btnCopyAllServerInfo.TabIndex = 5
        Me.btnCopyAllServerInfo.Text = "Copy All Server Info"
        Me.btnCopyAllServerInfo.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.btnClose.Location = New System.Drawing.Point(7, 123)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 32)
        Me.btnClose.TabIndex = 4
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'frmCreateServerSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(378, 159)
        Me.Controls.Add(Me.btnCopyAllServerInfo)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.gpServerSettings)
        Me.Controls.Add(Me.btnSave)
        Me.Name = "frmCreateServerSettings"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Server Settings"
        Me.gpServerSettings.ResumeLayout(False)
        Me.gpServerSettings.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents txtPortNumber As System.Windows.Forms.TextBox
    Friend WithEvents lblPortNumber As System.Windows.Forms.Label
    Friend WithEvents gpServerSettings As System.Windows.Forms.GroupBox
    Friend WithEvents btnCopyAllServerInfo As System.Windows.Forms.Button
    Friend WithEvents txtRemoteIp As System.Windows.Forms.TextBox
    Friend WithEvents lblRemoteIp As System.Windows.Forms.Label
    Friend WithEvents txtLocalIp As System.Windows.Forms.TextBox
    Friend WithEvents lblLocalIp As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
