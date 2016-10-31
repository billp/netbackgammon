Imports System.Math
Public Class Dice

    Dim randNum1 As Integer
    Dim randNum2 As Integer
    Dim rand1, rand2 As Integer
    Dim randNum3 As Integer
    Dim numPics As Integer = 6
    Dim count As Integer = 0
    Dim pic1 As String
    Dim speed As Single = 20
    Dim rndInst As New Random()
    Dim xVel As Single = Math.Cos(rndInst.Next(5, 10)) * speed
    Dim yVel As Single = Math.Sin(rndInst.Next(5, 10)) * speed
    Public Shared finished As Boolean


    Public Sub rollDice()
        Randomize()
        randNum1 = CInt(Int((numPics * Rnd()) + 1))
        randNum2 = CInt(Int((numPics * Rnd()) + 1))

        frmBoard.tmrDie.Enabled = True
        frmBoard.pbxSixSided.Visible = True
        frmBoard.pbxSixSided2.Visible = True
    End Sub

    Public Sub setDice(ByVal num1 As Integer, ByVal num2 As Integer)
        rand1 = num1
        rand2 = num2
    End Sub

    Public Function getDiceArray() As Integer()
        Dim nums As Integer()
        If rand1 <> 0 And rand2 <> 0 Then
            nums = New Integer() {rand1, rand2}

        Else
            nums = New Integer() {randNum1, randNum2}
        End If

        Return nums
    End Function

    Public Sub playDice()
        'Start the random number generator
        Randomize()

        'Assign a random number to a variable

        Dim curNum1 = CInt(Int((numPics * Rnd()) + 1))
        Dim curNum2 = CInt(Int((numPics * Rnd()) + 1))

        'Count 1 for every round
        count += 1

        If count = 12 Then
            curNum1 = randNum1
            curNum2 = randNum2

            If (rand1 <> 0 And rand2 <> 0) Then
                curNum1 = rand1
                curNum2 = rand2

                randNum1 = rand1
                randNum2 = rand2

                rand1 = 0
                rand2 = 0
            End If
        End If

        'Console.WriteLine(randNum1 & " " & randNum2)

        'Show the picture for the random number
        Select Case curNum1
            Case 1
                'AsyncUpdate.PictureBox.setImage(frmBoard.pbxSixSided, frmBoard.iLstSixDie.Images.Item(0))
                frmBoard.pbxSixSided.Image = frmBoard.iLstSixDie.Images.Item(0)
            Case 2
                frmBoard.pbxSixSided.Image = frmBoard.iLstSixDie.Images.Item(1)
                'AsyncUpdate.PictureBox.setImage(frmBoard.pbxSixSided, frmBoard.iLstSixDie.Images.Item(1))
            Case 3
                frmBoard.pbxSixSided.Image = frmBoard.iLstSixDie.Images.Item(2)
                'AsyncUpdate.PictureBox.setImage(frmBoard.pbxSixSided, frmBoard.iLstSixDie.Images.Item(2))
            Case 4
                frmBoard.pbxSixSided.Image = frmBoard.iLstSixDie.Images.Item(3)
                'AsyncUpdate.PictureBox.setImage(frmBoard.pbxSixSided, frmBoard.iLstSixDie.Images.Item(3))
            Case 5
                frmBoard.pbxSixSided.Image = frmBoard.iLstSixDie.Images.Item(4)
                'AsyncUpdate.PictureBox.setImage(frmBoard.pbxSixSided, frmBoard.iLstSixDie.Images.Item(4))
            Case 6
                frmBoard.pbxSixSided.Image = frmBoard.iLstSixDie.Images.Item(5)
                'AsyncUpdate.PictureBox.setImage(frmBoard.pbxSixSided, frmBoard.iLstSixDie.Images.Item(5))
        End Select

        Select Case curNum2
            Case 1
                'AsyncUpdate.PictureBox.setImage(frmBoard.pbxSixSided2, frmBoard.iLstSixDie.Images.Item(0))

                frmBoard.pbxSixSided2.Image = frmBoard.iLstSixDie.Images.Item(0)
            Case 2
                'AsyncUpdate.PictureBox.setImage(frmBoard.pbxSixSided2, frmBoard.iLstSixDie.Images.Item(1))

                frmBoard.pbxSixSided2.Image = frmBoard.iLstSixDie.Images.Item(1)
            Case 3
                'AsyncUpdate.PictureBox.setImage(frmBoard.pbxSixSided2, frmBoard.iLstSixDie.Images.Item(2))

                frmBoard.pbxSixSided2.Image = frmBoard.iLstSixDie.Images.Item(2)
            Case 4
                'AsyncUpdate.PictureBox.setImage(frmBoard.pbxSixSided2, frmBoard.iLstSixDie.Images.Item(3))

                frmBoard.pbxSixSided2.Image = frmBoard.iLstSixDie.Images.Item(3)
            Case 5
                'AsyncUpdate.PictureBox.setImage(frmBoard.pbxSixSided2, frmBoard.iLstSixDie.Images.Item(4))

                frmBoard.pbxSixSided2.Image = frmBoard.iLstSixDie.Images.Item(4)
            Case 6
                'AsyncUpdate.PictureBox.setImage(frmBoard.pbxSixSided2, frmBoard.iLstSixDie.Images.Item(5))

                frmBoard.pbxSixSided2.Image = frmBoard.iLstSixDie.Images.Item(5)
        End Select

        'If the count equals the number of rotations,
        '   then stop the wheel, and reset the count

        If count = 12 Then
            frmBoard.tmrDie.Enabled = False
            count = 0
            RaiseEvent Enddice(randNum1, randNum2)
        End If

        'Move the picture box.
        'MovePic()

        'Rotate the picture in the picture box.
        Rotate(frmBoard.pbxSixSided)
        Rotate(frmBoard.pbxSixSided2)

    End Sub

    Public Sub Rotate(ByVal pic As System.Windows.Forms.PictureBox)
        'Copy the output bitmap from the source image.
        Dim startPic As New Bitmap(pic.Image)


        'Make an array of points defining the image's corners.
        Dim wid As Single = startPic.Width
        Dim hgt As Single = startPic.Height
        Dim corners As Point() = { _
            New Point(0, 0), _
            New Point(wid, 0), _
            New Point(0, hgt), _
            New Point(wid, hgt)}

        'Translate to center the bounding box at the origin.
        Dim cx As Single = wid / 2
        Dim cy As Single = hgt / 2
        Dim i As Long
        For i = 0 To 3
            corners(i).X -= cx
            corners(i).Y -= cy
        Next i

        'Rotate.
        randNum3 = CInt(Int((360 * Rnd()) + 1))
        Dim theta As Single = Single.Parse(randNum3) * PI / 180.0

        Dim sin_theta As Single = Sin(theta)
        Dim cos_theta As Single = Cos(theta)
        Dim X As Single
        Dim Y As Single
        For i = 0 To 3
            X = corners(i).X
            Y = corners(i).Y
            corners(i).X = X * cos_theta + Y * sin_theta
            corners(i).Y = -X * sin_theta + Y * cos_theta
        Next i

        'Translate so X >= 0 and Y >=0 for all corners.
        Dim xmin As Single = corners(0).X
        Dim ymin As Single = corners(0).Y
        For i = 1 To 3
            If xmin > corners(i).X Then xmin = corners(i).X
            If ymin > corners(i).Y Then ymin = corners(i).Y
        Next i
        For i = 0 To 3
            corners(i).X -= xmin
            corners(i).Y -= ymin
        Next i

        'Create an output Bitmap and Graphics object.
        Dim finishPic As New Bitmap(CInt(-2 * xmin), CInt(-2 * ymin))
        Dim picOut As Graphics = Graphics.FromImage(finishPic)

        'Drop the last corner lest we confuse DrawImage, 
        'which expects an array of three corners.
        ReDim Preserve corners(2)

        'Draw the result onto the output image.
        picOut.DrawImage(startPic, corners)

        'Display the result.
        pic.Image = finishPic
    End Sub

    'custom events
    Public Event EndDice(ByVal dice1 As Integer, ByVal dice2 As Integer)

End Class