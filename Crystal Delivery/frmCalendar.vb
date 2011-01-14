Public Class frmCalendar

  
    Private Sub cmbAddDate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAddDate.Click
        Try
            txbSelectedDates.Text = txbSelectedDates.Text & Format(calCalendar.SelectionStart, "M").ToString & ";"
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try

    End Sub

    Private Sub frmCalendar_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            txbSelectedDates.Text = Trim(txbSelectedDates.Text)
            If txbSelectedDates.Text <> "" Then
                frmSettings.tbxExportIntervalValue.Text = Mid(txbSelectedDates.Text, 1, txbSelectedDates.Text.Length - 1)
            End If
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try

    End Sub

    Private Sub frmCalendar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If frmSettings.tbxExportIntervalValue.Text <> "" Then
                txbSelectedDates.Text = frmSettings.tbxExportIntervalValue.Text & ";"
            Else
                txbSelectedDates.Text = frmSettings.tbxExportIntervalValue.Text
            End If
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try

    End Sub

End Class