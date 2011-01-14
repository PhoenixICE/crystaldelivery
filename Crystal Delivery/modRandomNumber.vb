Module modRandomNumber
    Dim objRandom As New System.Random(CType(System.DateTime.Now.Ticks Mod System.Int32.MaxValue, Integer))

    Public Function GetRandomNumber(Optional ByVal Low As Integer = 1, Optional ByVal High As Integer = 100) As Integer
        Try
            Return objRandom.Next(Low, High + 1)
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try
    End Function

End Module
