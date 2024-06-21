Imports System.Drawing.Drawing2D
Imports System.Net.Http
Imports System.Text
Imports Newtonsoft.Json

Public Class CreateSubmissionForm
    Inherits Form

    Private WithEvents txtName As TextBox
    Private WithEvents txtEmail As TextBox
    Private WithEvents txtPhoneNumber As TextBox
    Private WithEvents txtGitHubRepoLink As TextBox
    Private WithEvents btnSubmit As NextRoundedButton
    Private WithEvents lblName As Label
    Private WithEvents lblEmail As Label
    Private WithEvents lblPhone As Label
    Private WithEvents lblGitHubLink As Label
    Private WithEvents btnStopwatch As RoundButton
    Private WithEvents lblStopwatchValue As Label

    Private stopwatch As New Stopwatch()
    Private WithEvents timer As Timer

    Public Sub New()
        InitializeComponent()
        InitializeTextBoxes()

        timer = New Timer()
        timer.Interval = 1000
        AddHandler timer.Tick, AddressOf Timer_Tick
    End Sub

    Private Sub InitializeComponent()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.txtPhoneNumber = New System.Windows.Forms.TextBox()
        Me.txtGitHubRepoLink = New System.Windows.Forms.TextBox()
        Me.btnStopwatch = New RoundButton()
        Me.btnSubmit = New NextRoundedButton()
        Me.lblName = New System.Windows.Forms.Label()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.lblPhone = New System.Windows.Forms.Label()
        Me.lblGitHubLink = New System.Windows.Forms.Label()
        Me.lblStopwatchValue = New System.Windows.Forms.Label()
        Me.SuspendLayout()


        SetLabelStyle(Me.lblName, "Name:", New Point(12, 20))
        SetLabelStyle(Me.lblEmail, "Email:", New Point(12, 80))
        SetLabelStyle(Me.lblPhone, "Phone:", New Point(12, 140))
        SetLabelStyle(Me.lblGitHubLink, "GitHub Link:", New Point(12, 200))


        SetTextBoxStyle(Me.txtName, New Point(180, 30))
        SetTextBoxStyle(Me.txtEmail, New Point(180, 90))
        SetTextBoxStyle(Me.txtPhoneNumber, New Point(180, 150))
        SetTextBoxStyle(Me.txtGitHubRepoLink, New Point(180, 210))

        Me.lblStopwatchValue.AutoSize = True
        Me.lblStopwatchValue.Location = New System.Drawing.Point(320, 260)
        Me.lblStopwatchValue.Name = "lblStopwatchValue"
        Me.lblStopwatchValue.Size = New System.Drawing.Size(0, 15)
        Me.lblStopwatchValue.TabIndex = 10


        Me.btnStopwatch.Location = New System.Drawing.Point(30, 260)
        Me.btnStopwatch.Name = "btnStopwatch"
        Me.btnStopwatch.Size = New System.Drawing.Size(280, 30)
        Me.btnStopwatch.TabIndex = 8
        Me.btnStopwatch.Text = "TOGGLE STOPWATCH (CTRL + T"
        Me.btnStopwatch.UseVisualStyleBackColor = True

        Me.btnSubmit.Location = New System.Drawing.Point(130, 320)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(220, 30)
        Me.btnSubmit.TabIndex = 9
        Me.btnSubmit.Text = "Submit (CTRL + S"
        Me.btnSubmit.UseVisualStyleBackColor = True

        Me.Controls.Add(Me.txtGitHubRepoLink)
        Me.Controls.Add(Me.lblGitHubLink)
        Me.Controls.Add(Me.txtPhoneNumber)
        Me.Controls.Add(Me.lblPhone)
        Me.Controls.Add(Me.txtEmail)
        Me.Controls.Add(Me.lblEmail)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.btnStopwatch)
        Me.Controls.Add(Me.lblStopwatchValue)
        Me.Controls.Add(Me.btnSubmit)

        Me.ClientSize = New System.Drawing.Size(550, 420)


        Me.Name = "CreateSubmissionForm"
        Me.Text = "Create Submission"
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub

    Private Sub SetLabelStyle(lbl As Label, text As String, location As Point)
        lbl.AutoSize = True
        lbl.Location = location
        lbl.Name = "lbl" & text.Replace(" ", "")
        lbl.Size = New System.Drawing.Size(70, 25)
        lbl.TabIndex = 0
        lbl.Text = text
        lbl.Font = New Font(lbl.Font.FontFamily, 12, FontStyle.Regular)
        lbl.Padding = New Padding(10)
        Me.Controls.Add(lbl)
    End Sub

    Private Sub SetTextBoxStyle(txt As TextBox, location As Point)
        txt.Location = location
        txt.Name = "txt" & location.Y.ToString()
        txt.Size = New System.Drawing.Size(280, 30)
        txt.TabIndex = 1
        txt.ForeColor = Color.Gray
        txt.Margin = New Padding(10, 5, 10, 5)
        txt.Padding = New Padding(5)
        txt.BorderStyle = BorderStyle.FixedSingle
        Me.Controls.Add(txt)
    End Sub

    Private Sub InitializeTextBoxes()
        SetPlaceholderText(txtName, "Enter your name")
        SetPlaceholderText(txtEmail, "Enter your email")
        SetPlaceholderText(txtPhoneNumber, "Enter your phone number")
        SetPlaceholderText(txtGitHubRepoLink, "Enter your GitHub repo link")

        AddHandler txtName.GotFocus, AddressOf RemovePlaceholderText
        AddHandler txtName.LostFocus, AddressOf AddPlaceholderText
        AddHandler txtEmail.GotFocus, AddressOf RemovePlaceholderText
        AddHandler txtEmail.LostFocus, AddressOf AddPlaceholderText
        AddHandler txtPhoneNumber.GotFocus, AddressOf RemovePlaceholderText
        AddHandler txtPhoneNumber.LostFocus, AddressOf AddPlaceholderText
        AddHandler txtGitHubRepoLink.GotFocus, AddressOf RemovePlaceholderText
        AddHandler txtGitHubRepoLink.LostFocus, AddressOf AddPlaceholderText
    End Sub

    Private Sub SetPlaceholderText(textBox As TextBox, placeholder As String)
        textBox.Text = placeholder
        textBox.ForeColor = Color.Gray
    End Sub

    Private Sub RemovePlaceholderText(sender As Object, e As EventArgs)
        Dim textBox = DirectCast(sender, TextBox)
        If textBox.ForeColor = Color.Gray Then
            textBox.Text = ""
            textBox.ForeColor = Color.Black
        End If
    End Sub

    Private Sub AddPlaceholderText(sender As Object, e As EventArgs)
        Dim textBox = DirectCast(sender, TextBox)

    End Sub

    Private Sub btnStopwatch_Click(sender As Object, e As EventArgs) Handles btnStopwatch.Click
        If stopwatch.IsRunning Then
            stopwatch.Stop()
            btnStopwatch.Text = "Resume Stopwatch"
            timer.Stop()
        Else
            stopwatch.Start()
            btnStopwatch.Text = "Pause Stopwatch"
            timer.Start()
        End If
    End Sub

    Private Sub Timer_Tick(sender As Object, e As EventArgs)
        UpdateStopwatchDisplay()
    End Sub

    Private Sub UpdateStopwatchDisplay()
        Dim ts As TimeSpan = stopwatch.Elapsed
        lblStopwatchValue.Text = String.Format("{0:00}:{1:00}:{2:00}", ts.Hours, ts.Minutes, ts.Seconds)
    End Sub

    Private Async Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim submission = New With {
            .name = txtName.Text,
            .email = txtEmail.Text,
            .phone = txtPhoneNumber.Text,
            .github_link = txtGitHubRepoLink.Text,
            .stopwatch_value = lblStopwatchValue.Text
        }

        Await SubmitData(submission)
    End Sub

    Private Async Function SubmitData(submission As Object) As Task
        Using client As New HttpClient()
            client.BaseAddress = New Uri("http://localhost:3000")

            Dim json As String = JsonConvert.SerializeObject(submission)
            Dim content As New StringContent(json, Encoding.UTF8, "application/json")

            Dim response = Await client.PostAsync("/submit", content)
            If response.IsSuccessStatusCode Then
                MessageBox.Show("Submission successful!")
            Else
                MessageBox.Show("Submission failed.")
            End If
        End Using
    End Function

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        If keyData = (Keys.Control Or Keys.S) Then
            btnSubmit.PerformClick()
            Return True
        ElseIf keyData = (Keys.Control Or Keys.T) Then
            btnStopwatch.PerformClick()
            Return True
        End If

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function
End Class



