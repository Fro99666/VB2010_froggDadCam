Imports System.Xml

Module Lang

    ' MultiCam . text = Vision multi-caméra

    '#####Configuration
    '*Errors
    Public ConfOk
    Public ConfErr
    Public ConfConnErr
    Public ConfModelErr
    Public ConfUrlErr
    Public ConfPassErr
    Public ConfPassVerifErr
    Public ConfLogErr
    Public ConfPathErr
    Public ConfPathExistErr
    Public ConfLangErr
    '*Form
    Public ConfPathDialDesc

    '#####DadCam
    '*App
    Public AppDlExit
    Public AppExitTitle
    Public AppVersion
    Public AppNewVersion
    Public AppDLNewVersion
    Public AppMultiView
    '*Err
    Public ErrConn
    Public ErrDownload
    Public ErrDownloading
    Public ErrDeleteFile
    '*Cam
    Public cam
    Public camLive
    Public camMem
    '*msg
    Public msgRestart
    Public msgRestartTitle
    Public msgRestarting
    Public msgRestarted
    Public msgUpdated
    Public msgUpdating
    Public msgFormat
    Public msgFormatTitle
    Public msgFormating
    Public msgFormatingS
    Public msgFormated
    Public msgVideoMenuLoad
    Public msgDownloadStart
    Public msgDownloadCancel
    Public msgDownloadCanceled
    Public msgDownloadCancelTitle
    Public msgFile
    Public msgOn
    Public msgCurrentFile
    Public msgDeleteCam
    Public msgDeleteCamTitle
    Public msgDeleteCamComplete
    '*listview
    Public listVidName
    Public listVidDate
    Public listVidSize
    Public listVidLink

    Public Sub setLang(lang As String)

        Try
            Dim xDoc = New XmlDocument()
            xDoc.LoadXml(My.Resources.ResourceManager.GetObject(lang))

            '#####Configuration
            '*Errors
            ConfOk = xDoc.GetElementsByTagName("ConfOk")(0).InnerText
            ConfErr = xDoc.GetElementsByTagName("ConfErr")(0).InnerText
            ConfConnErr = xDoc.GetElementsByTagName("ConfConnErr")(0).InnerText
            ConfModelErr = xDoc.GetElementsByTagName("ConfModelErr")(0).InnerText
            ConfUrlErr = xDoc.GetElementsByTagName("ConfUrlErr")(0).InnerText
            ConfPassErr = xDoc.GetElementsByTagName("ConfPassErr")(0).InnerText
            ConfPassVerifErr = xDoc.GetElementsByTagName("ConfPassVerifErr")(0).InnerText
            ConfLogErr = xDoc.GetElementsByTagName("ConfLogErr")(0).InnerText
            ConfPathErr = xDoc.GetElementsByTagName("ConfPathErr")(0).InnerText
            ConfPathExistErr = xDoc.GetElementsByTagName("ConfPathExistErr")(0).InnerText
            ConfLangErr = xDoc.GetElementsByTagName("ConfLangErr")(0).InnerText
            '*form
            Configuration.PanelTestTxt.Text = xDoc.GetElementsByTagName("PanelTestTxt")(0).InnerText
            Configuration.ConfIDTxt.Text = xDoc.GetElementsByTagName("ConfIDTxt")(0).InnerText
            Configuration.ConfModelTxt.Text = xDoc.GetElementsByTagName("ConfModelTxt")(0).InnerText
            Configuration.ConfUrlTxt.Text = xDoc.GetElementsByTagName("ConfUrlTxt")(0).InnerText
            Configuration.ConfLogTxt.Text = xDoc.GetElementsByTagName("ConfLogTxt")(0).InnerText
            Configuration.ConfPassTxt.Text = xDoc.GetElementsByTagName("ConfPassTxt")(0).InnerText
            Configuration.ConfPassVerifTxt.Text = xDoc.GetElementsByTagName("ConfPassVerifTxt")(0).InnerText
            Configuration.ConfPathTxt.Text = xDoc.GetElementsByTagName("ConfPathTxt")(0).InnerText
            Configuration.ConfLangTxt.Text = xDoc.GetElementsByTagName("ConfLangTxt")(0).InnerText
            Configuration.ConfSave.Text = xDoc.GetElementsByTagName("ConfSave")(0).InnerText
            Configuration.ConfDel.Text = xDoc.GetElementsByTagName("ConfDel")(0).InnerText
            Configuration.ConfNew.Text = xDoc.GetElementsByTagName("ConfNew")(0).InnerText
            ConfPathDialDesc = xDoc.GetElementsByTagName("ConfPathDialDesc")(0).InnerText

            '#####DadCam
            '*App
            AppDlExit = xDoc.GetElementsByTagName("AppDlExit")(0).InnerText
            AppExitTitle = xDoc.GetElementsByTagName("AppExitTitle")(0).InnerText
            AppVersion = xDoc.GetElementsByTagName("AppVersion")(0).InnerText
            AppNewVersion = xDoc.GetElementsByTagName("AppNewVersion")(0).InnerText
            AppDLNewVersion = xDoc.GetElementsByTagName("AppDLNewVersion")(0).InnerText
            AppMultiView = xDoc.GetElementsByTagName("AppMultiView")(0).InnerText
            '*Err
            ErrConn = xDoc.GetElementsByTagName("ErrConn")(0).InnerText
            ErrDownloading = xDoc.GetElementsByTagName("ErrDownloading")(0).InnerText
            ErrDownload = xDoc.GetElementsByTagName("ErrDownload")(0).InnerText
            ErrDeleteFile = xDoc.GetElementsByTagName("ErrDeleteFile")(0).InnerText
            '*Cam
            cam = xDoc.GetElementsByTagName("cam")(0).InnerText
            camLive = xDoc.GetElementsByTagName("camLive")(0).InnerText
            camMem = xDoc.GetElementsByTagName("camMem")(0).InnerText
            DadCam.PanelMaskRestartTxt.Text = xDoc.GetElementsByTagName("PanelMaskRestart")(0).InnerText
            '*msg
            msgRestart = xDoc.GetElementsByTagName("msgRestart")(0).InnerText
            msgRestartTitle = xDoc.GetElementsByTagName("msgRestartTitle")(0).InnerText
            msgRestarting = xDoc.GetElementsByTagName("msgRestarting")(0).InnerText
            msgRestarted = xDoc.GetElementsByTagName("msgRestarted")(0).InnerText
            msgUpdated = xDoc.GetElementsByTagName("msgUpdated")(0).InnerText
            msgUpdating = xDoc.GetElementsByTagName("msgUpdating")(0).InnerText
            msgFormat = xDoc.GetElementsByTagName("msgFormat")(0).InnerText
            msgFormatTitle = xDoc.GetElementsByTagName("msgFormatTitle")(0).InnerText
            msgFormating = xDoc.GetElementsByTagName("msgFormating")(0).InnerText
            msgFormatingS = xDoc.GetElementsByTagName("msgFormatingS")(0).InnerText
            msgFormated = xDoc.GetElementsByTagName("msgFormated")(0).InnerText
            msgVideoMenuLoad = xDoc.GetElementsByTagName("msgVideoMenuLoad")(0).InnerText
            msgDownloadStart = xDoc.GetElementsByTagName("msgDownloadStart")(0).InnerText
            msgDownloadCancel = xDoc.GetElementsByTagName("msgDownloadCancel")(0).InnerText
            msgDownloadCanceled = xDoc.GetElementsByTagName("msgDownloadCanceled")(0).InnerText
            msgDownloadCancelTitle = xDoc.GetElementsByTagName("msgDownloadCancelTitle")(0).InnerText
            msgFile = xDoc.GetElementsByTagName("msgFile")(0).InnerText
            msgOn = xDoc.GetElementsByTagName("msgOn")(0).InnerText
            msgCurrentFile = xDoc.GetElementsByTagName("msgCurrentFile")(0).InnerText
            msgDeleteCam = xDoc.GetElementsByTagName("msgDeleteCamTitle")(0).InnerText
            msgDeleteCamTitle = xDoc.GetElementsByTagName("msgDeleteCamTitle")(0).InnerText
            msgDeleteCamComplete = xDoc.GetElementsByTagName("msgDeleteCamComplete")(0).InnerText
            '*listview
            listVidName = xDoc.GetElementsByTagName("listVidName")(0).InnerText
            listVidDate = xDoc.GetElementsByTagName("listVidDate")(0).InnerText
            listVidSize = xDoc.GetElementsByTagName("listVidSize")(0).InnerText
            listVidLink = xDoc.GetElementsByTagName("listVidLink")(0).InnerText
            '*form menu
            DadCam.Text = xDoc.GetElementsByTagName("DadCamTxt")(0).InnerText
            DadCam.MenuView.Text = xDoc.GetElementsByTagName("MenuViewTxt")(0).InnerText
            DadCam.MenuViewMini.Text = xDoc.GetElementsByTagName("MenuViewMiniTxt")(0).InnerText
            DadCam.MenuViewAll.Text = xDoc.GetElementsByTagName("MenuViewAllTxt")(0).InnerText
            DadCam.MenuDL.Text = xDoc.GetElementsByTagName("MenuDLTxt")(0).InnerText
            DadCam.MenuOption.Text = xDoc.GetElementsByTagName("MenuOptionTxt")(0).InnerText
            DadCam.MenuCamRestart.Text = xDoc.GetElementsByTagName("MenuCamRestartTxt")(0).InnerText
            DadCam.MenuMem.Text = xDoc.GetElementsByTagName("MenuMemTxt")(0).InnerText
            DadCam.MenuOfficial.Text = xDoc.GetElementsByTagName("MenuOfficialTxt")(0).InnerText
            DadCam.MenuConfig.Text = xDoc.GetElementsByTagName("MenuConfigTxt")(0).InnerText
            DadCam.MenuAdvancedConfig.Text = xDoc.GetElementsByTagName("MenuAdvancedConfigTxt")(0).InnerText
            DadCam.MenuInfoVersion.Text = xDoc.GetElementsByTagName("MenuInfoVersionTxt")(0).InnerText
            '*form video
            DadCam.PanelVidTitle.Text = xDoc.GetElementsByTagName("PanelVidTitle")(0).InnerText
            DadCam.BtnVidDL.Text = xDoc.GetElementsByTagName("BtnVidDL")(0).InnerText
            DadCam.btnVidCancel.Text = xDoc.GetElementsByTagName("btnVidCancel")(0).InnerText

            '#####Frogg
            DadCam.MenuBaniere.Text = xDoc.GetElementsByTagName("MenuBaniereTxt")(0).InnerText
            DadCam.MenuFrogg.Text = xDoc.GetElementsByTagName("MenuFroggTxt")(0).InnerText

        Catch ex As Exception
            MessageBox.Show("Cannot read '" & lang & "' File in the project, please contact admin@frogg.fr to fix this !" & vbCrLf & "Error message : " & vbCrLf & ex.Message)
            Exit Sub
        End Try

    End Sub

End Module
