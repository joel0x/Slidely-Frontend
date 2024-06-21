Imports Newtonsoft.Json
Imports System.Drawing.Drawing2D

Namespace Slidely_AI_project

    Public Class MainForm
        Inherits Form

        Private WithEvents btnViewSubmissions As Button
        Private WithEvents btnCreateSubmission As Button
        Private lblHeading As Label

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub InitializeComponent()
            Me.btnViewSubmissions = New System.Windows.Forms.Button()
            Me.btnCreateSubmission = New System.Windows.Forms.Button()
            Me.lblHeading = New System.Windows.Forms.Label()
            Me.SuspendLayout()

            Me.lblHeading.AutoSize = True
            Me.lblHeading.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblHeading.Location = New System.Drawing.Point(30, 10)
            Me.lblHeading.Name = "lblHeading"
            Me.lblHeading.Size = New System.Drawing.Size(343, 22)
            Me.lblHeading.TabIndex = 2
            Me.lblHeading.Text = "Joel Machado, slidely task 2 - slidely form app"


            Me.btnViewSubmissions.Location = New System.Drawing.Point(50, 60)
            Me.btnViewSubmissions.Name = "btnViewSubmissions"
            Me.btnViewSubmissions.Size = New System.Drawing.Size(280, 75)
            Me.btnViewSubmissions.TabIndex = 0
            Me.btnViewSubmissions.Text = "View Submissions (ctrl + V)"
            Me.btnViewSubmissions.UseVisualStyleBackColor = False
            Me.btnViewSubmissions.BackColor = Color.Yellow


            Me.btnCreateSubmission.Location = New System.Drawing.Point(50, 250)
            Me.btnCreateSubmission.Name = "btnCreateSubmission"
            Me.btnCreateSubmission.Size = New System.Drawing.Size(280, 75)
            Me.btnCreateSubmission.TabIndex = 1
            Me.btnCreateSubmission.Text = "Create New Submission (ctrl + N)"
            Me.btnCreateSubmission.UseVisualStyleBackColor = False
            Me.btnCreateSubmission.BackColor = Color.Blue


            Me.ClientSize = New System.Drawing.Size(650, 700)
            Me.Controls.Add(Me.lblHeading)
            Me.Controls.Add(Me.btnCreateSubmission)
            Me.Controls.Add(Me.btnViewSubmissions)
            Me.Name = "MainForm"
            Me.Text = "Main Form"
            Me.ResumeLayout(False)
            Me.PerformLayout()
        End Sub

        Protected Overrides Sub OnPaint(e As PaintEventArgs)
            MyBase.OnPaint(e)

        End Sub

        Private Sub btnViewSubmissions_Click(sender As Object, e As EventArgs) Handles btnViewSubmissions.Click
            Dim viewForm As New ViewSubmissionsForm()
            viewForm.Show()
        End Sub

        Private Sub btnCreateSubmission_Click(sender As Object, e As EventArgs) Handles btnCreateSubmission.Click
            Dim createForm As New CreateSubmissionForm()
            createForm.Show()
        End Sub

        Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
            If keyData = (Keys.Control Or Keys.N) Then
                btnCreateSubmission.PerformClick()
                Return True
            ElseIf keyData = (Keys.Control Or Keys.V) Then
                btnViewSubmissions.PerformClick()
                Return True
            End If
            Return MyBase.ProcessCmdKey(msg, keyData)
        End Function
    End Class
End Namespace
