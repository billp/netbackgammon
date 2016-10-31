Public Class Player
    Private nickname, color, role As String
    Private ready As Boolean
    Private checkersCollected, wins As Integer

    Public Sub New(ByVal nickname As String, ByVal color As String, ByVal role As String)
        Me.nickname = nickname
        Me.color = color
        Me.role = role
        Me.wins = 0
        Me.checkersCollected = 0
        Me.ready = False
    End Sub

    Public Function isReady() As Boolean
        Return ready
    End Function

    Public Sub setIsReady(ByVal ready As Boolean)
        Me.ready = ready
    End Sub


    Public Sub setWins(ByVal wins As Integer)
        Me.wins = wins
    End Sub

    Public Sub setCheckersCollected(ByVal num As Integer)
        Me.checkersCollected = num
    End Sub

    Public Function getCheckersCollected() As Integer
        Return Me.checkersCollected
    End Function

    Public Function getNickname() As String
        Return Me.nickname
    End Function

    Public Function getWins() As String
        Return Me.wins
    End Function

    Public Function getColor() As String
        Return Me.color
    End Function

    Public Function getRole() As String
        Return Me.role
    End Function
End Class
