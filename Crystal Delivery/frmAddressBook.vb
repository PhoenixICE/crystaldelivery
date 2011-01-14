Public Class frmAddressBook

    Private Sub frmAddressBook_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            SaveAddressBook()
            frmSettings.txbExportFrom.Text = txbExportFrom.Text
            frmSettings.txbExportTo.Text = txbExportTo.Text
            frmSettings.txbExportCC.Text = txbExportCC.Text
            frmSettings.txbExportBCC.Text = txbExportBCC.Text
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try

    End Sub

    Private Sub SaveAddressBook()
        Try
            Dim ReportSettingsInfo As String = App_Path() & "ABook.txt"
            Dim intColIndex As Integer
            Dim intRowIndex As Integer

            If dgvAddressBook.RowCount > 0 Then
                Dim objWriter As New System.IO.StreamWriter(ReportSettingsInfo)
                For intRowIndex = 0 To dgvAddressBook.RowCount - 1
                    If dgvAddressBook.Item(0, intRowIndex).Value <> "" Or dgvAddressBook.Item(1, intRowIndex).Value <> "" Or dgvAddressBook.Item(2, intRowIndex).Value <> "" Or dgvAddressBook.Item(3, intRowIndex).Value <> "" Then
                        For intColIndex = 0 To dgvAddressBook.ColumnCount - 1
                            objWriter.Write(dgvAddressBook.Item(intColIndex, intRowIndex).Value & vbCrLf)
                        Next (intColIndex)
                    End If
                Next intRowIndex
                objWriter.Close()
            End If
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try

    End Sub

    Private Sub ReadAddressBook()
        Try
            Dim AddressBookFile As String = App_Path() & "ABook.txt"


            If FileExists(AddressBookFile) = True Then

                Dim objReader As New System.IO.StreamReader(AddressBookFile)
                Do
                    dgvAddressBook.Rows.Add(objReader.ReadLine(), objReader.ReadLine(), objReader.ReadLine(), objReader.ReadLine())
                Loop Until objReader.EndOfStream
                objReader.Close()
            End If
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try

    End Sub

    Private Sub frmAddressBook_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            ReadAddressBook()
            txbExportFrom.Text = frmSettings.txbExportFrom.Text
            txbExportTo.Text = frmSettings.txbExportTo.Text
            txbExportCC.Text = frmSettings.txbExportCC.Text
            txbExportBCC.Text = frmSettings.txbExportBCC.Text
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try

    End Sub

    Private Sub cmbFrom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbFrom.Click
        Try
            Const intAddressCol As Integer = 3
            txbExportFrom.Text = CStr(dgvAddressBook.Item(intAddressCol, dgvAddressBook.CurrentRow.Index).Value)
            'txbExportFrom.Text = CStr(dgvAddressBook.Item(intAddressCol, 0).Value)
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try

    End Sub

    Private Sub cmbTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTo.Click
        Try
            Dim intRowIndex As Integer
            Const intAddressCol As Integer = 3

            For intRowIndex = 0 To dgvAddressBook.RowCount - 1
                If dgvAddressBook(0, intRowIndex).Selected Then

                    If txbExportTo.Text = "" Then
                        txbExportTo.Text = CStr(dgvAddressBook.Item(intAddressCol, intRowIndex).Value)
                    Else
                        txbExportTo.Text = txbExportTo.Text & ";" & CStr(dgvAddressBook.Item(intAddressCol, intRowIndex).Value)
                    End If

                End If
            Next
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try

    End Sub

    Private Sub cmbCC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCC.Click
        Try
            Dim intRowIndex As Integer
            Const intAddressCol As Integer = 3

            For intRowIndex = 0 To dgvAddressBook.RowCount - 1
                If dgvAddressBook(0, intRowIndex).Selected Then

                    If txbExportCC.Text = "" Then
                        txbExportCC.Text = CStr(dgvAddressBook.Item(intAddressCol, intRowIndex).Value)
                    Else
                        txbExportCC.Text = txbExportCC.Text & ";" & CStr(dgvAddressBook.Item(intAddressCol, intRowIndex).Value)
                    End If

                End If
            Next
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try


    End Sub

    Private Sub cmbBCC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBCC.Click
        Try
            Dim intRowIndex As Integer
            Const intAddressCol As Integer = 3

            For intRowIndex = 0 To dgvAddressBook.RowCount - 1
                If dgvAddressBook(0, intRowIndex).Selected Then

                    If txbExportBCC.Text = "" Then
                        txbExportBCC.Text = CStr(dgvAddressBook.Item(intAddressCol, intRowIndex).Value)
                    Else
                        txbExportBCC.Text = txbExportBCC.Text & ";" & CStr(dgvAddressBook.Item(intAddressCol, intRowIndex).Value)
                    End If

                End If
            Next
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try


    End Sub


    Private Sub frmAddressBook_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Try
            Me.txbExportFrom.Width = Me.Width - 70
            Me.txbExportTo.Width = Me.Width - 70
            Me.txbExportCC.Width = Me.Width - 70
            Me.txbExportBCC.Width = Me.Width - 70
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try

    End Sub

    Private Sub cmbExportABook_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbExportABook.Click
        Try
            SaveFileDialog1.Filter = "Text (*.txt)|*.txt"
            SaveFileDialog1.Title = "Select folder and filename"
            If SaveFileDialog1.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
                Dim intColIndex As Integer
                Dim intRowIndex As Integer

                If dgvAddressBook.RowCount > 0 Then
                    Dim objWriter As New System.IO.StreamWriter(SaveFileDialog1.FileName)
                    For intRowIndex = 0 To dgvAddressBook.RowCount - 1
                        If dgvAddressBook.Item(0, intRowIndex).Value <> "" Or dgvAddressBook.Item(1, intRowIndex).Value <> "" Or dgvAddressBook.Item(2, intRowIndex).Value <> "" Or dgvAddressBook.Item(3, intRowIndex).Value <> "" Then
                            For intColIndex = 0 To dgvAddressBook.ColumnCount - 1
                                objWriter.Write(dgvAddressBook.Item(intColIndex, intRowIndex).Value & vbCrLf)
                            Next (intColIndex)
                        End If
                    Next intRowIndex
                    objWriter.Close()
                End If
            End If
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try

    End Sub


    Private Sub cmdImportAbook_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbImportAbook.Click
        Try
            ImportBook(True)
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try

    End Sub

    Private Sub cmbAppendABook_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAppendABook.Click
        Try
            ImportBook(False)
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try

    End Sub

    Private Sub ImportBook(ByVal booClearBook As Boolean)
        Try
            OpenFileDialog1.Filter = "Text|*.txt"
            If OpenFileDialog1.ShowDialog() <> Windows.Forms.DialogResult.Cancel Then
                If FileExists(OpenFileDialog1.FileName) = True Then
                    If booClearBook = True Then
                        dgvAddressBook.Rows.Clear()
                    End If

                    Dim objReader As New System.IO.StreamReader(OpenFileDialog1.FileName)
                    Do
                        dgvAddressBook.Rows.Add(objReader.ReadLine(), objReader.ReadLine(), objReader.ReadLine(), objReader.ReadLine())
                    Loop Until objReader.EndOfStream
                    objReader.Close()
                End If
            End If
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try

    End Sub
End Class