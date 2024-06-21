Namespace My
    Partial Friend Class MyApplication

        <Global.System.Diagnostics.DebuggerStepThroughAttribute()>
        Protected Overrides Sub OnCreateMainForm()
            ' Create an instance of MainForm
            Dim mainFormInstance As New Slidely_AI_project.MainForm()

            ' Assign the instance to MainForm
            Me.MainForm = mainFormInstance
        End Sub

    End Class
End Namespace
