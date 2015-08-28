Public Class MultiCam

    Private nbVidPerLine = 3

    'close main form if cancel config when no informations exit
    Private Sub MultiCam_Closing(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        'check if cam is not loaded and quit config, quit software / else reshow main form
        If DadCam.Visible = False And Configuration.Visible = False Then Application.Exit() Else DadCam.Focus()
    End Sub

    'form loading
    Private Sub MultiCam_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        renderCams()
    End Sub

    Public Sub renderCams()
        'adding cams
        For k As Integer = 1 To DadCam.camTot
            'get cam information
            Dim urlMod = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\" & DadCam.registryKey & "\" & k, "model", "")
            Dim urlCam = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\" & DadCam.registryKey & "\" & k, "cam", "")
            Dim urlLog = DadCam.decodeStr(My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\" & DadCam.registryKey & "\" & k, "log", ""), DadCam.encryptLog)
            Dim urlPas = DadCam.decodeStr(My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\" & DadCam.registryKey & "\" & k, "pass", ""), DadCam.encryptPass)
            Dim urlLng = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\" & DadCam.registryKey & "\" & k, "lang", "")
            'check if can log to cam
            checkCamToDisplay(urlCam & DadCam.urls(urlMod & "_urlMiniCamView"), urlLog, urlPas, urlLng, k)
        Next
    End Sub

    Private Sub checkCamToDisplay(url, log, pass, language, pos)
        'get display infos
        Dim modVal = pos Mod nbVidPerLine
        If modVal = 0 Then modVal = nbVidPerLine
        Dim modLine = Int((pos - 1) / nbVidPerLine)

        'add a mask
        Dim loader = New Panel
        loader.Dock = DockStyle.None
        loader.Size = New Point(350, 275)
        loader.Location = New Point((modVal - 1) * 350, modLine * 275)
        loader.BorderStyle = BorderStyle.FixedSingle
        loader.BringToFront()
        'loader.Name = "loader" & pos
        If DadCam.camTot > nbVidPerLine Then
            Me.Size = New Point((nbVidPerLine * 350) + (nbVidPerLine * 2), (275 * (modLine + 1)) + 21 + (modLine + 1))
        Else
            Me.Size = New Point((pos * 350) + (pos * 2), (275 * (modLine + 1)) + 21 + (modLine + 1))
        End If
        Me.Controls.Add(loader)
        'test connexion
        If Not DadCam.testBasicAuth(url, False, log, pass) Then
            loader.BackColor = Color.Black
            Dim txtBox As New TextBox
            txtBox.AutoSize = False
            txtBox.TextAlign = HorizontalAlignment.Center
            txtBox.Dock = DockStyle.Bottom
            txtBox.Text = Lang.cam & " " & pos & " " & Lang.ErrConn
            txtBox.BackColor = Color.Black
            txtBox.ForeColor = Color.Red
            txtBox.BorderStyle = BorderStyle.None
            txtBox.Tag = pos
            AddHandler txtBox.Click, AddressOf Me.goToOpt
            loader.Controls.Add(txtBox)
        Else
            'cam name
            Dim txtBox As New Button
            txtBox.TextAlign = HorizontalAlignment.Center
            txtBox.Dock = DockStyle.Bottom
            txtBox.Text = Lang.cam & " " & pos
            txtBox.Tag = pos
            AddHandler txtBox.Click, AddressOf Me.goToCam
            loader.Controls.Add(txtBox)
            'cam display
            Dim webcam As New WebBrowser
            webcam.Dock = DockStyle.Top
            webcam.ScrollBarsEnabled = False

            'DadCam.showWebAuth(webcam, "http://127.0.0.1/kw5/KW_TEST/testHeader.php", log, pass, "language", DadCam.getCamLang(language))
            DadCam.showWebAuth(webcam, url, log, pass, "language", DadCam.getCamLang(language))
            loader.Controls.Add(webcam)
        End If


    End Sub

    Private Sub goToOpt(ByVal sender As System.Object, ByVal e As System.EventArgs)
        DadCam.Hide()
        Configuration.Close()
        DadCam.camID = sender.tag
        DadCam.getConfig()
        Configuration.PanelTest.Visible = False
        Configuration.Show()
        Configuration.Focus()
    End Sub

    Private Sub goToCam(ByVal sender As System.Object, ByVal e As System.EventArgs)
        DadCam.Hide()
        DadCam.camID = sender.tag
        DadCam.getConfig()
        DadCam.loadCam(False)
        DadCam.getMem()
    End Sub

End Class