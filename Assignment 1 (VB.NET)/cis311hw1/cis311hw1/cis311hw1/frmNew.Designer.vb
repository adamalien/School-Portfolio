<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmNew
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
        Me.lblManufacturer = New System.Windows.Forms.Label()
        Me.lblProcessor = New System.Windows.Forms.Label()
        Me.lblVideo = New System.Windows.Forms.Label()
        Me.txtManufacturer = New System.Windows.Forms.TextBox()
        Me.txtProcessor = New System.Windows.Forms.TextBox()
        Me.txtVideo = New System.Windows.Forms.TextBox()
        Me.lblForm = New System.Windows.Forms.Label()
        Me.lblRam = New System.Windows.Forms.Label()
        Me.lblVram = New System.Windows.Forms.Label()
        Me.lblHd = New System.Windows.Forms.Label()
        Me.txtForm = New System.Windows.Forms.TextBox()
        Me.txtRam = New System.Windows.Forms.TextBox()
        Me.txtVram = New System.Windows.Forms.TextBox()
        Me.txtHd = New System.Windows.Forms.TextBox()
        Me.lblGb = New System.Windows.Forms.Label()
        Me.chkWireless = New System.Windows.Forms.CheckBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.chkBytes = New System.Windows.Forms.CheckBox()
        Me.grbCapacities = New System.Windows.Forms.GroupBox()
        Me.grbCapacities.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblManufacturer
        '
        Me.lblManufacturer.AutoSize = True
        Me.lblManufacturer.Location = New System.Drawing.Point(28, 31)
        Me.lblManufacturer.Name = "lblManufacturer"
        Me.lblManufacturer.Size = New System.Drawing.Size(82, 15)
        Me.lblManufacturer.TabIndex = 0
        Me.lblManufacturer.Text = "Manufacturer:"
        '
        'lblProcessor
        '
        Me.lblProcessor.AutoSize = True
        Me.lblProcessor.Location = New System.Drawing.Point(28, 96)
        Me.lblProcessor.Name = "lblProcessor"
        Me.lblProcessor.Size = New System.Drawing.Size(61, 15)
        Me.lblProcessor.TabIndex = 1
        Me.lblProcessor.Text = "Processor:"
        '
        'lblVideo
        '
        Me.lblVideo.AutoSize = True
        Me.lblVideo.Location = New System.Drawing.Point(28, 173)
        Me.lblVideo.Name = "lblVideo"
        Me.lblVideo.Size = New System.Drawing.Size(40, 15)
        Me.lblVideo.TabIndex = 2
        Me.lblVideo.Text = "Video:"
        '
        'txtManufacturer
        '
        Me.txtManufacturer.Location = New System.Drawing.Point(116, 28)
        Me.txtManufacturer.Name = "txtManufacturer"
        Me.txtManufacturer.Size = New System.Drawing.Size(264, 23)
        Me.txtManufacturer.TabIndex = 3
        '
        'txtProcessor
        '
        Me.txtProcessor.Location = New System.Drawing.Point(116, 96)
        Me.txtProcessor.Name = "txtProcessor"
        Me.txtProcessor.Size = New System.Drawing.Size(264, 23)
        Me.txtProcessor.TabIndex = 4
        '
        'txtVideo
        '
        Me.txtVideo.Location = New System.Drawing.Point(116, 170)
        Me.txtVideo.Name = "txtVideo"
        Me.txtVideo.Size = New System.Drawing.Size(264, 23)
        Me.txtVideo.TabIndex = 5
        '
        'lblForm
        '
        Me.lblForm.AutoSize = True
        Me.lblForm.Location = New System.Drawing.Point(409, 32)
        Me.lblForm.Name = "lblForm"
        Me.lblForm.Size = New System.Drawing.Size(38, 15)
        Me.lblForm.TabIndex = 6
        Me.lblForm.Text = "Form:"
        '
        'lblRam
        '
        Me.lblRam.AutoSize = True
        Me.lblRam.Location = New System.Drawing.Point(409, 96)
        Me.lblRam.Name = "lblRam"
        Me.lblRam.Size = New System.Drawing.Size(36, 15)
        Me.lblRam.TabIndex = 7
        Me.lblRam.Text = "RAM:"
        '
        'lblVram
        '
        Me.lblVram.AutoSize = True
        Me.lblVram.Location = New System.Drawing.Point(409, 173)
        Me.lblVram.Name = "lblVram"
        Me.lblVram.Size = New System.Drawing.Size(43, 15)
        Me.lblVram.TabIndex = 8
        Me.lblVram.Text = "VRAM:"
        '
        'lblHd
        '
        Me.lblHd.AutoSize = True
        Me.lblHd.Location = New System.Drawing.Point(409, 243)
        Me.lblHd.Name = "lblHd"
        Me.lblHd.Size = New System.Drawing.Size(27, 15)
        Me.lblHd.TabIndex = 9
        Me.lblHd.Text = "HD:"
        '
        'txtForm
        '
        Me.txtForm.Location = New System.Drawing.Point(458, 28)
        Me.txtForm.Name = "txtForm"
        Me.txtForm.Size = New System.Drawing.Size(264, 23)
        Me.txtForm.TabIndex = 10
        '
        'txtRam
        '
        Me.txtRam.Location = New System.Drawing.Point(458, 93)
        Me.txtRam.Name = "txtRam"
        Me.txtRam.Size = New System.Drawing.Size(264, 23)
        Me.txtRam.TabIndex = 11
        Me.txtRam.Text = "0"
        '
        'txtVram
        '
        Me.txtVram.Location = New System.Drawing.Point(458, 170)
        Me.txtVram.Name = "txtVram"
        Me.txtVram.Size = New System.Drawing.Size(259, 23)
        Me.txtVram.TabIndex = 12
        Me.txtVram.Text = "0"
        '
        'txtHd
        '
        Me.txtHd.Location = New System.Drawing.Point(458, 240)
        Me.txtHd.Name = "txtHd"
        Me.txtHd.Size = New System.Drawing.Size(259, 23)
        Me.txtHd.TabIndex = 13
        Me.txtHd.Text = "0"
        '
        'lblGb
        '
        Me.lblGb.AutoSize = True
        Me.lblGb.Location = New System.Drawing.Point(723, 99)
        Me.lblGb.Name = "lblGb"
        Me.lblGb.Size = New System.Drawing.Size(22, 15)
        Me.lblGb.TabIndex = 14
        Me.lblGb.Text = "GB"
        '
        'chkWireless
        '
        Me.chkWireless.AutoSize = True
        Me.chkWireless.Location = New System.Drawing.Point(116, 244)
        Me.chkWireless.Name = "chkWireless"
        Me.chkWireless.Size = New System.Drawing.Size(74, 19)
        Me.chkWireless.TabIndex = 15
        Me.chkWireless.Text = "Wireless?"
        Me.chkWireless.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(127, 346)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(204, 57)
        Me.btnSave.TabIndex = 16
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(541, 346)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(204, 57)
        Me.btnCancel.TabIndex = 17
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'chkBytes
        '
        Me.chkBytes.AutoSize = True
        Me.chkBytes.Location = New System.Drawing.Point(6, 37)
        Me.chkBytes.Name = "chkBytes"
        Me.chkBytes.Size = New System.Drawing.Size(54, 19)
        Me.chkBytes.TabIndex = 18
        Me.chkBytes.Text = "Bytes"
        Me.chkBytes.UseVisualStyleBackColor = True
        '
        'grbCapacities
        '
        Me.grbCapacities.Controls.Add(Me.chkBytes)
        Me.grbCapacities.Location = New System.Drawing.Point(778, 173)
        Me.grbCapacities.Name = "grbCapacities"
        Me.grbCapacities.Size = New System.Drawing.Size(81, 90)
        Me.grbCapacities.TabIndex = 19
        Me.grbCapacities.TabStop = False
        Me.grbCapacities.Text = "Capacities"
        '
        'frmNew
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(913, 437)
        Me.Controls.Add(Me.grbCapacities)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.chkWireless)
        Me.Controls.Add(Me.lblGb)
        Me.Controls.Add(Me.txtHd)
        Me.Controls.Add(Me.txtVram)
        Me.Controls.Add(Me.txtRam)
        Me.Controls.Add(Me.txtForm)
        Me.Controls.Add(Me.lblHd)
        Me.Controls.Add(Me.lblVram)
        Me.Controls.Add(Me.lblRam)
        Me.Controls.Add(Me.lblForm)
        Me.Controls.Add(Me.txtVideo)
        Me.Controls.Add(Me.txtProcessor)
        Me.Controls.Add(Me.txtManufacturer)
        Me.Controls.Add(Me.lblVideo)
        Me.Controls.Add(Me.lblProcessor)
        Me.Controls.Add(Me.lblManufacturer)
        Me.Name = "frmNew"
        Me.Text = "IT Inventory Tacker - New Item Entry Screen"
        Me.grbCapacities.ResumeLayout(False)
        Me.grbCapacities.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblManufacturer As Label
    Friend WithEvents lblProcessor As Label
    Friend WithEvents lblVideo As Label
    Friend WithEvents txtManufacturer As TextBox
    Friend WithEvents txtProcessor As TextBox
    Friend WithEvents txtVideo As TextBox
    Friend WithEvents lblForm As Label
    Friend WithEvents lblRam As Label
    Friend WithEvents lblVram As Label
    Friend WithEvents lblHd As Label
    Friend WithEvents txtForm As TextBox
    Friend WithEvents txtRam As TextBox
    Friend WithEvents txtVram As TextBox
    Friend WithEvents txtHd As TextBox
    Friend WithEvents lblGb As Label
    Friend WithEvents chkWireless As CheckBox
    Friend WithEvents btnSave As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents chkBytes As CheckBox
    Friend WithEvents grbCapacities As GroupBox
End Class
