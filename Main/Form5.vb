﻿Imports System.IO
Imports System.Text
Imports System.Windows
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Status

Public Class Form5


    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Hide()
        Form1.Show()
    End Sub


    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim filePath As String = "D:\Users\Nisar\Documents\GitHub\Quiz_Game\Main\Text documents\temp_usernames.txt" 'Declares location of the text file containing the username for the account the user wants to reset
        Using reader As New StreamReader(filePath)
            Dim username As String = reader.ReadLine() 'Assigns the first line of the text file as a variable called username
            Label3.Text = username 'Displays the username of the user
        End Using
        If System.IO.File.Exists(filePath) Then
            Dim fileStream As New System.IO.FileStream(filePath, System.IO.FileMode.Truncate) 'Wipes all the contents of the temporary text file so it can be used again
            fileStream.Close() 'Closes the file for later use
        End If
    End Sub


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim filePath2 As String = "D:\Users\Nisar\Documents\GitHub\Quiz_Game\Main\Text documents\Login details.txt" 'Declares where the directory with all the login details is
        Dim password As New StringBuilder 'Declares the password variable
        Dim linecount As Integer = 0
        Dim linecount2 As Integer
        password.AppendLine(TextBox1.Text) 'The input in TextBox1 is assigned to the password variable
        Using reader As New StreamReader(filePath2)
            Dim line As String
            While Not reader.EndOfStream 'While loop that lasts until the program has read all lines of the text file individually
                linecount += 1 'Add one to the index to determine which line of the database the username is located in 
                line = reader.ReadLine()
                If line = Label3.Text.ToString Then
                    linecount2 = linecount + 1 'Determines which line of the code the username will be in, which will be the line after
                End If
            End While
        End Using
        Dim linecount3 As Integer = linecount2 - 1
        Dim lines As String() = System.IO.File.ReadAllLines(filePath2) ' Remove the line at index (lines are 0-indexed)
        lines = lines.Where(Function(line, index) index <> linecount3).ToArray()
        System.IO.File.WriteAllLines(filePath2, lines)
        Dim lines2 As String() = System.IO.File.ReadAllLines(filePath2)
        lines2 = lines.Take(linecount3).Concat({TextBox1.Text.ToString}).Concat(lines.Skip(linecount3)).ToArray()
        System.IO.File.WriteAllLines(filePath2, lines2)
        MsgBox("Reset was successful! Please sign in") 'Message box for a succesful login
    End Sub
End Class