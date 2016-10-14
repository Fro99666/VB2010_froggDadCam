<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VersionLog
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
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

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VersionLog))
        Me.VersionLogText = New System.Windows.Forms.RichTextBox()
        Me.SuspendLayout()
        '
        'VersionLogText
        '
        Me.VersionLogText.BackColor = System.Drawing.SystemColors.Control
        Me.VersionLogText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.VersionLogText.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VersionLogText.Location = New System.Drawing.Point(12, 12)
        Me.VersionLogText.Name = "VersionLogText"
        Me.VersionLogText.Size = New System.Drawing.Size(400, 224)
        Me.VersionLogText.TabIndex = 0
        Me.VersionLogText.Text = ""
        '
        'VersionLog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(424, 248)
        Me.Controls.Add(Me.VersionLogText)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "VersionLog"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Version log"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents VersionLogText As System.Windows.Forms.RichTextBox
End Class
