Imports System.IO
Imports System.Net.Mail
Imports Microsoft.Win32
Imports System.Drawing.Printing
Imports System.Math
Imports System.Diagnostics
Imports System.Data.OleDb
Imports System.Data

Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine


Public Class frmMain
    Dim exiting As Boolean = False
    Public watchfolder As FileSystemWatcher


    Private Sub tsbSchedule_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSchedule.Click
        Try
            SelectReport()
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try
    End Sub

    Private Sub SelectReport()
        Try
            'Add all selected reports to the list
            Dim strFilePathAndName As String
            Dim MyFile As FileInfo
            Dim intIndex As Integer
            Dim txtID As String
            Dim strOutputFileName As String
            Dim Split1() As String
            Dim Split2() As String



            If FolderExists(App_Path() & "ScheduledReports") = False Then
                System.IO.Directory.CreateDirectory(App_Path() & "ScheduledReports")
            End If

            If OpenFileDialog1.ShowDialog() <> Windows.Forms.DialogResult.Cancel Then
                For intIndex = 0 To UBound(OpenFileDialog1.FileNames)
                    strFilePathAndName = OpenFileDialog1.FileNames(intIndex)
                    Split1 = Split(strFilePathAndName, "\", -1)
                    Split2 = Split(Split1(UBound(Split1)), ".", -1)
                    MyFile = New FileInfo(strFilePathAndName)
                    Do
                        txtID = Path.GetFileNameWithoutExtension(Path.GetRandomFileName) & ".txt" ' dgvScheduleList.RowCount & GetRandomNumber(CInt(Now.Second), 10000) & GetRandomNumber(CInt(Now.Millisecond), 10000) & GetRandomNumber(CInt(Now.Minute), 10000) & ".txt"
                    Loop Until FileExists(App_Path() & "ScheduledReports\" & txtID) = False

                    dgvScheduleList.Rows.Add(txtID, Split2(0), "Do not export this report", "Monday;Tuesday;Wednesday;Thursday;Friday", "", "", strFilePathAndName)
                    strOutputFileName = App_Path() & "ScheduledReports\" & txtID
                    Dim objWriter As New System.IO.StreamWriter(strOutputFileName)
                    objWriter.Write("SOURCEREPORT" & vbCrLf)
                    objWriter.Write(strFilePathAndName & vbCrLf)
                    objWriter.Write("EXPORTINTERVALTYPE" & vbCrLf)
                    objWriter.Write("Do Not Export" & vbCrLf)
                    objWriter.Write("EXPORTDAYS" & vbCrLf)
                    objWriter.Write("Monday" & vbCrLf)
                    objWriter.Write("EXPORTDAYS" & vbCrLf)
                    objWriter.Write("Tuesday" & vbCrLf)
                    objWriter.Write("EXPORTDAYS" & vbCrLf)
                    objWriter.Write("Wednesday" & vbCrLf)
                    objWriter.Write("EXPORTDAYS" & vbCrLf)
                    objWriter.Write("Thursday" & vbCrLf)
                    objWriter.Write("EXPORTDAYS" & vbCrLf)
                    objWriter.Write("Friday" & vbCrLf)
                    objWriter.Close()
                Next intIndex
                SaveReportsList()
            End If
            NumberRows()
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try
    End Sub


    Private Sub SaveReportsList()
        Try
            Dim ReportSettingsInfo As String = App_Path() & "ScheduledReports\MainList.txt"
            Dim intColIndex As Integer
            Dim intRowIndex As Integer


            If FolderExists(App_Path() & "ScheduledReports") = False Then
                System.IO.Directory.CreateDirectory(App_Path() & "ScheduledReports")
            End If

            If dgvScheduleList.RowCount > 0 Then
                Dim objWriter As New System.IO.StreamWriter(ReportSettingsInfo)
                For intRowIndex = 0 To dgvScheduleList.RowCount - 1
                    For intColIndex = 0 To dgvScheduleList.ColumnCount - 1
                        objWriter.Write(dgvScheduleList.Item(intColIndex, intRowIndex).Value & vbCrLf)
                    Next (intColIndex)
                Next intRowIndex
                objWriter.Close()
                encryptfile(ReportSettingsInfo)

            End If
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try
    End Sub

    Private Sub SaveUserSettings()
        Try
            Dim ReportSettingsInfo As String = App_Path() & "Config.txt"
            Dim objWriter As New System.IO.StreamWriter(ReportSettingsInfo)

            objWriter.Write("SMTP SERVER" & vbCrLf)
            objWriter.Write(txtSMTP.Text & vbCrLf)
            objWriter.Write("USER ID" & vbCrLf)
            objWriter.Write(EncryptText(txtUserID.Text, glbEKey) & vbCrLf)
            objWriter.Write("PASSWORD" & vbCrLf)
            objWriter.Write(EncryptText(txtUserPassword.Text, glbEKey) & vbCrLf)
            objWriter.Write("USESSL" & vbCrLf)
            objWriter.Write(tsmUseSSL.Checked & vbCrLf)
            objWriter.Write("AUTO ON START" & vbCrLf)
            objWriter.Write(tsmAutoOnStart.Checked & vbCrLf)
            objWriter.Write("TRAY ON START" & vbCrLf)
            objWriter.Write(tsmTrayOnStart.Checked & vbCrLf)
            objWriter.Write("START WITH WINDOWS" & vbCrLf)
            objWriter.Write(tsmStartWithWindows.Checked & vbCrLf)
            objWriter.Write("LOAD LANGUAGE PACK" & vbCrLf)
            objWriter.Write(tsmLangPack.Checked & vbCrLf)
            objWriter.Write("SCHEDULE BUTTON" & vbCrLf)
            objWriter.Write(tsmScheduleBTN.Checked & vbCrLf)
            objWriter.Write("COPY BUTTON" & vbCrLf)
            objWriter.Write(tsmCopyBTN.Checked & vbCrLf)
            objWriter.Write("DELETE BUTTON" & vbCrLf)
            objWriter.Write(tsmDeleteBTN.Checked & vbCrLf)
            objWriter.Write("EXPORT BUTTON" & vbCrLf)
            objWriter.Write(tsmExportBTN.Checked & vbCrLf)
            objWriter.Write("VIEW BUTTON" & vbCrLf)
            objWriter.Write(tsmViewBTN.Checked & vbCrLf)
            objWriter.Write("PRINT BUTTON" & vbCrLf)
            objWriter.Write(tsmPrintBTN.Checked & vbCrLf)
            objWriter.Write("TO TRAY BUTTON" & vbCrLf)
            objWriter.Write(tsmToTrayBTN.Checked & vbCrLf)
            objWriter.Write("DELIVERY MODE BUTTON" & vbCrLf)
            objWriter.Write(tsmAutoDeliverBTN.Checked & vbCrLf)
            objWriter.Write("TRIGGER FOLDER" & vbCrLf)
            objWriter.Write(txtTriggerFolder.Text & vbCrLf)
            objWriter.Write("TRIGGER EMAIL" & vbCrLf)
            objWriter.Close()
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try
    End Sub
    Private Sub ReadUserSettings()
        Try
            Dim ReportSettingsInfo As String = App_Path() & "Config.txt"
            If FileExists(ReportSettingsInfo) = True Then

                Dim objReader As New System.IO.StreamReader(ReportSettingsInfo)
                Do
                    Select Case objReader.ReadLine
                        Case "SMTP SERVER"
                            txtSMTP.Text = objReader.ReadLine
                            If txtSMTP.Text = "Enter SMTP Server" Then
                                txtSMTP.ForeColor = Color.DarkGray
                            Else
                                txtSMTP.ForeColor = Color.Black
                            End If
                        Case "USER ID"
                            txtUserID.Text = DecryptText(objReader.ReadLine, glbEKey)
                            If txtUserID.Text = "Enter User ID" Then
                                txtUserID.ForeColor = Color.DarkGray
                            Else
                                txtUserID.ForeColor = Color.Black
                            End If
                        Case "PASSWORD"
                            txtUserPassword.Text = DecryptText(objReader.ReadLine, glbEKey)
                            If txtUserPassword.Text = "Enter Password" Then
                                txtUserPassword.ForeColor = Color.DarkGray
                            Else
                                txtUserPassword.ForeColor = Color.Black
                            End If
                        Case "USESSL"
                            tsmUseSSL.Checked = objReader.ReadLine
                        Case "AUTO ON START"
                            tsmAutoOnStart.Checked = objReader.ReadLine
                        Case "TRAY ON START"
                            tsmTrayOnStart.Checked = objReader.ReadLine
                        Case "START WITH WINDOWS"
                            tsmStartWithWindows.Checked = objReader.ReadLine
                        Case "LOAD LANGUAGE PACK"
                            tsmLangPack.Checked = objReader.ReadLine
                        Case "SCHEDULE BUTTON"
                            tsmScheduleBTN.Checked = objReader.ReadLine
                            tsbSchedule.Visible = tsmScheduleBTN.Checked
                        Case "COPY BUTTON"
                            tsmCopyBTN.Checked = objReader.ReadLine
                            tsbCopy.Visible = tsmCopyBTN.Checked
                        Case "DELETE BUTTON"
                            tsmDeleteBTN.Checked = objReader.ReadLine
                            tsbDelete.Visible = tsmDeleteBTN.Checked
                        Case "EXPORT BUTTON"
                            tsmExportBTN.Checked = objReader.ReadLine
                        Case "VIEW BUTTON"
                            tsmViewBTN.Checked = objReader.ReadLine
                            tsbView.Visible = tsmViewBTN.Checked
                        Case "PRINT BUTTON"
                            tsmPrintBTN.Checked = objReader.ReadLine
                            tsbPrint.Visible = tsmPrintBTN.Checked
                        Case "TO TRAY BUTTON"
                            tsmToTrayBTN.Checked = objReader.ReadLine
                            tsbToTray.Visible = tsmToTrayBTN.Checked
                        Case "DELIVERY MODE BUTTON"
                            tsmAutoDeliverBTN.Checked = objReader.ReadLine
                            tsbAutoDeliver.Visible = tsmAutoDeliverBTN.Checked
                        Case "TRIGGER FOLDER"
                            txtTriggerFolder.Text = objReader.ReadLine

                    End Select
                Loop Until objReader.EndOfStream
                objReader.Close()
            End If
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try
    End Sub


    Public Sub ReadReportsList()
        Try
            Dim ReportSettingsInfo As String = App_Path() & "ScheduledReports\MainList.txt"
            dgvScheduleList.Rows.Clear()
            If FileExists(ReportSettingsInfo) = True Then
                decryptfile(ReportSettingsInfo)
                Dim objReader As New System.IO.StreamReader(ReportSettingsInfo)
                Do
                    dgvScheduleList.Rows.Add(objReader.ReadLine(), objReader.ReadLine(), objReader.ReadLine(), objReader.ReadLine(), objReader.ReadLine(), objReader.ReadLine(), objReader.ReadLine())
                Loop Until objReader.EndOfStream
                objReader.Close()
                encryptfile(ReportSettingsInfo)

                NumberRows()
            End If
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try
    End Sub

    Private Sub NumberRows()
        Try
            Dim intRows As Integer
            For intRows = 0 To dgvScheduleList.Rows.Count - 1
                dgvScheduleList.Rows.Item(intRows).HeaderCell.Value = CStr(intRows + 1)
            Next
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try
    End Sub

    Private Sub frmMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            SaveReportsList()
            SaveUserSettings()
            CleanReportsFolder()
            KillTemp()
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
            End
        End Try
    End Sub

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            KillTemp()
            ToolStripStatusLabel3.Text = String.Format("Version {0}", My.Application.Info.Version.ToString)
            NotifyIcon1.Icon = Icon.FromHandle(CType(ImageList1.Images(1), Bitmap).GetHicon())
            tsbAutoDeliver.Image = ImageList1.Images(1)
            tsmAutoDeliver.Image = ImageList1.Images(3)
            AutoToolStripMenuItem.Image = ImageList1.Images(3)
            DeliveryModeToolStripMenuItem.Image = ImageList1.Images(3)
            NotifyIcon1.Visible = False
            intExportIntervalCounter = 0
            ReadReportsList()
            ReadUserSettings()

            glbActiveID = dgvScheduleList.Item(glbID, dgvScheduleList.CurrentRow.Index).Value
            glbActivePath = dgvScheduleList.Item(glbSourceReport, dgvScheduleList.CurrentRow.Index).Value


            If tsmTrayOnStart.Checked = True Then
                SendToTray()
                Me.Refresh()
            End If


            If tsmAutoOnStart.Checked = True Then
                booAutoDeliver = False 'Will get switched to true by AutoDelivery Sub
                AutoDeliver()
            End If

            If tsmLangPack.Checked = True Then
                LoadLangPack()
            End If
            SetWatchFolder()
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try
    End Sub

    Private Sub LoadLangPack()
        Try
            If FileExists(App_Path() & "LangPack.txt") = True Then
                Dim objReader As New System.IO.StreamReader(App_Path() & "LangPack.txt")
                'Main Form
                'Program Menu
                ProgramToolStripMenuItem.Text = objReader.ReadLine
                AutoToolStripMenuItem.Text = objReader.ReadLine
                SendToTrayToolStripMenuItem.Text = objReader.ReadLine
                tsbToTray.Text = SendToTrayToolStripMenuItem.Text
                ExitToolStripMenuItem.Text = objReader.ReadLine
                'Report Menu
                ReportToolStripMenuItem.Text = objReader.ReadLine
                ScheduleToolStripMenuItem.Text = objReader.ReadLine
                CopyToolStripMenuItem.Text = objReader.ReadLine
                DeleteToolStripMenuItem.Text = objReader.ReadLine
                ExportToolStripMenuItem.Text = objReader.ReadLine
                ViewToolStripMenuItem.Text = objReader.ReadLine
                PrintToolStripMenuItem.Text = objReader.ReadLine
                'Tools Menu
                ToolsToolStripMenuItem.Text = objReader.ReadLine
                tsmSMTPServer.Text = objReader.ReadLine
                BackupToolStripMenuItem.Text = objReader.ReadLine
                'Options Menu
                RestoreToolStripMenuItem.Text = objReader.ReadLine
                tsmAutoOnStart.Text = objReader.ReadLine
                tsmTrayOnStart.Text = objReader.ReadLine
                tsmStartWithWindows.Text = objReader.ReadLine
                tsmLangPack.Text = objReader.ReadLine
                tsmHideAllButtons.Text = objReader.ReadLine
                tsmIconSettings.Text = objReader.ReadLine
                tsmTrigger.Text = objReader.ReadLine
                'Help Menu
                HelpToolStripMenuItem.Text = objReader.ReadLine
                ContentsToolStripMenuItem.Text = objReader.ReadLine
                AboutToolStripMenuItem.Text = objReader.ReadLine
                'Buttons
                tsbSchedule.Text = ScheduleToolStripMenuItem.Text
                tsmScheduleBTN.Text = tsbSchedule.Text
                tsbCopy.Text = CopyToolStripMenuItem.Text
                tsmCopyBTN.Text = tsbCopy.Text
                tsbDelete.Text = DeleteToolStripMenuItem.Text
                tsmDeleteBTN.Text = tsbDelete.Text
                tsbExport.Text = ExportToolStripMenuItem.Text
                tsmExportBTN.Text = tsbExport.Text
                tsbView.Text = ViewToolStripMenuItem.Text
                tsmViewBTN.Text = tsbView.Text
                tsbPrint.Text = PrintToolStripMenuItem.Text
                tsmPrintBTN.Text = tsbPrint.Text
                tsbAutoDeliver.Text = AutoToolStripMenuItem.Text
                tsmAutoDeliverBTN.Text = tsbAutoDeliver.Text
                'Report List Column Heading
                dgvScheduleList.Columns(1).HeaderText = objReader.ReadLine
                dgvScheduleList.Columns(2).HeaderText = objReader.ReadLine
                dgvScheduleList.Columns(3).HeaderText = objReader.ReadLine
                dgvScheduleList.Columns(4).HeaderText = objReader.ReadLine
                dgvScheduleList.Columns(5).HeaderText = objReader.ReadLine
                'Settings Form
                frmSettings.Text = objReader.ReadLine
                'Schedule Tab
                frmSettings.tpgSchedule.Text = objReader.ReadLine
                frmSettings.cmbSelectSource.Text = objReader.ReadLine
                frmSettings.gbxExportInterval.Text = objReader.ReadLine
                frmSettings.lblUnit.Text = objReader.ReadLine
                frmSettings.lblValue.Text = objReader.ReadLine
                frmSettings.gbxExportTime.Text = objReader.ReadLine
                frmSettings.lblStart.Text = objReader.ReadLine
                frmSettings.lblEnd.Text = objReader.ReadLine
                frmSettings.gbxRunHistory.Text = objReader.ReadLine
                frmSettings.lblDate.Text = objReader.ReadLine
                frmSettings.lblTime.Text = objReader.ReadLine
                frmSettings.gbxExportDays.Text = objReader.ReadLine
                frmSettings.cmdMtoF.Text = objReader.ReadLine
                frmSettings.cmdAllDays.Text = objReader.ReadLine
                frmSettings.cmdClearDays.Text = objReader.ReadLine
                'Parameters Tab
                frmSettings.tpgParameters.Text = objReader.ReadLine
                frmSettings.gbxParList.Text = objReader.ReadLine
                frmSettings.gbxDynamic.Text = objReader.ReadLine
                frmSettings.lblType.Text = objReader.ReadLine
                frmSettings.lblOffsetValue.Text = objReader.ReadLine
                frmSettings.gbxDate.Text = objReader.ReadLine
                frmSettings.gbxTime.Text = objReader.ReadLine
                frmSettings.gbxBoolean.Text = objReader.ReadLine
                frmSettings.radTrue.Text = objReader.ReadLine
                frmSettings.radFalse.Text = objReader.ReadLine
                frmSettings.cmbValueStart.Text = objReader.ReadLine
                frmSettings.cmbValueEnd.Text = objReader.ReadLine
                frmSettings.dgvParameterList.Columns(1).HeaderText = objReader.ReadLine
                frmSettings.dgvParameterList.Columns(2).HeaderText = objReader.ReadLine
                frmSettings.dgvParameterList.Columns(3).HeaderText = objReader.ReadLine
                'Connections Tab
                frmSettings.tpgConnections.Text = objReader.ReadLine
                frmSettings.cmbRestoreConnDefaults.Text = objReader.ReadLine
                frmSettings.dgvConnections.Columns(0).HeaderText = objReader.ReadLine
                frmSettings.dgvConnections.Columns(1).HeaderText = objReader.ReadLine
                frmSettings.dgvConnections.Columns(2).HeaderText = objReader.ReadLine
                frmSettings.dgvConnections.Columns(3).HeaderText = objReader.ReadLine
                'Export Directory Tab
                frmSettings.tpgExportDirectory.Text = objReader.ReadLine
                frmSettings.cmbBrowseFolder.Text = objReader.ReadLine
                frmSettings.cmbDeleteFolder.Text = objReader.ReadLine
                frmSettings.dgvExportDirectories.Columns(0).HeaderText = objReader.ReadLine
                frmSettings.dgvExportDirectories.Columns(1).HeaderText = objReader.ReadLine
                'Printers Tab
                frmSettings.tpgExportPrinter.Text = objReader.ReadLine
                frmSettings.dgvExportPrinters.Columns(0).HeaderText = objReader.ReadLine
                frmSettings.dgvExportPrinters.Columns(1).HeaderText = objReader.ReadLine
                frmSettings.dgvExportPrinters.Columns(2).HeaderText = objReader.ReadLine
                frmSettings.dgvExportPrinters.Columns(3).HeaderText = objReader.ReadLine
                'Email Tab
                frmSettings.tpgExportEmail.Text = objReader.ReadLine
                frmSettings.cmbSaveTemplate.Text = objReader.ReadLine
                frmSettings.cmbLoadTemplate.Text = objReader.ReadLine
                frmSettings.lblExportSubject.Text = objReader.ReadLine

                frmAddressBook.Text = objReader.ReadLine
                frmAddressBook.cmbImportAbook().Text = objReader.ReadLine
                frmAddressBook.cmbAppendABook().Text = objReader.ReadLine
                frmAddressBook.cmbExportABook().Text = objReader.ReadLine
                frmAddressBook.dgvAddressBook.Columns(0).HeaderText = objReader.ReadLine
                frmAddressBook.dgvAddressBook.Columns(1).HeaderText = objReader.ReadLine
                frmAddressBook.dgvAddressBook.Columns(2).HeaderText = objReader.ReadLine
                frmAddressBook.dgvAddressBook.Columns(3).HeaderText = objReader.ReadLine
     
                'Viewer
                frmReportViewer.Text = objReader.ReadLine
                tsmAutoDeliver.Text = AutoToolStripMenuItem.Text()
                tsmExit.Text = ExitToolStripMenuItem.Text
                'Tray Icon Menu
                tsmRestore.Text = objReader.ReadLine
                objReader.Close()
            End If
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try
    End Sub


    Private Sub tsbDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbDelete.Click
        Try
            DeleteIDFiles()
            SaveReportsList()
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try
    End Sub

    Private Sub DeleteIDFiles()
        Try
            Dim FileToDelete As String
            Dim intRowIndex As Integer
            Dim arrSelectedIndex(0) As Integer

            For intRowIndex = dgvScheduleList.RowCount - 1 To 0 Step -1
                If dgvScheduleList(0, intRowIndex).Selected Then
                    arrSelectedIndex(UBound(arrSelectedIndex)) = intRowIndex
                    ReDim Preserve arrSelectedIndex(UBound(arrSelectedIndex) + 1)
                End If
            Next
            ReDim Preserve arrSelectedIndex(UBound(arrSelectedIndex) - 1)


            For intRowIndex = 0 To UBound(arrSelectedIndex)
                FileToDelete = App_Path() & "ScheduledReports\" & dgvScheduleList.Item(glbID, arrSelectedIndex(intRowIndex)).Value
                If System.IO.File.Exists(FileToDelete) = True Then
                    System.IO.File.Delete(FileToDelete)
                End If
                dgvScheduleList.Rows.RemoveAt(arrSelectedIndex(intRowIndex))
                dgvScheduleList.RefreshEdit()
            Next

            If dgvScheduleList.Rows.Count < 1 Then
                If FileExists(App_Path() & "ScheduledReports\MainList.txt") Then
                    Kill(App_Path() & "ScheduledReports\MainList.txt")
                End If
            End If
            NumberRows()
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try
    End Sub
    Private Sub ShowSettings(ByVal intRowIndex As Integer)
        Try
            Me.Cursor = Cursors.WaitCursor
            Timer2.Enabled = True
            ToolStripProgressBar1.PerformStep()
            If dgvScheduleList.SelectedRows.Count = 1 Then
                glbActiveID = dgvScheduleList.Item(glbID, dgvScheduleList.CurrentRow.Index).Value

                If intRowIndex >= 0 Then
                    If FileExists(dgvScheduleList.Item(glbSourceReport, dgvScheduleList.CurrentRow.Index).Value) = False Then

                        frmSettings.lblSourceError.Visible = True
                        frmSettings.tbxSourceReport.BackColor = Color.IndianRed
                    End If


                    Dim strSplitPV1() As String
                    strSplitPV1 = Split(dgvScheduleList.Item(glbID, dgvScheduleList.CurrentRow.Index).Value, ".", 2, CompareMethod.Text)

                    frmSettings.Show(Me)
                    SaveReportsList()
                End If
            End If
            Me.Cursor = Cursors.Default

            ToolStripProgressBar1.Value = 0
            SaveReportsList()
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try
    End Sub

    Private Sub dgvScheduleList_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvScheduleList.CellDoubleClick
        Try
            dgvScheduleList.Enabled = False
            ShowSettings(e.RowIndex)
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try
    End Sub

    Private Sub dgvScheduleList_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvScheduleList.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.Delete
                    DeleteIDFiles()
            End Select
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try
    End Sub


    Private Sub tsbCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbCopy.Click
        Try
            CopyReport()
            SaveReportsList()
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try
    End Sub

    Private Sub CopyReport()
        Try
            Dim intRowIndex As Integer
            Dim s As String = ""
            Dim txtID As String
            Dim arrCurrent(8) As String
            Dim intArrayIndex As Integer
            Dim sourceFileName As String
            Dim destFileName As String

            For intRowIndex = 0 To dgvScheduleList.RowCount - 1
                If dgvScheduleList(0, intRowIndex).Selected Then
                    For intArrayIndex = 0 To 6
                        arrCurrent(intArrayIndex) = CStr(dgvScheduleList.Item(intArrayIndex, intRowIndex).Value)
                    Next
                    Do

                        txtID = Path.GetFileNameWithoutExtension(Path.GetRandomFileName) & ".txt"

                    Loop Until FileExists(App_Path() & "ScheduledReports\" & txtID) = False
                    sourceFileName = App_Path() & "ScheduledReports\" & arrCurrent(0)
                    destFileName = App_Path() & "ScheduledReports\" & txtID
                    dgvScheduleList.Rows.Add(txtID, arrCurrent(1), arrCurrent(2), arrCurrent(3), arrCurrent(4), arrCurrent(5), arrCurrent(6))
                    File.Copy(sourceFileName, destFileName, True)
                End If
            Next
            NumberRows()
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try
    End Sub

    Private Sub tsbExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbExport.Click
        Try
            Dim intRowIndex As Integer
            Dim datTimeStart As Date
            Dim strFilename As String
            Dim strCheckSource As String = ""
            Dim txtDataID = ""
            Dim objReader As System.IO.StreamReader
            Dim intSeconds As Integer

            tsbExport.Enabled = False
            tsmExport.Enabled = False
            datTimeStart = Now()
            intSeconds = Second(datTimeStart)
            datTimeStart = DateAdd(DateInterval.Second, -intSeconds, datTimeStart)
            For intRowIndex = 0 To dgvScheduleList.RowCount - 1
                If dgvScheduleList(0, intRowIndex).Selected Then
                    strFilename = App_Path() & "ScheduledReports\" & dgvScheduleList.Item(glbID, intRowIndex).Value ' strActiveID
                    If FileExists(strFilename) = True Then
                        decryptfile(strFilename)
                        objReader = New StreamReader(strFilename)
                        Do
                            txtDataID = (objReader.ReadLine)
                            Select Case txtDataID
                                Case "SOURCEREPORT"
                                    strCheckSource = (objReader.ReadLine)
                                    Exit Do
                            End Select
                        Loop Until objReader.EndOfStream
                        objReader.Close()
                        encryptfile(strFilename)

                        If FileExists(strCheckSource) = True Then
                            ForcedExport(intRowIndex)
                            dgvScheduleList.Item(glbRunHistory, intRowIndex).Value = datTimeStart 'Format(datTimeStart, "M/d/yyyy hh:mm tt") 'datTimeStart
                            ToolStripProgressBar1.Value = 0
                        End If
                    End If
                End If
            Next intRowIndex
            tsbExport.Enabled = True
            tsmExport.Enabled = True
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try
    End Sub

    Private Sub ForcedExport(ByVal intSelectedRow As Integer)
        Try
            Dim objReader As System.IO.StreamReader
            Dim booHasBatch As Boolean = False
            Dim objBatchParameter As Object = ""
            Dim txtRead As String
            Dim intArrIndex As Integer
            Dim strSourceReport As String = ""
            Dim strBatchParameter As String = ""
            Dim strWorkingFile As String
            Dim strBatchFile As String


            glbActiveID = dgvScheduleList.Item(glbID, intSelectedRow).Value
            strWorkingFile = GetWorkingFile()
            FileCopy(App_Path() & "ScheduledReports\" & dgvScheduleList.Item(glbID, intSelectedRow).Value, strWorkingFile)
            decryptfile(strWorkingFile)
            objReader = New StreamReader(strWorkingFile)
            Do
                txtRead = objReader.ReadLine
                Select Case UCase(txtRead)
                    Case "SOURCEREPORT"
                        strSourceReport = objReader.ReadLine
                    Case "[BATCH]"
                        booHasBatch = True
                        Exit Select
                    Case Else
                        strBatchParameter = txtRead
                End Select
            Loop Until booHasBatch = True Or objReader.EndOfStream
            objReader.Close()
            encryptfile(strWorkingFile)

            If booHasBatch = False Then
                ExportReport(strWorkingFile)
                SaveReportsList()
            Else
                GetBatchValues(strBatchParameter)
                For intArrIndex = 0 To UBound(arrBatchParameter)
                    strBatchFile = GetWorkingFile()
                    decryptfile(strBatchFile)
                    CreateTempBatchFile("[BATCH]", arrBatchParameter(intArrIndex), strWorkingFile, strBatchFile)
                    encryptfile(strBatchFile)
                    ExportReport(strBatchFile)
                    SaveReportsList()
                Next intArrIndex
            End If
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try
    End Sub

    Private Sub ExportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportToolStripMenuItem.Click
        Try
            Dim intRowIndex As Integer
            Dim datTimeStart As Date
            Dim intSeconds As Integer
            tsbExport.Enabled = False
            tsmExport.Enabled = False
            ExportToolStripMenuItem.Enabled = False
            datTimeStart = Now()
            intSeconds = Second(datTimeStart)
            datTimeStart = DateAdd(DateInterval.Second, -intSeconds, datTimeStart)
            For intRowIndex = 0 To dgvScheduleList.RowCount - 1
                If dgvScheduleList(0, intRowIndex).Selected Then
                    ForcedExport(intRowIndex)
                    dgvScheduleList.Item(glbRunHistory, intRowIndex).Value = datTimeStart 'Format(datTimeStart, "M/d/yyyy hh:mm tt") 'datTimeStart
                End If
            Next intRowIndex
            tsbExport.Enabled = True
            tsmExport.Enabled = True
            ExportToolStripMenuItem.Enabled = True
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try
    End Sub

    Private Sub ExportReport(ByVal ReportSettingsPath As String)
        Try
            Dim mailProcess As New Process()
            Dim processInfo As New System.Diagnostics.ProcessStartInfo()
            Dim txtDataID As String
            Dim txtFileToAttach As String
            Dim arrFileToAttach(0) As String
            Dim arrPicsToAttach(0) As String
            Dim txtExportFrom As String
            Dim txtExportTo As String
            Dim txtExportCC As String
            Dim txtExportBC As String
            Dim txtExportSubject As String
            Dim txtExportMessage As String
            Dim txtPrinterName As String
            Dim intPrinterCopies As Integer
            Dim booPrinterLandscape As Boolean
            Dim booPrinterCollate As Boolean
            Dim booDisableExportEmail As Boolean
            Dim intIndex As Integer
            Dim Split1() As String
            Dim intDest As Integer
            Dim SplitHTMName() As String
            Dim SplitHTMPath() As String
            Dim SplitPicPath() As String
            Dim strMatchName As String
            Dim booHTMLEmail As Boolean
            Dim arrExportedNames(0) As String
            Dim intExportNamesCounter As Integer
            Dim txtAttachPath As String
            Dim txtID As String
            Dim txtPriorLabel As String
            Dim strExportDirectory(0) As String
            'Dim strPaperSource As String


            txtDataID = ""
            txtFileToAttach = ""
            ReDim arrFileToAttach(0)
            arrFileToAttach(0) = ""
            txtExportFrom = ""
            txtExportTo = ""
            txtExportCC = ""
            txtExportBC = ""
            txtExportSubject = ""
            txtExportMessage = ""
            txtPrinterName = ""
            intPrinterCopies = 1
            booPrinterLandscape = True
            booPrinterCollate = False
            booHTMLEmail = False
            intIndex = 0
            intDest = 0


            If FileExists(ReportSettingsPath) = True Then
                ReportSettingsInfo = ReportSettingsPath

                decryptfile(ReportSettingsPath)
                Dim objReader1 As New System.IO.StreamReader(ReportSettingsPath)

                txtPriorLabel = ToolStripStatusLabel2.Text
                ToolStripStatusLabel2.Text = "Exporting Report"
                Do
                    txtDataID = objReader1.ReadLine()
                    Select Case txtDataID
                        Case "SOURCEREPORT"
                            strSourceReportName = txtDataID
                        Case "EXPORTDIRECTORY"
                            strExportDirectory(UBound(strExportDirectory)) = objReader1.ReadLine()
                            strExportDirectory(UBound(strExportDirectory)) = fncFindDynamicValue(strExportDirectory(UBound(strExportDirectory)))
                            strExportDirectory(UBound(strExportDirectory)) = fncFindDynamicText(strExportDirectory(UBound(strExportDirectory)), True, ReportSettingsPath)
                            strExportDirectory(UBound(strExportDirectory)) = fncFixExportName(strExportDirectory(UBound(strExportDirectory)))
                            ReDim Preserve strExportDirectory(UBound(strExportDirectory) + 1)

                    End Select
                Loop Until objReader1.EndOfStream
                objReader1.Close()
                encryptfile(ReportSettingsPath)

                ReDim Preserve strExportDirectory(UBound(strExportDirectory) - 1)
                ReDim Preserve arrExportedNames(UBound(strExportDirectory))

                crxReportToExport = fncReportSource()
                intExportNamesCounter = 0
                For intIndex = 0 To UBound(strExportDirectory)

                    Select Case UCase(RightString(strExportDirectory(intIndex), 3))
                        Case "PDF"
                            crxReportToExport.ExportToDisk(ExportFormatType.PortableDocFormat, strExportDirectory(intIndex))
                            arrExportedNames(intIndex) = strExportDirectory(intIndex)
                        Case "XLS"
                            crxReportToExport.ExportToDisk(ExportFormatType.Excel, strExportDirectory(intIndex))
                            arrExportedNames(intIndex) = strExportDirectory(intIndex)

                        Case "LY)"
                            Dim strDataOnlyArray() As String = Split(strExportDirectory(intIndex), "(Record Only)", 2)
                            strDataOnlyArray(0) = Trim(strDataOnlyArray(0))
                            crxReportToExport.ExportToDisk(ExportFormatType.ExcelRecord, strDataOnlyArray(0))
                            arrExportedNames(intIndex) = strDataOnlyArray(0)


                        Case "RPT"
                            crxReportToExport.ExportToDisk(ExportFormatType.CrystalReport, strExportDirectory(intIndex))
                            arrExportedNames(intIndex) = strExportDirectory(intIndex)

                        Case "HTM"
                            crxReportToExport.ExportToDisk(ExportFormatType.HTML40, strExportDirectory(intIndex))
                            arrExportedNames(intIndex) = strExportDirectory(intIndex)

                            'FixHTMExport(strExportDirectory(intIndex))
                        Case "RTF"
                            crxReportToExport.ExportToDisk(ExportFormatType.RichText, strExportDirectory(intIndex))
                            arrExportedNames(intIndex) = strExportDirectory(intIndex)

                        Case "TXT"
                            Dim OutRTF As String
                            Do
                                OutRTF = GetRandomNumber(1, 10000) & ".rtf"
                            Loop Until FileExists(OutRTF) = False
                            OutRTF = App_Path() & OutRTF
                            crxReportToExport.ExportToDisk(ExportFormatType.RichText, OutRTF)
                            ConvertRtfToText(OutRTF, strExportDirectory(intIndex))
                            arrExportedNames(intIndex) = strExportDirectory(intIndex)

                        Case "DOC"
                            crxReportToExport.ExportToDisk(ExportFormatType.WordForWindows, strExportDirectory(intIndex))
                            arrExportedNames(intIndex) = strExportDirectory(intIndex)

                        Case "CSV"
                            Dim OutXLS As String
                            Do
                                OutXLS = GetRandomNumber(1, 10000) & ".xls"
                            Loop Until FileExists(OutXLS) = False
                            OutXLS = App_Path() & OutXLS
                            crxReportToExport.ExportToDisk(ExportFormatType.ExcelRecord, OutXLS)
                            ExcelToCSV(OutXLS, strExportDirectory(intIndex))
                            arrExportedNames(intIndex) = strExportDirectory(intIndex)


                    End Select
                Next intIndex


                decryptfile(ReportSettingsPath)
                Dim objReader As New System.IO.StreamReader(ReportSettingsPath)

                Do

                    txtDataID = objReader.ReadLine()
                    Select Case txtDataID
                        Case "EXPORTPRINTER"
                            txtPrinterName = fncFindDynamicText(fncFindDynamicValue(objReader.ReadLine), False, ReportSettingsPath)
                            txtID = Path.GetFileName(ReportSettingsPath)
                            intPrinterCopies = CInt(objReader.ReadLine)
                            If objReader.ReadLine = "Landscape" Then
                                booPrinterLandscape = True
                            Else
                                booPrinterLandscape = False
                            End If

                            If objReader.ReadLine = "No" Then
                                booPrinterCollate = False
                            Else
                                booPrinterCollate = True
                            End If

                            If intPrinterCopies > 0 Then
                                PrintReport(txtID, txtPrinterName, booPrinterLandscape, intPrinterCopies, booPrinterCollate)
                            End If

                        Case "EXPORTDIRECTORY"
                            txtFileToAttach = objReader.ReadLine
                            If objReader.ReadLine = True Then
                                txtFileToAttach = arrExportedNames(intExportNamesCounter)
                                If InStr(txtFileToAttach, ".htm", CompareMethod.Text) > 0 Then
                                    booHTMLEmail = True
                                    strBody = ""
                                    Dim strHTML As String
                                    Dim objReadHTML As New System.IO.StreamReader(txtFileToAttach)

                                    SplitHTMPath = Split(txtFileToAttach, ".htm", -1, CompareMethod.Text)
                                    SplitHTMName = Split(SplitHTMPath(0), "\", -1, CompareMethod.Text)
                                    strMatchName = SplitHTMName(UBound(SplitHTMName))
                                    SplitHTMPath = Split(txtFileToAttach, strMatchName, -1, CompareMethod.Text)
                                    Dim intImageCounter As Integer
                                    intImageCounter = 0
                                    Do
                                        strHTML = objReadHTML.ReadLine
                                        If InStr(strHTML, "img src=", CompareMethod.Text) Then
                                            SplitPicPath = Split(strHTML, "img src=" & quote, -1, CompareMethod.Text)
                                            SplitPicPath = Split(SplitPicPath(1), quote, -1, CompareMethod.Text)
                                            arrPicsToAttach(UBound(arrPicsToAttach)) = SplitHTMPath(0) & SplitPicPath(0)

                                            ReDim Preserve arrPicsToAttach(UBound(arrPicsToAttach) + 1)
                                            strBody = strBody & Replace(strHTML, quote & SplitPicPath(0) & quote, "cid:Image" & intImageCounter) & vbCrLf
                                            intImageCounter = intImageCounter + 1
                                        Else
                                            strBody = strBody & strHTML & vbCrLf
                                        End If
                                    Loop Until objReadHTML.EndOfStream
                                    objReadHTML.Close()
                                Else

                                    arrFileToAttach(UBound(arrFileToAttach)) = txtFileToAttach
                                    ReDim Preserve arrFileToAttach(UBound(arrFileToAttach) + 1)
                                End If
                            End If
                            intExportNamesCounter = intExportNamesCounter + 1
                        Case "DISABLEEXPORTEMAIL"
                            booDisableExportEmail = fncFindDynamicText(fncFindDynamicValue(objReader.ReadLine), True, ReportSettingsPath)
                        Case "EXPORTEMAILFROM"
                            txtExportFrom = fncFindDynamicText(fncFindDynamicValue(objReader.ReadLine), True, ReportSettingsPath)
                        Case "EXPORTEMAILTO"
                            txtExportTo = fncFindDynamicText(fncFindDynamicValue(objReader.ReadLine), True, ReportSettingsPath)
                        Case "EXPORTEMAILCC"
                            txtExportCC = fncFindDynamicText(fncFindDynamicValue(objReader.ReadLine), True, ReportSettingsPath)
                        Case "EXPORTEMAILBC"
                            txtExportBC = fncFindDynamicText(fncFindDynamicValue(objReader.ReadLine), True, ReportSettingsPath)
                        Case "EXPORTEMAILSUBJECT"
                            txtExportSubject = fncFindDynamicText(fncFindDynamicValue(objReader.ReadLine), True, ReportSettingsPath)
                        Case "EXPORTEMAILMESSAGE"
                            txtExportMessage = ""
                            Dim strReadText As String
                            Do
                                strReadText = objReader.ReadLine
                                If strReadText <> "CDENDOFRTF" Then
                                    strReadText = fncFindDynamicText(fncFindDynamicValue(strReadText), True, ReportSettingsPath)
                                    txtExportMessage = txtExportMessage & strReadText & vbCr & vbLf
                                End If
                            Loop Until strReadText = "CDENDOFRTF" Or objReader.EndOfStream
                    End Select
                Loop Until objReader.EndOfStream
                objReader.Close()
                ReDim Preserve arrFileToAttach(UBound(arrFileToAttach) - 1)
                ReDim Preserve arrPicsToAttach(UBound(arrPicsToAttach) - 1)

                If booDisableExportEmail = False And txtExportFrom <> "" And (txtExportTo <> "" Or txtExportCC <> "" Or txtExportBC <> "") And txtSMTP.Text <> "" And txtSMTP.Text <> "Enter SMTP Server" Then
                    Dim mailMessage As New MailMessage
                    Dim fromAddress As New MailAddress(txtExportFrom)
                    With mailMessage
                        .From = fromAddress
                        .BodyEncoding = System.Text.Encoding.Default
                        .Subject = txtExportSubject
                        .Priority = MailPriority.Normal
                        .IsBodyHtml = booHTMLEmail
                        If booHTMLEmail = False Then
                            .Body = txtExportMessage
                        Else

                            If strBody = "" Then
                                strBody = txtExportMessage
                            End If
                            Dim plainView As AlternateView = AlternateView.CreateAlternateViewFromString(txtExportMessage, Nothing, "text/plain")

                            Dim htmlView As AlternateView = AlternateView.CreateAlternateViewFromString(strBody, Nothing, "text/html")
                            Dim intArrIndex As Integer
                            Dim HTMLPics(UBound(arrPicsToAttach)) As LinkedResource
                            For intArrIndex = 0 To UBound(arrPicsToAttach)
                                HTMLPics(intArrIndex) = New LinkedResource(arrPicsToAttach(intArrIndex))
                                HTMLPics(intArrIndex).ContentId = "Image" & intArrIndex
                                htmlView.LinkedResources.Add(HTMLPics(intArrIndex))
                            Next
                            mailMessage.AlternateViews.Add(plainView)
                            mailMessage.AlternateViews.Add(htmlView)
                        End If

                        If txtExportTo <> "" Then
                            Split1 = Split(txtExportTo, ";", -1, CompareMethod.Text)
                            For intDest = 0 To UBound(Split1)
                                .To.Add(Split1(intDest))
                            Next intDest
                        End If
                        If txtExportCC <> "" Then
                            Split1 = Split(txtExportCC, ";", -1, CompareMethod.Text)
                            For intDest = 0 To UBound(Split1)
                                .CC.Add(Split1(intDest))
                            Next intDest
                        End If
                        If txtExportBC <> "" Then
                            Split1 = Split(txtExportBC, ";", -1, CompareMethod.Text)
                            For intDest = 0 To UBound(Split1)
                                .Bcc.Add(Split1(intDest))
                            Next intDest
                        End If
                        For intIndex = 0 To UBound(arrFileToAttach)
                            If arrFileToAttach(intIndex) <> "" Then
                                If FileExists(arrFileToAttach(intIndex)) = True Then
                                    txtAttachPath = GetWorkingFolder() & Path.GetFileName(arrFileToAttach(intIndex))
                                    FileCopy(arrFileToAttach(intIndex), txtAttachPath)
                                    .Attachments.Add(New Attachment(txtAttachPath))


                                End If
                            End If
                        Next intIndex

                        Dim smtpMail As New SmtpClient
                        smtpMail.DeliveryMethod = Net.Mail.SmtpDeliveryMethod.Network

                        If txtSMTP.Text <> "" And txtSMTP.Text <> "Enter SMTP Server" Then
                            smtpMail.Host = txtSMTP.Text

                        End If

                        If txtUserID.Text <> "" And txtUserID.Text <> "Enter User ID" And txtUserPassword.Text <> "" And txtUserPassword.Text <> "Enter User ID" Then
                            smtpMail.Credentials = New System.Net.NetworkCredential(txtUserID.Text, txtUserPassword.Text)

                        End If

                        Try


                            smtpMail.Send(mailMessage)
                            mailMessage.Dispose()


                        Catch ex As Exception
                            ErrorWriter(ex.Message.ToString)
                        End Try
                        mailMessage = Nothing
                        smtpMail = Nothing
                    End With
                End If
                encryptfile(ReportSettingsPath)

                ToolStripStatusLabel2.Text = txtPriorLabel
            End If

            Timer2.Enabled = False

        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try
    End Sub


    Private Sub tsbView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbView.Click
        Try
            ViewReport()
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try
    End Sub

    Private Sub ViewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewToolStripMenuItem.Click
        Try
            ViewReport()
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try
    End Sub

    Private Sub ViewReport()
        Try
            Dim crxReportToView As New ReportDocument
            Dim intRowIndex As Integer
            Dim objReader As System.IO.StreamReader
            Dim booHasBatch As Boolean = False
            Dim objBatchParameter As Object = ""
            Dim intIndex As Integer
            Dim crParameterFieldDefinitions As ParameterFieldDefinitions
            Dim crParameterFieldLocation As ParameterFieldDefinition
            Dim crParameterValues As ParameterValues
            Dim crParameterDiscreteValue As ParameterDiscreteValue
            Dim txtRead As String
            Dim arrBatchParameter(0) As String
            Dim intArrIndex As Integer
            Dim myViewer As New frmReportViewer
            Dim strWorkingFile As String
            Dim strBatchFile As String

            Me.Cursor = Cursors.WaitCursor

            For intRowIndex = 0 To dgvScheduleList.RowCount - 1
                booHasBatch = False
                If dgvScheduleList(0, intRowIndex).Selected Then
                    glbActiveID = dgvScheduleList.Item(glbID, intRowIndex).Value
                    strWorkingFile = GetWorkingFile()
                    'xxxxxxxx()
                    'If FileExists(App_Path() & "ScheduledReports\" & glbActiveID & "CDF") = False Then
                    FileCopy(App_Path() & "ScheduledReports\" & glbActiveID, strWorkingFile)
                    'End If
                    decryptfile(strWorkingFile)
                    objReader = New StreamReader(strWorkingFile)
                    Do
                        txtRead = objReader.ReadLine
                        If UCase((txtRead)) = "[BATCH]" Then
                            booHasBatch = True
                            Exit Do
                        Else
                            objBatchParameter = txtRead
                        End If
                    Loop Until objReader.EndOfStream
                    objReader.Close()
                    encryptfile(strWorkingFile)
                    ReportSettingsInfo = strWorkingFile

                    If booHasBatch = False Then
                        myViewer = New frmReportViewer
                        myViewer.Show()
                    Else

                        crxReportToView = fncReportSource()
                        crParameterFieldDefinitions = crxReportToView.DataDefinition.ParameterFields
                        crParameterFieldLocation = crParameterFieldDefinitions.Item(objBatchParameter)
                        crParameterValues = crParameterFieldLocation.DefaultValues
                        ReDim arrBatchParameter(crParameterValues.Count - 1)

                        For intIndex = 0 To crParameterValues.Count - 1
                            crParameterDiscreteValue = crParameterValues.Item(intIndex)
                            arrBatchParameter(intIndex) = crParameterDiscreteValue.Value
                        Next intIndex
                        crxReportToView.Close()

                        For intArrIndex = 0 To UBound(arrBatchParameter)
                            strBatchFile = GetWorkingFile()
                            decryptfile(strWorkingFile)
                            decryptfile(strBatchFile)
                            CreateTempBatchFile("[BATCH]", arrBatchParameter(intArrIndex), strWorkingFile, strBatchFile)
                            encryptfile(strBatchFile)
                            encryptfile(strWorkingFile)
                            ReportSettingsInfo = strBatchFile
                            'crxReportToView = fncReportSource()



                            myViewer = New frmReportViewer
                            myViewer.Show()
                        Next intArrIndex
                    End If
                End If
            Next
            'If FileExists(App_Path() & "ScheduledReports\" & glbActiveID & "CDF") Then
            'Kill(App_Path() & "ScheduledReports\" & glbActiveID & "CDF")
            'End If
            crxReportToView.Close()
            Me.Cursor = Cursors.Default
            KillTemp()

        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try
    End Sub

    Public Function SourceReport(ByVal ReportSettingsInfo As String) As String
        Try
            Dim objReaderSource As New System.IO.StreamReader(ReportSettingsInfo)
            Dim objReader As New System.IO.StreamReader(ReportSettingsInfo)
            SourceReport = ""
            Do
                If objReaderSource.ReadLine() = "SOURCEREPORT" Then
                    SourceReport = objReaderSource.ReadLine()
                    Exit Do
                End If
            Loop Until objReaderSource.EndOfStream
            objReaderSource.Close()
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
            SourceReport = ""
            'return false
        End Try
    End Function

    Private Sub tsbPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbPrint.Click
        Try
            Dim intRowIndex As Integer
            tsbPrint.Enabled = False
            tsmPrint.Enabled = False
            If PrintDialog1.ShowDialog() <> Windows.Forms.DialogResult.Cancel Then
                For intRowIndex = 0 To dgvScheduleList.RowCount - 1
                    If dgvScheduleList(0, intRowIndex).Selected Then
                        PrintReport(dgvScheduleList.Item(glbID, intRowIndex).Value, PrintDialog1.PrinterSettings.PrinterName, PrintDialog1.PrinterSettings.DefaultPageSettings.Landscape, PrintDialog1.PrinterSettings.Copies, PrintDialog1.PrinterSettings.Collate)
                    End If
                Next intRowIndex
            End If
            tsbPrint.Enabled = True
            tsmPrint.Enabled = True
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try
    End Sub


    Private Sub PrintReport(ByVal txtID As String, ByVal strPrinterName As String, ByVal booLandscape As Boolean, ByVal intCopies As Integer, ByVal booCollate As Boolean)
        Try
            Dim crxReportToPrint As New ReportDocument
            'Dim intRowIndex As Integer
            Dim objReader As System.IO.StreamReader
            Dim booHasBatch As Boolean = False
            Dim objBatchParameter As Object = ""
            Dim intIndex As Integer
            Dim crParameterFieldDefinitions As ParameterFieldDefinitions
            Dim crParameterFieldLocation As ParameterFieldDefinition
            Dim crParameterValues As ParameterValues
            Dim crParameterDiscreteValue As ParameterDiscreteValue
            Dim txtRead As String
            Dim arrBatchParameter(0) As String
            Dim intArrIndex As Integer
            Dim strWorkingFile As String
            Dim strBatchFile As String

            Me.Cursor = Cursors.WaitCursor

            'For intRowIndex = 0 To dgvScheduleList.RowCount - 1
            booHasBatch = False
            'If dgvScheduleList(0, intRowIndex).Selected Then
            glbActiveID = txtID 'dgvScheduleList.Item(glbID, intRowIndex).Value
            strWorkingFile = GetWorkingFile()
            'xxxxxxxx()
            'If FileExists(App_Path() & "ScheduledReports\" & glbActiveID & "CDF") = False Then
            FileCopy(App_Path() & "ScheduledReports\" & glbActiveID, strWorkingFile)
            'End If
            decryptfile(strWorkingFile)
            objReader = New StreamReader(strWorkingFile)
            Do
                txtRead = objReader.ReadLine
                If UCase((txtRead)) = "[BATCH]" Then
                    booHasBatch = True
                    Exit Do
                Else
                    objBatchParameter = txtRead
                End If
            Loop Until objReader.EndOfStream
            objReader.Close()
            encryptfile(strWorkingFile)
            ReportSettingsInfo = strWorkingFile

            If booHasBatch = False Then
                crxReportToPrint = fncReportSource()
                crxReportToPrint.PrintOptions.PrinterName = strPrinterName

                If booLandscape = True Then
                    crxReportToPrint.PrintOptions.PaperOrientation = PaperOrientation.Landscape
                Else
                    crxReportToPrint.PrintOptions.PaperOrientation = PaperOrientation.Portrait
                End If

                crxReportToPrint.PrintToPrinter(intCopies, booCollate, 0, 0)
                crxReportToPrint.Close()

            Else

                crxReportToPrint = fncReportSource()
                crParameterFieldDefinitions = crxReportToPrint.DataDefinition.ParameterFields
                crParameterFieldLocation = crParameterFieldDefinitions.Item(objBatchParameter)
                crParameterValues = crParameterFieldLocation.DefaultValues
                ReDim arrBatchParameter(crParameterValues.Count - 1)

                For intIndex = 0 To crParameterValues.Count - 1
                    crParameterDiscreteValue = crParameterValues.Item(intIndex)
                    arrBatchParameter(intIndex) = crParameterDiscreteValue.Value
                Next intIndex
                '''''''''crxReportToPrint = Nothing
                crxReportToPrint.Close()

                For intArrIndex = 0 To UBound(arrBatchParameter)


                    strBatchFile = GetWorkingFile()
                    decryptfile(strWorkingFile)
                    decryptfile(strBatchFile)
                    CreateTempBatchFile("[BATCH]", arrBatchParameter(intArrIndex), strWorkingFile, strBatchFile)
                    encryptfile(strBatchFile)
                    encryptfile(strWorkingFile)
                    ReportSettingsInfo = strBatchFile


                    crxReportToPrint = New ReportDocument
                    crxReportToPrint = fncReportSource()
                    crxReportToPrint.PrintOptions.PrinterName = strPrinterName 'PrintDialog1.PrinterSettings.PrinterName

                    If booLandscape = True Then 'PrintDialog1.PrinterSettings.DefaultPageSettings.Landscape = True Then
                        crxReportToPrint.PrintOptions.PaperOrientation = PaperOrientation.Landscape
                    Else
                        crxReportToPrint.PrintOptions.PaperOrientation = PaperOrientation.Portrait
                    End If


                    crxReportToPrint.PrintToPrinter(intCopies, booCollate, 0, 0)
                    crxReportToPrint.Close()
                Next intArrIndex
            End If
            crxReportToPrint.Close()
            Me.Cursor = Cursors.Default
            KillTemp()

        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try
    End Sub


    Private Sub tsbAutoDeliver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbAutoDeliver.Click
        Try
            AutoDeliver()
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try
    End Sub

    Private Sub AutoDeliver()
        Try
            Dim datTimeEnd As Date
            Dim datTimeStart As Date
            Dim intSeconds As Integer

            If booAutoDeliver = True Then
                booAutoDeliver = False
                NotifyIcon1.Icon = Icon.FromHandle(CType(ImageList1.Images(3), Bitmap).GetHicon())
                tsbAutoDeliver.Image = ImageList1.Images(1)
                tsmAutoDeliver.Image = ImageList1.Images(3)
                AutoToolStripMenuItem.Image = ImageList1.Images(3)
                DeliveryModeToolStripMenuItem.Image = ImageList1.Images(3)
                NotifyIcon1.BalloonTipText = "Manual Mode"
                ToolStripStatusLabel2.Text = "Manual Mode"
                ToolStripStatusLabel2.BackColor = Color.RosyBrown
                Timer1.Enabled = False
            Else
                booAutoDeliver = True
                NotifyIcon1.Icon = Icon.FromHandle(CType(ImageList1.Images(2), Bitmap).GetHicon())
                tsbAutoDeliver.Image = ImageList1.Images(0)
                tsmAutoDeliver.Image = ImageList1.Images(2)
                AutoToolStripMenuItem.Image = ImageList1.Images(2)
                DeliveryModeToolStripMenuItem.Image = ImageList1.Images(2)
                NotifyIcon1.BalloonTipText = "Auto Mode"
                ToolStripStatusLabel2.Text = "Auto Mode"
                ToolStripStatusLabel2.BackColor = Color.OliveDrab
                Me.Refresh()
                datTimeStart = Now()
                intSeconds = Second(datTimeStart)
                datTimeStart = DateAdd(DateInterval.Second, -intSeconds, datTimeStart)
                CheckExports(datTimeStart)
                Me.Refresh()
                datTimeEnd = Now()
                intExportIntervalCounter = Math.Round(DateDiff(DateInterval.Second, datTimeStart, datTimeEnd))
                intExportIntervalCounter = intExportIntervalCounter + 1 'Correct for 1 second delay until first timer count
                booInProcessOfExporting = False
                Timer1.Enabled = True
            End If
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Try
            Dim datTimeEnd As Date
            Dim datTimeStart As Date
            Dim intSeconds As Integer


            If intExportIntervalCounter >= 60 Then
                SaveReportsList()
                If booInProcessOfExporting = False Then
                    datTimeStart = Now()
                    intSeconds = Second(datTimeStart)
                    datTimeStart = DateAdd(DateInterval.Second, -intSeconds, datTimeStart)
                    CheckExports(datTimeStart)
                    datTimeEnd = Now()
                    intSeconds = Second(datTimeEnd)
                    datTimeEnd = DateAdd(DateInterval.Second, -intSeconds, datTimeEnd)
                    intExportIntervalCounter = Math.Round(DateDiff(DateInterval.Second, datTimeStart, datTimeEnd))
                End If
            Else
                intExportIntervalCounter = intExportIntervalCounter + 1
            End If
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try
    End Sub

    Private Sub CheckExports(ByVal datCurrentDate As Date)
        Dim intRowIndex As Integer
        Dim strExportIntervalType As String
        Dim strExportIntervalValue As String
        Dim datExportTimeStart As Date
        Dim datExportTimeEnd As Date
        Dim booExportTimeCheck As Boolean
        Dim txtDataID As String
        Dim objReader As System.IO.StreamReader
        Dim strFilename As String
        Dim booCheckWeekday As Boolean
        Dim booCheckTime As Boolean
        Dim booCheckHistory As Boolean
        Dim booCheckAlerts As Boolean
        Dim strDayOfWeek As String
        Dim datDate As Date
        Dim booHasBatch As Boolean = False
        Dim objBatchParameter As Object = ""
        Dim txtRead As String
        Dim intArrIndex As Integer
        Dim strCheckSource As String = ""
        Dim strSourceReport As String = ""
        Dim strBatchParameter As String = ""
        Dim strWorkingFile As String
        Dim strBatchFile As String

        Try
            booInProcessOfExporting = True
            For intRowIndex = 0 To dgvScheduleList.RowCount - 1
                ToolStripStatusLabel2.Text = "Checking Report #" & intRowIndex + 1
                booHasBatch = False
                strExportIntervalType = ""
                strExportIntervalValue = ""
                strDayOfWeek = ""
                strFilename = App_Path() & "ScheduledReports\" & dgvScheduleList.Item(glbID, intRowIndex).Value ' strActiveID
                glbActiveID = dgvScheduleList.Item(glbID, intRowIndex).Value

                If FileExists(strFilename) = True Then
                    decryptfile(strFilename)
                    objReader = New StreamReader(strFilename)
                    Do
                        txtDataID = (objReader.ReadLine)

                        Select Case txtDataID
                            Case "SOURCEREPORT"
                                strCheckSource = (objReader.ReadLine)
                            Case "EXPORTINTERVALTYPE"
                                strExportIntervalType = (objReader.ReadLine)
                            Case "EXPORTINTERVALVALUE"
                                strExportIntervalValue = (objReader.ReadLine)
                            Case "EXPORTTIMESTART"
                                datExportTimeStart = Format((objReader.ReadLine), "Long Time")
                            Case "EXPORTTIMEEND"
                                datExportTimeEnd = Format((objReader.ReadLine), "Long Time")
                            Case "EXPORTTIMECHECK"
                                booExportTimeCheck = (objReader.ReadLine)
                        End Select
                    Loop Until objReader.EndOfStream
                    objReader.Close()
                    encryptfile(strFilename)

                    If strExportIntervalType <> "Do Not Export" Then
                        Select Case Weekday(Now)
                            Case 1
                                strDayOfWeek = "Sunday"
                            Case 2
                                strDayOfWeek = "Monday"
                            Case 3
                                strDayOfWeek = "Tuesday"
                            Case 4
                                strDayOfWeek = "Wednesday"
                            Case 5
                                strDayOfWeek = "Thursday"
                            Case 6
                                strDayOfWeek = "Friday"
                            Case 7
                                strDayOfWeek = "Saturday"
                        End Select

                        ToolStripStatusLabel2.Text = "Week Day Check"
                        If InStr(dgvScheduleList.Item(glbExportDays, intRowIndex).Value, strDayOfWeek, CompareMethod.Text) Then
                            booCheckWeekday = True
                        Else
                            booCheckWeekday = False
                        End If


                        ToolStripStatusLabel2.Text = "Time Check"
                        If booExportTimeCheck = False Then
                            booCheckTime = True
                        Else
                            If datExportTimeEnd > datExportTimeStart Then
                                If (TimeOfDay() > datExportTimeStart) And (TimeOfDay() < datExportTimeEnd) Then
                                    booCheckTime = True
                                Else
                                    booCheckTime = False
                                End If
                            Else
                                If ((TimeOfDay() > datExportTimeStart) And (TimeOfDay() < #12:00:00 AM#)) Or ((TimeOfDay() < datExportTimeEnd) And (TimeOfDay() > #12:00:00 AM#)) Then
                                    booCheckTime = True
                                Else
                                    booCheckTime = False
                                End If
                            End If
                        End If

                        booCheckHistory = False
                        ToolStripStatusLabel2.Text = "Run History Check"
                        If CStr(dgvScheduleList.Item(glbRunHistory, intRowIndex).Value) <> "" Then
                            datDate = CDate(dgvScheduleList.Item(glbRunHistory, intRowIndex).Value)

                            Select Case strExportIntervalType
                                Case "Do Not Export"
                                    booCheckHistory = False
                                Case "Forced Export"
                                    booCheckHistory = True
                                    booCheckWeekday = True
                                    booCheckTime = True
                                Case "Minutes"
                                    If DateDiff(DateInterval.Minute, dgvScheduleList.Item(glbRunHistory, intRowIndex).Value, datCurrentDate, FirstDayOfWeek.System, FirstWeekOfYear.System) >= strExportIntervalValue Then
                                        booCheckHistory = True
                                    End If
                                Case "Hours"
                                    If DateDiff(DateInterval.Hour, dgvScheduleList.Item(glbRunHistory, intRowIndex).Value, datCurrentDate, FirstDayOfWeek.System, FirstWeekOfYear.System) >= strExportIntervalValue Then
                                        booCheckHistory = True
                                    End If

                                Case "Days"
                                    If DateDiff(DateInterval.Day, dgvScheduleList.Item(glbRunHistory, intRowIndex).Value, datCurrentDate, FirstDayOfWeek.System, FirstWeekOfYear.System) >= strExportIntervalValue Then
                                        booCheckHistory = True
                                    End If
                                Case "Weeks"
                                    If DateDiff(DateInterval.WeekOfYear, dgvScheduleList.Item(glbRunHistory, intRowIndex).Value, datCurrentDate, FirstDayOfWeek.System, FirstWeekOfYear.System) >= strExportIntervalValue Then
                                        booCheckHistory = True
                                    End If
                                Case "Months"
                                    If DateDiff(DateInterval.Month, dgvScheduleList.Item(glbRunHistory, intRowIndex).Value, datCurrentDate, FirstDayOfWeek.System, FirstWeekOfYear.System) >= strExportIntervalValue Then
                                        booCheckHistory = True
                                    End If
                                Case "Quarters"
                                    If DateDiff(DateInterval.Quarter, dgvScheduleList.Item(glbRunHistory, intRowIndex).Value, datCurrentDate, FirstDayOfWeek.System, FirstWeekOfYear.System) >= strExportIntervalValue Then
                                        booCheckHistory = True
                                    End If
                                Case "Years"
                                    If DateDiff(DateInterval.Year, dgvScheduleList.Item(glbRunHistory, intRowIndex).Value, datCurrentDate, FirstDayOfWeek.System, FirstWeekOfYear.System) >= strExportIntervalValue Then
                                        booCheckHistory = True
                                    End If
                                Case "Specific Day of Month"
                                    If strExportIntervalValue = "First Day" Then
                                        strExportIntervalValue = "1"
                                    ElseIf strExportIntervalValue = "Last Day" Then
                                        Dim datNewDate As Date
                                        datNewDate = CDate(Now.Month & " 01 " & Now.Year)
                                        datNewDate = DateAdd(DateInterval.Month, 1, datNewDate)
                                        datNewDate = DateAdd(DateInterval.Day, -1, datNewDate)
                                        strExportIntervalValue = datNewDate.Day
                                    End If
                                    If (CInt(Now.Day) = CInt(strExportIntervalValue)) And (datDate.Date <> Now.Date) Then
                                        booCheckHistory = True
                                    End If
                                Case "Reoccurring Dates"
                                    If (datDate.Date <> Now.Date) Then
                                        If InStr(strExportIntervalValue, Format(Now, "M").ToString, CompareMethod.Text) Then
                                            booCheckHistory = True
                                        End If
                                    End If
                                Case "Excluding Dates"
                                    If (datDate.Date <> Now.Date) Then
                                        If InStr(strExportIntervalValue, Format(Now, "M").ToString, CompareMethod.Text) = 0 Then
                                            booCheckHistory = True
                                        End If
                                    End If
                                Case "First"
                                    If (datDate.Date <> Now.Date) Then
                                        If Now.Day <= 7 Then
                                            booCheckHistory = True
                                        End If
                                    End If
                                Case "Second"
                                    If (datDate.Date <> Now.Date) Then
                                        If (Now.Day > 7) And (Now.Day <= 14) Then
                                            booCheckHistory = True
                                        End If
                                    End If
                                Case "Third"
                                    If (datDate.Date <> Now.Date) Then
                                        If (Now.Day > 14) And (Now.Day <= 21) Then
                                            booCheckHistory = True
                                        End If
                                    End If
                                Case "Fourth"
                                    If (datDate.Date <> Now.Date) Then
                                        If (Now.Day > 21) And (Now.Day <= 28) Then
                                            booCheckHistory = True
                                        End If
                                    End If
                                Case "Last"
                                    If (datDate.Date <> Now.Date) Then
                                        datDate = CDate(Now.Month & " 01 " & Now.Year)
                                        datDate = DateAdd(DateInterval.Month, 1, datDate)
                                        datDate = DateAdd(DateInterval.Day, -1, datDate)
                                        If (datDate.Day - Now.Day) < 7 Then
                                            booCheckHistory = True
                                        End If
                                    End If
                            End Select
                        Else
                            booCheckHistory = True
                        End If

                        ToolStripStatusLabel2.Text = "Report Alerts Check"
                        booCheckAlerts = True ' fncCheckAlerts(strFilename, strCheckSource, intRowIndex, booCheckWeekday, booCheckTime, booCheckHistory)
                        If (booCheckWeekday = True) And (booCheckTime = True) And (booCheckHistory = True) Then

                            strWorkingFile = GetWorkingFile()
                            FileCopy(App_Path() & "ScheduledReports\" & dgvScheduleList.Item(glbID, intRowIndex).Value, strWorkingFile)
                            decryptfile(strWorkingFile)
                            objReader = New StreamReader(strWorkingFile) 'App_Path() & "ScheduledReports\" & dgvScheduleList.Item(glbID, intRowIndex).Value.ToString & "CDF")
                            Do
                                txtRead = objReader.ReadLine
                                Select Case UCase(txtRead)
                                    Case "SOURCEREPORT"
                                        strSourceReport = objReader.ReadLine
                                    Case "[BATCH]"
                                        booHasBatch = True
                                        Exit Select
                                    Case Else
                                        strBatchParameter = txtRead
                                End Select
                            Loop Until booHasBatch = True Or objReader.EndOfStream
                            objReader.Close()
                            encryptfile(strWorkingFile)

                            If booHasBatch = False Then
                                ExportReport(strWorkingFile)
                                dgvScheduleList.Item(glbRunHistory, intRowIndex).Value = datCurrentDate
                                SaveReportsList()
                            Else
                                GetBatchValues(strBatchParameter)

                                For intArrIndex = 0 To UBound(arrBatchParameter)
                                    strBatchFile = GetWorkingFile()

                                    'REPLACE BATCH with values in temp file
                                    decryptfile(strWorkingFile)
                                    decryptfile(strBatchFile)
                                    CreateTempBatchFile("[BATCH]", arrBatchParameter(intArrIndex), strWorkingFile, strBatchFile)
                                    encryptfile(strBatchFile)
                                    encryptfile(strWorkingFile)
                                    ExportReport(strBatchFile)
                                    dgvScheduleList.Item(glbRunHistory, intRowIndex).Value = datCurrentDate
                                    ToolStripProgressBar1.Value = 0
                                    SaveReportsList()




                                Next intArrIndex
                            End If
                        Else
                            'If (booCheckWeekday = True) And (booCheckTime = True) And (booCheckHistory = True) And (booCheckAlerts = False) Then
                            '    dgvScheduleList.Item(glbRunHistory, intRowIndex).Value = datCurrentDate
                            'End If
                        End If
                    End If
                End If
            Next
            ToolStripStatusLabel2.Text = "Auto Mode"
            Me.Refresh()
            'KillTemp()

            booInProcessOfExporting = False
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
            booInProcessOfExporting = False
        End Try
    End Sub


    Private Sub ScheduleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ScheduleToolStripMenuItem.Click
        Try
            SelectReport()
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyToolStripMenuItem.Click
        Try
            CopyReport()
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        Try
            DeleteIDFiles()
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try
    End Sub

    Private Sub AutoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AutoToolStripMenuItem.Click
        Try
            AutoDeliver()
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try
    End Sub

    Private Sub SendToTrayToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SendToTrayToolStripMenuItem.Click
        Try
            SendToTray()
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try
    End Sub

    Private Sub SendToTray()
        Try
            Me.Hide()
            NotifyIcon1.Visible = True
            Me.NotifyIcon1.ContextMenuStrip = Me.ContextMenuStrip3
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try
    End Sub

    Private Function DeliveryStatus() As String
        Try
            Return NotifyIcon1.BalloonTipText
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
            Return False
        End Try
    End Function

    Private Sub NotifyIcon1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon1.MouseMove
        Try
            NotifyIcon1.Text = DeliveryStatus()
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Try
            exiting = True
            Application.Exit()
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try
    End Sub



    Private Sub tsmExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmExit.Click
        Try
            NotifyIcon1.Visible = False
            Application.Exit()
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try
    End Sub


    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        Try
            frmAbout.Show()
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try
    End Sub

    Private Sub txtSMTP_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            If txtSMTP.Text = "" Or txtSMTP.Text = "Enter SMTP Server" Then
                txtSMTP.Text = "Enter SMTP Server"
                txtSMTP.ForeColor = Color.DarkGray
            Else
                txtSMTP.ForeColor = Color.Black
            End If
            SaveUserSettings()
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try
    End Sub


    Private Sub ContentsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContentsToolStripMenuItem.Click
        Try
            Help.ShowHelp(Me, Application.StartupPath & "\CrystalDelivery.chm")
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try
    End Sub


    Private Sub RemoveCurrentKey(ByVal name As String)
        Try
            Dim key As RegistryKey = Registry.LocalMachine.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Run", True)
            key.DeleteValue(name, False)
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try
    End Sub

    Private Sub AddCurrentKey(ByVal name As String, ByVal path As String)
        Try
            Dim key As RegistryKey = Registry.LocalMachine.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Run", True)
            key.SetValue(name, path)
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try
    End Sub

    Private Sub tscbStartWithWindows_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            If tsmStartWithWindows.Checked = True Then
                AddCurrentKey("CrystalDelivery", System.Reflection.Assembly.GetEntryAssembly.Location)
            Else
                RemoveCurrentKey("CrystalDelivery")
            End If
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try
    End Sub

    Private Sub tsmSchedule_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmSchedule.Click
        Try
            SelectReport()
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try
    End Sub

    Private Sub tsmCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmCopy.Click
        Try
            CopyReport()
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try
    End Sub

    Private Sub tsmDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmDelete.Click
        Try
            DeleteIDFiles()
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try
    End Sub

    Private Sub tsmExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmExport.Click
        Try
            Dim intRowIndex As Integer
            Dim datTimeStart As Date
            Dim intSeconds As Integer
            tsbExport.Enabled = False
            tsmExport.Enabled = False
            datTimeStart = Now()
            intSeconds = Second(datTimeStart)
            datTimeStart = DateAdd(DateInterval.Second, -intSeconds, datTimeStart)

            For intRowIndex = 0 To dgvScheduleList.RowCount - 1
                If dgvScheduleList(0, intRowIndex).Selected Then
                    ForcedExport(intRowIndex)
                    dgvScheduleList.Item(glbRunHistory, intRowIndex).Value = datTimeStart 'Format(datTimeStart, "M/d/yyyy hh:mm tt") 'datTimeStart
                End If
            Next intRowIndex
            tsbExport.Enabled = True
            tsmExport.Enabled = True
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try
    End Sub

    Private Sub tsmView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmView.Click
        Try
            ViewReport()
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try
    End Sub

    Private Sub PrintToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripMenuItem.Click
        Try
            Dim intRowIndex As Integer
            If PrintDialog1.ShowDialog() <> Windows.Forms.DialogResult.Cancel Then
                For intRowIndex = 0 To dgvScheduleList.RowCount - 1
                    If dgvScheduleList(0, intRowIndex).Selected Then
                        PrintReport(dgvScheduleList.Item(glbID, intRowIndex).Value, PrintDialog1.PrinterSettings.PrinterName, PrintDialog1.PrinterSettings.DefaultPageSettings.Landscape, PrintDialog1.PrinterSettings.Copies, PrintDialog1.PrinterSettings.Collate)
                    End If
                Next intRowIndex
            End If
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try
    End Sub

    Private Sub tsmPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmPrint.Click
        Try
            Dim intRowIndex As Integer
            tsbPrint.Enabled = False
            tsmPrint.Enabled = False

            If PrintDialog1.ShowDialog() <> Windows.Forms.DialogResult.Cancel Then
                For intRowIndex = 0 To dgvScheduleList.RowCount - 1
                    If dgvScheduleList(0, intRowIndex).Selected Then
                        PrintReport(dgvScheduleList.Item(glbID, intRowIndex).Value, PrintDialog1.PrinterSettings.PrinterName, PrintDialog1.PrinterSettings.DefaultPageSettings.Landscape, PrintDialog1.PrinterSettings.Copies, PrintDialog1.PrinterSettings.Collate)
                    End If
                Next intRowIndex
            End If
            tsbPrint.Enabled = True
            tsmPrint.Enabled = True
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try
    End Sub


    Private Sub tsmLangPack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmLangPack.Click
        Try
            If tsmLangPack.Checked = True Then
                LoadLangPack()
            End If
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try
    End Sub

    Private Sub tsbToTray_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbToTray.Click
        Try
            SendToTray()
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try
    End Sub

    Private Sub SendToTrayToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SendToTrayToolStripMenuItem1.Click
        Try
            SendToTray()
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try
    End Sub

    Private Sub DeliveryModeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeliveryModeToolStripMenuItem.Click
        Try
            AutoDeliver()
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        Try
            If ToolStripProgressBar1.Value = 100 Then
                ToolStripProgressBar1.Value = 0
            End If
            ToolStripProgressBar1.PerformStep()
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try
    End Sub


    Private Sub tsmScheduleBTN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmScheduleBTN.Click
        Try
            tsbSchedule.Visible = tsmScheduleBTN.Checked
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try
    End Sub


    Private Sub tsmHideAllButtons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmHideAllButtons.Click
        Try
            ToolStrip1.Visible = Not tsmHideAllButtons.Checked
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try
    End Sub

    Private Sub tsmCopyBTN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmCopyBTN.Click
        Try
            tsbCopy.Visible = tsmCopyBTN.Checked
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try
    End Sub

    Private Sub tsmDeleteBTN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmDeleteBTN.Click
        Try
            tsbDelete.Visible = tsmDeleteBTN.Checked
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try
    End Sub

    Private Sub tsmExportBTN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmExportBTN.Click
        Try
            tsbExport.Visible = tsmExportBTN.Checked
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try
    End Sub

    Private Sub tsmViewBTN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmViewBTN.Click
        Try
            tsbView.Visible = tsmViewBTN.Checked
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try
    End Sub

    Private Sub tsmPrintBTN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmPrintBTN.Click
        Try
            tsbPrint.Visible = tsmPrintBTN.Checked
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try
    End Sub

    Private Sub tsmToTrayBTN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmToTrayBTN.Click
        Try
            tsbToTray.Visible = tsmToTrayBTN.Checked
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try
    End Sub

    Private Sub tsmDeliveryModeBTN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmAutoDeliverBTN.Click
        Try
            tsbAutoDeliver.Visible = tsmAutoDeliverBTN.Checked
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try
    End Sub


    Private Sub RestoreToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RestoreToolStripMenuItem.Click
        Try
            FolderBrowserDialog1.Description = "Select Folder That Contains Files to Restore"
            If FolderBrowserDialog1.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
                My.Computer.FileSystem.CopyDirectory(FolderBrowserDialog1.SelectedPath, App_Path() & "ScheduledReports", True)
            End If
            dgvScheduleList.Rows.Clear()
            ReadReportsList()
            ReadUserSettings()
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try
    End Sub


    Private Sub BackupToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BackupToolStripMenuItem.Click
        Try
            FolderBrowserDialog1.Description = "Select Folder to Create Backup Files"
            If FolderBrowserDialog1.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
                My.Computer.FileSystem.CopyDirectory(App_Path() & "ScheduledReports", FolderBrowserDialog1.SelectedPath, True)
            End If
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try
    End Sub


    Private Sub txtUserID_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUserID.LostFocus
        Try
            If txtUserID.Text = "" Or txtUserID.Text = "Enter User ID" Then
                txtUserID.Text = "Enter User ID"
                txtUserID.ForeColor = Color.DarkGray
            Else
                txtUserID.ForeColor = Color.Black
            End If
            SaveUserSettings()
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try
    End Sub


    Private Sub txtUserPassword_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUserPassword.LostFocus
        Try
            If txtUserPassword.Text = "" Or txtUserPassword.Text = "Enter Password" Then
                txtUserPassword.Text = "Enter Password"
                txtUserPassword.ForeColor = Color.DarkGray
            Else
                txtUserPassword.ForeColor = Color.Black
            End If
            SaveUserSettings()
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try
    End Sub

    Public Function GetDefaultSystemPrinter() As String
        Try
            Dim pdPrintDoc As New PrintDocument
            Return pdPrintDoc.PrinterSettings.PrinterName
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
            Return False
        End Try
    End Function

    Public Function SetDefaultSystemPrinter(ByVal strPrinterName As String) As Boolean

        Dim strCurrentPrinter As String = ""
        Dim wscPrinterScript As Object
        Dim pdPrintDoc As New PrintDocument

        Try
            strCurrentPrinter = pdPrintDoc.PrinterSettings.PrinterName
            wscPrinterScript = Microsoft.VisualBasic.CreateObject("WScript.Network")
            wscPrinterScript.SetDefaultPrinter(strPrinterName)

            pdPrintDoc.PrinterSettings.PrinterName = strPrinterName

            If pdPrintDoc.PrinterSettings.IsValid Then
                Return True
            Else
                wscPrinterScript.SetDefaultPrinter(strCurrentPrinter)
                'return false
            End If
        Catch ex As Exception
            wscPrinterScript.SetDefaultPrinter(strCurrentPrinter)
            ErrorWriter(ex.Message.ToString)
            'return false
        Finally
            wscPrinterScript = Nothing
            pdPrintDoc = Nothing
        End Try
    End Function

    Public Function GetWorkingFile() As String
        Try
            Do
                GetWorkingFile = App_Path() & "ScheduledReports\" & CStr(Path.GetFileNameWithoutExtension(Path.GetRandomFileName)) & ".tmp"
            Loop Until FileExists(GetWorkingFile) = False ' FileExists(App_Path() & "ScheduledReports\" & CStr(dblRandomNumber) & ".tmp") = False
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
            GetWorkingFile = ""
        End Try
    End Function

    Public Function GetWorkingFolder() As String '(ByVal strCurrentFile As String) As String
        Try
            Do
                GetWorkingFolder = App_Path() & "ScheduledReports\temp\" & CStr(Path.GetFileNameWithoutExtension(Path.GetRandomFileName)) & "\"
            Loop Until FolderExists(GetWorkingFolder) = False ' FolderExists(App_Path() & "ScheduledReports\temp\" & CStr(Path.GetFileNameWithoutExtension(Path.GetRandomFileName)) & "\") = False
            System.IO.Directory.CreateDirectory(GetWorkingFolder) ' App_Path() & "ScheduledReports\temp\" & CStr(Path.GetFileNameWithoutExtension(Path.GetRandomFileName)) & "\")
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
            GetWorkingFolder = ""
        End Try
    End Function



    Private Sub txtSMTP_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSMTP.LostFocus
        Try
            If txtSMTP.Text = "" Or txtSMTP.Text = "Enter SMTP Server" Then
                txtSMTP.Text = "Enter SMTP Server"
                txtSMTP.ForeColor = Color.DarkGray
            Else
                txtSMTP.ForeColor = Color.Black
            End If
            SaveUserSettings()
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try
    End Sub


    Public Sub SetWatchFolder()
        Try
            watchfolder = Nothing
            If txtTriggerFolder.Text <> "No Trigger Folder Selected" Then
                If FolderExists(txtTriggerFolder.Text) = False Then
                    System.IO.Directory.CreateDirectory(txtTriggerFolder.Text)
                End If

                watchfolder = New System.IO.FileSystemWatcher()

                'this is the path we want to monitor
                watchfolder.Path = (txtTriggerFolder.Text)

                'Add a list of Filter we want to specify
                'make sure you use OR for each Filter as we need to
                'all of those 

                watchfolder.NotifyFilter = IO.NotifyFilters.DirectoryName
                watchfolder.NotifyFilter = watchfolder.NotifyFilter Or IO.NotifyFilters.FileName
                watchfolder.NotifyFilter = watchfolder.NotifyFilter Or IO.NotifyFilters.Attributes


                ' add the handler to each event
                'AddHandler watchfolder.Changed, AddressOf logchange
                AddHandler watchfolder.Created, AddressOf logchange
                'AddHandler watchfolder.Deleted, AddressOf logchange


                ' add the rename handler as the signature is different
                'AddHandler watchfolder.Renamed, AddressOf logrename

                'Set this property to true to start watching
                watchfolder.EnableRaisingEvents = True
                CheckCurrentFolder()
            End If
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try
    End Sub

    Private Sub logchange(ByVal source As Object, ByVal e As System.IO.FileSystemEventArgs)
        Try

            If e.ChangeType = IO.WatcherChangeTypes.Created Then
                Dim strFileName As String
                Dim strReportName As String = ""
                Dim intReportNumber As Integer = -1
                Dim strFileExtension As String
                Dim intRowIndex As Integer
                Dim intindex As Integer
                Dim strTriggerName() As String
                Dim datTimeStart As Date
                Dim strCheckSource As String = ""
                Dim txtDataID = ""
                Dim booAllowRemote As Boolean = False
                Dim objReader As System.IO.StreamReader
                Dim intSeconds As Integer

                strTriggerName = Split(e.Name, ".", -1)

                For intindex = 0 To UBound(strTriggerName) - 1
                    If intindex < UBound(strTriggerName) - 1 Then
                        strReportName = strReportName & strTriggerName(intindex) & "."
                    Else
                        strReportName = strReportName & strTriggerName(intindex)
                    End If
                Next intindex

                If IsNumeric(strReportName) Then
                    intReportNumber = strReportName
                    intReportNumber = intReportNumber - 1
                End If

                strFileExtension = strTriggerName(UBound(strTriggerName))
                Select Case UCase(strFileExtension)

                    Case "TGR"
                        For intRowIndex = 0 To dgvScheduleList.RowCount - 1
                            If UCase(strReportName) = UCase(dgvScheduleList.Item(glbReportName, intRowIndex).Value) Or intReportNumber = intRowIndex Then
                                datTimeStart = Now()
                                intSeconds = Second(datTimeStart)
                                datTimeStart = DateAdd(DateInterval.Second, -intSeconds, datTimeStart)

                                strFileName = App_Path() & "ScheduledReports\" & dgvScheduleList.Item(glbID, intRowIndex).Value ' strActiveID
                                If FileExists(strFileName) = True Then
                                    objReader = New StreamReader(strFileName)
                                    Do
                                        txtDataID = (objReader.ReadLine)
                                        Select Case txtDataID
                                            Case "SOURCEREPORT"
                                                strCheckSource = (objReader.ReadLine)
                                            Case "ALLOWREMOTE"
                                                booAllowRemote = (objReader.ReadLine)
                                        End Select
                                    Loop Until objReader.EndOfStream
                                    objReader.Close()
                                    If booAllowRemote = True Then
                                        If FileExists(strCheckSource) = True Then
                                            ForcedExport(intRowIndex)
                                            dgvScheduleList.Item(glbRunHistory, intRowIndex).Value = datTimeStart 'Format(datTimeStart, "M/d/yyyy hh:mm tt") 'datTimeStart
                                            ToolStripProgressBar1.Value = 0
                                        End If
                                    End If
                                End If
                            End If
                        Next
                    Case "RRL"
                        SaveTriggersList()
                        Dim mailMessage As New MailMessage
                        Dim Split1() As String
                        Dim intDest As Integer
                        Dim txtTriggerEmailTo As String

                        objReader = New StreamReader(e.FullPath)
                        txtTriggerEmailTo = (objReader.ReadLine)
                        objReader.Close()
                        Split1 = Split(txtTriggerEmailTo, ";", -1, CompareMethod.Text)
                        Dim fromAddress As New MailAddress(Split1(intDest))

                        With mailMessage
                            .From = fromAddress
                            .BodyEncoding = System.Text.Encoding.Default
                            .Subject = "Reports Lists"
                            .Priority = MailPriority.Normal
                            .IsBodyHtml = False
                            .Body = "Attached is a list of reports allowing remote exports"
                            .Attachments.Add(New Attachment(App_Path() & "TriggerList.txt"))
                            For intDest = 0 To UBound(Split1)
                                .To.Add(Split1(intDest))
                            Next intDest

                            Dim smtpMail As New SmtpClient
                            smtpMail.DeliveryMethod = Net.Mail.SmtpDeliveryMethod.Network
                            If txtSMTP.Text <> "" And txtSMTP.Text <> "Enter SMTP Server" Then
                                smtpMail.Host = txtSMTP.Text
                            End If

                            If txtUserID.Text <> "" And txtUserID.Text <> "Enter User ID" And txtUserPassword.Text <> "" And txtUserPassword.Text <> "Enter User ID" Then
                                smtpMail.Credentials = New System.Net.NetworkCredential(txtUserID.Text, txtUserPassword.Text)
                            End If

                            Try
                                smtpMail.Send(mailMessage)
                            Catch ex As Exception
                                ErrorWriter(ex.Message.ToString)
                            End Try
                            mailMessage = Nothing
                            smtpMail = Nothing
                        End With
                End Select

            End If
            Kill(e.FullPath)
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try
    End Sub



    Private Sub SelectTriggerFolderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectTriggerFolderToolStripMenuItem.Click
        Try
            FolderBrowserDialog1.Description = "Select Folder to Monitor for Trigger Files"
            If FolderBrowserDialog1.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
                txtTriggerFolder.Text = FolderBrowserDialog1.SelectedPath
                SetWatchFolder()
            End If
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try
    End Sub

    Private Sub ClearTriggerFolderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearTriggerFolderToolStripMenuItem.Click
        txtTriggerFolder.Text = "No Trigger Folder Selected"
    End Sub

    Private Sub SaveTriggersList()
        Try
            Dim strFileName As String
            Dim strReportName As String = ""
            Dim intReportNumber As Integer = -1
            Dim intRowIndex As Integer
            Dim strCheckSource As String = ""
            Dim txtDataID = ""
            Dim booAllowRemote As Boolean = False
            Dim objReader As System.IO.StreamReader
            Dim objWriter As New System.IO.StreamWriter(App_Path() & "TriggerList.txt")

            If dgvScheduleList.RowCount > 0 Then
                objWriter.Write("The following reports allow remote exports:" & vbCrLf & vbCrLf)
                For intRowIndex = 0 To dgvScheduleList.RowCount - 1
                    strFileName = App_Path() & "ScheduledReports\" & dgvScheduleList.Item(glbID, intRowIndex).Value ' strActiveID
                    If FileExists(strFileName) = True Then
                        booAllowRemote = False
                        objReader = New StreamReader(strFileName)
                        Do
                            txtDataID = (objReader.ReadLine)
                            Select Case txtDataID
                                Case "ALLOWREMOTE"
                                    booAllowRemote = (objReader.ReadLine)
                                    Exit Do
                            End Select
                        Loop Until objReader.EndOfStream
                        objReader.Close()

                        If booAllowRemote = True Then
                            objWriter.Write("Report Number" & vbCrLf)
                            objWriter.Write(intRowIndex + 1 & vbCrLf)
                            objWriter.Write("Report Name" & vbCrLf)
                            objWriter.Write(dgvScheduleList.Item(glbReportName, intRowIndex).Value & vbCrLf)
                        End If
                    End If

                Next
            Else
                objWriter.Write("There are no reports currently scheduled." & vbCrLf)
            End If
            objWriter.Close()

        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try
    End Sub

    Sub CheckCurrentFolder()
        Dim di As New IO.DirectoryInfo(txtTriggerFolder.Text)
        Dim aryTGRFiles As IO.FileInfo() = di.GetFiles("*.tgr")
        Dim aryRRLFiles As IO.FileInfo() = di.GetFiles("*.rrl")
        Dim intIndex As Integer
        Dim intIndexTGR As Integer
        Dim strFileName As String
        Dim strReportName As String = ""
        Dim intReportNumber As Integer = -1
        Dim strFileExtension As String = ""
        Dim intRowIndex As Integer
        Dim strTriggerName() As String
        Dim datTimeStart As Date
        Dim strCheckSource As String = ""
        Dim txtDataID = ""
        Dim booAllowRemote As Boolean = False
        Dim objReader As System.IO.StreamReader
        Dim intSeconds As Integer



        For intIndex = 0 To UBound(aryTGRFiles)
            strTriggerName = Split(aryTGRFiles(intIndex).Name, ".", -1)

            For intIndexTGR = 0 To UBound(strTriggerName) - 1
                If intIndexTGR < UBound(strTriggerName) - 1 Then
                    strReportName = strReportName & strTriggerName(intIndexTGR) & "."
                Else
                    strReportName = strReportName & strTriggerName(intIndexTGR)
                End If
            Next intIndexTGR

            If IsNumeric(strReportName) Then
                intReportNumber = strReportName
                intReportNumber = intReportNumber - 1
            End If
            For intRowIndex = 0 To dgvScheduleList.RowCount - 1
                If strReportName = dgvScheduleList.Item(glbReportName, intRowIndex).Value Or intReportNumber = intRowIndex Then
                    datTimeStart = Now()
                    intSeconds = Second(datTimeStart)
                    datTimeStart = DateAdd(DateInterval.Second, -intSeconds, datTimeStart)
                    strFileName = App_Path() & "ScheduledReports\" & dgvScheduleList.Item(glbID, intRowIndex).Value ' strActiveID
                    If FileExists(strFileName) = True Then
                        objReader = New StreamReader(strFileName)
                        Do
                            txtDataID = (objReader.ReadLine)
                            Select Case txtDataID
                                Case "SOURCEREPORT"
                                    strCheckSource = (objReader.ReadLine)
                                Case "ALLOWREMOTE"
                                    booAllowRemote = (objReader.ReadLine)
                            End Select
                        Loop Until objReader.EndOfStream
                        objReader.Close()
                        If booAllowRemote = True Then
                            If FileExists(strCheckSource) = True Then
                                ForcedExport(intRowIndex)
                                dgvScheduleList.Item(glbRunHistory, intRowIndex).Value = datTimeStart 'Format(datTimeStart, "M/d/yyyy hh:mm tt") 'datTimeStart
                                ToolStripProgressBar1.Value = 0
                            End If
                        End If
                    End If
                End If
            Next


            Kill(aryTGRFiles(intIndex).FullName)

        Next

        SaveTriggersList()
        For intIndex = 0 To UBound(aryRRLFiles)
            Dim mailMessage As New MailMessage
            Dim Split1() As String
            Dim intDest As Integer
            Dim txtTriggerEmailTo As String

            objReader = New StreamReader(aryRRLFiles(intIndex).FullName)
            txtTriggerEmailTo = (objReader.ReadLine)
            objReader.Close()
            Split1 = Split(txtTriggerEmailTo, ";", -1, CompareMethod.Text)
            Dim fromAddress As New MailAddress(Split1(intDest))

            With mailMessage
                .From = fromAddress
                .BodyEncoding = System.Text.Encoding.Default
                .Subject = "Reports Lists"
                .Priority = MailPriority.Normal
                .IsBodyHtml = False
                .Body = "Attached is a list of reports allowing remote exports"
                .Attachments.Add(New Attachment(App_Path() & "TriggerList.txt"))
                For intDest = 0 To UBound(Split1)
                    .To.Add(Split1(intDest))
                Next intDest

                Dim smtpMail As New SmtpClient
                smtpMail.DeliveryMethod = Net.Mail.SmtpDeliveryMethod.Network
                If txtSMTP.Text <> "" And txtSMTP.Text <> "Enter SMTP Server" Then
                    smtpMail.Host = txtSMTP.Text
                End If

                If txtUserID.Text <> "" And txtUserID.Text <> "Enter User ID" And txtUserPassword.Text <> "" And txtUserPassword.Text <> "Enter User ID" Then
                    smtpMail.Credentials = New System.Net.NetworkCredential(txtUserID.Text, txtUserPassword.Text)
                End If

                Try
                    smtpMail.Send(mailMessage)
                Catch ex As Exception
                    ErrorWriter(ex.Message.ToString)
                End Try
                mailMessage = Nothing
                smtpMail = Nothing
            End With
            Kill(aryRRLFiles(intIndex).FullName)

        Next

    End Sub


    Private Sub ReplaceStringToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReplaceStringToolStripMenuItem.Click
        glbNumberOfReports = dgvScheduleList.RowCount
        Dim MyFormObject As New frmReplace
        MyFormObject.ShowDialog()
        ReadReportsList()
    End Sub


    Sub GetBatchValues(ByVal strParameterName As String)
        Try
            Dim intIndex As Integer
            Dim crParameterFieldDefinitions As ParameterFieldDefinitions
            Dim crParameterFieldLocation As ParameterFieldDefinition ' ParameterFieldDefinition
            Dim crParameterValues As ParameterValues 'ParameterValues
            Dim crParameterDiscreteValue As ParameterDiscreteValue
            Dim crxReport As New ReportDocument

            crParameterFieldDefinitions = crxReport.DataDefinition.ParameterFields
            crParameterFieldLocation = crParameterFieldDefinitions.Item(strParameterName)
            crParameterValues = crParameterFieldLocation.DefaultValues

            ReDim arrBatchParameter(crParameterValues.Count - 1)

            For intIndex = 0 To crParameterValues.Count - 1
                crParameterDiscreteValue = crParameterValues.Item(intIndex)
                arrBatchParameter(intIndex) = crParameterDiscreteValue.Value
            Next intIndex
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try
    End Sub

    Sub ExcelToCSV(ByVal SourceXLS As String, ByVal CSVPath As String)
        Try

            Dim StrConn As String
            Dim DA As New OleDbDataAdapter
            Dim DS As New DataSet
            Dim Str As String
            Dim ColumnCount As Integer
            Dim OuterCount As Integer
            Dim InnerCount As Integer
            Dim RowCount As Integer


            StrConn = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source= " & SourceXLS & "; Extended Properties=""Excel 8.0;HDR=no;IMEX=1"""
            Dim objConn As New OleDbConnection(StrConn)
            objConn.Open()

            Dim objCmd As New OleDbCommand("Select * from [Sheet1$]", objConn)
            objCmd.CommandType = CommandType.Text

            Dim ObjStreamWriter As StreamWriter
            ObjStreamWriter = New StreamWriter(CSVPath)

            Dim Count As Integer
            Count = 0
            DA.SelectCommand = objCmd
            DA.Fill(DS, "XLData")
            RowCount = DS.Tables(0).Rows.Count
            ColumnCount = DS.Tables(0).Columns.Count
            Str = ""
            For OuterCount = 0 To RowCount - 1
                For InnerCount = 0 To ColumnCount - 1
                    If DS.Tables(0).Rows(OuterCount).Item(InnerCount).ToString <> "" Then
                        Str &= Trim(DS.Tables(0).Rows(OuterCount).Item(InnerCount).ToString) & ","
                    End If
                Next

            Next
            Str = LeftString(Str, Str.Length - 1)
            ObjStreamWriter.WriteLine(Str)
            ObjStreamWriter.Close()
            objCmd.Dispose()
            objCmd = Nothing
            objConn.Close()
            objConn.Dispose()
            objConn = Nothing
            Kill(SourceXLS)
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try
    End Sub

    Public Sub ConvertRtfToText(ByVal input As String, ByVal output As String)
        Try
            Dim objReader As New System.IO.StreamReader(input)
            Dim strFileContents As String

            strFileContents = objReader.ReadToEnd
            objReader.Close()


            Using converter As New System.Windows.Forms.RichTextBox()

                converter.Rtf = strFileContents
                strFileContents = converter.Text

            End Using

            Dim objWriter As New System.IO.StreamWriter(output)
            objWriter.Write(strFileContents)
            objWriter.Close()
            Kill(input)
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try
    End Sub

    Private Sub ViewLogToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewLogToolStripMenuItem.Click
        ViewLogFile()
    End Sub

    Private Sub ViewLogFile()
        Dim myLogViewer As New frmLogViewer


        Me.Cursor = Cursors.WaitCursor
        myLogViewer = New frmLogViewer
        myLogViewer.Show()
        Me.Cursor = Cursors.Default


    End Sub




    Private Sub tsmAutoDelivery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmAutoDelivery.Click
        Try
            AutoDeliver()
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try
    End Sub

    Private Sub tsmRestorePanel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmRestorePanel.Click
        Try
            NotifyIcon1.Visible = False
            Me.Show()
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try
    End Sub
End Class
