Imports DevHealthAnalyzer
Imports DevHealthAnalyzer.DevHealthAnalyzer

Public Class ProcessReport

	Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
		If ListBox1.SelectedIndex = -1 Then
			Exit Sub
		End If
		ListView2.Items.Clear()
		Dim phi As ProcessHealthInfo = ReportManager.DevHealth.ProcessArray(ListBox1.SelectedIndex)
		For x = 0 To phi.LibraryList.Count - 1
			Dim mhi As MemoryHealthInfo = phi.LibraryList(x)
			Dim lvi As New ListViewItem
			lvi.Text = mhi.LibraryName
			lvi.SubItems.Add(Hex(mhi.MemoryAddress).ToString)
			lvi.SubItems.Add(Hex(mhi.MemorySize).ToString)
			ListView2.Items.Add(lvi)
		Next
	End Sub

	Private Sub Report_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		ListBox1.Items.Clear()
		Try
			For x = 0 To ReportManager.DevHealth.ProcessArray.Count - 1
				Dim phi As ProcessHealthInfo = ReportManager.DevHealth.ProcessArray(x)
				If Not phi.ProcessName Is Nothing Then
					ListBox1.Items.Add(phi.ProcessName)
				End If
			Next
		Catch ex As Exception
            frmErrorList.ClearList()

            frmErrorList.AddLines("Error while making a report from parsed data")
            frmErrorList.ShowDialog()
		End Try
		Me.Size = New System.Drawing.Size(Me.Width + 1, Me.Height)
	End Sub

	Private Sub ListView2_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView2.Resize
		ColumnHeader2.Width = 100
		ColumnHeader3.Width = 100
		ColumnHeader1.Width = ListView2.Width - ColumnHeader2.Width - ColumnHeader3.Width - 50
	End Sub
End Class
