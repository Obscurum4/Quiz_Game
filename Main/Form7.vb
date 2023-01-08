Imports System.IO
Imports System.Threading


Public Class Form7

    Dim questions As New List(Of String()) 'list to hold the questions and options
    Dim currentQuestion As Integer = 0 'variable to keep track of the current question
    Dim score As Integer = 0 'variable to keep track of the user's score
    Dim detailspath As String = "D:\Users\Nisar\Documents\GitHub\Quiz_Game\Main\Text documents\score.txt"
    Dim username As String
    Dim questions_directory As String

    Private Sub Form7_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'read in the questions and options from the text file
        get_questions()
        Using sr As New StreamReader(questions_directory)
            While Not sr.EndOfStream
                Dim question As String() = {sr.ReadLine(), sr.ReadLine(), sr.ReadLine(), sr.ReadLine(), sr.ReadLine(), sr.ReadLine(), sr.ReadLine()}
                questions.Add(question)
            End While
        End Using
        Dim category_path As String = "D:\Users\Nisar\Documents\GitHub\Quiz_Game\Main\Text documents\category.txt" 'Declares location of the text file containing the username 
        Dim category As String = File.ReadLines(category_path).FirstOrDefault()
        ' display the category in the button
        Button1.Text = category

        'display the first question
        DisplayQuestion()
    End Sub

    Private Sub store(score, detailspath) 'Declare function that stores the username in a temporary directory for later use
        File.AppendAllText(detailspath, score.ToString()) 'Stores the username in the temporary file directory
    End Sub

    Private Function get_questions()
        Dim category_path As String = "D:\Users\Nisar\Documents\GitHub\Quiz_Game\Main\Text documents\category.txt" 'Declares location of the text file containing the username 
        Dim category As String = File.ReadLines(category_path).FirstOrDefault()
        If category = ("General Knowledge") Then
            questions_directory = "D:\Users\Nisar\Documents\GitHub\Quiz_Game\Main\Text documents\Questions_General_knowledge.txt"
        ElseIf category = ("History") Then
            questions_directory = "D:\Users\Nisar\Documents\GitHub\Quiz_Game\Main\Text documents\Questions_History.txt"
        ElseIf category = ("Geography") Then
            questions_directory = "D:\Users\Nisar\Documents\GitHub\Quiz_Game\Main\Text documents\Questions_Geography.txt"
        ElseIf category = ("Football") Then
            questions_directory = "D:\Users\Nisar\Documents\GitHub\Quiz_Game\Main\Text documents\Questions_Football.txt"
        ElseIf category = ("Pop Culture") Then
            questions_directory = "D:\Users\Nisar\Documents\GitHub\Quiz_Game\Main\Text documents\Questions_Pop_culture.txt"
        ElseIf category = ("Computer Science") Then
            questions_directory = "D:\Users\Nisar\Documents\GitHub\Quiz_Game\Main\Text documents\Questions_Computer_science.txt"
        End If

        Return questions_directory
    End Function

    Private Sub SaveScore(username, score)
        ' read the existing scores from the leaderboard file
        Dim scores As New List(Of Tuple(Of String, Integer))
        Using file As New StreamReader("D:\Users\Nisar\Documents\GitHub\Quiz_Game\Main\Text documents\leaderboard_General_knowledge.txt")
            Dim line As String
            While (InlineAssignHelper(line, file.ReadLine())) IsNot Nothing
                Dim parts As String() = line.Split(":"c)
                scores.Add(New Tuple(Of String, Integer)(parts(0), Integer.Parse(parts(1))))
            End While
        End Using

        ' add the new score to the list of scores
        scores.Add(New Tuple(Of String, Integer)(username, score))

        ' sort the scores in decreasing order
        Dim sortedScores = scores.OrderByDescending(Function(x) x.Item2).ToList()

        ' open the file in write mode
        Using file As New StreamWriter("D:\Users\Nisar\Documents\GitHub\Quiz_Game\Main\Text documents\leaderboard_General_knowledge.txt")
            ' write each score to the file on a new line
            For Each score In sortedScores
                file.WriteLine("{0}: {1}", score.Item1, score.Item2)
            Next
        End Using
    End Sub

    Private Shared Function InlineAssignHelper(Of T)(ByRef target As T, value As T) As T
        target = value
        Return value
    End Function

    Private Function GetUsername()
        Dim filePath As String = ("D:\Users\Nisar\Documents\GitHub\Quiz_Game\Main\Text documents\game_username.txt") 'Declares location of the text file containing the username 
        Using reader As New StreamReader(filePath)
            username = reader.ReadLine() 'Assigns the first line of the text file as a variable called username
        End Using
        Return username
    End Function

    Private Sub DisplayQuestion()
        'reset the timer
        Timer1.Interval = 2900
        Label7.Text = 19

        'display the current question and options
        Question_label.Text = questions(currentQuestion)(0)
        Button3.Text = questions(currentQuestion)(1)
        Button4.Text = questions(currentQuestion)(2)
        Button5.Text = questions(currentQuestion)(3)
        Button6.Text = questions(currentQuestion)(4)


        'start the timer
        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick


        Timer1.Interval -= 100


        'display the current value of the timer in the label
        Label7.Text = Label7.Text - 1


    End Sub

    Private Sub btnOption_Click(sender As Object, e As EventArgs) Handles Button3.Click, Button4.Click, Button5.Click, Button6.Click
        'get the selected option

        If currentQuestion = 19 Or Timer1.Interval = 1000 Then
            Timer1.Stop()
            'display the final score
            MessageBox.Show("Quiz complete!")
            store(score, detailspath)
            GetUsername()
            SaveScore(username, score)

            'reset the game
            currentQuestion = 0
            score = 0
            Hide()
            Form8.Show()

        End If

        Dim button As Button = CType(sender, Button)
        Dim name As String = button.Text


        'check if the selected option is correct
        If name = questions(currentQuestion)(5) Then
            'increment the score if the answer is correct
            score += 1
        End If

        'move on to the next question
        currentQuestion += 1

        'check if all questions have been answered


        'display the next question
        DisplayQuestion()

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim Redirect_Confimation As DialogResult = MessageBox.Show("Are you sure you exit the quiz?", "Confirm", MessageBoxButtons.YesNo)
        ' redirect to Form6 if the user chooses "Yes"
        If Redirect_Confimation = DialogResult.Yes Then
            Dim form6 As New Form6()
            form6.Show()
            Me.Hide()
        End If
    End Sub
End Class


