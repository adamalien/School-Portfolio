Public Class frmCompConfig
    '------------------------------------------------------------
    '-                File Name : frmCompConfig.vb              - 
    '-                Part of Project: cis311hw2                -
    '------------------------------------------------------------
    '-                Written By: Adam Cossin                   -
    '-                Written On: January 23, 2023              -
    '------------------------------------------------------------
    '- File Purpose:                                            -
    '- This file contains the main application form where the   -
    '- user will make choices about what system they would like -
    '- to purchase. The user will then be able to place an order-
    '- where the information they have entered will be formatted-
    '- and ultimately shown on the next form.                   -
    '------------------------------------------------------------
    '- Program Purpose:                                         -
    '- This program's purpose is to take user input from the    -
    '- configuration form, calculate the cost of thier          -
    '- selections, and show a bill on the next form where they  -
    '- can see if they would like to proceed with the order,    -
    '- change the order, or exit.
    '------------------------------------------------------------
    '- Global Variable Dictionary (alphabetically):             -
    '- blnClose – Value that stores whether or not the form     –
    '-            should be closed.                             –
    '------------------------------------------------------------
    Public Property blnClose As Boolean = False 'initialized to 'false' because the form should not be able to be closed initially
    Private Sub btnPlaceOrder_Click(sender As Object, e As EventArgs) Handles btnPlaceOrder.Click
        '------------------------------------------------------------
        '-                Subprogram Name: btnPlaceOrder_Click      -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: January 23, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is called whenever the user clicks the   -
        '- btnPlaceOrder button.  The program will call the sub     –
        '- 'getcompDetails()'.                                      –
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- (None)                                                   -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        getCompDetails() 'calls 'getCompDetails() sub
    End Sub

    Private Sub frmCompConfig_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        '------------------------------------------------------------
        '-                Subprogram Name: frmCompConfig_FormClosing-
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: January 23, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is called whenever the user tries to     –
        '- close the form (Which is only actually accessible by the -
        '- red 'x' on the top right on this form).                  -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- sender – Identifies which particular control that raised -
        '-          the click event                                 - 
        '- e – Holds the EventArgs object sent to the routine       -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        If (blnClose = False) Then 'if 'blnClose' is set to false, that means we don't want the form to be able to be closed, so, a message is displayed and the event is canceled
            MessageBox.Show("Sorry, but you can only close out of the application from the Invoice screen." & vbCrLf & "Please press Place Order to go to that screen...")
            e.Cancel = True 'cancels the 'form closing' event
        End If
    End Sub

    Private Sub rdoDesktop_CheckedChanged(sender As Object, e As EventArgs) Handles rdoDesktop.CheckedChanged
        '------------------------------------------------------------
        '-                Subprogram Name: rdoDesktop_CheckedChanged-
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: January 23, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is called whenever the user clicks or    -
        '- unclicks the 'rdoDesktop' button for chosing 'Desktop' as-
        '- the form factor of their machines. If desktop is chosen, -
        '- then the user is able to see the controls for the desktop-
        '- option, and the controls for other form factors are      -
        '- hidden.                                                  -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- sender – Identifies which particular control that raised -
        '-          the click event                                 - 
        '- e – Holds the EventArgs object sent to the routine       -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        If (rdoDesktop.Checked) Then 'if the radiobutton for 'Desktop' is chosen, then the user is able to see the different options for a desktop configuration
            grbDesktopVideo.Visible = True
            grbDesktopRAM.Visible = True
            grbDesktopHD.Visible = True
            grbDesktopProcessor.Visible = True
            grbDesktopDVD.Visible = True
            grbDesktopSound.Visible = True
            grbDesktopCool.Visible = True
        Else 'if the radiobutton for 'Desktop' is not chosen (meaning a different button in the group is selected), then the user is unable to see the options for a desktop configuration
            grbDesktopVideo.Visible = False
            grbDesktopRAM.Visible = False
            grbDesktopHD.Visible = False
            grbDesktopProcessor.Visible = False
            grbDesktopDVD.Visible = False
            grbDesktopSound.Visible = False
            grbDesktopCool.Visible = False
        End If
    End Sub

    Private Sub rdoNotebook_CheckedChanged(sender As Object, e As EventArgs) Handles rdoNotebook.CheckedChanged
        '------------------------------------------------------------
        '-               Subprogram Name: rdoNotebook_CheckedChanged-
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: January 23, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is called whenever the user clicks or    -
        '- unclicks the 'rdoNotebook' button for chosing 'Notebook' -
        '- as the form factor of their machines. If notebook is     -
        '- chosen, then the user is able to see the controls for the-
        '- notebook option, and the controls for other form factors -
        '- are hidden.                                              -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- sender – Identifies which particular control that raised -
        '-          the click event                                 - 
        '- e – Holds the EventArgs object sent to the routine       -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        If (rdoNotebook.Checked) Then 'if the radiobutton for 'Notebook' is chosen, then the user is able to see the different options for a notebook configuration
            grbNotebookVideo.Visible = True
            grbNotebookRAM.Visible = True
            grbNotebookHD.Visible = True
            grbNotebookProcessor.Visible = True
            grbNotebookDVD.Visible = True
            grbNotebookCam.Visible = True
            grbNotebookCool.Visible = True
            grbNotebookSD.Visible = True
        Else 'if the radiobutton for 'Notebook' is not chosen (meaning a different button in the group is selected), then the user is unable to see the options for a notebook configuration
            grbNotebookVideo.Visible = False
            grbNotebookRAM.Visible = False
            grbNotebookHD.Visible = False
            grbNotebookProcessor.Visible = False
            grbNotebookDVD.Visible = False
            grbNotebookCam.Visible = False
            grbNotebookCool.Visible = False
            grbNotebookSD.Visible = False
        End If
    End Sub

    Private Sub rdoTablet_CheckedChanged(sender As Object, e As EventArgs) Handles rdoTablet.CheckedChanged
        '------------------------------------------------------------
        '-                Subprogram Name: rdoTablet_CheckedChanged -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: January 23, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is called whenever the user clicks or    -
        '- unclicks the 'rdoTablet' button for chosing 'Tablet' as  -
        '- the form factor of their machines. If tablet is chosen,  -
        '- then the user is able to see the controls for the tablet -
        '- option, and the controls for other form factors are      -
        '- hidden.                                                  -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- sender – Identifies which particular control that raised -
        '-          the click event                                 - 
        '- e – Holds the EventArgs object sent to the routine       -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        If (rdoTablet.Checked) Then 'if the radiobutton for 'Tablet' is chosen, then the user is able to see the different options for a tablet configuration
            grbTabletCam.Visible = True
            grbTabletHD.Visible = True
            grbTabletProcessor.Visible = True
            grbTabletSD.Visible = True
        Else 'if the radiobutton for 'Tablet' is not chosen (meaning a different button in the group is selected), then the user is unable to see the options for a tablet configuration
            grbTabletCam.Visible = False
            grbTabletHD.Visible = False
            grbTabletProcessor.Visible = False
            grbTabletSD.Visible = False
        End If
    End Sub

    Private Sub write(strText As String)
        '------------------------------------------------------------
        '-                Subprogram Name: write                    -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: January 23, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is used to write to the rich text box on -
        '- the invoice form.                                        -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- strText - A string value that needs to be written to the -
        '-           rich text box.                                 -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        frmInvoiceDetails.rtbOrderDetails.AppendText(strText) 'writes the passed text to the rich text box on the 'invoice details' form
    End Sub

    Private Sub setTitle(strName As String)
        '------------------------------------------------------------
        '-                Subprogram Name: setTitle                 -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: January 23, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is used to write the title to the rich   -
        '- text box on the 'invoice details' form and uses the      -
        '- 'write' sub to do so.                                    -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- strName - A string name that needs to be written to the  -
        '-           rich text box as the customer's name.          -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        write("==================================================" + vbCrLf)
        write("Custom Systems for " + strName + vbCrLf) 'writes the customer name at the top of the invoice details form
        write("==================================================" + vbCrLf + vbCrLf + vbCrLf)
    End Sub

    Private Sub getCompDetails()
        '------------------------------------------------------------
        '-                Subprogram Name: getCompDetails           -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: January 23, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is used to determine which values need to-
        '- be shown on the 'invoice details' form based on which    -
        '- form factor the user chose.                              -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- (None)                                                   -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- intQuantity - The number the user entered for quantity   -
        '- strFormFactor - The string representation of the form    -
        '-                 factor that the user chose.              -
        '------------------------------------------------------------
        Try 'handles if the user enters a non-numeric value in the 'quantity' field
            Dim intQuantity As Integer = Me.txtQuantity.Text 'if they did enter a numeric value, then that is stored in 'intQuantity'
            If (txtQuantity.Text = "0") Then 'if the user entered '0', this would not be a valid order, so a message is shown and the user is prompted to enter a new value for quantity
                MessageBox.Show("The value you've entered in the 'Quantity' field is invalid. Please enter a numeric value greater than 0.")
                Me.txtQuantity.Clear() 'quantity text box is cleared
                Me.txtQuantity.Focus() 'quantity text box is focused so that the user can enter a valid value in the field
            Else 'if code reaches this point, that means the value the user entered is valid
                setTitle(Me.txtCustName.Text) 'setTitle sub is called and the customer's name is passed (doing this here because now we know that the data is valid to send to the next form)
                Dim strFormFactor As String = Me.grbFormFactor.Controls.OfType(Of RadioButton).FirstOrDefault(Function(r) r.Checked = True).Text 'gets the text value from the radio button that is clicked in the 'form factor' group
                Select Case strFormFactor 'using select to determine which sub needs to be called based on the form factor chosen
                    Case "Desktop"
                        handleDesktopOrder(intQuantity) 'calls 'handleDesktopOrder' and passes the user-entered quantity
                    Case "Notebook"
                        handleNotebookOrder(intQuantity) 'calls 'handleNotebookOrder' and passes the user-entered quantity
                    Case "Tablet"
                        handleTabletOrder(intQuantity) 'calls 'handleTabletOrder' and passes the user-entered quantity
                End Select
                frmInvoiceDetails.ShowDialog() 'shows the invoice form (which will now be filled with data), and limits access to this (frmCompConfig) form
            End If
        Catch ex As Exception 'if the user enteres a non-numeric value, then an exception is caught and the user is prompted to enter a valid value
            MessageBox.Show("The value you've entered in the 'Quantity' field is invalid. Please enter a numeric value greater than 0.")
            Me.txtQuantity.Clear() 'quantity text box is cleared
            Me.txtQuantity.Focus() 'quantity text box is focused so that the user can enter a valid value in the field
        End Try
    End Sub

    Private Sub handleDesktopOrder(intQuan As Integer)
        '------------------------------------------------------------
        '-                Subprogram Name: handleDesktopOrder       -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: January 23, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is used to calculate the items for the   -
        '- user-configurated machine, and display the proper fields -
        '- and totals to the 'invoice details' form.                -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- intQuan - The number of devices the user wants.          -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- blnCool - Stores if the user wants liquid cooling or not.-
        '- blnDVD - Stores if the user wants a DVD-ROM or not.      -
        '- blnSound - Stores if the user wants a sound card or not. -
        '- intCool - Stores the cost of cooling in the machine.     -
        '- intDVD - Stores the cost of a DVD-ROM in the machine.    -
        '- intHD - Stores the cost of the hard disk in the machine. -
        '- intProc - Stores the cost of the processor in the machine-
        '- intRAM - Stores the cost of the RAM in the machine.      -
        '- intVideo - Stores the cost of the video card in the machine-
        '- strHD - Stores the string value of the hard disk chosen. -
        '- strProc - Stores the string value of the processor chosen-
        '- strRAM - Stores the string value of the RAM chosen.      -
        '- strVideo - Stores the string value of the video card chosen-
        '------------------------------------------------------------
        Dim intVideo As Integer
        Dim intRAM As Integer
        Dim intHD As Integer
        Dim intProc As Integer
        Dim intDVD As Integer = 0 'initialized to 0, because if the user did not pick to have it, the value will be zero
        Dim intSound As Integer = 0 'intitialized to 0, because if the user did not pick to have it, the value will be zero
        Dim intCool As Integer = 0 'intitialized to 0, because if the user did not pick to have it, the value will be zero
        Const BASECOST = 100 'base cost for a desktop unit
        Dim strVideo As String = Me.grbDesktopVideo.Controls.OfType(Of RadioButton).FirstOrDefault(Function(r) r.Checked = True).Text 'gets the name of the video card
        Dim strRAM As String = Me.grbDesktopRAM.Controls.OfType(Of RadioButton).FirstOrDefault(Function(r) r.Checked = True).Text 'gets the name of the RAM
        Dim strHD As String = Me.grbDesktopHD.Controls.OfType(Of RadioButton).FirstOrDefault(Function(r) r.Checked = True).Text 'gets the name of the HD
        Dim strProc As String = Me.grbDesktopProcessor.Controls.OfType(Of RadioButton).FirstOrDefault(Function(r) r.Checked = True).Text 'gets the name of the processor
        Dim blnDVD As String = Me.chkDesktopDVD.Checked 'gets if the user wanted a DVD-ROM
        Dim blnSound As String = Me.chkDesktopSound.Checked 'gets if the user wanted a sound card
        Dim blnCool As String = Me.chkDesktopCool.Checked 'gets if the user wanted liquid cooling
        Select Case strVideo 'select case to determine which video card the user chose, and sets the 'intVideo' value accordingly
            Case "nVidia"
                intVideo = 250
            Case "ATI"
                intVideo = 200
        End Select
        Select Case strRAM 'select case to determine which RAM the user chose, and sets the 'intRAM' value accordingly
            Case "8GB"
                intRAM = 100
            Case "12GB"
                intRAM = 200
            Case "16GB"
                intRAM = 250
        End Select
        Select Case strHD 'select case to determine which hard disk the user chose, and sets the 'intHD' value accordingly
            Case "1TB"
                intHD = 50
            Case "2TB"
                intHD = 100
            Case "4TB"
                intHD = 150
        End Select
        Select Case strProc 'select case to determine which processor the user chose, and sets the 'intProc' value accordingly
            Case "i5"
                intProc = 50
            Case "i7"
                intProc = 100
        End Select
        Select Case blnDVD 'select case to determine if the user wanted a DVD-ROM, if they did, updates the value of 'intDVD' accordingly
            Case "True"
                intDVD = 30
        End Select
        Select Case blnSound 'select case to determine if the user wanted a sound card, if they did, updates the value of 'intSound' accordingly
            Case "True"
                intSound = 50
        End Select
        Select Case blnCool 'select case to determine if the user wanted liquid cooling, if they did, updates the value of 'intCool' accordingly
            Case "True"
                intCool = 75
        End Select
        Dim dclTotal As Decimal = BASECOST + intVideo + intRAM + intHD + intProc + intDVD + intSound + intCool 'gets the total cost of one machine
        'block of write statments to display the relevant information to the user
        write("Base Desktop Price: " + String.Format("{0:C2}", BASECOST) + vbCrLf)
        write(strProc + " Price: " + String.Format("{0:C2}", intProc) + vbCrLf)
        write(strHD + " Price: " + String.Format("{0:C2}", intHD) + vbCrLf)
        write(strRAM + " Price: " + String.Format("{0:C2}", intRAM) + vbCrLf)
        write(strVideo + " Price: " + String.Format("{0:C2}", intVideo) + vbCrLf)
        If (Not intDVD = 0) Then
            write("DVD-ROM Price: " + String.Format("{0:C2}", intDVD) + vbCrLf)
        End If
        If (Not intSound = 0) Then
            write("Sound Card Price: " + String.Format("{0:C2}", intSound) + vbCrLf)
        End If
        If (Not intCool = 0) Then
            write("Liquid Cooling Price: " + String.Format("{0:C2}", intCool) + vbCrLf)
        End If
        write("==================================================" + vbCrLf)
        write("Cost Per Unit: " + String.Format("{0:C2}", dclTotal) + vbCrLf + vbCrLf)
        write("Quantity: " + intQuan.ToString + vbCrLf)
        write("==================================================" + vbCrLf)
        dclTotal = dclTotal * intQuan 'gets the grand total for the entire order
        write("Order Grand Total: " + String.Format("{0:C2}", dclTotal) + vbCrLf)
        write("==================================================")
    End Sub

    Private Sub handleNotebookOrder(intQuan As Integer)
        '------------------------------------------------------------
        '-                Subprogram Name: handleNotebookOrder      -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: January 23, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is used to calculate the items for the   -
        '- user-configurated machine, and display the proper fields -
        '- and totals to the 'invoice details' form.                -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- intQuan - The number of devices the user wants.          -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- blnCam - Stores if the user wants a camera or not.       -
        '- blnCool - Stores if the user wants liquid cooling or not.-
        '- blnDVD - Stores if the user wants a DVD-ROM or not.      -
        '- blnSD - Stores if the user wants an SD card or not.      -
        '- intCam - Stores the cost of the camera in the machine.   -
        '- intCool - Stores the cost of cooling in the machine.     -
        '- intDVD - Stores the cost of a DVD-ROM in the machine.    -
        '- intHD - Stores the cost of the hard disk in the machine. -
        '- intProc - Stores the cost of the processor in the machine-
        '- intRAM - Stores the cost of the RAM in the machine.      -
        '- intSD - Stores the cost of the SD card in the machine.   -
        '- intVideo - Stores the cost of the video card in the machine-
        '- strHD - Stores the string value of the hard disk chosen. -
        '- strProc - Stores the string value of the processor chosen-
        '- strRAM - Stores the string value of the RAM chosen.      -
        '- strVideo - Stores the string value of the video card chosen-
        '------------------------------------------------------------
        Dim intVideo As Integer
        Dim intRAM As Integer
        Dim intHD As Integer
        Dim intProc As Integer
        Dim intDVD As Integer = 0 'initialized to 0, because if the user did not pick to have it, the value will be zero
        Dim intSD As Integer = 0 'initialized to 0, because if the user did not pick to have it, the value will be zero
        Dim intCool As Integer = 0 'initialized to 0, because if the user did not pick to have it, the value will be zero
        Dim intCam As Integer = 0 'initialized to 0, because if the user did not pick to have it, the value will be zero
        Const BASECOST = 125 'base cost for a notebook unit
        Dim strVideo As String = Me.grbNotebookVideo.Controls.OfType(Of RadioButton).FirstOrDefault(Function(r) r.Checked = True).Text 'gets the name of the video card
        Dim strRAM As String = Me.grbNotebookRAM.Controls.OfType(Of RadioButton).FirstOrDefault(Function(r) r.Checked = True).Text 'gets the name of the RAM
        Dim strHD As String = Me.grbNotebookHD.Controls.OfType(Of RadioButton).FirstOrDefault(Function(r) r.Checked = True).Text 'gets the name of the hard disk
        Dim strProc As String = Me.grbNotebookProcessor.Controls.OfType(Of RadioButton).FirstOrDefault(Function(r) r.Checked = True).Text 'gets the name of the processor
        Dim blnDVD As String = Me.chkNotebookDVD.Checked 'gets if the user wanted a DVD-ROM
        Dim blnSD As String = Me.chkNotebookSD.Checked 'gets if the user wanted an SD card
        Dim blnCool As String = Me.chkNotebookCool.Checked 'gets if the user wanted liquid cooling
        Dim blnCam As String = Me.chkNotebookCam.Checked 'gets if the user wanted an internal camera
        Select Case strVideo 'select case to determine which video card the user chose, and sets the 'intVideo' value accordingly
            Case "Intel"
                intVideo = 50
            Case "ATI"
                intVideo = 200
        End Select
        Select Case strRAM 'select case to determine which RAM the user chose, and sets the 'intRAM' value accordingly
            Case "4GB"
                intRAM = 50
            Case "8GB"
                intRAM = 100
        End Select
        Select Case strHD 'select case to determine which hard disk the user chose, and sets the 'intHD' value accordingly
            Case "320GB"
                intHD = 50
            Case "720GB"
                intHD = 75
        End Select
        Select Case strProc 'select case to determine which processor the user chose, and sets the 'intProc' value accordingly
            Case "i5"
                intProc = 50
            Case "i7"
                intProc = 100
        End Select
        Select Case blnDVD 'select case to determine if the user wanted a DVD-ROM, if they did, updates the value of 'intDVD' accordingly
            Case "True"
                intDVD = 30
        End Select
        Select Case blnSD 'select case to determine if the user wanted an SD card, if they did, updates the value of 'intSD' accordingly
            Case "True"
                intSD = 20
        End Select
        Select Case blnCool 'select case to determine if the user wanted liquid cooling, if they did, updates the value of 'intCool' accordingly
            Case "True"
                intCool = 75
        End Select
        Select Case blnCam 'select case to determine if the user wanted an internal camera, if they did, updates the value of 'intCam' accordingly
            Case "True"
                intCam = 20
        End Select
        Dim dclTotal As Decimal = BASECOST + intVideo + intRAM + intHD + intProc + intDVD + intSD + intCool + intCam 'gets the total cost of one machine
        'block of write statments to display the relevant information to the user
        write("Base Notebook Price: " + String.Format("{0:C2}", BASECOST) + vbCrLf)
        write(strProc + " Price: " + String.Format("{0:C2}", intProc) + vbCrLf)
        write(strHD + " Price: " + String.Format("{0:C2}", intHD) + vbCrLf)
        write(strRAM + " Price: " + String.Format("{0:C2}", intRAM) + vbCrLf)
        write(strVideo + " Price: " + String.Format("{0:C2}", intVideo) + vbCrLf)
        If (Not intDVD = 0) Then
            write("DVD-ROM Price: " + String.Format("{0:C2}", intDVD) + vbCrLf)
        End If
        If (Not intSD = 0) Then
            write("SD Card Price: " + String.Format("{0:C2}", intSD) + vbCrLf)
        End If
        If (Not intCool = 0) Then
            write("Liquid Cooling Price: " + String.Format("{0:C2}", intCool) + vbCrLf)
        End If
        If (Not intCam = 0) Then
            write("Internal Camera Price: " + String.Format("{0:C2}", intCam) + vbCrLf)
        End If
        write("==================================================" + vbCrLf)
        write("Cost Per Unit: " + String.Format("{0:C2}", dclTotal) + vbCrLf + vbCrLf)
        write("Quantity: " + intQuan.ToString + vbCrLf)
        write("==================================================" + vbCrLf)
        dclTotal = dclTotal * intQuan 'gets the grand total for the entire order
        write("Order Grand Total: " + String.Format("{0:C2}", dclTotal) + vbCrLf)
        write("==================================================")
    End Sub

    Private Sub handleTabletOrder(intQuan As Integer)
        '------------------------------------------------------------
        '-                Subprogram Name: handleTabletOrder       -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: January 23, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is used to calculate the items for the   -
        '- user-configurated machine, and display the proper fields -
        '- and totals to the 'invoice details' form.                -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- intQuan - The number of devices the user wants.          -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- blnCam - Stores if the user wants a camera or not.       -
        '- blnSD - Stores if the user wants an SD card or not.      -
        '- intCam - Tores the cost of the camera in the machine.    -
        '- intHD - Stores the cost of the hard disk in the machine. -
        '- intProc - Stores the cost of the processor in the machine-
        '- intSD - Stores the cost of the SD card in the machine.   -
        '- strHD - Stores the string value of the hard disk chosen. -
        '- strProc - Stores the string value of the processor chosen-
        '------------------------------------------------------------
        Dim intHD As Integer
        Dim intProc As Integer
        Dim intSD As Integer = 0 'initialized to 0, because if the user did not pick to have it, the value will be zero
        Dim intCam As Integer = 0 'initialized to 0, because if the user did not pick to have it, the value will be zero
        Const BASECOST = 75
        Dim strHD As String = Me.grbTabletHD.Controls.OfType(Of RadioButton).FirstOrDefault(Function(r) r.Checked = True).Text 'gets the name of the hard disk
        Dim strProc As String = Me.grbTabletProcessor.Controls.OfType(Of RadioButton).FirstOrDefault(Function(r) r.Checked = True).Text 'gets the name of the processor
        Dim blnSD As String = Me.chkTabletSD.Checked 'gets if the user wanted an SD card
        Dim blnCam As String = Me.chkTabletCam.Checked 'gets if the user wanted an internal camera
        Select Case strHD 'select case to determine which hard disk the user chose, and sets the 'intHD' value accordingly
            Case "8GB"
                intHD = 100
            Case "16GB"
                intHD = 150
            Case "32GB"
                intHD = 200
        End Select
        Select Case strProc 'select case to determine which processor the user chose, and sets the 'intProc' value accordingly
            Case "ARM"
                intProc = 50
            Case "Intel"
                intProc = 75
        End Select
        Select Case blnSD 'select case to determine if the user wanted an SD card, if they did, updates the value of 'intSD' accordingly
            Case "True"
                intSD = 20
        End Select
        Select Case blnCam 'select case to determine if the user wanted an internal camera, if they did, updates the value of 'intCam' accordingly
            Case "True"
                intCam = 20
        End Select
        Dim dclTotal As Decimal = BASECOST + intHD + intProc + intSD + intCam 'gets the total cost of one machine
        'block of write statments to display the relevant information to the user
        write("Base Tablet Price: " + String.Format("{0:C2}", BASECOST) + vbCrLf)
        write(strProc + " Price: " + String.Format("{0:C2}", intProc) + vbCrLf)
        write(strHD + " Price: " + String.Format("{0:C2}", intHD) + vbCrLf)
        If (Not intSD = 0) Then
            write("SD Card Price: " + String.Format("{0:C2}", intSD) + vbCrLf)
        End If
        If (Not intCam = 0) Then
            write("Internal Camera: " + String.Format("{0:C2}", intCam) + vbCrLf)
        End If
        write("==================================================" + vbCrLf)
        write("Cost Per Unit: " + String.Format("{0:C2}", dclTotal) + vbCrLf + vbCrLf)
        write("Quantity: " + intQuan.ToString + vbCrLf)
        write("==================================================" + vbCrLf)
        dclTotal = dclTotal * intQuan 'gets the grand total for the entire order
        write("Order Grand Total: " + String.Format("{0:C2}", dclTotal) + vbCrLf)
        write("==================================================")
    End Sub
End Class
