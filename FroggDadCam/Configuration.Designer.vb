<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Configuration
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Configuration))
        Me.ConfUrl = New System.Windows.Forms.TextBox()
        Me.ConfLog = New System.Windows.Forms.TextBox()
        Me.ConfPath = New System.Windows.Forms.TextBox()
        Me.ConfUrlTxt = New System.Windows.Forms.Label()
        Me.ConfLogTxt = New System.Windows.Forms.Label()
        Me.ConfPassTxt = New System.Windows.Forms.Label()
        Me.ConfPathTxt = New System.Windows.Forms.Label()
        Me.ConfSave = New System.Windows.Forms.Button()
        Me.ConfPass = New System.Windows.Forms.MaskedTextBox()
        Me.ConfPassVerif = New System.Windows.Forms.MaskedTextBox()
        Me.ConfPassVerifTxt = New System.Windows.Forms.Label()
        Me.PanelTest = New System.Windows.Forms.Panel()
        Me.PanelTestTxt = New System.Windows.Forms.Label()
        Me.ConfLangTxt = New System.Windows.Forms.Label()
        Me.ConfLang = New System.Windows.Forms.ComboBox()
        Me.ConfModel = New System.Windows.Forms.ComboBox()
        Me.ConfModelTxt = New System.Windows.Forms.Label()
        Me.ConfIDTxt = New System.Windows.Forms.Label()
        Me.ConfDel = New System.Windows.Forms.Button()
        Me.ConfNew = New System.Windows.Forms.Button()
        Me.ConfId = New System.Windows.Forms.ComboBox()
        Me.PanelTest.SuspendLayout()
        Me.SuspendLayout()
        '
        'ConfUrl
        '
        Me.ConfUrl.Location = New System.Drawing.Point(163, 59)
        Me.ConfUrl.Name = "ConfUrl"
        Me.ConfUrl.Size = New System.Drawing.Size(207, 20)
        Me.ConfUrl.TabIndex = 1
        Me.ConfUrl.Text = "http://"
        '
        'ConfLog
        '
        Me.ConfLog.Location = New System.Drawing.Point(163, 86)
        Me.ConfLog.Name = "ConfLog"
        Me.ConfLog.Size = New System.Drawing.Size(207, 20)
        Me.ConfLog.TabIndex = 2
        '
        'ConfPath
        '
        Me.ConfPath.Location = New System.Drawing.Point(163, 164)
        Me.ConfPath.Name = "ConfPath"
        Me.ConfPath.Size = New System.Drawing.Size(207, 20)
        Me.ConfPath.TabIndex = 5
        '
        'ConfUrlTxt
        '
        Me.ConfUrlTxt.AutoSize = True
        Me.ConfUrlTxt.Location = New System.Drawing.Point(5, 62)
        Me.ConfUrlTxt.Name = "ConfUrlTxt"
        Me.ConfUrlTxt.Size = New System.Drawing.Size(109, 13)
        Me.ConfUrlTxt.TabIndex = 4
        Me.ConfUrlTxt.Text = "Adresse de la caméra"
        '
        'ConfLogTxt
        '
        Me.ConfLogTxt.AutoSize = True
        Me.ConfLogTxt.Location = New System.Drawing.Point(5, 89)
        Me.ConfLogTxt.Name = "ConfLogTxt"
        Me.ConfLogTxt.Size = New System.Drawing.Size(53, 13)
        Me.ConfLogTxt.TabIndex = 5
        Me.ConfLogTxt.Text = "Identifiant"
        '
        'ConfPassTxt
        '
        Me.ConfPassTxt.AutoSize = True
        Me.ConfPassTxt.Location = New System.Drawing.Point(5, 115)
        Me.ConfPassTxt.Name = "ConfPassTxt"
        Me.ConfPassTxt.Size = New System.Drawing.Size(71, 13)
        Me.ConfPassTxt.TabIndex = 6
        Me.ConfPassTxt.Text = "Mot de passe"
        '
        'ConfPathTxt
        '
        Me.ConfPathTxt.AutoSize = True
        Me.ConfPathTxt.Location = New System.Drawing.Point(5, 167)
        Me.ConfPathTxt.Name = "ConfPathTxt"
        Me.ConfPathTxt.Size = New System.Drawing.Size(147, 13)
        Me.ConfPathTxt.TabIndex = 7
        Me.ConfPathTxt.Text = "Répertoire de téléchargement"
        '
        'ConfSave
        '
        Me.ConfSave.BackColor = System.Drawing.Color.Green
        Me.ConfSave.ForeColor = System.Drawing.Color.White
        Me.ConfSave.Location = New System.Drawing.Point(163, 217)
        Me.ConfSave.Name = "ConfSave"
        Me.ConfSave.Size = New System.Drawing.Size(207, 23)
        Me.ConfSave.TabIndex = 7
        Me.ConfSave.Text = "Sauvegarder"
        Me.ConfSave.UseVisualStyleBackColor = False
        '
        'ConfPass
        '
        Me.ConfPass.Location = New System.Drawing.Point(163, 112)
        Me.ConfPass.Name = "ConfPass"
        Me.ConfPass.Size = New System.Drawing.Size(207, 20)
        Me.ConfPass.TabIndex = 3
        '
        'ConfPassVerif
        '
        Me.ConfPassVerif.Location = New System.Drawing.Point(163, 138)
        Me.ConfPassVerif.Name = "ConfPassVerif"
        Me.ConfPassVerif.Size = New System.Drawing.Size(207, 20)
        Me.ConfPassVerif.TabIndex = 4
        '
        'ConfPassVerifTxt
        '
        Me.ConfPassVerifTxt.AutoSize = True
        Me.ConfPassVerifTxt.Location = New System.Drawing.Point(5, 141)
        Me.ConfPassVerifTxt.Name = "ConfPassVerifTxt"
        Me.ConfPassVerifTxt.Size = New System.Drawing.Size(128, 13)
        Me.ConfPassVerifTxt.TabIndex = 11
        Me.ConfPassVerifTxt.Text = "Confirmer le mot de passe"
        '
        'PanelTest
        '
        Me.PanelTest.Controls.Add(Me.PanelTestTxt)
        Me.PanelTest.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelTest.Location = New System.Drawing.Point(0, 0)
        Me.PanelTest.Name = "PanelTest"
        Me.PanelTest.Size = New System.Drawing.Size(377, 271)
        Me.PanelTest.TabIndex = 12
        Me.PanelTest.Visible = False
        '
        'PanelTestTxt
        '
        Me.PanelTestTxt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelTestTxt.Location = New System.Drawing.Point(0, 0)
        Me.PanelTestTxt.Name = "PanelTestTxt"
        Me.PanelTestTxt.Size = New System.Drawing.Size(377, 271)
        Me.PanelTestTxt.TabIndex = 0
        Me.PanelTestTxt.Text = "Test de la connexion en cours, merci de patienter..."
        Me.PanelTestTxt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ConfLangTxt
        '
        Me.ConfLangTxt.AutoSize = True
        Me.ConfLangTxt.Location = New System.Drawing.Point(6, 190)
        Me.ConfLangTxt.Name = "ConfLangTxt"
        Me.ConfLangTxt.Size = New System.Drawing.Size(49, 13)
        Me.ConfLangTxt.TabIndex = 14
        Me.ConfLangTxt.Text = "Langage"
        '
        'ConfLang
        '
        Me.ConfLang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ConfLang.FormattingEnabled = True
        Me.ConfLang.Location = New System.Drawing.Point(163, 190)
        Me.ConfLang.Name = "ConfLang"
        Me.ConfLang.Size = New System.Drawing.Size(207, 21)
        Me.ConfLang.TabIndex = 15
        '
        'ConfModel
        '
        Me.ConfModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ConfModel.FormattingEnabled = True
        Me.ConfModel.Location = New System.Drawing.Point(163, 32)
        Me.ConfModel.Name = "ConfModel"
        Me.ConfModel.Size = New System.Drawing.Size(207, 21)
        Me.ConfModel.TabIndex = 17
        '
        'ConfModelTxt
        '
        Me.ConfModelTxt.AutoSize = True
        Me.ConfModelTxt.Location = New System.Drawing.Point(6, 35)
        Me.ConfModelTxt.Name = "ConfModelTxt"
        Me.ConfModelTxt.Size = New System.Drawing.Size(89, 13)
        Me.ConfModelTxt.TabIndex = 18
        Me.ConfModelTxt.Text = "Model de caméra"
        '
        'ConfIDTxt
        '
        Me.ConfIDTxt.AutoSize = True
        Me.ConfIDTxt.Location = New System.Drawing.Point(6, 9)
        Me.ConfIDTxt.Name = "ConfIDTxt"
        Me.ConfIDTxt.Size = New System.Drawing.Size(53, 13)
        Me.ConfIDTxt.TabIndex = 19
        Me.ConfIDTxt.Text = "Identifiant"
        '
        'ConfDel
        '
        Me.ConfDel.BackColor = System.Drawing.Color.Red
        Me.ConfDel.ForeColor = System.Drawing.Color.White
        Me.ConfDel.Location = New System.Drawing.Point(8, 217)
        Me.ConfDel.Name = "ConfDel"
        Me.ConfDel.Size = New System.Drawing.Size(149, 23)
        Me.ConfDel.TabIndex = 20
        Me.ConfDel.Text = "supprimer"
        Me.ConfDel.UseVisualStyleBackColor = False
        Me.ConfDel.Visible = False
        '
        'ConfNew
        '
        Me.ConfNew.BackColor = System.Drawing.Color.CadetBlue
        Me.ConfNew.ForeColor = System.Drawing.Color.White
        Me.ConfNew.Location = New System.Drawing.Point(8, 244)
        Me.ConfNew.Name = "ConfNew"
        Me.ConfNew.Size = New System.Drawing.Size(362, 23)
        Me.ConfNew.TabIndex = 21
        Me.ConfNew.Text = "Ajouter une nouvelle caméra"
        Me.ConfNew.UseVisualStyleBackColor = False
        '
        'ConfId
        '
        Me.ConfId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ConfId.FormattingEnabled = True
        Me.ConfId.Location = New System.Drawing.Point(163, 5)
        Me.ConfId.Name = "ConfId"
        Me.ConfId.Size = New System.Drawing.Size(207, 21)
        Me.ConfId.TabIndex = 22
        '
        'Configuration
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(377, 271)
        Me.Controls.Add(Me.PanelTest)
        Me.Controls.Add(Me.ConfLang)
        Me.Controls.Add(Me.ConfLangTxt)
        Me.Controls.Add(Me.ConfPassVerifTxt)
        Me.Controls.Add(Me.ConfPassVerif)
        Me.Controls.Add(Me.ConfPass)
        Me.Controls.Add(Me.ConfSave)
        Me.Controls.Add(Me.ConfPathTxt)
        Me.Controls.Add(Me.ConfPassTxt)
        Me.Controls.Add(Me.ConfLogTxt)
        Me.Controls.Add(Me.ConfUrlTxt)
        Me.Controls.Add(Me.ConfPath)
        Me.Controls.Add(Me.ConfLog)
        Me.Controls.Add(Me.ConfUrl)
        Me.Controls.Add(Me.ConfDel)
        Me.Controls.Add(Me.ConfModelTxt)
        Me.Controls.Add(Me.ConfIDTxt)
        Me.Controls.Add(Me.ConfModel)
        Me.Controls.Add(Me.ConfNew)
        Me.Controls.Add(Me.ConfId)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Configuration"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " Configuration"
        Me.PanelTest.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ConfUrl As System.Windows.Forms.TextBox
    Friend WithEvents ConfLog As System.Windows.Forms.TextBox
    Friend WithEvents ConfPath As System.Windows.Forms.TextBox
    Friend WithEvents ConfUrlTxt As System.Windows.Forms.Label
    Friend WithEvents ConfLogTxt As System.Windows.Forms.Label
    Friend WithEvents ConfPassTxt As System.Windows.Forms.Label
    Friend WithEvents ConfPathTxt As System.Windows.Forms.Label
    Friend WithEvents ConfSave As System.Windows.Forms.Button
    Friend WithEvents ConfPass As System.Windows.Forms.MaskedTextBox
    Friend WithEvents ConfPassVerif As System.Windows.Forms.MaskedTextBox
    Friend WithEvents ConfPassVerifTxt As System.Windows.Forms.Label
    Friend WithEvents PanelTest As System.Windows.Forms.Panel
    Friend WithEvents PanelTestTxt As System.Windows.Forms.Label
    Friend WithEvents ConfLangTxt As System.Windows.Forms.Label
    Friend WithEvents ConfLang As System.Windows.Forms.ComboBox
    Friend WithEvents ConfModel As System.Windows.Forms.ComboBox
    Friend WithEvents ConfModelTxt As System.Windows.Forms.Label
    Friend WithEvents ConfIDTxt As System.Windows.Forms.Label
    Friend WithEvents ConfDel As System.Windows.Forms.Button
    Friend WithEvents ConfNew As System.Windows.Forms.Button
    Friend WithEvents ConfId As System.Windows.Forms.ComboBox
End Class
