<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripProgressBar1 = New System.Windows.Forms.ToolStripProgressBar
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.ProgramToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AutoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SendToTrayToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ScheduleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CopyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.ExportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmSMTPServer = New System.Windows.Forms.ToolStripMenuItem
        Me.txtSMTP = New System.Windows.Forms.ToolStripTextBox
        Me.txtUserID = New System.Windows.Forms.ToolStripTextBox
        Me.txtUserPassword = New System.Windows.Forms.ToolStripTextBox
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.tsmUseSSL = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.BackupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.RestoreToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator
        Me.ReplaceStringToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmAutoOnStart = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmTrayOnStart = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmStartWithWindows = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmLangPack = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator
        Me.tsmHideAllButtons = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmIconSettings = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmScheduleBTN = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmCopyBTN = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmDeleteBTN = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmExportBTN = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmViewBTN = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmPrintBTN = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmToTrayBTN = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmAutoDeliverBTN = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.tsmTrigger = New System.Windows.Forms.ToolStripMenuItem
        Me.txtTriggerFolder = New System.Windows.Forms.ToolStripTextBox
        Me.SelectTriggerFolderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ClearTriggerFolderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ContentsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ViewLogToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.tsbSchedule = New System.Windows.Forms.ToolStripButton
        Me.tsbCopy = New System.Windows.Forms.ToolStripButton
        Me.tsbDelete = New System.Windows.Forms.ToolStripButton
        Me.tsbExport = New System.Windows.Forms.ToolStripButton
        Me.tsbView = New System.Windows.Forms.ToolStripButton
        Me.tsbPrint = New System.Windows.Forms.ToolStripButton
        Me.tsbToTray = New System.Windows.Forms.ToolStripButton
        Me.tsbAutoDeliver = New System.Windows.Forms.ToolStripButton
        Me.dgvScheduleList = New System.Windows.Forms.DataGridView
        Me.colID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colReportName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colExportInterval = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colExportDays = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colExportTime = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colRunHistory = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colReportPath = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ContextMenuStrip2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tsmSchedule = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmCopy = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmDelete = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmExport = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmView = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmPrint = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator
        Me.SendToTrayToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.DeliveryModeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.tsmRestore = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmAutoDeliver = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmExit = New System.Windows.Forms.ToolStripMenuItem
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ContextMenuStrip3 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tsmAutoDelivery = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmRestorePanel = New System.Windows.Forms.ToolStripMenuItem
        Me.StatusStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.dgvScheduleList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip2.SuspendLayout()
        Me.ContextMenuStrip3.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(222, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.StatusStrip1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripProgressBar1, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel3})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 500)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 17, 0)
        Me.StatusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.StatusStrip1.Size = New System.Drawing.Size(990, 22)
        Me.StatusStrip1.TabIndex = 0
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(222, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.ToolStripStatusLabel1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel1.Image = CType(resources.GetObject("ToolStripStatusLabel1.Image"), System.Drawing.Image)
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Padding = New System.Windows.Forms.Padding(0, 0, 100, 0)
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(221, 17)
        Me.ToolStripStatusLabel1.Text = "Groff Automation"
        '
        'ToolStripProgressBar1
        '
        Me.ToolStripProgressBar1.Name = "ToolStripProgressBar1"
        Me.ToolStripProgressBar1.Padding = New System.Windows.Forms.Padding(10, 0, 10, 0)
        Me.ToolStripProgressBar1.Size = New System.Drawing.Size(20, 16)
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.BackColor = System.Drawing.Color.RosyBrown
        Me.ToolStripStatusLabel2.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.ToolStripStatusLabel2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(530, 17)
        Me.ToolStripStatusLabel2.Spring = True
        Me.ToolStripStatusLabel2.Text = "Manual Mode"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(222, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.ToolStripStatusLabel3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Padding = New System.Windows.Forms.Padding(100, 0, 0, 0)
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(199, 17)
        Me.ToolStripStatusLabel3.Text = "Version Number"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(222, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.MenuStrip1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProgramToolStripMenuItem, Me.ReportToolStripMenuItem, Me.ToolStripMenuItem1, Me.ToolsToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(7, 2, 0, 2)
        Me.MenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.MenuStrip1.Size = New System.Drawing.Size(990, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ProgramToolStripMenuItem
        '
        Me.ProgramToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AutoToolStripMenuItem, Me.SendToTrayToolStripMenuItem, Me.ToolStripSeparator5, Me.ExitToolStripMenuItem})
        Me.ProgramToolStripMenuItem.Name = "ProgramToolStripMenuItem"
        Me.ProgramToolStripMenuItem.Size = New System.Drawing.Size(68, 20)
        Me.ProgramToolStripMenuItem.Text = "Program"
        '
        'AutoToolStripMenuItem
        '
        Me.AutoToolStripMenuItem.Image = CType(resources.GetObject("AutoToolStripMenuItem.Image"), System.Drawing.Image)
        Me.AutoToolStripMenuItem.Name = "AutoToolStripMenuItem"
        Me.AutoToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.AutoToolStripMenuItem.Text = "Delivery Mode"
        '
        'SendToTrayToolStripMenuItem
        '
        Me.SendToTrayToolStripMenuItem.Image = CType(resources.GetObject("SendToTrayToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SendToTrayToolStripMenuItem.Name = "SendToTrayToolStripMenuItem"
        Me.SendToTrayToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.SendToTrayToolStripMenuItem.Text = "Send To Tray"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(164, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Image = CType(resources.GetObject("ExitToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'ReportToolStripMenuItem
        '
        Me.ReportToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ScheduleToolStripMenuItem, Me.CopyToolStripMenuItem, Me.DeleteToolStripMenuItem, Me.ToolStripSeparator3, Me.ExportToolStripMenuItem, Me.ViewToolStripMenuItem, Me.PrintToolStripMenuItem})
        Me.ReportToolStripMenuItem.Name = "ReportToolStripMenuItem"
        Me.ReportToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.ReportToolStripMenuItem.Text = "Report"
        '
        'ScheduleToolStripMenuItem
        '
        Me.ScheduleToolStripMenuItem.Image = CType(resources.GetObject("ScheduleToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ScheduleToolStripMenuItem.Name = "ScheduleToolStripMenuItem"
        Me.ScheduleToolStripMenuItem.Size = New System.Drawing.Size(137, 22)
        Me.ScheduleToolStripMenuItem.Text = "Schedule"
        '
        'CopyToolStripMenuItem
        '
        Me.CopyToolStripMenuItem.Image = CType(resources.GetObject("CopyToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
        Me.CopyToolStripMenuItem.Size = New System.Drawing.Size(137, 22)
        Me.CopyToolStripMenuItem.Text = "Copy"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Image = CType(resources.GetObject("DeleteToolStripMenuItem.Image"), System.Drawing.Image)
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(137, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(134, 6)
        '
        'ExportToolStripMenuItem
        '
        Me.ExportToolStripMenuItem.Image = CType(resources.GetObject("ExportToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ExportToolStripMenuItem.Name = "ExportToolStripMenuItem"
        Me.ExportToolStripMenuItem.Size = New System.Drawing.Size(137, 22)
        Me.ExportToolStripMenuItem.Text = "Export"
        '
        'ViewToolStripMenuItem
        '
        Me.ViewToolStripMenuItem.Image = CType(resources.GetObject("ViewToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        Me.ViewToolStripMenuItem.Size = New System.Drawing.Size(137, 22)
        Me.ViewToolStripMenuItem.Text = "View"
        '
        'PrintToolStripMenuItem
        '
        Me.PrintToolStripMenuItem.Image = CType(resources.GetObject("PrintToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        Me.PrintToolStripMenuItem.Size = New System.Drawing.Size(137, 22)
        Me.PrintToolStripMenuItem.Text = "Print"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmSMTPServer, Me.ToolStripSeparator1, Me.BackupToolStripMenuItem, Me.RestoreToolStripMenuItem, Me.ToolStripSeparator6, Me.ReplaceStringToolStripMenuItem})
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(49, 20)
        Me.ToolStripMenuItem1.Text = "Tools"
        '
        'tsmSMTPServer
        '
        Me.tsmSMTPServer.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.txtSMTP, Me.txtUserID, Me.txtUserPassword, Me.ToolStripSeparator4, Me.tsmUseSSL})
        Me.tsmSMTPServer.Image = CType(resources.GetObject("tsmSMTPServer.Image"), System.Drawing.Image)
        Me.tsmSMTPServer.Name = "tsmSMTPServer"
        Me.tsmSMTPServer.Size = New System.Drawing.Size(194, 22)
        Me.tsmSMTPServer.Text = "Mail Settings"
        '
        'txtSMTP
        '
        Me.txtSMTP.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSMTP.ForeColor = System.Drawing.SystemColors.GrayText
        Me.txtSMTP.Name = "txtSMTP"
        Me.txtSMTP.Size = New System.Drawing.Size(300, 21)
        Me.txtSMTP.Text = "Enter SMTP Server"
        '
        'txtUserID
        '
        Me.txtUserID.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUserID.ForeColor = System.Drawing.SystemColors.GrayText
        Me.txtUserID.Name = "txtUserID"
        Me.txtUserID.Size = New System.Drawing.Size(300, 21)
        Me.txtUserID.Text = "Enter User ID"
        '
        'txtUserPassword
        '
        Me.txtUserPassword.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUserPassword.ForeColor = System.Drawing.SystemColors.GrayText
        Me.txtUserPassword.Name = "txtUserPassword"
        Me.txtUserPassword.Size = New System.Drawing.Size(300, 21)
        Me.txtUserPassword.Text = "Enter Password"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(357, 6)
        Me.ToolStripSeparator4.Visible = False
        '
        'tsmUseSSL
        '
        Me.tsmUseSSL.CheckOnClick = True
        Me.tsmUseSSL.Name = "tsmUseSSL"
        Me.tsmUseSSL.Size = New System.Drawing.Size(360, 22)
        Me.tsmUseSSL.Text = "Use Secure Sockets Layer (SSL)"
        Me.tsmUseSSL.Visible = False
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(191, 6)
        '
        'BackupToolStripMenuItem
        '
        Me.BackupToolStripMenuItem.Image = CType(resources.GetObject("BackupToolStripMenuItem.Image"), System.Drawing.Image)
        Me.BackupToolStripMenuItem.Name = "BackupToolStripMenuItem"
        Me.BackupToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.BackupToolStripMenuItem.Text = "Backup Report List"
        '
        'RestoreToolStripMenuItem
        '
        Me.RestoreToolStripMenuItem.Image = CType(resources.GetObject("RestoreToolStripMenuItem.Image"), System.Drawing.Image)
        Me.RestoreToolStripMenuItem.Name = "RestoreToolStripMenuItem"
        Me.RestoreToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.RestoreToolStripMenuItem.Text = "Restore Report List"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(191, 6)
        '
        'ReplaceStringToolStripMenuItem
        '
        Me.ReplaceStringToolStripMenuItem.Image = CType(resources.GetObject("ReplaceStringToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ReplaceStringToolStripMenuItem.Name = "ReplaceStringToolStripMenuItem"
        Me.ReplaceStringToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.ReplaceStringToolStripMenuItem.Text = "Replace Text"
        '
        'ToolsToolStripMenuItem
        '
        Me.ToolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmAutoOnStart, Me.tsmTrayOnStart, Me.tsmStartWithWindows, Me.tsmLangPack, Me.ToolStripSeparator8, Me.tsmHideAllButtons, Me.tsmIconSettings, Me.ToolStripSeparator2, Me.tsmTrigger})
        Me.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem"
        Me.ToolsToolStripMenuItem.Size = New System.Drawing.Size(62, 20)
        Me.ToolsToolStripMenuItem.Text = "Options"
        '
        'tsmAutoOnStart
        '
        Me.tsmAutoOnStart.CheckOnClick = True
        Me.tsmAutoOnStart.Name = "tsmAutoOnStart"
        Me.tsmAutoOnStart.Size = New System.Drawing.Size(209, 22)
        Me.tsmAutoOnStart.Text = "Auto Deliver on Start"
        '
        'tsmTrayOnStart
        '
        Me.tsmTrayOnStart.CheckOnClick = True
        Me.tsmTrayOnStart.Name = "tsmTrayOnStart"
        Me.tsmTrayOnStart.Size = New System.Drawing.Size(209, 22)
        Me.tsmTrayOnStart.Text = "Send to Tray on Start"
        '
        'tsmStartWithWindows
        '
        Me.tsmStartWithWindows.CheckOnClick = True
        Me.tsmStartWithWindows.Name = "tsmStartWithWindows"
        Me.tsmStartWithWindows.Size = New System.Drawing.Size(209, 22)
        Me.tsmStartWithWindows.Text = "Start with Windows"
        '
        'tsmLangPack
        '
        Me.tsmLangPack.CheckOnClick = True
        Me.tsmLangPack.Name = "tsmLangPack"
        Me.tsmLangPack.Size = New System.Drawing.Size(209, 22)
        Me.tsmLangPack.Text = "Use Language Pack"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(206, 6)
        '
        'tsmHideAllButtons
        '
        Me.tsmHideAllButtons.CheckOnClick = True
        Me.tsmHideAllButtons.Name = "tsmHideAllButtons"
        Me.tsmHideAllButtons.Size = New System.Drawing.Size(209, 22)
        Me.tsmHideAllButtons.Text = "Hide All Buttons"
        '
        'tsmIconSettings
        '
        Me.tsmIconSettings.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmScheduleBTN, Me.tsmCopyBTN, Me.tsmDeleteBTN, Me.tsmExportBTN, Me.tsmViewBTN, Me.tsmPrintBTN, Me.tsmToTrayBTN, Me.tsmAutoDeliverBTN})
        Me.tsmIconSettings.Name = "tsmIconSettings"
        Me.tsmIconSettings.Size = New System.Drawing.Size(209, 22)
        Me.tsmIconSettings.Text = "Visible Buttons"
        '
        'tsmScheduleBTN
        '
        Me.tsmScheduleBTN.Checked = True
        Me.tsmScheduleBTN.CheckOnClick = True
        Me.tsmScheduleBTN.CheckState = System.Windows.Forms.CheckState.Checked
        Me.tsmScheduleBTN.Name = "tsmScheduleBTN"
        Me.tsmScheduleBTN.Size = New System.Drawing.Size(167, 22)
        Me.tsmScheduleBTN.Text = "Schedule"
        '
        'tsmCopyBTN
        '
        Me.tsmCopyBTN.Checked = True
        Me.tsmCopyBTN.CheckOnClick = True
        Me.tsmCopyBTN.CheckState = System.Windows.Forms.CheckState.Checked
        Me.tsmCopyBTN.Name = "tsmCopyBTN"
        Me.tsmCopyBTN.Size = New System.Drawing.Size(167, 22)
        Me.tsmCopyBTN.Text = "Copy"
        '
        'tsmDeleteBTN
        '
        Me.tsmDeleteBTN.Checked = True
        Me.tsmDeleteBTN.CheckOnClick = True
        Me.tsmDeleteBTN.CheckState = System.Windows.Forms.CheckState.Checked
        Me.tsmDeleteBTN.Name = "tsmDeleteBTN"
        Me.tsmDeleteBTN.Size = New System.Drawing.Size(167, 22)
        Me.tsmDeleteBTN.Text = "Delete"
        '
        'tsmExportBTN
        '
        Me.tsmExportBTN.Checked = True
        Me.tsmExportBTN.CheckOnClick = True
        Me.tsmExportBTN.CheckState = System.Windows.Forms.CheckState.Checked
        Me.tsmExportBTN.Name = "tsmExportBTN"
        Me.tsmExportBTN.Size = New System.Drawing.Size(167, 22)
        Me.tsmExportBTN.Text = "Export"
        '
        'tsmViewBTN
        '
        Me.tsmViewBTN.Checked = True
        Me.tsmViewBTN.CheckOnClick = True
        Me.tsmViewBTN.CheckState = System.Windows.Forms.CheckState.Checked
        Me.tsmViewBTN.Name = "tsmViewBTN"
        Me.tsmViewBTN.Size = New System.Drawing.Size(167, 22)
        Me.tsmViewBTN.Text = "View"
        '
        'tsmPrintBTN
        '
        Me.tsmPrintBTN.Checked = True
        Me.tsmPrintBTN.CheckOnClick = True
        Me.tsmPrintBTN.CheckState = System.Windows.Forms.CheckState.Checked
        Me.tsmPrintBTN.Name = "tsmPrintBTN"
        Me.tsmPrintBTN.Size = New System.Drawing.Size(167, 22)
        Me.tsmPrintBTN.Text = "Print"
        '
        'tsmToTrayBTN
        '
        Me.tsmToTrayBTN.Checked = True
        Me.tsmToTrayBTN.CheckOnClick = True
        Me.tsmToTrayBTN.CheckState = System.Windows.Forms.CheckState.Checked
        Me.tsmToTrayBTN.Name = "tsmToTrayBTN"
        Me.tsmToTrayBTN.Size = New System.Drawing.Size(167, 22)
        Me.tsmToTrayBTN.Text = "To Tray"
        '
        'tsmAutoDeliverBTN
        '
        Me.tsmAutoDeliverBTN.Checked = True
        Me.tsmAutoDeliverBTN.CheckOnClick = True
        Me.tsmAutoDeliverBTN.CheckState = System.Windows.Forms.CheckState.Checked
        Me.tsmAutoDeliverBTN.Name = "tsmAutoDeliverBTN"
        Me.tsmAutoDeliverBTN.Size = New System.Drawing.Size(167, 22)
        Me.tsmAutoDeliverBTN.Text = "Delivery Mode"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(206, 6)
        '
        'tsmTrigger
        '
        Me.tsmTrigger.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.txtTriggerFolder, Me.SelectTriggerFolderToolStripMenuItem, Me.ClearTriggerFolderToolStripMenuItem})
        Me.tsmTrigger.Name = "tsmTrigger"
        Me.tsmTrigger.Size = New System.Drawing.Size(209, 22)
        Me.tsmTrigger.Text = "Trigger Folder"
        '
        'txtTriggerFolder
        '
        Me.txtTriggerFolder.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTriggerFolder.ForeColor = System.Drawing.SystemColors.GrayText
        Me.txtTriggerFolder.Name = "txtTriggerFolder"
        Me.txtTriggerFolder.ReadOnly = True
        Me.txtTriggerFolder.Size = New System.Drawing.Size(300, 21)
        Me.txtTriggerFolder.Text = "No Trigger Folder Selected"
        '
        'SelectTriggerFolderToolStripMenuItem
        '
        Me.SelectTriggerFolderToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.SelectTriggerFolderToolStripMenuItem.BackColor = System.Drawing.Color.Transparent
        Me.SelectTriggerFolderToolStripMenuItem.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SelectTriggerFolderToolStripMenuItem.Name = "SelectTriggerFolderToolStripMenuItem"
        Me.SelectTriggerFolderToolStripMenuItem.Size = New System.Drawing.Size(360, 22)
        Me.SelectTriggerFolderToolStripMenuItem.Text = "              Select Trigger Folder"
        '
        'ClearTriggerFolderToolStripMenuItem
        '
        Me.ClearTriggerFolderToolStripMenuItem.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ClearTriggerFolderToolStripMenuItem.Name = "ClearTriggerFolderToolStripMenuItem"
        Me.ClearTriggerFolderToolStripMenuItem.Size = New System.Drawing.Size(360, 22)
        Me.ClearTriggerFolderToolStripMenuItem.Text = "               Clear Trigger Folder"
        Me.ClearTriggerFolderToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ContentsToolStripMenuItem, Me.ViewLogToolStripMenuItem, Me.AboutToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'ContentsToolStripMenuItem
        '
        Me.ContentsToolStripMenuItem.Image = CType(resources.GetObject("ContentsToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ContentsToolStripMenuItem.Name = "ContentsToolStripMenuItem"
        Me.ContentsToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.ContentsToolStripMenuItem.Text = "Contents"
        '
        'ViewLogToolStripMenuItem
        '
        Me.ViewLogToolStripMenuItem.Image = CType(resources.GetObject("ViewLogToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ViewLogToolStripMenuItem.Name = "ViewLogToolStripMenuItem"
        Me.ViewLogToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.ViewLogToolStripMenuItem.Text = "View Log"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Image = CType(resources.GetObject("AboutToolStripMenuItem.Image"), System.Drawing.Image)
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.ToolStrip1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbSchedule, Me.tsbCopy, Me.tsbDelete, Me.tsbExport, Me.tsbView, Me.tsbPrint, Me.tsbToTray, Me.tsbAutoDeliver})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip1.Size = New System.Drawing.Size(990, 52)
        Me.ToolStrip1.TabIndex = 2
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsbSchedule
        '
        Me.tsbSchedule.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsbSchedule.Image = CType(resources.GetObject("tsbSchedule.Image"), System.Drawing.Image)
        Me.tsbSchedule.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSchedule.Name = "tsbSchedule"
        Me.tsbSchedule.Size = New System.Drawing.Size(63, 49)
        Me.tsbSchedule.Text = "Schedule"
        Me.tsbSchedule.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tsbCopy
        '
        Me.tsbCopy.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsbCopy.Image = CType(resources.GetObject("tsbCopy.Image"), System.Drawing.Image)
        Me.tsbCopy.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCopy.Name = "tsbCopy"
        Me.tsbCopy.Size = New System.Drawing.Size(41, 49)
        Me.tsbCopy.Text = "Copy"
        Me.tsbCopy.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tsbDelete
        '
        Me.tsbDelete.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsbDelete.Image = CType(resources.GetObject("tsbDelete.Image"), System.Drawing.Image)
        Me.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbDelete.Name = "tsbDelete"
        Me.tsbDelete.Size = New System.Drawing.Size(48, 49)
        Me.tsbDelete.Text = "Delete"
        Me.tsbDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tsbExport
        '
        Me.tsbExport.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsbExport.Image = CType(resources.GetObject("tsbExport.Image"), System.Drawing.Image)
        Me.tsbExport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbExport.Name = "tsbExport"
        Me.tsbExport.Size = New System.Drawing.Size(48, 49)
        Me.tsbExport.Text = "Export"
        Me.tsbExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tsbView
        '
        Me.tsbView.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsbView.Image = CType(resources.GetObject("tsbView.Image"), System.Drawing.Image)
        Me.tsbView.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbView.Name = "tsbView"
        Me.tsbView.Size = New System.Drawing.Size(38, 49)
        Me.tsbView.Text = "View"
        Me.tsbView.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tsbPrint
        '
        Me.tsbPrint.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsbPrint.Image = CType(resources.GetObject("tsbPrint.Image"), System.Drawing.Image)
        Me.tsbPrint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbPrint.Name = "tsbPrint"
        Me.tsbPrint.Size = New System.Drawing.Size(37, 49)
        Me.tsbPrint.Text = "Print"
        Me.tsbPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tsbToTray
        '
        Me.tsbToTray.Image = CType(resources.GetObject("tsbToTray.Image"), System.Drawing.Image)
        Me.tsbToTray.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbToTray.Name = "tsbToTray"
        Me.tsbToTray.Size = New System.Drawing.Size(55, 49)
        Me.tsbToTray.Text = "To Tray"
        Me.tsbToTray.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tsbToTray.ToolTipText = "Send To Tray"
        '
        'tsbAutoDeliver
        '
        Me.tsbAutoDeliver.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsbAutoDeliver.Image = CType(resources.GetObject("tsbAutoDeliver.Image"), System.Drawing.Image)
        Me.tsbAutoDeliver.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbAutoDeliver.Name = "tsbAutoDeliver"
        Me.tsbAutoDeliver.Size = New System.Drawing.Size(93, 49)
        Me.tsbAutoDeliver.Text = "Delivery Mode"
        Me.tsbAutoDeliver.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'dgvScheduleList
        '
        Me.dgvScheduleList.AllowUserToAddRows = False
        Me.dgvScheduleList.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro
        Me.dgvScheduleList.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvScheduleList.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(103, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(103, Byte), Integer))
        Me.dgvScheduleList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvScheduleList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.SlateGray
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.IndianRed
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvScheduleList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvScheduleList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvScheduleList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colID, Me.colReportName, Me.colExportInterval, Me.colExportDays, Me.colExportTime, Me.colRunHistory, Me.colReportPath})
        Me.dgvScheduleList.ContextMenuStrip = Me.ContextMenuStrip2
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.IndianRed
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvScheduleList.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvScheduleList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvScheduleList.EnableHeadersVisualStyles = False
        Me.dgvScheduleList.Location = New System.Drawing.Point(0, 76)
        Me.dgvScheduleList.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.dgvScheduleList.Name = "dgvScheduleList"
        Me.dgvScheduleList.ReadOnly = True
        Me.dgvScheduleList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.SlateGray
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.IndianRed
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvScheduleList.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvScheduleList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.dgvScheduleList.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvScheduleList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvScheduleList.Size = New System.Drawing.Size(990, 424)
        Me.dgvScheduleList.TabIndex = 3
        '
        'colID
        '
        Me.colID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.colID.HeaderText = "ID"
        Me.colID.MinimumWidth = 10
        Me.colID.Name = "colID"
        Me.colID.ReadOnly = True
        Me.colID.Visible = False
        '
        'colReportName
        '
        Me.colReportName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colReportName.HeaderText = "Report Description"
        Me.colReportName.MinimumWidth = 120
        Me.colReportName.Name = "colReportName"
        Me.colReportName.ReadOnly = True
        Me.colReportName.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'colExportInterval
        '
        Me.colExportInterval.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colExportInterval.HeaderText = "Export Interval"
        Me.colExportInterval.MinimumWidth = 50
        Me.colExportInterval.Name = "colExportInterval"
        Me.colExportInterval.ReadOnly = True
        '
        'colExportDays
        '
        Me.colExportDays.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colExportDays.HeaderText = "Valid Export Days"
        Me.colExportDays.MinimumWidth = 50
        Me.colExportDays.Name = "colExportDays"
        Me.colExportDays.ReadOnly = True
        '
        'colExportTime
        '
        Me.colExportTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colExportTime.HeaderText = "Valid Export Time"
        Me.colExportTime.MinimumWidth = 150
        Me.colExportTime.Name = "colExportTime"
        Me.colExportTime.ReadOnly = True
        '
        'colRunHistory
        '
        Me.colRunHistory.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colRunHistory.HeaderText = "Last Export"
        Me.colRunHistory.MinimumWidth = 50
        Me.colRunHistory.Name = "colRunHistory"
        Me.colRunHistory.ReadOnly = True
        '
        'colReportPath
        '
        Me.colReportPath.HeaderText = "Report Path"
        Me.colReportPath.Name = "colReportPath"
        Me.colReportPath.ReadOnly = True
        Me.colReportPath.Visible = False
        '
        'ContextMenuStrip2
        '
        Me.ContextMenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmSchedule, Me.tsmCopy, Me.tsmDelete, Me.tsmExport, Me.tsmView, Me.tsmPrint, Me.ToolStripSeparator7, Me.SendToTrayToolStripMenuItem1, Me.DeliveryModeToolStripMenuItem})
        Me.ContextMenuStrip2.Name = "ContextMenuStrip2"
        Me.ContextMenuStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ContextMenuStrip2.Size = New System.Drawing.Size(154, 186)
        '
        'tsmSchedule
        '
        Me.tsmSchedule.Image = CType(resources.GetObject("tsmSchedule.Image"), System.Drawing.Image)
        Me.tsmSchedule.Name = "tsmSchedule"
        Me.tsmSchedule.Size = New System.Drawing.Size(153, 22)
        Me.tsmSchedule.Text = "Schedule"
        '
        'tsmCopy
        '
        Me.tsmCopy.Image = CType(resources.GetObject("tsmCopy.Image"), System.Drawing.Image)
        Me.tsmCopy.Name = "tsmCopy"
        Me.tsmCopy.Size = New System.Drawing.Size(153, 22)
        Me.tsmCopy.Text = "Copy"
        '
        'tsmDelete
        '
        Me.tsmDelete.Image = CType(resources.GetObject("tsmDelete.Image"), System.Drawing.Image)
        Me.tsmDelete.Name = "tsmDelete"
        Me.tsmDelete.Size = New System.Drawing.Size(153, 22)
        Me.tsmDelete.Text = "Delete"
        '
        'tsmExport
        '
        Me.tsmExport.Image = CType(resources.GetObject("tsmExport.Image"), System.Drawing.Image)
        Me.tsmExport.Name = "tsmExport"
        Me.tsmExport.Size = New System.Drawing.Size(153, 22)
        Me.tsmExport.Text = "Export"
        '
        'tsmView
        '
        Me.tsmView.Image = CType(resources.GetObject("tsmView.Image"), System.Drawing.Image)
        Me.tsmView.Name = "tsmView"
        Me.tsmView.Size = New System.Drawing.Size(153, 22)
        Me.tsmView.Text = "View"
        '
        'tsmPrint
        '
        Me.tsmPrint.Image = CType(resources.GetObject("tsmPrint.Image"), System.Drawing.Image)
        Me.tsmPrint.Name = "tsmPrint"
        Me.tsmPrint.Size = New System.Drawing.Size(153, 22)
        Me.tsmPrint.Text = "Print"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(150, 6)
        '
        'SendToTrayToolStripMenuItem1
        '
        Me.SendToTrayToolStripMenuItem1.Image = CType(resources.GetObject("SendToTrayToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.SendToTrayToolStripMenuItem1.Name = "SendToTrayToolStripMenuItem1"
        Me.SendToTrayToolStripMenuItem1.Size = New System.Drawing.Size(153, 22)
        Me.SendToTrayToolStripMenuItem1.Text = "Send To Tray"
        '
        'DeliveryModeToolStripMenuItem
        '
        Me.DeliveryModeToolStripMenuItem.Image = CType(resources.GetObject("DeliveryModeToolStripMenuItem.Image"), System.Drawing.Image)
        Me.DeliveryModeToolStripMenuItem.Name = "DeliveryModeToolStripMenuItem"
        Me.DeliveryModeToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
        Me.DeliveryModeToolStripMenuItem.Text = "Delivery Mode"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.Filter = "Crystal Report|*.rpt"
        Me.OpenFileDialog1.Multiselect = True
        Me.OpenFileDialog1.Title = "Select Reports"
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.BalloonTipText = "Manual Mode"
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Visible = True
        '
        'tsmRestore
        '
        Me.tsmRestore.Image = CType(resources.GetObject("tsmRestore.Image"), System.Drawing.Image)
        Me.tsmRestore.ImageTransparentColor = System.Drawing.Color.White
        Me.tsmRestore.Name = "tsmRestore"
        Me.tsmRestore.Size = New System.Drawing.Size(182, 22)
        Me.tsmRestore.Text = "Restore"
        '
        'tsmAutoDeliver
        '
        Me.tsmAutoDeliver.Image = CType(resources.GetObject("tsmAutoDeliver.Image"), System.Drawing.Image)
        Me.tsmAutoDeliver.Name = "tsmAutoDeliver"
        Me.tsmAutoDeliver.Size = New System.Drawing.Size(182, 22)
        Me.tsmAutoDeliver.Text = "Delivery Mode"
        '
        'tsmExit
        '
        Me.tsmExit.Image = CType(resources.GetObject("tsmExit.Image"), System.Drawing.Image)
        Me.tsmExit.Name = "tsmExit"
        Me.tsmExit.Size = New System.Drawing.Size(182, 22)
        Me.tsmExit.Text = "Exit Crystal Delivery"
        '
        'Timer2
        '
        Me.Timer2.Interval = 20
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "Start.ico")
        Me.ImageList1.Images.SetKeyName(1, "Stop.ico")
        Me.ImageList1.Images.SetKeyName(2, "StartSmall.ico")
        Me.ImageList1.Images.SetKeyName(3, "StopSmall.ico")
        '
        'ContextMenuStrip3
        '
        Me.ContextMenuStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmAutoDelivery, Me.tsmRestorePanel})
        Me.ContextMenuStrip3.Name = "ContextMenuStrip3"
        Me.ContextMenuStrip3.Size = New System.Drawing.Size(154, 70)
        '
        'tsmAutoDelivery
        '
        Me.tsmAutoDelivery.Image = CType(resources.GetObject("tsmAutoDelivery.Image"), System.Drawing.Image)
        Me.tsmAutoDelivery.Name = "tsmAutoDelivery"
        Me.tsmAutoDelivery.Size = New System.Drawing.Size(153, 22)
        Me.tsmAutoDelivery.Text = "Delivery Mode"
        '
        'tsmRestorePanel
        '
        Me.tsmRestorePanel.Image = Global.CrystalDelivery.My.Resources.Resources.arrow2
        Me.tsmRestorePanel.Name = "tsmRestorePanel"
        Me.tsmRestorePanel.Size = New System.Drawing.Size(153, 22)
        Me.tsmRestorePanel.Text = "Restore"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(990, 522)
        Me.Controls.Add(Me.dgvScheduleList)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Name = "frmMain"
        Me.Text = "Crystal Delivery"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.dgvScheduleList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip2.ResumeLayout(False)
        Me.ContextMenuStrip3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbSchedule As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbCopy As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbExport As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbView As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbPrint As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbAutoDeliver As System.Windows.Forms.ToolStripButton
    Friend WithEvents ProgramToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AutoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SendToTrayToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContentsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dgvScheduleList As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents ScheduleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents tsmAutoDeliver As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmRestore As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents tsmAutoOnStart As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmTrayOnStart As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmStartWithWindows As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextMenuStrip2 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents tsmSchedule As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmExport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmView As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmPrint As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmLangPack As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsbToTray As System.Windows.Forms.ToolStripButton
    Friend WithEvents SendToTrayToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeliveryModeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripProgressBar1 As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsmIconSettings As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmScheduleBTN As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmHideAllButtons As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmCopyBTN As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmDeleteBTN As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmExportBTN As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmViewBTN As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmPrintBTN As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmToTrayBTN As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmAutoDeliverBTN As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BackupToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmSMTPServer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtSMTP As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents RestoreToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtUserID As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents txtUserPassword As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents tsmTrigger As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents tsmUseSSL As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents txtTriggerFolder As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents SelectTriggerFolderToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClearTriggerFolderToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ReplaceStringToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents colID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colReportName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colExportInterval As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colExportDays As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colExportTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRunHistory As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colReportPath As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ViewLogToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextMenuStrip3 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents tsmAutoDelivery As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmRestorePanel As System.Windows.Forms.ToolStripMenuItem

End Class
