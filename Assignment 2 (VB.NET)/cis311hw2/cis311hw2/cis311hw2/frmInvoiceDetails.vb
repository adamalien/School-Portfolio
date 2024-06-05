Public Class frmInvoiceDetails
    '------------------------------------------------------------
    '-                File Name : frmInvoiceDetails.vb          - 
    '-                Part of Project: cis311hw2                -
    '------------------------------------------------------------
    '-                Written By: Adam Cossin                   -
    '-                Written On: January 23, 2023              -
    '------------------------------------------------------------
    '- File Purpose:                                            -
    '- This file contains the second form which will display the-
    '- price information for the configuration the user selected-
    '- on the previous form.                                    -
    '------------------------------------------------------------
    '- Global Variable Dictionary (alphabetically):             -
    '- blnHardExit - Stores if the program should be completely -
    '-               shut down or not (Includes shutting down   -
    '-               the 'comp config' form).                   -
    '------------------------------------------------------------
    Dim blnHardExit As Boolean = True 'initially set to true because the 'form closing' event should be able to fire at any time that the user clicks the 'x' in the upper right of the form

    Private Sub btnChange_Click(sender As Object, e As EventArgs) Handles btnChange.Click
        '------------------------------------------------------------
        '-                Subprogram Name: btnChange_Click          -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: January 23, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is called whenever the user clicks on the-
        '- 'Change Order' button. Navigates the user back to the    -
        '- configuration form and closes this form. Also clears out -
        '- the rich text box on the page so that it is ready to be  -
        '- filled with the new order's information.                 -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- sender – Identifies which particular control that raised -
        '-          the click event                                 - 
        '- e – Holds the EventArgs object sent to the routine       -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        blnHardExit = False 'set this to false (this is so that the 'form closing' event will not run the 'true' condition)
        Me.rtbOrderDetails.Clear() 'clears the rich text box
        Me.Close() 'closes the current form
        frmCompConfig.Show() 'shows the other form so the user can update their order information
    End Sub

    Private Sub btnProcess_Click(sender As Object, e As EventArgs) Handles btnProcess.Click
        '------------------------------------------------------------
        '-                Subprogram Name: btnProcess_Click         -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: January 23, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is called whenever the user clicks on the-
        '- 'Process Order' button. A message will be shown to the   -
        '- user that their order is processed, and they will be sent-
        '- back to a cleared configuration form to place another    -
        '- order if they would like to.                             -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- sender – Identifies which particular control that raised -
        '-          the click event                                 - 
        '- e – Holds the EventArgs object sent to the routine       -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        blnHardExit = False 'set this to false (this is so that the 'form closing' event will not run the 'true' condition when 'me.close()' is called)
        MessageBox.Show("Thank you! Your order has been sent to the manufacturer for production. You will now be placed back at the configuration screen.") 'sends a success message to the user
        Me.rtbOrderDetails.Clear() 'clears the rich text box
        Me.Close() 'closes the current form
        resetForm() 'calls 'resetForm()'
        frmCompConfig.Show() 'shows the configuration form
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        '------------------------------------------------------------
        '-                Subprogram Name: btnExit_Click            -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: January 23, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is called whenever the user clicks on the-
        '- 'Exit' button. This will cause the 'form closing' event  -
        '- to fire for the form to properly respond to the request. -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- sender – Identifies which particular control that raised -
        '-          the click event                                 - 
        '- e – Holds the EventArgs object sent to the routine       -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        blnHardExit = True 'set this to true since we want to see the 'true' condition in the 'form closing' sub
        Me.Close() 'calls to close the form, firing the 'form closing' sub
    End Sub

    Private Sub frmInvoiceDetails_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        '------------------------------------------------------------
        '-            Subprogram Name: frmInvoiceDetails_FormClosing-
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: January 23, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is called whenever the user tries to     -
        '- close the form from the exit button or from the 'x' in   -
        '- the top right corner of the form. Gives the user the     -
        '- option to either terminate the program or to keep using  -
        '- it by clicking y/n on the 'are you sure' dialog.         -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- sender – Identifies which particular control that raised -
        '-          the click event                                 - 
        '- e – Holds the EventArgs object sent to the routine       -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        If (blnHardExit = True) Then 'if the boolean is set to true, then the form is intended to be closed
            If MessageBox.Show("Are you sure you want to exit?", "Invoice Details", MessageBoxButtons.YesNo) = DialogResult.No Then 'shows the user a message to make sure they want to exit and gives y/n option
                e.Cancel = True 'if they clicked no (as seen in the if statement above), then the form closing event will cancel
                blnHardExit = True
            Else 'if the user clicks on yes, that means they want the program to terminate
                frmCompConfig.blnClose = True 'the value of 'blnClose' on the configuration form is passed 'true' so that the form's closing event will run the 'true' condition
                frmCompConfig.Close() 'closes the configuration form, since this is the main form, this form will close also
            End If
        End If
        blnHardExit = True 'if the boolean value was set to false before, it's because we didn't want to run the 'true' condition (meaning when you click on 'change order', we didn't want the form to prompt if the user wanted to close
        'or not, etc.), but after this is done, the value needs to be set back to true so that once the user gets back to this form, they are able to close it at any time and the 'true' condition of form closing will run
    End Sub

    Private Sub resetForm()
        '------------------------------------------------------------
        '-                Subprogram Name: resetForm                -  
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: January 23, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is called to reset the configuration form-
        '- so that all values are set back to 'default' states.     -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- (None)                                                   -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        frmCompConfig.txtCustName.Clear() 'this and the line underneath will reset the text boxes to be empty
        frmCompConfig.txtQuantity.Clear()

        'this block will reset the 'desktop' configuration values back to default
        frmCompConfig.rdoDesktop.Select()
        frmCompConfig.rdoDesktopNVIDIA.Select()
        frmCompConfig.rdoDesktopSmRAM.Select()
        frmCompConfig.rdoDesktopSmHD.Select()
        frmCompConfig.rdoDesktopSmProc.Select()
        frmCompConfig.chkDesktopCool.Checked = False
        frmCompConfig.chkDesktopSound.Checked = False
        frmCompConfig.chkDesktopDVD.Checked = False

        'this block will reset the 'notebook' configuration values back to default
        frmCompConfig.rdoNotebookIntel.Select()
        frmCompConfig.rdoNotebookSmRAM.Select()
        frmCompConfig.rdoNotebookSmHD.Select()
        frmCompConfig.rdoNotebookSmProc.Select()
        frmCompConfig.chkNotebookCam.Checked = False
        frmCompConfig.chkNotebookCool.Checked = False
        frmCompConfig.chkNotebookDVD.Checked = False
        frmCompConfig.chkNotebookSD.Checked = False

        'this block will reset the 'tablet' configuration values back to default
        frmCompConfig.rdoTabletSmProc.Select()
        frmCompConfig.rdoTabletSmHD.Select()
        frmCompConfig.chkTabletSD.Checked = False
        frmCompConfig.chkTabletCam.Checked = False
    End Sub
End Class