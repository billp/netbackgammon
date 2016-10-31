Imports System.Xml


Public Class Protocol
    'antikeimeno me to opoio 8a xeirizomai ta xml responses
    Private Shared xmlResponse As New XmlDocument

    Public Shared Sub sendConnectRequest()
        'stelnw aithsh syndeshs ws xml
        Board.tcpConnection.sendData("<connect>" & _
                                        "<appname>" & My.Application.Info.Title & "</appname>" & _
                                        "<version>" & My.Application.Info.Version.ToString & "</version>" & _
                                     "</connect>")
    End Sub

    Public Shared Function checkConnection() As Boolean
        'pernw to response apo ton client
        Dim response = Board.tcpConnection.getData()

        Try

            xmlResponse.LoadXml(response)

            Dim appname As String = xmlResponse.Item("connect").Item("appname").InnerText
            Dim version As String = xmlResponse.Item("connect").Item("version").InnerText

            If appname <> My.Application.Info.Title Or version <> My.Application.Info.Version.ToString Then
                Return False
            End If

        Catch er As XmlException
            'gia opoiodhpote parse error epistrefw false
            Return False
        End Try

        Return True

    End Function

    Public Shared Sub sendServerResponse(ByVal status As String)
        Board.tcpConnection.sendData("<init><status>" & status & "</status><version>" & My.Application.Info.Version.ToString & "</version></init>")
    End Sub

    Public Shared Function getServerResponse() As String()
        Dim response = Board.tcpConnection.getData()

        xmlResponse.LoadXml(response)

        Dim status As String = xmlResponse.Item("init").Item("status").InnerText
        Dim version As String = xmlResponse.Item("init").Item("version").InnerText


        Return New String() {status, version}
    End Function

    Public Shared Sub sendPlayer(ByVal pl As Player)
        Board.tcpConnection.sendData("<player>" & _
                                             "<nickname>" & pl.getNickname & "</nickname>" & _
                                             "<color>" & pl.getColor & "</color>" & _
                                             "<role>" & pl.getRole & "</role>" & _
                                         "</player>")
    End Sub

    Public Shared Sub sendBoardSettings(ByVal wins As Integer, ByVal rtime As Integer)
        Board.tcpConnection.sendData("<boardSettings>" & _
                                          "<wins>" & wins & "</wins>" & _
                                          "<roundTime>" & rtime & "</roundTime>" & _
                                      "</boardSettings>")
    End Sub

    Public Shared Function getBoardSettings() As Integer()
        Dim response = Board.tcpConnection.getData()
        xmlResponse.LoadXml(response)

        Dim wins As Integer = CInt(xmlResponse.Item("boardSettings").Item("wins").InnerText)
        Dim roundTime As Integer = CInt(xmlResponse.Item("boardSettings").Item("roundTime").InnerText)

        Return New Integer() {wins, roundTime}
    End Function

    Public Shared Function getPlayer() As Player
        Dim response = Board.tcpConnection.getData()
        xmlResponse.LoadXml(response)

        Dim nickname As String = xmlResponse.Item("player").Item("nickname").InnerText
        Dim color As String = xmlResponse.Item("player").Item("color").InnerText
        Dim role As String = xmlResponse.Item("player").Item("role").InnerText

        Return New Player(nickname, color, role)
    End Function


    Public Shared Sub sendPlayerStatus()
        Board.tcpConnection.sendData("<playerReady>true</playerReady>")
    End Sub

    Public Shared Function getRemotePlayerStatus(Optional ByVal xmlStr As String = "")
        Dim response = If(xmlStr = "", Board.tcpConnection.getData(), xmlStr)

        xmlResponse.LoadXml(response)
        Return Boolean.Parse(xmlResponse.Item("playerReady").InnerText)
    End Function

    Public Shared Sub sendDice(ByVal dice1 As Integer, ByVal dice2 As Integer)
        Board.tcpConnection.sendData("<dice><dice1>" & dice1 & "</dice1><dice2>" & dice2 & "</dice2></dice>")
    End Sub

    Public Shared Function getDice(Optional ByVal xmlStr As String = "") As Integer()
        Dim response = If(xmlStr = "", Board.tcpConnection.getData(), xmlStr)
        xmlResponse.LoadXml(response)

        Dim dice1 = CInt(xmlResponse.Item("dice").Item("dice1").InnerText)
        Dim dice2 = CInt(xmlResponse.Item("dice").Item("dice2").InnerText)

        'Board.tcpConnection.getTCPStream.Flush()

        Return New Integer() {dice1, dice2}
    End Function

    Public Shared Sub sendMove(ByRef srcCol As Integer, ByVal destCol As Integer)
        Board.tcpConnection.sendData("<move><srcCol>" & srcCol & "</srcCol><destCol>" & destCol & "</destCol></move>")
    End Sub

    Public Shared Function getMove(Optional ByVal xmlStr As String = "") As Integer()
        Board.tcpConnection.getTCPStream.Flush()

        Dim response = If(xmlStr = "", Board.tcpConnection.getData(), xmlStr)
        xmlResponse.LoadXml(response)

        Dim srcCol = CInt(xmlResponse.Item("move").Item("srcCol").InnerText)
        Dim destCol = CInt(xmlResponse.Item("move").Item("destCol").InnerText)

        Return New Integer() {srcCol, destCol}
    End Function

    Public Shared Sub sendUnableToPlay()
        Board.tcpConnection.sendData("<unableToPlay></unableToPlay>")
    End Sub

    Public Shared Sub sendCollect(ByVal col As Integer)
        Board.tcpConnection.sendData("<collect>" & col & "</collect>")
    End Sub

    Public Shared Function getCollect(Optional ByVal xmlStr As String = "")
        Dim response = If(xmlStr = "", Board.tcpConnection.getData(), xmlStr)
        xmlResponse.LoadXml(response)

        Return CInt(xmlResponse.Item("collect").InnerText)
    End Function

    Public Shared Sub sendDisconnect()
        Board.tcpConnection.sendData("<disconnect></disconnect>")
    End Sub
End Class
