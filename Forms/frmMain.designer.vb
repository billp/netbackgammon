<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.btnCreate = New System.Windows.Forms.Button
        Me.btnJoin = New System.Windows.Forms.Button
        Me.btnAbout = New System.Windows.Forms.Button
        Me.pbBackground = New System.Windows.Forms.PictureBox
        Me.btnExit = New System.Windows.Forms.Button
        CType(Me.pbBackground, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCreate
        '
        Me.btnCreate.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.btnCreate.Location = New System.Drawing.Point(575, 189)
        Me.btnCreate.Name = "btnCreate"
        Me.btnCreate.Size = New System.Drawing.Size(98, 29)
        Me.btnCreate.TabIndex = 2
        Me.btnCreate.Text = "&Create"
        Me.btnCreate.UseVisualStyleBackColor = True
        '
        'btnJoin
        '
        Me.btnJoin.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.btnJoin.Location = New System.Drawing.Point(575, 224)
        Me.btnJoin.Name = "btnJoin"
        Me.btnJoin.Size = New System.Drawing.Size(98, 29)
        Me.btnJoin.TabIndex = 3
        Me.btnJoin.Text = "&Join"
        Me.btnJoin.UseVisualStyleBackColor = True
        '
        'btnAbout
        '
        Me.btnAbout.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.btnAbout.Location = New System.Drawing.Point(575, 259)
        Me.btnAbout.Name = "btnAbout"
        Me.btnAbout.Size = New System.Drawing.Size(98, 29)
        Me.btnAbout.TabIndex = 4
        Me.btnAbout.Text = "&About"
        Me.btnAbout.UseVisualStyleBackColor = True
        '
        'pbBackground
        '
        Me.pbBackground.Image = CType(resources.GetObject("pbBackground.Image"), System.Drawing.Image)
        Me.pbBackground.Location = New System.Drawing.Point(0, 0)
        Me.pbBackground.Name = "pbBackground"
        Me.pbBackground.Size = New System.Drawing.Size(697, 341)
        Me.pbBackground.TabIndex = 5
        Me.pbBackground.TabStop = False
        '
        'btnExit
        '
        Me.btnExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.btnExit.Location = New System.Drawing.Point(575, 294)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(98, 29)
        Me.btnExit.TabIndex = 6
        Me.btnExit.Text = "&Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(697, 342)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnAbout)
        Me.Controls.Add(Me.btnJoin)
        Me.Controls.Add(Me.btnCreate)
        Me.Controls.Add(Me.pbBackground)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.pbBackground, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnCreate As System.Windows.Forms.Button
    Friend WithEvents btnJoin As System.Windows.Forms.Button
    Friend WithEvents btnAbout As System.Windows.Forms.Button
    Friend WithEvents pbBackground As System.Windows.Forms.PictureBox
    Friend WithEvents btnExit As System.Windows.Forms.Button
End Class
