Public Class Column
    'grafika gia hover
    Public Shared hoverBottom = Global.NetBackgammon.My.Resources.line_hover
    Public Shared hoverTop = Global.NetBackgammon.My.Resources.line_hoverflip

    'Private owner As String
    Private stepY As Integer
    'metavliti gia to an einai panw h katw to column
    Private pos As String

    Private colX, colY As Integer
    Private hoverX, hoverY As Integer
    Private checkers As ArrayList

    Private hover, shrankCol As PictureBox

    Public Sub New(ByVal colX As Integer, ByVal colY As Integer, ByVal pos As String)
        Me.colX = colX - 20
        Me.colY = colY
        Me.pos = pos

        Select Case pos
            Case "bottom"
                stepY = -Checker.blackChecker.Height + 3
            Case "top"
                stepY = Checker.whiteChecker.Height - 3
        End Select

        Me.checkers = New ArrayList()
    End Sub

    Public Sub addChecker(ByVal color As String)
        Dim checker As New Checker(color, colX, colY)

        checkers.Add(checker)

        'vazei to grafiko  tou checker sto pbBoard
        frmBoard.pbBoard.Controls.Add(checker.getGraphic)

        If getSize() > 5 Then
            shrinkAdd()
        End If

        'owner = player

        colY += stepY
    End Sub

    Public Sub shrinkAdd()

        'dimiougw mia kenh eikona sthn opoia 8a zwgrafistoun ola ta checkers
        Dim bmdest As New Bitmap(47, 230)
        Dim newgr As Graphics = Graphics.FromImage(bmdest)

        'ypologizw thn arxikh 8esh sthn opoia 8a eisagetai to ka8e checker
        Dim start As Integer = Nothing
        'ypologismos tou step tou ka8e checker pou 8a zografistei
        Dim stp = Math.Ceiling(bmdest.Height / getSize() - 4)
        Dim stpModulo = bmdest.Height Mod getSize() + 4


        Dim chkSize = Checker.blackChecker.Width

        If Not shrankCol Is Nothing Then
            frmBoard.pbBoard.Controls.Remove(shrankCol)
        End If

        'newgr.DrawRectangle(Pens.Black, 0, 0, bmdest.Width - 2, bmdest.Height - 2)
        shrankCol = New PictureBox()

        shrankCol.Left = colX

        Select Case pos
            Case "top"
                shrankCol.Top = 10
                start = 10
                stp = -stp
            Case "bottom"
                shrankCol.Top = 355 + 38
                start = bmdest.Height - 45

        End Select


        'shrink checkers
        For i = 1 To getSize()

            newgr.DrawImage(getChecker(i).getGraphic().Image, 0, start, chkSize, chkSize)
            start -= stp

        Next

        'apokripsi olwn twn prohgoumenwn
        For i = 1 To getSize()
            getChecker(i).showGraphic(False)
        Next



        shrankCol.Height = bmdest.Height
        shrankCol.Width = bmdest.Width

        shrankCol.Image = bmdest
        shrankCol.BackColor = Color.Transparent
        shrankCol.Visible = True

        AddHandler shrankCol.MouseMove, AddressOf frmBoard.pbBoard_MouseMove
        AddHandler shrankCol.DoubleClick, AddressOf frmBoard.pbBoard_DoubleClick
        AddHandler shrankCol.MouseClick, AddressOf frmBoard.pbBoard_Click

        frmBoard.pbBoard.Controls.Add(shrankCol)
    End Sub

    Public Function removeChecker() As Checker
        Dim pos As Integer = checkers.Count - 1
        Dim tmp As Checker = checkers.Item(pos)

        checkers.RemoveAt(pos)
        frmBoard.pbBoard.Controls.Remove(tmp.getGraphic)
        colY -= stepY

        If getSize() < 6 Then
            frmBoard.pbBoard.Controls.Remove(shrankCol)

            For i = 1 To getSize()
                getChecker(i).undoMove()
                getChecker(i).showGraphic(True)
                getChecker(i).setParent(frmBoard.pbBoard)
            Next

            shrankCol = Nothing
        Else
            shrinkAdd()
        End If


        'If isEmpty() Then
        'owner = Nothing
        'End If

        Return tmp
    End Function

    Public Sub removeAllCheckers(ByVal cnt As Integer)
        For i = 0 To cnt - 1
            removeChecker()
        Next
    End Sub

    Public Function getChecker(ByVal pos As Integer) As Checker
        Return checkers.Item(pos - 1)
    End Function

    Public Function getTopCheckerColor() As String
        If getSize() = 0 Then
            Return Nothing
        End If

        Return getChecker(getSize).getCheckerType
    End Function

    Public Function isEmpty() As Integer
        Return (checkers.Count = 0)
    End Function

    Public Function getSize() As Integer
        Return (checkers.Count)
    End Function

    Public Function getOwner() As String
        If getSize() > 1 Then
            Return getChecker(getSize()).getCheckerType
        End If
        Return Nothing
    End Function

    Public Function getPos() As String
        Return pos
    End Function

    Public Sub setHoverXY(ByVal x As Integer, ByVal y As Integer)
        Me.hoverX = x
        Me.hoverY = y
    End Sub

    Public Function isHighlighted() As Boolean
        Return Not hover Is Nothing
    End Function

    Public Sub highlight()
        'elegxw an yparxei hdh to hover
        If isHighlighted() Then
            Exit Sub
        End If

        'dimiourgia grafikou hover
        hover = New PictureBox()

        'eisagwgh ths eikonas (panw h katw) tou hover
        Select Case pos
            Case "top"
                hover.Image = hoverTop
            Case "bottom"
                hover.Image = hoverBottom
        End Select

        '8etw tis idiothtes tou hover
        Me.hover.Left = hoverX
        Me.hover.Top = hoverY
        Me.hover.Height = hover.Image.Height
        Me.hover.Width = hover.Image.Width
        Me.hover.BackColor = Color.Transparent

        'pros8hkh tou grafikou sto board
        frmBoard.pbBoard.Controls.Add(Me.hover)

        AddHandler Me.hover.MouseMove, AddressOf frmBoard.pbBoard_MouseMove
        AddHandler Me.hover.Click, AddressOf frmBoard.pbBoard_Click
        AddHandler Me.hover.DoubleClick, AddressOf frmBoard.pbBoard_DoubleClick

        Dim start, stp As Integer

        'metakinish olwn twn checkers panw sto hover
        If getSize() < 6 Then
            Select Case Me.pos
                Case "bottom"
                    start = 204
                    stp = -44
                Case "top"
                    start = -3
                    stp = 44
            End Select

            For i = 1 To getSize()
                getChecker(i).setParent(hover)
                getChecker(i).getGraphic.BringToFront()
                getChecker(i).move(0, start)

                start += stp
            Next
        Else
            Select Case Me.pos
                Case "bottom"
                    start = 22
                    stp = -44
                Case "top"
                    start = -10
                    stp = 44
            End Select

            shrankCol.Parent = hover
            shrankCol.Left = 0
            shrankCol.Top = start - 3
        End If
    End Sub

    Public Sub removeHighlight()
        If Not isHighlighted() Then
            Exit Sub
        End If

        For i = 1 To getSize()
            If getSize() > 5 Then
                shrinkAdd()
                Exit For
            End If

            getChecker(i).undoMove()
            getChecker(i).setParent(frmBoard.pbBoard)
        Next

        frmBoard.pbBoard.Controls.Remove(hover)

        hover = Nothing
    End Sub

End Class