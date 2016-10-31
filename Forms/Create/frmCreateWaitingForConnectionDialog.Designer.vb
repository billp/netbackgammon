<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCreateWaitingForConnectionDialog
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCreateWaitingForConnectionDialog))
        Me.lblWaitingForClient = New System.Windows.Forms.Label
        Me.btnCancel = New System.Windows.Forms.Button
        Me.plWaitingForConnection = New System.Windows.Forms.Panel
        Me.plWaitingForConnection.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblWaitingForClient
        '
        Me.lblWaitingForClient.AutoSize = True
        Me.lblWaitingForClient.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblWaitingForClient.Location = New System.Drawing.Point(24, 8)
        Me.lblWaitingForClient.Name = "lblWaitingForClient"
        Me.lblWaitingForClient.Size = New System.Drawing.Size(264, 20)
        Me.lblWaitingForClient.TabIndex = 0
        Me.lblWaitingForClient.Text = "Waiting for a client to connect..."
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(121, 43)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'plWaitingForConnection
        '
        Me.plWaitingForConnection.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.plWaitingForConnection.Controls.Add(Me.btnCancel)
        Me.plWaitingForConnection.Controls.Add(Me.lblWaitingForClient)
        Me.plWaitingForConnection.Location = New System.Drawing.Point(0, 0)
        Me.plWaitingForConnection.Name = "plWaitingForConnection"
        Me.plWaitingForConnection.Size = New System.Drawing.Size(314, 77)
        Me.plWaitingForConnection.TabIndex = 2
        '
        'frmCreateWaitingForConnectionDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(314, 77)
        Me.Controls.Add(Me.plWaitingForConnection)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCreateWaitingForConnectionDialog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Waiting..."
        Me.plWaitingForConnection.ResumeLayout(False)
        Me.plWaitingForConnection.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblWaitingForClient As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents plWaitingForConnection As System.Windows.Forms.Panel
End Class
