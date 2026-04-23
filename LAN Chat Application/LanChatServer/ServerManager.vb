Imports System.Net
Imports System.Net.Sockets
Imports System.Threading
Imports System.Collections.Generic

Public Class ServerManager
    Private serverListener As TcpListener
    Private listenThread As Thread
    Private isServerRunning As Boolean = False

    ' A list to keep track of all connection clients
    Private connectedClients As New List(Of TcpClient)

    ' Event to pass log messages back to the UI
    Public Event LogUpdated(message As String)

    ' Starts the server
    Public Sub StartServer(port As Integer)
        If Not isServerRunning Then
            serverListener = New TcpListener(IPAddress.Any, port)
            serverListener.Start()
            isServerRunning = True

            RaiseEvent LogUpdated("Server started on port " & port & ". Waiting for connections...")

            listenThread = New Thread(AddressOf ListenForClients)
            listenThread.IsBackground = True
            listenThread.Start()
        End If
    End Sub

    ' Listens for new users connecting
    Private Sub ListenForClients()
        While isServerRunning
            Try
                Dim client As TcpClient = serverListener.AcceptTcpClient()
                connectedClients.Add(client)
                RaiseEvent LogUpdated("A new client connected!")

                ' Create a dedicated thread for this specific user
                Dim clientThread As New Thread(AddressOf HandleClientMessages)
                clientThread.IsBackground = True
                clientThread.Start(client)
            Catch ex As Exception
                RaiseEvent LogUpdated("Server Error: " & ex.Message)
            End Try
        End While
    End Sub

    ' Listens for messages from a specific user
    Private Sub HandleClientMessages(clientObj As Object)
        Dim client As TcpClient = CType(clientObj, TcpClient)
        Dim stream As NetworkStream = client.GetStream()
        Dim bytes(10024) As Byte

        While True
            Try
                Dim bytesRead As Integer = stream.Read(bytes, 0, bytes.Length)
                If bytesRead = 0 Then Exit While ' Client disconnected

                Dim message As String = System.Text.Encoding.ASCII.GetString(bytes, 0, bytesRead)
                RaiseEvent LogUpdated("Broadcasting: " & message)

                ' Send the message to everyone
                BroadcastMessage(message)

                ' This saves the message to our temporary text file
                SaveMessageToFile(message)
            Catch ex As Exception
                Exit While
            End Try
        End While

        connectedClients.Remove(client)
        client.Close()
    End Sub

    ' Sends a message to every user in the list
    Private Sub BroadcastMessage(message As String)
        Dim outStream As Byte() = System.Text.Encoding.ASCII.GetBytes(message)
        For Each client As TcpClient In connectedClients
            Try
                Dim stream As NetworkStream = client.GetStream()
                stream.Write(outStream, 0, outStream.Length)
                stream.Flush()
            Catch ex As Exception
                ' Ignore if a client fails
            End Try
        Next
    End Sub

    ' Method to save messages to a local text file
    Private Sub SaveMessageToFile(message As String)
        Try
            ' This will create/save the file in the Server project's bin/Debug folder
            Dim filePath As String = "ChatHistoryLog.txt"

            ' Add a timestamp to the text file entry
            Dim logEntry As String = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & " - " & message & Environment.NewLine

            ' AppendALLText automatically creates the file if it doesn't exist, and adds the new line to the bottom
            System.IO.File.AppendAllText(filePath, logEntry)
        Catch ex As Exception
            RaiseEvent LogUpdated("Failed to save to file: " & ex.Message)
        End Try
    End Sub
End Class
