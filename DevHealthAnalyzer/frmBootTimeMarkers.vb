Public Class frmBootTimeMarkers

    Private Sub ListView1_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.Resize
        ColumnHeader2.Width = 80
        ColumnHeader1.Width = ListView1.Width - 80 - 40
    End Sub

    Private Sub BootTimeMarkers_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ListView1.Items.Clear()
        Dim array As List(Of DevHealthAnalyzer.BootTimeMarker) = ReportManager.DevHealth.BootTimeMarkers
        For Each btm In array
            Dim text As String = btm.MarkerName
            Dim value As String = btm.value.ToString + " ms"
            If text = "Available RAM on boot" Then
                value = (btm.value \ 1024 \ 1024).ToString + " MB"
            ElseIf text = "Last Boot Type" Then
                value = btm.value.ToString
            End If

            Dim lvi As New ListViewItem
            lvi.Text = text
            lvi.SubItems.Add(value)
            ListView1.Items.Add(lvi)
        Next
    End Sub
End Class