Public Class ReportManager

	Private Shared _devhealth As DevHealthAnalyzer
	Private Shared _dumpmap As DumpMapAnalyzer
	Private Shared _devhealthraw As String
	Private Shared _dumpmapraw As String
	Private Shared _errors As String = ""
	Private Shared _isReady As Boolean = False
	Private Shared _isFullyFunctional As Boolean = False
	Private Shared _dumpMapName As String = ""
	Private Shared _rawReport As String = ""

#Region "Properties"

	Public Shared ReadOnly Property IsReady() As Boolean
		Get
			Return _isReady
		End Get
	End Property

	Public Shared ReadOnly Property DevHealth() As DevHealthAnalyzer
		Get
			Return _devhealth
		End Get
	End Property

	Public Shared ReadOnly Property DumpMap() As DumpMapAnalyzer
		Get
			Return _dumpmap
		End Get
	End Property

	Public Shared ReadOnly Property IsFullyFunctional() As Boolean
		Get
			Return _isFullyFunctional
		End Get
	End Property

	Public Shared ReadOnly Property Errors()
		Get
			Return _errors
		End Get
	End Property

	Public Shared ReadOnly Property RawReport() As String
		Get
			Return _rawReport
		End Get
	End Property

	Public Shared ReadOnly Property DumpMapName() As String
		Get
			Return _dumpMapName
		End Get
	End Property

	Public Shared ReadOnly Property DevHealthRaw() As String
		Get
			Return _devhealthraw
		End Get
	End Property

	Public Shared ReadOnly Property DumpMapRaw() As String
		Get
			Return _dumpmapraw
		End Get
	End Property

#End Region

	Private Shared Sub Initialize()
		_devhealth = New DevHealthAnalyzer
		_dumpmap = New DumpMapAnalyzer
		_errors = ""
		_isReady = False
		_dumpMapName = "Unnamed"
		_dumpmapraw = ""
		_devhealthraw = ""
	End Sub


	Public Shared Function ParseReports(ByVal DevHealthReport() As String, ByVal DumpMapReport() As String, ByVal CurDevHealthRaw As String, ByVal CurDumpMapRaw As String)
		Initialize()
		Dim s As String = _devhealth.Parse(DevHealthReport)
		_dumpmap.Parse(DumpMapReport)
		_errors = s
		_isReady = True
		_isFullyFunctional = True
		_devhealthraw = CurDevHealthRaw
		_dumpmapraw = CurDumpMapRaw
		If _errors = "" Then
			Return 1
		End If
		Return 0
	End Function

	Public Shared Function ParseReports(ByVal rawDump As String) As Integer
		Initialize()
		_errors = ""
		_isReady = True
		_isFullyFunctional = False
		Return 1
	End Function

	Private Shared Sub LoadFile_V1(ByVal filename As String)
		Dim sr As IO.StreamReader = IO.File.OpenText(filename)
		Dim line As String = sr.ReadLine
		Dim curDumpMapName As String = line
		_rawReport = sr.ReadToEnd
		sr.Close()
		ParseReports(_rawReport)
		_dumpMapName = curDumpMapName
	End Sub

	Private Shared Sub LoadFile_V2(ByVal filename As String)
		Dim sr As IO.StreamReader = IO.File.OpenText(filename)
		Dim line As String = sr.ReadLine
		Dim curDumpMapName As String = sr.ReadLine
		line = sr.ReadLine
		Dim DevHealthReport As String = ""
		Dim DumpMapReport As String = ""
		Dim currentReport As Integer = 0
		While Not line Is Nothing
			If line = "DEVHEALTHREPORT_END" Then
				currentReport = 1
			ElseIf line = "DUMPMAP_END" Then
				Exit While
			Else
				If currentReport = 0 Then
					DevHealthReport = DevHealthReport + line + vbCr
				Else
					DumpMapReport = DumpMapReport + line + vbCr
				End If
			End If
			line = sr.ReadLine
		End While
		sr.Close()
		_devhealthraw = DevHealthReport.Replace(vbCr, vbCrLf)
		_dumpmapraw = DumpMapReport.Replace(vbCr, vbCrLf)
		ParseReports(DevHealthReport.Split(vbCr), DumpMapReport.Split(vbCr), DevHealthReport, DumpMapReport)
		_dumpMapName = curDumpMapName
	End Sub

	Public Shared Sub LoadFile(ByVal filename As String)
		Dim sr As IO.StreamReader = IO.File.OpenText(filename)
		Dim line As String = sr.ReadLine
		sr.Close()
		If line = "DHAV2" Then
			LoadFile_V2(filename)
		Else
			LoadFile_V1(filename)
		End If
	End Sub

End Class
