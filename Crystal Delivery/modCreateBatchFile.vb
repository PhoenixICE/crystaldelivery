Imports System.IO

Module modCreateTempBatchFile

    Public Sub CreateTempBatchFile(ByVal txtSearchString As String, ByVal txtReplaceString As String, ByVal txtSearchFile As String, ByVal txtSaveFile As String)
        Try
            Dim objReader As System.IO.StreamReader
            Dim objWriter As System.IO.StreamWriter
            Dim arrReadArray(0) As String
            Dim arrWriteArrray(0) As String
            Dim intIndex As Integer


            objReader = New StreamReader(txtSearchFile)
            Do
                arrReadArray(UBound(arrReadArray)) = objReader.ReadLine
                ReDim Preserve arrReadArray(UBound(arrReadArray) + 1)
            Loop Until objReader.EndOfStream
            objReader.Close()

            ReDim Preserve arrReadArray(UBound(arrReadArray) - 1)

            objWriter = New System.IO.StreamWriter(txtSaveFile)
            For intIndex = 0 To UBound(arrReadArray) - 1
                If UCase(arrReadArray(intIndex)) = UCase(txtSearchString) Then
                    objWriter.Write(txtReplaceString & vbCrLf)
                Else
                    objWriter.Write(arrReadArray(intIndex) & vbCrLf)
                End If
            Next intIndex
            objWriter.Close()

        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try
    End Sub
End Module
