Imports System.Drawing.Text
Imports System.IO
Imports System.Reflection.Metadata.Ecma335
Imports System.Text
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel

Public Class Form3
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Hide()
        Form1.Show()
    End Sub

    Private Function store(username, password, detailspath)
        File.AppendAllText(detailspath, username.ToString())
        File.AppendAllText(detailspath, password.ToString())
    End Function

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim username As New StringBuilder
        Dim password As New StringBuilder
        Dim detailspath As String = "D:\Users\Nisar\Documents\GitHub\Quiz_Game\Main\Text documents\Login details.txt"
        Dim info = File.ReadAllText(detailspath)
        username.AppendLine(TextBox1.Text)
        password.AppendLine(TextBox2.Text)
        If info.Contains(username.ToString()) Then
            MsgBox("Usernane already exists, please try again")
        Else
            store(username, password, detailspath)
        End If




    End Sub
End Class