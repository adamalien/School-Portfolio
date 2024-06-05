Imports System.IO
Imports System.Net.Sockets

Public Class frmServer
    '------------------------------------------------------------
    '-                File Name : frmServer.vb                  - 
    '-                Part of Project: ServerApp                -
    '------------------------------------------------------------
    '-                Written By: Adam Cossin                   -
    '-                Written On: April 18th, 2023              -
    '------------------------------------------------------------
    '- File Purpose:                                            -
    '- This file contains the server application form where the -
    '- server will be able to listen for clients to play a game -
    '- of 'connect three' with.                                 -
    '------------------------------------------------------------
    '- Program Purpose:                                         -
    '- This program acts as a server and communicates with any  -
    '- client that wants to connect and lets them play a turn-  -
    '- based version of 'connect three'.                        -
    '------------------------------------------------------------
    '- Global Variable Dictionary (alphabetically):             -
    '- blnMyTurn - boolean keeping track of if it's server's turn-
    '- netReader - reads in incoming data from client connection-
    '- netStream - underlying access for network communication  -
    '- netWriter - writes data to client connection             -
    '- Server - instance of server (TcpListener)                -
    '- socketConnection - socket of communication to client     -
    '- threadGetData - thread that processes incoming data      -
    '- threadListen - thread that listens for a connection      -
    '------------------------------------------------------------
    Dim Server As TcpListener
    Dim socketConnection As Socket
    Dim netStream As NetworkStream
    Dim netWriter As BinaryWriter
    Dim netReader As BinaryReader
    Dim threadGetData As System.Threading.Thread
    Dim blnMyTurn As Boolean = True
    Dim threadListen As System.Threading.Thread

    Private Sub frmServer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '------------------------------------------------------------
        '-                Subprogram Name: frmServer_Load           -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: April 18th, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is to initialize the form. Sets initial  –
        '- values, including setting handlers.                      -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- sender – Identifies which particular control raised the  –
        '-          click event                                     - 
        '- e – Holds the EventArgs object sent to the routine       -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        lblMessage.Visible = False
        rdoServer.Select()
        rdoPlayer1.Select()
        rdoP1MoveFirst.Select()
        pnlChooseColumn.Enabled = False
        CheckForIllegalCrossThreadCalls = False
        setHandlersForColumnButtons()
        setHandlersForRdoPlayerChoiceButtons()
    End Sub

    Private Sub setHandlersForColumnButtons()
        '------------------------------------------------------------
        '-              Subprogram Name: setHandlersForColumnButtons-
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: April 18th, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is to set handlers for each button in the-
        '- 'pnlChooseColumn' panel (the buttons the user will click -
        '- to choose where to drop a token)                         -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- (None)                                                   -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        For Each btn In pnlChooseColumn.Controls
            AddHandler CType(btn, Button).Click, AddressOf clickAction 'sets each button's click event to run clickAction
        Next
    End Sub

    Private Sub setHandlersForRdoPlayerChoiceButtons()
        '------------------------------------------------------------
        '-     Subprogram Name: setHandlersForRdoPlayerChoiceButtons-
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: April 18th, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is to set handlers for each radio button -
        '- that dictates which player goes first and which player the-
        '- server and client are.                                   -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- (None)                                                   -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        For Each rdoBtn In gbxPlayer.Controls
            AddHandler CType(rdoBtn, RadioButton).CheckedChanged, AddressOf playerOrderSet 'sets the rdo button's checkedchanged event to call playerOrderSet
        Next
        For Each rdoBtn In gbxMovesFirst.Controls
            AddHandler CType(rdoBtn, RadioButton).CheckedChanged, AddressOf playerOrderSet 'sets the rdo button's checkedchanged event to call playerOrderSet
        Next
    End Sub

    Private Sub playerOrderSet()
        '------------------------------------------------------------
        '-                Subprogram Name: playerOrderSet           -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: April 18th, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is to used to set the title of the form  -
        '- based on the selected radio buttons, and also to set the -
        '- initial value that 'blnMyTurn' will hold.                -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- (None)                                                   -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        Me.Text = "Connect Three - Server - I am player " & getPlayerNum() & 'sets the title of the form
            " and player " & getMovesFirst() & " goes first"
        If (getPlayerNum() = getMovesFirst()) Then 'if the player that goes first is the same as the server, then it is the server's turn, else it is not
            blnMyTurn = True
        Else
            blnMyTurn = False
        End If
    End Sub

    Private Sub clickAction(sender As Object, e As EventArgs)
        '------------------------------------------------------------
        '-                Subprogram Name: clickAction              -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: April 18th, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is to handle the the click of each button-
        '- that the user can select to drop their token down a column-
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- sender – Identifies which particular control raised the  –
        '-          click event                                     - 
        '- e – Holds the EventArgs object sent to the routine       -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- btnClickedButton - the button that raised the event      -
        '- intClickedColumn - the column that the button is in      -
        '------------------------------------------------------------
        Dim btnClickedButton As Button = CType(sender, Button)
        Dim intClickedColumn As Integer = btnClickedButton.Tag
        Select Case intClickedColumn 'select case to try to add a token in the column that was selected
            Case 1
                addToken(1)
            Case 2
                addToken(2)
            Case 3
                addToken(3)
            Case 4
                addToken(4)
            Case 5
                addToken(5)
        End Select
    End Sub

    Private Sub addToken(intCol)
        '------------------------------------------------------------
        '-                Subprogram Name: addToken                 -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: April 18th, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is to used to add a token down the column-
        '- that is passed as a parameter (if possible).             -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- intCol- the column to add a token to                     -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- intRow - scans each row in a column to see where a token -
        '-          can be added.                                   -
        '- pnlToInsert - panel coorelating to the column to add a   -
        '-              token to.                                   -
        '------------------------------------------------------------
        Dim pnlToInsert As Panel = New Panel
        Dim intRow As Integer = 1 'start at row 1 (bottom row)
        setAvailableColumns() 'call setAvailableColumns to check that only columns with room can be added to
        For Each pnl In pnlGameBoard.Controls 'go through panels to find the correct one that will need to be added to
            If pnl.Tag = intCol Then
                pnlToInsert = pnl
            End If
        Next
        For Each btn In pnlToInsert.Controls 'go through each button in the panel to find one that has an empty space to insert the token into
            If (btn.Tag = intRow And btn.BackColor = Color.LightGray) Then 'if the current row's button is free, change the button's color to that of the token
                If (blnMyTurn = True) Then 'if it's the server's turn, add a red token
                    btn.BackColor = Color.Red
                    blnMyTurn = False
                    pnlChooseColumn.Enabled = False
                    netWriter.Write(intCol & "," & intRow & "," & btn.BackColor.ToString) 'write to the client that the token was inserted
                    checkForWin(intCol, intRow, btn.BackColor.ToString) 'checks for a win condition
                    setAvailableColumns()
                Else
                    btn.BackColor = Color.Blue 'if it's the client's turn, the token that was added will be blue
                    blnMyTurn = True
                    pnlChooseColumn.Enabled = True
                    setAvailableColumns()
                End If
            Else
                If (intRow = 4) Then 'if the number of the current row is 4, that means the row is full
                    Debug.WriteLine("Invalid move!")
                Else
                    intRow += 1 'increments the row as long as the current row didn't have a free space
                End If
            End If
        Next
    End Sub

    Private Function getPlayerNum() As Integer
        '------------------------------------------------------------
        '-                Function Name: getPlayerNum               -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: April 18th, 2023              -
        '------------------------------------------------------------
        '- Function Purpose:                                        -
        '- This function returns the player number of the server    -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- (None)                                                   -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        '- Returns:                                                 -
        '- Integer – telling the server's player number             -
        '------------------------------------------------------------
        If (rdoPlayer1.Checked) Then
            Return 1
        Else
            Return 2
        End If
    End Function

    Private Function getMovesFirst() As Integer
        '------------------------------------------------------------
        '-                Function Name: getMovesFirst              -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: April 18th, 2023              -
        '------------------------------------------------------------
        '- Function Purpose:                                        -
        '- This function returns the player who goes first          -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- (None)                                                   -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        '- Returns:                                                 -
        '- Integer – telling which player goes first                -
        '------------------------------------------------------------
        If (rdoP1MoveFirst.Checked) Then
            Return 1
        Else
            Return 2
        End If
    End Function

    Private Sub btnStartServer_Click(sender As Object, e As EventArgs) Handles btnStartServer.Click
        '------------------------------------------------------------
        '-                Subprogram Name: btnStartServer_Click     -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: April 18th, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is to start the server's listening thread-
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- sender – Identifies which particular control raised the  –
        '-          click event                                     - 
        '- e – Holds the EventArgs object sent to the routine       -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        gbxGameControls.Enabled = False
        txtPort.Enabled = False
        threadListen = New Threading.Thread(AddressOf startListening) 'spin up a new thread to start listening for clients (so that the server isn't frozen here)
        threadListen.Start()
        resetBoard() 'reset the board (in case there was a game played before)
        If (getMovesFirst() = getPlayerNum()) Then 'sets the boolean myTurn
            blnMyTurn = True
        Else
            blnMyTurn = False
        End If
    End Sub

    Private Sub startListening()
        '------------------------------------------------------------
        '-                Subprogram Name: startListening           -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: April 18th, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is to used to begin listening for client -
        '- requests and sets up the connection to the client.       -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- (None)                                                   -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        Try
            txtCommunications.Text &= "Starting Server..." & vbCrLf
            If (txtPort.Text = "") Then 'if a port number isn't entered, there would be an error, so display a message and stop
                MessageBox.Show("Error - no port number entered! Shutting down...")
                stopListening()
            End If
            Server = New TcpListener(Net.IPAddress.Parse("127.0.0.1"), CInt(txtPort.Text)) 'initialize server
            Server.Start() 'start server

            btnStartServer.Enabled = False
            btnStopServer.Enabled = True
            txtCommunications.Text &= "Listening for client connection..." & vbCrLf

            Application.DoEvents() 'allows messages from the message queue to be run
            socketConnection = Server.AcceptSocket() 'accepts a new connection if one comes
            txtCommunications.Text &= "...client connection accepted" & vbCrLf

            netStream = New NetworkStream(socketConnection) 'initialize our netStream, netWriter, and netReader
            netWriter = New BinaryWriter(netStream)
            netReader = New BinaryReader(netStream)

            txtCommunications.Text &= "Preparing thread to watch for data..." & vbCrLf
            threadGetData = New Threading.Thread(AddressOf getClientData) 'start a thread to get data from the client
            threadGetData.Start() 'start the thread
            txtCommunications.Text &= "Data watching thread active" & vbCrLf
            netWriter.Write("SERVER," & getPlayerNum() & "," & getMovesFirst()) 'write the server's player number and who moves first to the client
            If (getPlayerNum() = getMovesFirst()) Then
                pnlChooseColumn.Enabled = True 'if it's the server's turn, enable the panel to choose a column to drop a token
            End If
        Catch IOEx As IOException
            txtCommunications.Text &= "Error in setting up Server -- Closing..." & vbCrLf
        Catch SocketEx As SocketException
            'txtCommunications.Text &= "Server already exists -- just restarting listening..." & vbCrLf
        End Try
    End Sub

    Private Sub getClientData()
        '------------------------------------------------------------
        '-                Subprogram Name: getClientData            -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: April 18th, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is to used to read in client data, and to-
        '- update the board on the server's side to be in sync with -
        '- the client's board after either make a move.             -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- (None)                                                   -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- intCol - column number from the client's message         -
        '- strArrMessage - elements split up from the client's message-
        '- strClientMessage - message from the client               -
        '------------------------------------------------------------
        Dim strClientMessage As String
        txtCommunications.Text &= "Watching for client data..." & vbCrLf
        Try
            While (socketConnection.Connected) 'while there is still an open connection, continue to read in client data
                strClientMessage = netReader.ReadString 'get client's data
                txtCommunications.Text &= "From Client: " & strClientMessage & vbCrLf 'display the data in the communications textbox
                If (strClientMessage.Contains("WINNER")) Then 'if the message has 'WINNER' in it - that means there was a winner, so update the board and close the connection
                    lblMessage.Text = strClientMessage.ToString 'update the label on screen
                    lblMessage.Visible = True
                    pnlChooseColumn.Enabled = False
                    socketConnection.Disconnect(False) 'disconnect the socket
                ElseIf (strClientMessage.Contains("END")) Then 'if the message has 'END', means the client disconnected, so disconnect the socket
                    socketConnection.Disconnect(False)
                Else 'otherwise, it is just a normal move in the game
                    Dim strArrMessage() As String = strClientMessage.Split(",")
                    Dim intCol As Integer = strArrMessage(0) 'get the column from the message to pass to 'addToken'
                    addToken(intCol) 'add the token to the board
                    blnMyTurn = True 'will now be server's turn
                    pnlChooseColumn.Enabled = True
                End If
            End While
            stopListening() 'when the socket is disconnected, we call stop listening to wrap things up
        Catch IOEx As IOException
            txtCommunications.Text &= "Closing connection with client..." & vbCrLf
            stopListening()
        End Try
    End Sub

    Private Sub stopListening()
        '------------------------------------------------------------
        '-                Subprogram Name: stopListening            -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: April 18th, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is to used to disconnect from the client -
        '- and to clean up resources.                               -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- (None)                                                   -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        pnlChooseColumn.Enabled = False
        btnStartServer.Enabled = True
        btnStopServer.Enabled = False
        gbxGameControls.Enabled = True
        txtPort.Enabled = True
        txtCommunications.Text &= "Attempting to close connection to client..." & vbCrLf
        Try
            If (Not netWriter Is Nothing) Then
                netWriter.Close()
                netWriter = Nothing
            End If
            If (Not netReader Is Nothing) Then
                netReader.Close()
                netReader = Nothing
            End If
            If (Not netStream Is Nothing) Then
                netStream.Close()
                netStream = Nothing
            End If
            If (Not Server Is Nothing) Then
                Server.Stop()
                Server = Nothing
            End If

            If (Not threadGetData Is Nothing) Then
                threadGetData.Abort()
            End If

            If (Not threadListen Is Nothing) Then
                threadListen.Abort()
            End If
        Catch ex As Exception
        Finally
            txtCommunications.Text &= "Server has been stopped..." & vbCrLf
        End Try
    End Sub

    Private Sub btnStopServer_Click(sender As Object, e As EventArgs) Handles btnStopServer.Click
        '------------------------------------------------------------
        '-                Subprogram Name: btnStopServer_Click      -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: April 18th, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is to forcibly stop the server when 'stop'-
        '- button is clicked.                                       -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- sender – Identifies which particular control raised the  –
        '-          click event                                     - 
        '- e – Holds the EventArgs object sent to the routine       -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        If (netWriter Is Nothing) Then
            stopListening()
        Else
            netWriter.Write("END")
            stopListening()
        End If
    End Sub

    Private Sub frmServer_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        '------------------------------------------------------------
        '-                Subprogram Name: frmServer_FormClosing    -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: April 18th, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is to forcibly stop the server when the  -
        '- form is closed.                                          -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- sender – Identifies which particular control raised the  –
        '-          click event                                     - 
        '- e – Holds the FormClosingEventArgs object sent to the routine-
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        If (netWriter Is Nothing) Then
            stopListening()
        Else
            netWriter.Write("END")
            stopListening()
        End If
    End Sub

    Private Sub checkForWin(x As Integer, y As Integer, strColor As String)
        '------------------------------------------------------------
        '-                Subprogram Name: checkForWin              -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: April 18th, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is to check the board for win conditions -
        '- to see if there has been a win.                          -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- x - column                                               -
        '- y - row                                                  -
        '- strColor - color of the token                            -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- intNumFilled - keeps track of the number of slots that   -
        '- are full to check for the 'draw' condition.              -
        '------------------------------------------------------------
        If (checkHorizontal(x, y, strColor) Or 'check each win condition, if any of them are true...
            checkVertical(x, y, strColor) Or
            checkLeftDiag(x, y, strColor) Or
            checkRightDiag(x, y, strColor)) Then
            lblMessage.Text = "WINNER IS " & strColor '...update the label and send the 'WINNER' message to the client
            lblMessage.Visible = True
            pnlChooseColumn.Enabled = False
            netWriter.Write("WINNER IS " & strColor)
            netWriter.Write("END")
        Else 'otherwise a win condition was not met, so see if there was a 'draw' condition
            Dim intNumFilled As Integer = 0
            For Each pnl In pnlGameBoard.Controls
                For Each btn In pnl.Controls
                    If (btn.BackColor <> Color.LightGray) Then 'checks each button on the game board and sees if they are not available
                        intNumFilled += 1 'if the current slot is unavailable (occupied by a player), then add it to 'intNumFilled'
                        If (intNumFilled = 20) Then 'if intNumFilled is 20, means all slots are filled, and no more moves can be made, resulting in a draw
                            lblMessage.Text = "DRAW - NO WINNER"
                            lblMessage.Visible = True
                            pnlChooseColumn.Enabled = False
                            netWriter.Write(lblMessage.Text)
                        End If
                    End If
                Next
            Next
        End If
    End Sub

    Private Function checkHorizontal(x As Integer, y As Integer, strColor As String) As Boolean
        '------------------------------------------------------------
        '-                Function Name: checkHorizontal            -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: April 18th, 2023              -
        '------------------------------------------------------------
        '- Function Purpose:                                        -
        '- This function returns true on a horizontal win           -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- x - column                                               -
        '- y - row                                                  -
        '- strColor - color of the current token                    -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- intNumMatches - the number of currently matching tokens  -
        '-                 in a row in the current row.             -
        '------------------------------------------------------------
        '- Returns:                                                 -
        '- Boolean - telling if there is a win condition here       -
        '------------------------------------------------------------
        Dim intNumMatches As Integer = 0
        For Each columnPnl In pnlGameBoard.Controls 'goes through each column
            If (columnPnl.Tag = x Or columnPnl.Tag = x + 1 Or columnPnl.Tag = x - 1) Then 'checks three in a row in positions x, x+1 and x-1
                For Each btn In columnPnl.Controls
                    If (btn.Tag = y And btn.BackColor.ToString = strColor) Then
                        intNumMatches += 1
                        If (intNumMatches = 3) Then
                            Return True
                        End If
                    End If
                Next
            ElseIf (columnPnl.Tag = x Or columnPnl.Tag = x + 1 Or columnPnl.Tag = x + 2) Then 'checks three in a row in positions x, x+1 and x+2
                For Each btn In columnPnl.Controls
                    If (btn.Tag = y And btn.BackColor.ToString = strColor) Then
                        intNumMatches += 1
                        If (intNumMatches = 3) Then
                            Return True
                        End If
                    End If
                Next
            ElseIf (columnPnl.Tag = x Or columnPnl.Tag = x - 1 Or columnPnl.Tag = x - 2) Then 'checks three in a row in positions x, x-1 and x-2
                For Each btn In columnPnl.Controls
                    If (btn.Tag = y And btn.BackColor.ToString = strColor) Then
                        intNumMatches += 1
                        If (intNumMatches = 3) Then
                            Return True
                        End If
                    End If
                Next
            End If
        Next
        Return False
    End Function

    Private Function checkVertical(x As Integer, y As Integer, strColor As String) As Boolean
        '------------------------------------------------------------
        '-                Function Name: checkVertical              -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: April 18th, 2023              -
        '------------------------------------------------------------
        '- Function Purpose:                                        -
        '- This function returns true on a vertical win             -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- x - column                                               -
        '- y - row                                                  -
        '- strColor - color of the current token                    -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- intNumMatches - the number of currently matching tokens  -
        '-                 in a row in the current column.          -
        '------------------------------------------------------------
        '- Returns:                                                 -
        '- Boolean - telling if there is a win condition here       -
        '------------------------------------------------------------
        Dim intNumMatches As Integer = 0
        For Each pnl In pnlGameBoard.Controls 'goes through column that token was just added to
            If (pnl.Tag = x) Then
                For Each btn In pnl.Controls 'goes through each button in the column
                    If (btn.Tag = y And btn.BackColor.ToString = strColor Or
                        btn.Tag = y - 1 And btn.BackColor.ToString = strColor Or
                        btn.Tag = y + 1 And btn.BackColor.ToString = strColor) Then 'checks three in a row in y, y-1 and y+1
                        intNumMatches += 1
                        If (intNumMatches = 3) Then
                            Return True
                        End If
                    ElseIf (btn.Tag = y And btn.BackColor.ToString = strColor Or
                        btn.Tag = y + 1 And btn.BackColor.ToString = strColor Or
                        btn.Tag = y + 2 And btn.BackColor.ToString = strColor) Then 'checks three in a row in y, y+1, and y+2
                        intNumMatches += 1
                        If (intNumMatches = 3) Then
                            Return True
                        End If
                    ElseIf (btn.Tag = y And btn.BackColor.ToString = strColor Or
                        btn.Tag = y - 1 And btn.BackColor.ToString = strColor Or
                        btn.Tag = y - 2 And btn.BackColor.ToString = strColor) Then 'checks three in a row in y, y-1 and y-2
                        intNumMatches += 1
                        If (intNumMatches = 3) Then
                            Return True
                        End If
                    End If
                Next
            End If
        Next
        Return False
    End Function

    Private Function checkLeftDiag(x As Integer, y As Integer, strColor As String) As Boolean
        '------------------------------------------------------------
        '-                Function Name: checkLeftDiag              -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: April 18th, 2023              -
        '------------------------------------------------------------
        '- Function Purpose:                                        -
        '- This function returns true on a left diag win            -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- x - column                                               -
        '- y - row                                                  -
        '- strColor - color of the current token                    -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- intNumMatches - the number of currently matching tokens  -
        '-                 in a row in the current diag.            -
        '------------------------------------------------------------
        '- Returns:                                                 -
        '- Boolean - telling if there is a win condition here       -
        '------------------------------------------------------------
        Dim intNumMatches As Integer = 0
        For Each columnPnl In pnlGameBoard.Controls 'goes through each column in the game board
            For Each btn In columnPnl.Controls 'looks through each button in each column
                If (columnPnl.Tag = x And btn.Tag = y And btn.BackColor.ToString = strColor Or
                    columnPnl.Tag = x + 1 And btn.Tag = y - 1 And btn.BackColor.ToString = strColor Or
                    columnPnl.Tag = x - 1 And btn.Tag = y + 1 And btn.BackColor.ToString = strColor Or
                    columnPnl.Tag = x + 2 And btn.Tag = y - 2 And btn.BackColor.ToString = strColor Or
                    columnPnl.Tag = x - 2 And btn.Tag = y + 2 And btn.BackColor.ToString = strColor) Then 'checks each (x,y) pair that would correlate to a win for left diag
                    intNumMatches += 1
                    If (intNumMatches = 3) Then
                        Return True
                    End If
                End If
            Next
        Next
        Return False
    End Function

    Private Function checkRightDiag(x As Integer, y As Integer, strColor As String) As Boolean
        '------------------------------------------------------------
        '-                Function Name: checkRightDiag             -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: April 18th, 2023              -
        '------------------------------------------------------------
        '- Function Purpose:                                        -
        '- This function returns true on a right diag win           -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- x - column                                               -
        '- y - row                                                  -
        '- strColor - color of the current token                    -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- intNumMatches - the number of currently matching tokens  -
        '-                 in a row in the current diag.            -
        '------------------------------------------------------------
        '- Returns:                                                 -
        '- Boolean - telling if there is a win condition here       -
        '------------------------------------------------------------
        Dim intNumMatches As Integer = 0
        For Each columnPnl In pnlGameBoard.Controls
            For Each btn In columnPnl.Controls
                If (columnPnl.Tag = x And btn.Tag = y And btn.BackColor.ToString = strColor Or
                    columnPnl.Tag = x + 1 And btn.Tag = y + 1 And btn.BackColor.ToString = strColor Or
                    columnPnl.Tag = x - 1 And btn.Tag = y - 1 And btn.BackColor.ToString = strColor Or
                    columnPnl.Tag = x + 2 And btn.Tag = y + 2 And btn.BackColor.ToString = strColor Or
                    columnPnl.Tag = x - 2 And btn.Tag = y - 2 And btn.BackColor.ToString = strColor) Then 'checks each (x,y) pair that would correlate to a win for right diag
                    intNumMatches += 1
                    If (intNumMatches = 3) Then
                        Return True
                    End If
                End If
            Next
        Next
        Return False
    End Function

    Private Sub setAvailableColumns()
        '------------------------------------------------------------
        '-                Subprogram Name: setAvailableColumns      -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: April 18th, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is to check if a column is full, and to  -
        '- disable the insert button for that column if it is.      -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- (None)                                                   -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- colNum - number of the current column                    -
        '- intNumFilled - keeps track of the number of slots that   -
        '- are full to check for the 'draw' condition.              -
        '------------------------------------------------------------
        For Each pnl In pnlGameBoard.Controls 'goes through each column panel
            Dim intNumFilled As Integer = 0
            Dim colNum = pnl.Tag
            For Each btn In pnl.Controls 'goes through each button in the column and sees if it is available or not
                If (btn.BackColor <> Color.LightGray) Then
                    intNumFilled += 1
                    If (intNumFilled >= 4) Then 'if all four buttons are full for a column, then the row is full
                        For Each colBtn In pnlChooseColumn.Controls
                            If (colBtn.Tag = colNum) Then 'disable the button for the column that is full
                                colBtn.Enabled = False
                            End If
                        Next
                    End If
                End If
            Next
        Next
    End Sub

    Private Sub resetBoard()
        '------------------------------------------------------------
        '-                Subprogram Name: resetBoard               -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: April 18th, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is to rest the board to its' default state-
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- (None)                                                   -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        txtCommunications.Clear()
        lblMessage.Visible = False
        For Each pnl In pnlGameBoard.Controls
            For Each btn In pnl.Controls 'set each button back to light gray color
                If (btn.BackColor <> Color.LightGray) Then
                    btn.BackColor = Color.LightGray
                End If
            Next
        Next
        For Each btnCol In pnlChooseColumn.Controls
            If (btnCol.Enabled = False) Then 'set each column button back to enabled
                btnCol.Enabled = True
            End If
        Next
    End Sub
End Class
