'Chapter 19 - myClockControl
Public Class myClock
    '------------------------------------------------------------
    '-                File Name : myClock.vb                    - 
    '-                Part of Project: myClockControl           -
    '------------------------------------------------------------
    '-                Written By: Adam Cossin                   -
    '-                Written On: April 8th, 2023               -
    '------------------------------------------------------------
    '- File Purpose:                                            -
    '- This file contains a clock control that will display the -
    '- current system time on the form.                         -
    '------------------------------------------------------------
    '- Global Variable Dictionary (alphabetically):             -
    '- ArialFont - new font for the control.                    -
    '- CurrentForeColor - sets the forecolor of the control.    -
    '- myBrush - used to paint the control.                     -
    '------------------------------------------------------------

    'Create the Font and Brush that we will use to print the time
    'and also set the default Foreground color to Black
    Dim ArialFont As New Font("Arial", 12, FontStyle.Regular)
    Dim myBrush As New SolidBrush(Color.Black)
    Dim CurrentForeColor As Color = Color.Black
    Overrides Property ForeColor() As Color
        'We need to set ForeColor up as a property to allow the user
        'to get and set the foreground color of the control. Remember
        'that we aren't interested in allowing the user to set the
        'background color -- it's supposed to match the container that
        'it's in, so we will just inherit from whatever container is
        'hosting our control. (We can override it if we want using
        'the shadows keyword.)
        Get
            Return (CurrentForeColor)
        End Get
        Set(ByVal Value As Color)
            CurrentForeColor = Value
            Me.Invalidate()
        End Set
    End Property
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        '------------------------------------------------------------
        '-                Subprogram Name: Timer1_Tick              -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: April 8th, 2023               -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine is called each second (the interval that -
        '- the timer is set to tick). The clock is refreshed.       -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- sender – Identifies which particular control raised the  –
        '-          click event                                     - 
        '- e – Holds the EventArgs object sent to the routine       -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------

        'Every time the timer ticks, refresh the control's context,
        'which in effect will force the time to be updated since
        'Refresh forces Paint to be called
        Me.Refresh()
    End Sub
    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        '------------------------------------------------------------
        '-                Subprogram Name: OnPaint                  -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: April 8th, 2023               -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine is called on each paint of the control.  -
        '- The display will be updated.                             -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- e – Holds the EventArgs object sent to the routine       -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- myGfx - graphics context for the control.                -
        '------------------------------------------------------------

        'Everytime we are told to Paint, draw the time on the control's
        'surface...
        'e.Graphics is the graphics context for the control
        Dim myGfx As Graphics = e.Graphics
        'Set the brush to whatever the current foreground color is
        myBrush.Color = CurrentForeColor
        'Print the time out
        myGfx.DrawString(DateTime.Now.ToLongTimeString, ArialFont, myBrush, 10, 10)
    End Sub
End Class