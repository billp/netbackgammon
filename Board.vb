Public Class Board
    Private columns(23) As Column
    Public Shared localPlayer, remotePlayer, controlledBy As Player
    Public Shared tcpConnection As TCPIP

    Private dice As Dice
    Private Shared enabled = False
    Private hitArrayDown, hitArrayUp, collectArrayDown, collectArrayUp As ArrayList
    Private highlightEnabled As Boolean

    'stis poses nikes 8a teleiosei to paixnidi
    Public Shared wins As Integer
    'xronos ka8e gyrou se deuterolepta
    Public Shared roundTime As Integer

    'Ta epipleon pictureboxes (gia hit kai gia collect)
    Private pbHitDown, pbHitUp, pbCollectDown, pbCollectUp As PictureBox

    Public Sub New()

        For i = 1 To 6
            columns(i - 1) = New Column(47 * i + 2, 578, "bottom")
            columns(i - 1).setHoverXY(i * 47 - 18, 374)
        Next
        For i = 7 To 12
            columns(i - 1) = New Column(47 * i + 62, 578, "bottom")
            columns(i - 1).setHoverXY(i * 47 + 42, 374)
        Next
        For i = 13 To 18
            'columns(i) = New Column(626 - (i - 13) * 47, 20, "top")
            columns(i - 1) = New Column(1237 - (47 * i), 20, "top")
            columns(i - 1).setHoverXY((25 - i) * 47 + 42, 23)

        Next
        For i = 19 To 24
            'columns(i) = New Column(626 - (i - 13) * 47, 20, "top")
            columns(i - 1) = New Column(1237 - 62 - (47 * i), 20, "top")
            columns(i - 1).setHoverXY((25 - i) * 47 - 20, 23)

        Next

        'dhmiourgia twn zariwn
        dice = New Dice

        'dhmiourgia twn arraylists
        hitArrayDown = New ArrayList
        hitArrayUp = New ArrayList
        collectArrayDown = New ArrayList
        collectArrayUp = New ArrayList

        'dhmiourgia twn pictureboxes
        pbHitDown = New PictureBox
        pbHitUp = New PictureBox
        pbCollectDown = New PictureBox
        pbCollectUp = New PictureBox

        'energopoiw to highlight twn columns
        highlightEnabled = True
    End Sub

    Public Function hasHitUp() As Integer
        Return hitArrayUp.Count
    End Function
    Public Function hasHitDown() As Integer
        Return hitArrayDown.Count
    End Function

    Public Function getHitArray(ByVal pos As String) As ArrayList
        Select Case pos
            Case "up"
                Return hitArrayUp
            Case "down"
                Return hitArrayDown
        End Select

        Return Nothing
    End Function
    Public Sub addHitChecker(ByVal pos As String, ByVal type As String)
        Dim pbGraphic As PictureBox = Nothing
        Dim hitArray As ArrayList = Nothing

        Select Case pos
            Case "up"
                pbGraphic = pbHitUp
                hitArray = hitArrayUp
            Case "down"
                pbGraphic = pbHitDown
                hitArray = hitArrayDown
        End Select

        'pros8hkh tou checker katw (ta x,y den mas endiaferoun)
        Dim newChecker As Checker = New Checker(type, 0, 0)
        hitArray.Add(newChecker)

        generateHitGraphic(pbGraphic, hitArray.Count, newChecker.getGraphic)

    End Sub

    Public Function removeHitChecker(ByVal pos As String) As Checker
        'krivw ta hitboxes an den yparxoun kamena poulia
        hideHitBoxes()

        Dim pbGraphic As PictureBox = Nothing
        Dim hitArray As ArrayList = Nothing


        Select Case pos
            Case "up"
                pbGraphic = pbHitUp
                hitArray = hitArrayUp
            Case "down"
                pbGraphic = pbHitDown
                hitArray = hitArrayDown
        End Select

        Dim tmp As Checker = hitArray.Item(hitArray.Count - 1)
        hitArray.RemoveAt(hitArray.Count - 1)

        'dimiourgia tou grafikou
        generateHitGraphic(pbGraphic, hitArray.Count, tmp.getGraphic)

        Return tmp
    End Function

    Private Sub hideHitBoxes()
        If (hitArrayUp.Count = 0) Then
            pbHitUp.Visible = False
        End If

        If (hitArrayDown.Count = 0) Then
            pbHitDown.Visible = False
        End If
    End Sub

    Public Sub addCollectChecker(ByVal pos As String, ByVal type As String)
        Dim pbGraphic As PictureBox = Nothing
        Dim collectArray As ArrayList = Nothing

        Select Case pos
            Case "up"
                pbGraphic = pbCollectUp
                collectArray = collectArrayUp
            Case "down"
                pbGraphic = pbCollectDown
                collectArray = collectArrayDown
        End Select

        'pros8hkh tou checker katw (ta x,y den mas endiaferoun)
        Dim newChecker As Checker = New Checker(type, 0, 0)
        collectArray.Add(newChecker)

        'dimiougw mia kenh eikona sthn opoia 8a zwgrafistoun ola ta checkers
        Dim bmdest As New Bitmap(pbGraphic.Width, pbGraphic.Height)
        Dim newgr As Graphics = Graphics.FromImage(bmdest)
        Dim fnt As Font = New Font("Arial", 12, FontStyle.Bold)
        Dim slbrBlack As SolidBrush = New SolidBrush(Color.Black)
        Dim slbrWhite As SolidBrush = New SolidBrush(Color.White)

        Dim chkWidth = Checker.blackChecker.Width

        'shrink checkers
        newgr.DrawImage(newChecker.getGraphic.Image, 0, 0, chkWidth, chkWidth)

        If newChecker.getCheckerType = "black" Then
            newgr.DrawString(collectArray.Count, fnt, slbrWhite, ((bmdest.Width / 2) - 7) - (5 * (collectArray.Count.ToString.Length - 1)), (bmdest.Width / 2) - 10)
        Else
            newgr.DrawString(collectArray.Count, fnt, slbrBlack, ((bmdest.Width / 2) - 7) - (5 * (collectArray.Count.ToString.Length - 1)), (bmdest.Width / 2) - 10)
        End If


        pbGraphic.Height = bmdest.Height
        pbGraphic.Width = bmdest.Width

        pbGraphic.Image = bmdest
        pbGraphic.Visible = True

    End Sub

    Private Sub generateHitGraphic(ByRef pbGraphic As PictureBox, ByVal count As Integer, ByVal pbChecker As PictureBox)
        'dimiougw mia kenh eikona sthn opoia 8a zwgrafistoun ola ta checkers
        Dim bmdest As New Bitmap(pbGraphic.Width, pbGraphic.Height)
        Dim newgr As Graphics = Graphics.FromImage(bmdest)

        'ypologizw thn arxikh 8esh sthn opoia 8a eisagetai to ka8e checker
        Dim start = bmdest.Height - 45

        'ypologismos tou step tou ka8e checker pou 8a zografistei
        Dim stp = Math.Ceiling(bmdest.Height / count) - 5

        Dim chkSize = Checker.blackChecker.Width

        'shrink checkers
        For i = 0 To count - 1
            newgr.DrawImage(pbChecker.Image, 0, start, chkSize, chkSize)
            start -= stp
        Next

        pbGraphic.Height = bmdest.Height
        pbGraphic.Width = bmdest.Width

        pbGraphic.Image = bmdest
        pbGraphic.Visible = True
    End Sub

    Public Function getDice() As Dice
        Return dice
    End Function

    Public Function getPlayerColor() As String
        Return Board.localPlayer.getColor
    End Function

    Public Sub fillColumn(ByVal pos As Integer, ByVal ckType As String, ByVal count As Integer)
        For i = 0 To count - 1
            columns(pos - 1).addChecker(ckType)
        Next
        'columns(pos - 1).addHover()
    End Sub

    Public Function getColumn(ByVal pos As Integer) As Column
        If pos < 1 Or pos > 24 Then
            Return Nothing
        End If
        Return columns(pos - 1)
    End Function


    Public Sub fillBoard(ByVal game As String, ByVal user As String)
        For i = 1 To 24
            getColumn(i).removeAllCheckers(getColumn(i).getSize)
        Next

        hitArrayDown.Clear()
        hitArrayUp.Clear()
        collectArrayUp.Clear()
        collectArrayDown.Clear()

        pbHitDown.Visible = False
        pbHitUp.Visible = False
        pbCollectDown.Visible = False
        pbCollectUp.Visible = False


        If user = "white" Then
            Select Case game
                Case "portes"
                    'Gemizw to board me ta poulia
                    fillColumn(1, "black", 2)
                    fillColumn(6, "white", 5)
                    fillColumn(8, "white", 3)
                    fillColumn(12, "black", 5)
                    fillColumn(13, "white", 5)
                    fillColumn(17, "black", 3)
                    fillColumn(19, "black", 5)
                    fillColumn(24, "white", 2)

                    'addHitChecker("down", "white")

                    'debug
                    'fillColumn(24, "black", 3)
                    'fillColumn(23, "black", 4)
                    'fillColumn(22, "black", 3)
                    'fillColumn(21, "black", 2)
                    'fillColumn(19, "black", 1)

                    'addCollectChecker("up", "black")
                    'addCollectChecker("up", "black")

                    'For i = 1 To 6
                    'fillColumn(i, "white", 2)
                    'Next
                    'addHitChecker("down", "white")

                    'fillColumn(4, "white", 3)
            End Select

        ElseIf user = "black" Then
            Select Case game
                Case "portes"
                    'Gemizw to board me ta poulia
                    fillColumn(1, "white", 2)
                    fillColumn(6, "black", 5)
                    fillColumn(8, "black", 3)
                    fillColumn(12, "white", 5)
                    fillColumn(13, "black", 5)
                    fillColumn(17, "white", 3)
                    fillColumn(19, "white", 5)
                    fillColumn(24, "black", 2)


                    'debug
                    'fillColumn(1, "black", 3)
                    'fillColumn(2, "black", 4)
                    'fillColumn(3, "black", 3)
                    'fillColumn(4, "black", 2)
                    'fillColumn(6, "black", 1)

                    'addCollectChecker("down", "black")
                    'addCollectChecker("down", "black")

                    ' For i = 24 To 19 Step -1
                    'fillColumn(i, "white", 2)
                    'Next
                    'addHitChecker("up", "white")

                    'fillColumn(21, "white", 3)

            End Select

        End If
    End Sub

    Public Sub removeAllHighlights()
        For i = 0 To columns.Count - 1
            If columns(i).isHighlighted() Then
                columns(i).removeHighlight()
            End If
        Next
    End Sub

    Public Shared Function isEnabled() As Boolean
        Return enabled
    End Function

    Public Shared Sub enable()
        enabled = True
    End Sub

    Public Shared Sub disable()
        enabled = False
    End Sub


    Public Sub createExtraColumns()
        'dimiougw mia kenh eikona sthn opoia 8a zwgrafistoun ola ta checkers
        'Dim bmdestHit As New Bitmap(47, 125)
        'Dim bmdestCollect As New Bitmap(50, 50)
        'Dim newgrHit As Graphics = Graphics.FromImage(bmdestHit)

        'Dim pbHitBoxDown, pbHitBoxUp, pbCollectDown, pbCollectUp As New PictureBox

        'orizw ta onomata tous wste na mporw na anaferomai s'auta

        Dim pBoxesHit() As PictureBox = {pbHitDown, pbHitUp}
        Dim pBoxesCollect() As PictureBox = {pbCollectDown, pbCollectUp}

        For Each pb As PictureBox In pBoxesHit
            pb.Width = 47
            pb.Height = 125
            pb.BackColor = Color.Transparent
            pb.Top = 490
            pb.Left = 316
            pb.Visible = False
            frmBoard.pbBoard.Controls.Add(pb)

        Next

        pBoxesHit(1).Top = 35

        For Each pb As PictureBox In pBoxesCollect
            pb.Width = 47
            pb.Height = 47
            pb.Top = 430
            pb.Left = 740
            pb.BackColor = Color.Transparent
            pb.Visible = False
            frmBoard.pbBoard.Controls.Add(pb)
        Next

        pBoxesCollect(1).Top = 200

        'orizw ta onomata twn pb
        pbHitDown.Name = "pbHitDown"

        'pros8etw handles gia ta clicks
        AddHandler pbHitDown.Click, AddressOf frmBoard.pbBoard_Click
        'AddHandler pbHitUp.Click, AddressOf frmBoard.hitUp_Click
    End Sub

    Public Function playerWon() As Player

        If collectArrayDown.Count = 15 Then
            Return localPlayer
        ElseIf collectArrayUp.Count = 15 Then
            Return remotePlayer
        End If

        Return Nothing
    End Function

    Public Function isHighlightEnabled()
        Return highlightEnabled
    End Function

    Public Sub disableHighlight()
        highlightEnabled = False
    End Sub

    Public Sub enableHighlight()
        'an exei kamena poulia tote na min kanei enable
        If hasHitDown() Then
            Exit Sub
        End If
        highlightEnabled = True
    End Sub

    'Public Sub endGame(ByVal winner As Player)

    'winner.setWins(winner.getWins + 1)

    'Select Case winner.getRole
    'Case "server"
    '  frmBoard.lblLocalScore.Text = winner.getWins
    ' Case "client"
    '    frmBoard.lblLocalScore.Text = winner.getWins
    'End Select
    'End Sub
End Class
