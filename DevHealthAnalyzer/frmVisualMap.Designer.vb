<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VisualMap
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
		Me.components = New System.ComponentModel.Container
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VisualMap))
		Me.ListView1 = New System.Windows.Forms.ListView
		Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
		Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
		Me.ColumnHeader3 = New System.Windows.Forms.ColumnHeader
		Me.SelectedLabel = New System.Windows.Forms.Label
		Me.MainToolTip = New System.Windows.Forms.ToolTip(Me.components)
		Me.HealthMaxAmount = New System.Windows.Forms.Label
		Me.SearchBox = New System.Windows.Forms.TextBox
		Me.ContextMenu1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
		Me.menuSelectAll = New System.Windows.Forms.ToolStripMenuItem
		Me.MainMenu = New System.Windows.Forms.MenuStrip
		Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
		Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
		Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
		Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
		Me.CurrentConfigurationTextBox = New System.Windows.Forms.ToolStripTextBox
		Me.ToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
		Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
		Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
		Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
		Me.HealthLabel = New System.Windows.Forms.Label
		Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
		Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
		Me.OpenMainMenuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
		Me.BootTimeMarkersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
		Me.MemoryReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
		Me.ModuleReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
		Me.menuProcessInfo = New System.Windows.Forms.ToolStripMenuItem
		Me.TheBiggestLibrariesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
		Me.HealthPictureBox = New System.Windows.Forms.PictureBox
		Me.SearchImageLabel = New System.Windows.Forms.Label
		Me.ZoomPlus = New System.Windows.Forms.Button
		Me.ZoomMinus = New System.Windows.Forms.Button
		Me.ContextMenu1.SuspendLayout()
		Me.MainMenu.SuspendLayout()
		CType(Me.HealthPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'ListView1
		'
		Me.ListView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
					Or System.Windows.Forms.AnchorStyles.Left) _
					Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.ListView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3})
		Me.ListView1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
		Me.ListView1.FullRowSelect = True
		Me.ListView1.GridLines = True
		Me.ListView1.HideSelection = False
		Me.ListView1.Location = New System.Drawing.Point(12, 56)
		Me.ListView1.Name = "ListView1"
		Me.ListView1.Size = New System.Drawing.Size(817, 383)
		Me.ListView1.TabIndex = 0
		Me.ListView1.UseCompatibleStateImageBehavior = False
		Me.ListView1.View = System.Windows.Forms.View.Details
		'
		'ColumnHeader1
		'
		Me.ColumnHeader1.Text = "Address"
		Me.ColumnHeader1.Width = 100
		'
		'ColumnHeader2
		'
		Me.ColumnHeader2.Text = "Memory/File"
		Me.ColumnHeader2.Width = 200
		'
		'ColumnHeader3
		'
		Me.ColumnHeader3.Text = "EXE"
		Me.ColumnHeader3.Width = 300
		'
		'SelectedLabel
		'
		Me.SelectedLabel.AutoSize = True
		Me.SelectedLabel.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
		Me.SelectedLabel.Location = New System.Drawing.Point(74, 33)
		Me.SelectedLabel.Name = "SelectedLabel"
		Me.SelectedLabel.Size = New System.Drawing.Size(64, 17)
		Me.SelectedLabel.TabIndex = 3
		Me.SelectedLabel.Text = "Selected: "
		'
		'HealthMaxAmount
		'
		Me.HealthMaxAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.HealthMaxAmount.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
		Me.HealthMaxAmount.Location = New System.Drawing.Point(616, 445)
		Me.HealthMaxAmount.Name = "HealthMaxAmount"
		Me.HealthMaxAmount.Size = New System.Drawing.Size(213, 18)
		Me.HealthMaxAmount.TabIndex = 4
		Me.HealthMaxAmount.Text = "Max amount: "
		Me.HealthMaxAmount.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.MainToolTip.SetToolTip(Me.HealthMaxAmount, "Amount of memory every process can theoretically allocate")
		'
		'SearchBox
		'
		Me.SearchBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.SearchBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.SearchBox.ContextMenuStrip = Me.ContextMenu1
		Me.SearchBox.Location = New System.Drawing.Point(672, 30)
		Me.SearchBox.Name = "SearchBox"
		Me.SearchBox.Size = New System.Drawing.Size(157, 22)
		Me.SearchBox.TabIndex = 5
		Me.MainToolTip.SetToolTip(Me.SearchBox, "Highlight all such executable files")
		'
		'ContextMenu
		'
		Me.ContextMenu1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuSelectAll})
		Me.ContextMenu1.Name = "ContextMenuStrip1"
		Me.ContextMenu1.Size = New System.Drawing.Size(121, 26)
		'
		'menuSelectAll
		'
		Me.menuSelectAll.Name = "menuSelectAll"
		Me.menuSelectAll.Size = New System.Drawing.Size(120, 22)
		Me.menuSelectAll.Text = "Select all"
		'
		'MainMenu
		'
		Me.MainMenu.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
		Me.MainMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.CurrentConfigurationTextBox, Me.ToolsToolStripMenuItem, Me.AboutToolStripMenuItem})
		Me.MainMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
		Me.MainMenu.Location = New System.Drawing.Point(0, 0)
		Me.MainMenu.Name = "MainMenu"
		Me.MainMenu.Size = New System.Drawing.Size(841, 26)
		Me.MainMenu.TabIndex = 9
		Me.MainMenu.Text = "Main Menu"
		'
		'FileToolStripMenuItem
		'
		Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripMenuItem, Me.SaveToolStripMenuItem, Me.ToolStripSeparator1, Me.OpenMainMenuToolStripMenuItem, Me.ToolStripSeparator2, Me.ExitToolStripMenuItem})
		Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
		Me.FileToolStripMenuItem.Size = New System.Drawing.Size(42, 22)
		Me.FileToolStripMenuItem.Text = "Map"
		'
		'ToolStripSeparator1
		'
		Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
		Me.ToolStripSeparator1.Size = New System.Drawing.Size(160, 6)
		'
		'ToolStripSeparator2
		'
		Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
		Me.ToolStripSeparator2.Size = New System.Drawing.Size(160, 6)
		'
		'ExitToolStripMenuItem
		'
		Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
		Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
		Me.ExitToolStripMenuItem.Text = "Close"
		'
		'CurrentConfigurationTextBox
		'
		Me.CurrentConfigurationTextBox.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
		Me.CurrentConfigurationTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.CurrentConfigurationTextBox.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
		Me.CurrentConfigurationTextBox.Name = "CurrentConfigurationTextBox"
		Me.CurrentConfigurationTextBox.Size = New System.Drawing.Size(300, 22)
		Me.CurrentConfigurationTextBox.Text = "Unnamed"
		Me.CurrentConfigurationTextBox.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right
		'
		'ToolsToolStripMenuItem
		'
		Me.ToolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BootTimeMarkersToolStripMenuItem, Me.MemoryReportToolStripMenuItem, Me.ModuleReportToolStripMenuItem, Me.menuProcessInfo, Me.TheBiggestLibrariesToolStripMenuItem})
		Me.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem"
		Me.ToolsToolStripMenuItem.Size = New System.Drawing.Size(46, 22)
		Me.ToolsToolStripMenuItem.Text = "Tools"
		'
		'AboutToolStripMenuItem
		'
		Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
		Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(51, 22)
		Me.AboutToolStripMenuItem.Text = "About"
		'
		'SaveFileDialog1
		'
		Me.SaveFileDialog1.Filter = "Slot Map|*.slotmap"
		Me.SaveFileDialog1.Title = "Save slot map"
		'
		'OpenFileDialog1
		'
		Me.OpenFileDialog1.Filter = "Slot Map|*.slotmap"
		'
		'HealthLabel
		'
		Me.HealthLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.HealthLabel.Location = New System.Drawing.Point(38, 445)
		Me.HealthLabel.Name = "HealthLabel"
		Me.HealthLabel.Size = New System.Drawing.Size(497, 18)
		Me.HealthLabel.TabIndex = 11
		Me.HealthLabel.Text = "<health>"
		'
		'OpenToolStripMenuItem
		'
		Me.OpenToolStripMenuItem.Image = Global.DevHealthAnalyzer.My.Resources.Resources.OpenSelectedItem
		Me.OpenToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Fuchsia
		Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
		Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
		Me.OpenToolStripMenuItem.Text = "Open"
		'
		'SaveToolStripMenuItem
		'
		Me.SaveToolStripMenuItem.Image = Global.DevHealthAnalyzer.My.Resources.Resources.Save
		Me.SaveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Fuchsia
		Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
		Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
		Me.SaveToolStripMenuItem.Text = "Save"
		'
		'OpenMainMenuToolStripMenuItem
		'
		Me.OpenMainMenuToolStripMenuItem.Image = Global.DevHealthAnalyzer.My.Resources.Resources.Control_MenuStrip
		Me.OpenMainMenuToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Fuchsia
		Me.OpenMainMenuToolStripMenuItem.Name = "OpenMainMenuToolStripMenuItem"
		Me.OpenMainMenuToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
		Me.OpenMainMenuToolStripMenuItem.Text = "Open main menu"
		'
		'BootTimeMarkersToolStripMenuItem
		'
		Me.BootTimeMarkersToolStripMenuItem.Image = Global.DevHealthAnalyzer.My.Resources.Resources.Control_Timer
		Me.BootTimeMarkersToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Fuchsia
		Me.BootTimeMarkersToolStripMenuItem.Name = "BootTimeMarkersToolStripMenuItem"
		Me.BootTimeMarkersToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
		Me.BootTimeMarkersToolStripMenuItem.Text = "Boot Time Markers"
		'
		'MemoryReportToolStripMenuItem
		'
		Me.MemoryReportToolStripMenuItem.Image = Global.DevHealthAnalyzer.My.Resources.Resources.VSProject_report
		Me.MemoryReportToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Fuchsia
		Me.MemoryReportToolStripMenuItem.Name = "MemoryReportToolStripMenuItem"
		Me.MemoryReportToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
		Me.MemoryReportToolStripMenuItem.Text = "Memory Report"
		'
		'ModuleReportToolStripMenuItem
		'
		Me.ModuleReportToolStripMenuItem.Image = Global.DevHealthAnalyzer.My.Resources.Resources.Table
		Me.ModuleReportToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Fuchsia
		Me.ModuleReportToolStripMenuItem.Name = "ModuleReportToolStripMenuItem"
		Me.ModuleReportToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
		Me.ModuleReportToolStripMenuItem.Text = "Module Report"
		'
		'menuProcessInfo
		'
		Me.menuProcessInfo.Image = Global.DevHealthAnalyzer.My.Resources.Resources.appwindow_info_annotation_16
		Me.menuProcessInfo.ImageTransparentColor = System.Drawing.Color.Fuchsia
		Me.menuProcessInfo.Name = "menuProcessInfo"
		Me.menuProcessInfo.Size = New System.Drawing.Size(178, 22)
		Me.menuProcessInfo.Text = "Process Info"
		'
		'TheBiggestLibrariesToolStripMenuItem
		'
		Me.TheBiggestLibrariesToolStripMenuItem.Image = Global.DevHealthAnalyzer.My.Resources.Resources._109_AllAnnotations_Info_16x16_72
		Me.TheBiggestLibrariesToolStripMenuItem.Name = "TheBiggestLibrariesToolStripMenuItem"
		Me.TheBiggestLibrariesToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
		Me.TheBiggestLibrariesToolStripMenuItem.Text = "The biggest libraries"
		'
		'HealthPictureBox
		'
		Me.HealthPictureBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.HealthPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.HealthPictureBox.Location = New System.Drawing.Point(12, 445)
		Me.HealthPictureBox.Name = "HealthPictureBox"
		Me.HealthPictureBox.Size = New System.Drawing.Size(20, 13)
		Me.HealthPictureBox.TabIndex = 10
		Me.HealthPictureBox.TabStop = False
		Me.MainToolTip.SetToolTip(Me.HealthPictureBox, "Overall status")
		'
		'SearchImageLabel
		'
		Me.SearchImageLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.SearchImageLabel.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
		Me.SearchImageLabel.Image = Global.DevHealthAnalyzer.My.Resources.Resources.search_glyph
		Me.SearchImageLabel.ImageAlign = System.Drawing.ContentAlignment.TopRight
		Me.SearchImageLabel.Location = New System.Drawing.Point(619, 30)
		Me.SearchImageLabel.Name = "SearchImageLabel"
		Me.SearchImageLabel.Size = New System.Drawing.Size(56, 18)
		Me.SearchImageLabel.TabIndex = 6
		Me.SearchImageLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'ZoomPlus
		'
		Me.ZoomPlus.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
		Me.ZoomPlus.Image = Global.DevHealthAnalyzer.My.Resources.Resources._112_Plus_Blue_16x16_72
		Me.ZoomPlus.Location = New System.Drawing.Point(12, 29)
		Me.ZoomPlus.Name = "ZoomPlus"
		Me.ZoomPlus.Size = New System.Drawing.Size(25, 25)
		Me.ZoomPlus.TabIndex = 1
		Me.ZoomPlus.TextAlign = System.Drawing.ContentAlignment.TopCenter
		Me.ZoomPlus.UseVisualStyleBackColor = True
		'
		'ZoomMinus
		'
		Me.ZoomMinus.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
		Me.ZoomMinus.Image = Global.DevHealthAnalyzer.My.Resources.Resources._112_Minus_Blue_16x16_72
		Me.ZoomMinus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.ZoomMinus.Location = New System.Drawing.Point(43, 29)
		Me.ZoomMinus.Name = "ZoomMinus"
		Me.ZoomMinus.Size = New System.Drawing.Size(25, 25)
		Me.ZoomMinus.TabIndex = 2
		Me.ZoomMinus.TextAlign = System.Drawing.ContentAlignment.TopCenter
		Me.ZoomMinus.UseVisualStyleBackColor = True
		'
		'VisualMap
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(841, 465)
		Me.Controls.Add(Me.MainMenu)
		Me.Controls.Add(Me.SearchBox)
		Me.Controls.Add(Me.HealthLabel)
		Me.Controls.Add(Me.HealthPictureBox)
		Me.Controls.Add(Me.SearchImageLabel)
		Me.Controls.Add(Me.ZoomPlus)
		Me.Controls.Add(Me.HealthMaxAmount)
		Me.Controls.Add(Me.SelectedLabel)
		Me.Controls.Add(Me.ListView1)
		Me.Controls.Add(Me.ZoomMinus)
		Me.DoubleBuffered = True
		Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.MainMenuStrip = Me.MainMenu
		Me.MinimumSize = New System.Drawing.Size(600, 300)
		Me.Name = "VisualMap"
		Me.Text = "Slot 0 Map - Unnamed"
		Me.ContextMenu1.ResumeLayout(False)
		Me.MainMenu.ResumeLayout(False)
		Me.MainMenu.PerformLayout()
		CType(Me.HealthPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents ListView1 As System.Windows.Forms.ListView
	Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
	Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
	Friend WithEvents ZoomPlus As System.Windows.Forms.Button
	Friend WithEvents ZoomMinus As System.Windows.Forms.Button
	Friend WithEvents SelectedLabel As System.Windows.Forms.Label
	Friend WithEvents MainToolTip As System.Windows.Forms.ToolTip
	Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
	Friend WithEvents HealthMaxAmount As System.Windows.Forms.Label
	Friend WithEvents SearchBox As System.Windows.Forms.TextBox
	Friend WithEvents SearchImageLabel As System.Windows.Forms.Label
	Friend WithEvents ContextMenu1 As System.Windows.Forms.ContextMenuStrip
	Friend WithEvents menuSelectAll As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents MainMenu As System.Windows.Forms.MenuStrip
	Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
	Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
	Friend WithEvents HealthPictureBox As System.Windows.Forms.PictureBox
	Friend WithEvents OpenMainMenuToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
	Friend WithEvents CurrentConfigurationTextBox As System.Windows.Forms.ToolStripTextBox
	Friend WithEvents HealthLabel As System.Windows.Forms.Label
	Friend WithEvents ToolsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents TheBiggestLibrariesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents BootTimeMarkersToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents OpenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
	Friend WithEvents MemoryReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents menuProcessInfo As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents ModuleReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
