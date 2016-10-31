Public Class Moves
    Private gameBoard As Board
    Private selCol As Integer
    Private movesArray As ArrayList
    Private toHighlight As ArrayList


    Sub New(ByRef gb As Board)
        Me.gameBoard = gb
        Me.selCol = -1
        Me.movesArray = New ArrayList
        Me.toHighlight = New ArrayList
    End Sub

    Public Function getMovesArray() As ArrayList
        Return movesArray
    End Function

    Public Function getHighlightArray() As ArrayList
        Return toHighlight
    End Function


    Sub setSelectedCol(ByVal col As Integer)
        If col < 25 Then
            'An kanei click xwris na exei epile3ei kapoio diko tou pouli tote na vgei apo thn sub
            If (Not gameBoard.getColumn(col).getTopCheckerColor = gameBoard.getPlayerColor) And selCol = -1 Then
                Exit Sub
            End If

            'an to column den einai highlighted tote den mporei na kanei kinhsh opote na vgei apo thn sub
            If Not gameBoard.getColumn(col).isHighlighted Then
                cancelMove()
                Exit Sub
            End If

            'an den mporei na kouni8ei to sygekrimeno pouli tote vges apo thn sub
            'If Not canMove(col) And canCollect(col) Then
            'Exit Sub
            'End If
        End If

        If selCol > -1 Then
            'akyrwsh ths kinhshs an kanei klik panw sto idio column
            If selCol = col Then
                cancelMove()
            Else
                'an kanei click se column pou vrisketai ston pinaka na kanei thn kinhsh
                If gameBoard.getColumn(col).isHighlighted Then
                    'kanw thn kinhsh
                    doMove(selCol, col)

                    'arxikopopoiw to selCol
                    selCol = -1

                End If
            End If
        Else
            'an den mporei na kouni8ei to sygekrimeno pouli tote vges apo thn sub
            If Not canMove(col) And canCollect(col) Then
                Exit Sub
            End If
            selCol = col

            fillHighlightArray(col)

            For i = 0 To toHighlight.Count - 1
                gameBoard.getColumn(toHighlight.Item(i)).highlight()
            Next

            gameBoard.disableHighlight()
        End If



    End Sub

    Public Function canMove(ByVal col As Integer) As Boolean
        fillHighlightArray(col)
        Return toHighlight.Count > 0
    End Function

    Private Function allowedTo(ByVal col As Integer) As Boolean

        If col > 24 Or col < 1 Then
            Return False
        End If

        If gameBoard.getColumn(col).getOwner() Is Nothing Or _
                           gameBoard.getColumn(col).getOwner() = gameBoard.getPlayerColor Then
            Return True
        End If

        Return False

    End Function

    'Akyrwsh ths kinhshs (arxikopoihsh twn metavlitwn kai svisimw twn highlights)
    Public Sub cancelMove()
        gameBoard.removeAllHighlights()

        'an den exei kamena poulia tote na kanei enable to highlight
        If Not gameBoard.hasHitDown Then
            gameBoard.enableHighlight()
        End If

        selCol = -1
    End Sub

    Public Sub doMove(ByVal col1 As Integer, ByVal col2 As Integer)
        Dim dice1 = gameBoard.getdice().getdiceArray(0)
        Dim dice2 = gameBoard.getdice().getdiceArray(1)

        'elegxos gia to pouli pou yparxei sto col pou 8a paei einai diaforetiko xrwma apo to source checker kai 1 opote na kaei
        If isHittable(col1, col2) Then
            'tote na kaei to pouli
            Dim tmpChk As Checker = gameBoard.getColumn(col2).removeChecker()

            'an to pouli pou prokeitai na kaei einai diko mou tote topo8etise to katw
            If Board.controlledBy Is Board.remotePlayer Then
                gameBoard.addHitChecker("down", tmpChk.getCheckerType)
            Else
                'alliws panw
                gameBoard.addHitChecker("up", tmpChk.getCheckerType)
            End If
        End If

        'an to source position tou checker einai ta kamena tote to diagrafw apo ekei
        Dim tmpCol = Nothing

        If (col1 = 25) Then
            tmpCol = gameBoard.removeHitChecker("down")
        ElseIf (col1 = 0) Then
            tmpCol = gameBoard.removeHitChecker("up")
        Else
            tmpCol = gameBoard.getColumn(col1).removeChecker
        End If

        'dhmiourgia tou checker sth 8esh col2
        gameBoard.getColumn(col2).addChecker(tmpCol.getCheckerType)

        Dim moves = Math.Abs(col1 - col2)

        'diagrafh ths kinhshs apo to array
        If dice1 <> dice2 Then
            movesArray.Remove(moves)
        End If
        'aferesh tou katallhlou ari8mou zariwn gia tis diples
        Dim curSum As Integer
        For i = 0 To movesArray.Count - 1
            curSum += movesArray.Item(i)

            'an exei ferei diples kai yparxei apiloumeno pouli anamesa tote na to kapsei

            'If isHittable(col1, col1 - curSum) Then
            'an to pouli pou prokeitai na kaei einai diko mou tote topo8etise to katw

            'If gameBoard.getColumn(col1 - curSum).getTopCheckerColor <> Board.localPlayer.getColor Then
            'gameBoard.addHitChecker("up", 
            'If Board.controlledBy Is Board.remotePlayer Then
            'gameBoard.addHitChecker("down", gameBoard.getColumn(col1 - curSum).getTopCheckerColor)
            'Else
            'alliws panw
            'gameBoard.addHitChecker("up", gameBoard.getColumn(col1 - curSum).getTopCheckerColor)
            'End If
            'End If
            'End If

            If curSum = moves Then
                For j = 0 To i
                    movesArray.RemoveAt(0)
                Next
                Exit For
            End If
        Next

        'svinw ola ta highlighted columns
        gameBoard.removeAllHighlights()

        'energopoiw to highlight
        gameBoard.enableHighlight()

        'kanw raise to event EndMove
        RaiseEvent EndMove(Board.controlledBy, col1, col2)

        'Elegxos exei allh kinhsh o xrhsths
        If Board.controlledBy Is Board.localPlayer And Not ableToPlay() And movesArray.Count > 0 Then
            'kanw raise to event UnableToPlay
            RaiseEvent UnableToPlay(Board.controlledBy)
        End If

        'Elegxos gia to an exei teleiwsei ton gyro tou
        If Not hasMoves() Then
            gameBoard.removeAllHighlights()
            selCol = -1

            'kanw raise to event EndRound
            RaiseEvent EndRound(Board.controlledBy)
        End If

    End Sub

    Private Function isHittable(ByVal srcColNum As Integer, ByVal destColNum As Integer) As Boolean
        'elegxos gia to pouli pou yparxei sto col pou einai diaforetiko xrwma apo to source checker kai 1 (dld apileitai)
        Dim srcColor As String = Nothing
        Dim destColor As String = gameBoard.getColumn(destColNum).getTopCheckerColor

        'an to source einai ta kamena tote pare to color apo ta kamena
        If srcColNum = 25 Then
            Dim hitArray As ArrayList = gameBoard.getHitArray("down")
            srcColor = CType(hitArray.Item(hitArray.Count - 1), Checker).getCheckerType

        ElseIf srcColNum = 0 Then
            Dim hitArray As ArrayList = gameBoard.getHitArray("up")
            srcColor = CType(hitArray.Item(hitArray.Count - 1), Checker).getCheckerType
        Else
            'alliws pare to color apo to srcCol
            srcColor = gameBoard.getColumn(srcColNum).getTopCheckerColor
        End If

        'an den einai idiou xrwmatos tote epestrepse true
        If gameBoard.getColumn(destColNum).getSize = 1 Then
            If srcColor <> destColor Then
                Return True
            End If
        End If

        Return False
    End Function

    Public Function hasMoves() As Boolean
        Return Not movesArray.Count = 0
    End Function


    Private Sub fillHighlightArray(ByVal col As Integer)
        If movesArray.Count = 0 Then
            Exit Sub
        End If
        If toHighlight.Count > 0 Then
            toHighlight.Clear()
        End If

        'Highlight tou ka8e checker
        For i = 0 To movesArray.Count - 1
            If allowedTo(col - movesArray.Item(i)) And Not toHighlight.Contains(col - movesArray.Item(i)) Then
                toHighlight.Add(col - movesArray.Item(i))
            End If
        Next

        'an exei 2 h perissotera kamena poulia na min kanei highlight to a8roisma
        If gameBoard.hasHitDown > 1 Then
            Exit Sub
        End If

        'an yparxei pouli tou antipalou pou apileitai sta columns pou mporei na paei tote na min kanei higlight to a8roisma (gia profaneis logous)
        Dim curDest As Column = Nothing
        For i = 0 To toHighlight.Count - 1
            curDest = gameBoard.getColumn(toHighlight.Item(i))
            If curDest.getSize = 1 Then
                If curDest.getChecker(1).getCheckerType <> gameBoard.getPlayerColor Then
                    Exit Sub
                End If
            End If
        Next

        'Highlight tou a8rismatos twn kinhsewn twn checkers
        Dim curHighlightPos = col
        For i = 0 To movesArray.Count - 1
            curHighlightPos -= movesArray.Item(i)

            If curHighlightPos < 1 Then
                Exit For
            End If

            If allowedTo(curHighlightPos) Then
                If Not toHighlight.Contains(curHighlightPos) Then
                    toHighlight.Add(curHighlightPos)
                End If

                'na stamatisei to highlight sto pouli pou prokeitai na kaei(an yparxei)
                curDest = gameBoard.getColumn(toHighlight.Item(i))
                If curDest.getSize = 1 Then
                    If curDest.getChecker(1).getCheckerType <> gameBoard.getPlayerColor Then
                        Exit For
                    End If
                End If
            Else
                Exit For
            End If
        Next

        'elegxw thn periptwsh pou den einai diples kai mporei na paei to pouli (me ta zaria anapoda)
        If movesArray.Count = 2 Then
            If Not movesArray.Item(0) = movesArray.Item(1) Then
                If allowedTo(col - movesArray.Item(1)) And allowedTo(col - movesArray.Item(0) - movesArray.Item(1)) Then
                    toHighlight.Add(col - movesArray.Item(0) - movesArray.Item(1))
                End If
            End If
        End If

    End Sub

    Public Sub fillMovesArray()
        If movesArray.Count > 0 Then
            movesArray.Clear()
        End If

        Dim dice1 = gameBoard.getdice().getdiceArray(0)
        Dim dice2 = gameBoard.getdice().getdiceArray(1)

        'otan kanei click se ena pouli tou na gemisei o pinakas me tis zaries

        'an einai diples
        If (dice1 = dice2) Then
            For i = 1 To 4
                movesArray.Add(dice1)
            Next
        Else
            movesArray.Add(dice1)
            movesArray.Add(dice2)
        End If
    End Sub

    'epistrefei true h false gia to an mporei na kanei kinhsh o paixths
    Public Function ableToPlay() As Boolean

        'elegxos an exei poulia kamena kai den mporei na ta pai3ei
        If Board.controlledBy Is Board.localPlayer _
                And gameBoard.hasHitDown > 0 And Not canMove(25) Then
            Return False
        End If

        For i = 24 To 1 Step -1
            If (gameBoard.getColumn(i).getTopCheckerColor = gameBoard.getPlayerColor) Then
                'elegxw an mporei na kouni8ei to pouli h an mporei na mazepsei to sygekrimeno pouli
                If canMove(i) Or canCollect(i) Then
                    Return True
                End If
            End If
        Next

        Return False
    End Function

    Public Function canCollect(ByVal col As Integer) As Boolean
        'an den eimai se collectmode h an to pouli ths sthlhs den einai diko mou tote epistrefw false
        If col > 24 Then
            Return False
        End If
        If Not collectMode() Or gameBoard.getColumn(col).getTopCheckerColor <> gameBoard.getPlayerColor Then
            Return False
        End If

        'alliws pairnw ta zaria
        Dim dice1 = gameBoard.getdice().getdiceArray(0)
        Dim dice2 = gameBoard.getdice().getdiceArray(1)

        'kai elegxw an mporei na mazepsei to sygekrimeno pouli

        'an to checker einai sto teleutaio column tote na pianei kai zaries megalyteres apo ton ari8mo tou col, px otan exw checker sto col 5
        'na mporei na to mazepsei an ferei 6
        If col = getLastCheckerPos() Then
            For i = 0 To movesArray.Count - 1
                If (col - movesArray.Item(i) < 1) Then
                    Return True
                End If
            Next
        Else
            'alliws 8a prepei na einai akrivws 0 h aferese col - diceN gia na mporesei na to mazepsei
            For i = 0 To movesArray.Count - 1
                If (col - movesArray.Item(i) = 0) Then
                    Return True
                End If
            Next
        End If

        Return False
    End Function

    'epistrefei true an ola ta poulia tou paixti 
    Public Function collectMode() As Boolean
        'an exei kamena poulia tote den mporei an mazepsei
        If gameBoard.hasHitDown Then
            Return False
        End If

        Return getLastCheckerPos() < 7
    End Function

    Private Function getLastCheckerPos() As Integer
        Dim maxCol As Integer = 24

        'vriskw ton megalytero ari8mo column pou yparxei diko mou pouli 
        For i = 24 To 1 Step -1
            If gameBoard.getColumn(i).getTopCheckerColor = gameBoard.getPlayerColor Then
                maxCol = i
                Exit For
            End If
        Next

        Return maxCol
    End Function

    Public Sub collect(ByVal col As Integer)

        'pairnw thn megalyterh zaria
        Dim max As Integer = getMaxMove()
        Dim moves As Integer = If(col > 6, 25 - col, col)

        'an to teleutaio megalytero pouli einai mikrotero apo th megalyterh zaria tote aferese th megalyterh zaria
        If Board.controlledBy Is Board.localPlayer Then
            If getLastCheckerPos() < max Then
                movesArray.Remove(max)
            Else
                'alliws aferese th zaria pou prepei
                movesArray.Remove(moves)
            End If
        Else
            'vriskw to megalytero column pou exei pouli o antipalos
            Dim maxCol = 24
            For i = 24 To 19 Step -1
                If gameBoard.getColumn(i).getSize > 0 Then
                    If gameBoard.getColumn(i).getTopCheckerColor <> gameBoard.getPlayerColor Then
                        maxCol = i
                    End If
                End If
            Next

            If (25 - maxCol) < max Then
                movesArray.Remove(max)
            Else
                movesArray.Remove(moves)
            End If
        End If

        'svinw to grafiko apo th 8esh tou kai to pros8etw sta mazemena poulia
        gameBoard.getColumn(col).removeHighlight()
        If Board.controlledBy Is Board.localPlayer Then
            gameBoard.addCollectChecker("down", gameBoard.getColumn(col).removeChecker().getCheckerType)
        Else
            gameBoard.addCollectChecker("up", gameBoard.getColumn(col).removeChecker().getCheckerType)
        End If

        Dim chkIfWon As Player = Board.controlledBy

        'kanw raise to event
        RaiseEvent EndCollect(Board.controlledBy, col)

        If chkIfWon.getCheckersCollected = 15 Then
            RaiseEvent EndGame(chkIfWon)
            'gameBoard.endGame(chkForWinner)
            Exit Sub
        End If

        If Not hasMoves() Then
            'an den exei alles kinhseis kanw raise to event EndRound
            RaiseEvent EndRound(Board.controlledBy)
            Exit Sub
        End If

        If Not ableToPlay() And movesArray.Count > 0 Then
            'an den exei alles kinhseis kanw raise to event UnableToPlay
            RaiseEvent UnableToPlay(Board.controlledBy)
        End If
    End Sub

    Public Function getMaxMove() As Integer
        Dim max As Integer = movesArray.Item(0)
        For i = 1 To movesArray.Count - 1
            If movesArray.Item(i) > max Then
                max = movesArray.Item(i)
            End If
        Next
        Return max
    End Function

    'Custom events
    Public Event UnableToPlay(ByRef pl As Player)
    Public Event EndMove(ByRef pl As Player, ByVal srcPos As Integer, ByVal destPos As Integer)
    Public Event EndCollect(ByRef pl As Player, ByVal pos As Integer)
    Public Event EndRound(ByRef pl As Player)
    Public Event EndGame(ByRef pl As Player)

End Class