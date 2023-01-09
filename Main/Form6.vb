Imports System.Formats.Asn1.AsnWriter
Imports System.IO

Public Class Form6
    Dim category_directory As String = ("D:\Users\Nisar\Documents\GitHub\Quiz_Game\Main\Text documents\category.txt") ' location of temporary text file with category name
    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim fileStream As New System.IO.FileStream(category_directory, System.IO.FileMode.Truncate) 'Wipes all the contents of the temporary text file so it can be used again
        fileStream.Close() 'Closes the file for later use
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button_General_Knowledge.Click
        Using file As New StreamWriter(category_directory)
            file.WriteLine(Button_General_Knowledge.Text.ToString) 'Category name is stored in file for other interfaces to read and assign it as a variable
        End Using
        Hide()
        Dim Quiz_interface As New Form7() 'New instance of the form declared
        Quiz_interface.Show() 'New instance of the form is opened
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Hide()
        Form1.Show() 'Opens authentication menu
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Using file As New StreamWriter(category_directory)
            file.WriteLine(Button3.Text.ToString)
        End Using
        Hide()
        Dim form7 As New Form7()
        form7.Show()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Using file As New StreamWriter(category_directory)
            file.WriteLine(Button5.Text.ToString)
        End Using
        Hide()
        Dim form7 As New Form7()
        form7.Show()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Using file As New StreamWriter(category_directory)
            file.WriteLine(Button6.Text.ToString)
        End Using
        Hide()
        Dim form7 As New Form7()
        form7.Show()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Using file As New StreamWriter(category_directory)
            file.WriteLine(Button7.Text.ToString)
        End Using
        Hide()
        Dim form7 As New Form7()
        form7.Show()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Using file As New StreamWriter(category_directory)
            file.WriteLine(Button8.Text.ToString)
        End Using
        Hide()
        Dim form7 As New Form7()
        form7.Show()
    End Sub
End Class