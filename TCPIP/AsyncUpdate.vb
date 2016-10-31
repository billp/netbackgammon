Namespace AsyncUpdate
    Module Form
        Private Delegate Sub AsyncForm(ByVal frm As System.Windows.Forms.Form)
        Private Delegate Sub AsyncFormEnable(ByVal frm As System.Windows.Forms.Form, ByVal enable As Boolean)

        Public Sub close(ByVal frm As System.Windows.Forms.Form)

            If frm.InvokeRequired = True Then
                Dim d As New AsyncForm(AddressOf close)
                frm.Invoke(d, New Object() {frm})
            Else
                frm.Close()
            End If
        End Sub

        Public Sub show(ByVal frm As System.Windows.Forms.Form)

            If frm.InvokeRequired = True Then
                Dim d As New AsyncForm(AddressOf show)
                frm.Invoke(d, New Object() {frm})
            Else
                frm.Show()
            End If
        End Sub

        Public Sub enabled(ByVal frm As System.Windows.Forms.Form, ByVal enable As Boolean)

            If frm.InvokeRequired = True Then
                Dim d As New AsyncFormEnable(AddressOf enabled)
                frm.Invoke(d, New Object() {frm, enable})
            Else
                frm.Enabled = enable
            End If
        End Sub

        Public Sub activate(ByVal frm As System.Windows.Forms.Form)

            If frm.InvokeRequired = True Then
                Dim d As New AsyncForm(AddressOf activate)
                frm.Invoke(d, New Object() {frm})
            Else
                frm.Activate()
            End If
        End Sub


    End Module
    Module Button
        Private Delegate Sub AsyncButton(ByVal ctrl As System.Windows.Forms.Button, _
                                                ByVal enable As Boolean)

        Public Sub enable(ByVal ctrl As System.Windows.Forms.Button, _
                                ByVal enBool As Boolean)

            If ctrl.InvokeRequired = True Then
                Dim d As New AsyncButton(AddressOf enable)
                ctrl.Invoke(d, New Object() {ctrl, enBool})
            Else
                ctrl.Enabled = enBool
            End If
        End Sub
    End Module

    Module TextBox
        Private Delegate Sub AsyncTextBox(ByVal ctrl As System.Windows.Forms.TextBox, _
                                                ByVal text As String)

        Public Sub setText(ByVal ctrl As System.Windows.Forms.TextBox, _
                                ByVal text As String)

            If ctrl.InvokeRequired = True Then
                Dim d As New AsyncTextBox(AddressOf setText)
                ctrl.Invoke(d, New Object() {ctrl, text})
            Else
                ctrl.Text = text
            End If
        End Sub
    End Module

    Module PictureBox
        Private Delegate Sub AsyncPictureBox(ByVal ctrl As System.Windows.Forms.PictureBox, _
                                                ByVal image As Image)


        Public Sub setImage(ByVal ctrl As System.Windows.Forms.PictureBox, _
                                ByVal image As Image)

            If ctrl.InvokeRequired = True Then
                Dim d As New AsyncPictureBox(AddressOf setImage)
                ctrl.Invoke(d, New Object() {ctrl, image})
            Else
                ctrl.Image = image
            End If
        End Sub
    End Module

    Module Timer
        Private Delegate Sub enableT(ByVal ctrl As System.Windows.Forms.Timer)


        'Public Sub enableTimer(ByVal ctrl As System.Windows.Forms.Timer)

        '   If ctrl.InvokeRequired = True Then
        'Dim d As New enableT(AddressOf enableTimer)
        '        ctrl.Invoke(d, New Object() {ctrl})
        '   Else
        '       ctrl.Image = Image
        '   End If
        'End Sub
    End Module
End Namespace
