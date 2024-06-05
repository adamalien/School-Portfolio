Public Class frmTicTacToe
    '------------------------------------------------------------
    '-                File Name : frmTicTacToe.vb               - 
    '-                Part of Project: cis311hw7                -
    '------------------------------------------------------------
    '-                Written By: Adam Cossin                   -
    '-                Written On: March 10th, 2023              -
    '------------------------------------------------------------
    '- File Purpose:                                            -
    '- This file contains the main application form where the   -
    '- user will be able to play a turn-based version of tic-tac-
    '- toe.
    '------------------------------------------------------------
    '- Program Purpose:                                         -
    '- This program allows a user to play turn-based tic-tac-toe.-
    '------------------------------------------------------------
    '- Global Variable Dictionary (alphabetically):             -
    '- blnO - boolean variable to see if it is O's turn to go.  -
    '- blnX - boolean variable to see if it is X's turn to go.  -
    '- intSquaresVisited - number of squares that have been claimed.-
    '------------------------------------------------------------

    Dim intSquaresVisited = 0
    Dim blnX = True
    Dim blnO = False

    Private Sub txtX_MouseDown(sender As Object, e As MouseEventArgs) Handles txtX.MouseDown
        '------------------------------------------------------------
        '-                Subprogram Name: txtX_MouseDown           -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: March 10th, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is called whenever the user presses the  –
        '- mouse on the 'txtX' textbox to start being able to drag. -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- sender – Identifies which particular control raised the  –
        '-          click event                                     - 
        '- e – Holds the MouseEventArgs object sent to the routine  -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- dragDropX - the txtX.DragDrop event                      -
        '------------------------------------------------------------

        If (blnX) Then 'if it is not X's turn, will not be able to drag and drop, if it is X's turn, it can be drag/dropped
            Dim dragDropX = txtX.DoDragDrop(txtX.Text, DragDropEffects.Copy) 'start drag drop event and store it in 'dragDropX'
            If (successfulDrop(dragDropX)) Then 'call 'successfulDrop' on the dragDropX event to see if the drag/drop was successful
                blnX = False 'if it was successful, switch so that it is O's turn
                blnO = True
            End If
        End If
    End Sub

    Private Sub txtO_MouseDown(sender As Object, e As MouseEventArgs) Handles txtO.MouseDown
        '------------------------------------------------------------
        '-                Subprogram Name: txtO_MouseDown           -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: March 10th, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is called whenever the user presses the  –
        '- mouse on the 'txtO' textbox to start being able to drag. -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- sender – Identifies which particular control raised the  –
        '-          click event                                     - 
        '- e – Holds the MouseEventArgs object sent to the routine  -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- dragDropO - the txtO.DragDrop event                      -
        '------------------------------------------------------------
        If (blnO) Then 'if it is not O's turn, will not be able to drag and drop, if it is O's turn, it can be drag/dropped
            Dim dragDropO = txtO.DoDragDrop(txtO.Text, DragDropEffects.Copy) 'start drag drop event and store it in 'dragDropO'
            If (successfulDrop(dragDropO)) Then 'call 'successfulDrop' on the dragDropO event to see if the drag/drop was successful
                blnO = False 'if it was successful, switch so that it is X's turn
                blnX = True
            End If
        End If
    End Sub

    Private Sub txtRow1Col1_DragDrop(sender As Object, e As DragEventArgs) Handles txtRow1Col1.DragDrop
        '------------------------------------------------------------
        '-                Subprogram Name: txtRow1Col1_DragDrop     -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: March 10th, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is called whenever the user drags and drops-
        '- an item to Row1Col1 in the tic-tac-toe board.            -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- sender – Identifies which particular control raised the  –
        '-          click event                                     - 
        '- e – Holds the DragEventArgs object sent to the routine   -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        txtRow1Col1.Text = e.Data.GetData(DataFormats.Text).ToString 'copies the text from what is being hovered over the square and sets the text of the square to it
        resetColor(txtRow1Col1) 'resets the color of the square back to default
        checkForWin() 'checks if there has been a win
        intSquaresVisited += 1 'squares visited increased by 1
        checkForTie() 'checks for a tie
    End Sub

    Private Sub txtRow1Col1_DragEnter(sender As Object, e As DragEventArgs) Handles txtRow1Col1.DragEnter
        '------------------------------------------------------------
        '-                Subprogram Name: txtRow1Col1_DragEnter    -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: March 10th, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is called whenever the user drags an item-
        '- over Row1Col1 in the tic-tac-toe board.                  -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- sender – Identifies which particular control raised the  –
        '-          click event                                     - 
        '- e – Holds the DragEventArgs object sent to the routine   -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        validDrag(txtRow1Col1) 'checks if the drag/drop is valid and changes the color of the tile based on that
        If (checkColor(txtRow1Col1)) Then 'if it is valid, the tile will be green and checkColor will return true
            e.Effect = DragDropEffects.Copy 'then, the drag/drop can be carried out
        End If
    End Sub

    Private Sub txtRow1Col1_DragLeave(sender As Object, e As EventArgs) Handles txtRow1Col1.DragLeave
        '------------------------------------------------------------
        '-                Subprogram Name: txtRow1Col1_DragLeave    -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: March 10th, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is called whenever the user drags an item-
        '- over Row1Col1 in the tic-tac-toe board and then leaves the-
        '- tile.                                                    -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- sender – Identifies which particular control raised the  –
        '-          click event                                     - 
        '- e – Holds the DragEventArgs object sent to the routine   -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        resetColor(txtRow1Col1) 'resets the color of the tile to default
    End Sub

    Private Sub txtRow1Col2_DragDrop(sender As Object, e As DragEventArgs) Handles txtRow1Col2.DragDrop
        '------------------------------------------------------------
        '-                Subprogram Name: txtRow1Col2_DragDrop     -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: March 10th, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is called whenever the user drags and drops-
        '- an item to Row1Col2 in the tic-tac-toe board.            -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- sender – Identifies which particular control raised the  –
        '-          click event                                     - 
        '- e – Holds the DragEventArgs object sent to the routine   -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        txtRow1Col2.Text = e.Data.GetData(DataFormats.Text).ToString
        resetColor(txtRow1Col2)
        checkForWin()
        intSquaresVisited += 1
        checkForTie()
    End Sub

    Private Sub txtRow1Col2_DragEnter(sender As Object, e As DragEventArgs) Handles txtRow1Col2.DragEnter
        '------------------------------------------------------------
        '-                Subprogram Name: txtRow1Col2_DragEnter    -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: March 10th, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is called whenever the user drags an item-
        '- over Row1Col2 in the tic-tac-toe board.                  -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- sender – Identifies which particular control raised the  –
        '-          click event                                     - 
        '- e – Holds the DragEventArgs object sent to the routine   -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        validDrag(txtRow1Col2)
        If (checkColor(txtRow1Col2)) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub

    Private Sub txtRow1Col2_DragLeave(sender As Object, e As EventArgs) Handles txtRow1Col2.DragLeave
        '------------------------------------------------------------
        '-                Subprogram Name: txtRow1Col2_DragLeave    -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: March 10th, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is called whenever the user drags an item-
        '- over Row1Col2 in the tic-tac-toe board and then leaves the-
        '- tile.                                                    -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- sender – Identifies which particular control raised the  –
        '-          click event                                     - 
        '- e – Holds the DragEventArgs object sent to the routine   -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        resetColor(txtRow1Col2)
    End Sub

    Private Sub txtRow1Col3_DragDrop(sender As Object, e As DragEventArgs) Handles txtRow1Col3.DragDrop
        '------------------------------------------------------------
        '-                Subprogram Name: txtRow1Col3_DragDrop     -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: March 10th, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is called whenever the user drags and drops-
        '- an item to Row1Col3 in the tic-tac-toe board.            -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- sender – Identifies which particular control raised the  –
        '-          click event                                     - 
        '- e – Holds the DragEventArgs object sent to the routine   -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        txtRow1Col3.Text = e.Data.GetData(DataFormats.Text).ToString
        resetColor(txtRow1Col3)
        intSquaresVisited += 1
        checkForTie()
        checkForWin()
    End Sub

    Private Sub txtRow1Col3_DragEnter(sender As Object, e As DragEventArgs) Handles txtRow1Col3.DragEnter
        '------------------------------------------------------------
        '-                Subprogram Name: txtRow1Col3_DragEnter    -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: March 10th, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is called whenever the user drags an item-
        '- over Row1Col3 in the tic-tac-toe board.                  -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- sender – Identifies which particular control raised the  –
        '-          click event                                     - 
        '- e – Holds the DragEventArgs object sent to the routine   -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        validDrag(txtRow1Col3)
        If (checkColor(txtRow1Col3)) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub
    Private Sub txtRow1Col3_DragLeave(sender As Object, e As EventArgs) Handles txtRow1Col3.DragLeave
        '------------------------------------------------------------
        '-                Subprogram Name: txtRow1Col3_DragLeave    -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: March 10th, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is called whenever the user drags an item-
        '- over Row1Col3 in the tic-tac-toe board and then leaves the-
        '- tile.                                                    -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- sender – Identifies which particular control raised the  –
        '-          click event                                     - 
        '- e – Holds the DragEventArgs object sent to the routine   -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        resetColor(txtRow1Col3)
    End Sub

    Private Sub txtRow2Col1_DragDrop(sender As Object, e As DragEventArgs) Handles txtRow2Col1.DragDrop
        '------------------------------------------------------------
        '-                Subprogram Name: txtRow2Col1_DragDrop     -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: March 10th, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is called whenever the user drags and drops-
        '- an item to Row2Col1 in the tic-tac-toe board.            -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- sender – Identifies which particular control raised the  –
        '-          click event                                     - 
        '- e – Holds the DragEventArgs object sent to the routine   -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        txtRow2Col1.Text = e.Data.GetData(DataFormats.Text).ToString
        resetColor(txtRow2Col1)
        intSquaresVisited += 1
        checkForTie()
        checkForWin()
    End Sub

    Private Sub txtRow2Col1_DragEnter(sender As Object, e As DragEventArgs) Handles txtRow2Col1.DragEnter
        '------------------------------------------------------------
        '-                Subprogram Name: txtRow2Col1_DragEnter    -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: March 10th, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is called whenever the user drags an item-
        '- over Row2Col1 in the tic-tac-toe board.                  -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- sender – Identifies which particular control raised the  –
        '-          click event                                     - 
        '- e – Holds the DragEventArgs object sent to the routine   -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        validDrag(txtRow2Col1)
        If (checkColor(txtRow2Col1)) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub
    Private Sub txtRow2Col1_DragLeave(sender As Object, e As EventArgs) Handles txtRow2Col1.DragLeave
        '------------------------------------------------------------
        '-                Subprogram Name: txtRow2Col1_DragLeave    -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: March 10th, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is called whenever the user drags an item-
        '- over Row2Col1 in the tic-tac-toe board and then leaves the-
        '- tile.                                                    -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- sender – Identifies which particular control raised the  –
        '-          click event                                     - 
        '- e – Holds the DragEventArgs object sent to the routine   -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        resetColor(txtRow2Col1)
    End Sub

    Private Sub txtRow2Col2_DragDrop(sender As Object, e As DragEventArgs) Handles txtRow2Col2.DragDrop
        '------------------------------------------------------------
        '-                Subprogram Name: txtRow2Col2_DragDrop     -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: March 10th, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is called whenever the user drags and drops-
        '- an item to Row2Col2 in the tic-tac-toe board.            -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- sender – Identifies which particular control raised the  –
        '-          click event                                     - 
        '- e – Holds the DragEventArgs object sent to the routine   -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        txtRow2Col2.Text = e.Data.GetData(DataFormats.Text).ToString
        resetColor(txtRow2Col2)
        intSquaresVisited += 1
        checkForTie()
        checkForWin()
    End Sub

    Private Sub txtRow2Col2_DragEnter(sender As Object, e As DragEventArgs) Handles txtRow2Col2.DragEnter
        '------------------------------------------------------------
        '-                Subprogram Name: txtRow2Col2_DragEnter    -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: March 10th, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is called whenever the user drags an item-
        '- over Row2Col2 in the tic-tac-toe board.                  -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- sender – Identifies which particular control raised the  –
        '-          click event                                     - 
        '- e – Holds the DragEventArgs object sent to the routine   -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        validDrag(txtRow2Col2)
        If (checkColor(txtRow2Col2)) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub
    Private Sub txtRow2Col2_DragLeave(sender As Object, e As EventArgs) Handles txtRow2Col2.DragLeave
        '------------------------------------------------------------
        '-                Subprogram Name: txtRow2Col2_DragLeave    -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: March 10th, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is called whenever the user drags an item-
        '- over Row2Col2 in the tic-tac-toe board and then leaves the-
        '- tile.                                                    -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- sender – Identifies which particular control raised the  –
        '-          click event                                     - 
        '- e – Holds the DragEventArgs object sent to the routine   -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        resetColor(txtRow2Col2)
    End Sub

    Private Sub txtRow2Col3_DragDrop(sender As Object, e As DragEventArgs) Handles txtRow2Col3.DragDrop
        '------------------------------------------------------------
        '-                Subprogram Name: txtRow2Col3_DragDrop     -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: March 10th, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is called whenever the user drags and drops-
        '- an item to Row2Col3 in the tic-tac-toe board.            -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- sender – Identifies which particular control raised the  –
        '-          click event                                     - 
        '- e – Holds the DragEventArgs object sent to the routine   -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        txtRow2Col3.Text = e.Data.GetData(DataFormats.Text).ToString
        resetColor(txtRow2Col3)
        intSquaresVisited += 1
        checkForTie()
        checkForWin()
    End Sub

    Private Sub txtRow2Col3_DragEnter(sender As Object, e As DragEventArgs) Handles txtRow2Col3.DragEnter
        '------------------------------------------------------------
        '-                Subprogram Name: txtRow2Col3_DragEnter    -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: March 10th, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is called whenever the user drags an item-
        '- over Row2Col3 in the tic-tac-toe board.                  -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- sender – Identifies which particular control raised the  –
        '-          click event                                     - 
        '- e – Holds the DragEventArgs object sent to the routine   -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        validDrag(txtRow2Col3)
        If (checkColor(txtRow2Col3)) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub
    Private Sub txtRow2Col3_DragLeave(sender As Object, e As EventArgs) Handles txtRow2Col3.DragLeave
        '------------------------------------------------------------
        '-                Subprogram Name: txtRow2Col3_DragLeave    -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: March 10th, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is called whenever the user drags an item-
        '- over Row2Col3 in the tic-tac-toe board and then leaves the-
        '- tile.                                                    -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- sender – Identifies which particular control raised the  –
        '-          click event                                     - 
        '- e – Holds the DragEventArgs object sent to the routine   -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        resetColor(txtRow2Col3)
    End Sub

    Private Sub txtRow3Col1_DragDrop(sender As Object, e As DragEventArgs) Handles txtRow3Col1.DragDrop
        '------------------------------------------------------------
        '-                Subprogram Name: txtRow3Col1_DragDrop     -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: March 10th, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is called whenever the user drags and drops-
        '- an item to Row3Col1 in the tic-tac-toe board.            -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- sender – Identifies which particular control raised the  –
        '-          click event                                     - 
        '- e – Holds the DragEventArgs object sent to the routine   -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        txtRow3Col1.Text = e.Data.GetData(DataFormats.Text).ToString
        resetColor(txtRow3Col1)
        intSquaresVisited += 1
        checkForTie()
        checkForWin()
    End Sub

    Private Sub txtRow3Col1_DragEnter(sender As Object, e As DragEventArgs) Handles txtRow3Col1.DragEnter
        '------------------------------------------------------------
        '-                Subprogram Name: txtRow3Col1_DragEnter    -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: March 10th, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is called whenever the user drags an item-
        '- over Row3Col1 in the tic-tac-toe board.                  -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- sender – Identifies which particular control raised the  –
        '-          click event                                     - 
        '- e – Holds the DragEventArgs object sent to the routine   -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        validDrag(txtRow3Col1)
        If (checkColor(txtRow3Col1)) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub
    Private Sub txtRow3Col1_DragLeave(sender As Object, e As EventArgs) Handles txtRow3Col1.DragLeave
        '------------------------------------------------------------
        '-                Subprogram Name: txtRow3Col1_DragLeave    -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: March 10th, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is called whenever the user drags an item-
        '- over Row3Col1 in the tic-tac-toe board and then leaves the-
        '- tile.                                                    -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- sender – Identifies which particular control raised the  –
        '-          click event                                     - 
        '- e – Holds the DragEventArgs object sent to the routine   -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        resetColor(txtRow3Col1)
    End Sub

    Private Sub txtRow3Col2_DragDrop(sender As Object, e As DragEventArgs) Handles txtRow3Col2.DragDrop
        '------------------------------------------------------------
        '-                Subprogram Name: txtRow3Col2_DragDrop     -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: March 10th, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is called whenever the user drags and drops-
        '- an item to Row3Col2 in the tic-tac-toe board.            -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- sender – Identifies which particular control raised the  –
        '-          click event                                     - 
        '- e – Holds the DragEventArgs object sent to the routine   -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        txtRow3Col2.Text = e.Data.GetData(DataFormats.Text).ToString
        resetColor(txtRow3Col2)
        intSquaresVisited += 1
        checkForTie()
        checkForWin()
    End Sub

    Private Sub txtRow3Col2_DragEnter(sender As Object, e As DragEventArgs) Handles txtRow3Col2.DragEnter
        '------------------------------------------------------------
        '-                Subprogram Name: txtRow3Col2_DragEnter    -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: March 10th, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is called whenever the user drags an item-
        '- over Row3Col2 in the tic-tac-toe board.                  -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- sender – Identifies which particular control raised the  –
        '-          click event                                     - 
        '- e – Holds the DragEventArgs object sent to the routine   -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        validDrag(txtRow3Col2)
        If (checkColor(txtRow3Col2)) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub
    Private Sub txtRow3Col2_DragLeave(sender As Object, e As EventArgs) Handles txtRow3Col2.DragLeave
        '------------------------------------------------------------
        '-                Subprogram Name: txtRow3Col2_DragLeave    -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: March 10th, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is called whenever the user drags an item-
        '- over Row3Col2 in the tic-tac-toe board and then leaves the-
        '- tile.                                                    -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- sender – Identifies which particular control raised the  –
        '-          click event                                     - 
        '- e – Holds the DragEventArgs object sent to the routine   -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        resetColor(txtRow3Col2)
    End Sub

    Private Sub txtRow3Col3_DragDrop(sender As Object, e As DragEventArgs) Handles txtRow3Col3.DragDrop
        '------------------------------------------------------------
        '-                Subprogram Name: txtRow3Col3_DragDrop     -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: March 10th, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is called whenever the user drags and drops-
        '- an item to Row3Col3 in the tic-tac-toe board.            -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- sender – Identifies which particular control raised the  –
        '-          click event                                     - 
        '- e – Holds the DragEventArgs object sent to the routine   -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        txtRow3Col3.Text = e.Data.GetData(DataFormats.Text).ToString
        resetColor(txtRow3Col3)
        intSquaresVisited += 1
        checkForTie()
        checkForWin()
    End Sub

    Private Sub txtRow3Col3_DragEnter(sender As Object, e As DragEventArgs) Handles txtRow3Col3.DragEnter
        '------------------------------------------------------------
        '-                Subprogram Name: txtRow3Col3_DragEnter    -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: March 10th, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is called whenever the user drags an item-
        '- over Row3Col3 in the tic-tac-toe board.                  -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- sender – Identifies which particular control raised the  –
        '-          click event                                     - 
        '- e – Holds the DragEventArgs object sent to the routine   -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        validDrag(txtRow3Col3)
        If (checkColor(txtRow3Col3)) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub
    Private Sub txtRow3Col3_DragLeave(sender As Object, e As EventArgs) Handles txtRow3Col3.DragLeave
        '------------------------------------------------------------
        '-                Subprogram Name: txtRow3Col3_DragLeave    -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: March 10th, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is called whenever the user drags an item-
        '- over Row3Col3 in the tic-tac-toe board and then leaves the-
        '- tile.                                                    -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- sender – Identifies which particular control raised the  –
        '-          click event                                     - 
        '- e – Holds the DragEventArgs object sent to the routine   -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        resetColor(txtRow3Col3)
    End Sub

    Private Sub validDrag(RowCol As TextBox)
        '------------------------------------------------------------
        '-                Subprogram Name: validDrag                -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: March 10th, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is called whenever 'X' or 'O' is dragged -
        '- over a tile and will change the color to red or green for-
        '- valid/invalid move.                                      -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- RowCol - the textbox to be modified.                     -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        If (RowCol.Text.Length = 0) Then 'if the text length is 0, means the text is empty, so the move is valid
            RowCol.BackColor = Color.LightGreen 'change the background color of the textbox to green
        Else
            RowCol.BackColor = Color.Crimson 'otherwise, the move is invalid, so the background color of the textbox is changed to red
        End If
    End Sub

    Private Sub resetColor(RowCol As TextBox)
        '------------------------------------------------------------
        '-                Subprogram Name: resetColor               -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: March 10th, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is to reset the background color of the  -
        '- tic-tac-toe tile.                                        -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- RowCol - the textbox to be modified.                     -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        RowCol.BackColor = Color.LightGray 'changes the textbox color back to light gray
    End Sub

    Private Function checkColor(RowCol As TextBox) As Boolean
        '------------------------------------------------------------
        '-                Function Name: checkColor                 -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: March 10th, 2023              -
        '------------------------------------------------------------
        '- Function Purpose:                                        -
        '- This subroutine is to see if the background color of the -
        '- textbox is green or not.                                 -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- RowCol - the textbox to be considered.                   -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        '- Returns:                                                 -
        '- Boolean - telling if the color is green or not           -
        '------------------------------------------------------------

        If (RowCol.BackColor = Color.LightGreen) Then 'if the color is green, the move is valid, so return true
            Return True
        Else
            Return False 'if the color is not green (meaning red), the move is invalid, so return false
        End If
    End Function

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        '------------------------------------------------------------
        '-                Subprogram Name: btnReset_Click           -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: March 10th, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is to reset the tic-tac-toe board        -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- sender – Identifies which particular control raised the  –
        '-          click event                                     - 
        '- e – Holds the EventArgs object sent to the routine       -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        txtRow1Col1.Text = "" 'block to reset the text in the tiles on the tic-tac-toe board
        txtRow1Col2.Text = ""
        txtRow1Col3.Text = ""

        txtRow2Col1.Text = ""
        txtRow2Col2.Text = ""
        txtRow2Col3.Text = ""

        txtRow3Col1.Text = ""
        txtRow3Col2.Text = ""
        txtRow3Col3.Text = ""

        resetColor(txtRow1Col1) 'block to reset the color of the tiles on the tic-tac-toe board
        resetColor(txtRow1Col2)
        resetColor(txtRow1Col3)

        resetColor(txtRow2Col1)
        resetColor(txtRow2Col2)
        resetColor(txtRow2Col3)

        resetColor(txtRow3Col1)
        resetColor(txtRow3Col2)
        resetColor(txtRow3Col3)

        lblResult.Visible = False 'set the result label to not be visible
        intSquaresVisited = 0 'set squares visited back to 0
        allowDropTrue() 'call allowDropTrue to allow drag/drop again (in case it was disabled)
    End Sub

    Private Sub allowDropTrue()
        '------------------------------------------------------------
        '-                Subprogram Name: allowDropTrue            -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: March 10th, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is to allow dropping into the tic-tac-toe-
        '- tiles.                                                   -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- (None)                                                   -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        txtRow1Col1.AllowDrop = True 'block to allow dropping into the tiles on the tic-tac-toe board
        txtRow1Col2.AllowDrop = True
        txtRow1Col3.AllowDrop = True

        txtRow2Col1.AllowDrop = True
        txtRow2Col2.AllowDrop = True
        txtRow2Col3.AllowDrop = True

        txtRow3Col1.AllowDrop = True
        txtRow3Col2.AllowDrop = True
        txtRow3Col3.AllowDrop = True
    End Sub

    Private Sub allowDropFalse()
        '------------------------------------------------------------
        '-                Subprogram Name: allowDropFalse           -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: March 10th, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is to dis-allow dropping into the tic-tac-toe-
        '- tiles.                                                   -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- (None)                                                   -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        txtRow1Col1.AllowDrop = False 'block to disallow dropping into the tiles on the tic-tac-toe board
        txtRow1Col2.AllowDrop = False
        txtRow1Col3.AllowDrop = False

        txtRow2Col1.AllowDrop = False
        txtRow2Col2.AllowDrop = False
        txtRow2Col3.AllowDrop = False

        txtRow3Col1.AllowDrop = False
        txtRow3Col2.AllowDrop = False
        txtRow3Col3.AllowDrop = False
    End Sub

    Private Sub checkForWin()
        '------------------------------------------------------------
        '-                Subprogram Name: checkForWin              -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: March 10th, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine checks for tic-tac-toe win conditions    -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- (None)                                                   -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------

        'Row 1 Win
        If txtRow1Col1.Text = "X" And txtRow1Col2.Text = "X" And txtRow1Col3.Text = "X" Then
            txtRow1Col1.BackColor = Color.LightBlue
            txtRow1Col2.BackColor = Color.LightBlue
            txtRow1Col3.BackColor = Color.LightBlue
            lblResult.Text = "Game goes to X"
            lblResult.Visible = True
            allowDropFalse()
        End If

        If txtRow1Col1.Text = "O" And txtRow1Col2.Text = "O" And txtRow1Col3.Text = "O" Then
            txtRow1Col1.BackColor = Color.LightBlue
            txtRow1Col2.BackColor = Color.LightBlue
            txtRow1Col3.BackColor = Color.LightBlue
            lblResult.Text = "Game goes to O"
            lblResult.Visible = True
            allowDropFalse()
        End If

        'Row 2 Win
        If txtRow2Col1.Text = "X" And txtRow2Col2.Text = "X" And txtRow2Col3.Text = "X" Then
            txtRow2Col1.BackColor = Color.LightBlue
            txtRow2Col2.BackColor = Color.LightBlue
            txtRow2Col3.BackColor = Color.LightBlue
            lblResult.Text = "Game goes to X"
            lblResult.Visible = True
            allowDropFalse()
        End If

        If txtRow2Col1.Text = "O" And txtRow2Col2.Text = "O" And txtRow2Col3.Text = "O" Then
            txtRow2Col1.BackColor = Color.LightBlue
            txtRow2Col2.BackColor = Color.LightBlue
            txtRow2Col3.BackColor = Color.LightBlue
            lblResult.Text = "Game goes to O"
            lblResult.Visible = True
            allowDropFalse()
        End If

        'Row 3 Win
        If txtRow3Col1.Text = "X" And txtRow3Col2.Text = "X" And txtRow3Col3.Text = "X" Then
            txtRow3Col1.BackColor = Color.LightBlue
            txtRow3Col2.BackColor = Color.LightBlue
            txtRow3Col3.BackColor = Color.LightBlue
            lblResult.Text = "Game goes to X"
            lblResult.Visible = True
            allowDropFalse()
        End If

        If txtRow3Col1.Text = "O" And txtRow3Col2.Text = "O" And txtRow3Col3.Text = "O" Then
            txtRow3Col1.BackColor = Color.LightBlue
            txtRow3Col2.BackColor = Color.LightBlue
            txtRow3Col3.BackColor = Color.LightBlue
            lblResult.Text = "Game goes to O"
            lblResult.Visible = True
            allowDropFalse()
        End If

        'Diag top left to bottom right win
        If txtRow1Col1.Text = "X" And txtRow2Col2.Text = "X" And txtRow3Col3.Text = "X" Then
            txtRow1Col1.BackColor = Color.LightBlue
            txtRow2Col2.BackColor = Color.LightBlue
            txtRow3Col3.BackColor = Color.LightBlue
            lblResult.Text = "Game goes to X"
            lblResult.Visible = True
            allowDropFalse()
        End If

        If txtRow1Col1.Text = "O" And txtRow2Col2.Text = "O" And txtRow3Col3.Text = "O" Then
            txtRow1Col1.BackColor = Color.LightBlue
            txtRow2Col2.BackColor = Color.LightBlue
            txtRow3Col3.BackColor = Color.LightBlue
            lblResult.Text = "Game goes to O"
            lblResult.Visible = True
            allowDropFalse()
        End If

        'Diag top right to bottom left win
        If txtRow1Col3.Text = "X" And txtRow2Col2.Text = "X" And txtRow3Col1.Text = "X" Then
            txtRow1Col3.BackColor = Color.LightBlue
            txtRow2Col2.BackColor = Color.LightBlue
            txtRow3Col1.BackColor = Color.LightBlue
            lblResult.Text = "Game goes to X"
            lblResult.Visible = True
            allowDropFalse()
        End If

        If txtRow1Col3.Text = "O" And txtRow2Col2.Text = "O" And txtRow3Col1.Text = "O" Then
            txtRow1Col3.BackColor = Color.LightBlue
            txtRow2Col2.BackColor = Color.LightBlue
            txtRow3Col1.BackColor = Color.LightBlue
            lblResult.Text = "Game goes to O"
            lblResult.Visible = True
            allowDropFalse()
        End If

        'Column 1 Win
        If txtRow1Col1.Text = "X" And txtRow2Col1.Text = "X" And txtRow3Col1.Text = "X" Then
            txtRow1Col1.BackColor = Color.LightBlue
            txtRow2Col1.BackColor = Color.LightBlue
            txtRow3Col1.BackColor = Color.LightBlue
            lblResult.Text = "Game goes to X"
            lblResult.Visible = True
            allowDropFalse()
        End If

        If txtRow1Col1.Text = "O" And txtRow2Col1.Text = "O" And txtRow3Col1.Text = "O" Then
            txtRow1Col1.BackColor = Color.LightBlue
            txtRow2Col1.BackColor = Color.LightBlue
            txtRow3Col1.BackColor = Color.LightBlue
            lblResult.Text = "Game goes to O"
            lblResult.Visible = True
            allowDropFalse()
        End If

        'Column 2 Win
        If txtRow1Col2.Text = "X" And txtRow2Col2.Text = "X" And txtRow3Col2.Text = "X" Then
            txtRow1Col2.BackColor = Color.LightBlue
            txtRow2Col2.BackColor = Color.LightBlue
            txtRow3Col2.BackColor = Color.LightBlue
            lblResult.Text = "Game goes to X"
            lblResult.Visible = True
            allowDropFalse()
        End If

        If txtRow1Col2.Text = "O" And txtRow2Col2.Text = "O" And txtRow3Col2.Text = "O" Then
            txtRow1Col2.BackColor = Color.LightBlue
            txtRow2Col2.BackColor = Color.LightBlue
            txtRow3Col2.BackColor = Color.LightBlue
            lblResult.Text = "Game goes to O"
            lblResult.Visible = True
            allowDropFalse()
        End If

        'Column 3 Win
        If txtRow1Col3.Text = "X" And txtRow2Col3.Text = "X" And txtRow3Col3.Text = "X" Then
            txtRow1Col3.BackColor = Color.LightBlue
            txtRow2Col3.BackColor = Color.LightBlue
            txtRow3Col3.BackColor = Color.LightBlue
            lblResult.Text = "Game goes to X"
            lblResult.Visible = True
            allowDropFalse()
        End If

        If txtRow1Col3.Text = "O" And txtRow2Col3.Text = "O" And txtRow3Col3.Text = "O" Then
            txtRow1Col3.BackColor = Color.LightBlue
            txtRow2Col3.BackColor = Color.LightBlue
            txtRow3Col3.BackColor = Color.LightBlue
            lblResult.Text = "Game goes to O"
            lblResult.Visible = True
            allowDropFalse()
        End If
    End Sub

    Private Sub checkForTie()
        '------------------------------------------------------------
        '-                Subprogram Name: checkForTie              -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: March 10th, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is to check for a tie                    -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- (None)                                                   -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        If (intSquaresVisited = 9) Then 'if all squares are visited, then it is a potential tie
            lblResult.Text = "Tie game"
            lblResult.Visible = True
        End If
    End Sub

    Private Function successfulDrop(dragDrop As DragDropEffects) As Boolean
        '------------------------------------------------------------
        '-                Function Name: successfulDrop             -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: March 10th, 2023              -
        '------------------------------------------------------------
        '- Function Purpose:                                        -
        '- This subroutine is to see if the drag/drop was successful-
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- dragDrop - the drag/drop event to be considered          -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        '- Returns:                                                 -
        '- Boolean - telling if the drag/drop was successful or not -
        '------------------------------------------------------------
        If (dragDrop = DragDropEffects.None) Then 'if the effect of the dragdrop is 'none', that means the drag/drop was not performed successfully, so return false
            Return False
        End If
        Return True 'otherwise the drag/drop was successful, so return true
    End Function
End Class
