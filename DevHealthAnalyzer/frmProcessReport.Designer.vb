<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProcessReport
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
		Me.ListView2 = New System.Windows.Forms.ListView
		Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
		Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
		Me.ColumnHeader3 = New System.Windows.Forms.ColumnHeader
		Me.ListBox1 = New System.Windows.Forms.ListBox
		Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker
		Me.Label1 = New System.Windows.Forms.Label
		Me.Label2 = New System.Windows.Forms.Label
		Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
		Me.SplitContainer1.Panel1.SuspendLayout()
		Me.SplitContainer1.Panel2.SuspendLayout()
		Me.SplitContainer1.SuspendLayout()
		Me.SuspendLayout()
		'
		'ListView2
		'
		Me.ListView2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
					Or System.Windows.Forms.AnchorStyles.Left) _
					Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.ListView2.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3})
		Me.ListView2.FullRowSelect = True
		Me.ListView2.GridLines = True
		Me.ListView2.Location = New System.Drawing.Point(3, 31)
		Me.ListView2.Name = "ListView2"
		Me.ListView2.Size = New System.Drawing.Size(576, 379)
		Me.ListView2.TabIndex = 3
		Me.ListView2.UseCompatibleStateImageBehavior = False
		Me.ListView2.View = System.Windows.Forms.View.Details
		'
		'ColumnHeader1
		'
		Me.ColumnHeader1.Text = "DLL"
		Me.ColumnHeader1.Width = 300
		'
		'ColumnHeader2
		'
		Me.ColumnHeader2.Text = "Address"
		Me.ColumnHeader2.Width = 100
		'
		'ColumnHeader3
		'
		Me.ColumnHeader3.Text = "Size"
		Me.ColumnHeader3.Width = 100
		'
		'ListBox1
		'
		Me.ListBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
					Or System.Windows.Forms.AnchorStyles.Left) _
					Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.ListBox1.FormattingEnabled = True
		Me.ListBox1.ItemHeight = 15
		Me.ListBox1.Location = New System.Drawing.Point(3, 31)
		Me.ListBox1.Name = "ListBox1"
		Me.ListBox1.Size = New System.Drawing.Size(194, 379)
		Me.ListBox1.TabIndex = 4
		'
		'BackgroundWorker1
		'
		Me.BackgroundWorker1.WorkerReportsProgress = True
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Location = New System.Drawing.Point(1, 7)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(61, 15)
		Me.Label1.TabIndex = 5
		Me.Label1.Text = "Processes:"
		'
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.Location = New System.Drawing.Point(3, 7)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(93, 15)
		Me.Label2.TabIndex = 6
		Me.Label2.Text = "Loaded libraries:"
		'
		'SplitContainer1
		'
		Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
		Me.SplitContainer1.Name = "SplitContainer1"
		'
		'SplitContainer1.Panel1
		'
		Me.SplitContainer1.Panel1.Controls.Add(Me.ListBox1)
		Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
		Me.SplitContainer1.Panel1MinSize = 50
		'
		'SplitContainer1.Panel2
		'
		Me.SplitContainer1.Panel2.Controls.Add(Me.ListView2)
		Me.SplitContainer1.Panel2.Controls.Add(Me.Label2)
		Me.SplitContainer1.Panel2MinSize = 50
		Me.SplitContainer1.Size = New System.Drawing.Size(784, 422)
		Me.SplitContainer1.SplitterDistance = 200
		Me.SplitContainer1.SplitterWidth = 2
		Me.SplitContainer1.TabIndex = 7
		'
		'ProcessReport
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(784, 422)
		Me.Controls.Add(Me.SplitContainer1)
		Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
		Me.MinimumSize = New System.Drawing.Size(800, 226)
		Me.Name = "ProcessReport"
		Me.ShowIcon = False
		Me.ShowInTaskbar = False
		Me.Text = "Process info"
		Me.SplitContainer1.Panel1.ResumeLayout(False)
		Me.SplitContainer1.Panel1.PerformLayout()
		Me.SplitContainer1.Panel2.ResumeLayout(False)
		Me.SplitContainer1.Panel2.PerformLayout()
		Me.SplitContainer1.ResumeLayout(False)
		Me.ResumeLayout(False)

	End Sub
	Friend WithEvents ListView2 As System.Windows.Forms.ListView
	Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
	Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
	Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
	Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
	Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
	Friend WithEvents Label1 As System.Windows.Forms.Label
	Friend WithEvents Label2 As System.Windows.Forms.Label
	Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer

End Class
