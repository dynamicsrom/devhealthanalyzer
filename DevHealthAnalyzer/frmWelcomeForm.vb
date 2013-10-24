Imports DevHealthAnalyzer
Imports DevHealthAnalyzer.DevHealthAnalyzer
Imports System.IO

Public Class frmWelcomeForm

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If My.Computer.Clipboard.ContainsText = True Then
            txtReport.Text = My.Computer.Clipboard.GetText()
        End If
    End Sub

    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
        BackgroundWorker1.RunWorkerAsync()
    End Sub

    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        BackgroundWorker1.ReportProgress(1)
        ReportManager.ParseReports(txtReport.Lines, txtDumpMap.Lines, txtReport.Text, txtDumpMap.Text)
    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        If e.ProgressPercentage = 1 Then
            ProgressBar1.Style = ProgressBarStyle.Marquee
            ProgressBar1.Value = 50
        End If
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        ProgressBar1.Style = ProgressBarStyle.Blocks
        Me.Opacity = 0
        Me.ShowInTaskbar = False
        VisualMap.ShowDialog()
    End Sub

    Private Function ReadBriefInfo(ByVal file As String) As String
        Dim res As String = ""
        If IO.File.Exists(file) Then
            Try
                Dim sr As IO.StreamReader = IO.File.OpenText(file)

                res = sr.ReadLine()
                If res = "DHAV2" Then
                    res = sr.ReadLine()
                End If
                sr.Close()
            Catch ex As Exception
            End Try
        End If
        Return res
    End Function

    Private Sub WelcomeForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim arg As String = Command().Replace("""", "")
        If IO.File.Exists(arg) Then
            Me.Opacity = 0
            Me.ShowInTaskbar = False
            ReportManager.LoadFile(arg)
            VisualMap.ShowDialog()
        End If
        GroupBox1.Visible = False
        GroupBox2.Visible = True
        lvSlotmaps.Items.Clear()
        Dim files() As String = IO.Directory.GetFiles(Application.StartupPath)
        For Each file In files
            If file.EndsWith(".slotmap") Then
                Dim lvi As New ListViewItem
                Dim shortname As String = file.Substring(file.LastIndexOf("\") + 1)
                shortname = shortname.Substring(0, shortname.LastIndexOf("."))
                lvi.Text = shortname
                lvi.SubItems.Add(ReadBriefInfo(file))
                lvSlotmaps.Items.Add(lvi)
            End If
        Next
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateNewMap.Click
        GroupBox1.Visible = True
        GroupBox2.Visible = False
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        GroupBox1.Visible = False
        GroupBox2.Visible = True
    End Sub

    Private Sub btnOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpen.Click
        If lvSlotmaps.SelectedIndices.Count = 1 Then
            Me.Opacity = 0
            Me.ShowInTaskbar = False
            'BackgroundWorker2.RunWorkerAsync()
            ReportManager.LoadFile(Application.StartupPath + "\" + lvSlotmaps.SelectedItems(0).Text + ".slotmap")
            VisualMap.ShowDialog()
        End If
    End Sub

    Private Sub Button1_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmErrorList.AddLines("Test" + vbCrLf + "Test2")
        frmErrorList.ShowDialog()
    End Sub

    Private Sub lvSlotmaps_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvSlotmaps.Resize
        ColumnHeader1.Width = 150
        ColumnHeader2.Width = lvSlotmaps.Width - ColumnHeader1.Width - 40
    End Sub

End Class
