Imports System.Diagnostics.Eventing
Imports System.IO
Imports System.Text

Public Class Form2
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim username As New StringBuilder 'Declare the username variable
        Dim password As New StringBuilder 'Declare the password variable
        username.AppendLine(TextBox1.Text)
        password.AppendLine(TextBox2.Text) 'Assigns the values to the corresponding textbox in the program
        Dim filePath As String = "D:\Users\Nisar\Documents\GitHub\Quiz_Game\Main\Text documents\Login details.txt" 'Declares location of the database
        Dim targetLine As String = username.ToString
        Using reader As New StreamReader(filePath)
            Dim line As String
            Dim line2 As String
            Dim linecount As Integer = 0 'Defines the index of the database. In this case, the first element will be at index 1
            While Not reader.EndOfStream
                linecount += 1 'Add one to the index to determine which line of the database the username is located in 
                line = reader.ReadLine()
                If line = TextBox1.Text.ToString() Then
                    Dim linecount2 As Integer
                    linecount2 = linecount + 1 'Determines which line of the code the username will be in, which will be the line after
                    For i As Integer = 1 To linecount 'Condition for whether the target password is found
                        line2 = reader.ReadLine()
                        If line2 = TextBox2.Text.ToString() Then
                            MsgBox("Success") 'If password also matches, the program will display a success message
                            File.AppendAllText("D:\Users\Nisar\Documents\GitHub\Quiz_Game\Main\Text documents\game_username.txt", username.ToString())
                            Hide()
                            Form6.Show()
                            Return
                        End If
                    Next
                End If
            End While
            MsgBox("Details are incorrect, please try again") 'Displays a message to notify the user that the credentials are not correct
        End Using
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Hide()
        Form1.Show()
    End Sub
End Class





