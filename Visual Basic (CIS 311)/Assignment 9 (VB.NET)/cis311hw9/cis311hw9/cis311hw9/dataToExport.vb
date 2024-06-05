Imports System.IO
Imports Microsoft.Office.Interop

Module dataToExport
    '------------------------------------------------------------
    '-                File Name : dataToExport                  - 
    '-                Part of Project: cis311hw9                -
    '------------------------------------------------------------
    '-                Written By: Adam Cossin                   -
    '-                Written On: March 30th, 2023              -
    '------------------------------------------------------------
    '- File Purpose:                                            -
    '- This file contains the main application form where the   -
    '- user will input a file name, then the data from that file-
    '- will be parsed through and some statistical data will be -
    '- calculated for it in excel.                              -
    '------------------------------------------------------------
    '- Program Purpose:                                         -
    '- This program reads in a file and stores each line from   -
    '- the file into a class and then into an array. Once this  -
    '- data is fully added in, it is shown in an excel document -
    '- and some statistical data is calculated through excel.   -
    '------------------------------------------------------------
    '- Global Variable Dictionary (alphabetically):             -
    '- (None)                                                   -
    '------------------------------------------------------------

    Sub Main()
        '------------------------------------------------------------
        '-                Subprogram Name: Main                     -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: March 30th, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is called when the application first     -
        '- launches. The console will get the name and path of the  -
        '- file to be read in from the user, will initialize an     -
        '- arraylist which will hold the data, and initialize an    -
        '- excel document.                                          -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- (None)                                                   -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- arrlstStores - arraylist containing instances of class   -
        '-                'Stores'.                                 -
        '- excelDocument - instance of a new excel document.        -
        '- strFile - name of file to be processed.                  -
        '------------------------------------------------------------
        Dim strFile As String = getFileName() 'gets the file name/path from the user
        Dim arrlstStores As ArrayList = populateData(strFile) 'creates and populates an arraylist of class 'Stores'
        Dim excelDocument = initializeExcelDocument() 'creates and opens a new excel document
        populateExcelDocument(arrlstStores, excelDocument) 'fills the excel document with data from arraylist and has excel do some statistical calculations
        Console.WriteLine("Please press enter to exit...")
        Console.ReadLine() 'waits for the user's confirmation to exit
    End Sub

    Function getFileName() As String
        '------------------------------------------------------------
        '-                Function Name: getFileName                -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: March 30th, 2023              -
        '------------------------------------------------------------
        '- Function Purpose:                                        -
        '- This function is called to read in the file path and name-
        '- of the data to be processed from the user.               -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- (None)                                                   -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- strFilePath - file path/name entered by the user.        -
        '------------------------------------------------------------
        '- Returns:                                                 -
        '- String - file path/name entered by the user.             -
        '------------------------------------------------------------
        Console.Title = "Opening Excel for File Processing" 'sets console title
        Console.Write("Please enter the path and name of the file to process: ") 'prompt the user to enter file path/name
        Dim strFilePath As String = Console.ReadLine() 'get the file path/name from user
        If (Not File.Exists(strFilePath)) Then 'catches if the file does not exist
            Console.Write("There has been a problem locating the file. Please press 'Enter' to exit...")
            Console.ReadLine()
            End
        End If
        Return strFilePath
    End Function

    Function initializeExcelDocument() As Excel.Application
        '------------------------------------------------------------
        '-                Function Name: initializeExcelDocument    -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: March 30th, 2023              -
        '------------------------------------------------------------
        '- Function Purpose:                                        -
        '- This function is called to create a new instance of excel-
        '- and returns it to the main function.                     -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- (None)                                                   -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- anExcelDoc - instance of excel                           -
        '- objCheckExcel - object which holds an instance of excel  -
        '------------------------------------------------------------
        '- Returns:                                                 -
        '- Excel.Application - instance of excel                    -
        '------------------------------------------------------------
        Dim objCheckExcel As Object = Nothing 'initialize object to nothing
        Dim anExcelDoc As Excel.Application 'create a new instance of excel
        Try
            objCheckExcel = GetObject(, "Excel.Application") 'checks to see if excel is already open
        Catch ex As Exception
            'if excel is not open, reaches here
        End Try
        If (objCheckExcel Is Nothing) Then 'if an excel document was not already open, will create a new document and show it
            anExcelDoc = New Excel.Application With {
                .Visible = True
            }
        Else
            anExcelDoc = objCheckExcel 'if an excel document was already open, will grab that instance
            anExcelDoc.Visible = True
        End If

        anExcelDoc.Workbooks.Add() 'adds a workbook to the excel doc
        anExcelDoc.Sheets.Add() 'adds a sheet to the excel doc
        Return anExcelDoc
    End Function

    Function populateData(strFile As String) As ArrayList
        '------------------------------------------------------------
        '-                Function Name: populateData               -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: March 30th, 2023              -
        '------------------------------------------------------------
        '- Function Purpose:                                        -
        '- This function is called to read in the data from the file-
        '- gotten from the user. Each row of the file will be stored-
        '- in a class Stores instance, and those instances will be  -
        '- stored in an arraylist.                                  -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- strFile - name of the file to process.                   -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- arrlstStoreData - arraylist to store class instances.    -
        '- arrTempData - temporary array containing the line from   -
        '-              the file split into its' proper elements.   -
        '- newStore - new instance of Stores class containing the   -
        '-          info from the current line being read from file.-
        '- strrReader - instance of streamreader to read from file. -
        '------------------------------------------------------------
        '- Returns:                                                 -
        '- ArrayList - arraylist to store class instances from the  -
        '-              given data.                                 -
        '------------------------------------------------------------
        Dim strrReader As New StreamReader(strFile) 'initialize a new streamreader to read from the file
        Dim arrlstStoreData As New ArrayList() 'initialize a new arraylist to hold instances of class Stores
        While Not strrReader.EndOfStream 'loop to continue reading from the file until EOF is reached
            Dim arrTempData() As String = strrReader.ReadLine.Split(",") 'splits each line into its' elements
            Dim newStore = New clsStores(arrTempData(0), 'create an instance of class store with the data from the line
                                      {CDbl(arrTempData(1)), CDbl(arrTempData(2)), CDbl(arrTempData(3)), CDbl(arrTempData(4)),
                                      CDbl(arrTempData(5)), CDbl(arrTempData(6)), CDbl(arrTempData(7)), CDbl(arrTempData(8)), CDbl(arrTempData(9)),
                                      CDbl(arrTempData(10)), CDbl(arrTempData(11)), CDbl(arrTempData(12))},
                                      arrTempData(13))
            arrlstStoreData.Add(newStore) 'adds the class instance to the arraylist
        End While
        Return arrlstStoreData
    End Function

    Sub populateExcelDocument(arrlstData As ArrayList, excelDoc As Excel.Application)
        '------------------------------------------------------------
        '-                Subprogram Name: populateExcelDocument    -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: March 30th, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is called to enter data into the excel   -
        '- document.                                                -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- arrlstData - arraylist of class Stores instances.        -
        '- excelDoc - instance of excel.                            -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- arrAlphabet - array containing the letters of the columns-
        '-              that data will be entered into in excel.    -
        '- intRowNum - stores the current row number.               -
        '- tempArr - holds array from current class Stores instance.-
        '------------------------------------------------------------
        excelDoc.Cells(1, 1) = "Store Number" 'block to set headings for columns
        excelDoc.Cells(1, 2) = "January"
        excelDoc.Cells(1, 3) = "February"
        excelDoc.Cells(1, 4) = "March"
        excelDoc.Cells(1, 5) = "April"
        excelDoc.Cells(1, 6) = "May"
        excelDoc.Cells(1, 7) = "June"
        excelDoc.Cells(1, 8) = "July"
        excelDoc.Cells(1, 9) = "August"
        excelDoc.Cells(1, 10) = "September"
        excelDoc.Cells(1, 11) = "October"
        excelDoc.Cells(1, 12) = "November"
        excelDoc.Cells(1, 13) = "December"
        excelDoc.Cells(1, 15) = "Average"
        excelDoc.Cells(1, 16) = "Current Total"
        excelDoc.Cells(1, 17) = "Previous Total"
        excelDoc.Cells(1, 18) = "Sales Variance"
        excelDoc.Cells(1, 20) = "Jan-Mar"
        excelDoc.Cells(1, 21) = "Apr-Jun"
        excelDoc.Cells(1, 22) = "July-Sep"
        excelDoc.Cells(1, 23) = "Oct-Dec"

        Dim intRowNum As Integer = 2 'initialize row number to 2, since row 1 has the header data
        For Each store In arrlstData 'loop to go through each class Stores instance in the arraylist and populate the excel document with relevant information
            excelDoc.Cells(intRowNum, 1) = store.getStoreNumber() 'gets the store number of the Stores instance
            Dim tempArr = store.getArrSales() 'array holding the Stores sales
            For j As Integer = 2 To 13 'fills column 2-13 of a given row with the sales data for the current Stores instance
                excelDoc.Cells(intRowNum, j) = tempArr(j - 2)
            Next
            excelDoc.Cells(intRowNum, 15) = "=average(b" & intRowNum & "..m" & intRowNum & ")" 'tells excel to calculate the average
            excelDoc.Cells(intRowNum, 16) = "=sum(b" & intRowNum & "..m" & intRowNum & ")" 'tells excel to calculate the sum
            excelDoc.Cells(intRowNum, 17) = store.getTotal() 'gets the total for the Stores instance
            excelDoc.Cells(intRowNum, 18) = "=(p" & intRowNum & "/q" & intRowNum & ")" 'tells excel to do division (calcuates variance)
            excelDoc.Cells(intRowNum, 20) = "=sum(b" & intRowNum & "..d" & intRowNum & ")" 'tells excel to calculate the sum
            excelDoc.Cells(intRowNum, 21) = "=sum(e" & intRowNum & "..g" & intRowNum & ")"
            excelDoc.Cells(intRowNum, 22) = "=sum(h" & intRowNum & "..j" & intRowNum & ")"
            excelDoc.Cells(intRowNum, 23) = "=sum(k" & intRowNum & "..m" & intRowNum & ")"
            intRowNum += 1 'increment the row number so that new data will go into the next row
        Next

        Dim arrAlphabet() As String = {"B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "O", "P", "Q", "R", "T", "U", "V", "W"} 'columns that will have data entered into them
        intRowNum += 1 'increment row number so that there is an empty row
        loadCompositAverage(arrAlphabet, intRowNum, excelDoc, arrlstData.Count()) 'calls loadCompositAverage to calculate the average in a set of data
        intRowNum += 1
        loadCompositTotal(arrAlphabet, intRowNum, excelDoc, arrlstData.Count()) 'calls loadCompositTotal to calculate the total in a set of data
        intRowNum += 1
        loadCompositMin(arrAlphabet, intRowNum, excelDoc, arrlstData.Count()) 'calls loadCompositMin to find the min in a set of data
        intRowNum += 1
        loadCompositMax(arrAlphabet, intRowNum, excelDoc, arrlstData.Count()) 'calls loadCompositMax to find the max in a set of data
        Console.WriteLine("Data has been loaded and processed in an Excel document.") 'tells the user that the data is ready
        cleanUp(excelDoc) 'calls cleanUp on the excel instance
    End Sub

    Public Sub loadCompositAverage(arrAlphabet() As String, intRowNum As Integer, excelDoc As Excel.Application, intCount As Integer)
        '------------------------------------------------------------
        '-                Subprogram Name: loadCompositAverage      -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: March 30th, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is called to calculate the average for   -
        '- each column in the excel document.                       -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- arrAlphabet - stores letters of columns where data is to -
        '-               be entered.                                -
        '- intRowNum - stores the current row number for data to be -
        '-              entered into.                               -
        '- excelDoc - instance of excel.                            -
        '- intCount - length of the arrayList holding the class     -
        '-              Stores instances.                           -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- intColumn - stores the current column number.            -
        '------------------------------------------------------------
        excelDoc.Cells(intRowNum, 1) = "Aver:" 'sets the name of the row
        Dim intColumn As Integer = 2 'start intColumn at 2, since column 1 contains the row's name
        For Each letter In arrAlphabet 'loop to go through each column letter and populate the average based on the data present in the document
            excelDoc.Cells(intRowNum, intColumn) = "=average(" & letter & 2 & ".." & letter & intCount + 1 & ")" 'tells excel to calculate average for given data
            intColumn += 1 'increment the column number so that the next column can be processed
            If (intColumn = 14 Or intColumn = 19) Then 'these columns need to be empty, so just skip them
                intColumn += 1
            End If
        Next
    End Sub

    Public Sub loadCompositTotal(arrAlphabet() As String, intRowNum As Integer, excelDoc As Excel.Application, intCount As Integer)
        '------------------------------------------------------------
        '-                Subprogram Name: loadCompositTotal        -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: March 30th, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is called to calculate the total for each-
        '- column in the excel document.                            -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- arrAlphabet - stores letters of columns where data is to -
        '-               be entered.                                -
        '- intRowNum - stores the current row number for data to be -
        '-              entered into.                               -
        '- excelDoc - instance of excel.                            -
        '- intCount - length of the arrayList holding the class     -
        '-              Stores instances.                           -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- intColumn - stores the current column number.            -
        '------------------------------------------------------------
        excelDoc.Cells(intRowNum, 1) = "Total:" 'sets the name of the row
        Dim intColumn = 2 'start intColumn at 2, since column 1 contains the row's name
        For Each letter In arrAlphabet 'loop to go through each column letter and populate the sum based on the data present in the document
            excelDoc.Cells(intRowNum, intColumn) = "=sum(" & letter & 2 & ".." & letter & intCount + 1 & ")" 'tells excel to calculate sum for given data
            intColumn += 1 'increment the column number so that the next column can be processed
            If (intColumn = 14 Or intColumn = 19) Then 'these columns need to be empty, so just skip them
                intColumn += 1
            End If
        Next
    End Sub

    Public Sub loadCompositMin(arrAlphabet() As String, intRowNum As Integer, excelDoc As Excel.Application, intCount As Integer)
        '------------------------------------------------------------
        '-                Subprogram Name: loadCompositMin          -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: March 30th, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is called to calculate the min for each  -
        '- column in the excel document.                            -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- arrAlphabet - stores letters of columns where data is to -
        '-               be entered.                                -
        '- intRowNum - stores the current row number for data to be -
        '-              entered into.                               -
        '- excelDoc - instance of excel.                            -
        '- intCount - length of the arrayList holding the class     -
        '-              Stores instances.                           -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- intColumn - stores the current column number.            -
        '------------------------------------------------------------
        excelDoc.Cells(intRowNum, 1) = "Min" 'sets the name of the row
        Dim intColumn = 2 'start intColumn at 2, since column 1 contains the row's name
        For Each letter In arrAlphabet 'loop to go through each column letter and populate the min based on the data present in the document
            excelDoc.Cells(intRowNum, intColumn) = "=min(" & letter & 2 & ".." & letter & intCount + 1 & ")" 'tells excel to calculate min for given data
            intColumn += 1 'increment the column number so that the next column can be processed
            If (intColumn = 14 Or intColumn = 19) Then 'these columns need to be empty, so just skip them
                intColumn += 1
            End If
        Next
    End Sub

    Public Sub loadCompositMax(arrAlphabet() As String, intRowNum As Integer, excelDoc As Excel.Application, intCount As Integer)
        '------------------------------------------------------------
        '-                Subprogram Name: loadCompositMax          -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: March 30th, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is called to calculate the max for each  -
        '- column in the excel document.                            -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- arrAlphabet - stores letters of columns where data is to -
        '-               be entered.                                -
        '- intRowNum - stores the current row number for data to be -
        '-              entered into.                               -
        '- excelDoc - instance of excel.                            -
        '- intCount - length of the arrayList holding the class     -
        '-              Stores instances.                           -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- intColumn - stores the current column number.            -
        '------------------------------------------------------------
        excelDoc.Cells(intRowNum, 1) = "Max" 'sets the name of the row
        Dim intColumn = 2 'start intColumn at 2, since column 1 contains the row's name
        For Each letter In arrAlphabet 'loop to go through each column letter and populate the max based on the data present in the document
            excelDoc.Cells(intRowNum, intColumn) = "=max(" & letter & 2 & ".." & letter & intCount + 1 & ")" 'tells excel to calculate max for given data
            intColumn += 1 'increment the column number so that the next column can be processed
            If (intColumn = 14 Or intColumn = 19) Then 'these columns need to be empty, so just skip them
                intColumn += 1
            End If
        Next
    End Sub

    Public Sub cleanUp(excelDoc As Excel.Application)
        '------------------------------------------------------------
        '-                Subprogram Name: cleanUp                  -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: March 30th, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is called to exit the excel document and -
        '- make the excel document instance point to nothing.       -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- excelDoc - instance of excel.                            -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- strAnswer - string containing the user's answer to the   -
        '-              given question.                             -
        '------------------------------------------------------------
        Console.WriteLine("Would you like to exit the excel document (Yes/No)?") 'prompts the user on if they would like the exel doc to close
        Dim strAnswer As String = Console.ReadLine() 'gets the answer from the user
        If (strAnswer.ToUpper = "YES" Or strAnswer.ToUpper = "Y") Then 'if they do want it to close
            Try 'placed inside a try/catch in the case that the user already closed the excel document
                excelDoc.Quit() 'try to close the document
            Catch ex As Exception
                Debug.WriteLine("Document already closed.")
            End Try
            Console.WriteLine("If you do not wish to save, press 'Don't Save', if you do wish to save, press 'Save', otherwise, press 'Cancel'.") 'tells the user the options from the excel document
            excelDoc = Nothing 'excelDoc instance points to nothing
        End If
    End Sub
End Module

Public Class clsStores 'class for a Stores instance
    Private intStoreNumber As Integer 'block containing attributes for a store
    Private arrMonthlySales(12) As Double
    Private decTotalSales As Decimal

    Public Sub New(intStoreNum As Integer, arrMonthSales() As Decimal, decTotal As Decimal)
        '------------------------------------------------------------
        '-                Subprogram Name: New                      -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: March 30th, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is called whenever a new store needs to  –
        '- be created.                                              -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- intStoreNum - store's number                             -
        '- arrMonthlySales - array containing each month's sales    -
        '- decTotal - total of previous year's sales                -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        setStoreNumber(intStoreNum) 'pass given values to their setters
        setArrSales(arrMonthSales)
        setTotal(decTotal)
    End Sub

    Public Sub setStoreNumber(intNum As Integer)
        '------------------------------------------------------------
        '-                Subprogram Name: setStoreNumber           -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: March 30th, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is called to assign a passed integer to  -
        '- the instance's 'intStoreNumber' field.                   -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- intNum - number to be assigned to the store's store num  -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        intStoreNumber = intNum
    End Sub

    Public Function getStoreNumber() As Integer
        '------------------------------------------------------------
        '-                Function Name: getStoreNumber             -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: March 30th, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is called to get the current instance's  -
        '- store number.                                            -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- (None)                                                   -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        '- Returns:                                                 -
        '- Integer - containing the current instance's store number -
        '------------------------------------------------------------
        Return (intStoreNumber)
    End Function

    Public Sub setTotal(decTotal As Decimal)
        '------------------------------------------------------------
        '-                Subprogram Name: setTotal                 -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: March 30th, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is called to assign a passed decimal to  -
        '- the instance's 'decTotalSales' field.                    -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- decTotal - number to be assigned to the store's total    -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        decTotalSales = decTotal
    End Sub

    Public Function getTotal() As Decimal
        '------------------------------------------------------------
        '-                Function Name: getTotal                   -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: March 30th, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is called to get the current instance's  -
        '- total.                                                   -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- (None)                                                   -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        '- Returns:                                                 -
        '- Decimal - containing the current store instance's total  -
        '------------------------------------------------------------
        Return (decTotalSales)
    End Function

    Public Sub setArrSales(arrMonthSales() As Decimal)
        '------------------------------------------------------------
        '-                Subprogram Name: setArrSales              -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: March 30th, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is called to assign a passed array to the-
        '- instance's 'arrMonthlySales' field.                      -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- arrMonthSales - containing the store's monthly sales.    -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        For i As Integer = 0 To arrMonthSales.Count() - 1 'loop to go through each element from the passed array and assign it to each element in the 'arrMonthlySales' field
            arrMonthlySales(i) = arrMonthSales(i)
        Next
    End Sub

    Public Function getArrSales() As Array
        '------------------------------------------------------------
        '-                Function Name: getArrSales                -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: March 30th, 2023              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine is called to get the current instance's  -
        '- list of monthly sales.                                   -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- (None)                                                   -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        '- Returns:                                                 -
        '- Array - containing the store's monthly sales.            -
        '------------------------------------------------------------
        Return (arrMonthlySales)
    End Function
End Class
