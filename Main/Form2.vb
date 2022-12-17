Imports System.Diagnostics.Eventing
Imports System.IO
Imports System.Text

Public Class Form2
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim username As New StringBuilder
        Dim password As New StringBuilder
        username.AppendLine(TextBox1.Text)
        password.AppendLine(TextBox2.Text)
        Dim filePath As String = "D:\Users\Nisar\Documents\GitHub\Quiz_Game\Main\Text documents\Login details.txt"

        ' Replace "target line" with the line you want to find
        Dim targetLine As String = username.ToString
        MsgBox(targetLine)

        ' Open the file for reading
        Using reader As New StreamReader(filePath)
            Dim line As String

            ' Read the file line by line
            While Not reader.EndOfStream
                line = reader.ReadLine()
                MsgBox(line)

                ' Check if the current line matches the target line
                If line = TextBox1.Text.ToString() Then
                    ' Print the target line to the console
                    MsgBox(line)
                    Return
                End If
            End While

            ' If the loop completes, the target line was not found
            MsgBox("Target line not found in the file.")
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





