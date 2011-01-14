Imports System.Security.Cryptography
Imports System.IO
Imports System.Text

Module modEncyrpt
    Public Function EncryptText(ByVal vstrTextToBeEncrypted As String, ByVal vstrEncryptionKey As String) As String
        Try
            Dim bytValue() As Byte
            Dim bytKey() As Byte
            Dim bytEncoded() As Byte
            Dim bytIV() As Byte = {121, 241, 10, 1, 132, 74, 11, 39, 255, 91, 45, 78, 14, 211, 22, 62}
            Dim intLength As Integer
            Dim intRemaining As Integer
            Dim objMemoryStream As New MemoryStream()
            Dim objCryptoStream As CryptoStream
            Dim objRijndaelManaged As RijndaelManaged

            If vstrTextToBeEncrypted <> "" Then
                '**********************************************************************
                '******  Strip any null character from string to be encrypted    ******
                '**********************************************************************

                vstrTextToBeEncrypted = StripNullCharacters(vstrTextToBeEncrypted)

                '**********************************************************************
                '******  Value must be within ASCII range (i.e., no DBCS chars)  ******
                '**********************************************************************

                bytValue = Encoding.ASCII.GetBytes(vstrTextToBeEncrypted.ToCharArray)

                intLength = Len(vstrEncryptionKey)

                '********************************************************************
                '******   Encryption Key must be 256 bits long (32 bytes)      ******
                '******   If it is longer than 32 bytes it will be truncated.  ******
                '******   If it is shorter than 32 bytes it will be padded     ******
                '******   with upper-case Xs.                                  ****** 
                '********************************************************************

                If intLength >= 32 Then
                    vstrEncryptionKey = Strings.Left(vstrEncryptionKey, 32)
                Else
                    intLength = Len(vstrEncryptionKey)
                    intRemaining = 32 - intLength
                    vstrEncryptionKey = vstrEncryptionKey & Strings.StrDup(intRemaining, "X")
                End If

                bytKey = Encoding.ASCII.GetBytes(vstrEncryptionKey.ToCharArray)

                objRijndaelManaged = New RijndaelManaged()

                '***********************************************************************
                '******  Create the encryptor and write value to it after it is   ******
                '******  converted into a byte array                              ******
                '***********************************************************************

                Try

                    objCryptoStream = New CryptoStream(objMemoryStream, _
                      objRijndaelManaged.CreateEncryptor(bytKey, bytIV), _
                      CryptoStreamMode.Write)
                    objCryptoStream.Write(bytValue, 0, bytValue.Length)

                    objCryptoStream.FlushFinalBlock()

                    bytEncoded = objMemoryStream.ToArray
                    objMemoryStream.Close()
                    objCryptoStream.Close()

                Catch ex As Exception
                    ErrorWriter(ex.Message.ToString)
                End Try

                '***********************************************************************
                '******   Return encryptes value (converted from  byte Array to   ******
                '******   a base64 string).  Base64 is MIME encoding)             ******
                '***********************************************************************

                Return Convert.ToBase64String(bytEncoded)
            Else
                Return ""
            End If
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
            Return ""
        End Try

    End Function




    Public Function DecryptText(ByVal vstrStringToBeDecrypted As String, ByVal vstrDecryptionKey As String) As String
        Try
            Dim bytDataToBeDecrypted() As Byte
            Dim bytTemp() As Byte
            Dim bytIV() As Byte = {121, 241, 10, 1, 132, 74, 11, 39, 255, 91, 45, 78, 14, 211, 22, 62}
            Dim objRijndaelManaged As New RijndaelManaged()
            Dim objMemoryStream As MemoryStream
            Dim objCryptoStream As CryptoStream
            Dim bytDecryptionKey() As Byte

            Dim intLength As Integer
            Dim intRemaining As Integer
            'Dim intCtr As Integer
            Dim strReturnString As String = String.Empty
            'Dim achrCharacterArray() As Char
            'Dim intIndex As Integer

            '*****************************************************************
            '******   Convert base64 encrypted value to byte array      ******
            '*****************************************************************

            If vstrStringToBeDecrypted <> "" Then
                Try
                    bytDataToBeDecrypted = Convert.FromBase64String(vstrStringToBeDecrypted)
                Catch ex As Exception
                    ErrorWriter(ex.Message.ToString)
                    Return vstrStringToBeDecrypted
                End Try
                '********************************************************************
                '******   Encryption Key must be 256 bits long (32 bytes)      ******
                '******   If it is longer than 32 bytes it will be truncated.  ******
                '******   If it is shorter than 32 bytes it will be padded     ******
                '******   with upper-case Xs.                                  ****** 
                '********************************************************************

                intLength = Len(vstrDecryptionKey)

                If intLength >= 32 Then
                    vstrDecryptionKey = Strings.Left(vstrDecryptionKey, 32)
                Else
                    intLength = Len(vstrDecryptionKey)
                    intRemaining = 32 - intLength
                    vstrDecryptionKey = vstrDecryptionKey & Strings.StrDup(intRemaining, "X")
                End If

                bytDecryptionKey = Encoding.ASCII.GetBytes(vstrDecryptionKey.ToCharArray)

                ReDim bytTemp(bytDataToBeDecrypted.Length)

                objMemoryStream = New MemoryStream(bytDataToBeDecrypted)

                '***********************************************************************
                '******  Create the decryptor and write value to it after it is   ******
                '******  converted into a byte array                              ******
                '***********************************************************************

                Try

                    objCryptoStream = New CryptoStream(objMemoryStream, _
                       objRijndaelManaged.CreateDecryptor(bytDecryptionKey, bytIV), _
                       CryptoStreamMode.Read)

                    objCryptoStream.Read(bytTemp, 0, bytTemp.Length)

                    objCryptoStream.FlushFinalBlock()
                    objMemoryStream.Close()
                    objCryptoStream.Close()

                Catch ex As Exception
                    ErrorWriter(ex.Message.ToString)
                End Try

                '*****************************************
                '******   Return decypted value     ******
                '*****************************************

                Return StripNullCharacters(Encoding.ASCII.GetString(bytTemp))
            Else
                Return ""
            End If
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
            Return ""
        End Try

    End Function


    Public Function StripNullCharacters(ByVal vstrStringWithNulls As String) As String
        Try

            Dim intPosition As Integer
            Dim strStringWithOutNulls As String

            intPosition = 1
            strStringWithOutNulls = vstrStringWithNulls

            Do While intPosition > 0
                intPosition = InStr(intPosition, vstrStringWithNulls, vbNullChar)

                If intPosition > 0 Then
                    strStringWithOutNulls = Left$(strStringWithOutNulls, intPosition - 1) & _
                                      Right$(strStringWithOutNulls, Len(strStringWithOutNulls) - intPosition)
                End If

                If intPosition > strStringWithOutNulls.Length Then
                    Exit Do
                End If
            Loop

            Return strStringWithOutNulls
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
            'strStringWithOutNulls = vstrStringWithNulls
            'Return strStringWithOutNulls
            Return vstrStringWithNulls
        End Try

    End Function

    Public Sub encryptfile(ByVal strFileName As String)
        Try
            Dim objReader As New System.IO.StreamReader(strFileName)
            Dim strFileContents As String

            strFileContents = EncryptText(objReader.ReadToEnd, glbEKey)
            objReader.Close()

            Dim objWriter As New System.IO.StreamWriter(strFileName)
            objWriter.Write(strFileContents)
            objWriter.Close()
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try

    End Sub


    Public Sub decryptfile(ByVal strFileName As String)
        Try
            Dim objReader As New System.IO.StreamReader(strFileName)
            Dim strFileContents As String

            strFileContents = DecryptText(objReader.ReadToEnd, glbEKey)
            objReader.Close()

            Dim objWriter As New System.IO.StreamWriter(strFileName)
            objWriter.Write(strFileContents)
            objWriter.Close()
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try

    End Sub

End Module
