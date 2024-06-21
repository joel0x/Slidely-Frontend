Public Class Form1
    ' Declare buttons with WithEvents at the class level
    Private WithEvents btnViewSubmissions As Button
    Private WithEvents btnCreateSubmission As Button

    ' Constructor to initialize controls
    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
    End Sub

    Private Sub InitializeComponent()
        ' Initialization code for Form1 can be here, if needed
    End Sub

    Private Sub btnViewSubmissions_Click(sender As Object, e As EventArgs) Handles btnViewSubmissions.Click
        ' Handle btnViewSubmissions click event
    End Sub

    Private Sub btnCreateSubmission_Click(sender As Object, e As EventArgs) Handles btnCreateSubmission.Click
        ' Handle btnCreateSubmission click event
    End Sub
End Class
