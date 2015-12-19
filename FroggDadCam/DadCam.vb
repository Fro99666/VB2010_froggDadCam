Imports System.Net
Imports System.Text
Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Threading
Imports Microsoft.Win32

'TODO
'====
'1] voir l'annulation des downloads sous windows 8

'TODO BONUS
'==========
'#####Todo : Add update to menu if cancel update 
'#####Todo : design forms
'#####Todo : other cam constructor
'#####Todo : put all view in same tab + switch to cam directly from menu [?]
'[?] mean perhaps !

Public Class DadCam

#Region "VARS"

    ' ### CAM INFOS ###
    'nb total cams
    Public camTot As Integer = 1
    'num of selected cam
    Public camID As Integer = 1
    'cam url
    Public urlCam As String 'TODO : change to currcam ?
    'selected cam model
    Public currModel As String
    'web basic auth
    Public urlLog As String 'TODO : change to currlog ?
    Public urlPas As String 'TODO : change to currpass ?
    'video download path client
    Public dlPath As String 'TODO : change to currpath ?
    'lang
    Public language As String = "EN"
    'path where exe is started (used for update)
    Public exePath As String

    ' ### SCRIPT INFO ###
    Private Const version As String = "1.001"
    Public Const encryptLog As String = "Fr099d4DP4sSC0d3"
    Public Const encryptPass As String = "Fr099d4DL09C0d3"
    Public Const registryKey As String = "FroggDadCam"

    ' ### HttpWebRequest Params ###
    Private Const HttpUserAgent As String = "FroggDadCam Web Client"
    Private Const HttpAccept As String = " text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8"

    ' ### CAM URL ###
    'url list
    Public urls = New Dictionary(Of String, String)
    'model list
    Public camModel = New ArrayList()

    ' ###  FROGG INFOS ###
    Private Const froggVersion As String = "http://version.soft.frogg.fr"
    Private Const froggVersionFile As String = "v"
    Private Const froggcv As String = "http://cv.frogg.fr"
    Private Const froggwiki As String = "http://wiki.frogg.fr"
    Private Const froggyoutube As String = "http://youtube.frogg.fr"

    ' ### USED VAR ###
    'lock action if an action is already pending
    Private stopControl As Boolean = False
    'current status text (use to restore it while event replace it)
    Private currStatusT As String = ""
    'check if menu video is loaded
    Private isVidMenuLoaded As Boolean = False
    'check if can't connect to camera to not retry to refresh
    Private cantConnect As Boolean = False

    ' ### MULTITHREADING VAR ###
    'thread safe call back
    Delegate Sub SetThreadCallback(ByVal [text] As String)
    'thread safe call back
    Delegate Sub SetThreadInit(ByVal [text] As String)

#End Region


