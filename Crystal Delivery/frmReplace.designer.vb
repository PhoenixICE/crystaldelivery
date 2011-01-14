<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReplace
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReplace))
        Me.cmbExit = New System.Windows.Forms.Button
        Me.cmbReplace = New System.Windows.Forms.Button
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lblNewString = New System.Windows.Forms.Label
        Me.txbNewString = New System.Windows.Forms.TextBox
        Me.lblCurrentString = New System.Windows.Forms.Label
        Me.txbCurrentString = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.chkAll = New System.Windows.Forms.CheckBox
        Me.chkExEmail = New System.Windows.Forms.CheckBox
        Me.chkExPrint = New System.Windows.Forms.CheckBox
        Me.chkExDir = New System.Windows.Forms.CheckBox
        Me.chkConn = New System.Windows.Forms.CheckBox
        Me.chkParameters = New System.Windows.Forms.CheckBox
        Me.chkSchedule = New System.Windows.Forms.CheckBox
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmbExit
        '
        Me.cmbExit.Location = New System.Drawing.Point(12, 353)
        Me.cmbExit.Name = "cmbExit"
        Me.cmbExit.Size = New System.Drawing.Size(111, 24)
        Me.cmbExit.TabIndex = 4
        Me.cmbExit.Text = "Exit"
        Me.cmbExit.UseVisualStyleBackColor = True
        '
        'cmbReplace
        '
        Me.cmbReplace.Location = New System.Drawing.Point(246, 353)
        Me.cmbReplace.Name = "cmbReplace"
        Me.cmbReplace.Size = New System.Drawing.Size(111, 24)
        Me.cmbReplace.TabIndex = 5
        Me.cmbReplace.Text = "Replace"
        Me.cmbReplace.UseVisualStyleBackColor = True
        '
        'RichTextBox1
        '
        Me.RichTextBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(222, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.RichTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.RichTextBox1.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RichTextBox1.ForeColor = System.Drawing.Color.Red
        Me.RichTextBox1.Location = New System.Drawing.Point(17, 12)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(351, 45)
        Me.RichTextBox1.TabIndex = 6
        Me.RichTextBox1.Text = "Backup the reports list prior to performing a text replace"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblNewString)
        Me.GroupBox1.Controls.Add(Me.txbNewString)
        Me.GroupBox1.Controls.Add(Me.lblCurrentString)
        Me.GroupBox1.Controls.Add(Me.txbCurrentString)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 63)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(350, 131)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Text Strings"
        '
        'lblNewString
        '
        Me.lblNewString.AutoSize = True
        Me.lblNewString.Location = New System.Drawing.Point(7, 75)
        Me.lblNewString.Name = "lblNewString"
        Me.lblNewString.Size = New System.Drawing.Size(67, 13)
        Me.lblNewString.TabIndex = 7
        Me.lblNewString.Text = "New Value"
        '
        'txbNewString
        '
        Me.txbNewString.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txbNewString.Location = New System.Drawing.Point(6, 91)
        Me.txbNewString.Name = "txbNewString"
        Me.txbNewString.Size = New System.Drawing.Size(332, 21)
        Me.txbNewString.TabIndex = 6
        '
        'lblCurrentString
        '
        Me.lblCurrentString.AutoSize = True
        Me.lblCurrentString.Location = New System.Drawing.Point(7, 25)
        Me.lblCurrentString.Name = "lblCurrentString"
        Me.lblCurrentString.Size = New System.Drawing.Size(87, 13)
        Me.lblCurrentString.TabIndex = 5
        Me.lblCurrentString.Text = "Current Value"
        '
        'txbCurrentString
        '
        Me.txbCurrentString.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txbCurrentString.Location = New System.Drawing.Point(6, 41)
        Me.txbCurrentString.Name = "txbCurrentString"
        Me.txbCurrentString.Size = New System.Drawing.Size(332, 21)
        Me.txbCurrentString.TabIndex = 4
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkAll)
        Me.GroupBox2.Controls.Add(Me.chkExEmail)
        Me.GroupBox2.Controls.Add(Me.chkExPrint)
        Me.GroupBox2.Controls.Add(Me.chkExDir)
        Me.GroupBox2.Controls.Add(Me.chkConn)
        Me.GroupBox2.Controls.Add(Me.chkParameters)
        Me.GroupBox2.Controls.Add(Me.chkSchedule)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 209)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(350, 129)
        Me.GroupBox2.TabIndex = 8
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Search Areas"
        '
        'chkAll
        '
        Me.chkAll.AutoSize = True
        Me.chkAll.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAll.Location = New System.Drawing.Point(117, 106)
        Me.chkAll.Name = "chkAll"
        Me.chkAll.Size = New System.Drawing.Size(69, 17)
        Me.chkAll.TabIndex = 7
        Me.chkAll.Text = "All Text"
        Me.chkAll.UseVisualStyleBackColor = True
        '
        'chkExEmail
        '
        Me.chkExEmail.AutoSize = True
        Me.chkExEmail.Location = New System.Drawing.Point(210, 52)
        Me.chkExEmail.Name = "chkExEmail"
        Me.chkExEmail.Size = New System.Drawing.Size(98, 17)
        Me.chkExEmail.TabIndex = 5
        Me.chkExEmail.Text = "Export Email"
        Me.chkExEmail.UseVisualStyleBackColor = True
        '
        'chkExPrint
        '
        Me.chkExPrint.AutoSize = True
        Me.chkExPrint.Location = New System.Drawing.Point(210, 29)
        Me.chkExPrint.Name = "chkExPrint"
        Me.chkExPrint.Size = New System.Drawing.Size(111, 17)
        Me.chkExPrint.TabIndex = 4
        Me.chkExPrint.Text = "Export Printers"
        Me.chkExPrint.UseVisualStyleBackColor = True
        '
        'chkExDir
        '
        Me.chkExDir.AutoSize = True
        Me.chkExDir.Location = New System.Drawing.Point(209, 75)
        Me.chkExDir.Name = "chkExDir"
        Me.chkExDir.Size = New System.Drawing.Size(129, 17)
        Me.chkExDir.TabIndex = 3
        Me.chkExDir.Text = "Export Directories"
        Me.chkExDir.UseVisualStyleBackColor = True
        '
        'chkConn
        '
        Me.chkConn.AutoSize = True
        Me.chkConn.Location = New System.Drawing.Point(16, 75)
        Me.chkConn.Name = "chkConn"
        Me.chkConn.Size = New System.Drawing.Size(96, 17)
        Me.chkConn.TabIndex = 2
        Me.chkConn.Text = "Connections"
        Me.chkConn.UseVisualStyleBackColor = True
        '
        'chkParameters
        '
        Me.chkParameters.AutoSize = True
        Me.chkParameters.Location = New System.Drawing.Point(16, 52)
        Me.chkParameters.Name = "chkParameters"
        Me.chkParameters.Size = New System.Drawing.Size(92, 17)
        Me.chkParameters.TabIndex = 1
        Me.chkParameters.Text = "Parameters"
        Me.chkParameters.UseVisualStyleBackColor = True
        '
        'chkSchedule
        '
        Me.chkSchedule.AutoSize = True
        Me.chkSchedule.Location = New System.Drawing.Point(16, 29)
        Me.chkSchedule.Name = "chkSchedule"
        Me.chkSchedule.Size = New System.Drawing.Size(128, 17)
        Me.chkSchedule.TabIndex = 0
        Me.chkSchedule.Text = "Schedule Settings"
        Me.chkSchedule.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(129, 364)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(111, 13)
        Me.ProgressBar1.Step = 1
        Me.ProgressBar1.TabIndex = 9
        '
        'frmReplace
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(222, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(374, 391)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.cmbReplace)
        Me.Controls.Add(Me.cmbExit)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmReplace"
        Me.Text = "Replace Text"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmbExit As System.Windows.Forms.Button
    Friend WithEvents cmbReplace As System.Windows.Forms.Button
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblNewString As System.Windows.Forms.Label
    Friend WithEvents txbNewString As System.Windows.Forms.TextBox
    Friend WithEvents lblCurrentString As System.Windows.Forms.Label
    Friend WithEvents txbCurrentString As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents chkConn As System.Windows.Forms.CheckBox
    Friend WithEvents chkParameters As System.Windows.Forms.CheckBox
    Friend WithEvents chkSchedule As System.Windows.Forms.CheckBox
    Friend WithEvents chkExEmail As System.Windows.Forms.CheckBox
    Friend WithEvents chkExPrint As System.Windows.Forms.CheckBox
    Friend WithEvents chkExDir As System.Windows.Forms.CheckBox
    Friend WithEvents chkAll As System.Windows.Forms.CheckBox
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
End Class
