﻿Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Hide()
        Form2.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Hide()
        Form3.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Hide()
        Form4.Show()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim guest_access As Boolean
        guest_access = True
        Hide()
        Form6.Show()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim fileStream2 As New System.IO.FileStream("D:\Users\Nisar\Documents\GitHub\Quiz_Game\Main\Text documents\category.txt", System.IO.FileMode.Truncate) 'Wipes all the contents of the temporary text file so it can be used again
        fileStream2.Close() 'Closes the file for later use
        Dim fileStream As New System.IO.FileStream("D:\Users\Nisar\Documents\GitHub\Quiz_Game\Main\Text documents\game_username.txt", System.IO.FileMode.Truncate) 'Wipes all the contents of the temporary text file so it can be used again
        fileStream.Close() 'Closes the file for later use
    End Sub
End Class
