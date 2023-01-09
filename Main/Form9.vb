Imports System.IO

Public Class Form9
    Dim leaderboard_directory As String 'leaderbaord_directory variable is declared
    Private Sub Form9_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        get_leaderboard() 'Leaderboard directory assigned

        Using reader As New StreamReader(leaderboard_directory) 'From the leaderbord file, teh first 5 lines are assigned to different variables
            Dim line1 As String = reader.ReadLine()
            Dim line2 As String = reader.ReadLine()
            Dim line3 As String = reader.ReadLine()
            Dim line4 As String = reader.ReadLine()
            Dim line5 As String = reader.ReadLine()

            Dim parts1 As String() = line1.Split(":"c) 'Each line is split between the username and the score
            Dim parts2 As String() = line2.Split(":"c)
            Dim parts3 As String() = line3.Split(":"c)
            Dim parts4 As String() = line4.Split(":"c)
            Dim parts5 As String() = line5.Split(":"c)

            'Each label in the program is assigned to either the username or the corresponding score
            Label1.Text = parts1(0)
            Label2.Text = Integer.Parse(parts1(1))
            Label3.Text = parts2(0)
            Label4.Text = Integer.Parse(parts2(1))
            Label5.Text = parts3(0)
            Label6.Text = Integer.Parse(parts3(1))
            Label7.Text = parts4(0)
            Label8.Text = Integer.Parse(parts4(1))
            Label9.Text = parts5(0)
            Label10.Text = Integer.Parse(parts5(1))


        End Using
    End Sub

    Private Function get_leaderboard()
        Dim category_path As String = "D:\Users\Nisar\Documents\GitHub\Quiz_Game\Main\Text documents\category.txt" 'Declares location of the text file containing the username 
        Dim category As String = File.ReadLines(category_path).FirstOrDefault() 'First line of the text file is read and assigned to the category variable
        If category = ("General Knowledge") Then 'Assigns the directory to the corresponding category using IF statements to determine the correct directory
            leaderboard_directory = "D:\Users\Nisar\Documents\GitHub\Quiz_Game\Main\Text documents\leaderboard_General_knowledge.txt"
        ElseIf category = ("History") Then
            leaderboard_directory = "D:\Users\Nisar\Documents\GitHub\Quiz_Game\Main\Text documents\leaderboard_History.txt"
        ElseIf category = ("Geography") Then
            leaderboard_directory = "D:\Users\Nisar\Documents\GitHub\Quiz_Game\Main\Text documents\leaderboard_Geography.txt"
        ElseIf category = ("Football") Then
            leaderboard_directory = "D:\Users\Nisar\Documents\GitHub\Quiz_Game\Main\Text documents\leaderboard_Football.txt"
        ElseIf category = ("Pop Culture") Then
            leaderboard_directory = "D:\Users\Nisar\Documents\GitHub\Quiz_Game\Main\Text documents\leaderboard_Pop_culture.txt"
        ElseIf category = ("Computer Science") Then
            leaderboard_directory = "D:\Users\Nisar\Documents\GitHub\Quiz_Game\Main\Text documents\leaderboard_Computer_science.txt"
        End If

        Return leaderboard_directory 'Location of corresponding leaderboard is returned
    End Function


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Hide()
        Form6.Show() 'Quiz selection menu is loaded
    End Sub
End Class