#Region "MAIN LOAD/UNLOAD"

    'Pre Init Script
    Private Sub DadCam_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        '####################
        '### AQUILAVIZION ###
        '####################
        'add to cam model list
        camModel.Add("AQUILAVIZION")
        'cam urls
        urls.Add("AQUILAVIZION_urlVid", "/sd/")
        urls.Add("AQUILAVIZION_urlCamView", "/web/admin.html")
        urls.Add("AQUILAVIZION_urlMiniCamView", "/web/mobile.html")
        urls.Add("AQUILAVIZION_urlCamReboot", "/cgi-bin/hi3510/sysreboot.cgi")
        urls.Add("AQUILAVIZION_urlCamFormat", "/cgi-bin/hi3510/sdfrmt.cgi")
        urls.Add("AQUILAVIZION_urlCamMemInfo", "/cgi-bin/hi3510/param.cgi?cmd=getserverinfo")
        urls.Add("AQUILAVIZION_urlCamConfig", "/web/initialize.html")
        'cam move
        urls.Add("AQUILAVIZION_urlCamMoveUp", "/cgi-bin/hi3510/ytup.cgi")
        urls.Add("AQUILAVIZION_urlCamMoveDw", "/cgi-bin/hi3510/ytdown.cgi")
        urls.Add("AQUILAVIZION_urlCamMoveLe", "/cgi-bin/hi3510/ytleft.cgi")
        urls.Add("AQUILAVIZION_urlCamMoveRi", "/cgi-bin/hi3510/ytright.cgi")
        'cam official web site
        urls.Add("AQUILAVIZION_urlCamOfficial", "http://www.aquilavizion.com/support.html")
    End Sub

    'Init Script
    Private Sub DadCam_Shown(sender As System.Object, e As System.EventArgs) Handles MyBase.Shown
        'load config
        loadConfig()
        'check if version is up to date
        checkVersion()
    End Sub

    'exit script
    Private Sub DadCam_Closing(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        'check if multicam is opened
        If Application.OpenForms().OfType(Of MultiCam).Any Then
            'case close with multicam opened
            e.Cancel = True
            Me.Hide()
            MultiCam.Focus()
            Exit Sub
        End If

        'check if there still download pending
        If isDownloading = True Then
            If Not MsgBox(Lang.AppDlExit, MsgBoxStyle.YesNo, Lang.AppExitTitle) = MsgBoxResult.Yes Then
                e.Cancel = True
            End If
        End If
    End Sub

    'start cam display
    Public isCamLoaded = False
    Public Sub loadCam(multi As Boolean)

        'refresh > hide main form
        MyBase.Hide()
        MyBase.Visible = False

        'set user lang
        Lang.setLang(language)

        'refresh diplay
        Application.DoEvents()

        'check if it is started from update downloaded file
        checkPath()

        'hide panel vid if loaded from any cam
        clearVidList()
        PanelVid.Hide()

        'set loading screen 
        Configuration.Show()
        Configuration.PanelTest.Visible = True
        'refresh diplay
        Application.DoEvents()

        'hide multi view if single camera configurated
        If camTot > 1 Then MenuViewAll.Visible = True Else MenuViewAll.Visible = False

        'set cache credentials
        setCacheCredentials()

        'test connexion
        If Not testBasicAuth(urlCam, True) Then
            MessageBox.Show(ConfConnErr)
            showConfig()
            Exit Sub
        End If

        'set visible main form
        Configuration.Hide()
        If multi Then
            MultiCam.Show()
        Else
            MyBase.Show()
            MyBase.Visible = True
        End If

        'set script version
        setVersion()

        'Show camera view
        showCam()

        'Show memory status (force first tick)
        showMem()

        'loaded
        isCamLoaded = True
    End Sub

#End Region


#Region "UPDATE"

    'check if version is uptodate, else download new version
    Private Sub checkVersion()
        'get version text file
        Dim liveVersion = getHtmlBasicAuth(froggVersion & "/" & registryKey & "/" & froggVersionFile, False)
        'if outdated
        If liveVersion > version Then
            If MsgBox(Lang.AppNewVersion & vbCrLf & registryKey & " " & Lang.AppVersion & " " & liveVersion, MsgBoxStyle.YesNo, registryKey) = MsgBoxResult.Yes Then
                Try
                    'hidding other panels
                    Me.Hide()
                    MultiCam.Hide()
                    Frogg.Hide()
                    'init display
                    Configuration.Show()
                    Configuration.PanelTestTxt.Text = Lang.msgUpdating
                    Configuration.ProgressBarNewVersion.Visible = True
                    'init vars
                    isDownloading = True
                    Dim downloadTarget = My.Computer.FileSystem.SpecialDirectories.Temp & "/" & registryKey & ".exe"
                    Dim Client As WebClient = New WebClient
                    'set events
                    AddHandler Client.DownloadProgressChanged, AddressOf update_ProgressChanged
                    AddHandler Client.DownloadFileCompleted, AddressOf update_DownloadCompleted
                    'prepare download
                    Client.Credentials = New NetworkCredential(urlLog, urlPas)
                    Client.Headers.Add("user-agent", HttpUserAgent)
                    If System.IO.File.Exists(downloadTarget) = True Then System.IO.File.Delete(downloadTarget)
                    'download
                    Client.DownloadFileAsync(New Uri(froggVersion & "/" & registryKey & "/" & registryKey & ".exe"), downloadTarget)
                    While isDownloading = True
                        Thread.Sleep(50) : Application.DoEvents()
                    End While
                    'set updated flag
                    setUpdateFlag()
                    're-run the exe
                    Process.Start(downloadTarget)
                    Me.Close()
                Catch ex As Exception
                    MessageBox.Show("Error : " & ex.Message)
                    Console.Write(ex)
                    isDownloading = False
                End Try
            Else
                'TODO Add update to menu ! ?
                'MessageBox.Show("TODO ADD TO MENU ...")
            End If
        End If
    End Sub

    'check if start from update file or original exe
    Private Sub checkPath()
        'check if is updated
        If getUpdateFlag() = 1 Then
            'do update
            'copy file to application original path & then restart it
            If System.IO.File.Exists(exePath) = True Then
                System.IO.File.Delete(exePath)
            End If
            System.IO.File.Copy(Application.ExecutablePath, exePath)
            MessageBox.Show(registryKey & " " & Lang.msgUpdated)
            'remove update flag
            removeUpdateFlag()
            'restart process
            Process.Start(exePath)
            Me.Close()
        Else
            'set current path (if exe has moved)
            setInstallPath()
        End If
    End Sub

    Private Sub setInstallPath()
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\" & registryKey, "installpath", Replace(Application.ExecutablePath, ".EXE", ".exe"))
    End Sub

    Private Sub setUpdateFlag()
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\" & registryKey, "updated", "1")
    End Sub

    Private Sub removeUpdateFlag()
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\" & registryKey, "updated", "0")
    End Sub

    Private Function getUpdateFlag()
        Return My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\" & registryKey, "updated", "0")
    End Function

    'event download progress
    Private Sub update_ProgressChanged(ByVal sender As Object, ByVal e As DownloadProgressChangedEventArgs)
        Configuration.ProgressBarNewVersion.Value = e.ProgressPercentage
    End Sub

    'event download complete
    Private Sub update_DownloadCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs)
        isDownloading = False
    End Sub


#End Region


