'NOTE: Database is created when application is run
Imports System.Data.SqlClient
Module moduleForCollegesApp
    '------------------------------------------------------------
    '-                File Name : moduleForCollegesApp.vb       - 
    '-                Part of Project: cis311hw8                -
    '------------------------------------------------------------
    '-                Written By: Adam Cossin                   -
    '-                Written On: March 25th 2023               -
    '------------------------------------------------------------
    '- File Purpose:                                            -
    '- This file contains the startup routine for the main app  -
    '- and also contains the setup for the Colleges and Degrees -
    '- databases.                                               -
    '------------------------------------------------------------

    Sub Main()
        '------------------------------------------------------------
        '-                Subprogram Name: Main                     -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: March 25th 2023               -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is called when the program is initially  -
        '- launched. Sets up the connection strings for connecting  -
        '- to the database and creates/fills the database if it is  -
        '- not already on the system.                               -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- (None)                                                   -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- strConnection - the connection string for the database   -
        '- strDBPath - the path for the database to be created at   -
        '------------------------------------------------------------

        Const strDBNAME As String = "CollegeInfo" 'sets the name of the database
        Const strSERVERNAME As String = "(localdb)\MSSQLLocalDB" 'sets the server the database will be stored in
        Dim strDBPath As String = My.Application.Info.DirectoryPath & "\" & strDBNAME & ".mdf" 'sets the path for the database

        Dim strConnection As String = "SERVER=" & strSERVERNAME & ";DATABASE=" & strDBNAME & ";Integrated Security=SSPI;AttachDbFileName=" & strDBPath 'full connection string
        If Not (IO.File.Exists(strDBPath)) Then 'if the file already exists, no need to create the database again, if it doesn't, database will be created and populated
            CreateDatabase(strSERVERNAME, strDBNAME, strDBPath, strConnection)
            PopulateCollegesTable(strConnection)
            PopulateDegreesTable(strConnection)
        End If

        frmDBColleges.ShowDialog() 'show the main form
    End Sub

    Sub CreateDatabase(strSERVERNAME As String, strDBNAME As String, strDBPath As String, strConnection As String)
        '------------------------------------------------------------
        '-                Subprogram Name: CreateDatabase           -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: March 25th 2023               -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is called to create a database given the -
        '- server name, database name, database path, and connection-
        '- string.                                                  -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- strsERVERNAME - name of the server                       -
        '- strDBNAME - name of the database                         -
        '- strDBPATH - string of the path to the database           -
        '- strConnection - full connection string to the database   -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- DBCmd - SqlCommand object to be able to run the passed   -
        '-          command on the database.                        -
        '- DBConn - SqlConnection object to allow us connection to  -
        '-          the server.                                     -
        '- strSQLCmd - string to hold the SQL command to run on the -
        '-              database.                                   -
        '------------------------------------------------------------
        Dim DBConn As SqlConnection
        Dim strSQLCmd As String
        Dim DBCmd As SqlCommand

        DBConn = New SqlConnection("Server=" & strSERVERNAME)

        strSQLCmd = "CREATE DATABASE " & strDBNAME & " On " & "(NAME='" & strDBNAME & "'," & "FILENAME='" & strDBPath & "')"
        DBCmd = New SqlCommand(strSQLCmd, DBConn)

        Try
            DBConn.Open()
            DBCmd.ExecuteNonQuery() 'will run the above 'create database' query and create the database
            Debug.WriteLine("Successfully created DB")
        Catch ex As Exception
            MessageBox.Show(ex.ToString() & vbCrLf & "Cannot bulid DB. Shutting down program...")
            End
        End Try

        If (DBConn.State = ConnectionState.Open) Then 'close the connection if it is open
            DBConn.Close()
        End If

        DBConn = New SqlConnection(strConnection)
        DBConn.Open()

        DBCmd.CommandText = "CREATE TABLE Colleges (" & 'SQL query to create the Colleges table
                            "ID INT NOT NULL IDENTITY(1,1) PRIMARY KEY, " &
                            "CollegeName NCHAR(30), " &
                            "Address NCHAR(30), " &
                            "City NCHAR(30), " &
                            "State NCHAR(2), " &
                            "ZipCode NCHAR(10))"
        DBCmd.Connection = DBConn
        Try
            DBCmd.ExecuteNonQuery() 'execute the above 'create table' query and create the Colleges table
            Debug.WriteLine("Created Colleges Table")
        Catch ex As Exception
            Debug.WriteLine("Could not create table (Colleges)")
        End Try

        DBCmd.CommandText = "CREATE TABLE Degrees (" & 'SQL query to create the Degrees table
                            "ID INT NOT NULL IDENTITY(1,1) PRIMARY KEY, " &
                            "DegreeName NCHAR(25), " &
                            "DegreeDesignator NCHAR(5), " &
                            "CreditsRequired NCHAR(3), " &
                            "EstimatedTimeOfCompletion NCHAR(1), " &
                            "CollegeTUID INT)"
        DBCmd.Connection = DBConn
        Try
            DBCmd.ExecuteNonQuery() 'execute the above 'create table' query and create the Degrees table
            Debug.WriteLine("Created Degrees Table")
        Catch ex As Exception
            Debug.WriteLine("Could not create table (Degrees)")
        End Try

        If (DBConn.State = ConnectionState.Open) Then 'close the connection if it is open
            DBConn.Close()
        End If
    End Sub

    Sub PopulateCollegesTable(strConn As String)
        '------------------------------------------------------------
        '-                Subprogram Name: PopulateCollegesTable    -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: March 25th 2023               -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is called to populate the colleges table -
        '- with some initial data.                                  -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- strConn - connection string to the database              -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- DBCmd - SqlCommand object to run a given command on the  -
        '           database.                                       -
        '- DBConn - SqlConnection object to connect to the database.-
        '------------------------------------------------------------
        Dim DBConn As SqlConnection
        Dim DBCmd As SqlCommand = New SqlCommand()

        DBConn = New SqlConnection(strConn)
        DBConn.Open() 'open the connection

        DBCmd.CommandText = "INSERT INTO Colleges " & 'insert command to run on database
                            "VALUES('SVSU','7400 Bay Road','University Center','MI','48710');"
        DBCmd.Connection = DBConn
        DBCmd.ExecuteNonQuery() 'executes the above insert

        DBCmd.CommandText = "INSERT INTO Colleges " &
                            "VALUES('Delta College','1961 Delta Road','University Center','MI','48710');"
        DBCmd.Connection = DBConn
        DBCmd.ExecuteNonQuery()

        DBCmd.CommandText = "INSERT INTO Colleges " &
                            "VALUES('James Technical Institute','100 Code Blvd','Saginaw','MI','48604');"
        DBCmd.Connection = DBConn
        DBCmd.ExecuteNonQuery()

        DBConn.Close() 'closes the connection
        Debug.WriteLine("Added Colleges to Colleges Table")
    End Sub

    Sub PopulateDegreesTable(strConn As String)
        '------------------------------------------------------------
        '-                Subprogram Name: PopulateDegreesTable     -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: March 25th 2023               -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is called to populate the degrees table  -
        '- with some initial data.                                  -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- strConn - connection string to the database              -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- DBCmd - SqlCommand object to run a given command on the  -
        '           database.                                       -
        '- DBConn - SqlConnection object to connect to the database.-
        '------------------------------------------------------------
        Dim DBConn As SqlConnection
        Dim DBCmd As SqlCommand = New SqlCommand()

        DBConn = New SqlConnection(strConn)
        DBConn.Open() 'open the connection

        DBCmd.CommandText = "INSERT INTO Degrees (DegreeName, DegreeDesignator, CreditsRequired, EstimatedTimeOfCompletion, CollegeTUID)" & 'insert command to run on database
                            "VALUES('CIS','BS','124','4','1');"
        DBCmd.Connection = DBConn
        DBCmd.ExecuteNonQuery() 'executes the above command

        DBCmd.CommandText = "INSERT INTO Degrees (DegreeName, DegreeDesignator, CreditsRequired, EstimatedTimeOfCompletion, CollegeTUID)" &
                            "VALUES('CS','BS','124','4','1');"
        DBCmd.Connection = DBConn
        DBCmd.ExecuteNonQuery()

        DBCmd.CommandText = "INSERT INTO Degrees (DegreeName, DegreeDesignator, CreditsRequired, EstimatedTimeOfCompletion, CollegeTUID)" &
                            "VALUES('Business Administration','MBA','48','2','1');"
        DBCmd.Connection = DBConn
        DBCmd.ExecuteNonQuery()

        DBCmd.CommandText = "INSERT INTO Degrees (DegreeName, DegreeDesignator, CreditsRequired, EstimatedTimeOfCompletion, CollegeTUID)" &
                            "VALUES('Auto Mechanics','AA','62','2','2');"
        DBCmd.Connection = DBConn
        DBCmd.ExecuteNonQuery()

        DBCmd.CommandText = "INSERT INTO Degrees (DegreeName, DegreeDesignator, CreditsRequired, EstimatedTimeOfCompletion, CollegeTUID)" &
                            "VALUES('CS','AS','62','2','2');"
        DBCmd.Connection = DBConn
        DBCmd.ExecuteNonQuery()

        DBCmd.CommandText = "INSERT INTO Degrees (DegreeName, DegreeDesignator, CreditsRequired, EstimatedTimeOfCompletion, CollegeTUID)" &
                            "VALUES('Coding Wizardry','BS','124','5','3');"
        DBCmd.Connection = DBConn
        DBCmd.ExecuteNonQuery()

        DBCmd.CommandText = "INSERT INTO Degrees (DegreeName, DegreeDesignator, CreditsRequired, EstimatedTimeOfCompletion, CollegeTUID)" &
                            "VALUES('Hacking For Fun','AS','62','3','3');"
        DBCmd.Connection = DBConn
        DBCmd.ExecuteNonQuery()

        DBCmd.CommandText = "INSERT INTO Degrees (DegreeName, DegreeDesignator, CreditsRequired, EstimatedTimeOfCompletion, CollegeTUID)" &
                            "VALUES('Business Analysis','BA','124','5','3');"
        DBCmd.Connection = DBConn
        DBCmd.ExecuteNonQuery()

        DBConn.Close() 'closes the connection
        Debug.WriteLine("Added Degrees to the Degrees Table")
    End Sub

    Sub DeleteDatabase(strSERVERNAME As String, strDBNAME As String)
        '------------------------------------------------------------
        '-                Subprogram Name: DeleteDatabase           -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: March 25th 2023               -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is called to completely delete the       -
        '- database.                                                -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- strSERVERNAME - server name                              -
        '- strDBNAME - database name                                -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- DBCommand - SqlCommand object to run a given command on  -
        '           the database.                                   -
        '- DBConn - SqlConnection object to connect to the database.-
        '- strSQLCmd - string holding the command to run on the db. -
        '------------------------------------------------------------
        Dim DBConn As SqlConnection
        Dim strSQLCmd As String
        Dim DBCommand As SqlCommand

        DBConn = New SqlConnection("Server=" & strSERVERNAME)

        strSQLCmd = "ALTER DATABASE [" & strDBNAME & "] SET " & 'command to be run on the database
                    "SINGLE_USER WITH ROLLBACK IMMEDIATE"
        DBCommand = New SqlCommand(strSQLCmd, DBConn)

        Try
            DBConn.Open()
            DBCommand.ExecuteNonQuery() 'execute the above command
            Debug.WriteLine("Database set for exclusive use", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
        If (DBConn.State = ConnectionState.Open) Then
            DBConn.Close()
        End If

        strSQLCmd = "DROP DATABASE " & strDBNAME 'command to drop the database completely
        DBCommand = New SqlCommand(strSQLCmd, DBConn)

        Try
            DBConn.Open()
            DBCommand.ExecuteNonQuery() 'run the above command
            MessageBox.Show("Database has been deleted", "", MessageBoxButtons.OK,
            MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try

        If (DBConn.State = ConnectionState.Open) Then 'if the connection is open, close it
            DBConn.Close()
        End If
    End Sub
End Module
