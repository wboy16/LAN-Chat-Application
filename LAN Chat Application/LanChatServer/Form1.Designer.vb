<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        btnStartServer = New Button()
        rtbLogs = New RichTextBox()
        SuspendLayout()
        ' 
        ' btnStartServer
        ' 
        btnStartServer.Location = New Point(461, 313)
        btnStartServer.Name = "btnStartServer"
        btnStartServer.Size = New Size(75, 23)
        btnStartServer.TabIndex = 0
        btnStartServer.Text = "Start Server"
        btnStartServer.UseVisualStyleBackColor = True
        ' 
        ' rtbLogs
        ' 
        rtbLogs.Location = New Point(366, 81)
        rtbLogs.Name = "rtbLogs"
        rtbLogs.Size = New Size(258, 207)
        rtbLogs.TabIndex = 1
        rtbLogs.Text = ""
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(937, 512)
        Controls.Add(rtbLogs)
        Controls.Add(btnStartServer)
        Name = "Form1"
        Text = "Form1"
        ResumeLayout(False)
    End Sub

    Friend WithEvents btnStartServer As Button
    Friend WithEvents rtbLogs As RichTextBox

End Class
