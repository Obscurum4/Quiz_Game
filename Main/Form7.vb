Imports System.IO
Imports System.Threading




Public Class Form7

        Dim questions As New List(Of String()) 'list to hold the questions and options
        Dim currentQuestion As Integer = 0 'variable to keep track of the current question
        Dim score As Integer = 0 'variable to keep track of the user's score
    Dim totalQuestions As Integer = 20 'total number of questions in the quiz

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'read in the questions and options from the text file
        Using sr As New StreamReader("D:\Users\Nisar\Documents\GitHub\Quiz_Game\Main\Text documents\Questions_General_knowledge.txt")
            While Not sr.EndOfStream
                Dim question As String() = {sr.ReadLine(), sr.ReadLine(), sr.ReadLine(), sr.ReadLine(), sr.ReadLine(), sr.ReadLine(), sr.ReadLine()}
                questions.Add(question)
            End While
        End Using


        'display the first question
        DisplayQuestion()
    End Sub

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

        If currentQuestion = totalQuestions Or Timer1.Interval = 1000 Then
            Timer1.Stop()
            'display the final score
            MessageBox.Show("Quiz complete! Your score is: " & score & " / " & totalQuestions)

            'reset the game
            currentQuestion = 0
            score = 0
        End If
    End Sub

    Private Sub btnOption_Click(sender As Object, e As EventArgs) Handles Button3.Click, Button4.Click, Button5.Click, Button6.Click
        'get the selected option
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



End Class


