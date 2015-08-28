Public Class CustomPogress
    Inherits ProgressBar

    Public Property ShowPercents As Boolean
    Public Property LabelFormat As String
    Private Const WmPaint = 15
    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        MyBase.WndProc(m)
        If m.Msg = WmPaint Then
            UpdateText()

        End If
    End Sub

    Private Sub UpdateText()
        Dim s As String

        If (ShowPercents) Then
            Dim percent = CInt((Value - Minimum) * 100 / (Maximum - Minimum))
            If String.IsNullOrEmpty(LabelFormat) Then
                s = percent.ToString & "%"
            Else
                s = String.Format(LabelFormat, percent)
            End If
        Else
            If (String.IsNullOrEmpty(LabelFormat)) Then
                Return
            Else
                s = LabelFormat
            End If
        End If
        Using gr = Me.CreateGraphics()
            Dim textSize = gr.MeasureString(s, Font)
            Using br = New SolidBrush(ForeColor)
                gr.DrawString(s, Font, Brushes.Black, Width / 2 - textSize.Width / 2, Height / 2 - textSize.Height / 2)
            End Using
        End Using
    End Sub
End Class