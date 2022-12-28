Imports System.IO
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

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim filePath2 As String = "D:\Users\Nisar\Documents\GitHub\Quiz_Game\Main\Text documents\Login details.txt"
        Dim password As New StringBuilder 'Declare the password variable
        Dim linecount As Integer = 0
        Dim linecount2 As Integer
        password.AppendLine(TextBox1.Text)
        Using reader As New StreamReader(filePath2)
            Dim line As String
            While Not reader.EndOfStream
                linecount += 1 'Add one to the index to determine which line of the database the username is located in 
                line = reader.ReadLine()
                If line = Label3.Text.ToString Then
                    MsgBox("checkpio")
                    linecount2 = linecount + 1 'Determines which line of the code the username will be in, which will be the line after
                End If
            End While
        End Using

        'Dim fileContents As String = System.IO.File.ReadAllText(filePath2)
        'Dim lines As String() = fileContents.Split(New String() {Environment.NewLine}, StringSplitOptions.None)
        'lines(linecount2) = password.ToString
        'fileContents = String.Join(Environment.NewLine, lines)
        'System.IO.File.WriteAllText(filePath2, fileContents)
        'MsgBox("Success")
        'Hide()
        'Form1.Show()
        Dim linecount3 As Integer = linecount2 - 1
        Dim lines As String() = System.IO.File.ReadAllLines(filePath2)
        ' Remove the line at index 4 (lines are 0-indexed)
        lines = lines.Where(Function(line, index) index <> linecount3).ToArray()
        System.IO.File.WriteAllLines(filePath2, lines)
        MsgBox(linecount3)
        Dim lines2 As String() = System.IO.File.ReadAllLines(filePath2)
        lines2 = lines.Take(linecount3).Concat({TextBox1.Text.ToString}).Concat(lines.Skip(linecount3)).ToArray()
        System.IO.File.WriteAllLines(filePath2, lines2)
        MsgBox(TextBox1.Text.ToString)
    End Sub
End Class