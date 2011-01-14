<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCalendar
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCalendar))
        Me.calCalendar = New System.Windows.Forms.MonthCalendar
        Me.txbSelectedDates = New System.Windows.Forms.TextBox
        Me.cmbAddDate = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'calCalendar
        '
        Me.calCalendar.Location = New System.Drawing.Point(18, 18)
        Me.calCalendar.MaxSelectionCount = 1
        Me.calCalendar.Name = "calCalendar"
        Me.calCalendar.TabIndex = 1
        '
        'txbSelectedDates
        '
        Me.txbSelectedDates.Location = New System.Drawing.Point(18, 222)
        Me.txbSelectedDates.Multiline = True
        Me.txbSelectedDates.Name = "txbSelectedDates"
        Me.txbSelectedDates.Size = New System.Drawing.Size(178, 47)
        Me.txbSelectedDates.TabIndex = 2
        '
        'cmbAddDate
        '
        Me.cmbAddDate.Location = New System.Drawing.Point(64, 185)
        Me.cmbAddDate.Name = "cmbAddDate"
        Me.cmbAddDate.Size = New System.Drawing.Size(91, 29)
        Me.cmbAddDate.TabIndex = 3
        Me.cmbAddDate.Text = "Add Date"
        Me.cmbAddDate.UseVisualStyleBackColor = True
        '
        'frmCalendar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(219, 285)
        Me.Controls.Add(Me.cmbAddDate)
        Me.Controls.Add(Me.txbSelectedDates)
        Me.Controls.Add(Me.calCalendar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCalendar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Calendar"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents calCalendar As System.Windows.Forms.MonthCalendar
    Friend WithEvents txbSelectedDates As System.Windows.Forms.TextBox
    Friend WithEvents cmbAddDate As System.Windows.Forms.Button
End Class
