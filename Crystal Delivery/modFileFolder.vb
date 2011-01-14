Imports System.IO

Module modFileFolder
    Public Function FileExists(ByVal FileFullPath As String) As Boolean
        Try
            Dim f As New IO.FileInfo(FileFullPath)
            Return f.Exists
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try

    End Function

    Public Function FolderExists(ByVal FolderPath As String) As Boolean
        Try
            Dim f As New IO.DirectoryInfo(FolderPath)
            Return f.Exists
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try

    End Function
End Module
