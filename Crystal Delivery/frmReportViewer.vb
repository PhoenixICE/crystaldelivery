Public Class frmReportViewer

    Private Sub frmReportViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'FileCopy(App_Path() & "ScheduledReports\" & glbActiveID, App_Path() & "ScheduledReports\" & glbActiveID & "T")
            crViewer.ReportSource = fncReportSource()

            crViewer.Show()

        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try

    End Sub


    Private Sub frmViewer_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Try
            crViewer.Width = Me.Width
            crViewer.Height = Me.Height
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try

    End Sub
End Class