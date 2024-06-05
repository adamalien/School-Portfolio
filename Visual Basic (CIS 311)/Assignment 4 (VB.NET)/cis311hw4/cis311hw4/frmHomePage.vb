Public Class frmHomePage
    '------------------------------------------------------------
    '-                File Name : frmHomePage.vb                - 
    '-                Part of Project: cis311hw4                -
    '------------------------------------------------------------
    '-                Written By: Adam Cossin                   -
    '-                Written On: Feb 3rd, 2023                 -
    '------------------------------------------------------------
    '- File Purpose:                                            -
    '- This file contains the main application form where the   -
    '- user is able to view the libraries and media that are    - 
    '- available. The user is able to delete or add these items -
    '- as well as go to another form showing what each library  -
    '- contains.
    '------------------------------------------------------------
    '- Program Purpose:                                         -
    '- This program serves as a library management system where -
    '- a user can add/delete libraries and their media items, as-
    '- well as view the relationship that the libraries have    -
    '- with the media (meaning if the library contains the item)-
    '------------------------------------------------------------
    '- Global Variable Dictionary (alphabetically):             -
    '- dicAllBooks - a dictionary collection of all available   -
    '-              books.                                      -
    '- dicAllNonBookMedia - a dictionary collection of all      -
    '-                     available non-book media items.      -
    '- dicLibraries - a dictionary collection of all libraries. -
    '- dicLibrariesAndMedia - a dictionary collection of the    -
    '-                          libraries and their associated  -
    '-                          media items.                    -
    '------------------------------------------------------------

    Public dicLibraries As New SortedDictionary(Of String, String) 'dictionary containing key-value pairs of library items
    Public dicAllBooks As New SortedDictionary(Of String, String) 'dictionary containing key-value pairs of book items
    Public dicAllNonBookMedia As New SortedDictionary(Of String, String) 'dictionary containing key-value pairs of non-book media items
    Public dicLibrariesAndMedia As New SortedDictionary(Of String, SortedDictionary(Of String, String)) 'dictionary containing each library's key and each library's dictionary of items

    Private Sub frmHomePage_Load(sender As Object, e As EventArgs) Handles Me.Load
        '------------------------------------------------------------
        '-                Subprogram Name: frmHomePage_Load         -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: Feb 3rd, 2023                 -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine is called when the form first loads in   –
        '- order to populate the initial libraries and their media  -
        '- items and load them to the relevant listboxes.           -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- sender – Identifies which particular control raised the  –
        '-          click event                                     - 
        '- e – Holds the EventArgs object sent to the routine       -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- dicFleschner - dictionary for media items contained at   -
        '-               the Fleschner library.                     -
        '- dicScott - dictionary for media items contained at the   -
        '-            Scott D. James library.                       -
        '- dicZahnow - dictionary for media items contained at the  -
        '-              Zahnow library.                             -
        '------------------------------------------------------------

        Dim dicZahnow As New SortedDictionary(Of String, String) 'block to create libraries
        Dim dicFleschner As New SortedDictionary(Of String, String)
        Dim dicScott As New SortedDictionary(Of String, String)

        dicLibrariesAndMedia = New SortedDictionary(Of String, SortedDictionary(Of String, String)) 'initialize the above libraries and media dictionary

        dicLibraries.Add("SVSU", "Zahnow Library") 'block to add key-value pairs to 'dicLibraries' dictionary
        dicLibraries.Add("BR", "Fleschner Memorial Library")
        dicLibraries.Add("SDJ", "Scott D. James Technical Repository")

        dicAllBooks.Add("101", "Zen and the Art of Appliance Wiring") 'block to add key-value pairs to 'dicAllBooks' dictionary
        dicAllBooks.Add("102", "Interpretive Klingon Poetry")
        dicAllBooks.Add("103", "Doing More With Less - Navel Lint Art")
        dicAllBooks.Add("104", "Data Structures for Fun and Profit")
        dicAllBooks.Add("105", "Programming with the Bidgoli")

        dicAllNonBookMedia.Add("201", "CD - IEEE Computer: the Hits") 'block to add key-value paris to 'dicAllNonBookMedia' dictionary
        dicAllNonBookMedia.Add("202", "DVD - The Pirates of Silicon Valley")
        dicAllNonBookMedia.Add("203", "DVD - Databases and You: the Video Experience")

        dicZahnow.Add("101", "Zen and the Art of Appliance Wiring") 'block to add media items to the Zahnow library
        dicZahnow.Add("104", "Data Structures for Fun and Profit")
        dicZahnow.Add("105", "Programming with the Bidgoli")
        dicZahnow.Add("201", "CD - IEEE Computer: the Hits")

        dicScott.Add("102", "Interpretive Klingon Poetry") 'block to add media items to the Scott D. James library
        dicScott.Add("105", "Programming with the Bidgoli")
        dicScott.Add("202", "DVD - The Pirates of Silicon Valley")

        dicLibrariesAndMedia.Add("BR", dicFleschner) 'block to add each library to the libraries and media dictionary
        dicLibrariesAndMedia.Add("SDJ", dicScott)
        dicLibrariesAndMedia.Add("SVSU", dicZahnow)

        populateLibraries() 'block calling methods to populate the relevant listboxes
        populateBooks()
        populateOtherMedia()
    End Sub


    Sub populateLibraries()
        '------------------------------------------------------------
        '-                Subprogram Name: populateLibraries        -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: Feb 3rd, 2023                 -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine is called to populate the libraries list –
        '- box with the contents of the 'dicLibraries' dictionary.  -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- (None)                                                   -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------

        lbxAllLibraries.Items.Clear() 'clear the listbox to do a fresh reload
        For Each library In dicLibraries
            lbxAllLibraries.Items.Add(library.Value & " - " & library.Key) 'populate the listbox with each library's value and key
        Next
    End Sub

    Sub populateBooks()
        '------------------------------------------------------------
        '-                Subprogram Name: populateBooks            -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: Feb 3rd, 2023                 -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine is called to populate the books listbox  –
        '- with the contents of the 'dicAllBooks' dictionary.       -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- (None)                                                   -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------

        lbxAllBooks.Items.Clear() 'clear the listbox to do a fresh reload
        For Each book In dicAllBooks
            lbxAllBooks.Items.Add(book.Value & " - " & book.Key) 'populate the listbox with each book's value and key
        Next
    End Sub

    Sub populateOtherMedia()
        '------------------------------------------------------------
        '-                Subprogram Name: populateOtherMedia       -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: Feb 3rd, 2023                 -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine is called to populate the non-book media -
        '- listbox with the contents of the 'dicAllNonBookMedia'    -
        '- dictionary.                                              -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- (None)                                                   -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------

        lbxAllOtherMedia.Items.Clear() 'clear the listbox to do a fresh reload
        For Each item In dicAllNonBookMedia
            lbxAllOtherMedia.Items.Add(item.Value & " - " & item.Key) 'populate the listbox with each non-book media item's value and key
        Next
    End Sub

    Private Sub btnAddLibrary_Click(sender As Object, e As EventArgs) Handles btnAddLibrary.Click
        '------------------------------------------------------------
        '-                Subprogram Name: btnAddLibrary_Click      -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: Feb 3rd, 2023                 -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine is called when the 'Add Library' button  -
        '- is clicked. This calls for the 'addNewItem' form to show -
        '- and populates the title and lable names accordingly.     -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- sender – Identifies which particular control raised the  –
        '-          click event                                     - 
        '- e – Holds the EventArgs object sent to the routine       -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------

        frmAddNewItem.Text = "Add New Library" 'sets the title of the new item form
        frmAddNewItem.lblKey.Text = "Library Key:" 'sets the text value for the key label
        frmAddNewItem.lblName.Text = "Library Name:" 'sets the text value for the value label
        frmAddNewItem.ShowDialog() 'show frmAddNewItem
    End Sub

    Private Sub btnAddBook_Click(sender As Object, e As EventArgs) Handles btnAddBook.Click
        '------------------------------------------------------------
        '-                Subprogram Name: btnAddBook_Click         -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: Feb 3rd, 2023                 -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine is called when the 'Add Book' button     -
        '- is clicked. This calls for the 'addNewItem' form to show -
        '- and populates the title and lable names accordingly.     -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- sender – Identifies which particular control raised the  –
        '-          click event                                     - 
        '- e – Holds the EventArgs object sent to the routine       -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------

        frmAddNewItem.Text = "Add New Book" 'sets the title of the new item form
        frmAddNewItem.lblKey.Text = "Book Key:" 'sets the text value for the key label
        frmAddNewItem.lblName.Text = "Book Name:" 'sets the text value for the value label
        frmAddNewItem.ShowDialog() 'show frmAddNewItem
    End Sub

    Private Sub btnAddOtherMedia_Click(sender As Object, e As EventArgs) Handles btnAddOtherMedia.Click
        '------------------------------------------------------------
        '-                Subprogram Name: btnAddOtherMedia_Click   -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: Feb 3rd, 2023                 -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine is called when the 'Add Non-Book Media'  -
        '- button is clicked. This calls for the 'addNewItem' form  -
        '- to show and populates the title and lable names          -
        '- accordingly.                                             -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- sender – Identifies which particular control raised the  –
        '-          click event                                     - 
        '- e – Holds the EventArgs object sent to the routine       -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        frmAddNewItem.Text = "Add New Non-Book Media" 'sets the title of the new item form
        frmAddNewItem.lblKey.Text = "Non-Book Media Key:" 'sets the text value for the key label
        frmAddNewItem.lblName.Text = "Non-Book Media Name:" 'sets the text value for the value label
        frmAddNewItem.ShowDialog() 'show frmAddNewItem
    End Sub

    Private Sub frmHomePage_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        '------------------------------------------------------------
        '-                Subprogram Name: frmHomePage_Activated    -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: Feb 3rd, 2023                 -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine is called when the form is activated or  -
        '- focus is regained (ie. returning from another form). The -
        '- listboxes are refreshed to reflect any changes that have -
        '- been made from the other forms.                          -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- sender – Identifies which particular control raised the  –
        '-          click event                                     - 
        '- e – Holds the EventArgs object sent to the routine       -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------

        populateBooks() 'block to refresh the listboxes
        populateLibraries()
        populateOtherMedia()
    End Sub

    Private Sub btnGoToLinkForm_Click(sender As Object, e As EventArgs) Handles btnGoToLinkForm.Click
        '------------------------------------------------------------
        '-                Subprogram Name: btnGoToLinkForm_Click    -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: Feb 3rd, 2023                 -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine is called when the button at the bottom  -
        '- of the screen is clicked. This will show the create links-
        '- form.                                                    -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- sender – Identifies which particular control raised the  –
        '-          click event                                     - 
        '- e – Holds the EventArgs object sent to the routine       -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------

        frmCreateLinks.ShowDialog() 'shows frmCreateLinks
    End Sub

    Private Sub btnDeleteLibrary_Click(sender As Object, e As EventArgs) Handles btnDeleteLibrary.Click
        '------------------------------------------------------------
        '-                Subprogram Name: btnDeleteLibrary_Click   -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: Feb 3rd, 2023                 -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine is called when the 'Delete Library'      -
        '- button is clicked. A messagebox is shown to the user to  -
        '- confirm that they want to delete the item, and if they do-
        '- the item is deleted from the cooresponding dictionaries. -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- sender – Identifies which particular control raised the  –
        '-          click event                                     - 
        '- e – Holds the EventArgs object sent to the routine       -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- arrItems - array of key & values for the library selected-
        '- strSelectedKey - string for the selected key.            -
        '------------------------------------------------------------

        If (lbxAllLibraries.SelectedItem <> Nothing) Then 'makes sure a valid value is selected from the listbox
            Dim arrItems() As String = lbxAllLibraries.SelectedItem.Split(" - ") 'gets the selected item in its key/value components
            Dim strSelectedKey As String = lbxAllLibraries.SelectedItem.Split(" - ")(arrItems.Length - 1) 'gets the key for the item selected
            deleteLibrary(strSelectedKey) 'calls deleteLibrary and passes the key of the selected item
        Else
            MessageBox.Show("You must select a library in order to delete one!") 'if a library is not selected, shows a message
        End If
    End Sub

    Private Sub btnDeleteBook_Click(sender As Object, e As EventArgs) Handles btnDeleteBook.Click
        '------------------------------------------------------------
        '-                Subprogram Name: btnDeleteBook_Click      -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: Feb 3rd, 2023                 -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine is called when the 'Delete Book' button  -
        '- is clicked. A messagebox is shown to the user to  confirm-
        '- that they want to delete the item, and if they do the    -
        '- item is deleted from the cooresponding dictionaries.     -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- sender – Identifies which particular control raised the  –
        '-          click event                                     - 
        '- e – Holds the EventArgs object sent to the routine       -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- arrItems - array of key & values for the library selected-
        '- strSelectedKey - string for the selected key.            -
        '------------------------------------------------------------

        If (lbxAllBooks.SelectedItem <> Nothing) Then 'makes sure a valid value is selected from the listbox
            Dim arrItems() As String = lbxAllBooks.SelectedItem.Split(" - ") 'gets the selected item in its key/value components
            Dim strSelectedKey As String = lbxAllBooks.SelectedItem.Split(" - ")(arrItems.Length - 1) 'gets the key for the item selected
            deleteBook(strSelectedKey) 'calls deleteBook and passes the key of the selected item
        Else
            MessageBox.Show("You must select a book in order to delete one!") 'if a book is not selected, shows a message
        End If
    End Sub

    Private Sub btnDeleteOtherMedia_Click(sender As Object, e As EventArgs) Handles btnDeleteOtherMedia.Click
        '------------------------------------------------------------
        '-               Subprogram Name: btnDeleteOtherMedia_Click -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: Feb 3rd, 2023                 -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine is called when the 'Delete Other Media'  -
        '- button is clicked. A messagebox is shown to the user to  -
        '- confirm that they want to delete the item, and if they do-
        '- the item is deleted from the cooresponding dictionaries. -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- sender – Identifies which particular control raised the  –
        '-          click event                                     - 
        '- e – Holds the EventArgs object sent to the routine       -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- arrItems - array of key & values for the library selected-
        '- strSelectedKey - string for the selected key.            -
        '------------------------------------------------------------
        If (lbxAllOtherMedia.SelectedItem <> Nothing) Then 'makes sure a valid value is selected from the listbox
            Dim arrItems() As String = lbxAllOtherMedia.SelectedItem.Split(" - ") 'gets the selected item in its key/value components
            Dim strSelectedKey As String = lbxAllOtherMedia.SelectedItem.Split(" - ")(arrItems.Length - 1) 'gets the key for the item selected
            deleteOtherMedia(strSelectedKey) 'calls deleteOtherMedia and passes the key of the selected item
        Else
            MessageBox.Show("You must select a non-book media item in order to delete one!") 'if a non-book media item is not selected, shows a message
        End If
    End Sub

    Private Sub deleteBook(strKey As String)
        '------------------------------------------------------------
        '-                Subprogram Name: deleteBook               -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: Feb 3rd, 2023                 -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine is called to delete a book from the      -
        '- appropriate dictionaries.                                -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- strKey - the key of the item to be deleted.              -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- drResult - gets the result from the user when the confirm-
        '-              messagebox is shown (yes or no).            -
        '------------------------------------------------------------

        Dim drResult As New DialogResult 'create new dialogResult
        drResult = MessageBox.Show("Are you sure you want to delete this book?", "Confirmation", MessageBoxButtons.YesNo) 'show a confirmation messagebox and prompt the user to click yes or no
        If (drResult = DialogResult.Yes) Then 'if the user clicks yes, that means they do want to delete the item
            If (dicAllBooks.ContainsKey(strKey)) Then 'find the key present in the 'dicAllBooks' dictionary
                dicAllBooks.Remove(strKey) 'delete the book from the dictionary
            End If
            For Each library In dicLibrariesAndMedia 'goes through each library to check if they have the book
                If (library.Value.ContainsKey(strKey)) Then 'find if the key is present in each library's dictionary
                    library.Value.Remove(strKey) 'delete the book from the dictionary
                End If
            Next
        End If
        populateBooks() 'calls populateBooks() to reload the books listbox
    End Sub

    Private Sub deleteOtherMedia(strKey As String)
        '------------------------------------------------------------
        '-                Subprogram Name: deleteOtherMedia         -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: Feb 3rd, 2023                 -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine is called to delete a non-book media item-
        '- from the appropriate dictionaries.                       -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- strKey - the key of the item to be deleted.              -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- drResult - gets the result from the user when the confirm-
        '-              messagebox is shown (yes or no).            -
        '------------------------------------------------------------

        Dim drResult As New DialogResult 'create a new dialogResult
        drResult = MessageBox.Show("Are you sure you want to delete this non-book media item?", "Confirmation", MessageBoxButtons.YesNo) 'show a confirmation messagebox and prompt the user to click yes or no
        If (drResult = DialogResult.Yes) Then 'if the user clicks yes, that means they do want to delete the item
            If (dicAllNonBookMedia.ContainsKey(strKey)) Then 'find the key present in the 'dicAllNonBookMedia' dictionary
                dicAllNonBookMedia.Remove(strKey) 'delete the non-book media item from the dictionary
            End If
            For Each library In dicLibrariesAndMedia 'goes through each library to check if they have the non-book media item
                If (library.Value.ContainsKey(strKey)) Then 'find if the key is present in each library's dictionary
                    library.Value.Remove(strKey) 'delete the non-book media item from the dictionary
                End If
            Next
        End If
        populateOtherMedia() 'calls populateOtherMedia() to reload the non-book media listbox
    End Sub

    Private Sub deleteLibrary(strKey As String)
        '------------------------------------------------------------
        '-                Subprogram Name: deleteLIbrary            -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: Feb 3rd, 2023                 -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine is called to delete a library from the   -
        '- appropriate dictionaries.                                -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- strKey - the key of the item to be deleted.              -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- drResult - gets the result from the user when the confirm-
        '-              messagebox is shown (yes or no).            -
        '------------------------------------------------------------

        Dim drResult As New DialogResult 'create a new dialogResult
        drResult = MessageBox.Show("Are you sure you want to delete this library?", "Confirmation", MessageBoxButtons.YesNo) 'show a confirmation messagebox and prompt the user to click yes or no
        If (drResult = DialogResult.Yes) Then 'if the user clicks yes, that means they do want to delete the item
            If (dicLibraries.ContainsKey(strKey)) Then 'find the key present in the 'dicLibraries' dictionary
                dicLibraries.Remove(strKey) 'delete the library from the dictionary
                dicLibrariesAndMedia.Remove(strKey) 'delete the library from the dictionary
            End If
        End If
        populateLibraries() 'calls populateLibraries() to reload the library listbox
    End Sub
End Class
