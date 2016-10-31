Imports System.Threading
Imports System.Xml

Public Class frmBoard
    Private gameBoard As Board = New Board()
    Private gameMove As Moves = New Moves(gameBoard)
    Private lastHovered As Column

    Private initDice As Boolean = True
    Private gameInitThread As CallBackThread
    Private gameRoundThread As CallBackThread
    Private recieveData As CallBackThread

    Private netError As Boolean = False

    Private curRoundTime As Integer = Board.roundTime

    Private Sub tmrDie_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrDie.Tick
        gameBoard.getDice().playDice()
    End Sub


    Public Sub pbBoard_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles pbBoard.Click
        Dim x = Cursor.Position.X - Me.Location.X
        Dim y = Cursor.Position.Y - Me.Location.Y

        'eksodos an den einai h seira mas
        If Not Board.isEnabled() Then
            Exit Sub
        End If

        Dim curCol As Integer = Nothing

        'elegxw an exei kanei click sta kamena poulia
        If CType(sender, Control).Name = "pbHitDown" Then
            'alliws 8ese to selected col sto 25 wste na ypologisei swsta tis 8eseis
            curCol = 25
        Else
            curCol = getCol()
        End If

        If curCol <> -1 Then
            gameMove.setSelectedCol(curCol)
        Else
            gameMove.cancelMove()
        End If

    End Sub

    Public Sub pbBoard_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles pbBoard.DoubleClick
        'eksodos an den einai h seira mas h an den exei ola ta poulia sygentrwmena sthn perioxh tou
        If Not Board.isEnabled() Or Not gameMove.collectMode Then
            Exit Sub
        End If

        Dim curCol As Integer = getCol()

        If gameMove.canCollect(curCol) Then
            gameMove.cancelMove()
            gameMove.collect(curCol)
            'gameBoard.addCollectChecker("down", gameBoard.getColumn(curCol).removeChecker().getCheckerType)
            'gameMove.cancelMove()
        End If

    End Sub

    Public Sub pbBoard_MouseMove(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbBoard.MouseMove
        'eksodos an den einai h seira mas
        If Not Board.isEnabled() Or Not gameBoard.isHighlightEnabled Then
            Exit Sub
        End If

        Dim curCol As Integer = getCol()

        If (curCol <> -1) Then
            Dim col = gameBoard.getColumn(curCol)

            'highlight
            If Not Me.lastHovered Is Nothing And Not Me.lastHovered Is col Then
                Me.lastHovered.removeHighlight()
            End If

            'Fwtismos ths grammhs pou vrisketai o kersoras (efoson mporei o paikths na kanei kati me auto to checker)
            If (gameBoard.getPlayerColor() = gameBoard.getColumn(curCol).getTopCheckerColor And gameMove.canMove(curCol)) _
                        Or gameMove.canCollect(curCol) Then

                col.highlight()
                Me.lastHovered = col
            End If
        Else
            If Not Me.lastHovered Is Nothing Then
                Me.lastHovered.removeHighlight()
            End If
        End If
    End Sub

    Private Sub btnMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMenu.Click
        Dim answer = MsgBox("Είσαι σίγουρος ότι θέλεις να παραιτηθείς από την παρτίδα για να μεταφερθείς στο κυρίως μενού;", MsgBoxStyle.Information + MsgBoxStyle.YesNo)
        If answer = MsgBoxResult.Yes Then
            'Stelnw disconnect ston antipalo
            Protocol.sendDisconnect()

            Me.Close()
            frmMain.Show()
        End If

    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Dim answer = MsgBox("Είσαι σίγουρος ότι θέλεις να παραιτηθείς από την παρτίδα;", MsgBoxStyle.Information + MsgBoxStyle.YesNo)
        If answer = MsgBoxResult.Yes Then
            'Stelnw disconnect ston antipalo
            Protocol.sendDisconnect()
            End
        End If

    End Sub

    Private Sub board_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Orizw to parent se ka8e stoixeio panw sto board (gia to transparency)
        Dim controls() As Object = {pbxSixSided, pbxSixSided2, btnStartGame, lblMessage, gbRoundTime, gbScore, btnMenu, btnExit}
        setParrent(controls, Me.pbBoard)

        gameBoard.createExtraColumns()

        gameBoard.fillBoard("portes", Board.localPlayer.getColor)

        Me.lblLocalName.Text = Board.localPlayer.getNickname
        Me.lblLocalScore.Text = Board.localPlayer.getWins

        Me.lblRemoteName.Text = Board.remotePlayer.getNickname
        Me.lblRemoteScore.Text = Board.remotePlayer.getWins



        'Add event handler for dice
        AddHandler gameBoard.getDice().EndDice, AddressOf endDice

        'Add event handlers for move
        AddHandler gameMove.EndMove, AddressOf Me.endMove
        AddHandler gameMove.EndCollect, AddressOf Me.endCollect
        AddHandler gameMove.UnableToPlay, AddressOf Me.unableToPlay
        AddHandler gameMove.EndRound, AddressOf Me.endRound
        AddHandler gameMove.EndGame, AddressOf Me.endGame

        'Tcp event handlers
        AddHandler TCPIP.tcpError, AddressOf Me.tcpError
        AddHandler Application.ThreadException, AddressOf globalError

        Me.Text = My.Application.Info.Title & " - " & Board.localPlayer.getNickname & " (" & Board.localPlayer.getRole & ")"

        gameInitThread = New CallBackThread(Me, AddressOf initGameWork, AddressOf gamePlayCallback)
        recieveData = New CallBackThread(Me, AddressOf recieveDataWork, AddressOf gamePlayCallback)


        If Board.localPlayer.getRole = "server" Then
            gameBoard.getDice.setDice(2, 2)
        End If
        'ksekinaw to thread gia thn lhpsh twn dedomenwn
        recieveData.Start()

        'Throw New Exception("Sfalma efarmoghs")

        'debug
        'If Board.localPlayer.getRole = "client" Then
        ' Board.controlledBy = Board.localPlayer
        ' Else
        'Board.controlledBy = Board.remotePlayer
        'End If
        'If Board.controlledBy Is Board.localPlayer Then
        ' gameInitThread.UpdateUI(New Object() {"setdice", 5, 1})
        'Protocol.sendDice(5, 1)

        ' End If

        'initDice = False
        '3ekinaw to thread pou 8a dexetai ta dedomena apo ton antipalo
        'recieveData.Start()
    End Sub


    Private Sub initGameWork()
        'pairnw to player status tou apomakrysmenou player
        Board.remotePlayer.setIsReady(Protocol.getRemotePlayerStatus())


        While Not Board.localPlayer.isReady Or Not Board.remotePlayer.isReady
            'perimenw na patisei to ready o local Player
        End While


        If Board.localPlayer.getWins <> 0 Or Board.remotePlayer.getWins <> 0 Then
            If Board.controlledBy Is Board.localPlayer Then
                gameInitThread.UpdateUI("rolldice")
            End If

            gameInitThread.UpdateUI("hidemessage")

            Exit Sub
        End If

        Dim dice() As Integer = Nothing

        While True

            If Board.localPlayer.getRole = "server" Then
                gameInitThread.UpdateUI("rolldice")
                dice = gameBoard.getDice.getDiceArray
            Else
                dice = Protocol.getDice()
                gameInitThread.UpdateUI(New Object() {"setdice", dice(0), dice(1)})
            End If

            'kanw sleep gia rollDice
            Thread.Sleep(1400)

            If dice(0) <> dice(1) Then
                Exit While
            End If

        End While

        initDice = False

        'elegxw an h zaria mou einai megalyterh apo tou allou
        If dice(1) > dice(0) Then
            'paizw prwtos ara dinw ton elegxo tou board se emena
            Board.controlledBy = Board.localPlayer

            gameInitThread.UpdateUI(New Object() {"displaywarning", "Κέρδισες την πρώτη ζαριά", 3500})

            'rixnw ta zaria
            gameInitThread.UpdateUI("rolldice")

        Else
            'dinw ton elegxo ston antipalo
            Board.controlledBy = Board.remotePlayer

            gameInitThread.UpdateUI(New Object() {"displaywarning", "Ο " & Board.controlledBy.getNickname & " κέρδισε την πρώτη ζαριά", 2000})
        End If

        Console.WriteLine("Prwtos -> " & Board.controlledBy.getNickname)

        '3ekinaw to thread pou 8a dexetai ta dedomena apo ton antipalo
        recieveData.Start()

    End Sub

    Private Sub recieveDataWork()

        Dim xmlResponse = New XmlDocument()
        While True

            If netError Then
                netError = False
                Exit Sub
            End If

            While Board.tcpConnection.getTCPStream.DataAvailable
                Dim response = Board.tcpConnection.getData()


                Try
                    xmlResponse.LoadXml(response)

                    If xmlResponse.SelectNodes("playerReady").Count > 0 Then
                        Board.remotePlayer.setIsReady(Protocol.getRemotePlayerStatus(response))

                    ElseIf xmlResponse.SelectNodes("dice").Count > 0 Then
                        Dim dice() As Integer = Protocol.getDice(response)
                        recieveData.UpdateUI(New Object() {"setdice", dice(0), dice(1)})
                        Thread.Sleep(1000)

                        If initDice Then
                            If dice(0) = dice(1) Then
                                recieveData.UpdateUI("rolldice")
                                Thread.Sleep(1000)
                            End If

                            dice = gameBoard.getDice.getDiceArray

                            checkDice(dice(1), dice(0))

                        End If
                    ElseIf xmlResponse.SelectNodes("move").Count > 0 Then
                        Dim move() As Integer = Protocol.getMove(response)

                        recieveData.UpdateUI(New Object() {"move", 25 - move(0), 25 - move(1)})
                    ElseIf xmlResponse.SelectNodes("unableToPlay").Count > 0 Then
                        recieveData.UpdateUI("unabletoplay")

                        'rixnw ta zaria
                        Thread.Sleep(1400)
                        recieveData.UpdateUI("rolldice")

                    ElseIf xmlResponse.SelectNodes("collect").Count > 0 Then
                        Dim col As Integer = Protocol.getCollect(response)

                        recieveData.UpdateUI(New Object() {"collect", col})
                    ElseIf xmlResponse.SelectNodes("disconnect").Count > 0 Then
                        netError = True
                        recieveData.UpdateUI("disconnect")
                        Thread.Sleep(100)
                        recieveData.Dispose()
                        Exit Sub
                    End If

                Catch er As XmlException
                    Console.WriteLine(er.ToString & vbCrLf & response)
                End Try
            End While

            If initDice Then
                If Board.localPlayer.isReady And Board.remotePlayer.isReady Then
                    If Board.localPlayer.getRole = "server" Then
                        recieveData.UpdateUI("rolldice")
                        Thread.Sleep(1000)

                        Dim dice() = gameBoard.getDice.getDiceArray

                        checkDice(dice(1), dice(0))
                    End If
                End If
            End If
        End While
    End Sub


    Private Sub checkDice(ByVal die1 As Integer, ByVal die2 As Integer)

        'elegxw an h zaria mou einai megalyterh apo tou allou
        If die1 > die2 Then
            'paizw prwtos ara dinw ton elegxo tou board se emena
            Board.controlledBy = Board.localPlayer

            recieveData.UpdateUI(New Object() {"displaywarning", "Κέρδισες την πρώτη ζαριά", 0})

            initDice = False

            'rixnw ta zaria
            recieveData.UpdateUI("rolldice")

            Thread.Sleep(1000)

        ElseIf die1 < die2 Then
            'dinw ton elegxo ston antipalo
            Board.controlledBy = Board.remotePlayer
            'Thread.Sleep(1400)
            recieveData.UpdateUI(New Object() {"displaywarning", "Ο " & Board.controlledBy.getNickname & " κέρδισε την πρώτη ζαριά", 0})
            initDice = False
        End If

    End Sub

    Private Sub gamePlayCallback(ByRef obj As Object)
        If TypeOf obj Is String Then
            Dim msg = CType(obj, String)

            If msg = "rolldice" Then
                gameBoard.getDice.rollDice()

                'gameMove.fillMovesArray()

                Dim dice() As Integer = gameBoard.getDice.getDiceArray()

                Protocol.sendDice(dice(1), dice(0))
            ElseIf msg = "unabletoplay" Then
                'trexw to event sub
                unableToPlay(Board.controlledBy)

            ElseIf msg = "hidemessage" Then
                lblMessage.Visible = False
            ElseIf msg = "disconnect" Then
                Dim strRemotePlayerNickname = Board.remotePlayer.getNickname

                gbRoundTime.Visible = False
                resetCountdown()

                'klinw thn syndesh
                forceCloseConnection()
                'petaw to mhnyma
                MsgBox("Ο " & strRemotePlayerNickname & " αποσυνδέθηκε.", MsgBoxStyle.Information)


                Me.Close()
                frmMain.Show()
            End If
        Else

            Dim msg = CType(obj(0), String)

            If msg = "setdice" Then
                Dim dice1 As Integer = CInt(obj(1))
                Dim dice2 As Integer = CInt(obj(2))

                gameBoard.getDice.setDice(dice1, dice2)
                gameMove.fillMovesArray()
                gameBoard.getDice.rollDice()

            ElseIf msg = "move" Then
                Dim srcCol As Integer = CInt(obj(1))
                Dim destCol As Integer = CInt(obj(2))

                gameMove.doMove(srcCol, destCol)

            ElseIf msg = "collect" Then
                Dim col = CInt(obj(1))

                gameMove.collect(col)
            ElseIf msg = "displaywarning" Then
                Dim warnMsg = obj(1)
                Dim warnTime = obj(2)

                displayWarning(warnMsg, warnTime)
            End If
        End If

    End Sub


    Private Sub setParrent(ByRef controls() As Object, ByRef parent As Windows.Forms.Control)
        Dim curControl As Control
        For Each curControl In controls
            CType(curControl, Control).Parent = parent
        Next
    End Sub


    'epistrefei th grammh pou vrisketai to pontiki
    Private Function getCol()
        Dim x = Cursor.Position.X - Me.Location.X
        Dim y = Cursor.Position.Y - Me.Location.Y

        If y > 420 And y < 650 Then
            If (x > 30 And x < 310) Then
                Return Math.Ceiling((x - 30) / 47)

            ElseIf (x > 370 And x < 650) Then
                Return Math.Ceiling((x - 370) / 47) + 6
            End If

        ElseIf y > 45 And y < 270 Then
            If (x > 30 And x < 310) Then
                Return 25 - Math.Ceiling(Math.Ceiling((x - 30) / 47))

            ElseIf (x > 370 And x < 650) Then
                Return 19 - Math.Ceiling((x - 370) / 47)
            End If
        End If

        Return -1
    End Function

    'callbacks
    Private Sub endMove(ByRef pl As Player, ByVal srcPos As Integer, ByVal destPos As Integer)
        'an eimai egw stelnw thn kinhsh ston antipalo
        If Board.controlledBy Is Board.localPlayer Then
            Protocol.sendMove(srcPos, destPos)
        End If

        Console.WriteLine("End move: " & pl.getRole & " -> " & srcPos & "," & destPos)
    End Sub

    Private Sub endCollect(ByRef pl As Player, ByVal pos As Integer)
        'au3anw ta checkers tou
        pl.setCheckersCollected(pl.getCheckersCollected + 1)

        'stelnw thn energia ston apomakrismeno xrhsth (an einai h seira mou)
        If Board.controlledBy Is Board.localPlayer Then
            Protocol.sendCollect(25 - pos)
        End If
        Console.WriteLine("End collect: " & pl.getRole & " -> " & pos)
    End Sub

    Private Sub endRound(ByRef pl As Player)
        'gameBoard.getDice.setDice(3, 3)
        Console.WriteLine("End round: " & pl.getRole)

        'arxikopoiw kai 3ekinaw to xronometro
        resetCountdown()

        Board.disable()

        If Board.controlledBy Is Board.localPlayer Then
            Board.controlledBy = Board.remotePlayer

        Else
            Board.controlledBy = Board.localPlayer

            'stelnw tis zaries ston antipalo
            recieveData.UpdateUI("rolldice")

            ' gameBoard.getdice.setdice(1, 1)

            'Board.enable()
        End If

    End Sub

    Private Sub resetCountdown()
        tmrRound.Enabled = False
        curRoundTime = Board.roundTime
        lblCountdown.Text = curRoundTime
    End Sub

    Private Sub unableToPlay(ByRef pl As Player)

        displayWarning("Καμία δυνατή κίνηση", 3500)

        'enallasw ton paixth pou exei ton elegxo tou board
        If pl Is Board.remotePlayer Then
            Board.controlledBy = Board.localPlayer

            Console.WriteLine("no more moves to " & Board.remotePlayer.getRole)
            'recieveData.UpdateUI("rolldice")

            'Board.enable()
        Else
            'stelnw minima ston allon paixti oti den exw kinhseis kai tou dinw ton elegxo
            'Thread.Sleep(100)
            Protocol.sendUnableToPlay()
            Board.controlledBy = Board.remotePlayer

            Console.WriteLine("no more moves to " & Board.localPlayer.getRole)
            Board.disable()
        End If


    End Sub

    Private Sub endGame(ByRef pl As Player)

        'au3anw tis nikes tou nikiti
        Dim opponent = If(pl Is Board.localPlayer, Board.remotePlayer, Board.localPlayer)

        'elegxw gia diplo
        If opponent.getCheckersCollected = 0 And pl.getCheckersCollected = 15 Then
            pl.setWins(pl.getWins + 2)
        Else
            pl.setWins(pl.getWins + 1)
        End If

        If pl.getWins = Board.wins Then
            If pl Is Board.localPlayer Then
                MsgBox("Μπράβο κέρδισες! " & "Έφτασες πρώτος στις " & Board.wins & " νίκες", MsgBoxStyle.Information)
            Else
                MsgBox("Λυπάμαι έχασες :(", MsgBoxStyle.Information)
            End If

            Me.Close()
            forceCloseConnection()
            frmMain.Show()
            Exit Sub
        End If

        Board.localPlayer.setIsReady(False)
        Board.localPlayer.setCheckersCollected(0)
        Board.remotePlayer.setIsReady(False)
        Board.remotePlayer.setCheckersCollected(0)

        gameBoard.removeAllHighlights()
        gameBoard.fillBoard("portes", Board.localPlayer.getColor)
        gbRoundTime.Visible = False

        pbxSixSided.Visible = False
        pbxSixSided2.Visible = False



        If pl Is Board.localPlayer Then
            lblLocalScore.Text = pl.getWins
            Board.controlledBy = Board.localPlayer
            If Not lblMessage.Visible = True Then
                displayWarning("Νίκησες την παρτίδα", 0)
            End If

        ElseIf pl Is Board.remotePlayer Then
            lblRemoteScore.Text = pl.getWins
            Board.controlledBy = Board.remotePlayer
            If Not lblMessage.Visible = True Then
                displayWarning("Έχασες την παρτίδα", 0)
            End If
        End If

        'midenizw to xronometro
        resetCountdown()

        Board.disable()

        Console.WriteLine("Winner: " & pl.getRole)

        'arxikopoihsh tou paixnidiou



        gameInitThread = New CallBackThread(Me, AddressOf initGameWork, AddressOf gamePlayCallback)
        gameInitThread.Start()

        btnStartGame.Enabled = True
    End Sub


    Private Sub endDice(ByVal dice1 As Integer, ByVal dice2 As Integer)

        Console.WriteLine("dice: " & dice1 & "," & dice2)

        'diavazw tis zaries
        'Dim dice As Integer() = gameBoard.getdice().getdiceArray

        If initDice Then
            Exit Sub
        End If

        'kanw highlight to nickname tou paixth pou exei seira na pai3ei
        If Board.controlledBy Is Board.localPlayer Then
            'kanw bold to onoma tou paixth
            'lblLocalName.Font = New Font(lblLocalName.Font, FontStyle.Bold)
            lblLocalName.ForeColor = Color.Orange
            'lblRemoteName.Font = New Font(lblLocalName.Font, FontStyle.Regular)
            lblRemoteName.ForeColor = Color.White
        Else

            'lblRemoteName.Font = New Font(lblLocalName.Font, FontStyle.Bold)
            lblRemoteName.ForeColor = Color.Orange
            'lblLocalName.Font = New Font(lblLocalName.Font, FontStyle.Regular)
            lblLocalName.ForeColor = Color.White
        End If

        'start Countdown
        lblCountdown.Text = Board.roundTime
        tmrRound.Enabled = True
        gbRoundTime.Visible = True

        'Gemizw ton pinaka movesArray me tis nees times
        gameMove.fillMovesArray()


        'ksekinaw to xronometro
        'lblCountdown.Text = "Time: " & Board.roundTime
        'lblCountdown.Visible = True
        'tmrRound.Enabled = True

        'an den einai h seira mou tote den kanw tipota
        If Not Board.localPlayer Is Board.controlledBy Then
            Exit Sub
        End If

        'ernergopoiw to board
        Board.enable()

        'elegxw an exw kamena poulia
        If gameBoard.hasHitDown Then
            'Board.disable()
            gameBoard.disableHighlight()

            'elegxos an mporei na pai3ei to kameno pouli efoson yparxei
            If Not gameMove.canMove(25) Then
                unableToPlay(Board.controlledBy)
                Exit Sub
            End If
        End If

        If Not gameMove.ableToPlay() Then
            unableToPlay(Board.controlledBy)
        End If
    End Sub

    Private Sub btnStartGame_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStartGame.Click
        Board.localPlayer.setIsReady(True)
        btnStartGame.Enabled = False
        Protocol.sendPlayerStatus()
    End Sub

    Private Sub tmrRound_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tmrRound.Tick
        curRoundTime = curRoundTime - 1
        lblCountdown.Text = curRoundTime

        If curRoundTime = 0 Then
            tmrRound.Enabled = False
            If Board.controlledBy Is Board.localPlayer Then

                displayWarning(Board.controlledBy.getNickname() & " τέλος χρόνου, έχασες την παρτίδα", 0)
                endGame(Board.remotePlayer)
            Else

                displayWarning("Ο χρόνος του " & Board.controlledBy.getNickname() & " έληξε και έχασε την παρτίδα", 0)
                endGame(Board.localPlayer)
            End If

            'endGame(Board.remotePlayer)

            Exit Sub
        End If

    End Sub

    Private Sub tmrWarning_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrWarning.Tick
        lblMessage.Hide()
        tmrWarning.Enabled = False
    End Sub

    Private Sub displayWarning(ByVal message As String, ByVal displayTime As Integer)
        lblMessage.Text = message
        lblMessage.Visible = True

        If displayTime > 0 Then
            tmrWarning.Interval = displayTime
            tmrWarning.Enabled = True
        End If

    End Sub

    'Delegate Sub tcpDelegate(ByVal msg As String)

    'tcp error events
    Private Sub tcpError(ByVal errMsg As String)
        'If Me.InvokeRequired = True Then
        'Dim d As New tcpDelegate(AddressOf tcpError)
        'Me.Invoke(d, New Object() {errMsg})
        'Exit Sub
        'End If

        'klinw thn syndesh
        forceCloseConnection()

        'enhmerwnw ton xrhsth
        MsgBox("Παρουσιάστηκε πρόβλημα στην σύνδεση!")

        'Me.Close()
        'frmMain.Show()
    End Sub

    Private Sub forceCloseConnection()
        If Not gameInitThread Is Nothing Then
            'stamataw ta threads
            gameInitThread.Dispose()
        End If

        If Not recieveData Is Nothing Then
            recieveData.Dispose()
        End If



        Board.tcpConnection.close()

        'midenizw tous local/remote players
        Board.localPlayer = Nothing
        Board.remotePlayer = Nothing
        Board.controlledBy = Nothing
        Board.tcpConnection = Nothing
    End Sub

    Private Sub globalError(ByVal sender As Object, ByVal args As ThreadExceptionEventArgs)
        Console.WriteLine(args.Exception.Message)
    End Sub
End Class