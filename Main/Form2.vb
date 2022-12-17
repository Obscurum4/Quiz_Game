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
        Dim targetLine As String = username.ToString
        Using reader As New StreamReader(filePath)
            Dim line As String
            Dim line2 As String
            Dim linecount As Integer = 0
            While Not reader.EndOfStream
                linecount += 1
                line = reader.ReadLine()
                If line = TextBox1.Text.ToString() Then
                    MsgBox(linecount)
                    For i As Integer = 1 To linecount - 1
                        reader.ReadLine()
                    Next
                    line2 = reader.ReadLine()
                    MsgBox(line2)
                    If line2 = TextBox2.Text.ToString() Then
                        MsgBox("success")
                        Return
                    End If
                End If
            End While
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





