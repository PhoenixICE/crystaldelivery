Module modErrorWriter
    Public Sub ErrorWriter(ByVal strErrorMessage As String)
        Try
            If InStr(strErrorMessage, "FlushFinalBlock", CompareMethod.Text) = False Then
                Dim ReportSettingsInfo As String = App_Path() & "ProcessLog.txt"
                If FileExists(ReportSettingsInfo) Then
                    Dim fInfo As New System.IO.FileInfo(ReportSettingsInfo)
                    If fInfo.Length >= 100000 Then
                        Kill(ReportSettingsInfo)
                    End If
                End If
                'strErrorMessage = Now() & vbCrLf & strErrorMessage & vbCrLf & vbCrLf
                strErrorMessage = Now() & vbCrLf & strErrorMessage & vbCrLf
                Dim objErrorWriter As New System.IO.StreamWriter(ReportSettingsInfo, True)
                objErrorWriter.Write(strErrorMessage)
                objErrorWriter.Close()
            End If
        Catch
        End Try
    End Sub
End Module
