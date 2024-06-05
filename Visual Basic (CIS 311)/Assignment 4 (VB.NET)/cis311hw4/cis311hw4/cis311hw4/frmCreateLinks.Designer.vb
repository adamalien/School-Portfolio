<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCreateLinks
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
        Me.lblLibraries = New System.Windows.Forms.Label()
        Me.lbxLibraries = New System.Windows.Forms.ListBox()
        Me.lblBooksAtCurrentLibrary = New System.Windows.Forms.Label()
        Me.lbxBooksAtCurrentLibrary = New System.Windows.Forms.ListBox()
        Me.lblNonBookMediaAtCurrentLibrary = New System.Windows.Forms.Label()
        Me.lbxNonBookMediaAtCurrentLibrary = New System.Windows.Forms.ListBox()
        Me.lblAllBooks = New System.Windows.Forms.Label()
        Me.lblAllNonBookMedia = New System.Windows.Forms.Label()
        Me.lbxAllBooks = New System.Windows.Forms.ListBox()
        Me.lbxAllNonBookMedia = New System.Windows.Forms.ListBox()
        Me.btnAddBookToCurrentLibrary = New System.Windows.Forms.Button()
        Me.btnRemoveBookFromCurrentLibrary = New System.Windows.Forms.Button()
        Me.btnAddNonBookMediaToCurrentLibrary = New System.Windows.Forms.Button()
        Me.btnRemoveNonBookMediaFromCurrentLibrary = New System.Windows.Forms.Button()
        Me.btnGoBackToHomePage = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblLibraries
        '
        Me.lblLibraries.AutoSize = True
        Me.lblLibraries.Location = New System.Drawing.Point(12, 7)
        Me.lblLibraries.Name = "lblLibraries"
        Me.lblLibraries.Size = New System.Drawing.Size(54, 15)
        Me.lblLibraries.TabIndex = 0
        Me.lblLibraries.Text = "Libraries:"
        '
        'lbxLibraries
        '
        Me.lbxLibraries.FormattingEnabled = True
        Me.lbxLibraries.ItemHeight = 15
        Me.lbxLibraries.Location = New System.Drawing.Point(12, 25)
        Me.lbxLibraries.Name = "lbxLibraries"
        Me.lbxLibraries.Size = New System.Drawing.Size(995, 94)
        Me.lbxLibraries.TabIndex = 1
        '
        'lblBooksAtCurrentLibrary
        '
        Me.lblBooksAtCurrentLibrary.AutoSize = True
        Me.lblBooksAtCurrentLibrary.Location = New System.Drawing.Point(12, 144)
        Me.lblBooksAtCurrentLibrary.Name = "lblBooksAtCurrentLibrary"
        Me.lblBooksAtCurrentLibrary.Size = New System.Drawing.Size(132, 15)
        Me.lblBooksAtCurrentLibrary.TabIndex = 2
        Me.lblBooksAtCurrentLibrary.Text = "Books at current library:"
        '
        'lbxBooksAtCurrentLibrary
        '
        Me.lbxBooksAtCurrentLibrary.FormattingEnabled = True
        Me.lbxBooksAtCurrentLibrary.ItemHeight = 15
        Me.lbxBooksAtCurrentLibrary.Location = New System.Drawing.Point(12, 162)
        Me.lbxBooksAtCurrentLibrary.Name = "lbxBooksAtCurrentLibrary"
        Me.lbxBooksAtCurrentLibrary.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
        Me.lbxBooksAtCurrentLibrary.Size = New System.Drawing.Size(392, 94)
        Me.lbxBooksAtCurrentLibrary.TabIndex = 3
        '
        'lblNonBookMediaAtCurrentLibrary
        '
        Me.lblNonBookMediaAtCurrentLibrary.AutoSize = True
        Me.lblNonBookMediaAtCurrentLibrary.Location = New System.Drawing.Point(12, 285)
        Me.lblNonBookMediaAtCurrentLibrary.Name = "lblNonBookMediaAtCurrentLibrary"
        Me.lblNonBookMediaAtCurrentLibrary.Size = New System.Drawing.Size(196, 15)
        Me.lblNonBookMediaAtCurrentLibrary.TabIndex = 4
        Me.lblNonBookMediaAtCurrentLibrary.Text = "Non-Book Media at Current Library:"
        '
        'lbxNonBookMediaAtCurrentLibrary
        '
        Me.lbxNonBookMediaAtCurrentLibrary.FormattingEnabled = True
        Me.lbxNonBookMediaAtCurrentLibrary.ItemHeight = 15
        Me.lbxNonBookMediaAtCurrentLibrary.Location = New System.Drawing.Point(12, 303)
        Me.lbxNonBookMediaAtCurrentLibrary.Name = "lbxNonBookMediaAtCurrentLibrary"
        Me.lbxNonBookMediaAtCurrentLibrary.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
        Me.lbxNonBookMediaAtCurrentLibrary.Size = New System.Drawing.Size(392, 94)
        Me.lbxNonBookMediaAtCurrentLibrary.TabIndex = 5
        '
        'lblAllBooks
        '
        Me.lblAllBooks.AutoSize = True
        Me.lblAllBooks.Location = New System.Drawing.Point(615, 144)
        Me.lblAllBooks.Name = "lblAllBooks"
        Me.lblAllBooks.Size = New System.Drawing.Size(59, 15)
        Me.lblAllBooks.TabIndex = 6
        Me.lblAllBooks.Text = "All Books:"
        '
        'lblAllNonBookMedia
        '
        Me.lblAllNonBookMedia.AutoSize = True
        Me.lblAllNonBookMedia.Location = New System.Drawing.Point(615, 285)
        Me.lblAllNonBookMedia.Name = "lblAllNonBookMedia"
        Me.lblAllNonBookMedia.Size = New System.Drawing.Size(115, 15)
        Me.lblAllNonBookMedia.TabIndex = 7
        Me.lblAllNonBookMedia.Text = "All Non-Book Media"
        '
        'lbxAllBooks
        '
        Me.lbxAllBooks.FormattingEnabled = True
        Me.lbxAllBooks.ItemHeight = 15
        Me.lbxAllBooks.Location = New System.Drawing.Point(615, 162)
        Me.lbxAllBooks.Name = "lbxAllBooks"
        Me.lbxAllBooks.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
        Me.lbxAllBooks.Size = New System.Drawing.Size(392, 94)
        Me.lbxAllBooks.TabIndex = 8
        '
        'lbxAllNonBookMedia
        '
        Me.lbxAllNonBookMedia.FormattingEnabled = True
        Me.lbxAllNonBookMedia.ItemHeight = 15
        Me.lbxAllNonBookMedia.Location = New System.Drawing.Point(615, 303)
        Me.lbxAllNonBookMedia.Name = "lbxAllNonBookMedia"
        Me.lbxAllNonBookMedia.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
        Me.lbxAllNonBookMedia.Size = New System.Drawing.Size(392, 94)
        Me.lbxAllNonBookMedia.TabIndex = 9
        '
        'btnAddBookToCurrentLibrary
        '
        Me.btnAddBookToCurrentLibrary.Location = New System.Drawing.Point(425, 162)
        Me.btnAddBookToCurrentLibrary.Name = "btnAddBookToCurrentLibrary"
        Me.btnAddBookToCurrentLibrary.Size = New System.Drawing.Size(171, 35)
        Me.btnAddBookToCurrentLibrary.TabIndex = 10
        Me.btnAddBookToCurrentLibrary.Text = "<-"
        Me.btnAddBookToCurrentLibrary.UseVisualStyleBackColor = True
        '
        'btnRemoveBookFromCurrentLibrary
        '
        Me.btnRemoveBookFromCurrentLibrary.Location = New System.Drawing.Point(425, 221)
        Me.btnRemoveBookFromCurrentLibrary.Name = "btnRemoveBookFromCurrentLibrary"
        Me.btnRemoveBookFromCurrentLibrary.Size = New System.Drawing.Size(171, 35)
        Me.btnRemoveBookFromCurrentLibrary.TabIndex = 11
        Me.btnRemoveBookFromCurrentLibrary.Text = "->"
        Me.btnRemoveBookFromCurrentLibrary.UseVisualStyleBackColor = True
        '
        'btnAddNonBookMediaToCurrentLibrary
        '
        Me.btnAddNonBookMediaToCurrentLibrary.Location = New System.Drawing.Point(424, 303)
        Me.btnAddNonBookMediaToCurrentLibrary.Name = "btnAddNonBookMediaToCurrentLibrary"
        Me.btnAddNonBookMediaToCurrentLibrary.Size = New System.Drawing.Size(171, 35)
        Me.btnAddNonBookMediaToCurrentLibrary.TabIndex = 12
        Me.btnAddNonBookMediaToCurrentLibrary.Text = "<-"
        Me.btnAddNonBookMediaToCurrentLibrary.UseVisualStyleBackColor = True
        '
        'btnRemoveNonBookMediaFromCurrentLibrary
        '
        Me.btnRemoveNonBookMediaFromCurrentLibrary.Location = New System.Drawing.Point(424, 362)
        Me.btnRemoveNonBookMediaFromCurrentLibrary.Name = "btnRemoveNonBookMediaFromCurrentLibrary"
        Me.btnRemoveNonBookMediaFromCurrentLibrary.Size = New System.Drawing.Size(171, 35)
        Me.btnRemoveNonBookMediaFromCurrentLibrary.TabIndex = 13
        Me.btnRemoveNonBookMediaFromCurrentLibrary.Text = "->"
        Me.btnRemoveNonBookMediaFromCurrentLibrary.UseVisualStyleBackColor = True
        '
        'btnGoBackToHomePage
        '
        Me.btnGoBackToHomePage.Location = New System.Drawing.Point(12, 424)
        Me.btnGoBackToHomePage.Name = "btnGoBackToHomePage"
        Me.btnGoBackToHomePage.Size = New System.Drawing.Size(995, 35)
        Me.btnGoBackToHomePage.TabIndex = 14
        Me.btnGoBackToHomePage.Text = "Go back to Library and Media Manager Screen"
        Me.btnGoBackToHomePage.UseVisualStyleBackColor = True
        '
        'frmCreateLinks
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1019, 471)
        Me.Controls.Add(Me.btnGoBackToHomePage)
        Me.Controls.Add(Me.btnRemoveNonBookMediaFromCurrentLibrary)
        Me.Controls.Add(Me.btnAddNonBookMediaToCurrentLibrary)
        Me.Controls.Add(Me.btnRemoveBookFromCurrentLibrary)
        Me.Controls.Add(Me.btnAddBookToCurrentLibrary)
        Me.Controls.Add(Me.lbxAllNonBookMedia)
        Me.Controls.Add(Me.lbxAllBooks)
        Me.Controls.Add(Me.lblAllNonBookMedia)
        Me.Controls.Add(Me.lblAllBooks)
        Me.Controls.Add(Me.lbxNonBookMediaAtCurrentLibrary)
        Me.Controls.Add(Me.lblNonBookMediaAtCurrentLibrary)
        Me.Controls.Add(Me.lbxBooksAtCurrentLibrary)
        Me.Controls.Add(Me.lblBooksAtCurrentLibrary)
        Me.Controls.Add(Me.lbxLibraries)
        Me.Controls.Add(Me.lblLibraries)
        Me.Name = "frmCreateLinks"
        Me.Text = "Library and Media Association - Create the Links Between Libraries and Their Medi" &
    "a"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblLibraries As Label
    Friend WithEvents lbxLibraries As ListBox
    Friend WithEvents lblBooksAtCurrentLibrary As Label
    Friend WithEvents lbxBooksAtCurrentLibrary As ListBox
    Friend WithEvents lblNonBookMediaAtCurrentLibrary As Label
    Friend WithEvents lbxNonBookMediaAtCurrentLibrary As ListBox
    Friend WithEvents lblAllBooks As Label
    Friend WithEvents lblAllNonBookMedia As Label
    Friend WithEvents lbxAllBooks As ListBox
    Friend WithEvents lbxAllNonBookMedia As ListBox
    Friend WithEvents btnAddBookToCurrentLibrary As Button
    Friend WithEvents btnRemoveBookFromCurrentLibrary As Button
    Friend WithEvents btnAddNonBookMediaToCurrentLibrary As Button
    Friend WithEvents btnRemoveNonBookMediaFromCurrentLibrary As Button
    Friend WithEvents btnGoBackToHomePage As Button
End Class
