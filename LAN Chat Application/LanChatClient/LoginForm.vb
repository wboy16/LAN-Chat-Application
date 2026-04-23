Public Class LoginForm

    Private Sub btnConnect_Click(sender As Object, e As EventArgs) Handles btnConnect.Click
        If String.IsNullOrWhiteSpace(txtUsername.Text) Then
            MessageBox.Show("Please enter a username first!", "Missing Info")
            Return
        End If

        Try
            lblStatus.Text = "Connecting..."
            lblStatus.ForeColor = Color.Orange

            Dim ip As String = txtServerIP.Text
            Dim port As Integer = 8888

            ' 1. Instantiate our new OOP class
            Dim myConnection As New ClientConnection(txtUsername.Text)

            ' 2. Tell the object to connect
            myConnection.ConnectToServer(ip, port)

            ' 3. Pass the object directly into the ChatForm constructor!
            If myConnection.Socket.Connected Then
                Dim chatWindow As New ChatForm(myConnection)
                chatWindow.Show()
                Me.Hide()
            End If

        Catch ex As Exception
            lblStatus.Text = "Connection Failed."
            lblStatus.ForeColor = Color.Red
            MessageBox.Show("Could not connect to the server. Is it running?", "Error")
        End Try
    End Sub
End Class