'Chapter 19 - Program 1
Public Class Form1
    '------------------------------------------------------------
    '-                File Name : Form1.vb                      - 
    '-                Part of Project: myClockTester            -
    '------------------------------------------------------------
    '-                Written By: Adam Cossin                   -
    '-                Written On: April 8th, 2023               -
    '------------------------------------------------------------
    '- File Purpose:                                            -
    '- This file contains the main application form to test out -
    '- the different properties of our control.                 -
    '------------------------------------------------------------
    '- Program Purpose:                                         -
    '- This program displays our clock control, and features two-
    '- buttons which change some of the control's properties.   -
    '------------------------------------------------------------
    '- Global Variable Dictionary (alphabetically):             -
    '- (None)                                                   -
    '------------------------------------------------------------

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        '------------------------------------------------------------
        '-                Subprogram Name: Button1_Click            -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: April 8th, 2023               -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine is called whenever the user clicks the   -
        '- quit button.  The program will change the forecolor of   -
        '- our clock control to red (meaning the text is changed).  -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- sender – Identifies which particular control raised the  –
        '-          click event                                     - 
        '- e – Holds the EventArgs object sent to the routine       -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------

        'Click button 1 to change the clock's foreground color
        MyClock1.ForeColor = Color.Red
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        '------------------------------------------------------------
        '-                Subprogram Name: Button2_Click            -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: April 8th, 2023               -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine is called whenever the user clicks the   -
        '- quit button. The program will change the backcolor of our-
        '- clock control to white (meaning the background is changed).-
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- sender – Identifies which particular control raised the  –
        '-          click event                                     - 
        '- e – Holds the EventArgs object sent to the routine       -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------

        'Click button 2 to change to the form's background color and
        'see that the clock's background color automatically changes
        'to match
        Me.BackColor = Color.White
    End Sub
End Class