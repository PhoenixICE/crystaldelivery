﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReportViewer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReportViewer))
        Me.crViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.SuspendLayout()
        '
        'crViewer
        '
        Me.crViewer.ActiveViewIndex = -1
        Me.crViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crViewer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.crViewer.Location = New System.Drawing.Point(0, 0)
        Me.crViewer.Name = "crViewer"
        Me.crViewer.SelectionFormula = ""
        Me.crViewer.Size = New System.Drawing.Size(292, 273)
        Me.crViewer.TabIndex = 0
        Me.crViewer.ViewTimeSelectionFormula = ""
        '
        'frmReportViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 273)
        Me.Controls.Add(Me.crViewer)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmReportViewer"
        Me.Text = "Report Viewer"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents crViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
