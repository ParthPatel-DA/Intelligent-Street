﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Me.components = New System.ComponentModel.Container()
        Me.openFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.txtInfo = New System.Windows.Forms.TextBox()
        Me.ibOriginal = New Emgu.CV.UI.ImageBox()
        Me.btnOpenFile = New System.Windows.Forms.Button()
        Me.lblChosenFile = New System.Windows.Forms.Label()
        Me.tableLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
        CType(Me.ibOriginal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tableLayoutPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'openFileDialog
        '
        Me.openFileDialog.FileName = "OpenFileDialog1"
        '
        'txtInfo
        '
        Me.tableLayoutPanel.SetColumnSpan(Me.txtInfo, 3)
        Me.txtInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtInfo.Font = New System.Drawing.Font("Courier New", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInfo.Location = New System.Drawing.Point(2, 491)
        Me.txtInfo.Margin = New System.Windows.Forms.Padding(2)
        Me.txtInfo.Multiline = True
        Me.txtInfo.Name = "txtInfo"
        Me.txtInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtInfo.Size = New System.Drawing.Size(990, 193)
        Me.txtInfo.TabIndex = 3
        Me.txtInfo.WordWrap = False
        '
        'ibOriginal
        '
        Me.ibOriginal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tableLayoutPanel.SetColumnSpan(Me.ibOriginal, 3)
        Me.ibOriginal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ibOriginal.Enabled = False
        Me.ibOriginal.Location = New System.Drawing.Point(2, 34)
        Me.ibOriginal.Margin = New System.Windows.Forms.Padding(2)
        Me.ibOriginal.Name = "ibOriginal"
        Me.ibOriginal.Size = New System.Drawing.Size(990, 453)
        Me.ibOriginal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.ibOriginal.TabIndex = 2
        Me.ibOriginal.TabStop = False
        '
        'btnOpenFile
        '
        Me.btnOpenFile.AutoSize = True
        Me.btnOpenFile.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnOpenFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOpenFile.Location = New System.Drawing.Point(2, 2)
        Me.btnOpenFile.Margin = New System.Windows.Forms.Padding(2)
        Me.btnOpenFile.Name = "btnOpenFile"
        Me.btnOpenFile.Size = New System.Drawing.Size(81, 28)
        Me.btnOpenFile.TabIndex = 2
        Me.btnOpenFile.Text = "Open File"
        Me.btnOpenFile.UseVisualStyleBackColor = True
        '
        'lblChosenFile
        '
        Me.lblChosenFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblChosenFile.AutoSize = True
        Me.lblChosenFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblChosenFile.Location = New System.Drawing.Point(87, 7)
        Me.lblChosenFile.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblChosenFile.Name = "lblChosenFile"
        Me.lblChosenFile.Size = New System.Drawing.Size(1, 18)
        Me.lblChosenFile.TabIndex = 1
        Me.lblChosenFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tableLayoutPanel
        '
        Me.tableLayoutPanel.ColumnCount = 3
        Me.tableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tableLayoutPanel.Controls.Add(Me.lblChosenFile, 1, 0)
        Me.tableLayoutPanel.Controls.Add(Me.btnOpenFile, 0, 0)
        Me.tableLayoutPanel.Controls.Add(Me.ibOriginal, 0, 1)
        Me.tableLayoutPanel.Controls.Add(Me.txtInfo, 0, 2)
        Me.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tableLayoutPanel.Location = New System.Drawing.Point(0, 0)
        Me.tableLayoutPanel.Margin = New System.Windows.Forms.Padding(2)
        Me.tableLayoutPanel.Name = "tableLayoutPanel"
        Me.tableLayoutPanel.RowCount = 3
        Me.tableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70.0!))
        Me.tableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.tableLayoutPanel.Size = New System.Drawing.Size(994, 686)
        Me.tableLayoutPanel.TabIndex = 0
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(994, 686)
        Me.Controls.Add(Me.tableLayoutPanel)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "frmMain"
        Me.Text = "Form1"
        CType(Me.ibOriginal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tableLayoutPanel.ResumeLayout(False)
        Me.tableLayoutPanel.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents openFileDialog As OpenFileDialog
    Friend WithEvents txtInfo As TextBox
    Friend WithEvents tableLayoutPanel As TableLayoutPanel
    Friend WithEvents lblChosenFile As Label
    Friend WithEvents btnOpenFile As Button
    Friend WithEvents ibOriginal As Emgu.CV.UI.ImageBox
End Class
