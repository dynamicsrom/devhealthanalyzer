Public Class frmAboutBox

    Private Sub AboutBox_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label2.Text = "Version: " + Application.ProductVersion
        Dim year As Integer = DateTime.Now.Date.Year
        If Not year = 2011 And year > 2011 Then
            Label3.Text = "© ultrashot 2011-" + year.ToString
        Else
            Label3.Text = "© ultrashot 2011"
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class