#Region "CONFIG"

    'set config
    Public Sub setConfig(model As String, cam As String, log As String, pass As String, path As String, langage As String)
        'save conf
        saveConfig(model, cam, log, pass, path, langage)
        'set vars
        getConfig()
        'reload display
        loadCam(False)
    End Sub

    'get config
    Public Sub getConfig()
        camTot = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\" & registryKey, "camTot", camTot)
        currModel = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\" & registryKey & "\" & camID, "model", "")
        urlCam = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\" & registryKey & "\" & camID, "cam", "")
        urlLog = decodeStr(My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\" & registryKey & "\" & camID, "log", ""), encryptLog)
        urlPas = decodeStr(My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\" & registryKey & "\" & camID, "pass", ""), encryptPass)
        dlPath = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\" & registryKey & "\" & camID, "path", "")
        exePath = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\" & registryKey & "\", "installpath", Replace(Application.ExecutablePath, ".EXE", ".exe"))
        Dim tmpLang = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\" & registryKey & "\" & camID, "lang", language)
        If Not tmpLang = "" Then language = tmpLang
        'Should not be requiered cause default value should be taken, but it is not the case, so i put this bidouille
        If camTot = 0 Then camTot = 1
    End Sub

    'save config
    Private Sub saveConfig(model As String, cam As String, log As String, pass As String, path As String, langage As String)
        My.Computer.Registry.CurrentUser.CreateSubKey("Software").CreateSubKey(registryKey).CreateSubKey(camID)
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\" & registryKey, "camTot", camTot)
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\" & registryKey & "\" & camID, "model", model)
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\" & registryKey & "\" & camID, "log", encodeStr(log, encryptLog))
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\" & registryKey & "\" & camID, "pass", encodeStr(pass, encryptPass))
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\" & registryKey & "\" & camID, "cam", cam)
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\" & registryKey & "\" & camID, "path", path)
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\" & registryKey & "\" & camID, "lang", langage)
        setInstallPath()
    End Sub

    'remove config
    Public Sub removeConfig(ID)
        Dim regKey As Microsoft.Win32.RegistryKey
        regKey = Registry.CurrentUser.OpenSubKey("Software", True).OpenSubKey(registryKey, True)
        'delete selected id 
        regKey.DeleteSubKeyTree(ID, True)
        'reset cam ids to fit with a numeric list
        If Not ID = camTot Then
            For i As Integer = ID + 1 To camTot
                RegistryFunc.RenameSubKey(regKey, i, i - 1)
            Next
        End If
        'adjust values if no more camera then loaded go to false
        If camTot > 1 Then camTot = camTot - 1 Else isCamLoaded = False
        camID = camTot
        'set total cammera left
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\" & registryKey, "camTot", camTot)
        'close reg
        regKey.Close()
    End Sub

    'load config
    Private Sub loadConfig()
        'get saved config
        getConfig()
        'if config exist load form else form config
        If urlCam = "" Or urlLog = "" Or urlPas = "" Or dlPath = "" Or currModel = "" Then
            Lang.setLang(language)
            showConfig()
        Else
            If camTot = 1 Then
                'single view
                loadCam(False)
            Else
                'multiview
                loadCam(True)
            End If
        End If
    End Sub

    'show config panel
    Private Sub showConfig()
        MyBase.Visible = False
        MyBase.Hide()
        Configuration.Show()
        Configuration.PanelTest.Visible = False
    End Sub

    'encode string
    Private Function encodeStr(str As String, crypto As String)
        If str = "" Then Return ""
        Dim wrapper As New Encrypt(crypto)
        Return wrapper.EncryptData(str)
    End Function

    'decode string
    Public Function decodeStr(str As String, crypto As String)
        If str = "" Then Return ""
        Dim wrapper As New Encrypt(crypto)
        Return wrapper.DecryptData(str)
    End Function

#End Region


#Region "MAIN FUNC"

    'set script version
    Private Sub setVersion()
        Me.Text = Me.Text & " - " & Lang.AppVersion & " " & version
    End Sub

    'get html response with http basic auth
    Public Function testBasicAuth(url As String, useCache As Boolean, Optional log As String = "", Optional pass As String = "") As Boolean
        Dim loHttp As HttpWebRequest
        Dim loWebResponse As HttpWebResponse
        Try
            ' *** Establish the request
            loHttp = HttpWebRequest.Create(url)
            ' *** Set properties
            If useCache Then loHttp.Credentials = myCredentials Else loHttp.Credentials = New NetworkCredential(log, pass)
            loHttp.UserAgent = HttpUserAgent
            loHttp.Accept = HttpAccept
            ' *** Retrieve request info headers
            loWebResponse = loHttp.GetResponse()
            ' *** clean connexion
            loWebResponse.Close()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    'get html response with http basic auth
    Private Function getHtmlBasicAuth(url As String, useCache As Boolean, Optional log As String = "", Optional pass As String = "") As String
        Dim lcHtml = ""
        Dim loHttp As HttpWebRequest
        Dim loWebResponse As HttpWebResponse
        Dim loResponseStream As StreamReader

        Try
            ' *** Establish the request
            loHttp = HttpWebRequest.Create(url)
            ' *** Set properties
            If useCache Then loHttp.Credentials = myCredentials Else loHttp.Credentials = New NetworkCredential(log, pass)
            loHttp.UserAgent = HttpUserAgent
            loHttp.Accept = HttpAccept
            ' *** Retrieve request info headers
            loWebResponse = loHttp.GetResponse()
            loResponseStream = New StreamReader(loWebResponse.GetResponseStream())
            ' *** Get html response
            lcHtml = loResponseStream.ReadToEnd()
            ' *** clean connexion
            loWebResponse.Close()
            loResponseStream.Close()
        Catch ex As Exception
            cantConnect = True
            MessageBox.Show(Lang.ErrConn & " : " & vbCrLf & ex.ToString())
        End Try
        Return lcHtml
    End Function

    'get Binary response with http basic auth
    Public Function getBinBasicAuth(url As String, Optional log As String = "", Optional pass As String = "") As Byte()
        Dim loHttp As HttpWebRequest
        Dim SourceStream As System.IO.Stream
        Dim loWebResponse As HttpWebResponse

        Try
            ' *** Establish the request
            loHttp = HttpWebRequest.Create(url)
            ' *** Set properties
            If Not log = "" Then loHttp.Credentials = New NetworkCredential(log, pass)
            loHttp.UserAgent = HttpUserAgent
            loHttp.Accept = HttpAccept
            ' *** Retrieve request info headers
            loWebResponse = loHttp.GetResponse()
            ' *** Get stream response
            SourceStream = loWebResponse.GetResponseStream()
            ' *** SourceStream has no ReadAll, so we must read data block-by-block
            'Temporary Buffer and block size
            Dim Buffer(4096) As Byte, BlockSize As Integer
            ' *** Memory stream to store data
            Dim TempStream As New MemoryStream
            Do
                BlockSize = SourceStream.Read(Buffer, 0, 4096)
                If BlockSize > 0 Then TempStream.Write(Buffer, 0, BlockSize)
            Loop While BlockSize > 0
            ' *** clean connexion
            SourceStream.Close()
            loWebResponse.Close()
            ' *** return the document binary data
            Return TempStream.ToArray()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return Nothing
        End Try

    End Function

    'get links from a html page
    Public Function ExtractLinks(ByVal html As String) As DataTable
        'init datable
        Dim dt As New DataTable
        'set column names
        dt.Columns.Add("LinkText")
        dt.Columns.Add("LinkUrl")
        'set all match (links)
        Dim links As MatchCollection = Regex.Matches(html, "<a.*?href=""(.*?)"".*?>(.*?)</a>")
        'check links
        For Each match As Match In links
            Dim dr As DataRow = dt.NewRow
            Dim matchUrl As String = match.Groups(1).Value
            'Ignore all anchor links
            If matchUrl.StartsWith("#") Then Continue For
            'Ignore all javascript calls
            If matchUrl.ToLower.StartsWith("javascript:") Then Continue For
            'Ignore all email links
            If matchUrl.ToLower.StartsWith("mailto:") Then Continue For
            'For internal links, build the url mapped to the base address
            'If Not matchUrl.StartsWith("http://") And Not matchUrl.StartsWith("https://") Then
            'matchUrl = MapUrl(url, matchUrl)
            'End If
            'Add the link data to datatable
            dr("LinkUrl") = matchUrl
            dr("LinkText") = match.Groups(2).Value
            dt.Rows.Add(dr)
        Next
        'return result
        Return dt
    End Function

    'reformat url
    Public Function MapUrl(ByVal baseAddress As String, ByVal relativePath As String) As String
        Dim u As New System.Uri(baseAddress)
        If relativePath = "./" Then relativePath = "/"

        If relativePath.StartsWith("/") Then
            Return u.Scheme + Uri.SchemeDelimiter + u.Authority + relativePath
        Else
            Dim pathAndQuery As String = u.AbsolutePath
            ' If the baseAddress contains a file name, like ..../Something.aspx
            ' Trim off the file name
            pathAndQuery = pathAndQuery.Split("?")(0).TrimEnd("/")
            If pathAndQuery.Split("/")(pathAndQuery.Split("/").Count - 1).Contains(".") Then
                pathAndQuery = pathAndQuery.Substring(0, pathAndQuery.LastIndexOf("/"))
            End If
            baseAddress = u.Scheme + Uri.SchemeDelimiter + u.Authority + pathAndQuery
            'If the relativePath contains ../ then
            ' adjust the baseAddress accordingly
            While relativePath.StartsWith("../")
                relativePath = relativePath.Substring(3)
                If baseAddress.LastIndexOf("/") > baseAddress.IndexOf("//" + 2) Then
                    baseAddress = baseAddress.Substring(0, baseAddress.LastIndexOf("/")).TrimEnd("/")
                End If
            End While
            'return result
            Return baseAddress + "/" + relativePath
        End If
    End Function

    'fix to add cookie
    Public Declare Function InternetSetCookie Lib "wininet.dll" Alias "InternetSetCookieA" (ByVal lpszUrlName As String, ByVal lpszCookieName As String, ByVal lpszCookieData As String) As Boolean
    'show a web page trough auth in browser
    Public Sub showWebAuth(brower As WebBrowser, url As String, user As String, pass As String, Optional cookieName As String = "", Optional cookieValue As String = "")
        brower.ScriptErrorsSuppressed = True
        If Not cookieName = "" Then InternetSetCookie(url, cookieName, cookieValue)
        brower.Navigate(url, "", Nothing, "Authorization: Basic " & System.Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(user & ":" & pass)))
    End Sub

    'set cache credentials
    Dim myCredentials As New CredentialCache()
    Public Sub setCacheCredentials()
        myCredentials.Remove(New Uri(urlCam), "Basic")
        myCredentials.Add(New Uri(urlCam), "Basic", New NetworkCredential(urlLog, urlPas))
    End Sub

    'set url to http://log:pass@url
    Public Function urlPass(ByVal urlCam As String, ByVal urlLog As String, ByVal urlPas As String)
        Dim arrUrl = Split(urlCam, "://")
        urlPass = arrUrl(0) & "://" & urlLog & ":" & urlPas & "@" & arrUrl(1)
    End Function

#End Region


#Region "CAM FUNC"

    'show cam live video
    Private Sub showCam()
        showMenu()
        WebCam1.Dock = DockStyle.Fill
        WebCam1.Location = New Point(0, 27)
        Me.Size = New System.Drawing.Size(1015, 685)
        StatusCamTxt.Text = Lang.camLive & " " & urlCam & " !"
        showWebAuth(WebCam1, urlPass(urlCam, urlLog, urlPas) & urls(currModel & "_urlCamView"), urlLog, urlPas, "language", getCamLang(language))
    End Sub

    'show mini cam live video
    Private Sub showMiniCam()
        'hide menu
        hideMenu()
        'hide video list if opened
        PanelVid.Visible = False
        'changing display
        WebCam1.Dock = DockStyle.None
        WebCam1.Location = New Point(-10, -45)
        Me.Size = New System.Drawing.Size(325, 250)
        StatusCamTxt.Text = Lang.camLive & " " & urlCam & " !"
        showWebAuth(WebCam1, urlPass(urlCam, urlLog, urlPas) & urls(currModel & "_urlMiniCamView"), urlLog, urlPas, "language", getCamLang(language))
    End Sub

    Public Function getCamLang(userLang As String)
        Select Case userLang
            Case "FR"
                Return "french"
            Case "EN"
                Return "english"
            Case "RU"
                Return "russian"
            Case "DE"
                Return "deutsch"
            Case "JP"
                Return "japanese"
            Case "ES"
                Return "spanish"
            Case "KR"
                Return "korea"
            Case "CN"
                Return "simple_chinese"
            Case "CX"
                Return "tradi_chinese"
            Case Else
                Return "english"
        End Select
    End Function

    Private firstMemErr = False
    'display memory status
    Private Sub showMem()
        'exit if error already occured, to not spam
        'If firstMemErr Or stopControl Then Exit Sub
        'get web request mem data
        Dim precent = getMem()
        'set display
        MenuMemInfo.Text = camMem & " : " & precent & "%"
        'set back color depending og size
        Select Case True
            Case Not IsNumeric(precent)
                MenuMemInfo.BackColor = Color.Red
                MenuMemInfo.Text = camMem & " : " & precent
                firstMemErr = True
            Case precent < 45
                MenuMemInfo.BackColor = Color.Green
            Case precent >= 45 And precent < 60
                MenuMemInfo.BackColor = Color.YellowGreen
            Case precent >= 60 And precent < 75
                MenuMemInfo.BackColor = Color.Gold
            Case precent >= 75 And precent < 90
                MenuMemInfo.BackColor = Color.Orange
            Case precent >= 90
                MenuMemInfo.BackColor = Color.Red
        End Select
    End Sub

    'send restart event to the camera
    Private Sub restartCam()
        If MsgBox(Lang.msgRestart, MsgBoxStyle.YesNo, Lang.msgRestartTitle) = MsgBoxResult.Yes Then
            unControl("... " & Lang.msgRestarting & " ...")
            PanelMaskRestart.Visible = True
            'do restart as thread
            Dim trdRestartCam = New Thread(AddressOf restartCamAction)
            trdRestartCam.Start()
        End If
    End Sub

    'show confirm message after restart
    Private Sub restartCamAction()
        getHtmlBasicAuth(urlCam & urls(currModel & "_urlCamReboot"), True)
        Thread.Sleep(60000)
        MessageBox.Show(Lang.msgRestarted)
        If (Me.InvokeRequired) Then
            Me.Invoke(New SetThreadCallback(AddressOf reControl), New Object() {[Text]})
            Me.Invoke(New SetThreadCallback(AddressOf showCam), New Object() {[Text]})
        Else
            reControl()
            showCam()
        End If
    End Sub

    'show cam memory status
    Private Sub formatMem()
        If MsgBox(Lang.msgFormat, MsgBoxStyle.YesNo, Lang.msgFormatTitle) = MsgBoxResult.Yes Then
            unControl("... " & Lang.msgFormating & " ...")
            MenuMemInfo.Text = Lang.msgFormatingS
            'do format as thread
            Dim trdFormatMem = New Thread(AddressOf formatMemAction)
            trdFormatMem.Start()
            '###NO MORE USED
            'WebHidden.Url = New Uri(urlCam & urlCamFormat)
            'AddHandler WebHidden.DocumentCompleted, New WebBrowserDocumentCompletedEventHandler(AddressOf formated)
        End If
    End Sub

    '###NO MORE USED, but interresting code
    'show confimr message after format
    'Private Sub formated(ByVal sender As Object, ByVal e As WebBrowserDocumentCompletedEventArgs)
    '    RemoveHandler WebHidden.DocumentCompleted, AddressOf formated
    '    MessageBox.Show("La carte mémoire à été formatée avec succès !")
    '    reControl()
    'End Sub

    'thread safe format mem
    Private Sub formatMemAction()
        getHtmlBasicAuth(urlCam & urls(currModel & "_urlCamFormat"), True)
        'hide panel video if opened
        PanelVid.Visible = False
        MessageBox.Show(Lang.msgFormated)
        If (Me.InvokeRequired) Then
            Me.Invoke(New SetThreadCallback(AddressOf reControl), New Object() {[Text]})
            Me.Invoke(New SetThreadCallback(AddressOf showMem), New Object() {[Text]})
        Else
            showMem()
            reControl()
        End If
        'reset list
        resetVidList()
    End Sub

    'get memory value in %
    Public Function getMem()
        'prevent multiple error message if can't connect
        If Not testBasicAuth(urlCam & urls(currModel & "_urlCamMemInfo"), True) Then Return "N/A"
        'case if Dadcam form is closed, no need to check memorry
        If Not Me.Visible Then Return "N/A"
        'security if delet current cam
        Try
            'get html mem info 
            Dim memFileStr = getHtmlBasicAuth(urlCam & urls(currModel & "_urlCamMemInfo"), True)
            'get free space if found in string
            Dim freespace As MatchCollection = Regex.Matches(memFileStr, "sdfreespace=""(.*?)"";")
            Dim freespaceTxt = ""
            If freespace.Count > 0 Then freespaceTxt = freespace.Item(0).Groups(1).Value Else Return "N/A"
            'get total space if found in string
            Dim totalspace As MatchCollection = Regex.Matches(memFileStr, "sdtotalspace=""(.*?)"";")
            Dim totalspaceTxt = ""
            If totalspace.Count > 0 Then totalspaceTxt = totalspace.Item(0).Groups(1).Value Else Return "N/A"
            'return percent value
            Return Int((Int(totalspaceTxt) - Int(freespaceTxt)) * 100 / Int(totalspaceTxt))
        Catch ex As Exception
            Return "N/A"
        End Try
    End Function

#End Region


#Region "CAM MOVE"
    'click up
    Private Sub btnUp_Click(sender As System.Object, e As System.EventArgs) Handles btnUp.Click
        getHtmlBasicAuth(urlCam & urls(currModel & "_urlCamMoveUp"), True)
    End Sub
    'click left
    Private Sub btnleft_Click(sender As System.Object, e As System.EventArgs) Handles btnleft.Click
        getHtmlBasicAuth(urlCam & urls(currModel & "_urlCamMoveLe"), True)
    End Sub
    'click right
    Private Sub btnright_Click(sender As System.Object, e As System.EventArgs) Handles btnright.Click
        getHtmlBasicAuth(urlCam & urls(currModel & "_urlCamMoveRi"), True)
    End Sub
    'click down
    Private Sub btndown_Click(sender As System.Object, e As System.EventArgs) Handles btndown.Click
        getHtmlBasicAuth(urlCam & urls(currModel & "_urlCamMoveDw"), True)
    End Sub
#End Region


#Region "MENU FUNC"

    'stop menu actions
    Private Sub unControl(txt As String)
        stopControl = True
        currStatusT = StatusCamTxt.Text
        StatusCamTxt.Text = txt
        Application.DoEvents()
    End Sub

    'restore menu actions
    Private Sub reControl()
        stopControl = False
        StatusCamTxt.Text = currStatusT
        PanelMaskRestart.Visible = False
    End Sub

    'hide menu for minimized mode
    Private Sub hideMenu()
        MenuViewAll.Visible = False
        MenuViewMini.Visible = False
        MenuDL.Visible = False
        MenuMem.Visible = False
        MenuCamRestart.Visible = False
        MenuFrogg.Visible = False
    End Sub

    'show menu for maximized mode
    Private Sub showMenu()
        If camTot > 1 Then MenuViewAll.Visible = True
        MenuViewMini.Visible = True
        MenuDL.Visible = True
        MenuMem.Visible = True
        MenuCamRestart.Visible = True
        MenuFrogg.Visible = True
    End Sub

#End Region


#Region "MENU ACTION"

    'click on cam menu
    Private Sub MenuView_Click(sender As System.Object, e As System.EventArgs) Handles MenuView.Click
        If stopControl = True Then Exit Sub
        showCam()
    End Sub

    'click on mini cam
    Private Sub MenuViewMini_Click(sender As System.Object, e As System.EventArgs) Handles MenuViewMini.Click
        If stopControl = True Then Exit Sub
        showMiniCam()
    End Sub

    'click on mem menu
    Private Sub MenuMem_Click(sender As System.Object, e As System.EventArgs) Handles MenuMem.Click
        If stopControl = True Then Exit Sub
        formatMem()
    End Sub

    'refresh memory value
    Private Sub refreshMem_Tick(sender As System.Object, e As System.EventArgs) Handles refreshMem.Tick
        If stopControl = True Or isCamLoaded = False Then Exit Sub
        showMem()
    End Sub

    'restart cam
    Private Sub MenuCamRestart_Click(sender As System.Object, e As System.EventArgs) Handles MenuCamRestart.Click
        If stopControl = True Then Exit Sub
        restartCam()
    End Sub

    'show video list
    Private Sub MenuDL_Click(sender As System.Object, e As System.EventArgs) Handles MenuDL.Click
        If isDownloading = False And stopControl = True Then Exit Sub
        PanelVid.Location = New Point(235, 90)
        PanelVid.Visible = True
        loadVidMenuList()
    End Sub

    'show config
    Private Sub MenuConfig_Click(sender As System.Object, e As System.EventArgs) Handles MenuConfig.Click
        showConfig()
    End Sub

    'official web site
    Private Sub MenuOfficial_Click(sender As System.Object, e As System.EventArgs) Handles MenuOfficial.Click
        Process.Start(urls(currModel & "_urlCamOfficial"))
    End Sub

    'show advanced configuration
    Private Sub MenuAdvancedConfig_Click(sender As System.Object, e As System.EventArgs) Handles MenuAdvancedConfig.Click
        Process.Start(urlCam & urls(currModel & "_urlCamConfig"))
    End Sub

    'show multicam window
    Private Sub MenuViewAll_Click(sender As System.Object, e As System.EventArgs) Handles MenuViewAll.Click
        MultiCam.Show()
        MultiCam.Focus()
    End Sub

#End Region


#Region "VIDEO DL FUNC"

    'reinit video list
    Private Sub clearVidList()
        ListVid.Clear()
        ListVidDate.Items.Clear()
        isVidMenuLoaded = False
    End Sub

    'load download menu
    Private Sub loadVidMenuList()
        If Not isVidMenuLoaded Then
            'remove control
            unControl("... " & Lang.msgVideoMenuLoad & " ...")
            'add each links founds
            Dim links = ExtractLinks(getHtmlBasicAuth(urlCam & urls(currModel & "_urlVid"), True))
            For Each link As DataRow In links.Rows
                'only if full digits (as date time)
                If Regex.IsMatch(link("LinkUrl"), "[0-9]{8}/$") Then
                    ListVidDate.Items.Add(link("LinkText"))
                End If
            Next
            'set menu vid as loaded
            isVidMenuLoaded = True
            'restore control
            reControl()
        End If
    End Sub

    'reset list
    Private Sub resetVidList()
        'delete list
        clearVidList()
        'reload list
        loadVidMenuList()
    End Sub

    'download menu click
    Private Sub ListVidDate_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ListVidDate.SelectedIndexChanged
        If stopControl = True Then Exit Sub
        If Not ListVidDate.SelectedItem = Nothing Then loadVidList(ListVidDate.SelectedItem.ToString())
    End Sub

    'load video list
    Private Sub loadVidList(dateVid As String)
        unControl("... " & Lang.msgVideoMenuLoad & " ...")
        'clean old result
        ListVid.Clear()
        'set list of video display type (columns)
        ListVid.View = View.Details
        ListVid.Columns.Clear()
        ListVid.Columns.Add("", 20, HorizontalAlignment.Center)
        ListVid.Columns.Add(Lang.listVidName, 160, HorizontalAlignment.Left)
        ListVid.Columns.Add(Lang.listVidDate, 105, HorizontalAlignment.Center)
        ListVid.Columns.Add(Lang.listVidSize, 40, HorizontalAlignment.Center)
        ListVid.Columns.Add(Lang.listVidLink, 0, HorizontalAlignment.Center)
        lvwColumnSorter = New ListViewColumnSorter()
        ListVid.ListViewItemSorter = lvwColumnSorter
        'get html
        Dim folderListHtml = getHtmlBasicAuth(urlCam & urls(currModel & "_urlVid") & dateVid, True)
        'get each folder line
        Dim folderLines As MatchCollection = Regex.Matches(folderListHtml, "/"">record(.*)/</a>")
        'for each recordXXX folders add video to video list
        For Each folderMatch As Match In folderLines
            Dim html = getHtmlBasicAuth(urlCam & urls(currModel & "_urlVid") & dateVid & "record" & folderMatch.Groups(1).Value & "/", True)
            'get each tr
            Dim lines As MatchCollection = Regex.Matches(html, "<tr>(.*?)</tr>")
            'check links
            For Each match As Match In lines
                'get tds content
                Dim cells As MatchCollection = Regex.Matches(match.Groups(1).Value, "<td>(.*?)</td>")
                Dim tds As New List(Of String)
                'transfert MatchCollection to array
                For Each c As Match In cells
                    tds.Add(Replace(c.Groups(1).Value, "&nbsp;", ""))
                Next
                'add to listview 
                If tds.Count > 0 Then
                    Dim links = ExtractLinks(tds(0))
                    If Regex.IsMatch(links(0)("LinkText"), "avi$") Then
                        'add each line
                        Dim itemLine As New ListViewItem("")
                        itemLine.SubItems.Add(links(0)("LinkText"))
                        itemLine.SubItems.Add(tds(1))
                        itemLine.SubItems.Add(tds(2))
                        itemLine.SubItems.Add(links(0)("LinkUrl"))
                        ListVid.Items.Add(itemLine)
                        'change background color if file already downloaded
                        If File.Exists(dlPath & links(0)("LinkText")) Then
                            ListVid.Items(ListVid.Items.Count - 1).BackColor = Color.LightGreen
                        End If
                    End If
                End If
            Next
            'restore control
            reControl()
        Next
    End Sub

    'add colum sort event
    Private lvwColumnSorter As ListViewColumnSorter
    Private fullCheckedVid As Boolean = False
    Private Sub ListVid_ColumnClick(sender As System.Object, e As ColumnClickEventArgs) Handles ListVid.ColumnClick

        'case click first column 
        Dim MousePosition = Me.ListVid.PointToClient(Control.MousePosition)
        Dim hit = Me.ListVid.HitTest(MousePosition)
        If MousePosition.X <= 20 Then
            'prevent null pointer exception
            If hit.Item Is Nothing Then Exit Sub
            'invert selection
            fullCheckedVid = Not fullCheckedVid
            Dim columnindex = hit.Item.SubItems.IndexOf(hit.SubItem)
            For i = 0 To Me.ListVid.Items.Count - 1
                Dim currItem = Me.ListVid.Items(i)
                If currItem.BackColor = Color.LightGreen Then
                    currItem.Checked = False
                Else
                    currItem.Checked = fullCheckedVid
                End If
            Next
            Exit Sub
        End If

        ' Determine if the clicked column is already the column that is 
        ' being sorted.
        If (e.Column = lvwColumnSorter.SortColumn) Then
            ' Reverse the current sort direction for this column.
            If (lvwColumnSorter.Order = SortOrder.Ascending) Then
                lvwColumnSorter.Order = SortOrder.Descending
            Else
                lvwColumnSorter.Order = SortOrder.Ascending
            End If
        Else
            ' Set the column number that is to be sorted; default to ascending.
            lvwColumnSorter.SortColumn = e.Column
            lvwColumnSorter.Order = SortOrder.Ascending
        End If

        ' Perform the sort with these new sort options.
        Me.ListVid.Sort()
    End Sub

    'close video list
    Private Sub BtnVidClose_Click(sender As System.Object, e As System.EventArgs) Handles BtnVidClose.Click
        PanelVid.Visible = False
    End Sub

    'refresh video list
    Private Sub BtnVidRefresh_Click(sender As System.Object, e As System.EventArgs) Handles BtnVidRefresh.Click
        resetVidList()
    End Sub

    'download bin file
    Private Function downloadBinFile(url As String, target As String, Optional log As String = "", Optional pass As String = "")
        Try
            Dim binFile = getBinBasicAuth(url, log, pass)
            Dim savedfile As FileStream = File.OpenWrite(target)
            savedfile.Write(binFile, 0, binFile.Length)
            savedfile.Close()
            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        End Try
    End Function

    'click download file button
    Private trd As Thread
    Private Sub BtnVidDL_Click(sender As System.Object, e As System.EventArgs) Handles BtnVidDL.Click
        If stopControl = True Then Exit Sub
        'launch download process
        Dim trd = New Thread(AddressOf doDownloadsThread)
        trd.Start()
    End Sub

    Private cancelDL As Boolean = False
    Private Sub btnVidCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnVidCancel.Click
        If MsgBox(Lang.msgDownloadCancelTitle, MsgBoxStyle.YesNo, Lang.msgDownloadCancel) = MsgBoxResult.Yes Then
            cancelDL = True
            trd.Abort()
        End If
    End Sub

    Private Sub doDownloadsThread()
        If (Me.InvokeRequired) Then
            Me.Invoke(New SetThreadCallback(AddressOf doDownloads), New Object() {[Text]})
        Else
            doDownloads()
        End If
    End Sub

    Private isDownloading As Boolean = False
    Private currDownloadName As String = ""
    Private nbDl As Integer = 0
    Dim checkedItems As ListView.CheckedListViewItemCollection
    'download selected file
    Private Sub doDownloads()
        'get all selected files
        checkedItems = ListVid.CheckedItems
        'get nb file to download
        nbDl = checkedItems.Count
        'if nothing is selected no need to download
        If nbDl = 0 Then Exit Sub

        'block controls
        ListVidDate.Enabled = False
        ListVid.Enabled = False
        BtnVidDL.Enabled = False
        btnVidCancel.Visible = True
        cancelDL = False

        unControl(Lang.msgDownloadStart)

        'init all download progress bar infos
        DLProgress.Value = 0
        DLProgress.Maximum = nbDl * 100
        DLProgress.Visible = True

        'init solo download progress
        DllToolBar.Value = 0
        DllToolBar.Maximum = 100
        DllToolBar.Visible = True

        'reinit
        currDl = 0
        maxDl = nbDl
        oldTxt = StatusCamTxt.Text
        currPrecent = 0

        'init vars
        Dim Client As WebClient = New WebClient

        'download files
        Try
            'create download file if not exist
            If (Not System.IO.Directory.Exists(dlPath)) Then
                System.IO.Directory.CreateDirectory(dlPath)
            End If
            'download each files selected
            For Each item In checkedItems
                'add download flag
                isDownloading = True
                currDownloadName = item.SubItems(1).Text
                'download stuff
                AddHandler Client.DownloadProgressChanged, AddressOf client_ProgressChanged
                AddHandler Client.DownloadFileCompleted, AddressOf client_DownloadCompleted
                Client.Credentials = New NetworkCredential(urlLog, urlPas)
                Client.Headers.Add("user-agent", HttpUserAgent)
                Client.DownloadFileAsync(New Uri(urlCam & item.SubItems(4).Text), dlPath & item.SubItems(1).Text)
                'wait till next download
                While isDownloading = True
                    Thread.Sleep(50) : Application.DoEvents()
                End While
            Next

            'launch vid if only one dl
            If currDl = 1 Then
                Process.Start(dlPath & currDownloadName)
            End If

        Catch ex As Exception
            If cancelDL = True Then
                'cancel download
                Client.CancelAsync()
                Client.Dispose()
                Client = Nothing
            Else
                'error message
                MessageBox.Show(Lang.ErrDownloading & " : " & ex.Message)
            End If
            DLProgress.Visible = False
            DllToolBar.Visible = False
            StatusCamTxt.Text = oldTxt
            ListVidDate.Enabled = True
            BtnVidDL.Enabled = True
            ListVid.Enabled = True
            btnVidCancel.Visible = False
        End Try

        'restore controls
        reControl()
    End Sub

    Private oldTxt As String = ""
    Private currDl As Integer = 0
    Private maxDl As Integer = 0
    Private currPrecent As Integer = 0
    'event download progress
    Private Sub client_ProgressChanged(ByVal sender As Object, ByVal e As DownloadProgressChangedEventArgs)
        Try
            Dim bytesIn As Double = Double.Parse(e.BytesReceived.ToString())
            Dim bytesIn3 As Double = bytesIn / 1024
            Dim bytesIn2 As Integer = bytesIn3
            Format(bytesIn2, "#0")
            Dim totalBytes As Double = Double.Parse(e.TotalBytesToReceive.ToString())
            Dim totalBytes3 As Double = totalBytes / 1024
            Dim totalBytes2 As Integer = totalBytes3
            Format(totalBytes, "#0")
            DllToolBar.Value = e.ProgressPercentage
            DLProgress.Value = (currDl * 100) + e.ProgressPercentage
            StatusCamTxt.Text = msgFile & " " & (currDl + 1) & " " & msgOn & " " & maxDl & " - " & msgCurrentFile & " " & currDownloadName & " [ " & bytesIn2 & " / " & totalBytes2 & " Ko ]"
        Catch exception1 As Exception
            StatusCamTxt.Text = ErrDownload
        End Try
    End Sub

    'event download complete
    Private Sub client_DownloadCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs)

        'cancel case
        If e.Cancelled Then
            currDl = maxDl
            isDownloading = False
            DLProgress.Visible = False
            DllToolBar.Visible = False
            StatusCamTxt.Text = oldTxt
            ListVidDate.Enabled = True
            ListVid.Enabled = True
            BtnVidDL.Enabled = True
            btnVidCancel.Visible = False
            ' delete uncomplete file if exist
            If System.IO.File.Exists(dlPath & currDownloadName) = True Then System.IO.File.Delete(dlPath & currDownloadName)
            Exit Sub
        End If

        'nb downloaded is increased
        currDl = currDl + 1
        'remove downloading flag
        isDownloading = False
        'end of progress bars !
        If currDl = maxDl Then
            DLProgress.Visible = False
            DllToolBar.Visible = False
            StatusCamTxt.Text = oldTxt
            ListVidDate.Enabled = True
            ListVid.Enabled = True
            BtnVidDL.Enabled = True
            btnVidCancel.Visible = False
            'set all download as downloaded color & unselect
            For Each item In checkedItems
                item.BackColor = Color.LightGreen
                item.Checked = False
            Next
        End If
    End Sub

    'show selected file in player
    Private Sub ListVid_DoubleClick(sender As System.Object, e As System.EventArgs) Handles ListVid.DoubleClick

        'Dim wmp As New WMPLib.WindowsMediaPlayer
        'VideoPlayer.WindowsMediaPlayer

        If ListVid.SelectedItems.Item(0).BackColor = Color.LightGreen Then
            'read local
            'wmp.openPlayer(dlPath & ListVid.SelectedItems.Item(0).SubItems(1).Text)
            Process.Start(dlPath & ListVid.SelectedItems.Item(0).SubItems(1).Text)
        Else
            'bonus : read online
            'showWebAuth(WebCam1, urlPass(urlCam & ListVid.SelectedItems.Item(0).SubItems(4).Text, urlLog, urlPas), urlLog, urlPas)
            'Process.Start(urlPass(urlCam & ListVid.SelectedItems.Item(0).SubItems(4).Text, urlLog, urlPas))

            For i = 0 To Me.ListVid.Items.Count - 1
                Me.ListVid.Items(i).Checked = False
            Next
            ListVid.SelectedItems.Item(0).Checked = True

            'launch download process
            Dim trd = New Thread(AddressOf doDownloadsThread)
            trd.Start()

        End If
    End Sub

