Public Class frmEVMCalculator
    '------------------------------------------------------------
    '-                File Name : frmAbout.vb                    - 
    '-                Part of Project: cis311hw6                 -
    '------------------------------------------------------------
    '-                Written By: Adam Cossin                    -
    '-                Written On: Feb 21, 2023        -
    '------------------------------------------------------------
    '- File Purpose:                                            -
    '- This file contains the about form which will display an aboutbox- 
    '------------------------------------------------------------
    '- Global Variable Dictionary (alphabetically):             -
    '- arrlstMessages – List of error messages to display to the user.-
    '------------------------------------------------------------
    Private arrlstMessages As ArrayList

    Private Sub btnClearForm_Click(sender As Object, e As EventArgs) Handles btnClearForm.Click
        '------------------------------------------------------------
        '-                Subprogram Name: btnClearForm_Click       -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                    -
        '-                Written On: Feb 21, 2023                   -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine is called whenever the clear form button is clicked.-
        '- The form will be cleared/set to a default state.         -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- sender – Identifies which particular control raised the  –
        '-          click event                                     - 
        '- e – Holds the EventArgs object sent to the routine       -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        txtPresentValue.Clear() 'clears the textboxes
        txtActualCost.Clear()
        txtEarnedValue.Clear()
        txtBalanceAtCompletion.Clear()
        txtOriginalTime.Clear()
        rdoMonths.Select() 'sets the 'months' radio button to be selected

        txtCostVariance.Clear() 'clears the textboxes
        txtScheduleVariance.Clear()
        txtCostPerformanceIndex.Clear()
        txtSchedulePerformanceIndex.Clear()
        txtEstimateAtCompletion.Clear()
        txtTimeAtCompletion.Clear()

        btnCostVariance.BackColor = Color.DarkGray 'set the buttons to default color
        btnScheduleVariance.BackColor = Color.DarkGray
        btnCostPerformanceIndex.BackColor = Color.DarkGray
        btnSchedulePerformanceIndex.BackColor = Color.DarkGray
        btnEstimateAtCompletion.BackColor = Color.DarkGray
        btnTimeAtCompletion.BackColor = Color.DarkGray
    End Sub

    Private Sub frmEVMCalculator_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '------------------------------------------------------------
        '-                Subprogram Name: frmEVMCalculator_Load       -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                    -
        '-                Written On: Feb 21, 2023                   -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine is called whenever the form is loaded. The default-
        '- rdo button is selected.                                  -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- sender – Identifies which particular control raised the  –
        '-          click event                                     - 
        '- e – Holds the EventArgs object sent to the routine       -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        rdoMonths.Select() 'select a default value for radiobutton groupbox
    End Sub

    Private Sub calcCostVariance()
        '------------------------------------------------------------
        '-                Subprogram Name: calcCostVariance       -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                    -
        '-                Written On: Feb 21, 2023                   -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine is called to calculate the cost variance.-
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- (None)                                                   -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- decCostVariance - stores the value of cost variance.     -
        '------------------------------------------------------------
        Try
            Dim decCostVariance As Decimal = txtEarnedValue.Text - txtActualCost.Text 'calculates cost variance from the proper text fields
            txtCostVariance.Text = String.Format("{0:C2}", decCostVariance) 'populates the costVariance text box
        Catch ex As Exception

        End Try
    End Sub

    Private Sub calcScheduleVariance()
        '------------------------------------------------------------
        '-                Subprogram Name: calcScheduleVariance     -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                    -
        '-                Written On: Feb 21, 2023                   -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine is called to calculate the schedule variance.-
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- (None)                                                   -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- decScheduleVariance - stores the value of schedule variance.     -
        '------------------------------------------------------------
        Try
            Dim decScheduleVariance As Decimal = txtEarnedValue.Text - txtPresentValue.Text 'calculates schedule variance from the proper text fields
            txtScheduleVariance.Text = String.Format("{0:C2}", decScheduleVariance) 'populates the scheduleVariane text box
        Catch ex As Exception

        End Try
    End Sub

    Private Sub calcCostPerformanceIndex()
        '------------------------------------------------------------
        '-                Subprogram Name: calcCostPerformanceIndex     -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                    -
        '-                Written On: Feb 21, 2023                   -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine is called to calculate the cost performance index.-
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- (None)                                                   -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- decCostPerformanceIndex - stores the value of cost performance index.-
        '------------------------------------------------------------
        Try
            Dim decCostPerformanceIndex As Decimal = txtEarnedValue.Text / txtActualCost.Text 'calculates from proper text fields
            txtCostPerformanceIndex.Text = String.Format("{0:0%}", decCostPerformanceIndex) 'populates text box with above result
        Catch ex As Exception

        End Try
    End Sub

    Private Sub calcSchedulePerformanceIndex()
        '------------------------------------------------------------
        '-                Subprogram Name: calcSchedulePerformanceIndex     -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                    -
        '-                Written On: Feb 21, 2023                   -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine is called to calculate the schedule performance index.-
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- (None)                                                   -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- decSchedulePerformanceIndex - stores the value of schedule performance index.-
        '------------------------------------------------------------
        Try
            Dim decSchedulePerformanceIndex As Decimal = txtEarnedValue.Text / txtPresentValue.Text 'calculates from proper text fields
            txtSchedulePerformanceIndex.Text = String.Format("{0:0%}", decSchedulePerformanceIndex) 'populates text box with above result
        Catch ex As Exception

        End Try
    End Sub

    Private Sub calcEstimateAtCompletion()
        '------------------------------------------------------------
        '-                Subprogram Name: calcEstimateAtCompletion    -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                    -
        '-                Written On: Feb 21, 2023                   -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine is called to calculate the estimate at completion.-
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- (None)                                                   -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- decEstimateAtCompletion - stores the value of estimate at completion.-
        '------------------------------------------------------------
        Try
            Dim decEstimateAtCompletion As Decimal = txtBalanceAtCompletion.Text / (txtCostPerformanceIndex.Text.Replace("%", "") / 100) 'calculates from proper text fields
            txtEstimateAtCompletion.Text = String.Format("{0:C2}", decEstimateAtCompletion) 'populates text box with above result
        Catch ex As Exception
            txtEstimateAtCompletion.Text = "CPI must be numeric" 'catches if CPI is non-numeric
        End Try
    End Sub

    Private Sub calcTimeAtCompletion()
        '------------------------------------------------------------
        '-                Subprogram Name: calcTimeAtCompletion    -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                    -
        '-                Written On: Feb 21, 2023                   -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine is called to calculate the time at completion.-
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- (None)                                                   -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- decTimeAtCompletion - stores the value of time at completion.-
        '- strMonthsOrYears - stores if the selected rdo button is months or years.-
        '------------------------------------------------------------
        Dim strMonthsOrYears As String = "" 'initialize
        If (rdoMonths.Checked) Then 'if rdoMonths is selected, means string should contain 'Months'
            strMonthsOrYears = "Months"
        Else
            strMonthsOrYears = "Years" 'else string should contain 'Years'
        End If
        Try
            Dim decTimeAtCompletion As Decimal = txtOriginalTime.Text / (txtSchedulePerformanceIndex.Text.Replace("%", "") / 100) 'calculates from proper text fields
            txtTimeAtCompletion.Text = String.Format("{0:n} {1}", decTimeAtCompletion, strMonthsOrYears) 'populates text box with above result
        Catch ex As Exception
            txtTimeAtCompletion.Text = "SPI must be numeric" 'catches if SPI is non-numeric
        End Try
    End Sub

    Private Function validatePV() As Boolean
        '------------------------------------------------------------
        '-                Function Name: validatePV    -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                    -
        '-                Written On: Feb 21, 2023                   -
        '------------------------------------------------------------
        '- Function Purpose:                                      -
        '-                                                          -
        '- This function is called to see if PV is valid, and if it is-
        '- then it will also validate EV and calculate the performance index.-
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- (None)                                                   -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- strMessage - message to send to the arrlstMessages arraylist.-
        '------------------------------------------------------------
        '- Returns:                                                 -
        '- Boolean – if PV was validated                            -
        '------------------------------------------------------------

        If (IsNumeric(txtPresentValue.Text)) Then 'if the text value is numeric, then potentially SPI can be calculated
            If (txtPresentValue.Text = 0) Then 'if it's 0, SPI cannot be calculated, so put a message in that textbox
                txtSchedulePerformanceIndex.Text = "PV cannot be $0.00"
            Else
                If (validateEV()) Then 'validatesEV, and if it's valid, calculates performance index
                    calcSchedulePerformanceIndex()
                End If
            End If
            Return True
        Else
            Dim strMessage = "PV is non-numeric. Please enter a numeric value." 'if it's not numeric, will add error message to arraylist
            If (Not containsMessage(strMessage)) Then 'makes sure duplicate messages aren't added to the list
                arrlstMessages.Add(strMessage)
            End If
            txtScheduleVariance.Text = "Invalid data" 'block to set text values for fields that need PV to calculate them, but since it is non-numeric, they cannot be calculated
            txtSchedulePerformanceIndex.Text = "Invalid data"
            txtTimeAtCompletion.Text = "Invalid data"
            Return False
        End If
    End Function

    Private Function validateAC() As Boolean
        '------------------------------------------------------------
        '-                Function Name: validateAC    -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                    -
        '-                Written On: Feb 21, 2023                   -
        '------------------------------------------------------------
        '- Function Purpose:                                      -
        '-                                                          -
        '- This function is called to see if AV is valid, and if it is-
        '- then it will also validate EV and calculate the cost performance index.-
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- (None)                                                   -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- strMessage - message to send to the arrlstMessages arraylist.-
        '------------------------------------------------------------
        '- Returns:                                                 -
        '- Boolean – if AV was validated                            -
        '------------------------------------------------------------
        If (IsNumeric(txtActualCost.Text)) Then 'if the text value is numeric, then potentially CPI can be calculated
            If (txtActualCost.Text = 0) Then 'if AC is 0, CPI cannot be calculated, so show error message in that textbox
                txtCostPerformanceIndex.Text = "AC cannot be $0.00"
            Else
                If (validateEV()) Then 'if ev is also valid, we can calculate CPI
                    calcCostPerformanceIndex()
                End If
            End If
            Return True
        Else 'if AC is non-numeric, then add an error message to the arraylist
            Dim strMessage = "AC is non-numeric. Please enter a numeric value."
            If (Not containsMessage(strMessage)) Then 'makes sure no duplicates are stored
                arrlstMessages.Add(strMessage)
            End If
            txtCostVariance.Text = "Invalid data" 'block to display error messages
            txtCostPerformanceIndex.Text = "Invalid data"
            txtEstimateAtCompletion.Text = "Invalid data"
            Return False
        End If
    End Function

    Private Function validateEV() As Boolean
        '------------------------------------------------------------
        '-                Function Name: validateEV    -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                    -
        '-                Written On: Feb 21, 2023                   -
        '------------------------------------------------------------
        '- Function Purpose:                                      -
        '-                                                          -
        '- This function is called to see if EV is valid.           -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- (None)                                                   -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- strMessage - message to send to the arrlstMessages arraylist.-
        '------------------------------------------------------------
        '- Returns:                                                 -
        '- Boolean – if EV was validated                            -
        '------------------------------------------------------------
        If (IsNumeric(txtEarnedValue.Text)) Then 'if it's numeric, check if it's zero
            If (txtEarnedValue.Text = 0) Then 'if it's zero, CPI and SPI will be zero, so show that message in the textboxes
                txtEstimateAtCompletion.Text = "CPI cannot be 0%"
                txtTimeAtCompletion.Text = "SPI cannot be 0%"
            End If
            Return True
        Else 'if it's non-numeric, no other data can be generated, so store an error message in the arraylist
            Dim strMessage = "EV is non-numeric. Please enter a numeric value."
            If (Not containsMessage(strMessage)) Then
                arrlstMessages.Add(strMessage)
            End If
            txtCostVariance.Text = "Invalid data" 'since all calculations need EV value, all of the data will be invalid
            txtScheduleVariance.Text = "Invalid data"
            txtCostPerformanceIndex.Text = "Invalid data"
            txtSchedulePerformanceIndex.Text = "Invalid data"
            txtEstimateAtCompletion.Text = "Invalid data"
            txtTimeAtCompletion.Text = "Invalid data"
            Return False
        End If
    End Function

    Private Function validateBAC() As Boolean
        '------------------------------------------------------------
        '-                Function Name: validateBAC    -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                    -
        '-                Written On: Feb 21, 2023                   -
        '------------------------------------------------------------
        '- Function Purpose:                                      -
        '-                                                          -
        '- This function is called to see if BAC is valid.          -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- (None)                                                   -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- strMessage - message to send to the arrlstMessages arraylist.-
        '------------------------------------------------------------
        '- Returns:                                                 -
        '- Boolean – if BAC was validated                            -
        '------------------------------------------------------------
        If (IsNumeric(txtBalanceAtCompletion.Text)) Then 'check if the data in the textbox is numeric
            Return True
        Else
            Dim strMessage = "BAC is non-numeric. Please enter a numeric value." 'if it's not numeric, add the error message to the arraylist
            If (Not containsMessage(strMessage)) Then
                arrlstMessages.Add(strMessage)
            End If
            txtEstimateAtCompletion.Text = "Invalid data" 'show error
            Return False
        End If
    End Function

    Private Function validateOT() As Boolean
        '------------------------------------------------------------
        '-                Function Name: validateOT    -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                    -
        '-                Written On: Feb 21, 2023                   -
        '------------------------------------------------------------
        '- Function Purpose:                                      -
        '-                                                          -
        '- This function is called to see if OT is valid.           -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- (None)                                                   -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- strMessage - message to send to the arrlstMessages arraylist.-
        '------------------------------------------------------------
        '- Returns:                                                 -
        '- Boolean – if PV was validated                            -
        '------------------------------------------------------------
        If (IsNumeric(txtOriginalTime.Text)) Then 'check for numeric data
            If (txtOriginalTime.Text <= 0) Then 'time annot be 0 or negative
                Dim strMessage = "OT cannot be negative or zero! Please enter a positive numeric value."
                If (Not containsMessage(strMessage)) Then 'add error messge to arraylist
                    arrlstMessages.Add(strMessage)
                End If
                txtTimeAtCompletion.Text = "OT is invalid" 'show error
                Return False
            Else
                Return True
            End If
        Else 'otherwise, if the data is not numeric, add the message to the arraylist and show an error
            Dim strMessage = "OT is non-numeric. Please enter a numeric value."
            If (Not containsMessage(strMessage)) Then
                arrlstMessages.Add(strMessage)
            End If
            txtTimeAtCompletion.Text = "Invalid data"
            Return False
        End If
    End Function

    Private Function containsMessage(strMessage As String) As Boolean
        '------------------------------------------------------------
        '-                Function Name: validatePV    -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                    -
        '-                Written On: Feb 21, 2023                   -
        '------------------------------------------------------------
        '- Function Purpose:                                      -
        '-                                                          -
        '- This function is called to see if a string is already present-
        '- in the arraylist.                                        -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- strMessage - message to send to the arrlstMessages arraylist.-
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        '- Returns:                                                 -
        '- Boolean – if the message is already in the arraylist -
        '------------------------------------------------------------
        If (arrlstMessages.Contains(strMessage)) Then 'returns true if it's there, false if not
            Return True
        End If
        Return False
    End Function

    Private Sub setButtonColors()
        '------------------------------------------------------------
        '-                Subprogram Name: setButtonColors          -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                    -
        '-                Written On: Feb 21, 2023                   -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine is called to set the colors of the buttons-
        '– next to each field on the bottom half of the form.       -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- (None)                                                   -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- arrTemp - splits the value in the TAC textbox           -
        '------------------------------------------------------------
        If (IsNumeric(txtCostVariance.Text)) Then 'if it's numeric, checks conditions to determine which color the button should be
            Select Case CDec(txtCostVariance.Text)
                Case 0
                    btnCostVariance.BackColor = Color.Yellow
                Case < 0
                    btnCostVariance.BackColor = Color.Red
                Case > 0
                    btnCostVariance.BackColor = Color.Green
                Case Else
                    btnCostVariance.BackColor = Color.DarkGray
            End Select
        Else
            btnCostVariance.BackColor = Color.DarkGray 'if not numeric, set to default color
        End If

        If (IsNumeric(txtScheduleVariance.Text)) Then 'if it's numeric, checks conditions to determine which color the button should be
            Select Case CDec(txtScheduleVariance.Text)
                Case 0
                    btnScheduleVariance.BackColor = Color.Yellow
                Case < 0
                    btnScheduleVariance.BackColor = Color.Red
                Case > 0
                    btnScheduleVariance.BackColor = Color.Green
                Case Else
                    btnScheduleVariance.BackColor = Color.DarkGray
            End Select
        Else
            btnScheduleVariance.BackColor = Color.DarkGray 'if not numeric, set to default color
        End If

        If (IsNumeric(txtCostPerformanceIndex.Text.Replace("%", ""))) Then 'if it's numeric, checks conditions to determine which color the button should be
            Select Case CDbl(txtCostPerformanceIndex.Text.Replace("%", ""))
                Case 0
                    btnCostPerformanceIndex.BackColor = Color.Yellow
                Case > 100
                    btnCostPerformanceIndex.BackColor = Color.Green
                Case < 100
                    btnCostPerformanceIndex.BackColor = Color.Red
                Case Else
                    btnCostPerformanceIndex.BackColor = Color.DarkGray
            End Select
        Else
            btnCostPerformanceIndex.BackColor = Color.DarkGray 'if not numeric, set to default color
        End If

        If (IsNumeric(txtSchedulePerformanceIndex.Text.Replace("%", ""))) Then 'if it's numeric, checks conditions to determine which color the button should be
            Select Case CDbl(txtSchedulePerformanceIndex.Text.Replace("%", ""))
                Case 0
                    btnSchedulePerformanceIndex.BackColor = Color.Yellow
                Case > 100
                    btnSchedulePerformanceIndex.BackColor = Color.Green
                Case < 100
                    btnSchedulePerformanceIndex.BackColor = Color.Red
                Case Else
                    btnSchedulePerformanceIndex.BackColor = Color.DarkGray
            End Select
        Else
            btnSchedulePerformanceIndex.BackColor = Color.DarkGray 'if not numeric, set to default color
        End If

        If (IsNumeric(txtEstimateAtCompletion.Text)) Then 'if it's numeric, checks conditions to determine which color the button should be
            Select Case CDec(txtEstimateAtCompletion.Text)
                Case > txtBalanceAtCompletion.Text
                    btnEstimateAtCompletion.BackColor = Color.Red
                Case < txtBalanceAtCompletion.Text
                    btnEstimateAtCompletion.BackColor = Color.Green
                Case = txtBalanceAtCompletion.Text
                    btnEstimateAtCompletion.BackColor = Color.Yellow
                Case Else
                    btnEstimateAtCompletion.BackColor = Color.DarkGray
            End Select
        Else
            btnEstimateAtCompletion.BackColor = Color.DarkGray 'if not numeric, set to default color
        End If

        Try
            Dim arrTemp() = txtTimeAtCompletion.Text.Split(" ") 'split value in txtTimeAtCompletion to just get the numeric value (if there is one)
            If (IsNumeric(arrTemp(0))) Then 'if it's numeric, checks conditions to determine which color the button should be
                Select Case CDbl(arrTemp(0))
                    Case > txtOriginalTime.Text
                        btnTimeAtCompletion.BackColor = Color.Red
                    Case < txtOriginalTime.Text
                        btnTimeAtCompletion.BackColor = Color.Green
                    Case = txtOriginalTime.Text
                        btnTimeAtCompletion.BackColor = Color.Yellow
                    Case Else
                        btnTimeAtCompletion.BackColor = Color.DarkGray
                End Select
            Else
                btnTimeAtCompletion.BackColor = Color.DarkGray 'if not numeric, set to default color
            End If
        Catch ex As Exception
            btnTimeAtCompletion.BackColor = Color.DarkGray 'if the value in txtTimeAtCompletion could not be split, set to default color
        End Try


    End Sub

    Private Sub btnCalculateValues_Click(sender As Object, e As EventArgs) Handles btnCalculateValues.Click
        '------------------------------------------------------------
        '-                Subprogram Name: btnCalculateValues_Click -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                    -
        '-                Written On: Feb 21, 2023                   -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine is called whenever the user clicks the   -
        '- calcualte values button. The values entered will be evaluated–
        '- and calculations or errors will be shown.                -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- sender – Identifies which particular control raised the  –
        '-          click event                                     - 
        '- e – Holds the EventArgs object sent to the routine       -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- strTemp - holds messages from arraylist to display to messagebox-
        '------------------------------------------------------------
        arrlstMessages = New ArrayList 'initialize arrayList
        If (validateEV() And validateAC()) Then 'if EV and AC, then cost variance can be calculated
            calcCostVariance()
        End If
        If (validateEV() And validatePV()) Then 'if EV and PV, then schedule variance can be calculated
            calcScheduleVariance()
        End If
        If (validateBAC()) Then 'if BAC, then EAC can be calculated
            calcEstimateAtCompletion()
        End If
        If (validateOT()) Then 'if OT, then TAC can be calculated
            calcTimeAtCompletion()
        End If
        Dim strTemp As String = "" 'initializes string
        For Each message In arrlstMessages
            strTemp &= "*" & message & vbCrLf 'append each message to the string
        Next
        If (Not strTemp = "") Then 'if strTemp was populated with something, display the messagebox with it
            MessageBox.Show(strTemp)
        End If
        setButtonColors() 'sets the button colors
        arrlstMessages.Clear() 'clear the messages
    End Sub

    Private Sub frmEVMCalculator_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        '------------------------------------------------------------
        '-                Subprogram Name: frmEVMCalculator_FormClosing -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                    -
        '-                Written On: Feb 21, 2023                   -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine is called whenever the user clicks the   -
        '- to close the form or the parent attempts to close. Will check-
        '- if the user really wants to close unless each field contains '0'-
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- sender – Identifies which particular control raised the  –
        '-          click event                                     - 
        '- e – Holds the EventArgs object sent to the routine       -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- diag - holds the dialogresult from messageboxbuttons.yesno-
        '------------------------------------------------------------
        Focus() 'show the form attempting to close
        If (txtPresentValue.Text = "0" And txtActualCost.Text = "0" And txtEarnedValue.Text = "0" And txtBalanceAtCompletion.Text = "0" And txtOriginalTime.Text = "0") Then 'if '0' is in all fields, don't prompt if the user wants to close
            frmMain.intNumChildren -= 1 'subtract num of total children by 1
            Hide() 'hide the form
        Else
            Dim diag = MessageBox.Show("Are you sure you want to close " & Text & "?", "Close form confirmation", MessageBoxButtons.YesNo) 'shows a messagebox with a choice for the user to close or not
            If (diag = DialogResult.No) Then 'if the user clicks no, we cancel the closing event
                e.Cancel = True
            Else
                frmMain.intNumChildren -= 1 'if the user clicks yes, then we subtract num of total children by 1
                Hide() 'hide the form
            End If
        End If
    End Sub
End Class