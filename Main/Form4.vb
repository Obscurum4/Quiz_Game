Imports System.IO
Imports System.Text
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel

Public Class Form4



    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub


    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Hide()
        Form1.Show()
    End Sub

    Private Function store(username, detailspath2) 'Declare function that stores the username in a temporary directory for later use
        File.AppendAllText(detailspath2, username.ToString()) 'Stores the username in the temporary file directory
    End Function



    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim username As New StringBuilder
        Dim detailspath As String = "D:\Users\Nisar\Documents\GitHub\Quiz_Game\Main\Text documents\Login details.txt" 'Declares where the directory with all the login details is
        Dim detailspath2 As String = "D:\Users\Nisar\Documents\GitHub\Quiz_Game\Main\Text documents\temp_usernames.txt" 'Declares where the directory that stores the username temporarily
        Dim info = File.ReadAllText(detailspath)
        username.AppendLine(TextBox1.Text)
        If info.Contains(username.ToString) Then
            store(username, detailspath2)
            Hide()
            Form5.Show()
        Else
            MsgBox("Try again") 'Error message displayed as a result of a username not being found in the database
        End If
    End Sub




End Class