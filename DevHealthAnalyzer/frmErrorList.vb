Public Class frmErrorList

    Public Sub AddLines(ByVal s As String)
        Dim lines() As String = s.Split(vbCrLf)
        For Each line In lines
            Dim lvi As New ListViewItem(line)
            ListView1.Items.Add(lvi)
        Next
    End Sub

    Public Sub ClearList()
        ListView1.Items.Clear()
    End Sub

    Private Sub ListView1_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.Resize
        ColumnHeader1.Width = ListView1.Width - 20
    End Sub
End Class