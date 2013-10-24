Public Class ProcessHealthInfo

	Private _processName As String
	Private _slotBase As Int64
    Private _dlls As New List(Of MemoryHealthInfo)

	Public Property ProcessName() As String
		Get
			Return _processName
		End Get
		Set(ByVal value As String)
			_processName = value
		End Set
	End Property

	Public Property SlotBase() As Int64
		Get
			Return _slotBase
		End Get
		Set(ByVal value As Int64)
			_slotBase = value
		End Set
	End Property

    Public ReadOnly Property LibraryList() As List(Of MemoryHealthInfo)
        Get
            Return _dlls
        End Get
    End Property

End Class