Imports System.IO
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel

Public Class Form8
    Dim score As String
    Dim leaderboard_directory As String
    Dim username As String
    Private Sub Form8_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim filePath As String = "D:\Users\Nisar\Documents\GitHub\Quiz_Game\Main\Text documents\score.txt" 'Declares location of the text file containing the score
        Using reader As New StreamReader(filePath)
            score = reader.ReadLine() 'Assigns the first line of the text file as a variable called username
            Points.Text = score 'Displays the username of the user
        End Using
        If System.IO.File.Exists(filePath) Then
            Dim fileStream As New System.IO.FileStream(filePath, System.IO.FileMode.Truncate) 'Wipes all the contents of the temporary text file so it can be used again
            fileStream.Close() 'Closes the file for later use
        End If
        HighScoreCheck() 'Function called to see what message should be dios
    End Sub

    Private Sub HighScoreCheck()
        get_leaderboard()
        Dim username As String = GetUsername() ' get the username from the text box
        Dim highScore As Integer = 0 ' variable to hold the high score

        ' read in the scores from the text file
        Dim lines As String() = File.ReadAllLines(leaderboard_directory)
        For Each line As String In lines
            Dim parts As String() = line.Split(":")
            If parts(0) = username Then
                ' if the username matches, check if the score is higher
                Dim userScore As Integer = Integer.Parse(parts(1))
                If userScore > highScore Then
                    highScore = userScore
                End If
            End If
        Next

        ' check if the new score is a high score
        If score = highScore Then
            Button2.Text = "NEW RECORD"
        Else
            Button2.Text = ("HIGHEST SCORE: " & highScore)
        End If
    End Sub

    Private Function get_leaderboard()
        Dim category_path As String = "D:\Users\Nisar\Documents\GitHub\Quiz_Game\Main\Text documents\category.txt" 'Declares location of the text file containing the username 
        Dim category As String = File.ReadLines(category_path).FirstOrDefault()
        If category = ("General Knowledge") Then
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

        Return leaderboard_directory
    End Function

    Private Function GetUsername()
        Dim filePath As String = ("D:\Users\Nisar\Documents\GitHub\Quiz_Game\Main\Text documents\game_username.txt") 'Declares location of the text file containing the username 
        Using reader As New StreamReader(filePath)
            username = reader.ReadLine() 'Assigns the first line of the text file as a variable called username
        End Using
        Return username 'username is returned
    End Function

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Hide()
        Dim form9 As New Form9()
        form9.Show() 'Leaderboard interface is shown
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Hide()
        Form10.Show() 'Question review interface is opened
    End Sub
End Class