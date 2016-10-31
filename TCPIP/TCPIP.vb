Imports System.Net
Imports System.Net.Sockets

Public Class TCPIP
    Public Shared localIP As String
    Private tcpStream As NetworkStream
    Private tcpServer As TcpListener
    Private tcpClient As TcpClient
    Private mode As String

    Public Sub New(ByVal ip As String, ByVal port As Integer, ByVal mode As String)
        Me.mode = mode

        Try
            If mode = "server" Then
                tcpServer = New TcpListener(IPAddress.Parse(ip), port)
                tcpServer.Start()
            ElseIf mode = "client" Then
                tcpClient = New TcpClient()
                'tcpClient.SendTimeout = 3000

                tcpClient.Connect(ip, port)
                tcpStream = tcpClient.GetStream
            End If
        Catch se As SocketException
            RaiseEvent tcpConnectError(se.Message)
        End Try
    End Sub

    Public Sub sendData(ByVal strData As String)
        Try
            Dim dataBytes() = System.Text.Encoding.UTF8.GetBytes(strData)
            tcpStream.Write(dataBytes, 0, dataBytes.Length)
            tcpStream.Flush()
        Catch e As Exception
            RaiseEvent tcpError(e.Message)
        End Try
        Threading.Thread.Sleep(100)
    End Sub

    Public Function getData() As String
        'tcpStream.Flush()
        Dim dataBytes(512) As Byte
        Dim strData = ""
        Dim byteCount As Integer

        Do
            Try
                'End While
                byteCount = tcpStream.Read(dataBytes, 0, dataBytes.Length)

                strData = strData & System.Text.Encoding.UTF8.GetString(dataBytes)
                dataBytes = New Byte(512) {}

            Catch e As Exception
                RaiseEvent tcpError(e.Message)
            End Try
        Loop While tcpStream.DataAvailable

        Return strData

    End Function

    Public Function getTCPServer() As TcpListener
        Return tcpServer
    End Function

    Public Function getTCPClient() As TcpClient
        Return tcpClient
    End Function

    Public Function getTCPStream() As NetworkStream
        Return tcpStream
    End Function

    Public Sub setTCPStream(ByRef netStream As NetworkStream)
        tcpStream = netStream
    End Sub

    Public Sub close()
        If mode = "server" Then
            tcpServer.Stop()
        Else
            tcpClient.Close()
        End If
    End Sub

    Public Shared Function retrieveLocalIpV4() As String
        Dim localAddresses As IPAddress() = Dns.GetHostEntry(Dns.GetHostName).AddressList

        For Each curAddr As IPAddress In localAddresses
            If curAddr.AddressFamily.ToString = "InterNetwork" Then
                Return curAddr.ToString
            End If
        Next

        Return Nothing
    End Function

    Public Shared Function retrieveRemoteIpV4() As String
        Dim wc As New WebClient()
        Return wc.DownloadString("http://aetos.it.teithe.gr/~vpanag/ip.php")
    End Function

    'Error handlers
    Public Shared Event tcpConnectError(ByVal errMsg As String)
    Public Shared Event tcpError(ByVal errMsg As String)
End Class