Public Class RoundButton
    Inherits Button

    Private _radius As Integer = 8  ' Radius of rounded corners

    Protected Overrides Sub OnPaint(pevent As PaintEventArgs)
        MyBase.OnPaint(pevent)

        Dim g As Graphics = pevent.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias

        Dim rect As New Rectangle(0, 0, Me.Width - 1, Me.Height + 1)

        Dim graphicsPath As New GraphicsPath()
        graphicsPath.AddArc(rect.X, rect.Y, _radius, _radius, 180, 90)
        graphicsPath.AddArc(rect.X + rect.Width - _radius, rect.Y, _radius, _radius, 270, 90)
        graphicsPath.AddArc(rect.X + rect.Width - _radius, rect.Y + rect.Height - _radius, _radius, _radius, 0, 90)
        graphicsPath.AddArc(rect.X, rect.Y + rect.Height - _radius, _radius, _radius, 90, 90)
        graphicsPath.CloseAllFigures()

        Me.Region = New Region(graphicsPath)

        Dim shadowOffset As Integer = 5
        Dim shadowColor As Color = Color.FromArgb(100, 0, 0, 0)
        Dim shadowPath As New GraphicsPath()
        shadowPath.AddArc(rect.X + shadowOffset, rect.Y + shadowOffset, _radius, _radius, 180, 90)
        shadowPath.AddArc(rect.X + rect.Width - _radius + shadowOffset, rect.Y + shadowOffset, _radius, _radius, 270, 90)
        shadowPath.AddArc(rect.X + rect.Width - _radius + shadowOffset, rect.Y + rect.Height - _radius + shadowOffset, _radius, _radius, 0, 90)
        shadowPath.AddArc(rect.X + shadowOffset, rect.Y + rect.Height - _radius + shadowOffset, _radius, _radius, 90, 90)
        shadowPath.CloseAllFigures()
        g.FillPath(New SolidBrush(shadowColor), shadowPath)

        Using brush As New LinearGradientBrush(rect, Color.LightYellow, Color.Yellow, LinearGradientMode.Vertical)
            g.FillPath(brush, graphicsPath)
        End Using

        Using pen As New Pen(Color.Yellow, 1)
            g.DrawPath(pen, graphicsPath)
        End Using

        TextRenderer.DrawText(g, Me.Text, Me.Font, rect, Me.ForeColor, TextFormatFlags.HorizontalCenter Or TextFormatFlags.VerticalCenter)
    End Sub

    Protected Overrides Sub OnResize(e As EventArgs)
        MyBase.OnResize(e)
        Me.Refresh()
    End Sub
