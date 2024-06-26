﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmServer
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        lblGameLog = New Label()
        txtCommunications = New TextBox()
        gbxNetworkSettings = New GroupBox()
        btnStopServer = New Button()
        btnStartServer = New Button()
        txtPort = New TextBox()
        lblServerListens = New Label()
        gbxNetworkEnd = New GroupBox()
        rdoClient = New RadioButton()
        rdoServer = New RadioButton()
        gbxGameControls = New GroupBox()
        lblSetBeforeStart = New Label()
        lblServerControlsThis = New Label()
        gbxMovesFirst = New GroupBox()
        rdoP2MoveFirst = New RadioButton()
        rdoP1MoveFirst = New RadioButton()
        gbxPlayer = New GroupBox()
        rdoPlayer2 = New RadioButton()
        rdoPlayer1 = New RadioButton()
        pnlChooseColumn = New Panel()
        Button5 = New Button()
        Button4 = New Button()
        Button3 = New Button()
        Button2 = New Button()
        Button1 = New Button()
        pnlGameBoard = New Panel()
        Panel2 = New Panel()
        row1col5 = New Button()
        row2col5 = New Button()
        row3col5 = New Button()
        row4col5 = New Button()
        Panel3 = New Panel()
        row1col4 = New Button()
        row2col4 = New Button()
        row3col4 = New Button()
        row4col4 = New Button()
        Panel4 = New Panel()
        row1col3 = New Button()
        row2col3 = New Button()
        row3col3 = New Button()
        row4col3 = New Button()
        Panel5 = New Panel()
        row1col2 = New Button()
        row2col2 = New Button()
        row3col2 = New Button()
        row4col2 = New Button()
        Panel6 = New Panel()
        row1col1 = New Button()
        row2col1 = New Button()
        row3col1 = New Button()
        row4col1 = New Button()
        lblMessage = New Label()
        gbxNetworkSettings.SuspendLayout()
        gbxNetworkEnd.SuspendLayout()
        gbxGameControls.SuspendLayout()
        gbxMovesFirst.SuspendLayout()
        gbxPlayer.SuspendLayout()
        pnlChooseColumn.SuspendLayout()
        pnlGameBoard.SuspendLayout()
        Panel2.SuspendLayout()
        Panel3.SuspendLayout()
        Panel4.SuspendLayout()
        Panel5.SuspendLayout()
        Panel6.SuspendLayout()
        SuspendLayout()
        ' 
        ' lblGameLog
        ' 
        lblGameLog.AutoSize = True
        lblGameLog.Location = New Point(12, 533)
        lblGameLog.Name = "lblGameLog"
        lblGameLog.Size = New Size(64, 15)
        lblGameLog.TabIndex = 26
        lblGameLog.Text = "Game Log:"
        ' 
        ' txtCommunications
        ' 
        txtCommunications.Location = New Point(12, 551)
        txtCommunications.Multiline = True
        txtCommunications.Name = "txtCommunications"
        txtCommunications.ReadOnly = True
        txtCommunications.ScrollBars = ScrollBars.Vertical
        txtCommunications.Size = New Size(856, 180)
        txtCommunications.TabIndex = 20
        txtCommunications.TabStop = False
        ' 
        ' gbxNetworkSettings
        ' 
        gbxNetworkSettings.Controls.Add(btnStopServer)
        gbxNetworkSettings.Controls.Add(btnStartServer)
        gbxNetworkSettings.Controls.Add(txtPort)
        gbxNetworkSettings.Controls.Add(lblServerListens)
        gbxNetworkSettings.Controls.Add(gbxNetworkEnd)
        gbxNetworkSettings.Location = New Point(597, 27)
        gbxNetworkSettings.Name = "gbxNetworkSettings"
        gbxNetworkSettings.Size = New Size(271, 230)
        gbxNetworkSettings.TabIndex = 28
        gbxNetworkSettings.TabStop = False
        gbxNetworkSettings.Text = "Network Settings:"
        ' 
        ' btnStopServer
        ' 
        btnStopServer.Enabled = False
        btnStopServer.Location = New Point(18, 194)
        btnStopServer.Name = "btnStopServer"
        btnStopServer.Size = New Size(233, 26)
        btnStopServer.TabIndex = 3
        btnStopServer.Text = "Stop Server"
        btnStopServer.UseVisualStyleBackColor = True
        ' 
        ' btnStartServer
        ' 
        btnStartServer.Location = New Point(18, 148)
        btnStartServer.Name = "btnStartServer"
        btnStartServer.Size = New Size(233, 26)
        btnStartServer.TabIndex = 2
        btnStartServer.Text = "Start Server"
        btnStartServer.UseVisualStyleBackColor = True
        ' 
        ' txtPort
        ' 
        txtPort.Location = New Point(151, 108)
        txtPort.Name = "txtPort"
        txtPort.Size = New Size(100, 23)
        txtPort.TabIndex = 1
        txtPort.Text = "1000"
        ' 
        ' lblServerListens
        ' 
        lblServerListens.AutoSize = True
        lblServerListens.Location = New Point(18, 111)
        lblServerListens.Name = "lblServerListens"
        lblServerListens.Size = New Size(123, 15)
        lblServerListens.TabIndex = 1
        lblServerListens.Text = "Server Listens on Port:"
        ' 
        ' gbxNetworkEnd
        ' 
        gbxNetworkEnd.Controls.Add(rdoClient)
        gbxNetworkEnd.Controls.Add(rdoServer)
        gbxNetworkEnd.Enabled = False
        gbxNetworkEnd.Location = New Point(18, 36)
        gbxNetworkEnd.Name = "gbxNetworkEnd"
        gbxNetworkEnd.Size = New Size(233, 57)
        gbxNetworkEnd.TabIndex = 0
        gbxNetworkEnd.TabStop = False
        gbxNetworkEnd.Text = "Network End:"
        ' 
        ' rdoClient
        ' 
        rdoClient.AutoSize = True
        rdoClient.Location = New Point(138, 25)
        rdoClient.Name = "rdoClient"
        rdoClient.Size = New Size(56, 19)
        rdoClient.TabIndex = 1
        rdoClient.TabStop = True
        rdoClient.Text = "Client"
        rdoClient.UseVisualStyleBackColor = True
        ' 
        ' rdoServer
        ' 
        rdoServer.AutoSize = True
        rdoServer.Location = New Point(38, 25)
        rdoServer.Name = "rdoServer"
        rdoServer.Size = New Size(57, 19)
        rdoServer.TabIndex = 0
        rdoServer.TabStop = True
        rdoServer.Text = "Server"
        rdoServer.UseVisualStyleBackColor = True
        ' 
        ' gbxGameControls
        ' 
        gbxGameControls.Controls.Add(lblSetBeforeStart)
        gbxGameControls.Controls.Add(lblServerControlsThis)
        gbxGameControls.Controls.Add(gbxMovesFirst)
        gbxGameControls.Controls.Add(gbxPlayer)
        gbxGameControls.Location = New Point(615, 263)
        gbxGameControls.Name = "gbxGameControls"
        gbxGameControls.Size = New Size(233, 221)
        gbxGameControls.TabIndex = 29
        gbxGameControls.TabStop = False
        gbxGameControls.Text = "Game Controls:"
        ' 
        ' lblSetBeforeStart
        ' 
        lblSetBeforeStart.AutoSize = True
        lblSetBeforeStart.Location = New Point(26, 190)
        lblSetBeforeStart.Name = "lblSetBeforeStart"
        lblSetBeforeStart.Size = New Size(177, 15)
        lblSetBeforeStart.TabIndex = 4
        lblSetBeforeStart.Text = "** Set Before Starting Server!!!! **"
        ' 
        ' lblServerControlsThis
        ' 
        lblServerControlsThis.AutoSize = True
        lblServerControlsThis.Location = New Point(55, 165)
        lblServerControlsThis.Name = "lblServerControlsThis"
        lblServerControlsThis.Size = New Size(114, 15)
        lblServerControlsThis.TabIndex = 3
        lblServerControlsThis.Text = "Server Controls This!"
        ' 
        ' gbxMovesFirst
        ' 
        gbxMovesFirst.Controls.Add(rdoP2MoveFirst)
        gbxMovesFirst.Controls.Add(rdoP1MoveFirst)
        gbxMovesFirst.Location = New Point(13, 79)
        gbxMovesFirst.Name = "gbxMovesFirst"
        gbxMovesFirst.Size = New Size(205, 73)
        gbxMovesFirst.TabIndex = 2
        gbxMovesFirst.TabStop = False
        gbxMovesFirst.Text = "Moves First:"
        ' 
        ' rdoP2MoveFirst
        ' 
        rdoP2MoveFirst.AutoSize = True
        rdoP2MoveFirst.Location = New Point(56, 47)
        rdoP2MoveFirst.Name = "rdoP2MoveFirst"
        rdoP2MoveFirst.Size = New Size(85, 19)
        rdoP2MoveFirst.TabIndex = 7
        rdoP2MoveFirst.TabStop = True
        rdoP2MoveFirst.Text = "2 Goes First"
        rdoP2MoveFirst.UseVisualStyleBackColor = True
        ' 
        ' rdoP1MoveFirst
        ' 
        rdoP1MoveFirst.AutoSize = True
        rdoP1MoveFirst.Location = New Point(56, 22)
        rdoP1MoveFirst.Name = "rdoP1MoveFirst"
        rdoP1MoveFirst.Size = New Size(85, 19)
        rdoP1MoveFirst.TabIndex = 6
        rdoP1MoveFirst.TabStop = True
        rdoP1MoveFirst.Text = "1 Goes First"
        rdoP1MoveFirst.UseVisualStyleBackColor = True
        ' 
        ' gbxPlayer
        ' 
        gbxPlayer.Controls.Add(rdoPlayer2)
        gbxPlayer.Controls.Add(rdoPlayer1)
        gbxPlayer.Location = New Point(13, 22)
        gbxPlayer.Name = "gbxPlayer"
        gbxPlayer.Size = New Size(205, 51)
        gbxPlayer.TabIndex = 0
        gbxPlayer.TabStop = False
        gbxPlayer.Text = "Player:"
        ' 
        ' rdoPlayer2
        ' 
        rdoPlayer2.AutoSize = True
        rdoPlayer2.Location = New Point(125, 26)
        rdoPlayer2.Name = "rdoPlayer2"
        rdoPlayer2.Size = New Size(31, 19)
        rdoPlayer2.TabIndex = 5
        rdoPlayer2.TabStop = True
        rdoPlayer2.Text = "2"
        rdoPlayer2.UseVisualStyleBackColor = True
        ' 
        ' rdoPlayer1
        ' 
        rdoPlayer1.AutoSize = True
        rdoPlayer1.Location = New Point(25, 26)
        rdoPlayer1.Name = "rdoPlayer1"
        rdoPlayer1.Size = New Size(31, 19)
        rdoPlayer1.TabIndex = 4
        rdoPlayer1.TabStop = True
        rdoPlayer1.Text = "1"
        rdoPlayer1.UseVisualStyleBackColor = True
        ' 
        ' pnlChooseColumn
        ' 
        pnlChooseColumn.Controls.Add(Button5)
        pnlChooseColumn.Controls.Add(Button4)
        pnlChooseColumn.Controls.Add(Button3)
        pnlChooseColumn.Controls.Add(Button2)
        pnlChooseColumn.Controls.Add(Button1)
        pnlChooseColumn.Location = New Point(12, 12)
        pnlChooseColumn.Name = "pnlChooseColumn"
        pnlChooseColumn.Size = New Size(479, 81)
        pnlChooseColumn.TabIndex = 33
        ' 
        ' Button5
        ' 
        Button5.Location = New Point(391, 15)
        Button5.Name = "Button5"
        Button5.Size = New Size(66, 65)
        Button5.TabIndex = 4
        Button5.Tag = "5"
        Button5.Text = "Col5"
        Button5.UseVisualStyleBackColor = True
        ' 
        ' Button4
        ' 
        Button4.Location = New Point(295, 15)
        Button4.Name = "Button4"
        Button4.Size = New Size(66, 65)
        Button4.TabIndex = 3
        Button4.Tag = "4"
        Button4.Text = "Col4"
        Button4.UseVisualStyleBackColor = True
        ' 
        ' Button3
        ' 
        Button3.Location = New Point(199, 15)
        Button3.Name = "Button3"
        Button3.Size = New Size(66, 65)
        Button3.TabIndex = 2
        Button3.Tag = "3"
        Button3.Text = "Col3"
        Button3.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.Location = New Point(106, 15)
        Button2.Name = "Button2"
        Button2.Size = New Size(66, 65)
        Button2.TabIndex = 1
        Button2.Tag = "2"
        Button2.Text = "Col2"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(13, 15)
        Button1.Name = "Button1"
        Button1.Size = New Size(66, 65)
        Button1.TabIndex = 0
        Button1.Tag = "1"
        Button1.Text = "Col1"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' pnlGameBoard
        ' 
        pnlGameBoard.Controls.Add(Panel2)
        pnlGameBoard.Controls.Add(Panel3)
        pnlGameBoard.Controls.Add(Panel4)
        pnlGameBoard.Controls.Add(Panel5)
        pnlGameBoard.Controls.Add(Panel6)
        pnlGameBoard.Location = New Point(13, 98)
        pnlGameBoard.Name = "pnlGameBoard"
        pnlGameBoard.Size = New Size(483, 380)
        pnlGameBoard.TabIndex = 32
        ' 
        ' Panel2
        ' 
        Panel2.Controls.Add(row1col5)
        Panel2.Controls.Add(row2col5)
        Panel2.Controls.Add(row3col5)
        Panel2.Controls.Add(row4col5)
        Panel2.Location = New Point(385, 17)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(79, 348)
        Panel2.TabIndex = 29
        Panel2.Tag = "5"
        ' 
        ' row1col5
        ' 
        row1col5.BackColor = Color.LightGray
        row1col5.Enabled = False
        row1col5.Location = New Point(5, 260)
        row1col5.Name = "row1col5"
        row1col5.Size = New Size(66, 65)
        row1col5.TabIndex = 24
        row1col5.Tag = "1"
        row1col5.UseVisualStyleBackColor = False
        ' 
        ' row2col5
        ' 
        row2col5.BackColor = Color.LightGray
        row2col5.Enabled = False
        row2col5.Location = New Point(5, 179)
        row2col5.Name = "row2col5"
        row2col5.Size = New Size(66, 65)
        row2col5.TabIndex = 19
        row2col5.Tag = "2"
        row2col5.UseVisualStyleBackColor = False
        ' 
        ' row3col5
        ' 
        row3col5.BackColor = Color.LightGray
        row3col5.Enabled = False
        row3col5.Location = New Point(5, 96)
        row3col5.Name = "row3col5"
        row3col5.Size = New Size(66, 65)
        row3col5.TabIndex = 14
        row3col5.Tag = "3"
        row3col5.UseVisualStyleBackColor = False
        ' 
        ' row4col5
        ' 
        row4col5.BackColor = Color.LightGray
        row4col5.Enabled = False
        row4col5.Location = New Point(5, 10)
        row4col5.Name = "row4col5"
        row4col5.Size = New Size(66, 65)
        row4col5.TabIndex = 9
        row4col5.Tag = "4"
        row4col5.UseVisualStyleBackColor = False
        ' 
        ' Panel3
        ' 
        Panel3.Controls.Add(row1col4)
        Panel3.Controls.Add(row2col4)
        Panel3.Controls.Add(row3col4)
        Panel3.Controls.Add(row4col4)
        Panel3.Location = New Point(289, 17)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(80, 351)
        Panel3.TabIndex = 28
        Panel3.Tag = "4"
        ' 
        ' row1col4
        ' 
        row1col4.BackColor = Color.LightGray
        row1col4.Enabled = False
        row1col4.Location = New Point(5, 260)
        row1col4.Name = "row1col4"
        row1col4.Size = New Size(66, 65)
        row1col4.TabIndex = 23
        row1col4.Tag = "1"
        row1col4.UseVisualStyleBackColor = False
        ' 
        ' row2col4
        ' 
        row2col4.BackColor = Color.LightGray
        row2col4.Enabled = False
        row2col4.Location = New Point(5, 179)
        row2col4.Name = "row2col4"
        row2col4.Size = New Size(66, 65)
        row2col4.TabIndex = 18
        row2col4.Tag = "2"
        row2col4.UseVisualStyleBackColor = False
        ' 
        ' row3col4
        ' 
        row3col4.BackColor = Color.LightGray
        row3col4.Enabled = False
        row3col4.Location = New Point(5, 96)
        row3col4.Name = "row3col4"
        row3col4.Size = New Size(66, 65)
        row3col4.TabIndex = 13
        row3col4.Tag = "3"
        row3col4.UseVisualStyleBackColor = False
        ' 
        ' row4col4
        ' 
        row4col4.BackColor = Color.LightGray
        row4col4.Enabled = False
        row4col4.Location = New Point(5, 10)
        row4col4.Name = "row4col4"
        row4col4.Size = New Size(66, 65)
        row4col4.TabIndex = 8
        row4col4.Tag = "4"
        row4col4.UseVisualStyleBackColor = False
        ' 
        ' Panel4
        ' 
        Panel4.Controls.Add(row1col3)
        Panel4.Controls.Add(row2col3)
        Panel4.Controls.Add(row3col3)
        Panel4.Controls.Add(row4col3)
        Panel4.Location = New Point(193, 17)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(79, 343)
        Panel4.TabIndex = 27
        Panel4.Tag = "3"
        ' 
        ' row1col3
        ' 
        row1col3.BackColor = Color.LightGray
        row1col3.Enabled = False
        row1col3.Location = New Point(5, 260)
        row1col3.Name = "row1col3"
        row1col3.Size = New Size(66, 65)
        row1col3.TabIndex = 22
        row1col3.Tag = "1"
        row1col3.UseVisualStyleBackColor = False
        ' 
        ' row2col3
        ' 
        row2col3.BackColor = Color.LightGray
        row2col3.Enabled = False
        row2col3.Location = New Point(5, 179)
        row2col3.Name = "row2col3"
        row2col3.Size = New Size(66, 65)
        row2col3.TabIndex = 17
        row2col3.Tag = "2"
        row2col3.UseVisualStyleBackColor = False
        ' 
        ' row3col3
        ' 
        row3col3.BackColor = Color.LightGray
        row3col3.Enabled = False
        row3col3.Location = New Point(5, 96)
        row3col3.Name = "row3col3"
        row3col3.Size = New Size(66, 65)
        row3col3.TabIndex = 12
        row3col3.Tag = "3"
        row3col3.UseVisualStyleBackColor = False
        ' 
        ' row4col3
        ' 
        row4col3.BackColor = Color.LightGray
        row4col3.Enabled = False
        row4col3.Location = New Point(5, 10)
        row4col3.Name = "row4col3"
        row4col3.Size = New Size(66, 65)
        row4col3.TabIndex = 7
        row4col3.Tag = "4"
        row4col3.UseVisualStyleBackColor = False
        ' 
        ' Panel5
        ' 
        Panel5.Controls.Add(row1col2)
        Panel5.Controls.Add(row2col2)
        Panel5.Controls.Add(row3col2)
        Panel5.Controls.Add(row4col2)
        Panel5.Location = New Point(100, 16)
        Panel5.Name = "Panel5"
        Panel5.Size = New Size(83, 342)
        Panel5.TabIndex = 26
        Panel5.Tag = "2"
        ' 
        ' row1col2
        ' 
        row1col2.BackColor = Color.LightGray
        row1col2.Enabled = False
        row1col2.Location = New Point(5, 261)
        row1col2.Name = "row1col2"
        row1col2.Size = New Size(66, 65)
        row1col2.TabIndex = 21
        row1col2.Tag = "1"
        row1col2.UseVisualStyleBackColor = False
        ' 
        ' row2col2
        ' 
        row2col2.BackColor = Color.LightGray
        row2col2.Enabled = False
        row2col2.Location = New Point(5, 180)
        row2col2.Name = "row2col2"
        row2col2.Size = New Size(66, 65)
        row2col2.TabIndex = 16
        row2col2.Tag = "2"
        row2col2.UseVisualStyleBackColor = False
        ' 
        ' row3col2
        ' 
        row3col2.BackColor = Color.LightGray
        row3col2.Enabled = False
        row3col2.Location = New Point(5, 97)
        row3col2.Name = "row3col2"
        row3col2.Size = New Size(66, 65)
        row3col2.TabIndex = 11
        row3col2.Tag = "3"
        row3col2.UseVisualStyleBackColor = False
        ' 
        ' row4col2
        ' 
        row4col2.BackColor = Color.LightGray
        row4col2.Enabled = False
        row4col2.Location = New Point(5, 11)
        row4col2.Name = "row4col2"
        row4col2.Size = New Size(66, 65)
        row4col2.TabIndex = 6
        row4col2.Tag = "4"
        row4col2.UseVisualStyleBackColor = False
        ' 
        ' Panel6
        ' 
        Panel6.Controls.Add(row1col1)
        Panel6.Controls.Add(row2col1)
        Panel6.Controls.Add(row3col1)
        Panel6.Controls.Add(row4col1)
        Panel6.Location = New Point(7, 17)
        Panel6.Name = "Panel6"
        Panel6.Size = New Size(80, 344)
        Panel6.TabIndex = 25
        Panel6.Tag = "1"
        ' 
        ' row1col1
        ' 
        row1col1.BackColor = Color.LightGray
        row1col1.Enabled = False
        row1col1.Location = New Point(1, 261)
        row1col1.Name = "row1col1"
        row1col1.Size = New Size(66, 65)
        row1col1.TabIndex = 20
        row1col1.Tag = "1"
        row1col1.UseVisualStyleBackColor = False
        ' 
        ' row2col1
        ' 
        row2col1.BackColor = Color.LightGray
        row2col1.Enabled = False
        row2col1.Location = New Point(1, 180)
        row2col1.Name = "row2col1"
        row2col1.Size = New Size(66, 65)
        row2col1.TabIndex = 15
        row2col1.Tag = "2"
        row2col1.UseVisualStyleBackColor = False
        ' 
        ' row3col1
        ' 
        row3col1.BackColor = Color.LightGray
        row3col1.Enabled = False
        row3col1.Location = New Point(1, 97)
        row3col1.Name = "row3col1"
        row3col1.Size = New Size(66, 65)
        row3col1.TabIndex = 10
        row3col1.Tag = "3"
        row3col1.UseVisualStyleBackColor = False
        ' 
        ' row4col1
        ' 
        row4col1.BackColor = Color.LightGray
        row4col1.Enabled = False
        row4col1.Location = New Point(1, 11)
        row4col1.Name = "row4col1"
        row4col1.Size = New Size(66, 65)
        row4col1.TabIndex = 5
        row4col1.Tag = "4"
        row4col1.UseVisualStyleBackColor = False
        ' 
        ' lblMessage
        ' 
        lblMessage.AutoSize = True
        lblMessage.Font = New Font("Sitka Text", 15.7499981F, FontStyle.Regular, GraphicsUnit.Point)
        lblMessage.Location = New Point(131, 497)
        lblMessage.Name = "lblMessage"
        lblMessage.Size = New Size(147, 30)
        lblMessage.TabIndex = 34
        lblMessage.Text = "Example Text"
        ' 
        ' frmServer
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(880, 743)
        Controls.Add(lblMessage)
        Controls.Add(pnlChooseColumn)
        Controls.Add(pnlGameBoard)
        Controls.Add(gbxGameControls)
        Controls.Add(gbxNetworkSettings)
        Controls.Add(txtCommunications)
        Controls.Add(lblGameLog)
        Name = "frmServer"
        Tag = "4"
        Text = "Connect Three - Server - I am player 1 and player 1 goes first"
        gbxNetworkSettings.ResumeLayout(False)
        gbxNetworkSettings.PerformLayout()
        gbxNetworkEnd.ResumeLayout(False)
        gbxNetworkEnd.PerformLayout()
        gbxGameControls.ResumeLayout(False)
        gbxGameControls.PerformLayout()
        gbxMovesFirst.ResumeLayout(False)
        gbxMovesFirst.PerformLayout()
        gbxPlayer.ResumeLayout(False)
        gbxPlayer.PerformLayout()
        pnlChooseColumn.ResumeLayout(False)
        pnlGameBoard.ResumeLayout(False)
        Panel2.ResumeLayout(False)
        Panel3.ResumeLayout(False)
        Panel4.ResumeLayout(False)
        Panel5.ResumeLayout(False)
        Panel6.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents lblGameLog As Label
    Friend WithEvents txtCommunications As TextBox
    Friend WithEvents gbxNetworkSettings As GroupBox
    Friend WithEvents btnStopServer As Button
    Friend WithEvents btnStartServer As Button
    Friend WithEvents txtPort As TextBox
    Friend WithEvents lblServerListens As Label
    Friend WithEvents gbxNetworkEnd As GroupBox
    Friend WithEvents rdoClient As RadioButton
    Friend WithEvents rdoServer As RadioButton
    Friend WithEvents gbxGameControls As GroupBox
    Friend WithEvents lblSetBeforeStart As Label
    Friend WithEvents lblServerControlsThis As Label
    Friend WithEvents gbxMovesFirst As GroupBox
    Friend WithEvents rdoP2MoveFirst As RadioButton
    Friend WithEvents rdoP1MoveFirst As RadioButton
    Friend WithEvents gbxPlayer As GroupBox
    Friend WithEvents rdoPlayer2 As RadioButton
    Friend WithEvents rdoPlayer1 As RadioButton
    Friend WithEvents pnlChooseColumn As Panel
    Friend WithEvents Button5 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents pnlGameBoard As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents row1col5 As Button
    Friend WithEvents row2col5 As Button
    Friend WithEvents row3col5 As Button
    Friend WithEvents row4col5 As Button
    Friend WithEvents Panel3 As Panel
    Friend WithEvents row1col4 As Button
    Friend WithEvents row2col4 As Button
    Friend WithEvents row3col4 As Button
    Friend WithEvents row4col4 As Button
    Friend WithEvents Panel4 As Panel
    Friend WithEvents row1col3 As Button
    Friend WithEvents row2col3 As Button
    Friend WithEvents row3col3 As Button
    Friend WithEvents row4col3 As Button
    Friend WithEvents Panel5 As Panel
    Friend WithEvents row1col2 As Button
    Friend WithEvents row2col2 As Button
    Friend WithEvents row3col2 As Button
    Friend WithEvents row4col2 As Button
    Friend WithEvents Panel6 As Panel
    Friend WithEvents row1col1 As Button
    Friend WithEvents row2col1 As Button
    Friend WithEvents row3col1 As Button
    Friend WithEvents row4col1 As Button
    Friend WithEvents lblMessage As Label
End Class
