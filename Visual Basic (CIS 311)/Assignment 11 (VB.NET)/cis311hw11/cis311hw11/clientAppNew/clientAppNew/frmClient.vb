Imports System.IO
Imports System.Net.Sockets

Public Class frmClient
    '------------------------------------------------------------
    '-                File Name : frmClient.vb                  - 
    '-                Part of Project: clientAppNew             -
    '------------------------------------------------------------
    '-                Written By: Adam Cossin                   -
    '-                Written On: April 18th, 2023              -
    '------------------------------------------------------------
    '- File Purpose:                                            -
    '- This file contains the client application form where the -
    '- client will be able to play 'connect three' with a server-
    '------------------------------------------------------------
    '- Program Purpose:                                         -
    '- This program acts as a client and communicates with a    -
    '- server and lets them play a turn-based version of        -
    '-'connect three'.                                          -
    '------------------------------------------------------------
    '- Global Variable Dictionary (alphabetically):             -
    '- blnConnected - if the client and server are connected    -
    '- blnMyTurn - boolean keeping track of if it's server's turn-
    '- Client - instance of TcpClient                           -
    '- netReader - reads in incoming data from client connection-
    '- netStream - underlying access for network communication  -
    '- netWriter - writes data to client connection             -
    '- threadGetData - thread that processes incoming data      -
    '------------------------------------------------------------
    'Note: in general, there will be more detailed comments on the server application as much of the functionality here is the same
    Dim Client As TcpClient
    Dim netStream As NetworkStream
    Dim netWriter As BinaryWriter
    Dim netReader As BinaryReader
    Dim threadGetData As System.Threading.Thread
    Dim blnMyTurn As Boolean = False
    Dim blnConnected As Boolean = False
    Private Sub frmClient_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '------------------------------------------------------------
        '-                Subprogram Name: frmClient_Load           -
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
        rdoClient.Select()
        pnlChooseColumn.Enabled = False
        CheckForIllegalCrossThreadCalls = False
        setHandlers()
    End Sub

    Private Sub btnStartClient_Click(sender As Object, e As EventArgs) Handles btnStartClient.Click
        '------------------------------------------------------------
        '-                Subprogram Name: btnStartClient_Click     -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: April 18th, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is to start the client's listening thread-
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- sender – Identifies which particular control raised the  –
        '-          click event                                     - 
        '- e – Holds the EventArgs object sent to the routine       -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        txtAddress.Enabled = False
        txtPort.Enabled = False
        Dim threadListen As System.Threading.Thread
        threadListen = New Threading.Thread(AddressOf startListening)
        threadListen.Start()
        resetBoard()
    End Sub

    Private Sub setHandlers()
        '------------------------------------------------------------
        '-              Subprogram Name: setHandlers                -
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
            AddHandler CType(btn, Button).Click, AddressOf btnClick
        Next
    End Sub

    Private Sub startListening()
        '------------------------------------------------------------
        '-                Subprogram Name: startListening           -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: April 18th, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is to used to begin listening for server -
        '- responses and sets up the connection to the server.      -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- (None)                                                   -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        Try
            txtCommunications.Text &= "Attempting connection to the server..." & vbCrLf
            Client = New TcpClient()
            If (txtAddress.Text <> "" And txtPort.Text <> "") Then
                Client.Connect(txtAddress.Text, CInt(txtPort.Text))
                blnConnected = True
            Else
                If (txtAddress.Text = "") Then
                    MessageBox.Show("Error - no address entered! Shutting down...")
                Else
                    MessageBox.Show("Error - no port number entered! Shutting down...")
                End If
                disconnectClient()
            End If
            netStream = Client.GetStream()
            netWriter = New BinaryWriter(netStream)
            netReader = New BinaryReader(netStream)

            txtCommunications.Text &= "Network stream and reader/writer objects created" & vbCrLf
            btnStartClient.Enabled = False
            btnStopClient.Enabled = True
            txtCommunications.Text &= "Preparing thread to watch for data..." & vbCrLf

            threadGetData = New Threading.Thread(AddressOf getData)
            threadGetData.Start()
            txtCommunications.Text &= "Data watching thread active" & vbCrLf
        Catch IOEx As IOException
            txtCommunications.Text &= "Error in setting up Client -- Closing" & vbCrLf
        Catch SocketEx As SocketException
            txtCommunications.Text &= "Cannot find server -- please try again later" & vbCrLf
            txtAddress.Enabled = True
            txtPort.Enabled = True
        End Try
    End Sub

    Private Sub getData()
        '------------------------------------------------------------
        '-                Subprogram Name: getData                  -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: April 18th, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is to used to read in server data, and to-
        '- update the board on the client's side to be in sync with -
        '- the server's board after either make a move.             -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- (None)                                                   -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- intCol - column number from the server's message         -
        '- strArrMessage - elements split up from the server's message-
        '- strServerMessage - message from the server               -
        '------------------------------------------------------------
        Dim strServerMessage As String
        txtCommunications.Text &= "Data watching thread active..." & vbCrLf
        Try
            While (blnConnected)
                strServerMessage = netReader.ReadString
                txtCommunications.Text &= "From Server: " & strServerMessage & vbCrLf
                If (strServerMessage.Contains("WINNER")) Then
                    lblMessage.Text = strServerMessage
                    lblMessage.Text = strServerMessage.ToString
                    lblMessage.Visible = True
                    pnlChooseColumn.Enabled = False
                    blnConnected = False
                ElseIf (strServerMessage.Contains("SERVER")) Then
                    setTitle(strServerMessage)
                ElseIf (strServerMessage.Contains("END")) Then
                    blnConnected = False
                Else
                    Dim strArrMessage() As String = strServerMessage.Split(",")
                    Dim intCol As Integer = Integer.Parse(strArrMessage(0))
                    addToken(intCol)
                    blnMyTurn = True
                    pnlChooseColumn.Enabled = True
                End If
            End While
            disconnectClient()
        Catch IOEx As IOException
            txtCommunications.Text &= "Closing client connection..." & vbCrLf
            disconnectClient()
        End Try
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
        Dim intRow As Integer = 1
        setAvailableColumns()
        For Each pnl In pnlGameBoard.Controls
            If pnl.Tag = intCol Then
                pnlToInsert = pnl
            End If
        Next
        For Each btn In pnlToInsert.Controls
            If (btn.Tag = intRow And btn.BackColor = Color.LightGray) Then
                If (blnMyTurn = True) Then
                    btn.BackColor = Color.Blue
                    blnMyTurn = False
                    pnlChooseColumn.Enabled = False
                    netWriter.Write(intCol & "," & intRow & "," & btn.BackColor.ToString)
                    checkForWin(intCol, intRow, btn.BackColor.ToString)
                    setAvailableColumns()
                Else
                    btn.BackColor = Color.Red
                    blnMyTurn = True
                    pnlChooseColumn.Enabled = True
                    setAvailableColumns()
                End If
            Else
                If (intRow = 4) Then
                    Debug.WriteLine("Invalid move!")
                Else
                    intRow += 1
                End If
            End If
        Next
    End Sub

    Private Sub disconnectClient()
        '------------------------------------------------------------
        '-                Subprogram Name: disconnectClient         -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: April 18th, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is to used to disconnect from the server -
        '- and to clean up resources.                               -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- (None)                                                   -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        pnlChooseColumn.Enabled = False
        blnConnected = False
        btnStopClient.Enabled = False
        btnStartClient.Enabled = True
        txtAddress.Enabled = True
        txtPort.Enabled = True
        txtCommunications.Text &= "Attempting to disconnect from the server..." & vbCrLf
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
            If (Not Client Is Nothing) Then
                Client.Close()
                Client = Nothing
            End If

            If (Not threadGetData Is Nothing) Then
                threadGetData.Abort()
            End If
        Catch ex As Exception
        Finally
            txtCommunications.Text &= "Disconnected... client closed" & vbCrLf
        End Try
    End Sub

    Private Sub btnStopClient_Click(sender As Object, e As EventArgs) Handles btnStopClient.Click
        '------------------------------------------------------------
        '-                Subprogram Name: btnStopClient_Click      -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: April 18th, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is to forcibly stop the client when 'stop'-
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
            disconnectClient()
        Else
            netWriter.Write("END")
            disconnectClient()
        End If
    End Sub

    Private Sub frmClient_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        '------------------------------------------------------------
        '-                Subprogram Name: frmClient_FormClosing    -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: April 18th, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is to forcibly stop the client when the  -
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
            disconnectClient()
        Else
            netWriter.Write("END")
            disconnectClient()
        End If
    End Sub

    Private Sub setTitle(strMessage As String)
        '------------------------------------------------------------
        '-                Subprogram Name: setTitle                 -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: April 18th, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is to set the title of the client given  -
        '- the initial message from the server                      -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- strMessage - message from server indicating which player -
        '- the server is and which player goes first.               -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- playerInfoArray - splits message up into components      -
        '------------------------------------------------------------
        Dim playerInfoArray() As String = strMessage.Split(",")
        If (CInt(playerInfoArray(1)) = CInt(playerInfoArray(2))) Then
            blnMyTurn = False
            pnlChooseColumn.Enabled = False
        Else
            blnMyTurn = True
            pnlChooseColumn.Enabled = True
        End If
        If (playerInfoArray(1) = "1") Then
            Me.Text = "Connect Three - Client - I am player 2 and player " & playerInfoArray(2) & " goes first"
        Else
            Me.Text = " Connect Three - Client - I am player 1 and player " & playerInfoArray(2) & " goes first"
        End If
    End Sub

    Private Sub btnClick(sender As Object, e As EventArgs)
        '------------------------------------------------------------
        '-                Subprogram Name: btnClick                 -
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
        Select Case intClickedColumn
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
        If (checkHorizontal(x, y, strColor) Or
            checkVertical(x, y, strColor) Or
            checkLeftDiag(x, y, strColor) Or
            checkRightDiag(x, y, strColor)) Then
            lblMessage.Text = "WINNER IS " & strColor
            lblMessage.Visible = True
            pnlChooseColumn.Enabled = False
            netWriter.Write("WINNER IS " & strColor)
            netWriter.Write("END")
        Else
            Dim intNumFilled As Integer = 0
            For Each pnl In pnlGameBoard.Controls
                For Each btn In pnl.Controls
                    If (btn.BackColor <> Color.LightGray) Then
                        intNumFilled += 1
                        If (intNumFilled = 20) Then
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
        For Each columnPnl In pnlGameBoard.Controls
            If (columnPnl.Tag = x Or columnPnl.Tag = x + 1 Or columnPnl.Tag = x - 1) Then
                For Each btn In columnPnl.Controls
                    If (btn.Tag = y And btn.BackColor.ToString = strColor) Then
                        intNumMatches += 1
                        If (intNumMatches = 3) Then
                            Return True
                        End If
                    End If
                Next
            ElseIf (columnPnl.Tag = x Or columnPnl.Tag = x + 1 Or columnPnl.Tag = x + 2) Then
                For Each btn In columnPnl.Controls
                    If (btn.Tag = y And btn.BackColor.ToString = strColor) Then
                        intNumMatches += 1
                        If (intNumMatches = 3) Then
                            Return True
                        End If
                    End If
                Next
            ElseIf (columnPnl.Tag = x Or columnPnl.Tag = x - 1 Or columnPnl.Tag = x - 2) Then
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
        For Each pnl In pnlGameBoard.Controls
            If (pnl.Tag = x) Then
                For Each btn In pnl.Controls
                    If (btn.Tag = y And btn.BackColor.ToString = strColor Or
                        btn.Tag = y - 1 And btn.BackColor.ToString = strColor Or
                        btn.Tag = y + 1 And btn.BackColor.ToString = strColor) Then
                        intNumMatches += 1
                        If (intNumMatches = 3) Then
                            Return True
                        End If
                    ElseIf (btn.Tag = y And btn.BackColor.ToString = strColor Or
                        btn.Tag = y + 1 And btn.BackColor.ToString = strColor Or
                        btn.Tag = y + 2 And btn.BackColor.ToString = strColor) Then
                        intNumMatches += 1
                        If (intNumMatches = 3) Then
                            Return True
                        End If
                    ElseIf (btn.Tag = y And btn.BackColor.ToString = strColor Or
                        btn.Tag = y - 1 And btn.BackColor.ToString = strColor Or
                        btn.Tag = y - 2 And btn.BackColor.ToString = strColor) Then
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
        For Each columnPnl In pnlGameBoard.Controls
            For Each btn In columnPnl.Controls
                If (columnPnl.Tag = x And btn.Tag = y And btn.BackColor.ToString = strColor Or
                    columnPnl.Tag = x + 1 And btn.Tag = y - 1 And btn.BackColor.ToString = strColor Or
                    columnPnl.Tag = x - 1 And btn.Tag = y + 1 And btn.BackColor.ToString = strColor Or
                    columnPnl.Tag = x + 2 And btn.Tag = y - 2 And btn.BackColor.ToString = strColor Or
                    columnPnl.Tag = x - 2 And btn.Tag = y + 2 And btn.BackColor.ToString = strColor) Then
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
                    columnPnl.Tag = x - 2 And btn.Tag = y - 2 And btn.BackColor.ToString = strColor) Then
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
        For Each pnl In pnlGameBoard.Controls
            Dim intNumFilled As Integer = 0
            Dim colNum = pnl.Tag
            For Each btn In pnl.Controls
                If (btn.BackColor <> Color.LightGray) Then
                    intNumFilled += 1
                    If (intNumFilled >= 4) Then
                        For Each colBtn In pnlChooseColumn.Controls
                            If (colBtn.Tag = colNum) Then
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
            For Each btn In pnl.Controls
                If (btn.BackColor <> Color.LightGray) Then
                    btn.BackColor = Color.LightGray
                End If
            Next
        Next
        For Each btnCol In pnlChooseColumn.Controls
            If (btnCol.Enabled = False) Then
                btnCol.Enabled = True
            End If
        Next
    End Sub
End Class
