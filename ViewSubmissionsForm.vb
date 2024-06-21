Imports System.Net.Http
Imports System.Text
Imports Newtonsoft.Json
Imports System.Drawing.Drawing2D

Public Class ViewSubmissionsForm
    Inherits Form

    Private WithEvents lblName As Label
    Private WithEvents lblEmail As Label
    Private WithEvents lblPhone As Label
    Private WithEvents lblGitHubLink As Label
    Private WithEvents lblStopwatchValue As Label
    Private WithEvents txtName As TextBox
    Private WithEvents txtEmail As TextBox
    Private WithEvents txtPhone As TextBox
    Private WithEvents txtGitHubLink As TextBox
    Private WithEvents txtStopwatchValue As TextBox
    Private WithEvents btnPrevious As RoundedButton
    Private WithEvents btnNext As SubmitRoundedButton
    Private currentIndex As Integer = 0
    Private submissionCount As Integer = 0

    Private ReadOnly customBackgroundColor As Color = ColorTranslator.FromHtml("#C7C6C1")
    Private ReadOnly customTextColor As Color = ColorTranslator.FromHtml("#333333")

    ' Constructor to initialize controls
    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
    End Sub

    Private Sub InitializeComponent()
        Me.lblName = New System.Windows.Forms.Label()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.lblPhone = New System.Windows.Forms.Label()
        Me.lblGitHubLink = New System.Windows.Forms.Label()
        Me.lblStopwatchValue = New System.Windows.Forms.Label()
        Me.txtName = New TextBox()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.txtPhone = New System.Windows.Forms.TextBox()
        Me.txtGitHubLink = New System.Windows.Forms.TextBox()
        Me.txtStopwatchValue = New System.Windows.Forms.TextBox()
        Me.btnPrevious = New RoundedButton()
        Me.btnNext = New SubmitRoundedButton()
        Me.SuspendLayout()


        ' lblName
        Me.lblName.AutoSize = True
        Me.lblName.Location = New System.Drawing.Point(12, 20)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(45, 15)
        Me.lblName.TabIndex = 0
        Me.lblName.Text = "Name:"
        Me.lblName.Font = New Font(Me.lblName.Font.FontFamily, 12, FontStyle.Regular)
        Me.lblName.Margin = New Padding(0, 20, 0, 0)
        Me.lblName.Padding = New Padding(10)


        ' lblEmail
        Me.lblEmail.AutoSize = True
        Me.lblEmail.Location = New System.Drawing.Point(12, 60)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(42, 15)
        Me.lblEmail.TabIndex = 1
        Me.lblEmail.Text = "Email:"
        Me.lblEmail.Font = New Font(Me.lblEmail.Font.FontFamily, 12, FontStyle.Regular)
        Me.lblEmail.Margin = New Padding(0, 20, 0, 0)
        Me.lblEmail.Padding = New Padding(10)

        ' lblPhone
        Me.lblPhone.AutoSize = True
        Me.lblPhone.Location = New System.Drawing.Point(12, 105)
        Me.lblPhone.Name = "lblPhone"
        Me.lblPhone.Size = New System.Drawing.Size(46, 15)
        Me.lblPhone.TabIndex = 2
        Me.lblPhone.Text = "Phone:"
        Me.lblPhone.Font = New Font(Me.lblPhone.Font.FontFamily, 12, FontStyle.Regular)
        Me.lblPhone.Margin = New Padding(0, 20, 0, 0) ' Add margin for top spacing
        Me.lblPhone.Padding = New Padding(10)

        ' lblGitHubLink
        Me.lblGitHubLink.AutoSize = True
        Me.lblGitHubLink.Location = New System.Drawing.Point(12, 161)
        Me.lblGitHubLink.Name = "lblGitHubLink"
        Me.lblGitHubLink.Size = New System.Drawing.Size(70, 15)
        Me.lblGitHubLink.TabIndex = 3
        Me.lblGitHubLink.Text = "GitHub Link:"
        Me.lblGitHubLink.Font = New Font(Me.lblGitHubLink.Font.FontFamily, 12, FontStyle.Regular)
        Me.lblGitHubLink.Margin = New Padding(0, 20, 0, 0)
        Me.lblGitHubLink.Padding = New Padding(10)

        ' lblStopwatchValue
        Me.lblStopwatchValue.AutoSize = True
        Me.lblStopwatchValue.Location = New System.Drawing.Point(12, 210)
        Me.lblStopwatchValue.Name = "lblStopwatchValue"
        Me.lblStopwatchValue.Size = New System.Drawing.Size(90, 15)
        Me.lblStopwatchValue.TabIndex = 10
        Me.lblStopwatchValue.Text = "Stopwatch Value:"
        Me.lblStopwatchValue.Font = New Font(Me.lblStopwatchValue.Font.FontFamily, 12, FontStyle.Regular)
        Me.lblStopwatchValue.Margin = New Padding(0, 20, 0, 0)
        Me.lblStopwatchValue.Padding = New Padding(10)


        ' txtName
        Me.txtName.Location = New System.Drawing.Point(250, 15)
        Me.txtName.Name = "txtName"
        Me.txtName.TabStop = False
        Me.txtName.ReadOnly = True
        Me.txtName.Size = New System.Drawing.Size(400, 40) ' Increase width to 400 and height to 40
        Me.txtName.BackColor = customBackgroundColor
        Me.txtName.ForeColor = Color.Black
        Me.txtName.Font = New Font(Me.txtName.Font.FontFamily, 14, FontStyle.Regular) ' Increase font size to 14
        Me.txtName.Margin = New Padding(0, 20, 0, 0) ' Add margin for top spacing
        Me.txtName.Padding = New Padding(10) ' Add padding inside the textbox
        Me.txtName.BorderStyle = BorderStyle.None
        Me.txtEmail.BorderStyle = BorderStyle.None
        Me.txtPhone.BorderStyle = BorderStyle.None
        Me.txtGitHubLink.BorderStyle = BorderStyle.None
        Me.txtStopwatchValue.BorderStyle = BorderStyle.None


        ' txtEmail
        Me.txtEmail.Location = New System.Drawing.Point(250, 65) ' Increase vertical position
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.TabStop = False
        Me.txtEmail.Size = New System.Drawing.Size(400, 40) ' Increase width to 400 and height to 40
        Me.txtEmail.BackColor = customBackgroundColor
        Me.txtEmail.ForeColor = Color.Black
        Me.txtEmail.Font = New Font(Me.txtEmail.Font.FontFamily, 14, FontStyle.Regular) ' Increase font size to 14
        Me.txtEmail.Margin = New Padding(0, 20, 0, 0) ' Add margin for top spacing
        Me.txtEmail.Padding = New Padding(10) ' Add padding inside the textbox

        ' txtPhone
        Me.txtPhone.Location = New System.Drawing.Point(250, 115) ' Increase vertical position
        Me.txtPhone.Name = "txtPhone"
        Me.txtPhone.Size = New System.Drawing.Size(400, 40) ' Increase width to 400 and height to 40
        Me.txtPhone.TabStop = False
        Me.txtPhone.BackColor = customBackgroundColor
        Me.txtPhone.ForeColor = Color.Black
        Me.txtPhone.Font = New Font(Me.txtPhone.Font.FontFamily, 14, FontStyle.Regular) ' Increase font size to 14
        Me.txtPhone.Margin = New Padding(0, 20, 0, 0) ' Add margin for top spacing
        Me.txtPhone.Padding = New Padding(10) ' Add padding inside the textbox


        ' txtGitHubLink
        Me.txtGitHubLink.Location = New System.Drawing.Point(250, 165) ' Increase vertical position
        Me.txtGitHubLink.Name = "txtGitHubLink"
        Me.txtGitHubLink.TabStop = False
        Me.txtGitHubLink.ReadOnly = True
        Me.txtGitHubLink.Size = New System.Drawing.Size(400, 40) ' Increase width to 400 and height to 40
        Me.txtGitHubLink.BackColor = customBackgroundColor
        Me.txtGitHubLink.ForeColor = Color.Black
        Me.txtGitHubLink.Font = New Font(Me.txtGitHubLink.Font.FontFamily, 14, FontStyle.Regular) ' Increase font size to 14
        Me.txtGitHubLink.Margin = New Padding(0, 20, 0, 0) ' Add margin for top spacing
        Me.txtGitHubLink.Padding = New Padding(10) ' Add padding inside the textbox

        ' txtStopwatchValue
        Me.txtStopwatchValue.Location = New System.Drawing.Point(250, 215) ' Increase vertical position
        Me.txtStopwatchValue.Name = "txtStopwatchValue"
        Me.txtStopwatchValue.TabStop = False
        Me.txtStopwatchValue.ReadOnly = True
        Me.txtStopwatchValue.Size = New System.Drawing.Size(400, 40) ' Increase width to 400 and height to 40
        Me.txtStopwatchValue.BackColor = customBackgroundColor
        Me.txtStopwatchValue.ForeColor = Color.Black
        Me.txtStopwatchValue.Font = New Font(Me.txtStopwatchValue.Font.FontFamily, 14, FontStyle.Regular) ' Increase font size to 14
        Me.txtStopwatchValue.Margin = New Padding(0, 20, 0, 0) ' Add margin for top spacing
        Me.txtStopwatchValue.Padding = New Padding(10) ' Add padding inside the textbox



        ' btnPrevious
        Me.btnPrevious.Location = New System.Drawing.Point(15, 290)
        Me.btnPrevious.Name = "btnPrevious"
        Me.btnPrevious.Size = New System.Drawing.Size(180, 45)
        Me.btnPrevious.TabIndex = 4
        Me.btnPrevious.Text = "PREVIOUS (ctrl + P)"
        Me.btnPrevious.UseVisualStyleBackColor = True
        Me.btnPrevious.Margin = New Padding(0, 20, 0, 0) ' Add margin for top spacing
        Me.btnPrevious.Padding = New Padding(10)


        ' btnNext
        Me.btnNext.Location = New System.Drawing.Point(297, 290)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(180, 45)
        Me.btnNext.TabIndex = 5
        Me.btnNext.Text = "NEXT (ctrl + N)"
        Me.btnNext.UseVisualStyleBackColor = True
        Me.btnNext.Margin = New Padding(0, 20, 0, 0) ' Add margin for top spacing
        Me.btnNext.Padding = New Padding(10)

        ' ViewSubmissionsForm
        Me.ClientSize = New System.Drawing.Size(784, 511)
        Me.Controls.Add(Me.txtStopwatchValue)
        Me.Controls.Add(Me.lblStopwatchValue)
        Me.Controls.Add(Me.txtGitHubLink)
        Me.Controls.Add(Me.txtPhone)
        Me.Controls.Add(Me.txtEmail)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.btnPrevious)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.lblGitHubLink)
        Me.Controls.Add(Me.lblPhone)
        Me.Controls.Add(Me.lblEmail)
        Me.Controls.Add(Me.lblName)
        Me.Name = "ViewSubmissionsForm"
        Me.Text = "View Submissions"
        Me.ResumeLayout(False)
        Me.PerformLayout()

        ' Load the initial submission when the form is loaded
        AddHandler Me.Load, AddressOf ViewSubmissionsForm_Load
    End Sub

    Private Async Sub ViewSubmissionsForm_Load(sender As Object, e As EventArgs)
        Await LoadSubmissionCount()
        Await LoadSubmission(currentIndex)
    End Sub

    Private Async Function LoadSubmissionCount() As Task
        Using client As New HttpClient()
            client.BaseAddress = New Uri("http://localhost:3000")

            Try
                Dim response = Await client.GetAsync("/read/count")
                If response.IsSuccessStatusCode Then
                    Dim json = Await response.Content.ReadAsStringAsync()
                    Dim result = JsonConvert.DeserializeObject(Of Dictionary(Of String, Integer))(json)
                    submissionCount = result("count")
                Else
                    Dim errorContent = Await response.Content.ReadAsStringAsync()
                    Console.WriteLine($"Error: {response.StatusCode}, Content: {errorContent}")
                    MessageBox.Show("Failed to load submission count.")
                End If
            Catch ex As Exception
                Console.WriteLine($"Exception: {ex.Message}")
                MessageBox.Show($"An error occurred while loading submission count: {ex.Message}")
            End Try
        End Using
    End Function

    Private Async Function LoadSubmission(index As Integer) As Task
        Using client As New HttpClient()
            client.BaseAddress = New Uri("http://localhost:3000")

            Try
                Dim response = Await client.GetAsync($"/read?index={index}")
                If response.IsSuccessStatusCode Then
                    Dim json = Await response.Content.ReadAsStringAsync()
                    Dim submission = JsonConvert.DeserializeObject(Of Dictionary(Of String, String))(json)
                    ' Update textboxes with submission data
                    txtName.Text = submission("name")
                    txtEmail.Text = submission("email")
                    txtPhone.Text = submission("phone")
                    txtGitHubLink.Text = submission("github_link")
                    txtStopwatchValue.Text = submission("stopwatch_value")
                Else
                    Dim errorContent = Await response.Content.ReadAsStringAsync()
                    Console.WriteLine($"Error: {response.StatusCode}, Content: {errorContent}")
                    MessageBox.Show("Failed to load submission.")
                End If
            Catch ex As Exception
                Console.WriteLine($"Exception: {ex.Message}")
                MessageBox.Show($"An error occurred while loading submission: {ex.Message}")
            End Try
        End Using
    End Function

    Private Async Sub btnPrevious_Click(sender As Object, e As EventArgs) Handles btnPrevious.Click
        If currentIndex > 0 Then
            currentIndex -= 1
            Await LoadSubmission(currentIndex)
        Else
            MessageBox.Show("This is the first submission.")
        End If
    End Sub

    Private Async Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        If currentIndex < submissionCount - 1 Then
            currentIndex += 1
            Await LoadSubmission(currentIndex)
        Else
            MessageBox.Show("This is the last submission.")
        End If
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        If keyData = (Keys.Control Or Keys.P) Then
            btnPrevious.PerformClick()
            Return True
        ElseIf keyData = (Keys.Control Or Keys.N) Then
            btnNext.PerformClick()
            Return True
        End If

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function
End Class



Public Class RoundedButton
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

        ' Draw gradient background
        Using brush As New LinearGradientBrush(rect, Color.LightYellow, Color.Yellow, LinearGradientMode.Vertical)
            g.FillPath(brush, graphicsPath)
        End Using

        ' Draw border
        Using pen As New Pen(Color.Yellow, 1)
            g.DrawPath(pen, graphicsPath)
        End Using

        ' Draw text
        TextRenderer.DrawText(g, Me.Text, Me.Font, rect, Me.ForeColor, TextFormatFlags.HorizontalCenter Or TextFormatFlags.VerticalCenter)
    End Sub
End Class

Public Class SubmitRoundedButton
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

        ' Draw gradient background
        Using brush As New LinearGradientBrush(rect, Color.LightBlue, Color.BlueViolet, LinearGradientMode.Vertical)
            g.FillPath(brush, graphicsPath)
        End Using



        ' Draw text
        TextRenderer.DrawText(g, Me.Text, Me.Font, rect, Me.ForeColor, TextFormatFlags.HorizontalCenter Or TextFormatFlags.VerticalCenter)
    End Sub
End Class