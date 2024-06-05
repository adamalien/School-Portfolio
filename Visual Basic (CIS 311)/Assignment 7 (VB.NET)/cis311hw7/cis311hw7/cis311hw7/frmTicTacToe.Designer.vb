<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmTicTacToe
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTicTacToe))
        Me.btnReset = New System.Windows.Forms.Button()
        Me.lblResult = New System.Windows.Forms.Label()
        Me.txtRow1Col1 = New System.Windows.Forms.TextBox()
        Me.txtRow1Col2 = New System.Windows.Forms.TextBox()
        Me.txtRow1Col3 = New System.Windows.Forms.TextBox()
        Me.txtRow2Col3 = New System.Windows.Forms.TextBox()
        Me.txtRow2Col2 = New System.Windows.Forms.TextBox()
        Me.txtRow2Col1 = New System.Windows.Forms.TextBox()
        Me.txtRow3Col3 = New System.Windows.Forms.TextBox()
        Me.txtRow3Col2 = New System.Windows.Forms.TextBox()
        Me.txtRow3Col1 = New System.Windows.Forms.TextBox()
        Me.txtX = New System.Windows.Forms.TextBox()
        Me.txtO = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'btnReset
        '
        Me.btnReset.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.btnReset.Location = New System.Drawing.Point(254, 528)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(267, 63)
        Me.btnReset.TabIndex = 0
        Me.btnReset.Text = "Reset Board"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'lblResult
        '
        Me.lblResult.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblResult.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.lblResult.Location = New System.Drawing.Point(254, 70)
        Me.lblResult.Name = "lblResult"
        Me.lblResult.Size = New System.Drawing.Size(267, 37)
        Me.lblResult.TabIndex = 1
        Me.lblResult.Text = "Undecided"
        Me.lblResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblResult.Visible = False
        '
        'txtRow1Col1
        '
        Me.txtRow1Col1.AllowDrop = True
        Me.txtRow1Col1.BackColor = System.Drawing.Color.LightGray
        Me.txtRow1Col1.Font = New System.Drawing.Font("Segoe UI", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.txtRow1Col1.Location = New System.Drawing.Point(235, 162)
        Me.txtRow1Col1.Multiline = True
        Me.txtRow1Col1.Name = "txtRow1Col1"
        Me.txtRow1Col1.ReadOnly = True
        Me.txtRow1Col1.Size = New System.Drawing.Size(88, 78)
        Me.txtRow1Col1.TabIndex = 2
        Me.txtRow1Col1.TabStop = False
        Me.txtRow1Col1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtRow1Col2
        '
        Me.txtRow1Col2.AllowDrop = True
        Me.txtRow1Col2.BackColor = System.Drawing.Color.LightGray
        Me.txtRow1Col2.Font = New System.Drawing.Font("Segoe UI", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.txtRow1Col2.Location = New System.Drawing.Point(340, 162)
        Me.txtRow1Col2.Multiline = True
        Me.txtRow1Col2.Name = "txtRow1Col2"
        Me.txtRow1Col2.ReadOnly = True
        Me.txtRow1Col2.Size = New System.Drawing.Size(89, 78)
        Me.txtRow1Col2.TabIndex = 3
        Me.txtRow1Col2.TabStop = False
        Me.txtRow1Col2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtRow1Col3
        '
        Me.txtRow1Col3.AllowDrop = True
        Me.txtRow1Col3.BackColor = System.Drawing.Color.LightGray
        Me.txtRow1Col3.Font = New System.Drawing.Font("Segoe UI", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.txtRow1Col3.Location = New System.Drawing.Point(446, 162)
        Me.txtRow1Col3.Multiline = True
        Me.txtRow1Col3.Name = "txtRow1Col3"
        Me.txtRow1Col3.ReadOnly = True
        Me.txtRow1Col3.Size = New System.Drawing.Size(89, 78)
        Me.txtRow1Col3.TabIndex = 4
        Me.txtRow1Col3.TabStop = False
        Me.txtRow1Col3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtRow2Col3
        '
        Me.txtRow2Col3.AllowDrop = True
        Me.txtRow2Col3.BackColor = System.Drawing.Color.LightGray
        Me.txtRow2Col3.Font = New System.Drawing.Font("Segoe UI", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.txtRow2Col3.Location = New System.Drawing.Point(446, 262)
        Me.txtRow2Col3.Multiline = True
        Me.txtRow2Col3.Name = "txtRow2Col3"
        Me.txtRow2Col3.ReadOnly = True
        Me.txtRow2Col3.Size = New System.Drawing.Size(89, 78)
        Me.txtRow2Col3.TabIndex = 7
        Me.txtRow2Col3.TabStop = False
        Me.txtRow2Col3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtRow2Col2
        '
        Me.txtRow2Col2.AllowDrop = True
        Me.txtRow2Col2.BackColor = System.Drawing.Color.LightGray
        Me.txtRow2Col2.Font = New System.Drawing.Font("Segoe UI", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.txtRow2Col2.Location = New System.Drawing.Point(340, 262)
        Me.txtRow2Col2.Multiline = True
        Me.txtRow2Col2.Name = "txtRow2Col2"
        Me.txtRow2Col2.ReadOnly = True
        Me.txtRow2Col2.Size = New System.Drawing.Size(89, 78)
        Me.txtRow2Col2.TabIndex = 6
        Me.txtRow2Col2.TabStop = False
        Me.txtRow2Col2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtRow2Col1
        '
        Me.txtRow2Col1.AllowDrop = True
        Me.txtRow2Col1.BackColor = System.Drawing.Color.LightGray
        Me.txtRow2Col1.Font = New System.Drawing.Font("Segoe UI", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.txtRow2Col1.Location = New System.Drawing.Point(235, 262)
        Me.txtRow2Col1.Multiline = True
        Me.txtRow2Col1.Name = "txtRow2Col1"
        Me.txtRow2Col1.ReadOnly = True
        Me.txtRow2Col1.Size = New System.Drawing.Size(88, 78)
        Me.txtRow2Col1.TabIndex = 5
        Me.txtRow2Col1.TabStop = False
        Me.txtRow2Col1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtRow3Col3
        '
        Me.txtRow3Col3.AllowDrop = True
        Me.txtRow3Col3.BackColor = System.Drawing.Color.LightGray
        Me.txtRow3Col3.Font = New System.Drawing.Font("Segoe UI", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.txtRow3Col3.Location = New System.Drawing.Point(446, 361)
        Me.txtRow3Col3.Multiline = True
        Me.txtRow3Col3.Name = "txtRow3Col3"
        Me.txtRow3Col3.ReadOnly = True
        Me.txtRow3Col3.Size = New System.Drawing.Size(89, 78)
        Me.txtRow3Col3.TabIndex = 10
        Me.txtRow3Col3.TabStop = False
        Me.txtRow3Col3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtRow3Col2
        '
        Me.txtRow3Col2.AllowDrop = True
        Me.txtRow3Col2.BackColor = System.Drawing.Color.LightGray
        Me.txtRow3Col2.Font = New System.Drawing.Font("Segoe UI", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.txtRow3Col2.Location = New System.Drawing.Point(340, 361)
        Me.txtRow3Col2.Multiline = True
        Me.txtRow3Col2.Name = "txtRow3Col2"
        Me.txtRow3Col2.ReadOnly = True
        Me.txtRow3Col2.Size = New System.Drawing.Size(89, 78)
        Me.txtRow3Col2.TabIndex = 9
        Me.txtRow3Col2.TabStop = False
        Me.txtRow3Col2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtRow3Col1
        '
        Me.txtRow3Col1.AllowDrop = True
        Me.txtRow3Col1.BackColor = System.Drawing.Color.LightGray
        Me.txtRow3Col1.Font = New System.Drawing.Font("Segoe UI", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.txtRow3Col1.Location = New System.Drawing.Point(235, 361)
        Me.txtRow3Col1.Multiline = True
        Me.txtRow3Col1.Name = "txtRow3Col1"
        Me.txtRow3Col1.ReadOnly = True
        Me.txtRow3Col1.Size = New System.Drawing.Size(88, 78)
        Me.txtRow3Col1.TabIndex = 8
        Me.txtRow3Col1.TabStop = False
        Me.txtRow3Col1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtX
        '
        Me.txtX.BackColor = System.Drawing.Color.LightGray
        Me.txtX.Font = New System.Drawing.Font("Segoe UI", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.txtX.Location = New System.Drawing.Point(67, 262)
        Me.txtX.Multiline = True
        Me.txtX.Name = "txtX"
        Me.txtX.ReadOnly = True
        Me.txtX.Size = New System.Drawing.Size(88, 78)
        Me.txtX.TabIndex = 11
        Me.txtX.TabStop = False
        Me.txtX.Text = "X"
        Me.txtX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtO
        '
        Me.txtO.BackColor = System.Drawing.Color.LightGray
        Me.txtO.Font = New System.Drawing.Font("Segoe UI", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.txtO.Location = New System.Drawing.Point(628, 262)
        Me.txtO.Multiline = True
        Me.txtO.Name = "txtO"
        Me.txtO.ReadOnly = True
        Me.txtO.Size = New System.Drawing.Size(88, 78)
        Me.txtO.TabIndex = 12
        Me.txtO.TabStop = False
        Me.txtO.Text = "O"
        Me.txtO.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'frmTicTacToe
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(770, 603)
        Me.Controls.Add(Me.txtO)
        Me.Controls.Add(Me.txtX)
        Me.Controls.Add(Me.txtRow3Col3)
        Me.Controls.Add(Me.txtRow3Col2)
        Me.Controls.Add(Me.txtRow3Col1)
        Me.Controls.Add(Me.txtRow2Col3)
        Me.Controls.Add(Me.txtRow2Col2)
        Me.Controls.Add(Me.txtRow2Col1)
        Me.Controls.Add(Me.txtRow1Col3)
        Me.Controls.Add(Me.txtRow1Col2)
        Me.Controls.Add(Me.txtRow1Col1)
        Me.Controls.Add(Me.lblResult)
        Me.Controls.Add(Me.btnReset)
        Me.DoubleBuffered = True
        Me.Name = "frmTicTacToe"
        Me.Text = "Drag 'n' Drop Tic-Tac-Toe"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnReset As Button
    Friend WithEvents lblResult As Label
    Friend WithEvents txtRow1Col1 As TextBox
    Friend WithEvents txtRow1Col2 As TextBox
    Friend WithEvents txtRow1Col3 As TextBox
    Friend WithEvents txtRow2Col3 As TextBox
    Friend WithEvents txtRow2Col2 As TextBox
    Friend WithEvents txtRow2Col1 As TextBox
    Friend WithEvents txtRow3Col3 As TextBox
    Friend WithEvents txtRow3Col2 As TextBox
    Friend WithEvents txtRow3Col1 As TextBox
    Friend WithEvents txtX As TextBox
    Friend WithEvents txtO As TextBox
End Class
