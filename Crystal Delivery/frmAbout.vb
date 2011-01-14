Public NotInheritable Class frmAbout

    Private Sub AboutBox1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'Set the title of the form.
            Dim ApplicationTitle As String
            If My.Application.Info.Title <> "" Then
                ApplicationTitle = My.Application.Info.Title
            Else
                ApplicationTitle = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
            End If
            Me.Text = String.Format("About {0}", ApplicationTitle)
            'Initialize all of the text displayed on the About Box.
            'Customize the application's assembly information in the "Application" pane of the project 
            'properties dialog (under the "Project" menu).
            Me.lblProductName.Text = My.Application.Info.ProductName
            Me.lblVersion.Text = String.Format("Version {0}", My.Application.Info.Version.ToString)
            Me.lblCopyright.Text = My.Application.Info.Copyright
            Me.lblCompanyName.Text = My.Application.Info.CompanyName
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try

    End Sub

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
        Try
            Me.Close()
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try

    End Sub

    Private Sub LogoPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            System.Diagnostics.Process.Start("https://www.paypal.com/xclick/business=groffautomation@gmail.com")
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try

    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Try
            System.Diagnostics.Process.Start("https://www.paypal.com/xclick/business=groffautomation@gmail.com")
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try

    End Sub

    Private Sub LinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Try
            System.Diagnostics.Process.Start(App_Path() & "DonationForm.pdf")
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
        End Try

    End Sub
End Class
