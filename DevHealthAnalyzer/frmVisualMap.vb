Imports DevHealthAnalyzer
Imports DevHealthAnalyzer.DevHealthAnalyzer
Imports System.Threading.Tasks
Public Class VisualMap

	Private Sub VisualMap_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
		Application.Exit()
	End Sub

	Sub InitHealthInfo()
		If ListView1.Items.Count > 0 Then
			Dim kb As Integer = Val("&H" + ListView1.Items(0).SubItems(0).Text) / 1024
			HealthMaxAmount.Text = "Max amount: " + kb.ToString + " KB"
			If kb < 20000 Then
				HealthPictureBox.BackColor = Color.Red
				HealthLabel.Text = " - critical. Try to reduce slot 0 usage."
			ElseIf kb < 25000 Then
				HealthPictureBox.BackColor = Color.Yellow
				HealthLabel.Text = " - normal. No serious problems, but try to eliminate rarely used libraries"
			Else
				HealthPictureBox.BackColor = Color.LightGreen
				HealthLabel.Text = " - very good. No actions are required"
			End If
		End If
	End Sub

    Private Function FindMemoryBlock(ByRef phi As ProcessHealthInfo, ByVal x As Int64) As MemoryHealthInfo
        For Each mhi In phi.LibraryList
            If mhi.MemoryAddress = x Then
                Return mhi
            ElseIf mhi.MemoryAddress > x Then
                Return Nothing
            End If
        Next
        Return Nothing
    End Function

    Sub InitSlotInfo(ByVal show As Boolean)
        ListView1.Items.Clear()
        If ReportManager.IsFullyFunctional = True Then
            'Dim list As New List(Of MemoryHealthInfo)(8192)
            Dim isAnyItem As Boolean = False
            For x As Int64 = 0 To (33554432 - 4096) Step 4096
                Dim resmhi As MemoryHealthInfo = Nothing
                For Each phi In ReportManager.DevHealth.ProcessArray
                    Dim mhi As MemoryHealthInfo = FindMemoryBlock(phi, x)
                    If resmhi Is Nothing Then
                        If Not mhi Is Nothing Then
                            resmhi = mhi
                            resmhi.PrivateValue = 0
                            resmhi.PrivateStrings = ""
                        End If
                    End If
                    If Not resmhi Is Nothing And Not mhi Is Nothing Then
                        resmhi.PrivateStrings = resmhi.PrivateStrings + phi.ProcessName + "; "
                    End If
                Next
                If resmhi Is Nothing Then
                    resmhi = ReportManager.DumpMap.GetMemoryInfo(x)
                    If Not resmhi Is Nothing Then
                        'If resmhi.LibraryName = "NULL" Then
                        'resmhi = Nothing
                        'Else
                        resmhi.PrivateValue = 1
                        resmhi.PrivateStrings = ""
                        'End If
                    End If
                End If

                If resmhi Is Nothing And isAnyItem = True Then
                    Dim lvi As New ListViewItem
                    lvi.Text = Hex(x).ToString
                    lvi.SubItems.Add("NULL")
                    lvi.SubItems.Add("")
                    lvi.BackColor = Color.LightBlue
                    ListView1.Items.Add(lvi)
                ElseIf Not resmhi Is Nothing Then
                    Dim lvi As New ListViewItem
                    lvi.Text = Hex(resmhi.MemoryAddress).ToString
                    lvi.SubItems.Add(resmhi.LibraryName)
                    lvi.SubItems.Add(resmhi.PrivateStrings)
                    If resmhi.PrivateValue = 1 Then
                        If resmhi.LibraryName = "NULL" Then
                            lvi.BackColor = Color.LightSkyBlue
                        Else
                            lvi.BackColor = Color.LightGreen
                        End If
                    Else
                        lvi.BackColor = Color.White
                    End If
                    isAnyItem = True
                    ListView1.Items.Add(lvi)
                End If
            Next

            'Dim isAnyItem As Boolean = False
            'For x = 0 To list.Count - 1
            'Dim mhi As MemoryHealthInfo = List(x)
            'If mhi Is Nothing And isAnyItem = True Then
            'Dim lvi As New ListViewItem
            'lvi.Text = Hex(x * 4096).ToString
            'lvi.SubItems.Add("NULL")
            'lvi.SubItems.Add("")
            'lvi.BackColor = Color.LightBlue
            'ListView1.Items.Add(lvi)
            ' ElseIf Not mhi Is Nothing Then
            'Dim lvi As New ListViewItem
            'lvi.Text = Hex(mhi.MemoryAddress).ToString
            'lvi.SubItems.Add(mhi.LibraryName)
            'lvi.SubItems.Add(mhi.PrivateStrings)
            'If mhi.PrivateValue = 1 Then
            'lvi.BackColor = Color.LightGreen
            'End If
            'isAnyItem = True
            'ListView1.Items.Add(lvi)
            'End If
            'Next

        Else
            Dim lines() As String = ReportManager.RawReport.Replace(vbCrLf, vbCr).Split(vbCr)
            For Each line In lines
                Try
                    Dim color As Color = color.White
                    If line.StartsWith("[DUMP]") Then
                        color = color.LightGreen
                    ElseIf line.StartsWith("[NULL]") Then
                        color = color.LightBlue
                    End If

                    Dim tempStr As String = line.Substring(line.IndexOf("""") + 1)
                    Dim libraryName As String = tempStr.Substring(0, tempStr.IndexOf(""""))
                    tempStr = tempStr.Substring(tempStr.IndexOf("""") + 1)
                    tempStr = tempStr.Substring(tempStr.IndexOf("""") + 1)
                    Dim libraryAddr As String = tempStr.Substring(0, tempStr.IndexOf(""""))
                    tempStr = tempStr.Substring(tempStr.IndexOf("""") + 1)
                    tempStr = tempStr.Substring(tempStr.IndexOf("""") + 1)
                    Dim libraryExes As String = tempStr.Substring(0, tempStr.IndexOf(""""))

                    Dim lvi As New ListViewItem
                    lvi.Text = libraryAddr
                    lvi.SubItems.Add(libraryName)
                    lvi.SubItems.Add(libraryExes)
                    lvi.BackColor = color
                    ListView1.Items.Add(lvi)
                Catch ex As Exception
                End Try
            Next
        End If
    End Sub

	Sub InitUserInterface()
		menuProcessInfo.Visible = ReportManager.isFullyFunctional
		BootTimeMarkersToolStripMenuItem.Visible = ReportManager.isFullyFunctional
		CurrentConfigurationTextBox.Text = ReportManager.DumpMapName
		SaveToolStripMenuItem.Visible = ReportManager.IsFullyFunctional
		MemoryReportToolStripMenuItem.Visible = ReportManager.IsFullyFunctional
		ModuleReportToolStripMenuItem.Visible = ReportManager.IsFullyFunctional
	End Sub

	Private Sub VisualMap_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		OpenFileDialog1.InitialDirectory = Application.StartupPath
		SaveFileDialog1.InitialDirectory = Application.StartupPath
		InitSlotInfo(True)
		InitHealthInfo()
		InitUserInterface()
		If Not ReportManager.Errors = "" Then
            frmErrorList.ClearList()
            frmErrorList.AddLines(ReportManager.Errors)
            frmErrorList.ShowDialog()
        End If
    End Sub

    Private Sub ListView1_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.SizeChanged
        Dim size As Integer = ListView1.Size.Width
        ColumnHeader3.Width = size - 50 - ColumnHeader1.Width - ColumnHeader2.Width
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ZoomPlus.Click
        Dim fnt As Font = ListView1.Font
        If fnt.SizeInPoints < 76 Then
            ListView1.Font = New Font(fnt.Name, fnt.SizeInPoints + 1, FontStyle.Regular, GraphicsUnit.Point, fnt.GdiCharSet, False)
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ZoomMinus.Click
        Dim fnt As Font = ListView1.Font
        If fnt.SizeInPoints > 4 Then
            ListView1.Font = New Font(fnt.Name, fnt.SizeInPoints - 1, FontStyle.Regular, GraphicsUnit.Point, fnt.GdiCharSet, False)
        End If
    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged
        SelectedLabel.Text = "Selected: " + ListView1.SelectedItems.Count.ToString + " (" + (ListView1.SelectedItems.Count * 4).ToString + " KB)"
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchBox.TextChanged
        Dim searchStr As String = SearchBox.Text.ToLower
        For x = 0 To ListView1.Items.Count - 1
            Dim lvi As ListViewItem
            lvi = ListView1.Items(x)
            If (lvi.SubItems(2).Text.ToLower.Contains(searchStr) Or lvi.SubItems(1).Text.ToLower.Contains(searchStr)) And Not searchStr = "" Then
                lvi.ForeColor = Color.Red
            Else
                lvi.ForeColor = Color.Black
            End If
        Next
    End Sub

    Private Sub SelectAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuSelectAll.Click
        For x = 0 To ListView1.Items.Count - 1
            Dim lvi As ListViewItem
            lvi = ListView1.Items(x)
            If lvi.ForeColor = Color.Red Then
                lvi.Selected = True
            Else
                lvi.Selected = False
            End If
        Next
    End Sub

    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        If CurrentConfigurationTextBox.Text = "" Then
            MessageBox.Show("Please, enter any description", "DevHealth", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            CurrentConfigurationTextBox.Focus()
            Exit Sub
        End If

        SaveFileDialog1.FileName = CurrentConfigurationTextBox.Text.Replace(".", "_")
        If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            If Not SaveFileDialog1.FileName Is Nothing Then
                If ReportManager.IsFullyFunctional = False Then
                    Dim res As String = CurrentConfigurationTextBox.Text + vbCrLf
                    For x = 0 To ListView1.Items.Count - 1
                        Dim lvi As ListViewItem = ListView1.Items(x)
                        Dim line As String = ""
                        If lvi.BackColor = Color.LightGreen Then
                            line += "[DUMP]"
                        ElseIf lvi.BackColor = Color.LightBlue Then
                            line += "[NULL]"
                        Else
                            line += "[DEVH]"
                        End If
                        line = line.PadRight(15, " ") '+= vbTab
                        line += """" + lvi.SubItems(1).Text + """"
                        line = line.PadRight(50, " ") '+= vbTab
                        line += """" + lvi.SubItems(0).Text + """"
                        line = line.PadRight(100, " ") '+= vbTab
                        line += """" + lvi.SubItems(2).Text + """"
                        res += line + vbCrLf
                    Next
                    Dim sw As IO.StreamWriter = IO.File.CreateText(SaveFileDialog1.FileName)
                    sw.Write(res)
                    sw.Close()
                Else
                    Dim sw As IO.StreamWriter = IO.File.CreateText(SaveFileDialog1.FileName)
                    sw.WriteLine("DHAV2")
                    sw.WriteLine(CurrentConfigurationTextBox.Text)
                    sw.Write(ReportManager.DevHealthRaw)
                    sw.WriteLine("DEVHEALTHREPORT_END")
                    sw.WriteLine(ReportManager.DumpMapRaw)
                    sw.WriteLine("DUMPMAP_END")
                    sw.Close()
                End If
            End If
        End If
        'MessageBox.Show(res)
    End Sub

    Private Sub ToolStripTextBox1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CurrentConfigurationTextBox.TextChanged
        If Not CurrentConfigurationTextBox.Text = "" Then
            Me.Text = "Slot 0 Map - " + CurrentConfigurationTextBox.Text
        Else
            Me.Text = "Slot 0 Map"
        End If
    End Sub



    Sub LoadFile_V1(ByVal filename As String)
        ListView1.Items.Clear()
        Dim sr As IO.StreamReader = IO.File.OpenText(filename)
        Dim line As String = sr.ReadLine
        CurrentConfigurationTextBox.Text = line
        line = sr.ReadLine


        sr.Close()
    End Sub


    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()
    End Sub


    Private Sub OpenMainMenuToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenMainMenuToolStripMenuItem.Click
        Application.Restart()
    End Sub

    Private Sub menuProcessInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuProcessInfo.Click
        ProcessReport.ShowDialog()
    End Sub

    Private Sub TheBiggestLibrariesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TheBiggestLibrariesToolStripMenuItem.Click
        frmTheBiggestLibraries.ShowDialog()
    End Sub

    Private Sub BootTimeMarkersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BootTimeMarkersToolStripMenuItem.Click
        frmBootTimeMarkers.ShowDialog()
    End Sub

    Private Sub OpenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripMenuItem.Click
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            If Not OpenFileDialog1.FileName Is Nothing And IO.File.Exists(OpenFileDialog1.FileName) Then
                ReportManager.LoadFile(OpenFileDialog1.FileName)
                InitSlotInfo(True)
                InitHealthInfo()
                InitUserInterface()
                If Not ReportManager.Errors = "" Then
                    frmErrorList.ClearList()
                    frmErrorList.AddLines(ReportManager.Errors)
                    frmErrorList.ShowDialog()
                End If
            End If
        End If
    End Sub

	Private Sub MemoryReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MemoryReportToolStripMenuItem.Click
        frmMemoryReport.ShowDialog()
	End Sub

	Private Sub ModuleReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModuleReportToolStripMenuItem.Click
        frmModuleReport.ShowDialog()
	End Sub

	Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        frmAboutBox.ShowDialog()
	End Sub
End Class