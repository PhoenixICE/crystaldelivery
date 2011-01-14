<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddressBook
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAddressBook))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer
        Me.cmbAppendABook = New System.Windows.Forms.Button
        Me.cmbImportAbook = New System.Windows.Forms.Button
        Me.cmbExportABook = New System.Windows.Forms.Button
        Me.dgvAddressBook = New System.Windows.Forms.DataGridView
        Me.FirstName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LastName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Company = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colExportDays = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cmbTo = New System.Windows.Forms.Button
        Me.cmbCC = New System.Windows.Forms.Button
        Me.cmbBCC = New System.Windows.Forms.Button
        Me.cmbFrom = New System.Windows.Forms.Button
        Me.txbExportFrom = New System.Windows.Forms.TextBox
        Me.txbExportCC = New System.Windows.Forms.TextBox
        Me.txbExportBCC = New System.Windows.Forms.TextBox
        Me.txbExportTo = New System.Windows.Forms.TextBox
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.dgvAddressBook, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.SplitContainer2)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(222, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.SplitContainer1.Panel2.Controls.Add(Me.cmbTo)
        Me.SplitContainer1.Panel2.Controls.Add(Me.cmbCC)
        Me.SplitContainer1.Panel2.Controls.Add(Me.cmbBCC)
        Me.SplitContainer1.Panel2.Controls.Add(Me.cmbFrom)
        Me.SplitContainer1.Panel2.Controls.Add(Me.txbExportFrom)
        Me.SplitContainer1.Panel2.Controls.Add(Me.txbExportCC)
        Me.SplitContainer1.Panel2.Controls.Add(Me.txbExportBCC)
        Me.SplitContainer1.Panel2.Controls.Add(Me.txbExportTo)
        Me.SplitContainer1.Size = New System.Drawing.Size(753, 441)
        Me.SplitContainer1.SplitterDistance = 323
        Me.SplitContainer1.TabIndex = 5
        '
        'SplitContainer2
        '
        Me.SplitContainer2.BackColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(222, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(222, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.SplitContainer2.Panel1.Controls.Add(Me.cmbAppendABook)
        Me.SplitContainer2.Panel1.Controls.Add(Me.cmbImportAbook)
        Me.SplitContainer2.Panel1.Controls.Add(Me.cmbExportABook)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.dgvAddressBook)
        Me.SplitContainer2.Size = New System.Drawing.Size(753, 323)
        Me.SplitContainer2.SplitterDistance = 35
        Me.SplitContainer2.TabIndex = 6
        '
        'cmbAppendABook
        '
        Me.cmbAppendABook.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbAppendABook.Location = New System.Drawing.Point(176, 3)
        Me.cmbAppendABook.Name = "cmbAppendABook"
        Me.cmbAppendABook.Size = New System.Drawing.Size(164, 31)
        Me.cmbAppendABook.TabIndex = 21
        Me.cmbAppendABook.Text = "Append Address Book"
        Me.cmbAppendABook.UseVisualStyleBackColor = True
        '
        'cmbImportAbook
        '
        Me.cmbImportAbook.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbImportAbook.Location = New System.Drawing.Point(3, 3)
        Me.cmbImportAbook.Name = "cmbImportAbook"
        Me.cmbImportAbook.Size = New System.Drawing.Size(164, 31)
        Me.cmbImportAbook.TabIndex = 19
        Me.cmbImportAbook.Text = "Import Address Book"
        Me.cmbImportAbook.UseVisualStyleBackColor = True
        '
        'cmbExportABook
        '
        Me.cmbExportABook.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbExportABook.Location = New System.Drawing.Point(346, 3)
        Me.cmbExportABook.Name = "cmbExportABook"
        Me.cmbExportABook.Size = New System.Drawing.Size(164, 31)
        Me.cmbExportABook.TabIndex = 20
        Me.cmbExportABook.Text = "Export Address Book"
        Me.cmbExportABook.UseVisualStyleBackColor = True
        '
        'dgvAddressBook
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro
        Me.dgvAddressBook.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvAddressBook.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(103, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(103, Byte), Integer))
        Me.dgvAddressBook.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvAddressBook.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.SlateGray
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Red
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvAddressBook.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvAddressBook.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAddressBook.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FirstName, Me.LastName, Me.Company, Me.colExportDays})
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.IndianRed
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvAddressBook.DefaultCellStyle = DataGridViewCellStyle7
        Me.dgvAddressBook.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvAddressBook.EnableHeadersVisualStyles = False
        Me.dgvAddressBook.Location = New System.Drawing.Point(0, 0)
        Me.dgvAddressBook.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.dgvAddressBook.Name = "dgvAddressBook"
        Me.dgvAddressBook.RowHeadersVisible = False
        Me.dgvAddressBook.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.IndianRed
        Me.dgvAddressBook.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White
        Me.dgvAddressBook.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvAddressBook.Size = New System.Drawing.Size(753, 284)
        Me.dgvAddressBook.TabIndex = 5
        '
        'FirstName
        '
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Cornsilk
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        Me.FirstName.DefaultCellStyle = DataGridViewCellStyle3
        Me.FirstName.HeaderText = "First Name"
        Me.FirstName.Name = "FirstName"
        Me.FirstName.Width = 150
        '
        'LastName
        '
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Cornsilk
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        Me.LastName.DefaultCellStyle = DataGridViewCellStyle4
        Me.LastName.HeaderText = "Last Name"
        Me.LastName.Name = "LastName"
        Me.LastName.Width = 150
        '
        'Company
        '
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Verdana", 8.25!)
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Cornsilk
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        Me.Company.DefaultCellStyle = DataGridViewCellStyle5
        Me.Company.HeaderText = "Company"
        Me.Company.Name = "Company"
        Me.Company.Width = 150
        '
        'colExportDays
        '
        Me.colExportDays.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Verdana", 8.25!)
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Cornsilk
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        Me.colExportDays.DefaultCellStyle = DataGridViewCellStyle6
        Me.colExportDays.HeaderText = "Email Address"
        Me.colExportDays.MinimumWidth = 50
        Me.colExportDays.Name = "colExportDays"
        '
        'cmbTo
        '
        Me.cmbTo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTo.Location = New System.Drawing.Point(4, 33)
        Me.cmbTo.Name = "cmbTo"
        Me.cmbTo.Size = New System.Drawing.Size(45, 20)
        Me.cmbTo.TabIndex = 18
        Me.cmbTo.Text = "To"
        Me.cmbTo.UseVisualStyleBackColor = True
        '
        'cmbCC
        '
        Me.cmbCC.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCC.Location = New System.Drawing.Point(4, 59)
        Me.cmbCC.Name = "cmbCC"
        Me.cmbCC.Size = New System.Drawing.Size(45, 20)
        Me.cmbCC.TabIndex = 17
        Me.cmbCC.Text = "CC"
        Me.cmbCC.UseVisualStyleBackColor = True
        '
        'cmbBCC
        '
        Me.cmbBCC.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbBCC.Location = New System.Drawing.Point(3, 85)
        Me.cmbBCC.Name = "cmbBCC"
        Me.cmbBCC.Size = New System.Drawing.Size(45, 20)
        Me.cmbBCC.TabIndex = 16
        Me.cmbBCC.Text = "BCC"
        Me.cmbBCC.UseVisualStyleBackColor = True
        '
        'cmbFrom
        '
        Me.cmbFrom.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbFrom.Location = New System.Drawing.Point(4, 7)
        Me.cmbFrom.Name = "cmbFrom"
        Me.cmbFrom.Size = New System.Drawing.Size(45, 20)
        Me.cmbFrom.TabIndex = 15
        Me.cmbFrom.Text = "From"
        Me.cmbFrom.UseVisualStyleBackColor = True
        '
        'txbExportFrom
        '
        Me.txbExportFrom.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txbExportFrom.Location = New System.Drawing.Point(55, 8)
        Me.txbExportFrom.Name = "txbExportFrom"
        Me.txbExportFrom.Size = New System.Drawing.Size(534, 21)
        Me.txbExportFrom.TabIndex = 11
        '
        'txbExportCC
        '
        Me.txbExportCC.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txbExportCC.Location = New System.Drawing.Point(55, 60)
        Me.txbExportCC.Name = "txbExportCC"
        Me.txbExportCC.Size = New System.Drawing.Size(534, 21)
        Me.txbExportCC.TabIndex = 13
        '
        'txbExportBCC
        '
        Me.txbExportBCC.AcceptsReturn = True
        Me.txbExportBCC.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txbExportBCC.Location = New System.Drawing.Point(54, 86)
        Me.txbExportBCC.Name = "txbExportBCC"
        Me.txbExportBCC.Size = New System.Drawing.Size(534, 21)
        Me.txbExportBCC.TabIndex = 14
        '
        'txbExportTo
        '
        Me.txbExportTo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txbExportTo.Location = New System.Drawing.Point(55, 34)
        Me.txbExportTo.Name = "txbExportTo"
        Me.txbExportTo.Size = New System.Drawing.Size(534, 21)
        Me.txbExportTo.TabIndex = 12
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'frmAddressBook
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(753, 441)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(100, 100)
        Me.Name = "frmAddressBook"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Address Book"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.ResumeLayout(False)
        CType(Me.dgvAddressBook, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents dgvAddressBook As System.Windows.Forms.DataGridView
    Friend WithEvents txbExportFrom As System.Windows.Forms.TextBox
    Friend WithEvents txbExportCC As System.Windows.Forms.TextBox
    Friend WithEvents txbExportBCC As System.Windows.Forms.TextBox
    Friend WithEvents txbExportTo As System.Windows.Forms.TextBox
    Friend WithEvents cmbTo As System.Windows.Forms.Button
    Friend WithEvents cmbCC As System.Windows.Forms.Button
    Friend WithEvents cmbBCC As System.Windows.Forms.Button
    Friend WithEvents cmbFrom As System.Windows.Forms.Button
    Friend WithEvents cmbExportABook As System.Windows.Forms.Button
    Friend WithEvents cmbImportAbook As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents cmbAppendABook As System.Windows.Forms.Button
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents FirstName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LastName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Company As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colExportDays As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
