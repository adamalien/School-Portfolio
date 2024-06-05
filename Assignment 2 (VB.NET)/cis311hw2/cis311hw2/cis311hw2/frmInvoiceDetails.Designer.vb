<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInvoiceDetails
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
        Me.btnChange = New System.Windows.Forms.Button()
        Me.btnProcess = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.rtbOrderDetails = New System.Windows.Forms.RichTextBox()
        Me.SuspendLayout()
        '
        'btnChange
        '
        Me.btnChange.Location = New System.Drawing.Point(12, 409)
        Me.btnChange.Name = "btnChange"
        Me.btnChange.Size = New System.Drawing.Size(210, 62)
        Me.btnChange.TabIndex = 0
        Me.btnChange.Text = "Change Order"
        Me.btnChange.UseVisualStyleBackColor = True
        '
        'btnProcess
        '
        Me.btnProcess.Location = New System.Drawing.Point(302, 409)
        Me.btnProcess.Name = "btnProcess"
        Me.btnProcess.Size = New System.Drawing.Size(210, 62)
        Me.btnProcess.TabIndex = 1
        Me.btnProcess.Text = "Process Order"
        Me.btnProcess.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(584, 411)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(210, 60)
        Me.btnExit.TabIndex = 2
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'rtbOrderDetails
        '
        Me.rtbOrderDetails.Location = New System.Drawing.Point(12, 11)
        Me.rtbOrderDetails.Name = "rtbOrderDetails"
        Me.rtbOrderDetails.ReadOnly = True
        Me.rtbOrderDetails.Size = New System.Drawing.Size(781, 386)
        Me.rtbOrderDetails.TabIndex = 3
        Me.rtbOrderDetails.Text = ""
        '
        'frmInvoiceDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(806, 483)
        Me.Controls.Add(Me.rtbOrderDetails)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnProcess)
        Me.Controls.Add(Me.btnChange)
        Me.Name = "frmInvoiceDetails"
        Me.Text = "Invoice Details"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnChange As Button
    Friend WithEvents btnProcess As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents rtbOrderDetails As RichTextBox
End Class
