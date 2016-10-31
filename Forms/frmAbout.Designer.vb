<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAbout
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
        Me.gbAbout = New System.Windows.Forms.GroupBox
        Me.txtVersion = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtDevelopers = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnClose = New System.Windows.Forms.Button
        Me.gbAbout.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbAbout
        '
        Me.gbAbout.Controls.Add(Me.txtVersion)
        Me.gbAbout.Controls.Add(Me.Label2)
        Me.gbAbout.Controls.Add(Me.txtDevelopers)
        Me.gbAbout.Controls.Add(Me.Label1)
        Me.gbAbout.Location = New System.Drawing.Point(6, -1)
        Me.gbAbout.Name = "gbAbout"
        Me.gbAbout.Size = New System.Drawing.Size(438, 128)
        Me.gbAbout.TabIndex = 0
        Me.gbAbout.TabStop = False
        '
        'txtVersion
        '
        Me.txtVersion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVersion.Location = New System.Drawing.Point(105, 96)
        Me.txtVersion.Name = "txtVersion"
        Me.txtVersion.ReadOnly = True
        Me.txtVersion.Size = New System.Drawing.Size(107, 20)
        Me.txtVersion.TabIndex = 3
        Me.txtVersion.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label2.Location = New System.Drawing.Point(37, 100)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Version:"
        '
        'txtDevelopers
        '
        Me.txtDevelopers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDevelopers.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDevelopers.Location = New System.Drawing.Point(105, 16)
        Me.txtDevelopers.Multiline = True
        Me.txtDevelopers.Name = "txtDevelopers"
        Me.txtDevelopers.ReadOnly = True
        Me.txtDevelopers.Size = New System.Drawing.Size(302, 74)
        Me.txtDevelopers.TabIndex = 1
        Me.txtDevelopers.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Developers:"
        '
        'btnClose
        '
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Location = New System.Drawing.Point(369, 133)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 1
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'frmAbout
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(448, 164)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.gbAbout)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAbout"
        Me.Padding = New System.Windows.Forms.Padding(9)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "About"
        Me.gbAbout.ResumeLayout(False)
        Me.gbAbout.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtDevelopers As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents txtVersion As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents gbAbout As System.Windows.Forms.GroupBox

End Class