#End Region


#Region "MOVE PANEL"

    Public MovePanel As Boolean
    Public MovePanel_MousePosition As Point

    Public Sub MoveForm_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles PanelVid.MouseDown
        If e.Button = MouseButtons.Left Then
            MovePanel = True
            Me.Cursor = Cursors.NoMove2D
            MovePanel_MousePosition = e.Location
        End If
    End Sub

    Public Sub MoveForm_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles PanelVid.MouseMove
        If MovePanel Then PanelVid.Location = PanelVid.Location + (e.Location - MovePanel_MousePosition)
    End Sub

    Public Sub MoveForm_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles PanelVid.MouseUp
        If e.Button = MouseButtons.Left Then
            MovePanel = False
            Me.Cursor = Cursors.Default
        End If
    End Sub

#End Region


#Region "Frogg MENU"

    Private Sub CurriculumVitaeToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles MenuCV.Click
        Process.Start(froggcv)
    End Sub

    Private Sub YoutubeToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles YoutubeToolStripMenuItem.Click
        Process.Start(froggyoutube)
    End Sub

    Private Sub WikiToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles WikiToolStripMenuItem.Click
        Process.Start(froggwiki)
    End Sub

    Private Sub BanièreToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles MenuBaniere.Click
        Frogg.Show()
    End Sub

#End Region

End Class
