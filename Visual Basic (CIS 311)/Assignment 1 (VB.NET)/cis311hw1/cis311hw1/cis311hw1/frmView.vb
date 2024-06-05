Imports System.IO

Public Class frmView
    '------------------------------------------------------------
    '-                File Name : frmView.vb                    - 
    '-                Part of Project: cis311hw1                -
    '------------------------------------------------------------
    '-                Written By: Adam Cossin                   -
    '-                Written On: January 17, 2023              -
    '------------------------------------------------------------
    '- File Purpose:                                            -
    '- This file contains the application form where the user   -
    '- is able to see the current inventory.                    -
    '------------------------------------------------------------
    '- Global Variable Dictionary (alphabetically):             -
    '- arrlstItems – Stores the items read in from the file.    –
    '- blnBytes – Value for if 'chkBytes' is checked or not.    –
    '- intCounter - Keeps track of the item number in the       -
    '-              arrayList.
    '- strPath - String representation of the file path.        -
    '- strTitle - Common substring used between all pages of the-
    '- inventory items.                                         -
    '------------------------------------------------------------
    Dim strPath As String
    Dim arrlstItems As ArrayList
    Dim intCounter As Integer = 0
    Dim blnBytes As Boolean = False
    Dim strTitle As String = "IT Inventory Tracker - Item"
    Private Sub loadItemsFromFile()
        '------------------------------------------------------------
        '-                Subprogram Name: loadItemsFromFile        -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: January 17, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine is called to read in the data from the   -
        '- file and populate 'arrlstItems'.                         -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- (None)                                                   -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- strrReader - Used to read in information from the file   -
        '------------------------------------------------------------
        arrlstItems = New ArrayList() 'initialize the global variable
        Dim strrReader = New StreamReader(strPath, True) 'create an instance of StreamReader to read in the file from the given path
        strrReader.ReadLine() 'discards the first line since that only contains the headers
        While (strrReader.EndOfStream = False) 'loop to read in all lines of the file until the end
            arrlstItems.Add(strrReader.ReadLine) 'adds each line from the file into 'arrlstItems'
        End While
        strrReader.Close() 'closes the StreamReader since the file has been completely read in
    End Sub

    Private Sub loadItemToForm(intNum As Integer)
        '------------------------------------------------------------
        '-                Subprogram Name: loadItemToForm           -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: January 17, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine is called to process an individual item  -
        '- from the 'arrlstItems' arrayList.
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- intNum - integer to determine which item in 'arrlstItems'-
        '-          will need to be processed.                      -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        populateInfo(arrlstItems(intNum), blnBytes) 'calls 'populateInfo' to populate the info from the given item in the arrayList to the form (and passes if the 'bytes' check box should be checked)
    End Sub

    Private Sub populateInfo(strItem As String, blnTemp As Boolean)
        '------------------------------------------------------------
        '-                Subprogram Name: populateInfo             -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: January 17, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine is called to load in an individual item  -
        '- to the form. This means that the corresponding values    -
        '- from the item are loaded onto the form.                  -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- strItem - determines the data to be loaded to the form.  -
        '- blnTemp - determines how to display numerical data on the-
        '-           form.                                          -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- arrComponents - splits the passed string into an array of-
        '- strings, which separates the data to be displayed on the -
        '- form by its' textfield.                                  -
        '------------------------------------------------------------
        Dim arrComponents = strItem.Split(",")
        txtManufacturer.Text = arrComponents(0).ToString.Trim   'the first value will be the manufacturer value, so this is loaded to this part of the form
        txtProcessor.Text = arrComponents(1).ToString.Trim      'the second value will be the processor value, so this is loaded to this part of the form
        txtVideo.Text = arrComponents(2).ToString.Trim          'the third value will be the video card value, so this is loaded to this part of the form
        txtForm.Text = arrComponents(3).ToString.Trim           'the fourth value will be the form value, so this is loaded to this part of the form
        txtRam.Text = arrComponents(4).ToString.Trim            'the fifth value will be the RAM value, so this is loaded to this part of the form
        txtVram.Text = arrComponents(5).ToString.Trim           'the sixth value will be the VRAM value, so this will be loaded to this part of the form
        txtHd.Text = arrComponents(6).ToString.Trim             'the seventh value will be the HD value, so this will be loaded to this part of the form
        If (arrComponents(7).ToString.Trim.Equals("True")) Then 'checks if the eighth value is 'true'
            chkWireless.Checked = True                          'if it is true, this means that 'wireless' should be checked
        Else
            chkWireless.Checked = False                         'if it is not true, this means that 'wireless' should not be checked
        End If
        If (blnBytes) Then                                      'checks if 'blnBytes' is true or false, meaning if the value of 'chkBytes' from the previous page is checked or not
            txtRam.Text = convertGigsToBytes(txtRam.Text)       'if it is checked, then the numerical values will continue to show in bytes, so this value will be carried from page to page
            txtVram.Text = convertGigsToBytes(txtVram.Text)
            txtHd.Text = convertGigsToBytes(txtHd.Text)
        End If
    End Sub

    Private Sub frmView_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '------------------------------------------------------------
        '-                Subprogram Name: frmView_Load             -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: January 17, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is called immediately when the form is   -
        '- loaded. When it is loaded, 'loadItemsFromFile' is called -
        '- to load load in the items from the file to the arrayList.-
        '- Then, the first item in the arrayList is loaded to the   -
        '- form, and the text at the top of the form is displayed   -
        '- to show that the first item is loaded.                   -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- sender – Identifies which particular control raised the  –
        '-          click event                                     - 
        '- e – Holds the EventArgs object sent to the routine       -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- objNew - creates an instance of 'frmNew' to get the file -
        '- path, and determines what the value of 'chkBytes' should -
        '- be.                                                      -
        '------------------------------------------------------------
        Dim objNew As New frmNew
        strPath = frmNew.strPath 'gets the path for the file created by 'frmNew'
        blnBytes = frmNew.chkBytes.Checked 'sets the boolean value of 'blnBytes' based on if the value of 'chkBytes' on 'frmNew' was checked or not, if it was it will maintain this value
        chkBytes.Checked = blnBytes 'sets the check value of 'chkBytes' to that of 'blnBytes' so that the checked property is maintained between forms
        loadItemsFromFile() 'calls 'loadItemsFromFile' to load the items from the file into the global arrayList
        loadItemToForm(0) 'calls 'loadItemToForm' to load the first item to the form
        Me.Text = strTitle + " 1/" + arrlstItems.Count.ToString 'sets the top text to 1/? with '?' being the count of items in the file
    End Sub

    Private Sub btnPrev_Click(sender As Object, e As EventArgs) Handles btnPrev.Click
        '------------------------------------------------------------
        '-                Subprogram Name: btnPrev_Click            -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: January 17, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is called when the '<<' button is clicked-
        '- and determines if the click is valid or not. This means  -
        '- that either the user is able to go back a page to see the-
        '- previously entered item, or they cannot go back because  -
        '- they are already at the first item.                      -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- sender – Identifies which particular control raised the  –
        '-          click event                                     - 
        '- e – Holds the EventArgs object sent to the routine       -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- intTemp - holds the value of the page number based on    -
        '- the value of intCounter (which will be the number in the -
        '- arrayList) + 1, which will be the correct numerical value-
        '- when starting the count from 1.                          -
        '------------------------------------------------------------
        If (intCounter = 0) Then 'if the first record is already showing, meaning arrlstItems(0), then a message is shown
            MessageBox.Show("You cannot move past the first record")
        Else 'otherwise, the counter is decremented, and so the previous item is loaded by calling 'loadItemToForm' and passing this new value
            intCounter = intCounter - 1
            loadItemToForm(intCounter)
            Dim intTemp = intCounter + 1 'intTemp is set to the updated intCounter value plus 1, meaning the actual representation of the number if 1 = the first item instead of 0 = the first item
            Me.Text = strTitle + " " + intTemp.ToString + "/" + arrlstItems.Count.ToString 'form title is updated to display appropriate page number(s)
        End If
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        '------------------------------------------------------------
        '-                Subprogram Name: btnNext_Click            -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: January 17, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is called when the '>>' button is clicked-
        '- and determines if the click is valid or not. This means  -
        '- that either the user is able to go forward a page to see -
        '- next item, or they cannot go forward because they are    -
        '- already at the last item.                                -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- sender – Identifies which particular control raised the  –
        '-          click event                                     - 
        '- e – Holds the EventArgs object sent to the routine       -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- intTemp - holds the value of the page number based on    -
        '- the value of intCounter (which will be the number in the -
        '- arrayList) + 1, which will be the correct numerical value-
        '- when starting the count from 1.                          -
        '------------------------------------------------------------
        If (intCounter = arrlstItems.Count - 1) Then 'if the user is already on the last entry, a message is shown
            MessageBox.Show("You cannot move past the last record")
        ElseIf (intCounter < arrlstItems.Count) Then
            intCounter = intCounter + 1 'otherwise, the counter is incremented
            loadItemToForm(intCounter)  'loadItemToForm is called with the passed value of 'intCounter'
            Dim intTemp = intCounter + 1 'intTemp is calculated by adding 1 to 'intCounter'
            Me.Text = strTitle + " " + intTemp.ToString + "/" + arrlstItems.Count.ToString 'form title is updated to display appropriate page number(s)
        End If
    End Sub
    Function convertGigsToBytes(ByVal dblGigValue As Double) As Double
        '------------------------------------------------------------
        '-                Subprogram Name: convertGigsToBytes       -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: January 17, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine is called whenever the user checks the   –
        '- checkbox for 'bytes', as it will convert all numeric     -
        '- values on the form from the default Gigs to Bytes.       -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- dblGigValue - holds the initial value in Gigabytes that  -
        '- is to be converted to Bytes.                             -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        '- Returns:                                                 -
        '- Double – gives the number of Bytes in the passed number  -
        '- of Gigs                                                  -
        '------------------------------------------------------------
        Return dblGigValue * 1073741824 'returns the number of bytes in a given gig value
    End Function

    Function convertBytesToGigs(ByVal dblByteValue As Double) As Double
        '------------------------------------------------------------
        '-                Subprogram Name: convertBytesToGigs       -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: January 17, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine is called whenever the user unchecks the –
        '- checkbox for 'bytes', as it will convert all numeric     -
        '- values on the form from Bytes back to Gigs.              -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- dblByteValue - holds the initial value in bytes that is  -
        '- to be converted to gigs.                                 -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        '- Returns:                                                 -
        '- Double – gives the number of Gigs in the passed number   -
        '- of Bytes                                                 -
        '------------------------------------------------------------
        Return dblByteValue / 1073741824 'returns the number of gigs in a given byte value
    End Function

    Private Sub chkBytes_CheckedChanged(sender As Object, e As EventArgs) Handles chkBytes.CheckedChanged
        '------------------------------------------------------------
        '-                Subprogram Name: chkBytes_CheckedChanged  -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: January 17, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine is called whenever the user checks or    -
        '- unchecks the 'chkBytes' checkbox. This determines how the-
        '- numerical values will be shown on the form to the user,  -
        '- as it will show either a gig or byte representation      -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- sender – Identifies which particular control raised the  –
        '-          click event                                     - 
        '- e – Holds the EventArgs object sent to the routine       -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        If (chkBytes.Checked) Then
            blnBytes = True
            txtRam.Text = convertGigsToBytes(txtRam.Text)
            txtVram.Text = convertGigsToBytes(txtVram.Text)
            txtHd.Text = convertGigsToBytes(txtHd.Text)
            lblGb.Text = "Bytes"
        End If

        If (chkBytes.Checked = False) Then
            blnBytes = False
            txtRam.Text = convertBytesToGigs(txtRam.Text)
            txtVram.Text = convertBytesToGigs(txtVram.Text)
            txtHd.Text = convertBytesToGigs(txtHd.Text)
            lblGb.Text = "GB"
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        '------------------------------------------------------------
        '-                Subprogram Name: btnAdd_Click             -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: January 17, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine is called whenever the user clicks the   -
        '- 'Add New Inventory Item' button. This will close         -
        '- 'frmView' and re-enable 'frmNew' so that the user can    -
        '- enter a new item.
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- sender – Identifies which particular control raised the  –
        '-          click event                                     - 
        '- e – Holds the EventArgs object sent to the routine       -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        frmNew.Enabled = True 're-enables 'frmNew' so that the user can interact with it again
        Me.Close() 'closes the current ('frmView') window
    End Sub
End Class