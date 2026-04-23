<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class LoginForm
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
        txtUsername = New TextBox()
        txtServerIP = New TextBox()
        btnConnect = New Button()
        lblStatus = New Label()
        SuspendLayout()
        ' 
        ' txtUsername
        ' 
        txtUsername.Location = New Point(290, 58)
        txtUsername.Name = "txtUsername"
        txtUsername.Size = New Size(100, 23)
        txtUsername.TabIndex = 0
        ' 
        ' txtServerIP
        ' 
        txtServerIP.Location = New Point(290, 144)
        txtServerIP.Name = "txtServerIP"
        txtServerIP.Size = New Size(100, 23)
        txtServerIP.TabIndex = 1
        txtServerIP.Text = "127.0.0.1"
        ' 
        ' btnConnect
        ' 
        btnConnect.Location = New Point(387, 224)
        btnConnect.Name = "btnConnect"
        btnConnect.Size = New Size(75, 23)
        btnConnect.TabIndex = 2
        btnConnect.Text = "Connect"
        btnConnect.UseVisualStyleBackColor = True
        ' 
        ' lblStatus
        ' 
        lblStatus.AutoSize = True
        lblStatus.Location = New Point(582, 228)
        lblStatus.Name = "lblStatus"
        lblStatus.Size = New Size(39, 15)
        lblStatus.TabIndex = 3
        lblStatus.Text = "Ready"
        ' 
        ' LoginForm
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(845, 319)
        Controls.Add(lblStatus)
        Controls.Add(btnConnect)
        Controls.Add(txtServerIP)
        Controls.Add(txtUsername)
        Name = "LoginForm"
        Text = "Form1"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents txtUsername As TextBox
    Friend WithEvents txtServerIP As TextBox
    Friend WithEvents btnConnect As Button
    Friend WithEvents lblStatus As Label

End Class
