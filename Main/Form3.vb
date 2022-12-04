Imports System.IO
Imports System.Text

Public Class Form3
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Hide()
        Form1.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim username As New StringBuilder
        Dim password As New StringBuilder
        username.AppendLine(TextBox1.Text)
        Dim detailspath As String = "D:\Users\Nisar\Documents\GitHub\Quiz_Game\Main\Text documents\Login details.txt"
        File.AppendAllText(detailspath, username.ToString())


    End Sub
End Class