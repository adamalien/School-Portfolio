<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmView
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.grbCapacities = New System.Windows.Forms.GroupBox()
        Me.chkBytes = New System.Windows.Forms.CheckBox()
        Me.chkWireless = New System.Windows.Forms.CheckBox()
        Me.lblGb = New System.Windows.Forms.Label()
        Me.txtHd = New System.Windows.Forms.TextBox()
        Me.txtVram = New System.Windows.Forms.TextBox()
        Me.txtRam = New System.Windows.Forms.TextBox()
        Me.txtForm = New System.Windows.Forms.TextBox()
        Me.lblHd = New System.Windows.Forms.Label()
        Me.lblVram = New System.Windows.Forms.Label()
        Me.lblRam = New System.Windows.Forms.Label()
        Me.lblForm = New System.Windows.Forms.Label()
        Me.txtVideo = New System.Windows.Forms.TextBox()
        Me.txtProcessor = New System.Windows.Forms.TextBox()
        Me.txtManufacturer = New System.Windows.Forms.TextBox()
        Me.lblVideo = New System.Windows.Forms.Label()
        Me.lblProcessor = New System.Windows.Forms.Label()
        Me.lblManufacturer = New System.Windows.Forms.Label()
        Me.btnPrev = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.grbCapacities.SuspendLayout()
        Me.SuspendLayout()
        '
        'grbCapacities
        '
        Me.grbCapacities.Controls.Add(Me.chkBytes)
        Me.grbCapacities.Location = New System.Drawing.Point(783, 175)
        Me.grbCapacities.Name = "grbCapacities"
        Me.grbCapacities.Size = New System.Drawing.Size(81, 90)
        Me.grbCapacities.TabIndex = 36
        Me.grbCapacities.TabStop = False
        Me.grbCapacities.Text = "Capacities"
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
        'chkWireless
        '
        Me.chkWireless.AutoSize = True
        Me.chkWireless.Enabled = False
        Me.chkWireless.Location = New System.Drawing.Point(121, 246)
        Me.chkWireless.Name = "chkWireless"
        Me.chkWireless.Size = New System.Drawing.Size(74, 19)
        Me.chkWireless.TabIndex = 35
        Me.chkWireless.Text = "Wireless?"
        Me.chkWireless.UseVisualStyleBackColor = True
        '
        'lblGb
        '
        Me.lblGb.AutoSize = True
        Me.lblGb.Location = New System.Drawing.Point(728, 101)
        Me.lblGb.Name = "lblGb"
        Me.lblGb.Size = New System.Drawing.Size(22, 15)
        Me.lblGb.TabIndex = 34
        Me.lblGb.Text = "GB"
        '
        'txtHd
        '
        Me.txtHd.Location = New System.Drawing.Point(463, 242)
        Me.txtHd.Name = "txtHd"
        Me.txtHd.ReadOnly = True
        Me.txtHd.Size = New System.Drawing.Size(259, 23)
        Me.txtHd.TabIndex = 33
        Me.txtHd.Text = "0"
        '
        'txtVram
        '
        Me.txtVram.Location = New System.Drawing.Point(463, 172)
        Me.txtVram.Name = "txtVram"
        Me.txtVram.ReadOnly = True
        Me.txtVram.Size = New System.Drawing.Size(259, 23)
        Me.txtVram.TabIndex = 32
        Me.txtVram.Text = "0"
        '
        'txtRam
        '
        Me.txtRam.Location = New System.Drawing.Point(463, 95)
        Me.txtRam.Name = "txtRam"
        Me.txtRam.ReadOnly = True
        Me.txtRam.Size = New System.Drawing.Size(264, 23)
        Me.txtRam.TabIndex = 31
        Me.txtRam.Text = "0"
        '
        'txtForm
        '
        Me.txtForm.Location = New System.Drawing.Point(463, 30)
        Me.txtForm.Name = "txtForm"
        Me.txtForm.ReadOnly = True
        Me.txtForm.Size = New System.Drawing.Size(264, 23)
        Me.txtForm.TabIndex = 30
        '
        'lblHd
        '
        Me.lblHd.AutoSize = True
        Me.lblHd.Location = New System.Drawing.Point(414, 245)
        Me.lblHd.Name = "lblHd"
        Me.lblHd.Size = New System.Drawing.Size(27, 15)
        Me.lblHd.TabIndex = 29
        Me.lblHd.Text = "HD:"
        '
        'lblVram
        '
        Me.lblVram.AutoSize = True
        Me.lblVram.Location = New System.Drawing.Point(414, 175)
        Me.lblVram.Name = "lblVram"
        Me.lblVram.Size = New System.Drawing.Size(43, 15)
        Me.lblVram.TabIndex = 28
        Me.lblVram.Text = "VRAM:"
        '
        'lblRam
        '
        Me.lblRam.AutoSize = True
        Me.lblRam.Location = New System.Drawing.Point(414, 98)
        Me.lblRam.Name = "lblRam"
        Me.lblRam.Size = New System.Drawing.Size(36, 15)
        Me.lblRam.TabIndex = 27
        Me.lblRam.Text = "RAM:"
        '
        'lblForm
        '
        Me.lblForm.AutoSize = True
        Me.lblForm.Location = New System.Drawing.Point(414, 34)
        Me.lblForm.Name = "lblForm"
        Me.lblForm.Size = New System.Drawing.Size(38, 15)
        Me.lblForm.TabIndex = 26
        Me.lblForm.Text = "Form:"
        '
        'txtVideo
        '
        Me.txtVideo.Location = New System.Drawing.Point(121, 172)
        Me.txtVideo.Name = "txtVideo"
        Me.txtVideo.ReadOnly = True
        Me.txtVideo.Size = New System.Drawing.Size(264, 23)
        Me.txtVideo.TabIndex = 25
        '
        'txtProcessor
        '
        Me.txtProcessor.Location = New System.Drawing.Point(121, 98)
        Me.txtProcessor.Name = "txtProcessor"
        Me.txtProcessor.ReadOnly = True
        Me.txtProcessor.Size = New System.Drawing.Size(264, 23)
        Me.txtProcessor.TabIndex = 24
        '
        'txtManufacturer
        '
        Me.txtManufacturer.Location = New System.Drawing.Point(121, 30)
        Me.txtManufacturer.Name = "txtManufacturer"
        Me.txtManufacturer.ReadOnly = True
        Me.txtManufacturer.Size = New System.Drawing.Size(264, 23)
        Me.txtManufacturer.TabIndex = 23
        '
        'lblVideo
        '
        Me.lblVideo.AutoSize = True
        Me.lblVideo.Location = New System.Drawing.Point(33, 175)
        Me.lblVideo.Name = "lblVideo"
        Me.lblVideo.Size = New System.Drawing.Size(40, 15)
        Me.lblVideo.TabIndex = 22
        Me.lblVideo.Text = "Video:"
        '
        'lblProcessor
        '
        Me.lblProcessor.AutoSize = True
        Me.lblProcessor.Location = New System.Drawing.Point(33, 98)
        Me.lblProcessor.Name = "lblProcessor"
        Me.lblProcessor.Size = New System.Drawing.Size(61, 15)
        Me.lblProcessor.TabIndex = 21
        Me.lblProcessor.Text = "Processor:"
        '
        'lblManufacturer
        '
        Me.lblManufacturer.AutoSize = True
        Me.lblManufacturer.Location = New System.Drawing.Point(33, 33)
        Me.lblManufacturer.Name = "lblManufacturer"
        Me.lblManufacturer.Size = New System.Drawing.Size(82, 15)
        Me.lblManufacturer.TabIndex = 20
        Me.lblManufacturer.Text = "Manufacturer:"
        '
        'btnPrev
        '
        Me.btnPrev.Location = New System.Drawing.Point(33, 326)
        Me.btnPrev.Name = "btnPrev"
        Me.btnPrev.Size = New System.Drawing.Size(152, 76)
        Me.btnPrev.TabIndex = 37
        Me.btnPrev.Text = "<<"
        Me.btnPrev.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(199, 326)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(518, 76)
        Me.btnAdd.TabIndex = 38
        Me.btnAdd.Text = "Add New Inventory Item"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnNext
        '
        Me.btnNext.Location = New System.Drawing.Point(735, 326)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(152, 76)
        Me.btnNext.TabIndex = 39
        Me.btnNext.Text = ">>"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'frmView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(913, 437)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnPrev)
        Me.Controls.Add(Me.grbCapacities)
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
        Me.Name = "frmView"
        Me.Text = "IT Inventory Tracker - Item"
        Me.grbCapacities.ResumeLayout(False)
        Me.grbCapacities.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents grbCapacities As GroupBox
    Friend WithEvents chkBytes As CheckBox
    Friend WithEvents chkWireless As CheckBox
    Friend WithEvents lblGb As Label
    Friend WithEvents txtHd As TextBox
    Friend WithEvents txtVram As TextBox
    Friend WithEvents txtRam As TextBox
    Friend WithEvents txtForm As TextBox
    Friend WithEvents lblHd As Label
    Friend WithEvents lblVram As Label
    Friend WithEvents lblRam As Label
    Friend WithEvents lblForm As Label
    Friend WithEvents txtVideo As TextBox
    Friend WithEvents txtProcessor As TextBox
    Friend WithEvents txtManufacturer As TextBox
    Friend WithEvents lblVideo As Label
    Friend WithEvents lblProcessor As Label
    Friend WithEvents lblManufacturer As Label
    Friend WithEvents btnPrev As Button
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnNext As Button
End Class
