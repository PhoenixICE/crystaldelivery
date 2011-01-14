Imports System.Drawing.Printing
Imports System.IO
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Public Class frmSettings
    Public booHistoryChanged As Boolean = False
    'Public dgvParameterList.CurrentRow.Index As Integer


    Private Sub cmbBrowseFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBrowseFolder.Click
        Try
            SaveFileDialog1.Filter = "Adobe PDF (*.pdf)|*.pdf|Excel (*.xls)|*.xls|Excel (Record Only) (*.xls)|*.xls|Crystal Report (*.rpt)|*.rpt|HTML (*.htm)|*.htm|Text (*.txt)|*.txt|Rich Text (*.rtf)|*.rtf|Word (*.doc)|*.doc|CSV (*.csv)|*.csv"
            SaveFileDialog1.Title = "Select folder and filename"
            If SaveFileDialog1.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
                If SaveFileDialog1.FilterIndex = 3 Or SaveFileDialog1.FilterIndex = 9 Then
                    dgvExportDirectories.Rows.Add(SaveFileDialog1.FileName & " (Record Only)", False)
                Else
                    dgvExportDirectories.Rows.Add(SaveFileDialog1.FileName, False)
                End If
            End If
            ButtonUpdate()
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try

    End Sub



    Private Sub frmSettings_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            SaveReportSettingsFile()
            CleanReportsFolder()
            frmMain.dgvScheduleList.Item(glbReportName, frmMain.dgvScheduleList.CurrentRow.Index).Value = txbDesc.Text
            frmMain.dgvScheduleList.Enabled = True
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try

    End Sub


    Private Sub frmSettings_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Try
            'Resizes the controls when the form resizes
            Me.txbExportFrom.Width = Me.Width * 0.4096
            Me.txbExportTo.Width = Me.Width * 0.4096
            Me.txbExportSubject.Width = Me.Width - 20 - txbExportSubject.Left
            Me.txbExportCC.Width = Me.Width * 0.4096
            Me.txbExportBCC.Width = Me.Width * 0.4096
            Me.txbExportCC.Left = Me.Width - Me.txbExportCC.Width - 20
            Me.txbExportBCC.Left = Me.Width - Me.txbExportBCC.Width - 20
            Me.cmbBCC.Left = Me.txbExportBCC.Left - 52
            Me.cmbCC.Left = Me.txbExportCC.Left - 52

            'Me.tbxSourceReport.Width = Me.Width - 45 - Me.tbxSourceReport.Left
            'txbDesc.Width = tbxSourceReport.Width
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try

    End Sub

    Private Sub frmSettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim NewFileID As String
            NewFileID = Path.GetFileNameWithoutExtension(Path.GetRandomFileName) & ".txt"
            File.Copy(App_Path() & "ScheduledReports\" & glbActiveID, App_Path() & "ScheduledReports\" & NewFileID)
            glbActiveID = NewFileID
            frmMain.dgvScheduleList.Item(glbID, frmMain.dgvScheduleList.CurrentRow.Index).Value = NewFileID
            Timer1.Enabled = True
            Dim pkInstalledPrinters As String
            'Dim datDate As Date
            'Find all printers installed and adds the names to the data grid

            Try
                For Each pkInstalledPrinters In PrinterSettings.InstalledPrinters
                    dgvExportPrinters.Rows.Add(pkInstalledPrinters, 0, "Portrait", "No")
                Next pkInstalledPrinters
                'Import report settings before checking user settings in text file to eliminate duplicate fields

                If FileExists(frmMain.dgvScheduleList.Item(glbSourceReport, frmMain.dgvScheduleList.CurrentRow.Index).Value) = True Then
                    ImportReportParameters()
                    ImportReportConnections()
                End If
                ReadReportSettingsFile()
                'Format(dtmRunHistoryDate.Value.ToString, "Short Date") & " " & Format(dtmRunHistoryTime.Value.ToString, "Long Time")
                'datDate = frmMain.dgvScheduleList.Item(glbRunHistory, frmMain.dgvScheduleList.CurrentRow.Index).Value
                Try
                    If frmMain.dgvScheduleList.Item(glbRunHistory, frmMain.dgvScheduleList.CurrentRow.Index).Value.ToString <> "" Then
                        dtmRunHistoryDate.Value = frmMain.dgvScheduleList.Item(glbRunHistory, frmMain.dgvScheduleList.CurrentRow.Index).Value 'datDate.Date
                        dtmRunHistoryTime.Value = frmMain.dgvScheduleList.Item(glbRunHistory, frmMain.dgvScheduleList.CurrentRow.Index).Value
                    End If
                Catch ex As Exception
                    ErrorWriter(ex.Message.ToString)
                End Try

                txbDesc.Text = frmMain.dgvScheduleList.Item(glbReportName, frmMain.dgvScheduleList.CurrentRow.Index).Value
                IntervalUpdate()
                ButtonUpdate()

                Me.Cursor = Cursors.Default
                Timer1.Enabled = False
                'frmMain.ToolStripProgressBar1.Value = 0
            Catch ex As Exception

            End Try
            CheckSourceFile()
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try

    End Sub

    Private Sub ReadReportSettingsFile()
        Try
            Dim ReportSettingsInfo As String = App_Path() & "ScheduledReports\" & glbActiveID
            Dim txtDataID As String
            'Dim txtMatchSource As String
            Dim txtValue1 As String
            Dim txtValue2 As String
            Dim txtValue3 As String
            Dim txtValue4 As String
            Dim intRowIndex As Integer

            If FileExists(ReportSettingsInfo) = True Then
                decryptfile(App_Path() & "ScheduledReports\" & glbActiveID)
                Dim objReader As New System.IO.StreamReader(ReportSettingsInfo)
                Do
                    txtDataID = objReader.ReadLine()
                    Select Case txtDataID
                        Case "SOURCEREPORT"
                            tbxSourceReport.Text = objReader.ReadLine()
                        Case "ALLOWREMOTE"
                            chbAllowRemote.Checked = objReader.ReadLine()
                        Case "EXPORTINTERVALTYPE"
                            cbxExportInterval.Text = objReader.ReadLine()
                        Case "EXPORTINTERVALVALUE"
                            txtValue1 = objReader.ReadLine()
                            tbxExportIntervalValue.Text = txtValue1
                            cbxWeekdays.Text = txtValue1
                            cbxDayNumbers.Text = txtValue1
                            'Case "CALENDAR"
                            'cbxCalendar.Text = objReader.ReadLine()
                        Case "EXPORTTIMESTART"
                            dtmExportTimeStart.Value = objReader.ReadLine()
                        Case "EXPORTTIMEEND"
                            dtmExportTimeEnd.Value = objReader.ReadLine()
                        Case "EXPORTTIMECHECK"
                            txtValue1 = objReader.ReadLine()
                            dtmExportTimeStart.Checked = txtValue1
                            dtmExportTimeEnd.Checked = txtValue1
                        Case "RUNHISTORYDATE"
                            'dtmRunHistoryDate.Value = objReader.ReadLine()
                        Case "RUNHISTORYTIME"
                            'dtmRunHistoryTime.Value() = objReader.ReadLine()
                        Case "EXPORTDAYS"
                            Select Case objReader.ReadLine()
                                Case "Sunday"
                                    txtValue1 = 0
                                Case "Monday"
                                    txtValue1 = 1
                                Case "Tuesday"
                                    txtValue1 = 2
                                Case "Wednesday"
                                    txtValue1 = 3
                                Case "Thursday"
                                    txtValue1 = 4
                                Case "Friday"
                                    txtValue1 = 5
                                Case "Saturday"
                                    txtValue1 = 6
                                Case Else
                                    txtValue1 = 0
                            End Select
                            lbxExportDays.SetSelected(txtValue1, True)
                        Case "RANGE"
                            'txtValue2 = objReader.ReadLine()
                            txtValue1 = objReader.ReadLine()
                            txtValue2 = objReader.ReadLine()
                            txtValue3 = objReader.ReadLine()
                            For intRowIndex = 0 To (dgvParameterList.Rows.Count - 1)
                                If dgvParameterList.Item(1, intRowIndex).Value() = txtValue1 Then
                                    dgvParameterList.Item(2, intRowIndex).Value() = txtValue2
                                    dgvParameterList.Item(3, intRowIndex).Value() = txtValue3
                                    'dgvParameterList.Item(4, intRowIndex).Value() = objReader.ReadLine()
                                    'dgvParameterList.Item(5, intRowIndex).Value() = objReader.ReadLine()
                                End If
                            Next intRowIndex
                        Case "DISCRETE"
                            'txtValue2 = objReader.ReadLine()
                            txtValue1 = objReader.ReadLine()
                            txtValue2 = objReader.ReadLine()
                            For intRowIndex = 0 To (dgvParameterList.Rows.Count - 1)
                                If dgvParameterList.Item(1, intRowIndex).Value() = txtValue1 Then
                                    If dgvParameterList.Item(2, intRowIndex).Value() = "" Then
                                        dgvParameterList.Item(2, intRowIndex).Value() = txtValue2
                                    Else
                                        dgvParameterList.Item(2, intRowIndex).Value() = dgvParameterList.Item(2, intRowIndex).Value() & ";" & txtValue2
                                    End If
                                    'dgvParameterList.Item(3, intRowIndex).Value() = objReader.ReadLine()
                                End If
                            Next intRowIndex

                        Case "CONNECTION"
                            txtValue1 = objReader.ReadLine()
                            txtValue2 = objReader.ReadLine()
                            txtValue3 = DecryptText(objReader.ReadLine(), glbEKey)
                            txtValue4 = DecryptText(objReader.ReadLine(), glbEKey)

                            For intRowIndex = 0 To (dgvConnections.Rows.Count - 1)
                                If dgvConnections.Item(0, intRowIndex).Value() = txtValue1 And dgvConnections.Item(1, intRowIndex).Value() = txtValue2 Then
                                    'If dgvConnections.Item(2, intRowIndex).Value() = "" Then
                                    dgvConnections.Item(2, intRowIndex).Value() = txtValue3
                                    'Else
                                    'dgvConnections.Item(2, intRowIndex).Value() = dgvConnections.Item(2, intRowIndex).Value() & ";" & txtValue3
                                    ''End If

                                    'If dgvConnections.Item(3, intRowIndex).Value() = "" Then
                                    dgvConnections.Item(3, intRowIndex).Value() = txtValue4
                                    'Else
                                    'dgvConnections.Item(3, intRowIndex).Value() = dgvConnections.Item(3, intRowIndex).Value() & ";" & txtValue4
                                    'End If
                                End If
                            Next intRowIndex

                        Case "EXPORTDIRECTORY"
                            dgvExportDirectories.Rows.Add(objReader.ReadLine(), objReader.ReadLine())
                        Case "EXPORTPRINTER"
                            txtValue1 = objReader.ReadLine()
                            txtValue2 = objReader.ReadLine()
                            txtValue3 = objReader.ReadLine()
                            txtValue4 = objReader.ReadLine()

                            For intRowIndex = 0 To (dgvExportPrinters.Rows.Count - 1)
                                If dgvExportPrinters.Item(0, intRowIndex).Value() = txtValue1 Then
                                    dgvExportPrinters.Item(1, intRowIndex).Value() = txtValue2
                                    dgvExportPrinters.Item(2, intRowIndex).Value() = txtValue3
                                    dgvExportPrinters.Item(3, intRowIndex).Value() = txtValue4
                                End If
                            Next intRowIndex
                        Case "EXPORTEMAILFROM"
                            txbExportFrom.Text = objReader.ReadLine()
                        Case "EXPORTEMAILTO"
                            txbExportTo.Text = objReader.ReadLine()
                        Case "EXPORTEMAILCC"
                            txbExportCC.Text = objReader.ReadLine()
                        Case "EXPORTEMAILBC"
                            txbExportBCC.Text = objReader.ReadLine()
                        Case "EXPORTEMAILSUBJECT"
                            txbExportSubject.Text = objReader.ReadLine()
                        Case "EXPORTEMAILMESSAGE"
                            rtbExportMessage.Text = ""
                            Do
                                rtbExportMessage.Text = rtbExportMessage.Text & objReader.ReadLine() & vbCr & vbLf
                            Loop Until objReader.EndOfStream
                    End Select
                Loop Until objReader.EndOfStream
                objReader.Close()
            End If
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try

    End Sub

    Private Sub ImportReportParameters()
        Try
            Dim crxReport As New ReportDocument()
            Dim strReportName As String
            'Dim crParameterValues As New ParameterValues()
            'Dim crParameterDiscreteValue As New ParameterDiscreteValue()
            'Dim crxSubReport As New ReportDocument()
            Dim intParameter As Integer
            Dim booParameterOnList As Boolean
            Dim intParRow As Integer
            Dim crSections As Sections
            Dim crSection As Section
            Dim crReportObjects As ReportObjects
            Dim crReportObject As ReportObject
            Dim crxSubReport As New ReportDocument()
            Dim crxSubReportObject As CrystalDecisions.CrystalReports.Engine.SubreportObject
            Dim crSubParameterValues As New ParameterValues()
            Dim crSubParameterDiscreteValue As New ParameterDiscreteValue()



            strReportName = frmMain.dgvScheduleList.Item(glbSourceReport, frmMain.dgvScheduleList.CurrentRow.Index).Value
            crxReport.Load(strReportName)

            For intParameter = 0 To crxReport.DataDefinition.ParameterFields.Count - 1
                If crxReport.DataDefinition.ParameterFields.Item(intParameter).ReportName = "" Then
                    booParameterOnList = False
                    intParRow = 1
                    If dgvParameterList.Rows.Count > 0 Then
                        For intParRow = 0 To dgvParameterList.Rows.Count - 1
                            If crxReport.DataDefinition.ParameterFields.Item(intParameter).Name = dgvParameterList.Item(1, intParRow).Value Then 'And dgvParameterList.Item(0, intParRow).Value = "MAIN" Then
                                booParameterOnList = True
                            End If
                        Next intParRow
                    End If
                    If booParameterOnList = False Then
                        dgvParameterList.Rows.Add(crxReport.DataDefinition.ParameterFields.Item(intParameter).DiscreteOrRangeKind, crxReport.DataDefinition.ParameterFields.Item(intParameter).Name)
                        If dgvParameterList.Item(0, dgvParameterList.Rows.Count - 1).Value >= 1 Then
                            dgvParameterList.Item(3, dgvParameterList.Rows.Count - 1).Style.BackColor = Color.WhiteSmoke
                            dgvParameterList.Item(3, dgvParameterList.Rows.Count - 1).ReadOnly = False
                        Else
                            dgvParameterList.Item(3, dgvParameterList.Rows.Count - 1).Style.BackColor = Color.FromArgb(177, 194, 216)
                            dgvParameterList.Item(3, dgvParameterList.Rows.Count - 1).ReadOnly = True
                        End If
                    End If
                End If
            Next intParameter

            crSections = crxReport.ReportDefinition.Sections
            For Each crSection In crSections
                crReportObjects = crSection.ReportObjects
                For Each crReportObject In crReportObjects
                    If crReportObject.Kind = ReportObjectKind.SubreportObject Then


                        crxSubReportObject = CType(crReportObject, SubreportObject)
                        crxSubReport = crxSubReportObject.OpenSubreport(crxSubReportObject.SubreportName)

                        For intParameter = 0 To crxSubReport.DataDefinition.ParameterFields.Count - 1
                            booParameterOnList = False
                            intParRow = 1
                            If dgvParameterList.Rows.Count > 0 Then
                                For intParRow = 0 To dgvParameterList.Rows.Count - 1
                                    If crxSubReport.DataDefinition.ParameterFields.Item(intParameter).Name = dgvParameterList.Item(1, intParRow).Value Then 'And dgvParameterList.Item(0, intParRow).Value = "MAIN" Then
                                        booParameterOnList = True
                                    End If
                                Next intParRow
                            End If
                            If booParameterOnList = False Then
                                dgvParameterList.Rows.Add(crxSubReport.DataDefinition.ParameterFields.Item(intParameter).DiscreteOrRangeKind, crxSubReport.DataDefinition.ParameterFields.Item(intParameter).Name)
                                If dgvParameterList.Item(0, dgvParameterList.Rows.Count - 1).Value >= 1 Then
                                    dgvParameterList.Item(3, dgvParameterList.Rows.Count - 1).Style.BackColor = Color.WhiteSmoke
                                    dgvParameterList.Item(3, dgvParameterList.Rows.Count - 1).ReadOnly = False
                                Else
                                    dgvParameterList.Item(3, dgvParameterList.Rows.Count - 1).Style.BackColor = Color.FromArgb(177, 194, 216)
                                    dgvParameterList.Item(3, dgvParameterList.Rows.Count - 1).ReadOnly = True
                                End If
                            End If
                        Next intParameter
                        crxSubReport.Close()
                    End If
                Next
            Next


            crxReport.Close()
            If dgvParameterList.Rows.Count = 0 Then
                SplitContainer1.Panel1.Enabled = False
            Else
                SplitContainer1.Panel1.Enabled = True
            End If
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try

    End Sub


    Private Sub ImportReportConnections()
        Try
            Dim crxReport As New ReportDocument()
            Dim strReportName As String
            Dim crParameterValues As New ParameterValues()
            Dim crParameterDiscreteValue As New ParameterDiscreteValue()
            Dim crxSubReport As New ReportDocument()
            Dim crxSections As CrystalDecisions.CrystalReports.Engine.Sections
            Dim crxSection As CrystalDecisions.CrystalReports.Engine.Section
            Dim crxReportObjects As CrystalDecisions.CrystalReports.Engine.ReportObjects
            Dim crxSubReportObject As CrystalDecisions.CrystalReports.Engine.SubreportObject
            Dim intSections As Integer
            Dim intReportObjects As Integer
            Dim intTableNumber As Integer

            Dim booTableOnList As Boolean
            Dim intConRow As Integer
            Dim ConInfo As New CrystalDecisions.Shared.TableLogOnInfo

            strReportName = frmMain.dgvScheduleList.Item(glbSourceReport, frmMain.dgvScheduleList.CurrentRow.Index).Value

            intTableNumber = 1
            crxReport.Load(strReportName)

            'For intTableNumber = 0 To crxReport.DataSourceConnections.Count - 1
            'dgvConnections.Rows.Add(crxReport.DataSourceConnections(intTableNumber).DatabaseName, crxReport.DataSourceConnections(intTableNumber).ServerName, crxReport.DataSourceConnections(intTableNumber).UserID, crxReport.DataSourceConnections(intTableNumber).Password)
            'Next

            For intTableNumber = 0 To crxReport.Database.Tables.Count - 1
                booTableOnList = False
                'intConRow = 1
                If dgvConnections.Rows.Count > 0 Then
                    For intConRow = 0 To dgvConnections.Rows.Count - 1
                        If (crxReport.Database.Tables(intTableNumber).LogOnInfo.ConnectionInfo.DatabaseName.ToString = dgvConnections.Item(0, intConRow).Value.ToString) And (crxReport.Database.Tables(intTableNumber).LogOnInfo.ConnectionInfo.ServerName.ToString = dgvConnections.Item(1, intConRow).Value.ToString) Then
                            booTableOnList = True
                        End If
                    Next intConRow
                End If
                If booTableOnList = False Then
                    dgvConnections.Rows.Add(crxReport.Database.Tables(intTableNumber).LogOnInfo.ConnectionInfo.DatabaseName, crxReport.Database.Tables(intTableNumber).LogOnInfo.ConnectionInfo.ServerName, crxReport.Database.Tables(intTableNumber).LogOnInfo.ConnectionInfo.UserID, crxReport.Database.Tables(intTableNumber).LogOnInfo.ConnectionInfo.Password)
                    'dgvConnections.Rows.Add(crxReport.DataSourceConnections(0).DatabaseName, crxReport.DataSourceConnections(0).ServerName, crxReport.DataSourceConnections(0).UserID, crxReport.DataSourceConnections(0).Password)

                    'txbConnectString.Text = crxReport.DataSourceConnections(0)
                End If
            Next intTableNumber

            crxSections = crxReport.ReportDefinition.Sections

            For intSections = 0 To crxSections.Count - 1
                crxSection = crxSections.Item(intSections)
                crxReportObjects = crxSection.ReportObjects
                For intReportObjects = 0 To crxReportObjects.Count - 1
                    If crxReportObjects.Item(intReportObjects).Kind = CrystalDecisions.Shared.ReportObjectKind.SubreportObject Then 'Then
                        crxSubReportObject = crxReportObjects.Item(intReportObjects)
                        crxSubReport = crxSubReportObject.OpenSubreport(crxSubReportObject.SubreportName)
                        intTableNumber = 1
                        If crxSubReport.Database.Tables.Count > 0 Then
                            For intTableNumber = 0 To crxSubReport.Database.Tables.Count - 1
                                booTableOnList = False
                                'intConRow = 1
                                If dgvConnections.Rows.Count > 0 Then
                                    For intConRow = 0 To dgvConnections.Rows.Count - 1
                                        If (crxSubReport.Database.Tables(intTableNumber).LogOnInfo.ConnectionInfo.DatabaseName.ToString = dgvConnections.Item(0, intConRow).Value.ToString) And (crxSubReport.Database.Tables(intTableNumber).LogOnInfo.ConnectionInfo.ServerName.ToString = dgvConnections.Item(1, intConRow).Value.ToString) Then
                                            booTableOnList = True
                                        End If
                                    Next intConRow
                                End If
                                If booTableOnList = False Then
                                    dgvConnections.Rows.Add(crxSubReport.Database.Tables(intTableNumber).LogOnInfo.ConnectionInfo.DatabaseName, crxSubReport.Database.Tables(intTableNumber).LogOnInfo.ConnectionInfo.ServerName, crxSubReport.Database.Tables(intTableNumber).LogOnInfo.ConnectionInfo.UserID, crxSubReport.Database.Tables(intTableNumber).LogOnInfo.ConnectionInfo.Password)
                                End If
                            Next intTableNumber
                        End If
                    End If
                Next intReportObjects

            Next intSections
            ''''''crxReport = Nothing
            crxReport.Close()
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try

    End Sub


    Private Sub SaveReportSettingsFile()
        Try
            Dim ReportSettingsInfo As String = App_Path() & "ScheduledReports\" & glbActiveID
            Dim intIndex As Integer
            Dim strExportDays As String
            Dim objwriter As New System.IO.StreamWriter(ReportSettingsInfo)

            objwriter.Write("SOURCEREPORT" & vbCrLf)
            objwriter.Write(tbxSourceReport.Text & vbCrLf)
            frmMain.dgvScheduleList.Item(glbSourceReport, frmMain.dgvScheduleList.CurrentRow.Index).Value() = tbxSourceReport.Text
            objwriter.Write("ALLOWREMOTE" & vbCrLf)
            objwriter.Write(chbAllowRemote.Checked.ToString & vbCrLf)

            objwriter.Write("EXPORTINTERVALTYPE" & vbCrLf)
            objwriter.Write(cbxExportInterval.Text & vbCrLf)
            objwriter.Write("EXPORTINTERVALVALUE" & vbCrLf)
            Select Case cbxExportInterval.Text
                Case "Specific Day of Month"
                    If cbxDayNumbers.Text = "First Day" Or cbxDayNumbers.Text = "Last Day" Then
                        frmMain.dgvScheduleList.Item(glbExportInterval, frmMain.dgvScheduleList.CurrentRow.Index).Value() = "On the " & LCase(cbxDayNumbers.Text) & " of every month"
                        objwriter.Write(cbxDayNumbers.Text & vbCrLf)
                    Else
                        frmMain.dgvScheduleList.Item(glbExportInterval, frmMain.dgvScheduleList.CurrentRow.Index).Value() = "On day " & cbxDayNumbers.Text & " of every month"
                        objwriter.Write(cbxDayNumbers.Text & vbCrLf)
                    End If
                Case "Reoccurring Dates"
                    frmMain.dgvScheduleList.Item(glbExportInterval, frmMain.dgvScheduleList.CurrentRow.Index).Value() = "Every " & tbxExportIntervalValue.Text
                    objwriter.Write(tbxExportIntervalValue.Text & vbCrLf)
                Case "Excluding Dates"
                    frmMain.dgvScheduleList.Item(glbExportInterval, frmMain.dgvScheduleList.CurrentRow.Index).Value() = "Exclude " & tbxExportIntervalValue.Text
                    objwriter.Write(tbxExportIntervalValue.Text & vbCrLf)
                Case "First", "Second", "Third", "Fourth", "Last"
                    frmMain.dgvScheduleList.Item(glbExportInterval, frmMain.dgvScheduleList.CurrentRow.Index).Value() = "On the " & LCase(cbxExportInterval.Text) & " " & LCase(cbxWeekdays.Text) & " of every month"
                    objwriter.Write(cbxWeekdays.Text & vbCrLf)
                Case "Do Not Export"
                    frmMain.dgvScheduleList.Item(glbExportInterval, frmMain.dgvScheduleList.CurrentRow.Index).Value() = "Do not export this report"
                    objwriter.Write(vbCrLf)
                Case "Forced Export"
                    frmMain.dgvScheduleList.Item(glbExportInterval, frmMain.dgvScheduleList.CurrentRow.Index).Value() = "Force this report to export"
                    objwriter.Write(vbCrLf)
                Case Else
                    If tbxExportIntervalValue.Text = "1" Then
                        frmMain.dgvScheduleList.Item(glbExportInterval, frmMain.dgvScheduleList.CurrentRow.Index).Value() = "Every " & Mid(cbxExportInterval.Text, 1, Len(cbxExportInterval.Text) - 1)
                        objwriter.Write(tbxExportIntervalValue.Text & vbCrLf)
                    Else
                        frmMain.dgvScheduleList.Item(glbExportInterval, frmMain.dgvScheduleList.CurrentRow.Index).Value() = "Every " & tbxExportIntervalValue.Text & " " & cbxExportInterval.Text
                        objwriter.Write(tbxExportIntervalValue.Text & vbCrLf)
                    End If
            End Select

            objwriter.Write("EXPORTTIMESTART" & vbCrLf)
            objwriter.Write(dtmExportTimeStart.Value & vbCrLf)
            objwriter.Write("EXPORTTIMEEND" & vbCrLf)
            objwriter.Write(dtmExportTimeEnd.Value & vbCrLf)
            objwriter.Write("EXPORTTIMECHECK" & vbCrLf)
            If dtmExportTimeStart.Checked = True Or dtmExportTimeEnd.Checked = True Then
                objwriter.Write("True" & vbCrLf)
                frmMain.dgvScheduleList.Item(glbExportTime, frmMain.dgvScheduleList.CurrentRow.Index).Value() = "Between " & dtmExportTimeStart.Value.ToShortTimeString & " and " & dtmExportTimeEnd.Value.ToShortTimeString
            Else
                objwriter.Write("False" & vbCrLf)
                frmMain.dgvScheduleList.Item(glbExportTime, frmMain.dgvScheduleList.CurrentRow.Index).Value() = ""
            End If
            If booHistoryChanged = True Then
                objwriter.Write("RUNHISTORYDATE" & vbCrLf)
                objwriter.Write(dtmRunHistoryDate.Value.ToShortDateString & vbCrLf)
                objwriter.Write("RUNHISTORYTIME" & vbCrLf)
                '"M/d/yyyy H:mm tt"
                objwriter.Write(dtmRunHistoryTime.Value.ToLongTimeString & vbCrLf)
                frmMain.dgvScheduleList.Item(glbRunHistory, frmMain.dgvScheduleList.CurrentRow.Index).Value() = Format(dtmRunHistoryDate.Value.ToShortDateString) & " " & Format(dtmRunHistoryTime.Value.ToLongTimeString)
            End If


            strExportDays = ""
            For intIndex = 0 To lbxExportDays.SelectedIndices.Count - 1
                objwriter.Write("EXPORTDAYS" & vbCrLf)
                objwriter.Write(lbxExportDays.Items(lbxExportDays.SelectedIndices(intIndex)).ToString & vbCrLf)
                strExportDays = strExportDays & ";" & lbxExportDays.Items(lbxExportDays.SelectedIndices(intIndex)).ToString
            Next intIndex
            If strExportDays <> "" Then
                strExportDays = Mid(strExportDays, 2)
            End If
            frmMain.dgvScheduleList.Item(glbExportDays, frmMain.dgvScheduleList.CurrentRow.Index).Value = strExportDays

            If dgvParameterList.Rows.Count > 0 Then
                Dim arrSplit() As String
                Dim arrIndex As Integer
                For intIndex = 0 To dgvParameterList.Rows.Count - 1
                    If dgvParameterList.Item(0, intIndex).Value() = 0 Then
                        arrSplit = Split(dgvParameterList.Item(2, intIndex).Value, ";", -1, CompareMethod.Text)
                        For arrIndex = 0 To UBound(arrSplit)
                            objwriter.Write("DISCRETE" & vbCrLf)
                            objwriter.Write(dgvParameterList.Item(1, intIndex).Value & vbCrLf)
                            objwriter.Write(arrSplit(arrIndex) & vbCrLf)
                            'objwriter.Write(Trim(arrSplit(arrIndex)) & vbCrLf)
                        Next arrIndex

                    ElseIf dgvParameterList.Item(0, intIndex).Value() >= 1 Then
                        objwriter.Write("RANGE" & vbCrLf)
                        objwriter.Write(dgvParameterList.Item(1, intIndex).Value & vbCrLf)
                        objwriter.Write(dgvParameterList.Item(2, intIndex).Value & vbCrLf)
                        objwriter.Write(dgvParameterList.Item(3, intIndex).Value & vbCrLf)
                    End If

                Next intIndex
            End If

            If dgvConnections.Rows.Count > 0 Then
                For intIndex = 0 To dgvConnections.Rows.Count - 1
                    objwriter.Write("CONNECTION" & vbCrLf)
                    objwriter.Write(dgvConnections.Item(0, intIndex).Value & vbCrLf)
                    objwriter.Write(dgvConnections.Item(1, intIndex).Value & vbCrLf)
                    objwriter.Write(EncryptText(dgvConnections.Item(2, intIndex).Value, glbEKey) & vbCrLf)
                    objwriter.Write(EncryptText(dgvConnections.Item(3, intIndex).Value, glbEKey) & vbCrLf)
                Next intIndex
            End If

            If dgvExportDirectories.Rows.Count >= 1 Then
                For intIndex = 0 To dgvExportDirectories.Rows.Count - 1
                    objwriter.Write("EXPORTDIRECTORY" & vbCrLf)
                    objwriter.Write(dgvExportDirectories.Item(0, intIndex).Value & vbCrLf)
                    objwriter.Write(dgvExportDirectories.Item(1, intIndex).Value & vbCrLf)
                Next intIndex
            End If

            If dgvExportPrinters.Rows.Count > 1 Then
                For intIndex = 0 To dgvExportPrinters.Rows.Count - 1
                    objwriter.Write("EXPORTPRINTER" & vbCrLf)
                    objwriter.Write(dgvExportPrinters.Item(0, intIndex).Value & vbCrLf)
                    objwriter.Write(dgvExportPrinters.Item(1, intIndex).Value & vbCrLf)
                    objwriter.Write(dgvExportPrinters.Item(2, intIndex).Value & vbCrLf)
                    objwriter.Write(dgvExportPrinters.Item(3, intIndex).Value & vbCrLf)
                Next intIndex
            End If
            objwriter.Write("EXPORTEMAILFROM" & vbCrLf)
            objwriter.Write(txbExportFrom.Text & vbCrLf)
            objwriter.Write("EXPORTEMAILTO" & vbCrLf)
            objwriter.Write(txbExportTo.Text & vbCrLf)
            objwriter.Write("EXPORTEMAILCC" & vbCrLf)
            objwriter.Write(txbExportCC.Text & vbCrLf)
            objwriter.Write("EXPORTEMAILBC" & vbCrLf)
            objwriter.Write(txbExportBCC.Text & vbCrLf)
            objwriter.Write("EXPORTEMAILSUBJECT" & vbCrLf)
            objwriter.Write(txbExportSubject.Text & vbCrLf)
            objwriter.Write("EXPORTEMAILMESSAGE" & vbCrLf)
            objwriter.Write(rtbExportMessage.Text & vbCrLf)
            'objwriter.Write("CDENDOFRTF" & vbCrLf)
            objwriter.Close()
            encryptfile(App_Path() & "ScheduledReports\" & glbActiveID)
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try

    End Sub


    Private Sub cmbDeleteFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDeleteFolder.Click
        Try
            dgvExportDirectories.Rows.RemoveAt(dgvExportDirectories.CurrentRow.Index)
            dgvExportDirectories.RefreshEdit()
            ButtonUpdate()
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try

    End Sub

    Private Sub ButtonUpdate()
        Try
            If dgvExportDirectories.Rows.Count > 0 Then
                cmbDeleteFolder.Enabled = True
            Else
                cmbDeleteFolder.Enabled = False
            End If
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try

    End Sub


    Private Sub IntervalUpdate()
        Try
            Select Case cbxExportInterval.Text
                Case "Specific Day of Month"
                    cbxDayNumbers.Visible = True
                    cbxWeekdays.Visible = False
                    tbxExportIntervalValue.Visible = False
                    lblValue.Visible = True
                    cmbShowCalendar.Visible = False
                Case "Reoccurring Dates"
                    cbxDayNumbers.Visible = False
                    cbxWeekdays.Visible = False
                    tbxExportIntervalValue.Visible = True
                    lblValue.Visible = True
                    cmbShowCalendar.Visible = True
                Case "Excluding Dates"
                    cbxDayNumbers.Visible = False
                    cbxWeekdays.Visible = False
                    tbxExportIntervalValue.Visible = True
                    lblValue.Visible = True
                    cmbShowCalendar.Visible = True
                Case "First", "Second", "Third", "Fourth", "Last"
                    cbxDayNumbers.Visible = False
                    cbxWeekdays.Visible = True
                    tbxExportIntervalValue.Visible = False
                    lblValue.Visible = True
                    cmbShowCalendar.Visible = False
                Case "Forced Export"
                    cbxDayNumbers.Visible = False
                    cbxWeekdays.Visible = False
                    tbxExportIntervalValue.Visible = False
                    lblValue.Visible = False
                    cmbShowCalendar.Visible = False
                Case "Do Not Export"
                    cbxDayNumbers.Visible = False
                    cbxWeekdays.Visible = False
                    tbxExportIntervalValue.Visible = False
                    lblValue.Visible = False
                    cmbShowCalendar.Visible = False
                Case Else
                    cbxDayNumbers.Visible = False
                    cbxWeekdays.Visible = False
                    tbxExportIntervalValue.Visible = True
                    lblValue.Visible = True
                    cmbShowCalendar.Visible = False
            End Select
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try

    End Sub

    Private Sub dtmExportTimeStart_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dtmExportTimeStart.MouseDown
        Try
            dtmExportTimeEnd.Checked = dtmExportTimeStart.Checked
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try

    End Sub

    Private Sub dtmExportTimeEnd_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dtmExportTimeEnd.MouseDown
        Try
            dtmExportTimeStart.Checked = dtmExportTimeEnd.Checked
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try

    End Sub

    Private Sub cbxExportInterval_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxExportInterval.SelectedIndexChanged
        Try
            cbxDayNumbers.Text = ""
            tbxExportIntervalValue.Text = ""
            cbxWeekdays.Text = ""
            IntervalUpdate()
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try

    End Sub

    Private Sub cmdMtoF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMtoF.Click
        Try
            Dim intIndex As Integer
            lbxExportDays.SetSelected(0, False)
            For intIndex = 1 To 5
                lbxExportDays.SetSelected(intIndex, True)
            Next intIndex
            lbxExportDays.SetSelected(6, False)
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try

    End Sub

    Private Sub cmdAllDays_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAllDays.Click
        Try
            Dim intIndex As Integer
            For intIndex = 0 To 6
                lbxExportDays.SetSelected(intIndex, True)
            Next intIndex
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try

    End Sub

    Private Sub cmdClearDays_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearDays.Click
        Try
            Dim intIndex As Integer
            For intIndex = 0 To 6
                lbxExportDays.SetSelected(intIndex, False)
            Next intIndex
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try

    End Sub

    Private Sub dgvParameterList_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvParameterList.CellClick
        Try
            Dim crxReportP As New ReportDocument()
            Dim intIndex As Integer
            Dim intRowIndex As Integer
            Dim booAddBatch As Boolean
            Dim crParameterDiscreteValue As ParameterDiscreteValue
            Dim crParameterFieldDefinitions As ParameterFieldDefinitions
            Dim crParameterFieldLocation As ParameterFieldDefinition
            Dim crParameterValues As ParameterValues
            'Dim crSections As Sections
            'Dim crSection As Section
            'Dim crReportObjects As ReportObjects
            'Dim crReportObject As ReportObject
            Dim crxSubReport As New ReportDocument()
            'Dim crxSubReportObject As CrystalDecisions.CrystalReports.Engine.SubreportObject

            'Dim crFormulaFieldDefinitions As FormulaFieldDefinitions
            'Dim crFormulaFieldLocation As FormulaFieldDefinition
            booAddBatch = True
            If e.RowIndex >= 0 Then
                If dgvParameterList.Item(0, e.RowIndex).Value >= 1 Then
                    cmbValueEnd.Enabled = True
                    booAddBatch = False
                    dgvParameterList.Item(3, e.RowIndex).Style.SelectionBackColor = Color.Blue
                    dgvParameterList.Item(3, e.RowIndex).Style.SelectionForeColor = Color.White
                Else
                    dgvParameterList.Item(3, e.RowIndex).Style.SelectionBackColor = dgvParameterList.Item(3, e.RowIndex).Style.BackColor
                    dgvParameterList.Item(3, e.RowIndex).Style.SelectionForeColor = dgvParameterList.Item(3, e.RowIndex).Style.ForeColor
                    cmbValueEnd.Enabled = False
                    For intRowIndex = 0 To dgvParameterList.RowCount - 1
                        If UCase(dgvParameterList.Item(2, intRowIndex).Value) = "[BATCH]" And intRowIndex <> e.RowIndex Then
                            booAddBatch = False
                            Exit For
                        End If
                    Next intRowIndex
                End If

                lbxDefaultValues.Items.Clear()
                crxReportP.Load(frmMain.dgvScheduleList.Item(glbSourceReport, frmMain.dgvScheduleList.CurrentRow.Index).Value)
                crParameterFieldDefinitions = crxReportP.DataDefinition.ParameterFields
                crParameterFieldLocation = crParameterFieldDefinitions.Item(dgvParameterList.Item(1, dgvParameterList.CurrentRow.Index).Value())
                crParameterValues = crParameterFieldLocation.DefaultValues
                If crParameterFieldLocation.EnableAllowMultipleValue = True Then
                    lbxDefaultValues.SelectionMode = SelectionMode.MultiSimple
                Else
                    lbxDefaultValues.SelectionMode = SelectionMode.One
                End If

                crParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue

                If booAddBatch = True Then
                    lbxDefaultValues.Items.Add("[Batch]")
                End If

                For intIndex = 0 To crParameterValues.Count - 1
                    crParameterDiscreteValue = crParameterValues.Item(intIndex)
                    lbxDefaultValues.Items.Add(crParameterDiscreteValue.Value)
                Next intIndex


                'crSections = crxReportP.ReportDefinition.Sections
                'For Each crSection In crSections
                'crReportObjects = crSection.ReportObjects
                'For Each crReportObject In crReportObjects
                'If crReportObject.Kind = ReportObjectKind.SubreportObject Then
                'crxSubReportObject = CType(crReportObject, SubreportObject)
                'crxSubReport = crxSubReportObject.OpenSubreport(crxSubReportObject.SubreportName)
                'crParameterFieldDefinitions = crxSubReport.DataDefinition.ParameterFields
                'crParameterFieldLocation = crParameterFieldDefinitions.Item(dgvParameterList.Item(1, dgvParameterList.CurrentRow.Index).Value())
                'crParameterValues = crParameterFieldLocation.DefaultValues

                'For intIndex = 0 To crParameterValues.Count - 1
                'crParameterDiscreteValue = crParameterValues.Item(intIndex)
                'lbxDefaultValues.Items.Add(crParameterDiscreteValue.Value)
                'Next intIndex

                'End If
                'Next
                'Next
                crxReportP.Close()
            End If

        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try

    End Sub


    Private Sub gbxParList_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gbxParList.Enter
        Try
            gbxParList.ForeColor = Color.IndianRed
            gbxDynamic.ForeColor = Color.RoyalBlue
            gbxDate.ForeColor = Color.RoyalBlue
            gbxTime.ForeColor = Color.RoyalBlue
            gbxBoolean.ForeColor = Color.RoyalBlue
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try

    End Sub

    Private Sub gbxDynamic_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gbxDynamic.Enter
        Try
            gbxParList.ForeColor = Color.RoyalBlue
            gbxDynamic.ForeColor = Color.IndianRed
            gbxDate.ForeColor = Color.RoyalBlue
            gbxTime.ForeColor = Color.RoyalBlue
            gbxBoolean.ForeColor = Color.RoyalBlue
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try

    End Sub

    Private Sub gbxDate_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gbxDate.Enter
        Try
            gbxParList.ForeColor = Color.RoyalBlue
            gbxDynamic.ForeColor = Color.RoyalBlue
            gbxDate.ForeColor = Color.IndianRed
            gbxTime.ForeColor = Color.RoyalBlue
            gbxBoolean.ForeColor = Color.RoyalBlue
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try

    End Sub

    Private Sub gbxTime_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gbxTime.Enter
        Try
            gbxParList.ForeColor = Color.RoyalBlue
            gbxDynamic.ForeColor = Color.RoyalBlue
            gbxDate.ForeColor = Color.RoyalBlue
            gbxTime.ForeColor = Color.IndianRed
            gbxBoolean.ForeColor = Color.RoyalBlue
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try

    End Sub

    Private Sub gbxBoolean_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gbxBoolean.Enter
        Try
            gbxParList.ForeColor = Color.RoyalBlue
            gbxDynamic.ForeColor = Color.RoyalBlue
            gbxDate.ForeColor = Color.RoyalBlue
            gbxTime.ForeColor = Color.RoyalBlue
            gbxBoolean.ForeColor = Color.IndianRed
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try

    End Sub

    Private Sub cmbValueStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbValueStart.Click
        Try
            AddStartValue()
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try

    End Sub

    Private Sub AddStartValue()
        Try
            Dim intIndex As Integer
            Dim txtParameterValue As String

            If gbxParList.ForeColor = Color.IndianRed Then
                txtParameterValue = ""
                For intIndex = 0 To lbxDefaultValues.SelectedItems.Count - 1
                    txtParameterValue = lbxDefaultValues.SelectedItems.Item(intIndex) & ";" & txtParameterValue
                Next intIndex
                dgvParameterList.Item(2, dgvParameterList.CurrentRow.Index).Value() = Mid(txtParameterValue, 1, (txtParameterValue.Length - 1))
            ElseIf gbxDynamic.ForeColor = Color.IndianRed Then
                dgvParameterList.Item(2, dgvParameterList.CurrentRow.Index).Value() = cbxDyanmicType.Text.ToString & ":" & tbxDynamicOffset.Text
            ElseIf gbxDate.ForeColor = Color.IndianRed Then
                dgvParameterList.Item(2, dgvParameterList.CurrentRow.Index).Value() = dtmDate.Text
            ElseIf gbxTime.ForeColor = Color.IndianRed Then
                dgvParameterList.Item(2, dgvParameterList.CurrentRow.Index).Value() = dtmTime.Text
            ElseIf gbxBoolean.ForeColor = Color.IndianRed Then
                If radTrue.Checked = True Then
                    dgvParameterList.Item(2, dgvParameterList.CurrentRow.Index).Value() = "True"
                Else
                    dgvParameterList.Item(2, dgvParameterList.CurrentRow.Index).Value() = "False"
                End If
            End If
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try

    End Sub

    Private Sub cmbValueEnd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbValueEnd.Click
        Try
            AddEndValue()
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try

    End Sub

    Private Sub AddEndValue()
        Try
            Dim intIndex As Integer
            Dim txtParameterValue As String
            If gbxParList.ForeColor = Color.IndianRed Then
                txtParameterValue = ""
                For intIndex = 0 To lbxDefaultValues.SelectedItems.Count - 1
                    txtParameterValue = txtParameterValue & ";" & lbxDefaultValues.SelectedItems.Item(intIndex)
                Next intIndex
                dgvParameterList.Item(3, dgvParameterList.CurrentRow.Index).Value() = Mid(txtParameterValue, 3)
            ElseIf gbxDynamic.ForeColor = Color.IndianRed Then
                dgvParameterList.Item(3, dgvParameterList.CurrentRow.Index).Value() = cbxDyanmicType.Text.ToString & ":" & tbxDynamicOffset.Text
            ElseIf gbxDate.ForeColor = Color.IndianRed Then
                dgvParameterList.Item(3, dgvParameterList.CurrentRow.Index).Value() = dtmDate.Text
            ElseIf gbxTime.ForeColor = Color.IndianRed Then
                dgvParameterList.Item(3, dgvParameterList.CurrentRow.Index).Value() = dtmTime.Text
            ElseIf gbxBoolean.ForeColor = Color.IndianRed Then
                If radTrue.Checked = True Then
                    dgvParameterList.Item(3, dgvParameterList.CurrentRow.Index).Value() = "True"
                Else
                    dgvParameterList.Item(3, dgvParameterList.CurrentRow.Index).Value() = "False"
                End If
            End If
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try

    End Sub



    Private Sub cmbRestoreConnDefaults_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbRestoreConnDefaults.Click
        Try
            dgvConnections.Rows.Clear()
            ImportReportConnections()
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try

    End Sub

    Private Sub dtmRunHistoryDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtmRunHistoryDate.ValueChanged
        Try
            booHistoryChanged = True
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try

    End Sub



    Private Sub dtmRunHistoryTime_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtmRunHistoryTime.ValueChanged
        Try
            booHistoryChanged = True
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try

    End Sub

    Private Sub lbxDefaultValues_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lbxDefaultValues.MouseDoubleClick
        Try
            If cmbValueEnd.Enabled = False Then
                AddStartValue()
            Else
                If dgvParameterList.SelectedCells.Item(0).ColumnIndex = 2 Then
                    AddStartValue()
                ElseIf dgvParameterList.SelectedCells.Item(0).ColumnIndex = 3 Then
                    AddEndValue()
                End If
            End If
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try

    End Sub




    Private Sub cmbSaveTemplate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSaveTemplate.Click
        Try
            SaveFileDialog1.Filter = "Text (*.txt)|*.txt"
            SaveFileDialog1.Title = "Select folder and filename"
            If SaveFileDialog1.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
                Dim objWriter As New System.IO.StreamWriter(SaveFileDialog1.FileName)
                objWriter.Write("EXPORTEMAILFROM" & vbCrLf)
                objWriter.Write(txbExportFrom.Text & vbCrLf)
                objWriter.Write("EXPORTEMAILTO" & vbCrLf)
                objWriter.Write(txbExportTo.Text & vbCrLf)
                objWriter.Write("EXPORTEMAILCC" & vbCrLf)
                objWriter.Write(txbExportCC.Text & vbCrLf)
                objWriter.Write("EXPORTEMAILBC" & vbCrLf)
                objWriter.Write(txbExportBCC.Text & vbCrLf)
                objWriter.Write("EXPORTEMAILSUBJECT" & vbCrLf)
                objWriter.Write(txbExportSubject.Text & vbCrLf)
                objWriter.Write("EXPORTEMAILMESSAGE" & vbCrLf)
                objWriter.Write(rtbExportMessage.Text)
                objWriter.Close()
            End If
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try

    End Sub

    Private Sub cmbLoadTemplate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbLoadTemplate.Click
        Try
            'Dim strFilePathAndName As String
            Dim txtDataID As String

            OpenFileDialog1.Filter = "Text|*.txt"
            If OpenFileDialog1.ShowDialog() <> Windows.Forms.DialogResult.Cancel Then
                'strFilePathAndName = OpenFileDialog1.FileName '.FileNames(intIndex)
                Dim objReader As New System.IO.StreamReader(OpenFileDialog1.FileName)
                Do
                    txtDataID = objReader.ReadLine()
                    Select Case txtDataID
                        Case "EXPORTEMAILFROM"
                            txbExportFrom.Text = objReader.ReadLine
                        Case "EXPORTEMAILTO"
                            txbExportTo.Text = objReader.ReadLine
                        Case "EXPORTEMAILCC"
                            txbExportCC.Text = objReader.ReadLine
                        Case "EXPORTEMAILBC"
                            txbExportBCC.Text = objReader.ReadLine
                        Case "EXPORTEMAILSUBJECT"
                            txbExportSubject.Text = objReader.ReadLine
                        Case "EXPORTEMAILMESSAGE"
                            rtbExportMessage.Text = ""
                            Do
                                rtbExportMessage.Text = rtbExportMessage.Text & objReader.ReadLine() & vbCr & vbLf
                            Loop Until objReader.EndOfStream
                            'rtbExportMessage.Text = objReader.ReadLine
                    End Select
                Loop Until objReader.EndOfStream
                objReader.Close()
            End If
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try

    End Sub

    Private Sub cmbFrom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbFrom.Click
        Try
            ShowAddressBook()
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try

    End Sub

    Private Sub ShowAddressBook()
        Try
            frmAddressBook.Show()
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try

    End Sub

    Private Sub cmbTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTo.Click
        Try
            ShowAddressBook()
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try

    End Sub

    Private Sub cmbCC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCC.Click
        Try
            ShowAddressBook()
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try

    End Sub

    Private Sub cmbBCC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBCC.Click
        Try
            ShowAddressBook()
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try

    End Sub


    Private Sub cmbSelectSource_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSelectSource.Click
        Try
            Dim Split1() As String
            Dim Split2() As String


            OpenFileDialog1.Filter = "Crystal Report|*.rpt"

            If OpenFileDialog1.ShowDialog() <> Windows.Forms.DialogResult.Cancel Then
                tbxSourceReport.Text = OpenFileDialog1.FileName
                Split1 = Split(OpenFileDialog1.FileName, "\", -1)
                Split2 = Split(Split1(UBound(Split1)), ".", -1)
                frmMain.dgvScheduleList.Item(glbSourceReport, frmMain.dgvScheduleList.CurrentRow.Index).Value = tbxSourceReport.Text
                frmMain.dgvScheduleList.Item(glbReportName, frmMain.dgvScheduleList.CurrentRow.Index).Value = Split2(0)
                SaveReportSettingsFile()
                dgvParameterList.Rows.Clear()
                dgvConnections.Rows.Clear()
                dgvExportDirectories.Rows.Clear()
                lbxDefaultValues.Items.Clear()
                ImportReportParameters()
                ImportReportConnections()
                ReadReportSettingsFile()
            End If
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try

    End Sub


    Private Sub dgvParameterList_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvParameterList.CellContentClick
        Try
            Dim arrSplit() As String
            If e.ColumnIndex > 1 Then
                If InStr(dgvParameterList.Item(e.ColumnIndex, e.RowIndex).Value, ":", CompareMethod.Text) Then
                    arrSplit = Split(dgvParameterList.Item(e.ColumnIndex, e.RowIndex).Value, ":", 2)
                    Select Case arrSplit(0)
                        Case "Today (Days)"
                            cbxDyanmicType.Text = arrSplit(0).ToString
                            tbxDynamicOffset.Text = arrSplit(1).ToString
                        Case "Today (Months)"
                            cbxDyanmicType.Text = arrSplit(0).ToString
                            tbxDynamicOffset.Text = arrSplit(1).ToString
                        Case "Month Start (Days)"
                            cbxDyanmicType.Text = arrSplit(0).ToString
                            tbxDynamicOffset.Text = arrSplit(1).ToString
                        Case "Month End (Days)"
                            cbxDyanmicType.Text = arrSplit(0).ToString
                            tbxDynamicOffset.Text = arrSplit(1).ToString
                        Case "Month Start (Months)"
                            cbxDyanmicType.Text = arrSplit(0).ToString
                            tbxDynamicOffset.Text = arrSplit(1).ToString
                        Case "Month End (Months)"
                            cbxDyanmicType.Text = arrSplit(0).ToString
                            tbxDynamicOffset.Text = arrSplit(1).ToString
                        Case "Year Start (Days)"
                            cbxDyanmicType.Text = arrSplit(0).ToString
                            tbxDynamicOffset.Text = arrSplit(1).ToString
                        Case "Year End (Days)"
                            cbxDyanmicType.Text = arrSplit(0).ToString
                            tbxDynamicOffset.Text = arrSplit(1).ToString
                        Case "Year Start (Months)"
                            cbxDyanmicType.Text = arrSplit(0).ToString
                            tbxDynamicOffset.Text = arrSplit(1).ToString
                        Case "Year End (Months)"
                            cbxDyanmicType.Text = arrSplit(0).ToString
                            tbxDynamicOffset.Text = arrSplit(1).ToString
                        Case "Year Start (Years)"
                            cbxDyanmicType.Text = arrSplit(0).ToString
                            tbxDynamicOffset.Text = arrSplit(1).ToString
                        Case "Year End (Years)"
                            cbxDyanmicType.Text = arrSplit(0).ToString
                            tbxDynamicOffset.Text = arrSplit(1).ToString
                        Case "Sunday (Weeks)"
                            cbxDyanmicType.Text = arrSplit(0).ToString
                            tbxDynamicOffset.Text = arrSplit(1).ToString
                        Case "Monday (Weeks)"
                            cbxDyanmicType.Text = arrSplit(0).ToString
                            tbxDynamicOffset.Text = arrSplit(1).ToString
                        Case "Tuesday (Weeks)"
                            cbxDyanmicType.Text = arrSplit(0).ToString
                            tbxDynamicOffset.Text = arrSplit(1).ToString
                        Case "Wednesday (Weeks)"
                            cbxDyanmicType.Text = arrSplit(0).ToString
                            tbxDynamicOffset.Text = arrSplit(1).ToString
                        Case "Thursday (Weeks)"
                            cbxDyanmicType.Text = arrSplit(0).ToString
                            tbxDynamicOffset.Text = arrSplit(1).ToString
                        Case "Friday (Weeks)"
                            cbxDyanmicType.Text = arrSplit(0).ToString
                            tbxDynamicOffset.Text = arrSplit(1).ToString
                        Case "Saturday (Weeks)"
                            cbxDyanmicType.Text = arrSplit(0).ToString
                            tbxDynamicOffset.Text = arrSplit(1).ToString
                    End Select
                End If
            End If
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Try
            If frmMain.ToolStripProgressBar1.Value = 100 Then
                frmMain.ToolStripProgressBar1.Value = 0
            End If
            frmMain.ToolStripProgressBar1.PerformStep()
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try

    End Sub

    Private Sub cmbShowCalendar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbShowCalendar.Click
        Try
            frmCalendar.Show()
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try

    End Sub

    Private Sub dtmExportTimeEnd_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtmExportTimeEnd.ValueChanged
        Dim intSeconds As Integer

        Try
            'dtmExportTimeStart.Value = Format(dtmExportTimeEnd.Value, "d") & " " & Format(dtmExportTimeStart.Value, "t")

            dtmExportTimeEnd.Value = Format(Now(), "d") & " " & Format(dtmExportTimeEnd.Value, "t")


            intSeconds = Second(dtmExportTimeEnd.Value)
            dtmExportTimeEnd.Value = DateAdd(DateInterval.Second, -intSeconds, dtmExportTimeEnd.Value)


            If DateDiff(DateInterval.Minute, dtmExportTimeStart.Value, dtmExportTimeEnd.Value) <= 5 Then
                dtmExportTimeStart.Value = DateAdd(DateInterval.Minute, -5, dtmExportTimeEnd.Value)
            End If
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try

    End Sub

    Private Sub dtmExportTimeStart_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtmExportTimeStart.ValueChanged
        Dim intSeconds As Integer
        Try
            'dtmExportTimeStart.Value = Format(dtmExportTimeEnd.Value, "d") & " " & Format(dtmExportTimeEnd.Value, "t")

            dtmExportTimeStart.Value = Format(Now(), "d") & " " & Format(dtmExportTimeStart.Value, "t")


            intSeconds = Second(dtmExportTimeStart.Value)
            dtmExportTimeStart.Value = DateAdd(DateInterval.Second, -intSeconds, dtmExportTimeStart.Value)



            If DateDiff(DateInterval.Minute, dtmExportTimeStart.Value, dtmExportTimeEnd.Value) <= 5 Then
                dtmExportTimeEnd.Value = DateAdd(DateInterval.Minute, 5, dtmExportTimeStart.Value)
            End If
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try

    End Sub

    Private Sub tbxSourceReport_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbxSourceReport.LostFocus
        Try
            CheckSourceFile()
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try

    End Sub
    Private Sub CheckSourceFile()
        Try
            If FileExists(tbxSourceReport.Text) = True Then
                tbxSourceReport.BackColor = Color.White
                lblSourceError.Visible = False
            Else
                tbxSourceReport.BackColor = Color.IndianRed
                lblSourceError.Visible = True
            End If
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try

    End Sub


End Class