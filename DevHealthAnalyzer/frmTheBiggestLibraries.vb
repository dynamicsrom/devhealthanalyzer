Public Class frmTheBiggestLibraries

    Private Sub TheBiggestLibraries_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim s As String = ""
        Dim i As Integer = 0
        ListView1.Items.Clear()
        Try
            For x = 0 To VisualMap.ListView1.Items.Count - 1
                Dim lvi As ListViewItem = VisualMap.ListView1.Items(x)
                If lvi.SubItems(1).Text = s Or lvi.SubItems(1).Text = "NULL" Then
                    i += 1
                Else
                    If Not s = "" Then
                        If i > 25 Then
                            Dim lvi1 As New ListViewItem
                            lvi1.Text = s
                            lvi1.SubItems.Add((i * 4).ToString + " KB")
                            ListView1.Items.Add(lvi1)
                        End If
                    End If
                    s = lvi.SubItems(1).Text
                    i = 1
                End If
            Next
        Catch ex As Exception
            frmErrorList.ClearList()

            frmErrorList.AddLines("Error while making a report from parsed data")
            frmErrorList.ShowDialog()
        End Try
    End Sub

    Private Sub ListView1_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.Resize
        ColumnHeader2.Width = 80
        ColumnHeader1.Width = ListView1.Width - 80 - 40
    End Sub
End Class