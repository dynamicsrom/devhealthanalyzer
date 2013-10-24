<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmWelcomeForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmWelcomeForm))
        Me.txtReport = New System.Windows.Forms.TextBox
        Me.lblPasteReport = New System.Windows.Forms.Label
        Me.btnStart = New System.Windows.Forms.Button
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.txtDumpMap = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnBack = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btnOpen = New System.Windows.Forms.Button
        Me.btnCreateNewMap = New System.Windows.Forms.Button
        Me.lvSlotmaps = New System.Windows.Forms.ListView
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtReport
        '
        Me.txtReport.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtReport.Location = New System.Drawing.Point(6, 37)
        Me.txtReport.MaxLength = 327670000
        Me.txtReport.Multiline = True
        Me.txtReport.Name = "txtReport"
        Me.txtReport.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtReport.Size = New System.Drawing.Size(260, 191)
        Me.txtReport.TabIndex = 0
        '
        'lblPasteReport
        '
        Me.lblPasteReport.AutoSize = True
        Me.lblPasteReport.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lblPasteReport.Location = New System.Drawing.Point(6, 21)
        Me.lblPasteReport.Name = "lblPasteReport"
        Me.lblPasteReport.Size = New System.Drawing.Size(178, 13)
        Me.lblPasteReport.TabIndex = 1
        Me.lblPasteReport.Text = "Paste your devhealth report here:"
        '
        'btnStart
        '
        Me.btnStart.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btnStart.Image = Global.DevHealthAnalyzer.My.Resources.Resources.PlayHS
        Me.btnStart.Location = New System.Drawing.Point(489, 234)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(60, 30)
        Me.btnStart.TabIndex = 3
        Me.btnStart.Text = "Start"
        Me.btnStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnStart.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'BackgroundWorker1
        '
        Me.BackgroundWorker1.WorkerReportsProgress = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(76, 247)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(407, 11)
        Me.ProgressBar1.TabIndex = 4
        '
        'txtDumpMap
        '
        Me.txtDumpMap.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtDumpMap.Location = New System.Drawing.Point(289, 37)
        Me.txtDumpMap.MaxLength = 327670000
        Me.txtDumpMap.Multiline = True
        Me.txtDumpMap.Name = "txtDumpMap"
        Me.txtDumpMap.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtDumpMap.Size = New System.Drawing.Size(260, 191)
        Me.txtDumpMap.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label1.Location = New System.Drawing.Point(286, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(146, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Paste your DumpMap here:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnBack)
        Me.GroupBox1.Controls.Add(Me.lblPasteReport)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtReport)
        Me.GroupBox1.Controls.Add(Me.txtDumpMap)
        Me.GroupBox1.Controls.Add(Me.btnStart)
        Me.GroupBox1.Controls.Add(Me.ProgressBar1)
        Me.GroupBox1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(560, 270)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Create a new map"
        Me.GroupBox1.Visible = False
        '
        'btnBack
        '
        Me.btnBack.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btnBack.Image = Global.DevHealthAnalyzer.My.Resources.Resources.Back
        Me.btnBack.Location = New System.Drawing.Point(9, 234)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(57, 30)
        Me.btnBack.TabIndex = 7
        Me.btnBack.Text = "Back"
        Me.btnBack.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBack.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnOpen)
        Me.GroupBox2.Controls.Add(Me.btnCreateNewMap)
        Me.GroupBox2.Controls.Add(Me.lvSlotmaps)
        Me.GroupBox2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(560, 270)
        Me.GroupBox2.TabIndex = 8
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Open existing map"
        '
        'btnOpen
        '
        Me.btnOpen.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btnOpen.Image = Global.DevHealthAnalyzer.My.Resources.Resources.OpenSelectedItemHS
        Me.btnOpen.Location = New System.Drawing.Point(489, 234)
        Me.btnOpen.Name = "btnOpen"
        Me.btnOpen.Size = New System.Drawing.Size(60, 30)
        Me.btnOpen.TabIndex = 4
        Me.btnOpen.Text = "Open"
        Me.btnOpen.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnOpen.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnOpen.UseVisualStyleBackColor = True
        '
        'btnCreateNewMap
        '
        Me.btnCreateNewMap.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btnCreateNewMap.Image = Global.DevHealthAnalyzer.My.Resources.Resources.NewDocumentHS
        Me.btnCreateNewMap.Location = New System.Drawing.Point(9, 234)
        Me.btnCreateNewMap.Name = "btnCreateNewMap"
        Me.btnCreateNewMap.Size = New System.Drawing.Size(124, 30)
        Me.btnCreateNewMap.TabIndex = 1
        Me.btnCreateNewMap.Text = "Create new map"
        Me.btnCreateNewMap.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCreateNewMap.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCreateNewMap.UseVisualStyleBackColor = True
        '
        'lvSlotmaps
        '
        Me.lvSlotmaps.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.lvSlotmaps.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lvSlotmaps.FullRowSelect = True
        Me.lvSlotmaps.GridLines = True
        Me.lvSlotmaps.Location = New System.Drawing.Point(9, 19)
        Me.lvSlotmaps.MultiSelect = False
        Me.lvSlotmaps.Name = "lvSlotmaps"
        Me.lvSlotmaps.Size = New System.Drawing.Size(540, 209)
        Me.lvSlotmaps.TabIndex = 0
        Me.lvSlotmaps.UseCompatibleStateImageBehavior = False
        Me.lvSlotmaps.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "File"
        Me.ColumnHeader1.Width = 150
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Brief information"
        Me.ColumnHeader2.Width = 400
        '
        'WelcomeForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(584, 292)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "WelcomeForm"
        Me.Text = "Welcome to DevHealthAnalyzer!"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtReport As System.Windows.Forms.TextBox
    Friend WithEvents lblPasteReport As System.Windows.Forms.Label
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents txtDumpMap As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnBack As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lvSlotmaps As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnOpen As System.Windows.Forms.Button
    Friend WithEvents btnCreateNewMap As System.Windows.Forms.Button
End Class
