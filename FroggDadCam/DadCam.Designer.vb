<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DadCam
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DadCam))
        Me.WebCam1 = New System.Windows.Forms.WebBrowser()
        Me.MenuBar = New System.Windows.Forms.MenuStrip()
        Me.MenuView = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuViewMini = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuViewAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuDL = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuMemInfo = New System.Windows.Forms.ToolStripTextBox()
        Me.MenuOption = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuCamRestart = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuMem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuOfficial = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuConfig = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuAdvancedConfig = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuInfoVersion = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuFrogg = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuCV = New System.Windows.Forms.ToolStripMenuItem()
        Me.YoutubeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WikiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuBaniere = New System.Windows.Forms.ToolStripMenuItem()
        Me.WebHidden = New System.Windows.Forms.WebBrowser()
        Me.CamStatus = New System.Windows.Forms.StatusStrip()
        Me.DllToolBar = New System.Windows.Forms.ToolStripProgressBar()
        Me.StatusCamTxt = New System.Windows.Forms.ToolStripStatusLabel()
        Me.refreshMem = New System.Windows.Forms.Timer(Me.components)
        Me.PanelVid = New System.Windows.Forms.Panel()
        Me.BtnVidRefresh = New System.Windows.Forms.Button()
        Me.btnVidCancel = New System.Windows.Forms.Button()
        Me.DLProgress = New System.Windows.Forms.ProgressBar()
        Me.ListVid = New System.Windows.Forms.ListView()
        Me.filename = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.filedate = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.filesize = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.PanelVidTitle = New System.Windows.Forms.Label()
        Me.BtnVidClose = New System.Windows.Forms.Button()
        Me.BtnVidDL = New System.Windows.Forms.Button()
        Me.ListVidDate = New System.Windows.Forms.ListBox()
        Me.PanelMaskRestart = New System.Windows.Forms.Panel()
        Me.PanelMaskRestartTxt = New System.Windows.Forms.Label()
        Me.PanelCamControl = New System.Windows.Forms.Panel()
        Me.btnright = New System.Windows.Forms.Button()
        Me.btndown = New System.Windows.Forms.Button()
        Me.btnleft = New System.Windows.Forms.Button()
        Me.btnUp = New System.Windows.Forms.Button()
        Me.MenuBar.SuspendLayout()
        Me.CamStatus.SuspendLayout()
        Me.PanelVid.SuspendLayout()
        Me.PanelMaskRestart.SuspendLayout()
        Me.PanelCamControl.SuspendLayout()
        Me.SuspendLayout()
        '
        'WebCam1
        '
        Me.WebCam1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WebCam1.Location = New System.Drawing.Point(0, 0)
        Me.WebCam1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebCam1.Name = "WebCam1"
        Me.WebCam1.ScrollBarsEnabled = False
        Me.WebCam1.Size = New System.Drawing.Size(1009, 657)
        Me.WebCam1.TabIndex = 0
        '
        'MenuBar
        '
        Me.MenuBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuView, Me.MenuViewMini, Me.MenuViewAll, Me.MenuDL, Me.MenuMemInfo, Me.MenuOption, Me.MenuFrogg})
        Me.MenuBar.Location = New System.Drawing.Point(0, 0)
        Me.MenuBar.Name = "MenuBar"
        Me.MenuBar.Size = New System.Drawing.Size(1009, 27)
        Me.MenuBar.TabIndex = 2
        Me.MenuBar.Text = "MenuStrip1"
        '
        'MenuView
        '
        Me.MenuView.Name = "MenuView"
        Me.MenuView.Size = New System.Drawing.Size(143, 23)
        Me.MenuView.Text = "Voir la caméra en direct"
        '
        'MenuViewMini
        '
        Me.MenuViewMini.Name = "MenuViewMini"
        Me.MenuViewMini.Size = New System.Drawing.Size(178, 23)
        Me.MenuViewMini.Text = "Voir la caméra en taille reduite"
        '
        'MenuViewAll
        '
        Me.MenuViewAll.Name = "MenuViewAll"
        Me.MenuViewAll.Size = New System.Drawing.Size(140, 23)
        Me.MenuViewAll.Text = "Voir toutes les caméras"
        '
        'MenuDL
        '
        Me.MenuDL.Name = "MenuDL"
        Me.MenuDL.Size = New System.Drawing.Size(135, 23)
        Me.MenuDL.Text = "Télécharger les vidéos"
        '
        'MenuMemInfo
        '
        Me.MenuMemInfo.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.MenuMemInfo.BackColor = System.Drawing.SystemColors.Control
        Me.MenuMemInfo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuMemInfo.ForeColor = System.Drawing.SystemColors.Window
        Me.MenuMemInfo.Name = "MenuMemInfo"
        Me.MenuMemInfo.ReadOnly = True
        Me.MenuMemInfo.Size = New System.Drawing.Size(160, 23)
        Me.MenuMemInfo.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'MenuOption
        '
        Me.MenuOption.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuCamRestart, Me.MenuMem, Me.MenuOfficial, Me.MenuConfig, Me.MenuAdvancedConfig, Me.MenuInfoVersion})
        Me.MenuOption.Name = "MenuOption"
        Me.MenuOption.Size = New System.Drawing.Size(61, 23)
        Me.MenuOption.Text = "Options"
        '
        'MenuCamRestart
        '
        Me.MenuCamRestart.Name = "MenuCamRestart"
        Me.MenuCamRestart.Size = New System.Drawing.Size(206, 22)
        Me.MenuCamRestart.Text = "Redémarrer la caméra"
        '
        'MenuMem
        '
        Me.MenuMem.Name = "MenuMem"
        Me.MenuMem.Size = New System.Drawing.Size(206, 22)
        Me.MenuMem.Text = "Effacer la carte mémoire"
        '
        'MenuOfficial
        '
        Me.MenuOfficial.Name = "MenuOfficial"
        Me.MenuOfficial.Size = New System.Drawing.Size(206, 22)
        Me.MenuOfficial.Text = "Site Officiel de la caméra"
        '
        'MenuConfig
        '
        Me.MenuConfig.Name = "MenuConfig"
        Me.MenuConfig.Size = New System.Drawing.Size(206, 22)
        Me.MenuConfig.Text = "Configuration"
        '
        'MenuAdvancedConfig
        '
        Me.MenuAdvancedConfig.Name = "MenuAdvancedConfig"
        Me.MenuAdvancedConfig.Size = New System.Drawing.Size(206, 22)
        Me.MenuAdvancedConfig.Text = "Configuration avancée"
        '
        'MenuInfoVersion
        '
        Me.MenuInfoVersion.Name = "MenuInfoVersion"
        Me.MenuInfoVersion.Size = New System.Drawing.Size(206, 22)
        Me.MenuInfoVersion.Text = "Information de la version"
        '
        'MenuFrogg
        '
        Me.MenuFrogg.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuCV, Me.YoutubeToolStripMenuItem, Me.WikiToolStripMenuItem, Me.MenuBaniere})
        Me.MenuFrogg.Name = "MenuFrogg"
        Me.MenuFrogg.Size = New System.Drawing.Size(115, 23)
        Me.MenuFrogg.Text = "Powered By Frogg"
        '
        'MenuCV
        '
        Me.MenuCV.Name = "MenuCV"
        Me.MenuCV.Size = New System.Drawing.Size(163, 22)
        Me.MenuCV.Text = "Curriculum Vitae"
        '
        'YoutubeToolStripMenuItem
        '
        Me.YoutubeToolStripMenuItem.Name = "YoutubeToolStripMenuItem"
        Me.YoutubeToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
        Me.YoutubeToolStripMenuItem.Text = "Youtube"
        '
        'WikiToolStripMenuItem
        '
        Me.WikiToolStripMenuItem.Name = "WikiToolStripMenuItem"
        Me.WikiToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
        Me.WikiToolStripMenuItem.Text = "Wiki"
        '
        'MenuBaniere
        '
        Me.MenuBaniere.Name = "MenuBaniere"
        Me.MenuBaniere.Size = New System.Drawing.Size(163, 22)
        Me.MenuBaniere.Text = "Banière"
        '
        'WebHidden
        '
        Me.WebHidden.Location = New System.Drawing.Point(0, 476)
        Me.WebHidden.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebHidden.Name = "WebHidden"
        Me.WebHidden.Size = New System.Drawing.Size(232, 156)
        Me.WebHidden.TabIndex = 3
        Me.WebHidden.Visible = False
        '
        'CamStatus
        '
        Me.CamStatus.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DllToolBar, Me.StatusCamTxt})
        Me.CamStatus.Location = New System.Drawing.Point(0, 635)
        Me.CamStatus.Name = "CamStatus"
        Me.CamStatus.Size = New System.Drawing.Size(1009, 22)
        Me.CamStatus.SizingGrip = False
        Me.CamStatus.TabIndex = 4
        Me.CamStatus.Text = "StatusStrip1"
        '
        'DllToolBar
        '
        Me.DllToolBar.Name = "DllToolBar"
        Me.DllToolBar.Size = New System.Drawing.Size(100, 16)
        Me.DllToolBar.Visible = False
        '
        'StatusCamTxt
        '
        Me.StatusCamTxt.Name = "StatusCamTxt"
        Me.StatusCamTxt.Size = New System.Drawing.Size(0, 17)
        '
        'refreshMem
        '
        Me.refreshMem.Enabled = True
        Me.refreshMem.Interval = 20000
        '
        'PanelVid
        '
        Me.PanelVid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelVid.Controls.Add(Me.BtnVidRefresh)
        Me.PanelVid.Controls.Add(Me.btnVidCancel)
        Me.PanelVid.Controls.Add(Me.DLProgress)
        Me.PanelVid.Controls.Add(Me.ListVid)
        Me.PanelVid.Controls.Add(Me.PanelVidTitle)
        Me.PanelVid.Controls.Add(Me.BtnVidClose)
        Me.PanelVid.Controls.Add(Me.BtnVidDL)
        Me.PanelVid.Controls.Add(Me.ListVidDate)
        Me.PanelVid.Location = New System.Drawing.Point(230, 90)
        Me.PanelVid.Name = "PanelVid"
        Me.PanelVid.Size = New System.Drawing.Size(540, 395)
        Me.PanelVid.TabIndex = 5
        Me.PanelVid.Visible = False
        '
        'BtnVidRefresh
        '
        Me.BtnVidRefresh.BackColor = System.Drawing.Color.RoyalBlue
        Me.BtnVidRefresh.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.BtnVidRefresh.ForeColor = System.Drawing.Color.White
        Me.BtnVidRefresh.Image = Global.DadCam.My.Resources.Resources.refresh
        Me.BtnVidRefresh.Location = New System.Drawing.Point(4, 3)
        Me.BtnVidRefresh.Margin = New System.Windows.Forms.Padding(0)
        Me.BtnVidRefresh.Name = "BtnVidRefresh"
        Me.BtnVidRefresh.Size = New System.Drawing.Size(20, 20)
        Me.BtnVidRefresh.TabIndex = 8
        Me.BtnVidRefresh.UseVisualStyleBackColor = False
        '
        'btnVidCancel
        '
        Me.btnVidCancel.BackColor = System.Drawing.Color.Red
        Me.btnVidCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVidCancel.ForeColor = System.Drawing.Color.White
        Me.btnVidCancel.Location = New System.Drawing.Point(292, 363)
        Me.btnVidCancel.Name = "btnVidCancel"
        Me.btnVidCancel.Size = New System.Drawing.Size(117, 23)
        Me.btnVidCancel.TabIndex = 7
        Me.btnVidCancel.Text = "Annuler"
        Me.btnVidCancel.UseVisualStyleBackColor = False
        Me.btnVidCancel.Visible = False
        '
        'DLProgress
        '
        Me.DLProgress.Location = New System.Drawing.Point(5, 364)
        Me.DLProgress.Name = "DLProgress"
        Me.DLProgress.Size = New System.Drawing.Size(180, 23)
        Me.DLProgress.TabIndex = 6
        Me.DLProgress.Visible = False
        '
        'ListVid
        '
        Me.ListVid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListVid.CheckBoxes = True
        Me.ListVid.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.filename, Me.filedate, Me.filesize})
        Me.ListVid.FullRowSelect = True
        Me.ListVid.Location = New System.Drawing.Point(191, 25)
        Me.ListVid.Name = "ListVid"
        Me.ListVid.Size = New System.Drawing.Size(342, 334)
        Me.ListVid.TabIndex = 5
        Me.ListVid.UseCompatibleStateImageBehavior = False
        '
        'PanelVidTitle
        '
        Me.PanelVidTitle.AutoSize = True
        Me.PanelVidTitle.Location = New System.Drawing.Point(25, 7)
        Me.PanelVidTitle.Name = "PanelVidTitle"
        Me.PanelVidTitle.Size = New System.Drawing.Size(138, 13)
        Me.PanelVidTitle.TabIndex = 4
        Me.PanelVidTitle.Text = "Liste des vidéos disponibles"
        '
        'BtnVidClose
        '
        Me.BtnVidClose.BackColor = System.Drawing.Color.Red
        Me.BtnVidClose.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.BtnVidClose.ForeColor = System.Drawing.Color.White
        Me.BtnVidClose.Location = New System.Drawing.Point(513, 3)
        Me.BtnVidClose.Margin = New System.Windows.Forms.Padding(0)
        Me.BtnVidClose.Name = "BtnVidClose"
        Me.BtnVidClose.Size = New System.Drawing.Size(20, 20)
        Me.BtnVidClose.TabIndex = 3
        Me.BtnVidClose.Text = "X"
        Me.BtnVidClose.UseVisualStyleBackColor = False
        '
        'BtnVidDL
        '
        Me.BtnVidDL.BackColor = System.Drawing.Color.Green
        Me.BtnVidDL.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnVidDL.ForeColor = System.Drawing.Color.White
        Me.BtnVidDL.Location = New System.Drawing.Point(416, 363)
        Me.BtnVidDL.Name = "BtnVidDL"
        Me.BtnVidDL.Size = New System.Drawing.Size(117, 23)
        Me.BtnVidDL.TabIndex = 2
        Me.BtnVidDL.Text = "Télécharger"
        Me.BtnVidDL.UseVisualStyleBackColor = False
        '
        'ListVidDate
        '
        Me.ListVidDate.FormattingEnabled = True
        Me.ListVidDate.IntegralHeight = False
        Me.ListVidDate.Location = New System.Drawing.Point(4, 25)
        Me.ListVidDate.Name = "ListVidDate"
        Me.ListVidDate.Size = New System.Drawing.Size(181, 334)
        Me.ListVidDate.TabIndex = 0
        '
        'PanelMaskRestart
        '
        Me.PanelMaskRestart.Controls.Add(Me.PanelMaskRestartTxt)
        Me.PanelMaskRestart.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelMaskRestart.Location = New System.Drawing.Point(0, 27)
        Me.PanelMaskRestart.Name = "PanelMaskRestart"
        Me.PanelMaskRestart.Size = New System.Drawing.Size(1009, 608)
        Me.PanelMaskRestart.TabIndex = 6
        Me.PanelMaskRestart.Visible = False
        '
        'PanelMaskRestartTxt
        '
        Me.PanelMaskRestartTxt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelMaskRestartTxt.Location = New System.Drawing.Point(0, 0)
        Me.PanelMaskRestartTxt.Name = "PanelMaskRestartTxt"
        Me.PanelMaskRestartTxt.Size = New System.Drawing.Size(1009, 608)
        Me.PanelMaskRestartTxt.TabIndex = 0
        Me.PanelMaskRestartTxt.Text = "Redémarrage en cours ..."
        Me.PanelMaskRestartTxt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PanelCamControl
        '
        Me.PanelCamControl.Controls.Add(Me.btnright)
        Me.PanelCamControl.Controls.Add(Me.btndown)
        Me.PanelCamControl.Controls.Add(Me.btnleft)
        Me.PanelCamControl.Controls.Add(Me.btnUp)
        Me.PanelCamControl.Location = New System.Drawing.Point(889, 515)
        Me.PanelCamControl.Name = "PanelCamControl"
        Me.PanelCamControl.Size = New System.Drawing.Size(120, 120)
        Me.PanelCamControl.TabIndex = 1
        '
        'btnright
        '
        Me.btnright.Image = Global.DadCam.My.Resources.Resources.r
        Me.btnright.Location = New System.Drawing.Point(80, 40)
        Me.btnright.Name = "btnright"
        Me.btnright.Size = New System.Drawing.Size(40, 40)
        Me.btnright.TabIndex = 3
        Me.btnright.UseVisualStyleBackColor = True
        '
        'btndown
        '
        Me.btndown.Image = Global.DadCam.My.Resources.Resources.d
        Me.btndown.Location = New System.Drawing.Point(40, 80)
        Me.btndown.Name = "btndown"
        Me.btndown.Size = New System.Drawing.Size(40, 40)
        Me.btndown.TabIndex = 2
        Me.btndown.UseVisualStyleBackColor = True
        '
        'btnleft
        '
        Me.btnleft.Image = Global.DadCam.My.Resources.Resources.l
        Me.btnleft.Location = New System.Drawing.Point(0, 40)
        Me.btnleft.Name = "btnleft"
        Me.btnleft.Size = New System.Drawing.Size(40, 40)
        Me.btnleft.TabIndex = 1
        Me.btnleft.UseVisualStyleBackColor = True
        '
        'btnUp
        '
        Me.btnUp.Image = Global.DadCam.My.Resources.Resources.u
        Me.btnUp.Location = New System.Drawing.Point(40, 0)
        Me.btnUp.Name = "btnUp"
        Me.btnUp.Size = New System.Drawing.Size(40, 40)
        Me.btnUp.TabIndex = 0
        Me.btnUp.UseVisualStyleBackColor = True
        '
        'DadCam
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1009, 657)
        Me.Controls.Add(Me.PanelCamControl)
        Me.Controls.Add(Me.PanelVid)
        Me.Controls.Add(Me.PanelMaskRestart)
        Me.Controls.Add(Me.CamStatus)
        Me.Controls.Add(Me.MenuBar)
        Me.Controls.Add(Me.WebHidden)
        Me.Controls.Add(Me.WebCam1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuBar
        Me.MaximizeBox = False
        Me.Name = "DadCam"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Caméra Surveillance"
        Me.MenuBar.ResumeLayout(False)
        Me.MenuBar.PerformLayout()
        Me.CamStatus.ResumeLayout(False)
        Me.CamStatus.PerformLayout()
        Me.PanelVid.ResumeLayout(False)
        Me.PanelVid.PerformLayout()
        Me.PanelMaskRestart.ResumeLayout(False)
        Me.PanelCamControl.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents WebCam1 As System.Windows.Forms.WebBrowser
    Friend WithEvents MenuBar As System.Windows.Forms.MenuStrip
    Friend WithEvents MenuDL As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuView As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WebHidden As System.Windows.Forms.WebBrowser
    Friend WithEvents CamStatus As System.Windows.Forms.StatusStrip
    Friend WithEvents StatusCamTxt As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents MenuMemInfo As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents refreshMem As System.Windows.Forms.Timer
    Friend WithEvents MenuFrogg As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuCV As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents YoutubeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WikiToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuBaniere As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PanelVid As System.Windows.Forms.Panel
    Friend WithEvents PanelVidTitle As System.Windows.Forms.Label
    Friend WithEvents BtnVidClose As System.Windows.Forms.Button
    Friend WithEvents BtnVidDL As System.Windows.Forms.Button
    Friend WithEvents ListVidDate As System.Windows.Forms.ListBox
    Friend WithEvents MenuViewMini As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ListVid As System.Windows.Forms.ListView
    Friend WithEvents filename As System.Windows.Forms.ColumnHeader
    Friend WithEvents filedate As System.Windows.Forms.ColumnHeader
    Friend WithEvents filesize As System.Windows.Forms.ColumnHeader
    Friend WithEvents DLProgress As System.Windows.Forms.ProgressBar
    Friend WithEvents DllToolBar As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents MenuOption As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuMem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuConfig As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuCamRestart As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuOfficial As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PanelMaskRestart As System.Windows.Forms.Panel
    Friend WithEvents PanelMaskRestartTxt As System.Windows.Forms.Label
    Friend WithEvents MenuAdvancedConfig As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnVidCancel As System.Windows.Forms.Button
    Friend WithEvents PanelCamControl As System.Windows.Forms.Panel
    Friend WithEvents btnright As System.Windows.Forms.Button
    Friend WithEvents btndown As System.Windows.Forms.Button
    Friend WithEvents btnleft As System.Windows.Forms.Button
    Friend WithEvents btnUp As System.Windows.Forms.Button
    Friend WithEvents MenuViewAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BtnVidRefresh As System.Windows.Forms.Button
    Friend WithEvents MenuInfoVersion As System.Windows.Forms.ToolStripMenuItem

End Class
