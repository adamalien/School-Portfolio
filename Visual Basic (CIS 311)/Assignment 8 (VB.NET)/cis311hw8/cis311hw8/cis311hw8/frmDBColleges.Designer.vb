<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmDBColleges
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
        gbxCollegeInfo = New GroupBox()
        pnlNavigation = New Panel()
        btnUpdate = New Button()
        btnDelete = New Button()
        btnAdd = New Button()
        btnNext = New Button()
        btnLast = New Button()
        btnPrevious = New Button()
        btnFirst = New Button()
        btnCancel = New Button()
        btnSave = New Button()
        txtIDNumber = New TextBox()
        txtZipCode = New TextBox()
        txtState = New TextBox()
        txtCity = New TextBox()
        txtStreet = New TextBox()
        txtName = New TextBox()
        lblIDNumber = New Label()
        lblAddress = New Label()
        lblName = New Label()
        dgvDegreesForCollege = New DataGridView()
        gbxCollegeInfo.SuspendLayout()
        pnlNavigation.SuspendLayout()
        CType(dgvDegreesForCollege, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' gbxCollegeInfo
        ' 
        gbxCollegeInfo.Controls.Add(pnlNavigation)
        gbxCollegeInfo.Controls.Add(btnCancel)
        gbxCollegeInfo.Controls.Add(btnSave)
        gbxCollegeInfo.Controls.Add(txtIDNumber)
        gbxCollegeInfo.Controls.Add(txtZipCode)
        gbxCollegeInfo.Controls.Add(txtState)
        gbxCollegeInfo.Controls.Add(txtCity)
        gbxCollegeInfo.Controls.Add(txtStreet)
        gbxCollegeInfo.Controls.Add(txtName)
        gbxCollegeInfo.Controls.Add(lblIDNumber)
        gbxCollegeInfo.Controls.Add(lblAddress)
        gbxCollegeInfo.Controls.Add(lblName)
        gbxCollegeInfo.Location = New Point(12, 12)
        gbxCollegeInfo.Name = "gbxCollegeInfo"
        gbxCollegeInfo.Size = New Size(683, 289)
        gbxCollegeInfo.TabIndex = 0
        gbxCollegeInfo.TabStop = False
        gbxCollegeInfo.Text = "College Information:"
        ' 
        ' pnlNavigation
        ' 
        pnlNavigation.Controls.Add(btnUpdate)
        pnlNavigation.Controls.Add(btnDelete)
        pnlNavigation.Controls.Add(btnAdd)
        pnlNavigation.Controls.Add(btnNext)
        pnlNavigation.Controls.Add(btnLast)
        pnlNavigation.Controls.Add(btnPrevious)
        pnlNavigation.Controls.Add(btnFirst)
        pnlNavigation.Location = New Point(22, 129)
        pnlNavigation.Name = "pnlNavigation"
        pnlNavigation.Size = New Size(633, 96)
        pnlNavigation.TabIndex = 16
        ' 
        ' btnUpdate
        ' 
        btnUpdate.Location = New Point(381, 22)
        btnUpdate.Name = "btnUpdate"
        btnUpdate.Size = New Size(83, 55)
        btnUpdate.TabIndex = 11
        btnUpdate.Text = "Update"
        btnUpdate.UseVisualStyleBackColor = True
        ' 
        ' btnDelete
        ' 
        btnDelete.Location = New Point(272, 22)
        btnDelete.Name = "btnDelete"
        btnDelete.Size = New Size(83, 55)
        btnDelete.TabIndex = 10
        btnDelete.Text = "Delete"
        btnDelete.UseVisualStyleBackColor = True
        ' 
        ' btnAdd
        ' 
        btnAdd.Location = New Point(160, 22)
        btnAdd.Name = "btnAdd"
        btnAdd.Size = New Size(83, 55)
        btnAdd.TabIndex = 9
        btnAdd.Text = "Add"
        btnAdd.UseVisualStyleBackColor = True
        ' 
        ' btnNext
        ' 
        btnNext.Location = New Point(519, 22)
        btnNext.Name = "btnNext"
        btnNext.Size = New Size(39, 55)
        btnNext.TabIndex = 12
        btnNext.Text = ">>"
        btnNext.UseVisualStyleBackColor = True
        ' 
        ' btnLast
        ' 
        btnLast.Location = New Point(564, 22)
        btnLast.Name = "btnLast"
        btnLast.Size = New Size(39, 55)
        btnLast.TabIndex = 13
        btnLast.Text = "|>"
        btnLast.UseVisualStyleBackColor = True
        ' 
        ' btnPrevious
        ' 
        btnPrevious.Location = New Point(64, 22)
        btnPrevious.Name = "btnPrevious"
        btnPrevious.Size = New Size(39, 55)
        btnPrevious.TabIndex = 8
        btnPrevious.Text = "<<"
        btnPrevious.UseVisualStyleBackColor = True
        ' 
        ' btnFirst
        ' 
        btnFirst.Location = New Point(19, 22)
        btnFirst.Name = "btnFirst"
        btnFirst.Size = New Size(39, 55)
        btnFirst.TabIndex = 7
        btnFirst.Text = "<|"
        btnFirst.UseVisualStyleBackColor = True
        ' 
        ' btnCancel
        ' 
        btnCancel.Location = New Point(370, 236)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(116, 31)
        btnCancel.TabIndex = 15
        btnCancel.Text = "Cancel"
        btnCancel.UseVisualStyleBackColor = True
        btnCancel.Visible = False
        ' 
        ' btnSave
        ' 
        btnSave.Location = New Point(182, 236)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(116, 31)
        btnSave.TabIndex = 14
        btnSave.Text = "Save"
        btnSave.UseVisualStyleBackColor = True
        btnSave.Visible = False
        ' 
        ' txtIDNumber
        ' 
        txtIDNumber.Location = New Point(586, 22)
        txtIDNumber.Name = "txtIDNumber"
        txtIDNumber.ReadOnly = True
        txtIDNumber.Size = New Size(58, 23)
        txtIDNumber.TabIndex = 2
        txtIDNumber.TabStop = False
        ' 
        ' txtZipCode
        ' 
        txtZipCode.Location = New Point(314, 88)
        txtZipCode.Name = "txtZipCode"
        txtZipCode.ReadOnly = True
        txtZipCode.Size = New Size(172, 23)
        txtZipCode.TabIndex = 6
        ' 
        ' txtState
        ' 
        txtState.Location = New Point(250, 88)
        txtState.Name = "txtState"
        txtState.ReadOnly = True
        txtState.Size = New Size(58, 23)
        txtState.TabIndex = 5
        ' 
        ' txtCity
        ' 
        txtCity.Location = New Point(79, 88)
        txtCity.Name = "txtCity"
        txtCity.ReadOnly = True
        txtCity.Size = New Size(165, 23)
        txtCity.TabIndex = 4
        ' 
        ' txtStreet
        ' 
        txtStreet.Location = New Point(79, 59)
        txtStreet.Name = "txtStreet"
        txtStreet.ReadOnly = True
        txtStreet.Size = New Size(407, 23)
        txtStreet.TabIndex = 3
        ' 
        ' txtName
        ' 
        txtName.Location = New Point(79, 23)
        txtName.Name = "txtName"
        txtName.ReadOnly = True
        txtName.Size = New Size(407, 23)
        txtName.TabIndex = 1
        ' 
        ' lblIDNumber
        ' 
        lblIDNumber.AutoSize = True
        lblIDNumber.Location = New Point(512, 26)
        lblIDNumber.Name = "lblIDNumber"
        lblIDNumber.Size = New Size(68, 15)
        lblIDNumber.TabIndex = 2
        lblIDNumber.Text = "ID Number:"
        ' 
        ' lblAddress
        ' 
        lblAddress.AutoSize = True
        lblAddress.Location = New Point(16, 62)
        lblAddress.Name = "lblAddress"
        lblAddress.Size = New Size(52, 15)
        lblAddress.TabIndex = 1
        lblAddress.Text = "Address:"
        ' 
        ' lblName
        ' 
        lblName.AutoSize = True
        lblName.Location = New Point(16, 26)
        lblName.Name = "lblName"
        lblName.Size = New Size(42, 15)
        lblName.TabIndex = 0
        lblName.Text = "Name:"
        ' 
        ' dgvDegreesForCollege
        ' 
        dgvDegreesForCollege.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvDegreesForCollege.Location = New Point(12, 307)
        dgvDegreesForCollege.Name = "dgvDegreesForCollege"
        dgvDegreesForCollege.RowTemplate.Height = 25
        dgvDegreesForCollege.Size = New Size(683, 272)
        dgvDegreesForCollege.TabIndex = 1
        ' 
        ' frmDBColleges
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(707, 591)
        Controls.Add(dgvDegreesForCollege)
        Controls.Add(gbxCollegeInfo)
        Name = "frmDBColleges"
        Text = "Colleges Browser"
        gbxCollegeInfo.ResumeLayout(False)
        gbxCollegeInfo.PerformLayout()
        pnlNavigation.ResumeLayout(False)
        CType(dgvDegreesForCollege, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents gbxCollegeInfo As GroupBox
    Friend WithEvents txtName As TextBox
    Friend WithEvents lblIDNumber As Label
    Friend WithEvents lblAddress As Label
    Friend WithEvents lblName As Label
    Friend WithEvents txtZipCode As TextBox
    Friend WithEvents txtState As TextBox
    Friend WithEvents txtCity As TextBox
    Friend WithEvents txtStreet As TextBox
    Friend WithEvents dgvDegreesForCollege As DataGridView
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents pnlNavigation As Panel
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnNext As Button
    Friend WithEvents btnLast As Button
    Friend WithEvents btnPrevious As Button
    Friend WithEvents btnFirst As Button
    Friend WithEvents txtIDNumber As TextBox
End Class
