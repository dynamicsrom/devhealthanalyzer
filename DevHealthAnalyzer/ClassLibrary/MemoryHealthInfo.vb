Public Class MemoryHealthInfo

	Private _memoryAddr As Int64
	Private _memorySize As Int64
	Private _libraryName As String
    Private _privateValue As Integer
    Private _privateStrings As String
	Public Property MemoryAddress() As Int64
		Get
			Return _memoryAddr
		End Get
		Set(ByVal value As Int64)
			_memoryAddr = value
		End Set
	End Property
	Public Property MemorySize() As Int64
		Get
			Return _memorySize
		End Get
		Set(ByVal value As Int64)
			_memorySize = value
		End Set
	End Property
	Public Property LibraryName() As String
		Get
			Return _libraryName
		End Get
		Set(ByVal value As String)
			_libraryName = value
		End Set
	End Property

    Public Property PrivateValue() As Integer
        Get
            Return _privateValue
        End Get
        Set(value As Integer)
            _privateValue = value
        End Set
    End Property

    Public Property PrivateStrings() As String
        Get
            Return _privateStrings
        End Get
        Set(value As String)
            _privateStrings = value
        End Set
    End Property
End Class