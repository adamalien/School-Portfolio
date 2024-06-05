Imports System.IO

Public Class frmNew
    '------------------------------------------------------------
    '-                File Name : frmNew.vb                     - 
    '-                Part of Project: cis311hw1                -
    '------------------------------------------------------------
    '-                Written By: Adam Cossin                   -
    '-                Written On: January 17, 2023              -
    '------------------------------------------------------------
    '- File Purpose:                                            -
    '- This file contains the initial application form where    -
    '- the user will fill in the information for a machine to   -
    '- be inserted into an inventory system (in this case, it   -
    '- will be a file). All user input is gathered from this    -
    '- form. There are two different calculations which can be  -
    '- performed in this file, too.
    '------------------------------------------------------------
    '- Program Purpose:                                         -
    '- The purpose of this program is to have an inventory type -
    '- of system which allows a user to enter in information    -
    '- for an item and store it in some sort of database or     -
    '- file. The user is also able to check a box to toggle if  -
    '- numeric information present on the form shows in Gigs or -
    '- in bytes, though it will only be stored in Gigs. Then,   -
    '- the user will be able to save this entry which will in   -
    '- turn launch the secondary form to view the data entered. -
    '------------------------------------------------------------
    '- Global Variable Dictionary (alphabetically):             -
    '- arrlstItems – Used to read in the items from the file.   –
    '- strrReader - Used to read information in from the file.  –
    '- strrWriter - Used to write information to the file.      -
    '------------------------------------------------------------

    Public Property strPath As String = Application.StartupPath + "Inventory.txt" 'The path where the file is to be created/read from/wrote to
    Dim arrlstItems As ArrayList = New ArrayList()
    Dim strrReader
    Dim strwWriter

    Public Structure udtItemInfo
        Dim strManufacturer As String   'The name of the manufacturer of the item to be entered
        Dim strProcessor As String      'The name of the processor of the item to be entered
        Dim strVideo As String          'The name of the video card/manufacturer of the video card of the item to be entered
        Dim strForm As String           'The type of item to be entered (ie. Desktop, laptop, etc)
        Dim dblRam As Double            'The amount of RAM that the item has (in Gigs)
        Dim dblVram As Double           'The amount of VRAM that the item has (in Gigs)
        Dim dblHd As Double             'The capacity of the hard disk(s) present in the item (in Gigs)
        Dim blnWireless As Boolean      'Stores if the item has wireless capabilities or not
    End Structure

    Public Function convertGigsToBytes(ByVal dblGigValue As Double) As Double
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

    Private Sub openStream()
        '------------------------------------------------------------
        '-                Subprogram Name: openStream               -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: January 17, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine is called to open the StreamWriter to    -
        '- write to a file.
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- (None)
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        strwWriter = New StreamWriter(strPath, True) 'creates a new instance of StreamWriter to write to the file in 'strPath'. Also, 'True' is
        'passed because we want to append new information to the file, not overwrite it
    End Sub

    Private Sub closeStream()
        '------------------------------------------------------------
        '-                Subprogram Name: closeStream              -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: January 17, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine is called to close the StreamWriter that -
        '- write to a file.
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- (None)
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        strwWriter.close() 'closes the instance of the StreamWriter to write the previously given values to the file
    End Sub

    Private Sub createFile()
        '------------------------------------------------------------
        '-                Subprogram Name: createFile               -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: January 17, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine is called to create a file if it is not  -
        '- already present in the path given
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- (None)
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- fsWrite - A FileStream used to create a file to a path   -
        '------------------------------------------------------------
        Dim fsWrite As FileStream = File.Create(strPath) 'creates the file at the given path
        fsWrite.Close() 'close the FileStream, as it is not used again
        openStream() 'calls 'openStream' to write to the file
        writeToFile("Manufacturer Processor Video Form RAM VRAM HD Wireless") 'calls 'writeToFile' to write the passed information to the file
        closeStream() 'calls 'closeStream' to close the StreamWriter
    End Sub

    Private Sub writeToFile(strInfo As String)
        '------------------------------------------------------------
        '-                Subprogram Name: writeToFile              -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: January 17, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine is called to write the passed information-
        '- to the file.
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- strInfo - String that is passed in which will be written -
        '- to the file.
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- arrTemp - Temporary storage of each value on a given line-
        '- of the file.
        '- fmtStr - Formatter to format the string according to how -
        '- the columns should appear in the file.
        '------------------------------------------------------------
        Dim arrTemp() As String = strInfo.Split(" ")
        Dim fmtStr As String = "{0, -15}{1, 15}{2, 15}{3, 15}{4, 15}{5, 15}{6, 15}{7, 15}"
        strwWriter.WriteLine(String.Format(fmtStr, arrTemp(0), arrTemp(1), arrTemp(2), arrTemp(3), arrTemp(4), arrTemp(5), arrTemp(6), arrTemp(7)))
    End Sub

    Private Sub loadItems()
        '------------------------------------------------------------
        '-                Subprogram Name: loadItems                -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: January 17, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine is called to load the items from the file-
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- (None)
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)
        '------------------------------------------------------------
        arrlstItems = New ArrayList() 'initialize the global variable
        strrReader = New StreamReader(strPath, True) 'initialize the global variable
        strrReader.ReadLine() 'discard the first line of the file since it will always be the header line
        While (strrReader.EndOfStream = False) 'loop to go through each line of the file
            arrlstItems.Add(strrReader.ReadLine) 'adds the current line to 'arrlstItems'
        End While
        strrReader.Close() 'closes the StreamReader, as the file is done being read
    End Sub

    Private Sub initializeItem(udtItem As udtItemInfo)
        '------------------------------------------------------------
        '-                Subprogram Name: initializeItem           -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: January 17, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine is called to load default values into a  -
        '- passed structure of 'udtItemInfo' type. The reason for   -
        '- this is that if a user does not enter a value in one of  -
        '- the fields, then it will result in the default being     -
        '- used instead for item storage purposes.                  -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- udtItem - instance of udtItemInfo structure that is      -
        '- going to receive default values to store if/until they   -
        '- are changed.                                             -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        udtItem.strManufacturer = "Null"    'The default value given to the manufacturer
        udtItem.strProcessor = "Null"       'The default value given to the processor
        udtItem.strVideo = "Null"           'The default value given to the video card
        udtItem.strForm = "Null"            'The default value given to the item's type
        udtItem.blnWireless = False         'The default value of if the item has onboard wireless capabilites
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        '------------------------------------------------------------
        '-                Subprogram Name: btnSave_Click            -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: January 17, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine is called whenever the user clicks the   -
        '- save button. The information on all controls on the form –
        '- will be saved into an instance of the 'udtItemInfo'      -
        '- structure, which will then be written to the external    -
        '- file. The form itself will then be cleared, and disabled,-
        '- and the second form 'frmView' will be opened to show the -
        '- currently stored items from the file.
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- sender – Identifies which particular control raised the  –
        '-          click event                                     - 
        '- e – Holds the EventArgs object sent to the routine       -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- inventoryItem - instance of 'udtItemInfo' structure which-
        '- takes in the values entered from the user.               -
        '------------------------------------------------------------
        Dim inventoryItem As udtItemInfo = New udtItemInfo 'new instance of 'udtItemInfo' structure
        initializeItem(inventoryItem) 'calls 'initializeItem' to set default values for passed 'inventoryItem'
        inventoryItem.strManufacturer = txtManufacturer.Text 'if any info is entered by the user into the text field, this will be saved instead of the default value
        inventoryItem.strProcessor = txtProcessor.Text
        inventoryItem.strVideo = txtVideo.Text
        inventoryItem.strForm = txtForm.Text
        inventoryItem.blnWireless = chkWireless.Checked
        If (chkBytes.Checked = False) Then  'if bytes check box is not checked, it means the values in the relevant text fields are in the proper mode for storage, gigs
            inventoryItem.dblRam = txtRam.Text  'so, the values are directly stored
            inventoryItem.dblVram = txtVram.Text
            inventoryItem.dblHd = txtHd.Text
        Else 'if the bytes check box is checked, it means the values in the relevant text fields are not ready to be stored yet, and must first be converted to gigs
            inventoryItem.dblRam = convertBytesToGigs(txtRam.Text) 'calls 'convertBytesToGigs' on the relevant text field
            inventoryItem.dblVram = convertBytesToGigs(txtVram.Text)
            inventoryItem.dblHd = convertBytesToGigs(txtHd.Text)
        End If
        arrlstItems.Add(inventoryItem) 'adds the inventory item to 'arrlstItems'
        openStream() 'calls 'openStream' to open the StreamWriter to write to the file
        writeToFile(inventoryItem.strManufacturer & ", " & inventoryItem.strProcessor & ", " & inventoryItem.strVideo & ", " & inventoryItem.strForm & ", " & inventoryItem.dblRam.ToString & ", " & inventoryItem.dblVram.ToString & ", " & inventoryItem.dblHd.ToString & ", " & inventoryItem.blnWireless.ToString)
        'above parameters are passed to the called 'writeToFile' sub in order to write the relevant information to the file
        closeStream() 'calls 'closeStream' to close the StreamWriter to finalize the write to the file
        clearForm() 'calls 'clearForm' to set the form back to default values
        showView() 'calls 'showView' to load the other form, 'frmView' to show the inventory items so far
    End Sub

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
        If (chkBytes.Checked) Then 'if the checkbox for bytes is checked, then the numerical values stored in the relevant fields are converted from gigs to bytes
            txtRam.ReadOnly = True  'the 'ReadOnly' property is set to true on the textfields as the byte values should not be edited, only the gig values
            txtVram.ReadOnly = True
            txtHd.ReadOnly = True
            txtRam.Text = convertGigsToBytes(txtRam.Text)
            txtVram.Text = convertGigsToBytes(txtVram.Text)
            txtHd.Text = convertGigsToBytes(txtHd.Text)
            lblGb.Text = "Bytes" 'changes the text of 'GB' to 'Bytes' so that the user can see they are looking at a byte representation of these values
        End If

        If (chkBytes.Checked = False) Then 'if the checkbox for byes is unchecked, then the numerical values stored in the relevant fields are converted from bytes to gigs
            txtRam.ReadOnly = False 'the 'ReadOnly' property is set to false on the textfields because the gig values can be edited by the user
            txtVram.ReadOnly = False
            txtHd.ReadOnly = False
            txtRam.Text = convertBytesToGigs(txtRam.Text)
            txtVram.Text = convertBytesToGigs(txtVram.Text)
            txtHd.Text = convertBytesToGigs(txtHd.Text)
            lblGb.Text = "GB" 'changes the text back to 'GB' so that the user can see they are looking at the Gig representation of these values
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        '------------------------------------------------------------
        '-                Subprogram Name: btnCancel_Click          -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: January 17, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine is called whenever the user clicks the   -
        '- cancel button. The information on all controls on the    -
        '- form will be set back to their default values.           -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- sender – Identifies which particular control raised the  –
        '-          click event                                     - 
        '- e – Holds the EventArgs object sent to the routine       -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        clearForm() 'calls 'clearForm' to set the form back to default values
    End Sub

    Private Sub showView()
        '------------------------------------------------------------
        '-                Subprogram Name: showView                 -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: January 17, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine is called to show the second form,       -
        '- 'frmView' and disable 'frmNew' so that a user cannot     -
        '- enter new items while looking at current inventory.      -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- (None)                                                   -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        frmView.Show() 'opens 'frmView' so that the user can interact with it
        frmView.TopMost = True 'sets 'frmView' to be the form 'on top', meaning that it is in focus
        Me.Enabled = False 'disables 'frmNew' because the user should not be able to enter a new item while looking at the current inventory
    End Sub

    Private Sub clearForm()
        '------------------------------------------------------------
        '-                Subprogram Name: clearForm                -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: January 17, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine is called to set all values in the form  -
        '- back to the default so that a user can start to enter    -
        '- a new item.
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- (None)                                                   -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        txtManufacturer.Text = ""
        txtProcessor.Text = ""
        txtVideo.Text = ""
        txtForm.Text = ""
        txtRam.Text = 0
        txtVram.Text = 0
        txtHd.Text = 0
        chkWireless.Checked = False
        chkBytes.Checked = False
    End Sub

    Private Sub frmNew_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '------------------------------------------------------------
        '-                Subprogram Name: frmNew_Load              -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: January 17, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine is called immediately when the form is   -
        '- loaded. When it is loaded, there is a check done to see  -
        '- if the file currently exists, if it doesn't, then it is  -
        '- created. If it does, then 'loaditems' is called to load  -
        '- the items in from the file, and 'showView' is called to  -
        '- show 'frmView' and let the user see the current inventory-
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- (None)                                                   -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        If File.Exists(strPath) Then 'if the file already exists, then items are loaded and 'frmView' is shown immediately
            loadItems()
            showView()
        Else 'if the file doesn't exist, then it s created
            createFile()
        End If
    End Sub
End Class
