Public Class Form1
    ' Declare our ServerManager and listen for its events
    Private WithEvents myServer As ServerManager

    Private Sub btnStartServer_Click(sender As Object, e As EventArgs) Handles btnStartServer.Click
        myServer = New ServerManager()
        myServer.StartServer(8888)

        btnStartServer.Text = "Server Running"
        btnStartServer.Enabled = False
    End Sub

    ' This catches logs from the ServerManager and safely adds thm to the RichTextBox
    Private Sub myServer_LogUpdated(message As String) Handles myServer.LogUpdated
        Me.Invoke(Sub() rtbLogs.AppendText(DateTime.Now.ToString("HH:mm:ss") & " - " & message & Environment.NewLine))
    End Sub

    Private Sub rtbLogs_TextChanged(sender As Object, e As EventArgs) Handles rtbLogs.TextChanged

    End Sub
End Class
