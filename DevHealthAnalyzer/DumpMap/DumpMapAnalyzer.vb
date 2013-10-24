Public Class DumpMapAnalyzer

    Private _MemoryArray As New List(Of MemoryHealthInfo)

    Public ReadOnly Property MemoryArray() As List(Of MemoryHealthInfo)
        Get
            Return _MemoryArray
        End Get
    End Property

	Enum Mode
		NoMode
		ImgfsLow
		ImgfsHigh
		XipLow
	End Enum

	Public Function GetMemoryInfo(ByVal address As Int64) As MemoryHealthInfo
		For each mhi In MemoryArray
			If mhi.MemoryAddress = address Then
				Return mhi
			End If
		Next
		Return Nothing
	End Function
	Public Sub Parse(ByVal lines() As String)
		Dim phi As New ProcessHealthInfo
		Dim mode As Mode = DumpMapAnalyzer.Mode.NoMode
		For x = 0 To lines.Length - 1
			Dim str As String = lines(x)
			If str.Contains("START: Slot 0 IMGFS High") Then
				mode = DumpMapAnalyzer.Mode.ImgfsHigh
			ElseIf str.Contains("START: Slot 0 IMGFS Low") Then
				mode = DumpMapAnalyzer.Mode.ImgfsLow
			ElseIf str.Contains("START: Slot 0 XIP ") Then
				mode = DumpMapAnalyzer.Mode.XipLow
			ElseIf str.Contains("END:   Slot 0 IMGFS Low") Or str.Contains("END:   Slot 0 IMGFS High") Or str.Contains("END:   Slot 0 XIP ") Then
				mode = DumpMapAnalyzer.Mode.NoMode
			Else
				If mode = DumpMapAnalyzer.Mode.ImgfsHigh _
				Or mode = DumpMapAnalyzer.Mode.ImgfsLow _
				Or mode = DumpMapAnalyzer.Mode.XipLow Then
					Dim addr As String = str.Substring(0, 8)
					Dim size As String = str.Substring(str.IndexOf("L") + 1, 8)
					Dim uAddr As Int64 = Val("&H" + addr)
					Dim uSize As Int64 = Val("&H" + size)

					For y As Int64 = 0 To uSize - 4096 Step 4096
						Dim mhi As New MemoryHealthInfo
						mhi.LibraryName = str.Substring(28).ToLower
						If mhi.LibraryName = "nul" Then
							mhi.LibraryName = "NULL"
						End If
						mhi.MemoryAddress = uAddr + y
						mhi.MemorySize = 4096
						MemoryArray.Add(mhi)
					Next
				End If
			End If
		Next
	End Sub
End Class
