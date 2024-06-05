Imports System.ComponentModel

Public Class frmAddNewItem
    '------------------------------------------------------------
    '-                File Name : frmAddNewItem                 - 
    '-                Part of Project: cis311hw4                -
    '------------------------------------------------------------
    '-                Written By: Adam Cossin                   -
    '-                Written On: Feb, 3rd 2023                 -
    '------------------------------------------------------------
    '- File Purpose:                                            -
    '- This file contains the application form where the user   - 
    '- is able to manually add an item.                         -
    '------------------------------------------------------------

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        '------------------------------------------------------------
        '-                Subprogram Name: btnCancel_Click          -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: Feb, 3rd 2023                 -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine is called whenever the user clicks the   -
        '- cancel button. The form will close.                      –
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- sender – Identifies which particular control raised the  –
        '-          click event                                     - 
        '- e – Holds the EventArgs object sent to the routine       -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------

        Me.Close() 'closes the form
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        '------------------------------------------------------------
        '-                Subprogram Name: btnSave_Click            -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: Feb, 3rd 2023                 -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine is called whenever the user clicks the   -
        '- save button. The item will be added to its' relevant     -
        '- dictionary.                                              -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- sender – Identifies which particular control raised the  –
        '-          click event                                     - 
        '- e – Holds the EventArgs object sent to the routine       -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------

        If (Me.Text.Contains("Library")) Then 'if the form title contains 'library', it means a library should be added
            addLibrary() 'calls addLibrary
            frmHomePage.Show() 'shows the home form
        ElseIf (Me.Text.Contains("Non-Book")) Then 'if the form title contains 'non-book', it means a non-book media item should be added
            addOtherMedia() 'calls addOtherMedia
            frmHomePage.Show() 'shows the home form
        Else 'the only other option is for a book to be added
            addBook() 'calls addBook
            frmHomePage.Show() 'shows the home form
        End If
    End Sub

    Private Sub addLibrary()
        '------------------------------------------------------------
        '-                Subprogram Name: addLibrary               -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: Feb, 3rd 2023                 -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine is called whenever a library needs to be -
        '- added to its relevant dictionaries.                      -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- (None)                                                   -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- dicTemp - dictionary for the library to be added.        -
        '------------------------------------------------------------
        Me.errInvalidItem.Clear() 'clears the error provider data
        If frmHomePage.dicLibraries.ContainsKey(txtKey.Text) Then 'if the key is already present in the 'dicLibraries' dictionary, we cannot add it
            Me.errInvalidItem.SetError(Me.txtKey, "Invalid Key - Cannot add a duplicate!") 'display an error message
        ElseIf (frmHomePage.dicLibraries.ContainsValue(txtName.Text)) Then 'if the value is already present in the 'dicLibraries' dictionary, we will not add it
            Me.errInvalidItem.SetError(Me.txtName, "Invalid Name - Cannot add a duplicate!") 'display an error message
        Else 'otherwise, the library can be added
            frmHomePage.dicLibraries.Add(txtKey.Text, txtName.Text) 'add the library to the dictionary of libraries
            Dim dicTemp As New SortedDictionary(Of String, String) 'create a new library
            dicTemp.Add(txtKey.Text, txtName.Text) 'add the key and value to the library
            frmHomePage.dicLibrariesAndMedia.Add(Me.txtKey.Text, dicTemp) 'add the library to the dictionary
            Me.Close() 'close the form
        End If
    End Sub

    Private Sub addBook()
        '------------------------------------------------------------
        '-                Subprogram Name: addBook                  -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: Feb, 3rd 2023                 -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine is called whenever a book needs to be    -
        '- added to its relevant dictionaries.                      -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- (None)                                                   -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        Me.errInvalidItem.Clear() 'clears the error provider data
        If frmHomePage.dicAllBooks.ContainsKey(txtKey.Text) Then 'if the key is already present in the 'dicAllBooks' dictionary, we cannot add it
            Me.errInvalidItem.SetError(Me.txtKey, "Invalid Key - Cannot add a duplicate!") 'display an error message
        ElseIf (frmHomePage.dicAllBooks.ContainsValue(txtName.Text)) Then 'if the value is already present in the 'dicAllBooks' dictionary, we will not add it
            Me.errInvalidItem.SetError(Me.txtName, "Invalid Name - Cannot add a duplicate!") 'display an error message
        Else 'Otherwise, the book can be added
            frmHomePage.dicAllBooks.Add(txtKey.Text, txtName.Text) 'add the book to the dictionary
            Me.Close() 'close the form
        End If
    End Sub

    Private Sub addOtherMedia()
        '------------------------------------------------------------
        '-                Subprogram Name: addOtherMedia            -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: Feb, 3rd 2023                 -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine is called whenever a non-book item needs -
        '- to be added to its relevant dictionaries.                -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- (None)                                                   -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        Me.errInvalidItem.Clear() 'clears the error provider data
        If frmHomePage.dicAllNonBookMedia.ContainsKey(txtKey.Text) Then 'if the key is already present in the 'dicAllNonBookMedia' dictionary, we cannot add it
            Me.errInvalidItem.SetError(Me.txtKey, "Invalid Key - Cannot add a duplicate!") 'display an error message
        ElseIf (frmHomePage.dicAllNonBookMedia.ContainsValue(txtName.Text)) Then 'if the value is already present in the 'dicAllNonBooKMedia' dictionary, we will not add it
            Me.errInvalidItem.SetError(Me.txtName, "Invalid Name - Cannot add a duplicate!") 'display an error message
        Else 'Otherwise, the non-book media item can be added
            frmHomePage.dicAllNonBookMedia.Add(txtKey.Text, txtName.Text) 'add the non-book media item to the dictionary
            Me.Close() 'close the form
        End If
    End Sub

    Private Sub frmAddNewItem_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        '------------------------------------------------------------
        '-                Subprogram Name: frmAddNewItem_Closing    -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: Feb, 3rd 2023                 -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine is called whenever the form is closing.  -
        '- The home page form will show and the 'add item' form will-
        '- be reset.                                                -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- sender – Identifies which particular control raised the  –
        '-          click event                                     - 
        '- e – Holds the EventArgs object sent to the routine       -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        errInvalidItem.Clear() 'clears the error provider
        txtKey.Clear() 'clears the txtKey textbox
        txtName.Clear() 'clears the txtName text box
        frmHomePage.Show() 'shows frmHomePage
    End Sub

End Class