Imports System.IO
Imports System.Windows
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Status

Public Class Form5


    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Hide()
        Form1.Show()
    End Sub





    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim filePath As String = "D:\Users\Nisar\Documents\GitHub\Quiz_Game\Main\Text documents\temp_usernames.txt" 'Declares location of the database
        Using reader As New StreamReader(filePath)
            Dim username As String = reader.ReadLine()
            Label3.Text = username
        End Using
        If System.IO.File.Exists(filePath) Then
            Dim fileStream As New System.IO.FileStream(filePath, System.IO.FileMode.Truncate)
            fileStream.Close()
        End If
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub
End Class