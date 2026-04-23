Imports System.Net.Sockets
Imports System.Threading ' This is needed to run our listening loop in the background

Public Class ClientConnection
    ' Properties encapsulate the data belonging to this specific user's connection
    Public Property Socket As TcpClient
    Public Property Stream As NetworkStream
    Public Property Username As String

    ' This event fires whenever the server sends us a message
    Public Event MessageReceived(message As String)

    ' Constructor to initialise the object with a username
    Public Sub New(user As String)
        Username = user
        Socket = New TcpClient()
    End Sub

    ' Method to handle the connection logic
    Public Sub ConnectToServer(ip As String, port As Integer)
        Socket.Connect(ip, port)
        Stream = Socket.GetStream()
    End Sub

    ' Method to send a message to the server
    Public Sub SendMessage(message As String)
        If Socket IsNot Nothing AndAlso Socket.Connected Then
            'Convert our text message into a byte array (as computer send data as bytes over the network)
            Dim outStream As Byte() = System.Text.Encoding.ASCII.GetBytes(message)

            ' Write the bytes to the network stream
            Stream.Write(outStream, 0, outStream.Length)
            Stream.Flush()
        End If
    End Sub

    ' This starts the background thread to listen for server broadcasts
    Public Sub StartListening()
        Dim listenThread As New Thread(AddressOf ReceiveMessages)
        listenThread.IsBackground = True
        listenThread.Start()
    End Sub

    ' This is the actual loop that waits for data from the server
    Private Sub ReceiveMessages()
        Dim bytes(10024) As Byte
        While True
            Try
                ' This line waits until the server sends something
                Dim bytesRead As Integer = Stream.Read(bytes, 0, bytes.Length)

                If bytesRead = 0 Then Exit While ' Server disconnected

                ' Convert bytes to text and trigger the event!
                Dim message As String = System.Text.Encoding.ASCII.GetString(bytes, 0, bytesRead)
                RaiseEvent MessageReceived(message)
            Catch ex As Exception
                Exit While
            End Try
        End While
    End Sub
End Class
