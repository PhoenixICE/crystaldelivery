Imports System.IO
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine


Module modGlobals
    Public glbActiveID As String
    Public glbActivePath As String
    Public strSourceReportName As String
    Public booAutoDeliver As Boolean = False
    Public intExportIntervalCounter As Integer
    Public datExportDate As Date
    Public booInProcessOfExporting As Boolean
    Public strBody As String
    Public strExportFiles(0) As String
    Public glbNumberOfReports As Integer
    Public crxReportToExport As New ReportDocument
    Public ReportSettingsInfo As String

    Public arrBatchParameter(0) As String

    Public Const quote As String = """"
    Public Const glbID = 0
    Public Const glbReportName = 1
    Public Const glbExportInterval = 2
    Public Const glbExportDays = 3
    Public Const glbExportTime = 4
    Public Const glbRunHistory = 5
    Public Const glbSourceReport = 6
    Public Const glbEKey = "2g!r@o#f$f%a^u&t*o(m)a{t}i[o]n'0"


    Public Function App_Path() As String
        Try
            Return System.AppDomain.CurrentDomain.BaseDirectory()
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
            App_Path = ""
        End Try

    End Function

    Public Sub KillTemp()
        Try
            Kill(App_Path() & "ScheduledReports\*.tmp")
            Directory.Delete(App_Path() & "ScheduledReports\TEMP", True)
        Catch ex As Exception
            ' ErrorWriter(ex.Message.ToString)
        End Try

    End Sub

    Public Sub CleanReportsFolder()
        Try
            Dim intRowIndex As Integer
            Dim arrFileNames() As String = Directory.GetFiles(App_Path() & "ScheduledReports")
            Dim intIndex As Integer
            Dim txtFileName As String
            Dim booInList As Boolean

            For intIndex = 0 To arrFileNames.Length - 1
                booInList = False
                txtFileName = Path.GetFileName(arrFileNames(intIndex))

                For intRowIndex = 0 To frmMain.dgvScheduleList.Rows.Count - 1
                    If txtFileName = frmMain.dgvScheduleList.Item(glbID, intRowIndex).Value Then
                        booInList = True
                        Exit For
                    End If
                Next

                If booInList = False Then
                    If Path.GetExtension(App_Path() & "ScheduledReports\" & txtFileName) = ".txt" And UCase(txtFileName) <> "MAINLIST.TXT" Then
                        Try
                            Kill(App_Path() & "ScheduledReports\" & txtFileName)
                        Catch
                        End Try
                    End If
                End If
            Next intIndex
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try
    End Sub

    Public Function LeftString(ByVal str As String, ByVal index As Integer) As String
        LeftString = str.Substring(0, index)
    End Function

    Public Function RightString(ByVal str As String, ByVal index As Integer) As String
        RightString = str.Substring(str.Length - index)
    End Function

End Module

