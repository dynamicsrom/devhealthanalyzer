Public Class frmModuleReport

    Public Function GetSuitableName(ByVal mr As DevHealthAnalyzer.ModuleReport.PageStatus) As String
        If mr = DevHealthAnalyzer.ModuleReport.PageStatus.Pageable Then
            Return "Y"
        ElseIf mr = DevHealthAnalyzer.ModuleReport.PageStatus.NotPageable Then
            Return "N"
        ElseIf mr = DevHealthAnalyzer.ModuleReport.PageStatus.Cannot Then
            Return "Cannot"
        Else
            Return "Partly"
        End If
    End Function
    Private Sub ModuleReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ListView1.Items.Clear()
        Try
            Dim list As List(Of DevHealthAnalyzer.ModuleReport) = ReportManager.DevHealth.ModuleReports
            For Each mr In list
                Dim lvi As New ListViewItem
                lvi.Text = mr.Name
                lvi.SubItems.Add(Hex(mr.InUse).ToString)
                lvi.SubItems.Add((mr.Size \ 1024).ToString + " KB")
                'size += mr.InUse
                lvi.SubItems.Add(GetSuitableName(mr.Page))
                If (mr.Size \ 1024) > 50 Then
                    lvi.BackColor = Color.LightGray
                End If
                ListView1.Items.Add(lvi)
            Next
        Catch ex As Exception
            frmErrorList.ClearList()

            frmErrorList.AddLines("Error while making a report from parsed data")
            frmErrorList.ShowDialog()
        End Try
    End Sub

    Private Sub ListView1_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.Resize
        ColumnHeader1.Width = ListView1.Size.Width - 240 - 40
        ColumnHeader2.Width = 80
        ColumnHeader3.Width = 80
        ColumnHeader4.Width = 80
    End Sub
End Class