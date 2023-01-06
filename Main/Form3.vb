Imports System.Drawing.Text
Imports System.IO
Imports System.Reflection.Metadata.Ecma335
Imports System.Text
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel

Public Class Form3
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Hide()
        Form1.Show() 'Hides current interface and open the main menu
    End Sub

    Private Function store(username, password, detailspath)
        File.AppendAllText(detailspath, username.ToString()) 'Stores the username on the database
        File.AppendAllText(detailspath, password.ToString()) 'Stores the password on the databse, on the line after the username
    End Function

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim username As New StringBuilder 'Username variable declared
        Dim password As New StringBuilder 'Password variable decalred
        Dim detailspath As String = "D:\Users\Nisar\Documents\GitHub\Quiz_Game\Main\Text documents\Login details.txt" 'Declares where the directory with all the login details is
        Dim info = File.ReadAllText(detailspath)
        username.AppendLine(TextBox1.Text) 'Username varibale is assigend to the input of the username textbox
        password.AppendLine(TextBox2.Text) 'Password varibale is assigend to the input of the password textbox
        If info.Contains(username.ToString()) Then 'Validation to check if the username exixts in the database
            MsgBox("Username already exists, please try again") 'Error message
        Else
            store(username, password, detailspath) 'Calls function
            MsgBox("Sign Up Successful! Please sign in") 'Message to confirm successful registration
        End If


    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class