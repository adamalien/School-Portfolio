Public Class frmMain
    '------------------------------------------------------------
    '-                File Name : frmMain.vb                     - 
    '-                Part of Project: cis311hw6                 -
    '------------------------------------------------------------
    '-                Written By: Adam Cossin                     -
    '-                Written On: Feb 21, 2023                  -
    '------------------------------------------------------------
    '- File Purpose:                                            -
    '- This file contains the main application form where the   -
    '- user will be able to launch multiple child windows.
    '------------------------------------------------------------
    '- Program Purpose:                                         -
    '- This program showcases MDIParent and MDIChildren forms and-
    '- how they work together. The children here will be forms -
    '- which can calculate EVM information. The parent will be -
    '- able to display these children and organize them.        -
    '------------------------------------------------------------
    '- Global Variable Dictionary (alphabetically):             -
    '- intNumChildren – Keeps track of the number of child windows.-
    '------------------------------------------------------------

    Public Property intNumChildren As Integer 'number of child windows
    Private Sub mnuHelpAbout_Click(sender As Object, e As EventArgs) Handles mnuHelpAbout.Click
        '------------------------------------------------------------
        '-                Subprogram Name: mnuHelpAbout_Click          -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                    -
        '-                Written On: Feb 21, 2023                   -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine is called whenever the user clicks the   -
        '- help button. The 'About' form will be shown.             –
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- sender – Identifies which particular control raised the  –
        '-          click event                                     - 
        '- e – Holds the EventArgs object sent to the routine       -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------

        frmAbout.ShowDialog() 'shows frmAbout
    End Sub

    Private Sub mnuWindowHorizontal_Click(sender As Object, e As EventArgs) Handles mnuWindowHorizontal.Click
        '------------------------------------------------------------
        '-                Subprogram Name: mnuWindowHorizontal_Click          -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                    -
        '-                Written On: Feb 21, 2023                   -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine is called whenever the user clicks the   -
        '- horizontal button. The child windows will be tiled horizontally.–
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- sender – Identifies which particular control raised the  –
        '-          click event                                     - 
        '- e – Holds the EventArgs object sent to the routine       -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub mnuWindowVertical_Click(sender As Object, e As EventArgs) Handles mnuWindowVertical.Click
        '------------------------------------------------------------
        '-                Subprogram Name: mnuWindowVertical_Click          -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                    -
        '-                Written On: Feb 21, 2023                   -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine is called whenever the user clicks the   -
        '- vertical button. The child windows will be tiled vertically.–
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- sender – Identifies which particular control raised the  –
        '-          click event                                     - 
        '- e – Holds the EventArgs object sent to the routine       -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub mnuWindowCascade_Click(sender As Object, e As EventArgs) Handles mnuWindowCascade.Click
        '------------------------------------------------------------
        '-                Subprogram Name: mnuWindowCascade_Click          -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                    -
        '-                Written On: Feb 21, 2023                   -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine is called whenever the user clicks the   -
        '- cascade button. The child windows will be cascaded.–
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- sender – Identifies which particular control raised the  –
        '-          click event                                     - 
        '- e – Holds the EventArgs object sent to the routine       -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub mnuFileNew_Click(sender As Object, e As EventArgs) Handles mnuFileNew.Click
        '------------------------------------------------------------
        '-                Subprogram Name: mnuFileNew_Click          -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                    -
        '-                Written On: Feb 21, 2023                   -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine is called whenever the user clicks the   -
        '- new button. A new child will be added to the MDI container.–
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- sender – Identifies which particular control raised the  –
        '-          click event                                     - 
        '- e – Holds the EventArgs object sent to the routine       -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- frmEVMChild - new child form                             -
        '------------------------------------------------------------
        intNumChildren = intNumChildren + 1 'add 1 to intNumChildren
        Dim frmEVMChild As frmEVMCalculator = New frmEVMCalculator With { 'create a new instance of frmEVMCalculator
            .MdiParent = Me, 'set parent to frmMain
            .Text = "EVM - " & intNumChildren 'set title to 'EVM' and the current number of children
        }
        frmEVMChild.Show() 'show child
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles Me.Load
        '------------------------------------------------------------
        '-                Subprogram Name: frmMain_Load         -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                    -
        '-                Written On: Feb 21, 2023                   -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine is called whenever the form loads. It initializes-
        '- 'intNumChildren' to 0                                    -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- sender – Identifies which particular control raised the  –
        '-          click event                                     - 
        '- e – Holds the EventArgs object sent to the routine       -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        intNumChildren = 0 'initialize to 0
    End Sub

    Private Sub frmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        '------------------------------------------------------------
        '-                Subprogram Name: frmMain_FormClosing          -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                    -
        '-                Written On: Feb 21, 2023                   -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine is called whenever the form is closing. Will-
        '- go through each child to confirm a close on those, and then close-
        '- itself based on if there are any children left.           -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- sender – Identifies which particular control raised the  –
        '-          click event                                     - 
        '- e – Holds the EventArgs object sent to the routine       -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        For Each frmChild In MdiChildren 'go through each child form
            frmChild.Close() 'call the child's closing event
        Next
        If (intNumChildren > 0) Then 'if 'intNumChildren' is greater than zero, means at least one child is remaining, so the main form will not close
            e.Cancel = True 'cancels the close
        End If
    End Sub

    Private Sub mnuFileExit_Click(sender As Object, e As EventArgs) Handles mnuFileExit.Click
        '------------------------------------------------------------
        '-                Subprogram Name: mnuFileExit_Click         -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                    -
        '-                Written On: Feb 21, 2023                   -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine is called whenever the user clicks the exit button.-
        '- The form closing event will be called.                   -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- sender – Identifies which particular control raised the  –
        '-          click event                                     - 
        '- e – Holds the EventArgs object sent to the routine       -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        Close() 'close form
    End Sub
End Class
