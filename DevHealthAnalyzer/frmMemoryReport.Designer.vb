<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMemoryReport
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
        Dim TreeListColumn1 As CommonTools.TreeListColumn = New CommonTools.TreeListColumn("fieldname0", "Name")
        Dim TreeListColumn2 As CommonTools.TreeListColumn = New CommonTools.TreeListColumn("fieldname1", "Pages")
        Dim TreeListColumn3 As CommonTools.TreeListColumn = New CommonTools.TreeListColumn("fieldname2", "Size")
        Me.TreeListView1 = New CommonTools.TreeListView
        CType(Me.TreeListView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TreeListView1
        '
        TreeListColumn1.AutoSize = True
        TreeListColumn1.AutoSizeMinSize = 0
        TreeListColumn1.AutoSizeRatio = 50.0!
        TreeListColumn1.Width = 50
        TreeListColumn2.AutoSize = True
        TreeListColumn2.AutoSizeMinSize = 0
        TreeListColumn2.AutoSizeRatio = 20.0!
        TreeListColumn2.Width = 50
        TreeListColumn3.AutoSize = True
        TreeListColumn3.AutoSizeMinSize = 0
        TreeListColumn3.AutoSizeRatio = 30.0!
        TreeListColumn3.Width = 50
        Me.TreeListView1.Columns.AddRange(New CommonTools.TreeListColumn() {TreeListColumn1, TreeListColumn2, TreeListColumn3})
        Me.TreeListView1.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TreeListView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeListView1.Images = Nothing
        Me.TreeListView1.Location = New System.Drawing.Point(0, 0)
        Me.TreeListView1.MultiSelect = False
        Me.TreeListView1.Name = "TreeListView1"
        Me.TreeListView1.Size = New System.Drawing.Size(544, 652)
        Me.TreeListView1.TabIndex = 0
        Me.TreeListView1.Text = "TreeListView1"
        '
        'MemoryReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(544, 652)
        Me.Controls.Add(Me.TreeListView1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.MinimumSize = New System.Drawing.Size(500, 200)
        Me.Name = "MemoryReport"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Memory Report"
        CType(Me.TreeListView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TreeListView1 As CommonTools.TreeListView

End Class
