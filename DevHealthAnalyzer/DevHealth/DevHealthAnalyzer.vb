Public Class DevHealthAnalyzer

    Private _SystemMemoryReport As String

    Private _ProcessArray As New List(Of ProcessHealthInfo)
    Private _BootTimeMarkers As New List(Of BootTimeMarker)
    Private _ModuleReports As New List(Of ModuleReport)

	Public Class BootTimeMarker
		Public MarkerName As String
		Public value As Integer
	End Class
	Public Class ModuleReport
		Public Enum PageStatus
			NotPageable = 0
			Pageable = 1
			PartlyPageable = 2
			Cannot = 3
		End Enum

		Public Name As String
		Public InUse As Double
		Public StartAddress As Double
		Public EndAddress As Double
		Public Size As Double
		Public Page As PageStatus
	End Class
    Public ReadOnly Property ProcessArray() As List(Of ProcessHealthInfo)
        Get
            Return _ProcessArray
        End Get
    End Property
    Public ReadOnly Property BootTimeMarkers() As List(Of BootTimeMarker)
        Get
            Return _BootTimeMarkers
        End Get
    End Property
	Public ReadOnly Property SystemMemoryReport() As String
		Get
			Return _SystemMemoryReport
		End Get
	End Property
    Public ReadOnly Property ModuleReports() As List(Of ModuleReport)
        Get
            Return _ModuleReports
        End Get
    End Property
	Private Function GetSymbolsCount(ByVal str As String, ByVal chr As String) As Integer
		Dim res As Integer = 0
		For x = 0 To str.Length - 1
			If str.Substring(x, 1) = chr Then
				res += 1
			End If
		Next
		Return res
	End Function

	Private Sub MapDSymbols(ByRef symbols() As Int64, ByVal str As String, ByVal chr As String)
		Dim res As Integer = 0
		For x = 0 To str.Length - 1
			If str.Substring(x, 1) = chr Then
				symbols(res) = x
				res += 1
			End If
		Next
	End Sub

	Private Function GetWhatToFind(ByVal s As String) As String
		Dim dllIndex As Integer = s.ToLower.IndexOf(".dll")
		Dim cplIndex As Integer = s.ToLower.IndexOf(".cpl")
		Dim acmIndex As Integer = s.ToLower.IndexOf(".acm")

		If Not dllIndex = -1 And cplIndex = -1 And acmIndex = -1 Then
			Return ".dll"
		ElseIf dllIndex = -1 And Not cplIndex = -1 And acmIndex = -1 Then
			Return ".cpl"
		ElseIf dllIndex = -1 And cplIndex = -1 And Not acmIndex = -1 Then
			Return ".acm"
		Else
            Dim arr As New List(Of Integer)
			arr.Add(dllIndex)
			arr.Add(cplIndex)
			arr.Add(acmIndex)
			arr.Sort()
			For x = 0 To 3
				If Not arr(x) = -1 Then
					Return arr(x)
				End If
			Next
			Return Nothing
		End If
	End Function

	Private Function GetLibEndIndex(ByVal line As String, ByVal substr As String) As Integer
		'Dim s1 As String = line.Substring(0, line.IndexOf(substr))
		Dim libEndIndex As Integer = line.ToLower.IndexOf(substr) + substr.Length
		Dim spaceIndex As Integer = line.Substring(libEndIndex).IndexOf(" ")
		If spaceIndex = -1 Then
			Return -1
		End If

		libEndIndex = libEndIndex + spaceIndex 'line.Substring(line.IndexOf(" "))
		Return libEndIndex
	End Function

	Private Function AnalyzeLine(ByVal phi As ProcessHealthInfo, ByVal line As String) As Integer
		Try
			line = line.Substring(2)
			Dim addr As Int64 = Val("&H" + line.Substring(0, 8))
			line = line.Substring(line.IndexOf(": ") + 2)
			Dim map As String = line.Substring(0, 16)
			Dim DCount As Integer = GetSymbolsCount(map, "D")
			line = line.Substring(line.IndexOf("DLL: ") + 5)
			Dim libs(DCount) As String
			Dim libsAddresses(DCount) As Int64
			Dim libsDSymbols(DCount) As Int64
			MapDSymbols(libsDSymbols, map, "D")
			Dim prevLine As String = ""
			For x = 0 To DCount - 1
				If line.StartsWith("+") Then
					libs(x) = prevLine

					If Not x = DCount - 1 Then
						line = line.Substring(2)
					End If
				Else

					Dim substr As String = GetWhatToFind(line)
					If Not substr Is Nothing Then
						Dim libEndIndex As Integer = GetLibEndIndex(line, substr)
						Dim libraryName As String
						If libEndIndex = -1 Then
							libraryName = line
						Else
							libraryName = line.Substring(0, libEndIndex)
							line = line.Substring(libraryName.Length + 1)
							'line = line.Substring
						End If
						prevLine = libraryName
						libs(x) = libraryName
					End If
				End If
				libsAddresses(x) = addr + libsDSymbols(x) * 4096 - phi.SlotBase
			Next

			For x = 0 To DCount - 1
				Dim mhi As New MemoryHealthInfo
				mhi.LibraryName = libs(x)
				mhi.MemoryAddress = libsAddresses(x)
				mhi.MemorySize = 4096
				phi.LibraryList.Add(mhi)
			Next
		Catch ex As Exception
			Return 0
		End Try
		Return 1
	End Function

	Private Sub ClearProcessHealthInfo(ByVal processHealthInfo As ProcessHealthInfo)
		Dim prevLib As String = ""
		Dim prevAddr As Int64 = 0
		Dim prevSize As Int64 = 0
		Dim firstX As Integer = -1
        Dim array As List(Of MemoryHealthInfo) = processHealthInfo.LibraryList

		Dim arrayCount = array.Count
		For x = 0 To arrayCount - 1
			If x < arrayCount Then
				Dim mhi As MemoryHealthInfo = array(x)
				If mhi.LibraryName = prevLib Then
					array.RemoveAt(x)
					x -= 1
					arrayCount -= 1
				Else
					If Not firstX = -1 Then
						Dim mhiOld As MemoryHealthInfo = array(firstX)
						mhiOld.MemorySize = prevSize
					End If
					prevLib = mhi.LibraryName
					prevAddr = mhi.MemoryAddress
					prevSize = 0
					firstX = x
				End If
				prevSize += mhi.MemorySize
			End If
		Next
	End Sub

	Private Enum CurrentInfo
		Unknown = 0
		BootupTimeMarkers = 1
		SystemMemoryReport = 2
		SystemMemoryMap = 3
		ModuleReport = 4
		HeapReport = 5
	End Enum


	Private Function GetSpacesCount(ByVal s As String) As Integer
		For x = 0 To s.Length - 2
			If Not s.Substring(x, 1) = " " Then
				Return x
			End If
		Next
		Return -1
	End Function

	Private Function GetUsefulLineLength(ByVal s As String) As Integer
		Dim i As Integer = -1
		For x = 0 To s.Length - 1
			If s.Substring(x, 1) = " " Then
				If i = 0 Then
					i = x
				End If
			Else
				i = 0
			End If
		Next
		If i = 0 And s.Length > 0 Then
			i = s.Length - 1
		End If
		Return i
	End Function

    Public Function Parse(ByVal lines() As String) As String
        Dim log As String = ""
        Dim phi As New ProcessHealthInfo
        Dim curInfo As CurrentInfo = CurrentInfo.Unknown
        For x = 0 To lines.Length - 1
            Dim str As String = lines(x)
            If str.StartsWith("Memory usage for Process") Then
                Dim memoryUsageProcess As String = str.Substring(str.IndexOf("'") + 1)
                memoryUsageProcess = memoryUsageProcess.Substring(0, memoryUsageProcess.LastIndexOf("'"))
                phi.ProcessName = memoryUsageProcess
            ElseIf str.Contains("page summary") And Not str.Contains("===") Then
                'ClearProcessHealthInfo(phi)
                If Not phi Is Nothing Then
                    If Not phi.ProcessName Is Nothing Then
                        If Not phi.ProcessName.ToLower = "nk.exe" Then
                            ProcessArray.Add(phi)
                        End If
                    End If
                End If
                phi = New ProcessHealthInfo
            ElseIf str.Contains("Slot base ") Then
                If Not phi Is Nothing Then
                    If Not phi.ProcessName Is Nothing Then
                        If Not phi.ProcessName.ToLower = "nk.exe" Then
                            str = str.Replace("Slot base ", "")
                            phi.SlotBase = Val("&H" + str.Substring(0, 8).ToUpper)
                        End If
                    End If
                End If
            ElseIf str.StartsWith("Bootup Time Markers (Milliseconds)") Then
                curInfo = CurrentInfo.BootupTimeMarkers
            ElseIf str.StartsWith("System Memory Report") Then
                curInfo = CurrentInfo.SystemMemoryReport
            ElseIf str.StartsWith("System Memory Map") Then
                curInfo = CurrentInfo.SystemMemoryMap
            ElseIf str.StartsWith("Module Report") Then
                curInfo = CurrentInfo.ModuleReport
            ElseIf str.StartsWith("Heap Report") Then
                curInfo = CurrentInfo.HeapReport
            Else
                If curInfo = CurrentInfo.SystemMemoryReport Then
                    If str.Length > 2 Then
                        _SystemMemoryReport += str + vbCr
                    End If
                ElseIf curInfo = CurrentInfo.BootupTimeMarkers Then
                    If str.Length > 2 And str.Contains(" = ") Then
                        Dim btm As New BootTimeMarker
                        btm.MarkerName = str.Substring(0, str.IndexOf(" ="))
                        btm.value = Int(str.Substring(str.IndexOf("= ") + 2))
                        _BootTimeMarkers.Add(btm)
                    End If
                ElseIf curInfo = CurrentInfo.ModuleReport Then
                    If str.Contains("0x") And str.Contains("|") Then
                        Dim mr As New ModuleReport

                        mr.Name = str.Substring(0, str.IndexOf("|"))
                        mr.Name = mr.Name.Substring(GetSpacesCount(mr.Name))
                        mr.Name = mr.Name.Substring(0, GetUsefulLineLength(mr.Name))

                        If mr.Name = "wspm.dll" Then
                            mr.Name = mr.Name
                        End If
                        Dim report As String = str.Substring(str.IndexOf("|") + 2).ToUpper

                        mr.InUse = Val("&H" + report.Substring(2, 8))
                        If mr.InUse < 0 Then
                            mr.InUse = -mr.InUse
                        End If
                        mr.StartAddress = Val("&H" + report.Substring(15, 8))
                        mr.EndAddress = Val("&H" + report.Substring(28, 8))

                        Dim pagestat As String = report.Substring(39, 1)
                        If pagestat = "Y" Then
                            mr.Page = ModuleReport.PageStatus.Pageable
                        ElseIf pagestat = "N" Then
                            mr.Page = ModuleReport.PageStatus.NotPageable
                        ElseIf pagestat = "C" Then
                            mr.Page = ModuleReport.PageStatus.Cannot
                        Else
                            mr.Page = ModuleReport.PageStatus.PartlyPageable
                        End If
                        mr.Size = mr.EndAddress - mr.StartAddress + 1

                        _ModuleReports.Add(mr)
                    End If
                ElseIf curInfo = CurrentInfo.SystemMemoryMap Then
                    If Not phi Is Nothing Then
                        If Not phi.ProcessName Is Nothing Then
                            If Not phi.ProcessName.ToLower = "nk.exe" Then
                                If str.Contains("DLL: ") Then
                                    If AnalyzeLine(phi, str) = 0 Then
                                        log = log + "[" + (x + 1).ToString + "] Parsing error" + vbCrLf
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        Next
        Return log
    End Function

End Class
