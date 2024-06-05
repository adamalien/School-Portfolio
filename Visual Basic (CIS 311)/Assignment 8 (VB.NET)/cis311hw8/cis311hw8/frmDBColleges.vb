'NOTE: Database is created when application is run
Imports System.ComponentModel
Imports System.Data.SqlClient

Public Class frmDBColleges
    '------------------------------------------------------------
    '-                File Name : frmDBColleges                 - 
    '-                Part of Project: cis311hw8                -
    '------------------------------------------------------------
    '-                Written By: Adam Cossin                   -
    '-                Written On: March 25th 2023               -
    '------------------------------------------------------------
    '- File Purpose:                                            -
    '- This file contains the main application form where the   -
    '- user will be able to browse colleges and degrees that they-
    '- offer. The user will also be able to add new colleges or -
    '- delete colleges (along with the degrees at that college).-
    '------------------------------------------------------------
    '- Program Purpose:                                         -
    '- This program utilizes a database to persist information  -
    '- about colleges and the degrees they offer. Colleges are  -
    '- able to be added or deleted to/from the database.        -
    '------------------------------------------------------------
    '- Global Variable Dictionary (alphabetically):             -
    '- blnUpdate - determines if 'save' was clicked for 'update'-
    '-             or for 'add'.                                -
    '- DBAdaptColleges - data adapter to communicate with       -
    '-                  colleges table.                         -
    '- DBAdaptDegrees - data adapter to communicate with degrees-
    '-                  table.                                  -
    '- dsColleges - data set containing info from colleges table-
    '- dsDegrees - data set containing info from degrees table. -
    '- myConn - SqlConnection object to connect to the database.-
    '- strConnection - connection string to the database.       -
    '- strDBPath - path to the database on the system.          -
    '------------------------------------------------------------
    Dim dsColleges As New DataSet 'dataset for holding colleges
    Dim dsDegrees As New DataSet 'dataset for holding degrees

    Const strDBNAME As String = "CollegeInfo" 'database name
    Const strSERVERNAME As String = "(localdb)\MSSQLLocalDB" 'server name
    Dim strDBPath As String = My.Application.Info.DirectoryPath & "\" & strDBNAME & ".mdf" 'path to local database

    Dim strConnection As String = "SERVER=" & strSERVERNAME & ";DATABASE=" & strDBNAME & ";Integrated Security=SSPI;AttachDbFileName=" & strDBPath 'connection string

    Dim myConn As New SqlConnection(strConnection) 'connection to connect to the database

    Dim DBAdaptColleges As SqlDataAdapter 'data adapter for colleges
    Dim DBAdaptDegrees As SqlDataAdapter 'data adapter for degrees

    Dim blnUpdate As Boolean = False 'boolean to see if 'update' or 'add' was chosen - initially set to false

    Private Sub frmDBColleges_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '------------------------------------------------------------
        '-                Subprogram Name: frmDBCollegs_Load        -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: March 25th 2023               -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is called when the form initially loads. -
        '- Colleges table is loaded from the database and bindings  -
        '- are set so that the information from the table corresponds-
        '- correctly to the text fields on the form. Additionally,  -
        '- the degrees are retrieved for the college that is first  -
        '- displayed.                                               -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- sender – Identifies which particular control raised the  –
        '-          click event                                     - 
        '- e – Holds the EventArgs object sent to the routine       -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- strSQLCmd - holds the command to be run on the database. -
        '------------------------------------------------------------
        Dim strSQLCmd = "Select * From Colleges" 'command to get all colleges from the colleges table on the database
        DBAdaptColleges = New SqlDataAdapter(strSQLCmd, strConnection)
        DBAdaptColleges.Fill(dsColleges, "Colleges") 'populate the data adapter with the result of the above command

        txtName.DataBindings.Add(New Binding("Text", dsColleges, "Colleges.CollegeName")) 'binding block to bind column info from the college table to text fields on the form
        txtIDNumber.DataBindings.Add(New Binding("Text", dsColleges, "Colleges.ID"))
        txtStreet.DataBindings.Add(New Binding("Text", dsColleges, "Colleges.Address"))
        txtCity.DataBindings.Add(New Binding("Text", dsColleges, "Colleges.City"))
        txtState.DataBindings.Add(New Binding("Text", dsColleges, "Colleges.State"))
        txtZipCode.DataBindings.Add(New Binding("Text", dsColleges, "Colleges.ZipCode"))
        getDegrees() 'calls get degrees to show the degrees for the current college
    End Sub

    Private Sub btnFirst_Click(sender As Object, e As EventArgs) Handles btnFirst.Click
        '------------------------------------------------------------
        '-                Subprogram Name: btnFirst_Click           -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: March 25th 2023               -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is called when the leftmost button is    -
        '- clicked. It is used to display the first college from the-
        '- database.                                                -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- sender – Identifies which particular control raised the  –
        '-          click event                                     - 
        '- e – Holds the EventArgs object sent to the routine       -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        BindingContext(dsColleges, "Colleges").Position = 0
        getDegrees()
    End Sub

    Private Sub btnPrevious_Click(sender As Object, e As EventArgs) Handles btnPrevious.Click
        '------------------------------------------------------------
        '-                Subprogram Name: btnPrevious_Click        -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: March 25th 2023               -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is called when the '<<' (previous) button-
        '- is clicked. It is used to display the previous college from-
        '- the database.                                            -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- sender – Identifies which particular control raised the  –
        '-          click event                                     - 
        '- e – Holds the EventArgs object sent to the routine       -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        BindingContext(dsColleges, "Colleges").Position = (BindingContext(dsColleges, "Colleges").Position - 1)
        getDegrees()
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        '------------------------------------------------------------
        '-                Subprogram Name: btnNext_Click            -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: March 25th 2023               -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is called when the '>>' (next) button is -
        '- clicked. It is used to display the next college from the -
        '- database.                                                -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- sender – Identifies which particular control raised the  –
        '-          click event                                     - 
        '- e – Holds the EventArgs object sent to the routine       -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        BindingContext(dsColleges, "Colleges").Position = (BindingContext(dsColleges, "Colleges").Position + 1)
        getDegrees()
    End Sub

    Private Sub btnLast_Click(sender As Object, e As EventArgs) Handles btnLast.Click
        '------------------------------------------------------------
        '-                Subprogram Name: btnLast_Click            -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: March 25th 2023               -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is called when the rightmost button is   -
        '- clicked. It is used to display the last college from the -
        '- database.                                                -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- sender – Identifies which particular control raised the  –
        '-          click event                                     - 
        '- e – Holds the EventArgs object sent to the routine       -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        BindingContext(dsColleges, "Colleges").Position = (dsColleges.Tables("Colleges").Rows.Count - 1)
        getDegrees()
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        '------------------------------------------------------------
        '-                Subprogram Name: btnUpdate_Click          -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: March 25th 2023               -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is called when the 'update' button is    -
        '- clicked. It is used to update the current college's info.-
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- sender – Identifies which particular control raised the  –
        '-          click event                                     - 
        '- e – Holds the EventArgs object sent to the routine       -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        pnlNavigation.Visible = False 'hide the navigation panel
        blnUpdate = True 'since it is an update, we set blnUpdate to true indicating that an update is being made
        readOnlyOff() 'turns off 'read only' on text boxes so data can be entered
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        '------------------------------------------------------------
        '-                Subprogram Name: btnSave_Click            -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: March 25th 2023               -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is called when the 'save' button is clicked-
        '- It is used to save the currently entered info.           -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- sender – Identifies which particular control raised the  –
        '-          click event                                     - 
        '- e – Holds the EventArgs object sent to the routine       -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- intCurrentRecord - stores the value of the current record-
        '-                   so that when the operation is done, the-
        '-                   correct college is displayed.          -
        '- sqlCommand - SqlCommand object to run the given command on-
        '-              the database.                               -
        '- strSQLCmd - holds the sql command to be run.             -
        '------------------------------------------------------------
        Dim intCurrentRecord
        BindingContext(dsColleges, "Colleges").EndCurrentEdit() 'ends the current edit
        Dim strSQLCmd As String
        If (blnUpdate) Then 'if save was clicked after 'update', then the SQLCmd is set to the below string
            strSQLCmd = "UPDATE Colleges SET CollegeName = '" & txtName.Text & "', Address = '" & txtStreet.Text & "', City = '" &
                        txtCity.Text & "', State = '" & txtState.Text & "', ZipCode = '" & txtZipCode.Text & "' WHERE ID = '" &
                        txtIDNumber.Text & "'"
            intCurrentRecord = getCurrentRecord() 'stays on the current record after the update is complete
        Else 'otherwise, save was clicked after 'add', so the SQLCmd is set to the below string
            strSQLCmd = "INSERT Into Colleges VALUES ('" & txtName.Text & "', '" &
                        txtStreet.Text & "', '" & txtCity.Text & "', '" & txtState.Text & "', '" & txtZipCode.Text & "');"
            intCurrentRecord = dsColleges.Tables("Colleges").Compute("MAX(ID)", "") + 1 'goes to the last record (which will be the one just added) after insert is complete
            txtIDNumber.Visible = True
            lblIDNumber.Visible = True
        End If

        Dim sqlCommand As New SqlCommand(strSQLCmd, myConn)
        Try
            myConn.Open()
            sqlCommand.ExecuteNonQuery() 'executes the command provided in 'strSQLCmd'
            myConn.Close()
            refreshColleges() 'calls to refresh the list of colleges (to display the updated or newly added college)
        Catch ex As Exception
            MessageBox.Show("Error adding college to database!")
        End Try
        BindingContext(dsColleges, "Colleges").Position = intCurrentRecord 'sets the position to be on the updated college or the newly added college depending on above
        getDegrees() 'get degrees for the current college
        readOnlyOn() 'set text fields back to read only
        pnlNavigation.Visible = True 'navigation panel reappears
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        '------------------------------------------------------------
        '-                Subprogram Name: btnCancel_Click          -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: March 25th 2023               -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is called when the 'cancel' button is    -
        '- clicked. It is used to cancel out the add/update attempt -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- sender – Identifies which particular control raised the  –
        '-          click event                                     - 
        '- e – Holds the EventArgs object sent to the routine       -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        pnlNavigation.Visible = True 'navigation panel reappears
        BindingContext(dsColleges, "Colleges").CancelCurrentEdit() 'cancel the current edit
        txtIDNumber.Visible = True
        lblIDNumber.Visible = True
        getDegrees() 'get the degrees for the current college
        readOnlyOn() 'sets the text fields to read only
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        '------------------------------------------------------------
        '-                Subprogram Name: btnAdd_Click             -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: March 25th 2023               -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is called when the 'add' button is clicked-
        '- It is used to let the user enter info for a new college. -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- sender – Identifies which particular control raised the  –
        '-          click event                                     - 
        '- e – Holds the EventArgs object sent to the routine       -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        pnlNavigation.Visible = False 'hide navigation panel
        blnUpdate = False 'since 'add' was clicked, that means that the potential 'save' would be for 'insert', not 'update', so set blnUpdate to false
        txtIDNumber.Text = "" 'clear out ID number - since this will be generated when the record is added to the database
        txtIDNumber.Visible = False 'hide ID number text field - since the user will not be able to enter this anyway
        lblIDNumber.Visible = False 'hide the label

        txtName.Clear() 'block to clear out the text boxes
        txtStreet.Clear()
        txtCity.Clear()
        txtState.Clear()
        txtZipCode.Clear()

        getDegrees() 'gets the degrees for the current college, but since it doesn't exist, the 'degrees' datagridview will be empty
        readOnlyOff() 'sets the read only property on the text fields to off
    End Sub

    Private Sub getDegrees()
        '------------------------------------------------------------
        '-                Subprogram Name: getDegrees               -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: March 25th 2023               -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is called to get the degrees for the     -
        '- current college and display them in the data grid view.  -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- (None)                                                   -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- strSQLCmd - the command to be run on the database.       -
        '------------------------------------------------------------
        Dim strSQLCmd = "Select * From Degrees Where CollegeTUID ='" & Trim(txtIDNumber.Text) & "'" 'selects the degrees for the currently selected college
        DBAdaptDegrees = New SqlDataAdapter(strSQLCmd, strConnection)
        dsDegrees.Clear() 'clears the degrees dataset
        DBAdaptDegrees.Fill(dsDegrees, "Degrees") 'fills the data adapter with records from the above select statement
        dgvDegreesForCollege.DataSource = dsDegrees.Tables("Degrees") 'sets the datasource for the data grid view to that of the result of the above select statement
    End Sub

    Private Sub readOnlyOn()
        '------------------------------------------------------------
        '-                Subprogram Name: readOnlyOn               -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: March 25th 2023               -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is called to set the read only property  -
        '- of the text fields to 'on' and to hide the 'save' and    -
        '- 'cancel' buttons.                                        -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- (None)                                                   -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        txtName.ReadOnly = True
        txtStreet.ReadOnly = True
        txtCity.ReadOnly = True
        txtState.ReadOnly = True
        txtZipCode.ReadOnly = True
        btnSave.Visible = False
        btnCancel.Visible = False
    End Sub

    Private Sub readOnlyOff()
        '------------------------------------------------------------
        '-                Subprogram Name: readOnlyOff              -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: March 25th 2023               -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is called to set the read only property  -
        '- of the text fields to 'off' and to show the 'save' and   -
        '- 'cancel' buttons.                                        -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- (None)                                                   -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        txtName.ReadOnly = False
        txtStreet.ReadOnly = False
        txtCity.ReadOnly = False
        txtState.ReadOnly = False
        txtZipCode.ReadOnly = False
        btnSave.Visible = True
        btnCancel.Visible = True
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        '------------------------------------------------------------
        '-                Subprogram Name: btnDelete_Click          -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: March 25th 2023               -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is called when the 'delete' button is clicked-
        '- It is used to delete the current college record.         -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- sender – Identifies which particular control raised the  –
        '-          click event                                     - 
        '- e – Holds the EventArgs object sent to the routine       -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- sqlCommand - SqlCommand object to run the given command on-
        '-              the database.                               -
        '- strSQLCmd - holds the sql command to be run.             -
        '------------------------------------------------------------
        If (MessageBox.Show("Are you sure you want to delete this college?", "", MessageBoxButtons.YesNo) = DialogResult.Yes) Then 'if the user selects that they do really want to delete the record, continue
            Dim strSQLCmd = "DELETE FROM Degrees WHERE CollegeTUID ='" & txtIDNumber.Text & "'" 'SQL query to delete the degrees associated with the current college
            Dim sqlCommand As SqlCommand = New SqlCommand(strSQLCmd, myConn)
            Try
                myConn.Open()
                sqlCommand.ExecuteNonQuery() 'execute the above query
                myConn.Close()

                strSQLCmd = "DELETE FROM Colleges WHERE ID ='" & txtIDNumber.Text & "'" 'SQL query to delete the currently selected college
                sqlCommand = New SqlCommand(strSQLCmd, myConn)
                Try
                    myConn.Open()
                    sqlCommand.ExecuteNonQuery() 'execute the above query
                    myConn.Close()
                Catch ex As Exception
                    MessageBox.Show("Error - Could not delete college!")
                End Try

            Catch ex As Exception
                MessageBox.Show("Error - Could not delete record(s)!")
            End Try
            refreshColleges() 're-aquire the colleges from the database
            getDegrees() 'get degrees for the currently selected college (after the deletion)
        End If
    End Sub

    Private Sub refreshColleges()
        '------------------------------------------------------------
        '-                Subprogram Name: refreshColleges          -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: March 25th 2023               -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is called to reaquire the list of colleges-
        '- from the database.                                       -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- (None)                                                   -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- strSQLCmd - command to be run on the databse.            -
        '------------------------------------------------------------
        Dim strSQLCmd As String = "SELECT * FROM Colleges" 'SQL command to get all of the colleges from the database
        DBAdaptColleges = New SqlDataAdapter(strSQLCmd, strConnection)
        dsColleges.Clear() 'clear out the colleges dataset
        DBAdaptColleges.Fill(dsColleges, "Colleges") 'fill the adapter with the result from the above query
    End Sub

    Private Function getCurrentRecord() As Integer
        '------------------------------------------------------------
        '-                Function Name: getCurrentRecord           -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: March 25th 2023               -
        '------------------------------------------------------------
        '- Function Purpose:                                        -
        '- This subroutine is called to get the position of the     -
        '- current record.                                          -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- (None)                                                   -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        '- Returns:                                                 -
        '- Integer – telling the current record's position          -
        '------------------------------------------------------------
        Return BindingContext(dsColleges, "Colleges").Position
    End Function

    Private Sub frmDBColleges_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        '------------------------------------------------------------
        '-                Subprogram Name: frmDBColleges_Closing    -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: March 25th 2023               -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is called when the form is closed. It    -
        '- prompts the user if they would like to delete the database-
        '- or not.                                                  -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- sender – Identifies which particular control raised the  –
        '-          click event                                     - 
        '- e – Holds the EventArgs object sent to the routine       -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        If MessageBox.Show("Do you want to physically delete the database?", "Database Deletion", MessageBoxButtons.YesNo) = DialogResult.Yes Then 'if user selects that they want to delete, deletes the database
            DeleteDatabase(strSERVERNAME, strDBNAME)
        End If
    End Sub
End Class
