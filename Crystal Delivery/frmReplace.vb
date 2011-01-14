Imports System.IO


Public Class frmReplace

    Private Sub cmbExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbExit.Click
        Try
            Me.Close()
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try
    End Sub

    Private Sub cmbReplace_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbReplace.Click
        Try

            Dim arrFileNames() As String = Directory.GetFiles(App_Path() & "ScheduledReports")
            Dim intIndex As Integer
            Dim txtFileName As String
            Dim booInList As Boolean
            Dim strFileText(0) As String
            Dim intArrIndex As Integer
            Dim intMainIndex As Integer

            ProgressBar1.Value = 0
            ProgressBar1.Maximum = frmMain.dgvScheduleList.Rows.Count
            For intIndex = 0 To arrFileNames.Length - 1
                ProgressBar1.PerformStep()
                booInList = True
                txtFileName = Path.GetFileName(arrFileNames(intIndex))

                If booInList = True And UCase(txtFileName) <> "MAINLIST.TXT" Then
                    decryptfile(App_Path() & "ScheduledReports\" & txtFileName)
                    Dim objReader As New System.IO.StreamReader(App_Path() & "ScheduledReports\" & txtFileName)
                    ReDim strFileText(0)

                    Do
                        strFileText(UBound(strFileText)) = objReader.ReadLine
                        ReDim Preserve strFileText(UBound(strFileText) + 1)
                    Loop Until objReader.EndOfStream
                    objReader.Close()
                    encryptfile(App_Path() & "ScheduledReports\" & txtFileName)

                    ReDim Preserve strFileText(UBound(strFileText) - 1)

                    For intArrIndex = 0 To UBound(strFileText)
                        Select Case strFileText(intArrIndex)
                            Case "SOURCEREPORT"
                                If chkSchedule.CheckState = CheckState.Checked Then
                                    strFileText(intArrIndex + 1) = Replace(strFileText(intArrIndex + 1), txbCurrentString.Text, txbNewString.Text, , , CompareMethod.Text)
                                End If
                            Case "ALLOWREMOTE"
                                If chkSchedule.CheckState = CheckState.Checked Then
                                    strFileText(intArrIndex + 1) = Replace(strFileText(intArrIndex + 1), txbCurrentString.Text, txbNewString.Text, , , CompareMethod.Text)
                                End If
                            Case "EXPORTINTERVALTYPE"
                                If chkSchedule.CheckState = CheckState.Checked Then
                                    strFileText(intArrIndex + 1) = Replace(strFileText(intArrIndex + 1), txbCurrentString.Text, txbNewString.Text, , , CompareMethod.Text)
                                End If
                            Case "EXPORTINTERVALVALUE"
                                If chkSchedule.CheckState = CheckState.Checked Then
                                    strFileText(intArrIndex + 1) = Replace(strFileText(intArrIndex + 1), txbCurrentString.Text, txbNewString.Text, , , CompareMethod.Text)
                                End If
                            Case "EXPORTTIMESTART"
                                If chkSchedule.CheckState = CheckState.Checked Then
                                    strFileText(intArrIndex + 1) = Replace(strFileText(intArrIndex + 1), txbCurrentString.Text, txbNewString.Text, , , CompareMethod.Text)
                                End If
                            Case "EXPORTTIMEEND"
                                If chkSchedule.CheckState = CheckState.Checked Then
                                    strFileText(intArrIndex + 1) = Replace(strFileText(intArrIndex + 1), txbCurrentString.Text, txbNewString.Text, , , CompareMethod.Text)
                                End If
                            Case "EXPORTTIMECHECK"
                                If chkSchedule.CheckState = CheckState.Checked Then
                                    strFileText(intArrIndex + 1) = Replace(strFileText(intArrIndex + 1), txbCurrentString.Text, txbNewString.Text, , , CompareMethod.Text)
                                End If
                            Case "RUNHISTORYDATE"
                                If chkSchedule.CheckState = CheckState.Checked Then
                                    strFileText(intArrIndex + 1) = Replace(strFileText(intArrIndex + 1), txbCurrentString.Text, txbNewString.Text, , , CompareMethod.Text)
                                End If
                            Case "RUNHISTORYTIME"
                                If chkSchedule.CheckState = CheckState.Checked Then
                                    strFileText(intArrIndex + 1) = Replace(strFileText(intArrIndex + 1), txbCurrentString.Text, txbNewString.Text, , , CompareMethod.Text)
                                End If
                            Case "EXPORTDAYS"
                                If chkSchedule.CheckState = CheckState.Checked Then
                                    strFileText(intArrIndex + 1) = Replace(strFileText(intArrIndex + 1), txbCurrentString.Text, txbNewString.Text, , , CompareMethod.Text)
                                End If
                            Case "RANGE"
                                If chkParameters.CheckState = CheckState.Checked Then
                                    strFileText(intArrIndex + 1) = Replace(strFileText(intArrIndex + 1), txbCurrentString.Text, txbNewString.Text, , , CompareMethod.Text)
                                    strFileText(intArrIndex + 2) = Replace(strFileText(intArrIndex + 2), txbCurrentString.Text, txbNewString.Text, , , CompareMethod.Text)
                                    strFileText(intArrIndex + 3) = Replace(strFileText(intArrIndex + 3), txbCurrentString.Text, txbNewString.Text, , , CompareMethod.Text)
                                End If
                                intArrIndex = intArrIndex + 3
                            Case "DISCRETE"
                                If chkParameters.CheckState = CheckState.Checked Then
                                    strFileText(intArrIndex + 1) = Replace(strFileText(intArrIndex + 1), txbCurrentString.Text, txbNewString.Text, , , CompareMethod.Text)
                                    strFileText(intArrIndex + 2) = Replace(strFileText(intArrIndex + 2), txbCurrentString.Text, txbNewString.Text, , , CompareMethod.Text)
                                End If
                                intArrIndex = intArrIndex + 1

                            Case "CONNECTION"
                                If chkConn.CheckState = CheckState.Checked Then
                                    strFileText(intArrIndex + 3) = DecryptText(strFileText(intArrIndex + 3), glbEKey)
                                    strFileText(intArrIndex + 4) = DecryptText(strFileText(intArrIndex + 4), glbEKey)

                                    strFileText(intArrIndex + 1) = Replace(strFileText(intArrIndex + 1), txbCurrentString.Text, txbNewString.Text, , , CompareMethod.Text)
                                    strFileText(intArrIndex + 2) = Replace(strFileText(intArrIndex + 2), txbCurrentString.Text, txbNewString.Text, , , CompareMethod.Text)
                                    strFileText(intArrIndex + 3) = Replace(strFileText(intArrIndex + 3), txbCurrentString.Text, txbNewString.Text, , , CompareMethod.Text)
                                    strFileText(intArrIndex + 4) = Replace(strFileText(intArrIndex + 4), txbCurrentString.Text, txbNewString.Text, , , CompareMethod.Text)

                                    strFileText(intArrIndex + 3) = EncryptText(strFileText(intArrIndex + 3), glbEKey)
                                    strFileText(intArrIndex + 4) = EncryptText(strFileText(intArrIndex + 4), glbEKey)

                                End If
                                intArrIndex = intArrIndex + 4
                            Case "EXPORTDIRECTORY"
                                If chkExDir.CheckState = CheckState.Checked Then
                                    strFileText(intArrIndex + 1) = Replace(strFileText(intArrIndex + 1), txbCurrentString.Text, txbNewString.Text, , , CompareMethod.Text)
                                End If
                            Case "EXPORTPRINTER"
                                If chkExPrint.CheckState = CheckState.Checked Then
                                    strFileText(intArrIndex + 1) = Replace(strFileText(intArrIndex + 1), txbCurrentString.Text, txbNewString.Text, , , CompareMethod.Text)
                                    strFileText(intArrIndex + 2) = Replace(strFileText(intArrIndex + 2), txbCurrentString.Text, txbNewString.Text, , , CompareMethod.Text)
                                    strFileText(intArrIndex + 3) = Replace(strFileText(intArrIndex + 3), txbCurrentString.Text, txbNewString.Text, , , CompareMethod.Text)
                                    strFileText(intArrIndex + 4) = Replace(strFileText(intArrIndex + 4), txbCurrentString.Text, txbNewString.Text, , , CompareMethod.Text)
                                End If
                                intArrIndex = intArrIndex + 4
                            Case "DISABLEEXPORTEMAIL"
                                If chkExEmail.CheckState = CheckState.Checked Then
                                    strFileText(intArrIndex + 1) = Replace(strFileText(intArrIndex + 1), txbCurrentString.Text, txbNewString.Text, , , CompareMethod.Text)
                                End If
                            Case "EXPORTEMAILFROM"
                                If chkExEmail.CheckState = CheckState.Checked Then
                                    strFileText(intArrIndex + 1) = Replace(strFileText(intArrIndex + 1), txbCurrentString.Text, txbNewString.Text, , , CompareMethod.Text)
                                End If
                            Case "EXPORTEMAILTO"
                                If chkExEmail.CheckState = CheckState.Checked Then
                                    strFileText(intArrIndex + 1) = Replace(strFileText(intArrIndex + 1), txbCurrentString.Text, txbNewString.Text, , , CompareMethod.Text)
                                End If
                            Case "EXPORTEMAILCC"
                                If chkExEmail.CheckState = CheckState.Checked Then
                                    strFileText(intArrIndex + 1) = Replace(strFileText(intArrIndex + 1), txbCurrentString.Text, txbNewString.Text, , , CompareMethod.Text)
                                End If
                            Case "EXPORTEMAILBC"
                                If chkExEmail.CheckState = CheckState.Checked Then
                                    strFileText(intArrIndex + 1) = Replace(strFileText(intArrIndex + 1), txbCurrentString.Text, txbNewString.Text, , , CompareMethod.Text)
                                End If
                            Case "EXPORTEMAILSUBJECT"
                                If chkExEmail.CheckState = CheckState.Checked Then
                                    strFileText(intArrIndex + 1) = Replace(strFileText(intArrIndex + 1), txbCurrentString.Text, txbNewString.Text, , , CompareMethod.Text)
                                End If
                            Case "EXPORTEMAILMESSAGE"
                                If chkExEmail.CheckState = CheckState.Checked Then 'And strFileText(intArrIndex) <> "CDENDOFRTF" Then
                                    strFileText(intArrIndex) = Replace(strFileText(intArrIndex + 1), txbCurrentString.Text, txbNewString.Text, , , CompareMethod.Text)
                                End If

                        End Select

                    Next intArrIndex


                    Dim objWriterNew As New System.IO.StreamWriter(App_Path() & "ScheduledReports\" & txtFileName)
                    For intArrIndex = 0 To UBound(strFileText)
                        objWriterNew.Write(strFileText(intArrIndex) & vbCrLf)
                    Next intArrIndex
                    objWriterNew.Close()
                    encryptfile(App_Path() & "ScheduledReports\" & txtFileName)

                End If

                If chkSchedule.CheckState = CheckState.Checked And UCase(txtFileName) = "MAINLIST.TXT" Then
                    ReDim strFileText(0)
                    decryptfile(App_Path() & "ScheduledReports\MainList.txt")

                    Dim objReader As New System.IO.StreamReader(App_Path() & "ScheduledReports\MainList.txt")
                    Do
                        strFileText(UBound(strFileText)) = objReader.ReadLine
                        ReDim Preserve strFileText(UBound(strFileText) + 1)
                    Loop Until objReader.EndOfStream
                    objReader.Close()
                    ReDim Preserve strFileText(UBound(strFileText) - 1)

                    For intMainIndex = 1 To UBound(strFileText) Step 7
                        strFileText(intMainIndex) = Replace(strFileText(intMainIndex), txbCurrentString.Text, txbNewString.Text, , , CompareMethod.Text)
                    Next intMainIndex

                    Dim objWriterNew As New System.IO.StreamWriter(App_Path() & "ScheduledReports\MainList.txt")
                    For intArrIndex = 0 To UBound(strFileText)
                        objWriterNew.Write(strFileText(intArrIndex) & vbCrLf)
                    Next intArrIndex
                    objWriterNew.Close()
                    encryptfile(App_Path() & "ScheduledReports\MainList.txt")


                End If

            Next intIndex
            ProgressBar1.Value = 0
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try


    End Sub


    Private Sub chkAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAll.CheckedChanged
        Try
            chkSchedule.CheckState = chkAll.CheckState
            chkParameters.CheckState = chkAll.CheckState
            chkConn.CheckState = chkAll.CheckState
            chkExDir.CheckState = chkAll.CheckState
            chkExPrint.CheckState = chkAll.CheckState
            chkExEmail.CheckState = chkAll.CheckState
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try

    End Sub

    Private Sub frmReplace_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            CleanReportsFolder()
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try

    End Sub

 
End Class