End Class



Public Class NextRoundedButton
    Inherits Button

    Protected Overrides Sub OnPaint(pevent As PaintEventArgs)
        ' Create graphics object
        Dim g As Graphics = pevent.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias

        ' Define the button rectangle and corner radius
        Dim rect As New Rectangle(0, 0, Me.Width, Me.Height)
        Dim radius As Integer = 8

        ' Create path for rounded rectangle
        Dim graphicsPath As New GraphicsPath()
        graphicsPath.AddArc(rect.X, rect.Y, radius, radius, 180, 90)
        graphicsPath.AddArc(rect.X + rect.Width - radius, rect.Y, radius, radius, 270, 90)
        graphicsPath.AddArc(rect.X + rect.Width - radius, rect.Y + rect.Height - radius, radius, radius, 0, 90)
        graphicsPath.AddArc(rect.X, rect.Y + rect.Height - radius, radius, radius, 90, 90)
        graphicsPath.CloseAllFigures()

        ' Set button region
        Me.Region = New Region(graphicsPath)

        ' Draw shadow
        Dim shadowOffset As Integer = 5
        Dim shadowColor As Color = Color.FromArgb(100, 0, 0, 0)
        Dim shadowPath As New GraphicsPath()
        shadowPath.AddArc(rect.X + shadowOffset, rect.Y + shadowOffset, radius, radius, 180, 90)
        shadowPath.AddArc(rect.X + rect.Width - radius + shadowOffset, rect.Y + shadowOffset, radius, radius, 270, 90)
        shadowPath.AddArc(rect.X + rect.Width - radius + shadowOffset, rect.Y + rect.Height - radius + shadowOffset, radius, radius, 0, 90)
        shadowPath.AddArc(rect.X + shadowOffset, rect.Y + rect.Height - radius + shadowOffset, radius, radius, 90, 90)
        shadowPath.CloseAllFigures()
        g.FillPath(New SolidBrush(shadowColor), shadowPath)


        Using brush As New LinearGradientBrush(rect, Color.LightBlue, Color.BlueViolet, LinearGradientMode.Vertical)
            g.FillPath(brush, graphicsPath)
        End Using


        ' Draw text
        TextRenderer.DrawText(g, Me.Text, Me.Font, rect, Me.ForeColor, TextFormatFlags.HorizontalCenter Or TextFormatFlags.VerticalCenter)
    End Sub
End Class