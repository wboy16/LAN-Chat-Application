Public Class ChatForm
    ' A private variable to hold the connection object for this specific form. Later we added WithEvents which allows this form to catch the MessageReceived event
    Private WithEvents _myConnection As ClientConnection

    ' We modify the constructor to require a ClientConnection object
    Public Sub New(connectionObject As ClientConnection)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.


        ' Store the passed object so we can use it to send/receive messages!
        _myConnection = connectionObject

        ' Just to test that it worked, lets change the window title
        Me.Text = "LAN Chat - Logged in as: " & _myConnection.Username
    End Sub

    ' As soon as the chat window opens, tell the connection to start listening
    Private Sub ChatForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _myConnection.StartListening()
    End Sub

    ' When a message arrives from the server, append it to the chat history
    Private Sub _myConnection_MessageReceived(message As String) Handles _myConnection.MessageReceived
        ' We must Invoke because the message came from a background thread
        Me.Invoke(Sub() rtbChatHistory.AppendText(message & Environment.NewLine))
    End Sub


    Private Sub btnSend_Click(sender As Object, e As EventArgs) Handles btnSend.Click
        Dim message As String = txtMessage.Text

        If Not String.IsNullOrWhiteSpace(message) Then
            ' 1. Format the message to include the user's name (e.g., "Erastus: Hello world!")
            Dim formattedMessage As String = _myConnection.Username & ": " & message

            ' 2. Usins the OOP object to send the messge to the server
            _myConnection.SendMessage(formattedMessage)

            ' 3. Clear the text box so they can type another message
            txtMessage.Clear()
        End If
    End Sub
End Class