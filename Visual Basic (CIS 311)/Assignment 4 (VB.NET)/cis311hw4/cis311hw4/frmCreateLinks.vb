Imports System.ComponentModel

Public Class frmCreateLinks
    '------------------------------------------------------------
    '-                File Name : frmAddNewItem                 - 
    '-                Part of Project: cis311hw4                -
    '------------------------------------------------------------
    '-                Written By: Adam Cossin                   -
    '-                Written On: Feb, 3rd 2023                 -
    '------------------------------------------------------------
    '- File Purpose:                                            -
    '- This file contains the application form where the user   - 
    '- is able to manually add an item to a library or remove an-
    '- item from a library.                                     -
    '------------------------------------------------------------
    '- Global Variable Dictionary (alphabetically):             -
    '- strSelectedLibrary - string representation of the current-
    '-                      selected library.                   -
    '------------------------------------------------------------

    Dim strSelectedLibrary As String 'string to store the info for the currently selected library

    Private Sub frmCreateLinks_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        '------------------------------------------------------------
        '-                Subprogram Name: frmCreateLinks_Activated -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: Feb, 3rd 2023                 -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine is called whenever the form is in focus. –
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- sender – Identifies which particular control raised the  –
        '-          click event                                     - 
        '- e – Holds the EventArgs object sent to the routine       -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- intIndex - gets the index that the library is at in the  -
        '-              listbox.                                    -
        '------------------------------------------------------------

        If (strSelectedLibrary <> Nothing) Then 'makes sure that a valid library is selected
            Dim intIndex = lbxLibraries.FindString(strSelectedLibrary) 'gets the index that the currently selected library is at in the listbox
            lbxLibraries.SelectedIndex = intIndex 'sets the library to be selected (for more consistent results when the form is active but had not yet been closed)
        Else
            clearForm() 'calls clearForm
            populateLibrarires() 'calls populateLibraries
        End If
        populateAllBooks() 'calls populateAllBooks4
        populateAllOtherMedia() 'callsPopulateAllOtherMedia
    End Sub

    Sub populateLibrarires()
        '------------------------------------------------------------
        '-                Subprogram Name: populateLibraries        -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: Feb, 3rd 2023                 -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine is called to load/reload the contents of -
        '- the libraries listbox.                                   -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- (None)                                                   -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------

        lbxLibraries.Items.Clear() 'clears the listbox for a fresh reload
        For Each library In frmHomePage.dicLibraries 'loops through the libraries present in 'dicLibraries'
            lbxLibraries.Items.Add(library.Value & " - " & library.Key) 'adds each value and key of the library to the listbox
        Next
    End Sub

    Sub populateAllBooks()
        '------------------------------------------------------------
        '-                Subprogram Name: populateAllBooks         -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: Feb, 3rd 2023                 -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine is called to load/reload the contents of -
        '- the 'all books' listbox.                                 -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- (None)                                                   -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------

        lbxAllBooks.Items.Clear() 'clears the listbox for a fresh reload
        For Each book In frmHomePage.dicAllBooks 'loops through the books present in 'dicAllBooks'
            lbxAllBooks.Items.Add(book.Value & " - " & book.Key) 'adds each value and key of the book to the listbox
        Next
    End Sub

    Sub populateAllOtherMedia()
        '------------------------------------------------------------
        '-                Subprogram Name: populateAllOtherMedia    -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: Feb, 3rd 2023                 -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine is called to load/reload the contents of -
        '- the 'all other media' listbox.                           -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- (None)                                                   -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------

        lbxAllNonBookMedia.Items.Clear() 'clears the listbox for a fresh reload
        For Each item In frmHomePage.dicAllNonBookMedia 'loops through the non-book media items present in 'dicAllNonBookMedia'
            lbxAllNonBookMedia.Items.Add(item.Value & " - " & item.Key) 'adds each value and key of the non-book media item to the listbox
        Next
    End Sub

    Sub populateBooksForLibrary(dicLib As SortedDictionary(Of String, String))
        '------------------------------------------------------------
        '-                Subprogram Name: populateBooksForLibrary  -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: Feb, 3rd 2023                 -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine is called to load/reload the contents of -
        '- the 'books' listbox for the currently selected library.  -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- dicLib - the library from which to load the books.       -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------

        lbxBooksAtCurrentLibrary.Items.Clear() 'clears the listbox for a fresh reload
        For Each book In dicLib 'loops through each item contained in 'dicLib'
            If (frmHomePage.dicAllBooks.ContainsKey(book.Key)) Then 'if the item is a book, it will also be present in 'dicAllBooks', so we can display it here
                lbxBooksAtCurrentLibrary.Items.Add(book.Value & " - " & book.Key) 'adds the book to the listbox
            End If
        Next
    End Sub

    Sub populateOtherMediaForLibrary(dicLib As SortedDictionary(Of String, String))
        '------------------------------------------------------------
        '-           Subprogram Name: populateOtherMediaForLibrary  -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: Feb, 3rd 2023                 -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine is called to load/reload the contents of -
        '- the 'other media' listbox for the currently selected     -
        '- library.                                                 -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- dicLib - the library from which to load the items.       -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------

        lbxNonBookMediaAtCurrentLibrary.Items.Clear() 'clears the listbox for a fresh reload
        For Each item In dicLib 'loops through each item contained in 'dicLib'
            If (frmHomePage.dicAllNonBookMedia.ContainsKey(item.Key)) Then 'if the item is a non-book media item, it will also be present in 'dicAllNonBookMedia', so we can display it here
                lbxNonBookMediaAtCurrentLibrary.Items.Add(item.Value & " - " & item.Key) 'adds the non-book media item to the listbox
            End If
        Next
    End Sub

    Function getLibrary() As SortedDictionary(Of String, String)
        '------------------------------------------------------------
        '-           Function Name: populateOtherMediaForLibrary    -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: Feb, 3rd 2023                 -
        '------------------------------------------------------------
        '- Function Purpose:                                        -
        '-                                                          -
        '- This subroutine is called to return a library from the   -
        '- key of the item selected in the listbox.                 -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- (None)                                                   -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- arrElements - gets the key and value pair from the       -
        '-               currently selected item in the listbox.    -
        '- dicTemp - library referencing the library with the given -
        '-            key.                                          -
        '- strKey - the key value for the library.                  -
        '------------------------------------------------------------
        '- Returns:                                                 -
        '- SortedDictionary –for the library selected in the listbox-
        '------------------------------------------------------------

        Dim arrElements = strSelectedLibrary.Split(" - ") 'splits the string for the currently selected library into its' elements
        Dim strKey = arrElements(arrElements.Length - 1) 'gets the key for the currently selected library
        Dim dicTemp As SortedDictionary(Of String, String) = frmHomePage.dicLibrariesAndMedia(strKey) 'reference for the library with the given key
        Return dicTemp 'returns the currently selected dictionary (or a reference to it)
    End Function

    Private Sub btnGoBackToHomePage_Click(sender As Object, e As EventArgs) Handles btnGoBackToHomePage.Click
        '------------------------------------------------------------
        '-               Subprogram Name: btnGoBackToHomePage_Click -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: Feb, 3rd 2023                 -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine is called whenever the return home button–
        '- is clicked. Returns the user to the home page form.      -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- sender – Identifies which particular control raised the  –
        '-          click event                                     - 
        '- e – Holds the EventArgs object sent to the routine       -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------

        frmHomePage.Show() 'shows frmHomePage
        Me.Close() 'closes this form
    End Sub

    Private Sub lbxLibraries_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbxLibraries.SelectedIndexChanged
        '------------------------------------------------------------
        '-       Subprogram Name: lbxLibraries_SelectedIndexChanged -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: Feb, 3rd 2023                 -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine is called whenever the selected item in  -
        '- the libraries listbox is changed. This will result in    -
        '- changing the listboxes for books and other media for the -
        '- currently selected library.                              -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- sender – Identifies which particular control raised the  –
        '-          click event                                     - 
        '- e – Holds the EventArgs object sent to the routine       -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- dicTemp - library referencing the library with the given -
        '-            key.                                          -
        '------------------------------------------------------------

        If (lbxLibraries.SelectedItem <> Nothing) Then 'if the selected library is valid
            strSelectedLibrary = lbxLibraries.SelectedItem 'changes the value of 'strSelectedLibrary' to be the current library
            Dim dicTemp As SortedDictionary(Of String, String) = getLibrary() 'get a reference to the library with the given key
            populateBooksForLibrary(dicTemp) 'populate the listbox for books at current library with proper books
            populateOtherMediaForLibrary(dicTemp) 'populate the listbox for non-book media at current library with proper items
        End If
    End Sub

    Private Sub btnAddBookToCurrentLibrary_Click(sender As Object, e As EventArgs) Handles btnAddBookToCurrentLibrary.Click
        '------------------------------------------------------------
        '-        Subprogram Name: btnAddBookToCurrentLibrary_Click -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: Feb, 3rd 2023                 -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine is called whenever the user wants to add -
        '- a book to the current library.                           -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- sender – Identifies which particular control raised the  –
        '-          click event                                     - 
        '- e – Holds the EventArgs object sent to the routine       -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- arrBooks - holds the books selected in the 'all books'   -   
        '-              listbox.                                    -
        '- dicTemp - library referencing the library with the given -
        '-            key.                                          -
        '- str - holds the string response(s) from calling sub      -
        '-       'giveBookToLibrary'                                -
        '------------------------------------------------------------

        If (lbxLibraries.SelectedItem <> Nothing And lbxAllBooks.SelectedItem <> Nothing) Then 'if there is a value selected for library and at least one book selected, then the request is valid
            Dim arrBooks As ArrayList = New ArrayList() 'array containing all books selected in the 'all books' listbox
            For Each item In lbxAllBooks.SelectedItems 'loops through selected items of 'allBooks' listbox
                arrBooks.Add(item) 'adds each item to the array
            Next
            Dim str = "" 'initialize string to contain result
            For Each book In arrBooks 'loops through books in array
                str &= (giveBookToLibrary(book)) & vbCrLf 'concats the result of 'giveBookToLibrary' to str
            Next
            MessageBox.Show(str) 'shows the message(s) from the attempt(s) to give the library the book(s)
            Dim dicTemp As SortedDictionary(Of String, String) = getLibrary() 'library referencing the library that is currently selected
            populateBooksForLibrary(dicTemp) 'refresh the list of books for the current library
        Else 'Otherwise, a library and/or book is not selected
            MessageBox.Show("You must have a library and book selected to perform this operation! Please select a library and at least one book.") 'display an error message
        End If
    End Sub

    Private Sub btnRemoveBookFromCurrentLibrary_Click(sender As Object, e As EventArgs) Handles btnRemoveBookFromCurrentLibrary.Click
        '------------------------------------------------------------
        '-   Subprogram Name: btnRemoveBookFromCurrentLibrary_Click -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: Feb, 3rd 2023                 -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine is called whenever the user wants to     -
        '- remove a book from the current library.                  -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- sender – Identifies which particular control raised the  –
        '-          click event                                     - 
        '- e – Holds the EventArgs object sent to the routine       -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- arrBooks - holds the books selected in the 'all books'   -   
        '-              listbox.                                    -
        '- dicTemp - library referencing the library with the given -
        '-            key.                                          -
        '- str - holds the string response(s) from calling sub      -
        '-       'removeBookFromLibrary'                            -
        '------------------------------------------------------------

        If (lbxLibraries.SelectedItem <> Nothing And lbxBooksAtCurrentLibrary.SelectedItem <> Nothing) Then 'if a valid library and book(s) are selected
            Dim arrBooks As ArrayList = New ArrayList() 'create array to hold selected book items
            For Each item In lbxBooksAtCurrentLibrary.SelectedItems 'loops through selected items of library's current books listbox
                arrBooks.Add(item) 'adds each item to the array
            Next
            Dim str = "" 'initialize string to contain result
            For Each book In arrBooks 'loops through books in array
                str &= (removeBookFromLibrary(book)) & vbCrLf 'concats the result of 'removeBookFromLibrary' to str
            Next
            MessageBox.Show(str) 'shows the message(s) from the attempt(s) to remove the book(s) from the library
            Dim dicTemp As SortedDictionary(Of String, String) = getLibrary() 'library referencing the library that is currently selected
            populateBooksForLibrary(dicTemp) 'refresh the list of books for the current library
        Else 'Otherwise, a library and/or book is not selected
            MessageBox.Show("You must have a library and at least one of its books selected to perform this operation! Please select a library and at least one of its books.") 'display an error message
        End If
    End Sub

    Private Function removeBookFromLibrary(strBook As String) As String
        '------------------------------------------------------------
        '-                Function Name: removeBookFromLibrary      -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: Feb, 3rd 2023                 -
        '------------------------------------------------------------
        '- Function Purpose:                                        -
        '-                                                          -
        '- This function is called whenever the user wants to remove-
        '- a book from the current library. The passed book  is     -
        '- removed from the currently selected library.             -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- strBook - a string of the book to be removed.            -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- arrElements - holds the elements of the book passed.     -
        '- dicTemp - library referencing the library with the given -
        '-            key.                                          -
        '------------------------------------------------------------
        '- Returns:                                                 -
        '- String – containing the message result of removing a book-
        '-          from the library.                               -
        '------------------------------------------------------------

        Dim dicTemp As SortedDictionary(Of String, String) = getLibrary() 'library referencing the currently selected library
        Dim arrElements() As String = strBook.Split(" - ") 'holds the elements of the passed book
        If (dicTemp.ContainsKey(arrElements(arrElements.Count - 1))) Then 'if the library has the book
            dicTemp.Remove(arrElements(arrElements.Count - 1)) 'the book is removed from the library
            Return frmHomePage.dicAllBooks(arrElements(arrElements.Count - 1)) & " was successfully removed from the library!" 'message is returned
        End If
        Return "" 'default return value
    End Function

    Private Function giveBookToLibrary(strBook As String) As String
        '------------------------------------------------------------
        '-                Function Name: giveBookToLibrary          -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: Feb, 3rd 2023                 -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine is called whenever the user wants to     -
        '- add a book to the current library. The passed book  is   -
        '- is added to the currently selected library.              -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- strBook - a string of the book to be added.              -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- arrElements - holds the elements of the book passed.     -
        '- dicTemp - library referencing the library with the given -
        '-            key.                                          -
        '- str - contains the value of the book to be added.        -
        '------------------------------------------------------------
        '- Returns:                                                 -
        '- String – containing the message result of adding a book  -
        '-          to the library.                                 -
        '------------------------------------------------------------

        Dim dicTemp As SortedDictionary(Of String, String) = getLibrary() 'library referencing the library with the given key
        Dim arrElements() As String = strBook.Split(" - ") 'holds elements of the passed book
        Dim str = "" 'initialize str
        If (dicTemp.ContainsKey(arrElements(arrElements.Count - 1))) Then 'if the dictionary already contains the key, it cannot be added
            Return frmHomePage.dicAllBooks(arrElements(arrElements.Count - 1)) & " could not be added to the library - no duplicates allowed!" 'return an error message
        Else 'othewise the book is able to be added
            For i = 0 To arrElements.Length - 2 'loop to format the output of the book value and key
                If (i <= arrElements.Length - 3) Then
                    str &= arrElements(i) & " - "
                Else
                    str &= arrElements(i) & " "
                End If
            Next
            dicTemp.Add(arrElements(arrElements.Count - 1), str) 'adds the book to the library
            Return frmHomePage.dicAllBooks(arrElements(arrElements.Count - 1)) & " was successfully added to the library!" 'return success message
        End If
        Return "" 'default return statement
    End Function

    Private Sub btnAddNonBookMediaToCurrentLibrary_Click(sender As Object, e As EventArgs) Handles btnAddNonBookMediaToCurrentLibrary.Click
        '------------------------------------------------------------
        '- Subprogram Name: btnAddNonBookMediaToCurrentLibrary_Click-
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: Feb, 3rd 2023                 -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine is called whenever the user wants to add -
        '- a non-book media item to the current library.            -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- sender – Identifies which particular control raised the  –
        '-          click event                                     - 
        '- e – Holds the EventArgs object sent to the routine       -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- arrItems - holds the items selected in the 'all other    -   
        '-             media' listbox.                              -
        '- dicTemp - library referencing the library with the given -
        '-            key.                                          -
        '- str - holds the string response(s) from calling sub      -
        '-       'giveBookToLibrary'                                -
        '------------------------------------------------------------

        If (lbxLibraries.SelectedItem <> Nothing And lbxAllNonBookMedia.SelectedItem <> Nothing) Then 'if a valid library and non-book media item are selected
            Dim arrItems As ArrayList = New ArrayList() 'initialize arrItems to hold non-book media items
            For Each item In lbxAllNonBookMedia.SelectedItems 'for each item that is selected in the non-book media listbox
                arrItems.Add(item) 'add the item to the array
            Next
            Dim str = "" 'initialize str
            For Each item In arrItems 'for each item in the array
                str &= (giveNonBookToLibrary(item)) & vbCrLf 'get the result of 'giveNonBookToLibrary' and concat it with str
            Next
            MessageBox.Show(str) 'show the result of adding non-book media item(s) to the library
            Dim dicTemp As SortedDictionary(Of String, String) = getLibrary() 'library referencing currently selected library
            populateOtherMediaForLibrary(dicTemp) 'populate the current library's listbox of non-book items
        Else 'Otherwise, a valid library and/or a non-book media item were not selected
            MessageBox.Show("You must have a library and non-book media item selected to perform this operation! Please select a library and at least one non-book media item.") 'display an error message
        End If
    End Sub

    Private Function giveNonBookToLibrary(strItem As String) As String
        '------------------------------------------------------------
        '-                Function Name: giveNonBookToLibrary       -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: Feb, 3rd 2023                 -
        '------------------------------------------------------------
        '- Function Purpose:                                        -
        '-                                                          -
        '- This subroutine is called whenever the user wants to     -
        '- add a non-book item to the current library. The passed   -
        '- non-book item is added to the currently selected library.-
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- strItem - a string of the item to be added.              -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- arrElements - holds the elements of the item passed.     -
        '- dicTemp - library referencing the library with the given -
        '-            key.                                          -
        '- str - contains the value of the item to be added.        -
        '------------------------------------------------------------
        '- Returns:                                                 -
        '- String – containing the message result of adding a book  -
        '-          to the library.                                 -
        '------------------------------------------------------------

        Dim tempLib As SortedDictionary(Of String, String) = getLibrary() 'library referencing the currently selected library
        Dim arrElements() As String = strItem.Split(" - ") 'holds the elements of the passed item
        Dim str = "" 'initialize str
        If (tempLib.ContainsKey(arrElements(arrElements.Count - 1))) Then 'if the library already contains the key, then the key cannot be added
            Return frmHomePage.dicAllNonBookMedia(arrElements(arrElements.Count - 1)) & " could not be added to the library - no duplicates allowed!" 'return an error message
        Else 'otherwise, the item can be added
            For i = 0 To arrElements.Length - 2 'loop to format the output of the non-book item value and key
                If (i <= arrElements.Length - 3) Then
                    str &= arrElements(i) & " - "
                Else
                    str &= arrElements(i) & " "
                End If
            Next
            tempLib.Add(arrElements(arrElements.Count - 1), str) 'add the item to the library
            Return frmHomePage.dicAllNonBookMedia(arrElements(arrElements.Count - 1)) & " was successfully added to the library!" 'return a success message
        End If
        Return "" 'default return value
    End Function

    Sub clearForm()
        '------------------------------------------------------------
        '-                Subprogram Name: clearForm                -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: Feb, 3rd 2023                 -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine is called to clear the form & refresh    -
        '- listboxes.                                               -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- (None)                                                   -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------

        lbxAllBooks.Refresh() 'block that refreshes listboxes
        lbxAllNonBookMedia.Refresh()
        lbxLibraries.Refresh()
        lbxLibraries.ClearSelected()

        lbxBooksAtCurrentLibrary.Items.Clear() 'clear currently selected library's listboxes since none are selected by default
        lbxNonBookMediaAtCurrentLibrary.Items.Clear()
    End Sub

    Private Sub btnRemoveNonBookMediaFromCurrentLibrary_Click(sender As Object, e As EventArgs) Handles btnRemoveNonBookMediaFromCurrentLibrary.Click
        '------------------------------------------------------------
        '-Subprogram Name: btnRemoveNonBookMediaFromCurrentLibrary_Click -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: Feb, 3rd 2023                 -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine is called whenever the user wants to     -
        '- remove a non-book item from the current library.         -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- sender – Identifies which particular control raised the  –
        '-          click event                                     - 
        '- e – Holds the EventArgs object sent to the routine       -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- arrNonBookMedia - holds the non-book items selected in   - 
        '-              the 'all other media' listbox.              -
        '- dicTemp - library referencing the library with the given -
        '-            key.                                          -
        '- str - holds the string response(s) from calling sub      -
        '-       'removeBookFromLibrary'                            -
        '------------------------------------------------------------

        If (lbxLibraries.SelectedItem <> Nothing And lbxNonBookMediaAtCurrentLibrary.SelectedItem <> Nothing) Then 'if a valid library and non-book media item are selected
            Dim arrNonBookMedia As ArrayList = New ArrayList() 'initialize arraylist
            For Each item In lbxNonBookMediaAtCurrentLibrary.SelectedItems 'loop through each selected item in non-book media listbox
                arrNonBookMedia.Add(item) 'add item to array
            Next
            Dim str = "" 'initialize str
            For Each item In arrNonBookMedia 'loop through each item in the array
                str &= (removeNonBookMediaFromLibrary(item)) & vbCrLf 'concat str to contain result of removeNonBookMediaFromLibrary
            Next
            MessageBox.Show(str) 'shows result containing message(s) from above call
            Dim dicTemp As SortedDictionary(Of String, String) = getLibrary() ' library referencing the currently selected library
            populateOtherMediaForLibrary(dicTemp) 'refresh the listbox of the current library's non-book media items
        Else 'Otherwise, a valid library and/or non-book media item(s) were not chosen
            MessageBox.Show("You must have a library and at least one of its non-book media items selected to perform this operation! Please select a library and at least one of its non-book media items.") 'display an error message
        End If
    End Sub

    Private Function removeNonBookMediaFromLibrary(strItem As String)
        '------------------------------------------------------------
        '-             Function Name: removeNonBookMediaFromLibrary -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: Feb, 3rd 2023                 -
        '------------------------------------------------------------
        '- Function Purpose:                                        -
        '-                                                          -
        '- This function is called whenever the user wants to remove-
        '- a non-book item from the current library. The passed non--
        '- book item is removed from the currently selected library.-
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- strItem - a string of the item to be removed.            -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- arrElements - holds the elements of the non-book passed. -
        '- dicTemp - library referencing the library with the given -
        '-            key.                                          -
        '------------------------------------------------------------
        '- Returns:                                                 -
        '- String – containing the message result of removing a     -
        '-          non-book from the library.                      -
        '------------------------------------------------------------

        Dim dicTemp As SortedDictionary(Of String, String) = getLibrary() 'library referencing currently selected library
        Dim arrElements() As String = strItem.Split(" - ") 'array of elements of the passed item
        If (dicTemp.ContainsKey(arrElements(arrElements.Count - 1))) Then 'if the current library has the key of the item to be removed
            dicTemp.Remove(arrElements(arrElements.Count - 1)) 'the item is removed from the library
            Return frmHomePage.dicAllNonBookMedia(arrElements(arrElements.Count - 1)) & " was successfully removed from the library!" 'returns a success message
        End If
        Return "" 'defaut return value
    End Function

    Private Sub frmCreateLinks_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        '------------------------------------------------------------
        '-                Subprogram Name: frmCreateLinks_Closing   -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: Feb, 3rd 2023                 -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine is called to clear the form & refresh    -
        '- listboxes upon the form's closing.                       -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- (None)                                                   -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------

        clearForm() 'calls clearForm
    End Sub
End Class