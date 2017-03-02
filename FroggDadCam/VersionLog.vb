Public Class VersionLog

    'exit script
    Private Sub VersionLog_Closing(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.Closing
        'check if multicam is opened
        If DadCam.getUpdateFlag() = 1 Then
            DadCam.startTempUpdated()
        End If

    End Sub

End Class