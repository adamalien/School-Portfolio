<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddNewItem
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
        Me.components = New System.ComponentModel.Container()
        Me.lblKey = New System.Windows.Forms.Label()
        Me.lblName = New System.Windows.Forms.Label()
        Me.txtKey = New System.Windows.Forms.TextBox()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.errInvalidItem = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.errInvalidItem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblKey
        '
        Me.lblKey.AutoSize = True
        Me.lblKey.Location = New System.Drawing.Point(12, 9)
        Me.lblKey.Name = "lblKey"
        Me.lblKey.Size = New System.Drawing.Size(29, 15)
        Me.lblKey.TabIndex = 0
        Me.lblKey.Text = "Key:"
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Location = New System.Drawing.Point(232, 9)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(42, 15)
        Me.lblName.TabIndex = 1
        Me.lblName.Text = "Name:"
        '
        'txtKey
        '
        Me.txtKey.Location = New System.Drawing.Point(12, 27)
        Me.txtKey.Name = "txtKey"
        Me.txtKey.Size = New System.Drawing.Size(127, 23)
        Me.txtKey.TabIndex = 2
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(232, 27)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(496, 23)
        Me.txtName.TabIndex = 3
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(116, 93)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(232, 39)
        Me.btnSave.TabIndex = 4
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(434, 93)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(232, 39)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'errInvalidItem
        '
        Me.errInvalidItem.ContainerControl = Me
        '
        'frmAddNewItem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 154)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.txtKey)
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.lblKey)
        Me.Name = "frmAddNewItem"
        Me.Text = "Add New"
        CType(Me.errInvalidItem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblKey As Label
    Friend WithEvents lblName As Label
    Friend WithEvents txtKey As TextBox
    Friend WithEvents txtName As TextBox
    Friend WithEvents btnSave As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents errInvalidItem As ErrorProvider
End Class
