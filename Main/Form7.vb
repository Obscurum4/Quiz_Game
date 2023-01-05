﻿Imports System.IO
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
                Dim line As String = sr.ReadLine()
                Dim question As String() = {line, sr.ReadLine(), sr.ReadLine(), sr.ReadLine(), sr.ReadLine()}
                questions.Add(question)
            End While
        End Using

        'randomize the order of the questions
        questions = questions.OrderBy(Function(x) Guid.NewGuid()).ToList()

            'display the first question
            DisplayQuestion()
        End Sub

        Private Sub DisplayQuestion()
            'reset the timer
            Timer1.Interval = 20000

        'display the current question and options
        Label2.Text = questions(currentQuestion)(0)
        Label3.Text = questions(currentQuestion)(1)
        Label4.Text = questions(currentQuestion)(2)
        Label5.Text = questions(currentQuestion)(3)
        Label6.Text = questions(currentQuestion)(4)

        'start the timer
        Timer1.Start()
        End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        'decrement the timer
        Timer1.Interval -= 1000

        'if the timer has reached 0, move on to the next question
        If Timer1.Interval = 0 Then
            Timer1.Stop()
            currentQuestion += 1
            DisplayQuestion()
        End If
    End Sub


    Private Sub btnOption_Click(sender As Object, e As EventArgs) Handles Button4.Click, Button5.Click, Button6.Click, Button7.Click
        'get the selected option
        Dim selectedOption As Integer = CInt(DirectCast(sender, Button).Tag)

        'check if the selected option is correct
        If selectedOption = CInt(questions(currentQuestion)(5)) Then
            'increment the score if the answer is correct
            score += 1
        End If

        'move on to the next question
        currentQuestion += 1

        'check if all questions have been answered
        If currentQuestion = totalQuestions Then
            'display the final score
            MessageBox.Show("Quiz complete! Your score is: " & score & " / " & totalQuestions)

            'reset the game
            currentQuestion = 0
            score = 0
            DisplayQuestion()
        Else
            'display the next question
            DisplayQuestion()
        End If
    End Sub


End Class

