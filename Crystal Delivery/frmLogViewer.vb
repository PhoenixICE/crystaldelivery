Public Class frmLogViewer

    Private Sub frmLogViewer_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim intRowIndex As Integer
        Dim intColIndex As Integer
        Dim ReportSettingsInfo As String = App_Path() & "ProcessLog.txt"

        Try
            If dgvLogFile.RowCount > 0 Then
                dgvLogFile.Sort(colDate, System.ComponentModel.ListSortDirection.Descending)

                Dim objWriter As New System.IO.StreamWriter(ReportSettingsInfo)
                For intRowIndex = 0 To dgvLogFile.RowCount - 1
                    For intColIndex = 0 To dgvLogFile.ColumnCount - 1
                        objWriter.Write(dgvLogFile.Item(intColIndex, intRowIndex).Value & vbCrLf)
                    Next (intColIndex)
                    If intRowIndex = 100 Then Exit For
                Next intRowIndex
                objWriter.Close()
            End If

        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try
    End Sub
    Private Sub frmLogViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Dim ReportSettingsInfo As String = App_Path() & "ProcessLog.txt"
            dgvLogFile.Rows.Clear()
            If FileExists(ReportSettingsInfo) = True Then
                Dim objReader As New System.IO.StreamReader(ReportSettingsInfo)
                Do
                    dgvLogFile.Rows.Add(objReader.ReadLine(), objReader.ReadLine())
                Loop Until objReader.EndOfStream
                objReader.Close()
                dgvLogFile.Sort(colDate, System.ComponentModel.ListSortDirection.Descending)
            End If


        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try
    End Sub




End Class