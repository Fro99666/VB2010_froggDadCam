Public Class Configuration

    Private defaultUrl = "http://"

    'Init Script
    Private Sub Configuration_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'add models
        camModelToInpt()
        'add langs
        Dim runTimeResourceSet As Object
        Dim dictEntry As DictionaryEntry
        runTimeResourceSet = My.Resources.ResourceManager.GetResourceSet(System.Globalization.CultureInfo.CurrentCulture, False, True)
        For Each dictEntry In runTimeResourceSet
            If (dictEntry.Value.GetType() Is GetType(String)) And dictEntry.Key.length() = 2 Then ConfLang.Items.Add(dictEntry.Key)
        Next
    End Sub

    'Init Script, load datas
    Private Sub Configuration_Shown(sender As System.Object, e As System.EventArgs) Handles MyBase.Shown
        setFormData()
    End Sub

    'set id input content
    Private Sub setIdList()
        'delete all existing
        ConfId.Items.Clear()
        'add all existing id
        For w As Integer = 1 To DadCam.camTot
            ConfId.Items.Add(w)
        Next
    End Sub

    'edit case check cam data to display it in the form
    Private Sub setFormData()
        'set ID combo box content
        setIdList()
        'set form content
        If Not DadCam.urlCam = "" Then ConfUrl.Text = DadCam.urlCam Else ConfUrl.Text = defaultUrl
        ConfId.Text = DadCam.camID
        ConfModel.Text = DadCam.currModel
        ConfLog.Text = DadCam.urlLog
        ConfPass.Text = DadCam.urlPas
        ConfPassVerif.Text = DadCam.urlPas
        ConfPath.Text = DadCam.dlPath
        ConfLang.Text = DadCam.language
        'check if data filled are empty or not
        If DadCam.currModel = "" Or ConfUrl.Text = defaultUrl Then
            Me.Size = New Point(383, 267)
            ConfDel.Visible = False
        Else
            Me.Size = New Point(383, 295)
            ConfDel.Visible = True
        End If
    End Sub

    'add cam case
    Private Sub addFormData()
        ConfId.Items.Add(DadCam.camTot + 1)
        Me.Size = New Point(383, 267)
        ConfDel.Visible = False
        ConfId.Text = DadCam.camTot + 1
        ConfUrl.Text = defaultUrl
        ConfModel.Text = ""
        ConfLog.Text = ""
        ConfPass.Text = ""
        ConfPassVerif.Text = ""
        ConfPath.Text = DadCam.dlPath
        ConfLang.Text = DadCam.language
    End Sub

    'close main form if cancel config when no informations exit
    Private Sub ConfSave_Closing(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        'check if cam is not loaded and quit config, quit software / else reshow main form
        If DadCam.isCamLoaded = False Then
            'case config as strat screen
            DadCam.Close()
        Else
            If Application.OpenForms().OfType(Of MultiCam).Any Then
                'case config opened from multicam
                MultiCam.Focus()
            Else
                'case config opened from main win (if not from multicam)
                DadCam.Show()
            End If
        End If
    End Sub

    'click on path inpt, open path selector
    Private Sub ConfPath_Click(sender As System.Object, e As System.EventArgs) Handles ConfPath.Click
        Dim dialog As New FolderBrowserDialog()
        dialog.RootFolder = Environment.SpecialFolder.Desktop
        If ConfPath.Text = "" Then
            dialog.SelectedPath = Environment.SpecialFolder.Personal
        Else
            dialog.SelectedPath = ConfPath.Text
        End If
        dialog.Description = Lang.ConfPathDialDesc
        If dialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            ConfPath.Text = dialog.SelectedPath
            If Not ConfPath.Text.EndsWith("\") Then ConfPath.Text = ConfPath.Text & "\"
        End If
    End Sub

    'Live change Form lang
    Public Sub ConfLang_SelectedIndexChanged() Handles ConfLang.SelectedIndexChanged
        Me.Hide()
        Lang.setLang(ConfLang.Text)
        Me.Show()
    End Sub

    'add model input list
    Public Sub camModelToInpt()
        'clean all content
        ConfModel.Items.Clear()
        'add all models
        For Each model In DadCam.camModel
            ConfModel.Items.Add(model)
        Next
    End Sub

    'save button click
    Private Sub ConfSave_Click(sender As System.Object, e As System.EventArgs) Handles ConfSave.Click
        'init err var
        Dim hasErr As String = ""

        'model verification
        If ConfModel.Text = "" Then
            hasErr &= vbCrLf & "- " & ConfModelErr
            setConfModelInpt(False)
        Else
            setConfModelInpt(True)
        End If

        'url verification
        If ConfUrl.Text = "http://" Or Not InStr(1, ConfUrl.Text, "http") = 1 Then
            hasErr &= vbCrLf & "- " & ConfUrlErr
            setConfUrlInpt(False)
        Else
            setConfUrlInpt(True)
        End If

        'password verification
        If Not ConfPass.Text = ConfPassVerif.Text Then
            hasErr &= vbCrLf & "- " & ConfPassVerifErr
            setConfVerifInpt(False)
        Else
            setConfVerifInpt(True)
        End If

        'password verification
        If ConfPass.Text = "" Then
            hasErr &= vbCrLf & "- " & ConfPassErr
            setConfPassInpt(False)
        Else
            setConfPassInpt(True)
        End If

        'password verification
        If ConfLog.Text = "" Then
            hasErr &= vbCrLf & "- " & ConfLogErr
            setConfLogInpt(False)
        Else
            setConfLogInpt(True)
        End If

        'path verification
        If ConfPath.Text = "" Then
            hasErr &= vbCrLf & "- " & ConfPathErr
            setConfPathInpt(False)
        Else
            setConfPathInpt(True)
        End If

        'path verification
        If Not My.Computer.FileSystem.DirectoryExists(ConfPath.Text) Then
            hasErr &= vbCrLf & "- " & ConfPathExistErr
            setConfPathInpt(False)
        Else
            setConfPathInpt(True)
        End If

        'lang verification
        If ConfLang.Text = "" Then
            hasErr &= vbCrLf & "- " & ConfLangErr
            setConfLangInpt(False)
        Else
            setConfLangInpt(True)
        End If

        'send error message & exit sub
        If Not hasErr = "" Then
            MessageBox.Show(ConfErr & " :" & hasErr)
            Exit Sub
        End If

        'test information
        PanelTest.Visible = True
        Application.DoEvents()
        If Not DadCam.testBasicAuth(ConfUrl.Text, False, ConfLog.Text, ConfPass.Text) Then
            MessageBox.Show(ConfConnErr)
            PanelTest.Visible = False
            Exit Sub
        End If

        PanelTest.Visible = False
        Application.DoEvents()

        'check if new camera or not
        If ConfId.Text > DadCam.camTot Then DadCam.camTot = ConfId.Text
        'set datas
        DadCam.camID = ConfId.Text
        DadCam.setConfig(ConfModel.Text, ConfUrl.Text, ConfLog.Text, ConfPass.Text, ConfPath.Text, ConfLang.Text)
        'confirm
        MessageBox.Show(ConfOk)
        'form display
        Me.Close()
        DadCam.Show()
        'multicam refresh
        If MultiCam.Visible = True Then
            MultiCam.Close()
            MultiCam.Show()
        End If
    End Sub

    'del button click
    Private Sub ConfDel_Click(sender As System.Object, e As System.EventArgs) Handles ConfDel.Click
        If MsgBox(Lang.msgDeleteCam, MsgBoxStyle.YesNo, Lang.msgDeleteCamTitle) = MsgBoxResult.Yes Then
            'supprimer l'id en cours
            DadCam.removeConfig(ConfId.Text)
            'display last cam existing info
            DadCam.getConfig()
            setFormData()
            'result message
            MessageBox.Show(Lang.msgDeleteCamComplete, Lang.msgDeleteCamTitle)
            'multicam refresh
            If MultiCam.Visible = True Then
                MultiCam.Close()
                MultiCam.Show()
            End If
        End If
    End Sub

    'add button click
    Private Sub ConfNew_Click(sender As System.Object, e As System.EventArgs) Handles ConfNew.Click
        addFormData()
    End Sub

    'go to selected id (when change the id in the list)
    Private Sub ConfId_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ConfId.SelectionChangeCommitted
        DadCam.camID = ConfId.Text
        DadCam.getConfig()
        setFormData()
    End Sub

    Private Sub setConfUrlInpt(state As Boolean)
        If state = False Then
            ConfUrl.BackColor = Color.Red
            ConfUrl.ForeColor = Color.White
        Else
            ConfUrl.BackColor = Color.White
            ConfUrl.ForeColor = Color.Black
        End If
    End Sub

    Private Sub setConfModelInpt(state As Boolean)
        If state = False Then
            ConfModel.BackColor = Color.Red
            ConfModel.ForeColor = Color.White
        Else
            ConfModel.BackColor = Color.White
            ConfModel.ForeColor = Color.Black
        End If
    End Sub

    Private Sub setConfPathInpt(state As Boolean)
        If state = False Then
            ConfPath.BackColor = Color.Red
            ConfPath.ForeColor = Color.White
        Else
            ConfPath.BackColor = Color.White
            ConfPath.ForeColor = Color.Black
        End If
    End Sub

    Private Sub setConfLogInpt(state As Boolean)
        If state = False Then
            ConfLog.BackColor = Color.Red
            ConfLog.ForeColor = Color.White
        Else
            ConfLog.BackColor = Color.White
            ConfLog.ForeColor = Color.Black
        End If
    End Sub

    Private Sub setConfPassInpt(state As Boolean)
        If state = False Then
            ConfPass.BackColor = Color.Red
            ConfPass.ForeColor = Color.White
        Else
            ConfPass.BackColor = Color.White
            ConfPass.ForeColor = Color.Black
        End If
    End Sub

    Private Sub setConfLangInpt(state As Boolean)
        If state = False Then
            ConfLang.BackColor = Color.Red
            ConfLang.ForeColor = Color.White
        Else
            ConfLang.BackColor = Color.White
            ConfLang.ForeColor = Color.Black
        End If
    End Sub

    Private Sub setConfVerifInpt(state As Boolean)
        If state = False Then
            ConfPass.BackColor = Color.Red
            ConfPass.ForeColor = Color.White
            ConfPassVerif.BackColor = Color.Red
            ConfPassVerif.ForeColor = Color.White
        Else
            ConfPass.BackColor = Color.White
            ConfPass.ForeColor = Color.Black
            ConfPassVerif.BackColor = Color.White
            ConfPassVerif.ForeColor = Color.Black
        End If
    End Sub


End Class