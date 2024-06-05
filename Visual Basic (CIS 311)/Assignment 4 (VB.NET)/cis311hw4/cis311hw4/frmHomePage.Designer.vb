<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmHomePage
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
        Me.lblLibraries = New System.Windows.Forms.Label()
        Me.lblBooks = New System.Windows.Forms.Label()
        Me.lblNonBookMedia = New System.Windows.Forms.Label()
        Me.lbxAllLibraries = New System.Windows.Forms.ListBox()
        Me.lbxAllBooks = New System.Windows.Forms.ListBox()
        Me.lbxAllOtherMedia = New System.Windows.Forms.ListBox()
        Me.btnAddLibrary = New System.Windows.Forms.Button()
        Me.btnDeleteLibrary = New System.Windows.Forms.Button()
        Me.btnAddBook = New System.Windows.Forms.Button()
        Me.btnDeleteBook = New System.Windows.Forms.Button()
        Me.btnAddOtherMedia = New System.Windows.Forms.Button()
        Me.btnDeleteOtherMedia = New System.Windows.Forms.Button()
        Me.btnGoToLinkForm = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblLibraries
        '
        Me.lblLibraries.AutoSize = True
        Me.lblLibraries.Location = New System.Drawing.Point(12, 9)
        Me.lblLibraries.Name = "lblLibraries"
        Me.lblLibraries.Size = New System.Drawing.Size(54, 15)
        Me.lblLibraries.TabIndex = 0
        Me.lblLibraries.Text = "Libraries:"
        '
        'lblBooks
        '
        Me.lblBooks.AutoSize = True
        Me.lblBooks.Location = New System.Drawing.Point(12, 164)
        Me.lblBooks.Name = "lblBooks"
        Me.lblBooks.Size = New System.Drawing.Size(42, 15)
        Me.lblBooks.TabIndex = 1
        Me.lblBooks.Text = "Books:"
        '
        'lblNonBookMedia
        '
        Me.lblNonBookMedia.AutoSize = True
        Me.lblNonBookMedia.Location = New System.Drawing.Point(12, 306)
        Me.lblNonBookMedia.Name = "lblNonBookMedia"
        Me.lblNonBookMedia.Size = New System.Drawing.Size(101, 15)
        Me.lblNonBookMedia.TabIndex = 2
        Me.lblNonBookMedia.Text = "Non-Book Media:"
        '
        'lbxAllLibraries
        '
        Me.lbxAllLibraries.FormattingEnabled = True
        Me.lbxAllLibraries.ItemHeight = 15
        Me.lbxAllLibraries.Location = New System.Drawing.Point(12, 27)
        Me.lbxAllLibraries.Name = "lbxAllLibraries"
        Me.lbxAllLibraries.Size = New System.Drawing.Size(599, 94)
        Me.lbxAllLibraries.TabIndex = 3
        '
        'lbxAllBooks
        '
        Me.lbxAllBooks.FormattingEnabled = True
        Me.lbxAllBooks.ItemHeight = 15
        Me.lbxAllBooks.Location = New System.Drawing.Point(12, 182)
        Me.lbxAllBooks.Name = "lbxAllBooks"
        Me.lbxAllBooks.Size = New System.Drawing.Size(599, 94)
        Me.lbxAllBooks.TabIndex = 4
        '
        'lbxAllOtherMedia
        '
        Me.lbxAllOtherMedia.FormattingEnabled = True
        Me.lbxAllOtherMedia.ItemHeight = 15
        Me.lbxAllOtherMedia.Location = New System.Drawing.Point(12, 324)
        Me.lbxAllOtherMedia.Name = "lbxAllOtherMedia"
        Me.lbxAllOtherMedia.Size = New System.Drawing.Size(599, 94)
        Me.lbxAllOtherMedia.TabIndex = 5
        '
        'btnAddLibrary
        '
        Me.btnAddLibrary.Location = New System.Drawing.Point(627, 27)
        Me.btnAddLibrary.Name = "btnAddLibrary"
        Me.btnAddLibrary.Size = New System.Drawing.Size(161, 37)
        Me.btnAddLibrary.TabIndex = 6
        Me.btnAddLibrary.Text = "Add Library"
        Me.btnAddLibrary.UseVisualStyleBackColor = True
        '
        'btnDeleteLibrary
        '
        Me.btnDeleteLibrary.Location = New System.Drawing.Point(627, 84)
        Me.btnDeleteLibrary.Name = "btnDeleteLibrary"
        Me.btnDeleteLibrary.Size = New System.Drawing.Size(161, 37)
        Me.btnDeleteLibrary.TabIndex = 7
        Me.btnDeleteLibrary.Text = "Delete Library"
        Me.btnDeleteLibrary.UseVisualStyleBackColor = True
        '
        'btnAddBook
        '
        Me.btnAddBook.Location = New System.Drawing.Point(627, 182)
        Me.btnAddBook.Name = "btnAddBook"
        Me.btnAddBook.Size = New System.Drawing.Size(161, 37)
        Me.btnAddBook.TabIndex = 8
        Me.btnAddBook.Text = "Add Book"
        Me.btnAddBook.UseVisualStyleBackColor = True
        '
        'btnDeleteBook
        '
        Me.btnDeleteBook.Location = New System.Drawing.Point(627, 239)
        Me.btnDeleteBook.Name = "btnDeleteBook"
        Me.btnDeleteBook.Size = New System.Drawing.Size(161, 37)
        Me.btnDeleteBook.TabIndex = 9
        Me.btnDeleteBook.Text = "Delete Book"
        Me.btnDeleteBook.UseVisualStyleBackColor = True
        '
        'btnAddOtherMedia
        '
        Me.btnAddOtherMedia.Location = New System.Drawing.Point(627, 324)
        Me.btnAddOtherMedia.Name = "btnAddOtherMedia"
        Me.btnAddOtherMedia.Size = New System.Drawing.Size(161, 37)
        Me.btnAddOtherMedia.TabIndex = 10
        Me.btnAddOtherMedia.Text = "Add Non-Book Media"
        Me.btnAddOtherMedia.UseVisualStyleBackColor = True
        '
        'btnDeleteOtherMedia
        '
        Me.btnDeleteOtherMedia.Location = New System.Drawing.Point(627, 381)
        Me.btnDeleteOtherMedia.Name = "btnDeleteOtherMedia"
        Me.btnDeleteOtherMedia.Size = New System.Drawing.Size(161, 37)
        Me.btnDeleteOtherMedia.TabIndex = 11
        Me.btnDeleteOtherMedia.Text = "Delete Non-Book Media"
        Me.btnDeleteOtherMedia.UseVisualStyleBackColor = True
        '
        'btnGoToLinkForm
        '
        Me.btnGoToLinkForm.Location = New System.Drawing.Point(12, 439)
        Me.btnGoToLinkForm.Name = "btnGoToLinkForm"
        Me.btnGoToLinkForm.Size = New System.Drawing.Size(776, 37)
        Me.btnGoToLinkForm.TabIndex = 12
        Me.btnGoToLinkForm.Text = "Go to Library/Media Association Screen"
        Me.btnGoToLinkForm.UseVisualStyleBackColor = True
        '
        'frmHomePage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 488)
        Me.Controls.Add(Me.btnGoToLinkForm)
        Me.Controls.Add(Me.btnDeleteOtherMedia)
        Me.Controls.Add(Me.btnAddOtherMedia)
        Me.Controls.Add(Me.btnDeleteBook)
        Me.Controls.Add(Me.btnAddBook)
        Me.Controls.Add(Me.btnDeleteLibrary)
        Me.Controls.Add(Me.btnAddLibrary)
        Me.Controls.Add(Me.lbxAllOtherMedia)
        Me.Controls.Add(Me.lbxAllBooks)
        Me.Controls.Add(Me.lbxAllLibraries)
        Me.Controls.Add(Me.lblNonBookMedia)
        Me.Controls.Add(Me.lblBooks)
        Me.Controls.Add(Me.lblLibraries)
        Me.Name = "frmHomePage"
        Me.Text = "Library and Media Manager - Add Libraries and Media Items Here"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblLibraries As Label
    Friend WithEvents lblBooks As Label
    Friend WithEvents lblNonBookMedia As Label
    Friend WithEvents lbxAllLibraries As ListBox
    Friend WithEvents lbxAllBooks As ListBox
    Friend WithEvents lbxAllOtherMedia As ListBox
    Friend WithEvents btnAddLibrary As Button
    Friend WithEvents btnDeleteLibrary As Button
    Friend WithEvents btnAddBook As Button
    Friend WithEvents btnDeleteBook As Button
    Friend WithEvents btnAddOtherMedia As Button
    Friend WithEvents btnDeleteOtherMedia As Button
    Friend WithEvents btnGoToLinkForm As Button
End Class
