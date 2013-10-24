Public Class frmMemoryReport

    Private Function GetSpacesCount(ByVal s As String) As Integer
        For x = 0 To s.Length - 2
            If Not s.Substring(x, 1) = " " Then
                Return x
            End If
        Next
        Return -1
    End Function

    Public Class TreeNodeInfo

        Public Level As Integer
        Public SpacesCount As Integer

        Public Sub New(ByVal newLevel As Integer, ByVal newSpacesCount As Integer)
            Level = newLevel
            SpacesCount = newSpacesCount
        End Sub

    End Class

    Private Shared Function GetLevelBySpacesCount(ByRef array As List(Of TreeNodeInfo), ByVal SpacesCount As Integer) As Integer
        For Each tni In array
            If tni.SpacesCount = SpacesCount Then
                Return tni.Level
            End If
        Next
        Return -1
    End Function

    Private Function GetLevel(ByVal node As CommonTools.Node) As Integer
        Dim i As Integer = 0
        While Not node.Parent Is Nothing
            node = node.Parent
            i += 1
        End While
        Return i
    End Function

    Private Function JumpToNode(ByVal CurrentNode As CommonTools.Node, ByVal level As Integer) As CommonTools.Node
        If GetLevel(CurrentNode) < level Then
            Return Nothing
        Else
            While Not GetLevel(CurrentNode) = level
                CurrentNode = CurrentNode.Parent
            End While
            Return CurrentNode
        End If
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

    Private Sub BeatifyLine(ByVal s As String, ByRef name As String, ByRef pagesCount As String, ByRef sizeInBytes As String)
        'Dim res As String = ""

        name = s.Substring(0, s.IndexOf("|"))
        name = name.Substring(0, GetUsefulLineLength(name))
        'res = name

        s = s.Substring(s.IndexOf("|") + 1)
        pagesCount = s.Substring(0, s.IndexOf("|"))
        pagesCount = pagesCount.Substring(GetSpacesCount(pagesCount))
        pagesCount = pagesCount.Substring(0, GetUsefulLineLength(pagesCount))
        'res = res + " | pages: " + pagesCount

        s = s.Substring(s.IndexOf("|") + 1)
        sizeInBytes = s.Substring(0, s.IndexOf("|"))
        sizeInBytes = sizeInBytes.Substring(GetSpacesCount(sizeInBytes))
        sizeInBytes = sizeInBytes.Substring(0, GetUsefulLineLength(sizeInBytes))
        sizeInBytes = (Int(sizeInBytes) \ 1024 \ 1024).ToString + " MB"
        'res = res + " | size: " + (Int(sizeInBytes) \ 1024 \ 1024).ToString + " MB"

    End Sub

    Private Sub MemoryReport_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        'Me.Location = New System.Drawing.Point(Me.Location.X + 1, Me.Location.Y)
        Me.Size = New System.Drawing.Size(Me.Width + 1, Me.Height)
    End Sub
    Private Sub MemoryReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            TreeListView1.Nodes.Clear()
            Dim array As New List(Of TreeNodeInfo)
            array.Add(New TreeNodeInfo(0, 0))
            'Dim n As New CommonTools.TreeList
            Dim fields1(3) As String
            fields1(0) = "Memory report"
            fields1(1) = " "
            fields1(2) = " "
            Dim CoreNode As New CommonTools.Node(fields1) 'lds'"Memory Report", "1", "2")	'TreeNode("Memory Report")
            Dim LastNode As CommonTools.Node = CoreNode
            Dim lastSpacesCount = 0

            'For x = 0 To TextBox1.Lines.Length - 1
            'Dim s As String = TextBox1.Lines(x)
            Dim fullReport As String = ReportManager.DevHealth.SystemMemoryReport
            Dim lines() As String = fullReport.Split(vbCr)
            For Each line In lines
                Dim s As String = line
                If s.Contains("|") Then
                    Dim firstcolumn As String = s.Substring(0, s.IndexOf("|"))
                    If firstcolumn.Replace(" ", "").Length > 0 Then
                        Dim SpacesCount As Integer = GetSpacesCount(s)
                        Dim LineLevel As Integer = GetLevelBySpacesCount(array, SpacesCount)
                        Dim ShouldBecomeCore As Boolean = False
                        If SpacesCount < lastSpacesCount Then
                            CoreNode = JumpToNode(CoreNode, LineLevel)
                        ElseIf SpacesCount > lastSpacesCount Then
                            CoreNode = LastNode
                            array.Add(New TreeNodeInfo(GetLevel(CoreNode), SpacesCount))
                        End If
                        Dim name As String = ""
                        Dim pagesCount As String = ""
                        Dim sizeInBytes As String = ""
                        If Not SpacesCount = -1 Then
                            s = s.Substring(SpacesCount)
                            BeatifyLine(s, name, pagesCount, sizeInBytes)
                        End If
                        Dim fields(3) As String
                        fields(0) = name
                        fields(1) = pagesCount
                        fields(2) = sizeInBytes
                        Dim node As New CommonTools.Node(fields)
                        CoreNode.Nodes.Add(node)
                        'Dim node As CommonTools.Node = CoreNode.Nodes.Add(s)
                        'node.SetData(
                        LastNode = node
                        lastSpacesCount = SpacesCount
                    End If
                End If
            Next

            TreeListView1.Nodes.Add(JumpToNode(CoreNode, 0))
        Catch ex As Exception
            frmErrorList.ClearList()

            frmErrorList.AddLines("Error while parsing a memory report")
            frmErrorList.ShowDialog()
        End Try
        TreeListView1.Nodes(0).ExpandAll()

    End Sub
End Class