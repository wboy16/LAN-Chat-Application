<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChatForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        rtbChatHistory = New RichTextBox()
        txtMessage = New TextBox()
        btnSend = New Button()
        SuspendLayout()
        ' 
        ' rtbChatHistory
        ' 
        rtbChatHistory.Location = New Point(348, 55)
        rtbChatHistory.Name = "rtbChatHistory"
        rtbChatHistory.Size = New Size(275, 221)
        rtbChatHistory.TabIndex = 0
        rtbChatHistory.Text = ""
        ' 
        ' txtMessage
        ' 
        txtMessage.Location = New Point(348, 313)
        txtMessage.Name = "txtMessage"
        txtMessage.Size = New Size(100, 23)
        txtMessage.TabIndex = 1
        ' 
        ' btnSend
        ' 
        btnSend.Location = New Point(519, 312)
        btnSend.Name = "btnSend"
        btnSend.Size = New Size(75, 23)
        btnSend.TabIndex = 2
        btnSend.Text = "Send"
        btnSend.UseVisualStyleBackColor = True
        ' 
        ' ChatForm
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1070, 620)
        Controls.Add(btnSend)
        Controls.Add(txtMessage)
        Controls.Add(rtbChatHistory)
        Name = "ChatForm"
        Text = "ChatForm"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents rtbChatHistory As RichTextBox
    Friend WithEvents txtMessage As TextBox
    Friend WithEvents btnSend As Button
End Class
