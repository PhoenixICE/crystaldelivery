<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLogViewer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLogViewer))
        Me.dgvLogFile = New System.Windows.Forms.DataGridView
        Me.colDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colErrorMessage = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.dgvLogFile, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvLogFile
        '
        Me.dgvLogFile.AllowUserToAddRows = False
        Me.dgvLogFile.AllowUserToDeleteRows = False
        Me.dgvLogFile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLogFile.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colDate, Me.colErrorMessage})
        Me.dgvLogFile.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvLogFile.Location = New System.Drawing.Point(0, 0)
        Me.dgvLogFile.Name = "dgvLogFile"
        Me.dgvLogFile.RowHeadersVisible = False
        Me.dgvLogFile.Size = New System.Drawing.Size(800, 532)
        Me.dgvLogFile.TabIndex = 1
        '
        'colDate
        '
        Me.colDate.HeaderText = "Date"
        Me.colDate.Name = "colDate"
        Me.colDate.Width = 150
        '
        'colErrorMessage
        '
        Me.colErrorMessage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colErrorMessage.HeaderText = "Error Message"
        Me.colErrorMessage.Name = "colErrorMessage"
        '
        'frmLogViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 532)
        Me.Controls.Add(Me.dgvLogFile)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmLogViewer"
        Me.Text = "Log Viewer"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgvLogFile, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvLogFile As System.Windows.Forms.DataGridView
    Friend WithEvents colDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colErrorMessage As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
