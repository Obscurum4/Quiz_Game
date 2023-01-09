Imports System.IO
Imports System.Threading


Public Class Form7

    Dim questions As New List(Of String()) 'list to hold the questions and options
    Dim currentQuestion As Integer = 0 'variable to keep track of the current question
    Dim score As Integer = 0 'variable to keep track of the user's score
    Dim detailspath As String = "D:\Users\Nisar\Documents\GitHub\Quiz_Game\Main\Text documents\score.txt" 'Declares location of text file storing the final score for the round
    Dim username As String 'declares user name
    Dim questions_directory As String 'variable to hold the location of the question directory

    Private Sub Form7_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        get_questions() 'Questions are loaded from the corresponding directory
        Using sr As New StreamReader(questions_directory)
            While Not sr.EndOfStream
                Dim question As String() = {sr.ReadLine(), sr.ReadLine(), sr.ReadLine(), sr.ReadLine(), sr.ReadLine(), sr.ReadLine(), sr.ReadLine()}
                questions.Add(question) 'Questions are added
            End While
        End Using
        Dim category_path As String = "D:\Users\Nisar\Documents\GitHub\Quiz_Game\Main\Text documents\category.txt" 'Declares location of the text file containing the category name 
        Dim category As String = File.ReadLines(category_path).FirstOrDefault() 'Category name corresponds to 
        Button1.Text = category ' The heading will display the name of the corresponding category

        DisplayQuestion() 'Question No.1 is initiated
    End Sub

    Private Sub store(score, detailspath) 'Declare function that stores the username in a temporary directory for later use
        File.AppendAllText(detailspath, score.ToString()) 'Stores the username in the temporary file directory
    End Sub

    Private Function get_questions()
        Dim category_path As String = "D:\Users\Nisar\Documents\GitHub\Quiz_Game\Main\Text documents\category.txt" 'Declares location of the text file containing the category name 
        Dim category As String = File.ReadLines(category_path).FirstOrDefault() 'Reads first line of the text file and assigns it to a variable
        If category = ("General Knowledge") Then
            questions_directory = "D:\Users\Nisar\Documents\GitHub\Quiz_Game\Main\Text documents\Questions_General_knowledge.txt" 'Questions will be imported from  Questions_General_knowledge.txt 
        ElseIf category = ("History") Then
            questions_directory = "D:\Users\Nisar\Documents\GitHub\Quiz_Game\Main\Text documents\Questions_History.txt" 'Questions will be imported from  Questions_History.txt 
        ElseIf category = ("Geography") Then
            questions_directory = "D:\Users\Nisar\Documents\GitHub\Quiz_Game\Main\Text documents\Questions_Geography.txt" 'Questions will be imported from  Questions_Geography.txt 
        ElseIf category = ("Football") Then
            questions_directory = "D:\Users\Nisar\Documents\GitHub\Quiz_Game\Main\Text documents\Questions_Football.txt" 'Questions  will be imported from Questions_Football.txt 
        ElseIf category = ("Pop Culture") Then
            questions_directory = "D:\Users\Nisar\Documents\GitHub\Quiz_Game\Main\Text documents\Questions_Pop_culture.txt" 'Questions will be imported from  Questions_Pop_culture.txt 
        ElseIf category = ("Computer Science") Then
            questions_directory = "D:\Users\Nisar\Documents\GitHub\Quiz_Game\Main\Text documents\Questions_Computer_science.txt" 'Questions will be imported from  Questions_Computer_science.txt 
        End If
        Return questions_directory 'Returns location of correct pathfile for the quiz category
    End Function

    Private Sub SaveScore(username, score)
        Dim scores As New List(Of Tuple(Of String, Integer))
        Using file As New StreamReader("D:\Users\Nisar\Documents\GitHub\Quiz_Game\Main\Text documents\leaderboard_General_knowledge.txt") 'leaderboard location declared
            Dim line As String
            While (InlineAssignHelper(line, file.ReadLine())) IsNot Nothing 'Scores in the leaderboard are read by the program
                Dim parts As String() = line.Split(":"c)
                scores.Add(New Tuple(Of String, Integer)(parts(0), Integer.Parse(parts(1)))) 'Scores are added in a list
            End While
        End Using

        scores.Add(New Tuple(Of String, Integer)(username, score)) 'The new scores are added to the list

        ' sort the scores in decreasing order
        Dim sortedScores = scores.OrderByDescending(Function(x) x.Item2).ToList() 'Scores are sorted from highest to lowest

        Using file As New StreamWriter("D:\Users\Nisar\Documents\GitHub\Quiz_Game\Main\Text documents\leaderboard_General_knowledge.txt") 'leaderboard location declared
            For Each score In sortedScores
                file.WriteLine("{0}: {1}", score.Item1, score.Item2) ' Scores are stored back in the text files.
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
        Return username 'username value is returned
    End Function

    Private Sub DisplayQuestion()

        Timer1.Interval = 2900  'timer embedded in the code is reset
        Label7.Text = 19    'timer visible to user is reset

        'Corresponding lines of text are assigned to respective label variables
        Question_label.Text = questions(currentQuestion)(0)
        Button3.Text = questions(currentQuestion)(1)
        Button4.Text = questions(currentQuestion)(2)
        Button5.Text = questions(currentQuestion)(3)
        Button6.Text = questions(currentQuestion)(4)

        Timer1.Start() 'Timer is started
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        Timer1.Interval -= 100 'Time in Timer1 to user decreases by one second
        Label7.Text = Label7.Text - 1 'Time displayed to user decreases by one second


    End Sub

    Private Sub btnOption_Click(sender As Object, e As EventArgs) Handles Button3.Click, Button4.Click, Button5.Click, Button6.Click

        If currentQuestion = 19 Or Timer1.Interval = 1000 Then 'IF statement that is executed only when either the user has answered all the questions or the timer runs out
            Timer1.Stop() 'Timer is stopped
            MessageBox.Show("Quiz complete!") 'Message box notifying teh user that they completed the round
            store(score, detailspath) 'score is stored
            GetUsername()
            SaveScore(username, score) 'username is saved


            currentQuestion = 0
            score = 0 'Game is reset

            Hide()
            Form8.Show() 'Scoreboard interface is shown

        End If

        Dim button As Button = CType(sender, Button)
        Dim name As String = button.Text


        'check if the selected option is correct
        If name = questions(currentQuestion)(5) Then
            score += 1 ' If score is correct, user receives a point
        End If

        currentQuestion += 1 'The question has been answered, so variable increments to mark this event

        DisplayQuestion() 'Next question in displayed

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim Redirect_Confimation As DialogResult = MessageBox.Show("Are you sure you exit the quiz?", "Confirm", MessageBoxButtons.YesNo) 'Message box text displayed
        If Redirect_Confimation = DialogResult.Yes Then
            Dim form6 As New Form6() 'New instance of a form declared
            form6.Show() 'New instance of form is displayed
            Me.Hide()
        End If
    End Sub
End Class


