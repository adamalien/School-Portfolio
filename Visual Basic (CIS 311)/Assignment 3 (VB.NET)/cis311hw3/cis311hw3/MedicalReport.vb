Imports System.IO

Module MedicalReport
    '------------------------------------------------------------
    '-                File Name : MedicalReport.vb              - 
    '-                Part of Project: cis311hw                 -
    '------------------------------------------------------------
    '-                Written By: Adam Cossin                   -
    '-                Written On: Jan 27, 2023                  -
    '------------------------------------------------------------
    '- File Purpose:                                            -
    '- This file contains the main console application where the-
    '- user will provide a file, and a report will be generated -
    '- with a histogram based on the information provided. This -
    '- report will also be saved to a file.                     -
    '------------------------------------------------------------
    '- Program Purpose:                                         -
    '- This program reads in a file from the user which will    -
    '- then be used to generate a report in a file that the user-
    '- is then able to view.                                    -
    '------------------------------------------------------------
    '- Global Variable Dictionary (alphabetically):             -
    '- arrlstFileInfo - arrayList which contains each line of   -
    '-                  the file that is read in.               -
    '------------------------------------------------------------

    Dim arrlstFileInfo As ArrayList 'will keep each line of the file that the user provides in an element in the arrayList

    Structure udtReportElements 'this structure will hold the information that we need from the input file
        Dim intNumUniqueDiseases As Integer 'contains the number of unique diseases in the file
        Dim arrlstFrequencyOfDiseases As ArrayList 'contains the frequency of each disease in the file
        Dim intTotalPatients As Integer 'contains the number of total patients in the file
        Dim strDateRange As String 'contains the date range (earliest date and latest date) in the file
    End Structure

    Sub Main()
        '------------------------------------------------------------
        '-                Subprogram Name: Main                     -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: Jan 27, 2023                  -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine is called when the program is launched. It–
        '- calls two methods to initialize the console app and to   -
        '- generate the report for the user.                        -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- (None)                                                   -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------

        initialize()
        getUserResults()
    End Sub

    Sub initialize()
        '------------------------------------------------------------
        '-                Subprogram Name: initialize               -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: Jan 27, 2023                  -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine is called to set the state of the console-
        '- app to have a set title, background color, and text color-
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- (None)                                                   -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        Console.Title = "Medical Practice Data Analysis Application" 'sets the title of the console window
        Console.BackgroundColor = ConsoleColor.Blue 'background color will be blue
        Console.ForegroundColor = ConsoleColor.Yellow 'text color will be yellow
        Console.Clear() 'clears the console window of text
    End Sub

    Sub getUserResults()
        '------------------------------------------------------------
        '-                Subprogram Name: getUserResults           -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: Jan 27, 2023                  -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine is called to get the file names from the -
        '- user and ultimately call methods to write and display    -
        '- the result of the processing of the file.                -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- (None)                                                   -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- strReadFrom - The name of the user's input file.         -
        '- strWriteTo - The name of the file to write to.           -
        '------------------------------------------------------------
        Console.WriteLine("Please enter the path and name of the file to process: ") 'prompt the user to enter the path and name of the file to be read
        Dim strReadFrom As String = Console.ReadLine() 'gets the path name for the file from the user
        validateInputFile(strReadFrom) 'calls validateInputFile on the user's file path
        getData(strReadFrom) 'calls getData on the user's file path

        Dim udtMedicalReport As udtReportElements 'create a new udtReportElements to store the information for this report
        udtMedicalReport.arrlstFrequencyOfDiseases = findFrequency(arrlstFileInfo) 'next few lines populate the udtMedicalReport with the relevant information through methods
        udtMedicalReport.intNumUniqueDiseases = udtMedicalReport.arrlstFrequencyOfDiseases.Count
        udtMedicalReport.intTotalPatients = arrlstFileInfo.Count
        udtMedicalReport.strDateRange = getDateRange(arrlstFileInfo)

        Console.WriteLine("Processing completed...") 'lets the user know that the file processing is done
        Console.WriteLine("Please enter the path and name of the report file to generate: ") 'prompts the user to enter the path and name of the destination file
        Dim strWriteTo As String = Console.ReadLine() 'gets the path name for the file to be created and written to
        createOutputFile(strWriteTo) 'calls method createOutputFile on the file path
        generateReport(strWriteTo, udtMedicalReport) 'calls generateReport on the file path and includes the udtMedicalReport
        Console.WriteLine("Report file generation completed...") 'lets the user know that their report file has been successfully generated

        finalResultToShow(strWriteTo) 'calls finalResultToShow on the file path
    End Sub

    Sub finalResultToShow(strWrite As String)
        '------------------------------------------------------------
        '-                Subprogram Name: getUserResults           -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: Jan 27, 2023                  -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine is called to show the final choice to the-
        '- user on if they would like to see their generated report.-
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- strWrite - the file path that the report was written to  -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- strAnswer - the user's answer on if they want to see the -
        '-              generated report file.                      -
        '- strReader - the streamreader to read the report file.    -
        '------------------------------------------------------------
        Console.WriteLine("Would you like to see the report file? [Y/n]") 'asks the user if they would like to see the generated report file 
        Dim strAnswer As String = Console.ReadLine() 'gets the answer from the user
        If (strAnswer.ToUpper.Equals("Y") Or strAnswer.ToUpper.Equals("YES")) Then 'if the user DOES want to see the file, we show it
            Dim strReader As StreamReader = New StreamReader(strWrite) 'create an instance of streamreader to be able to read the report file
            While (Not strReader.EndOfStream) 'while the reader still has something to read
                Console.WriteLine(strReader.ReadLine) 'the lines of the file are shown on the console screen
            End While
            Console.WriteLine("Please press 'Enter' to exit...") 'since the program is finished, prompts the user to enter to close the program
            Console.ReadLine()
            End 'terminates the program
        Else
            Console.WriteLine("Please press 'Enter' to exit...") 'if they did not want to see the contents of the file, the program will prompt the user to enter to close the program
            Console.ReadLine()
            End 'terminates the program
        End If
    End Sub

    Sub validateInputFile(strFilePath As String)
        '------------------------------------------------------------
        '-                Subprogram Name: validateInputFile        -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: Jan 27, 2023                  -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine is called to make sure that the file that-
        '- the user provided for input is valid to be read from.    -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- strFilePath - the file path for the file to be read.     -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        If (Not File.Exists(strFilePath)) Then 'if the file does not exist, we cannot do anything further
            Console.WriteLine("There has been a problem locating the file. Please press 'Enter' to exit...") 'a message is shown to the user to exit the program
            Console.ReadLine()
            End 'terminates the program
        End If
    End Sub

    Sub getData(strPath As String)
        '------------------------------------------------------------
        '-                Subprogram Name: getData                  -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: Jan 27, 2023                  -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine is called to populate the global arrayList-
        '- with the information from the user's input file.         -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- strPath- the file path for the file to be read.          -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- strrReader - instance of streamreader to read the file.  -
        '------------------------------------------------------------
        arrlstFileInfo = New ArrayList() 'initialize the arrayList
        Dim strrReader As StreamReader = New StreamReader(strPath) 'create an instance of streamreader to read in the user's file with provided file path
        While Not strrReader.EndOfStream 'while the streamreader has something to read
            arrlstFileInfo.Add(strrReader.ReadLine) 'the line of the file is added to the arrayList
        End While
        strrReader.Close() 'streamreader is closed, as the file is done being read in
    End Sub

    Sub createOutputFile(strFilePath As String)
        '------------------------------------------------------------
        '-                Subprogram Name: createOutputFile         -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: Jan 27, 2023                  -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine is called to create the output file that -
        '- the user specifies.                                      -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- strFilePath- the file path for the file to be written to.-
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- stwWriter - instance of streamwriter to create the file. -
        '------------------------------------------------------------
        Try 'attempts to create the file if the path is accessible
            Dim stwWriter As StreamWriter = New StreamWriter(strFilePath) 'creates the file with the user's specified path
            stwWriter.Close() 'closes the streamwriter as it is not used further in this sub
        Catch ex As Exception 'catches if the file path is invalid
            Console.WriteLine("There is a problem with the file path. Please press 'Enter' to exit...") 'display an error message to the user
            Console.ReadLine()
            End 'terminates the program
        End Try
    End Sub

    Function findFrequency(arrlstList As ArrayList)
        '------------------------------------------------------------
        '-                Function Name: findFrequency              -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: Jan 27, 2023                  -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This function is called to return the frequency of each  -
        '- disease from the input file.                             -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- arrlstList- the list containing all of the items to be   -
        '-              evaluated.                                  -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- arrlstVisited - boolean array to keep track of if a      -
        '-                  disease has been seen.                  -
        '- arrlstResult - the array containing the final result of  -
        '               disease name and frequency count.           -
        '- arrTemp - temporary array to hold the initial result data-
        '-          which contains some garbage values.             -
        '- arrPatientVisit -array containing the information of a   -
        '-                   specific patient visit                 -
        '- arrPatientVisitNext - array containing the information of-
        '                       the next patient visit in the list. -
        '- intCount - keeps track of the frequency of a disease.    -
        '- strDiseaseName - disease name from the first patient visit-
        '- strDiseaseNameTwo - disease name from the second patient -
        '                       visit.                              -
        '------------------------------------------------------------
        '- Returns:                                                 -
        '- ArrayList – containing the final disease name to frequency-
        '               list.                                       -
        '------------------------------------------------------------

        Dim arrVisited(arrlstList.Count) As Boolean
        Dim arrTemp(arrlstList.Count) As String
        For i = 0 To arrlstList.Count - 1 'outer loop to check one instance of a patient's visit
            Dim arrPatientVisit As Array = arrlstList(i).Split(vbTab) 'array to split the information from the first patient's visit
            Dim strDiseaseName As String = arrPatientVisit(4) 'gets the disease name from the patient visit info
            If (arrVisited(i) = False) Then 'if arrVisited in this position is false, that means the disease has not yet been seen
                Dim intCount = 1 'intCount is initialized to 1 to represent that this disease has been seen once now
                For j = i + 1 To arrlstList.Count - 1 'inner loop to check the next instance of a patient's visit
                    Dim arrPatientVisitNext As Array = arrlstList(j).Split(vbTab) 'array to split the information from the second patient's visit
                    Dim strDiseaseNameTwo As String = arrPatientVisitNext(4) 'gets the disease name from the patient visit info
                    If (strDiseaseName = strDiseaseNameTwo) Then 'if the diseases from both visit instances are the same
                        arrVisited(j) = True 'then that means this disease should also show it has been visited in the other array
                        intCount += 1 'the count of how many times the disease has been seen is increased by 1
                    End If
                Next
                arrTemp(i) = strDiseaseName & vbTab & intCount.ToString 'temp array maintains the result with disease name and frequency on valid cases (will be the first instance the disease was seen)
            End If
        Next
        Dim arrlstResult = New ArrayList 'new arrayList initialized to contain the final result
        For i = 0 To arrTemp.Count - 1 'loop to go through the arrTemp array and remove any garbage values
            If (arrTemp(i) <> Nothing) Then 'if the value from arrTemp at position 'i' is not 'Nothing', then it is added to the arrlstResult arrayList
                arrlstResult.Add(arrTemp(i))
            End If
        Next
        Return arrlstResult 'returns the final result which will contain a list of diseases and their frequencies
    End Function

    Function orderFrequency(arrlstList As ArrayList)
        '------------------------------------------------------------
        '-                Function Name: orderFrequency             -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: Jan 27, 2023                  -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This function is called to order the diseases based on   -
        '- their frequencies for use in the histogram.              -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- arrlstList- the list containing all of the items to be   -
        '-              evaluated.                                  -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- arrlstDiseases - arraylist containing only the disease   -
        '-                  names                                   -
        '- arrlstFinalList - contains the final result.             -
        '- arrlstFrequencies -arraylist containing only the frquency-
        '-                  of the diseases.                        -
        '- intMin - contains the minimum frequency                  -
        '- intTemp - contains a temporary minimum value             -
        '- strTemp - contains a temporary string value              - 
        '------------------------------------------------------------
        '- Returns:                                                 -
        '- ArrayList –containing the final disease name to frequency-
        '               list in sorted order.                       -
        '------------------------------------------------------------
        Dim arrlstDiseases = New ArrayList 'arraylist initialized to hold only disease names
        Dim arrlstFrequencies = New ArrayList 'arraylist initialized to hold only frequencies in parallel with arrlstDiseases
        For i = 0 To arrlstList.Count - 1 'loop to populate the above arrays with their respective info
            arrlstDiseases.Add(arrlstList(i).Split(vbTab)(0))
            arrlstFrequencies.Add(arrlstList(i).Split(vbTab)(1))
        Next

        Dim intMin As Integer 'create intMin to hold min value
        For i = 0 To arrlstDiseases.Count - 2 'outer loop to update the value of intMin and then to update the arrays with appropriate values
            intMin = i
            For j As Integer = i + 1 To arrlstDiseases.Count - 1 'inner loop to check if intMin needs to be updated based on the frequency
                If arrlstFrequencies(j) < arrlstFrequencies(intMin) Then
                    intMin = j
                End If
            Next
            Dim intTemp As Integer = arrlstFrequencies(intMin) 'initialize intTemp to hold the value of the frequency at intMin
            Dim strTemp As String = arrlstDiseases(intMin) 'initialize strTemp to hold the value of the disease at intMin
            arrlstFrequencies(intMin) = arrlstFrequencies(i) 'the positions of items in the respecive arrays are swapped based on what currently contains the minimum value
            arrlstDiseases(intMin) = arrlstDiseases(i)
            arrlstFrequencies(i) = intTemp
            arrlstDiseases(i) = strTemp
        Next

        Dim arrlstFinalList = New ArrayList 'initialize arrlstFinalList to contain the final result
        For i = 0 To arrlstDiseases.Count - 1 'loop to populate arrlstFinalList
            arrlstFinalList.Add(arrlstDiseases(i) & vbTab & arrlstFrequencies(i)) 'populates the arrayList with the respective disease and frequency info in order
        Next
        Return arrlstFinalList 'returns this list
    End Function

    Function getDateRange(arrlstInfo As ArrayList)
        '------------------------------------------------------------
        '-                Function Name: getDateRange               -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: Jan 27, 2023                  -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This function is called to get the oldest and newet dates-
        '- in the input file.
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- arrlstInfo- the list containing all of the items to be   -
        '-              evaluated.                                  -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- arrPatientVisit - array containing info from a patient   -
        '-                  visit.                                  -
        '- dateNewestDate - the most recent date in the file.       -
        '- dateOldestDate - the earliest date in the file.          -
        '- datePatientVisit - the date of visit in a patient's visit-
        '------------------------------------------------------------
        '- Returns:                                                 -
        '- String –containing the oldest and newest dates.          -
        '------------------------------------------------------------
        Dim dateOldestDate As Date = Date.Now 'set to current date
        Dim dateNewestDate As Date = Date.MinValue 'set to earliest date allowed
        For i = 0 To arrlstInfo.Count - 1 'loop to go through each item in the arraylist passed
            Dim arrPatientVisit As Array = arrlstInfo(i).Split(vbTab) 'array containing the info from this patient visit
            Dim datePatientVisit As Date = arrPatientVisit(3) 'gets the date value from that array
            If (datePatientVisit < dateOldestDate) Then 'if the patient's visit is less than the oldest date, the patient's visit date is earlier, so update oldest date
                dateOldestDate = datePatientVisit
            End If
            If (datePatientVisit > dateNewestDate) Then 'if the patient's visit is greater than the newest date, the patient's visit date is newer, so update newest date
                dateNewestDate = datePatientVisit
            End If
        Next
        Return dateOldestDate & vbTab & dateNewestDate 'return the oldest and newest dates (date range)
    End Function

    Function findNumStars(intDiseaseNum As Integer, intMaxNum As Integer, intMaxScale As Integer)
        '------------------------------------------------------------
        '-                Function Name: findNumStars               -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: Jan 27, 2023                  -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This function is called to get the number of stars that  -
        '- should be displayed for a given disease based on its'    -
        '- frequency.                                               -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- intDiseaseNum - number of diseases.                      -
        '- intMaxNum - largest occurence of a disease.              -
        '- intMaxScale - max scale value.                           -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        '- Returns:                                                 -
        '- Integer - containing the number of stars to be displayed -
        '------------------------------------------------------------
        Return (intDiseaseNum / intMaxNum) * intMaxScale
    End Function

    Function findScale(intMaxNum As Integer)
        '------------------------------------------------------------
        '-                Function Name: findScale                  -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: Jan 27, 2023                  -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This function is called to get the numbers to scale to   -
        '- for the histogram.                                       -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- intMaxNum - largest occurence of a disease.              -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        '- Returns:                                                 -
        '- Integer - containing scale to be used.                   -
        '------------------------------------------------------------
        If (intMaxNum <= 10) Then 'if block to try and set the scale to the number of stars that will be displayed on the histogram
            Return 100
        ElseIf (intMaxNum <= 50) Then
            Return 50
        ElseIf (intMaxNum <= 100) Then
            Return 25
        Else
            Return 10
        End If
    End Function

    Function findIntervals(intScale As Integer)
        '------------------------------------------------------------
        '-                Function Name: findIntervals              -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: Jan 27, 2023                  -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This function is called to get the numbers to show on the-
        '- bottom of the histogram.                                 -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- intScale - the scale that will be used for the histogram.-
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        '- Returns:                                                 -
        '- Integer - containing scale to be used.                   -
        '------------------------------------------------------------
        If (intScale <= 50) Then 'if block to attempt to determine how the histogram should be scaled at the bottom
            Return 10
        ElseIf (intScale <= 100) Then
            Return 25
        ElseIf (intScale <= 1000) Then
            Return 50
        Else
            Return 100
        End If
    End Function

    Function findMaxDiseaseOccurance(arrlstDiseases As ArrayList)
        '------------------------------------------------------------
        '-                Function Name: findMaxDiseaseOccurance    -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: Jan 27, 2023                  -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This function is called to get the highest frequency of  -
        '- the diseases.                                            -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- arrlstDiseases - array of diseases and their frequencies.-
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- arrDiseaseElements -splits the disease and frequency from-
        '-                  that particular instance in the array.  -
        '- intMaxNum - keeps track of the highest frequency.        -
        '------------------------------------------------------------
        '- Returns:                                                 -
        '- Integer - containing the max frequency.                  -
        '------------------------------------------------------------
        Dim intMaxNum As Integer = 0 'initialize intMaxNum to 0
        For i = 0 To arrlstDiseases.Count - 1 'loop to check the frequencies of each disease
            Dim arrDiseaseElements = arrlstDiseases(i).Split(vbTab) 'split disease name from the frequency
            If (arrDiseaseElements(1) > intMaxNum) Then 'if that disease's frequency is greater than the current max, set that to the max
                intMaxNum = arrDiseaseElements(1)
            End If
        Next
        Return intMaxNum 'returns the max frequency
    End Function

    Sub generateReport(strFileName As String, udtReportInstance As udtReportElements)
        '------------------------------------------------------------
        '-                Subprogram Name: generateReport           -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: Jan 27, 2023                  -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine is called to generate and write the final-
        '- report to the file.                                      -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- strFileName- the file path for the file to be written to.-
        '- udtReportInstance - the report instance that needs to be -
        '-                      processed.                          -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- arrDates - array containing the date range.              -
        '- arrDiseaseInstance - array containing the split diseaes  -
        '-                      info (frequency and name)           -
        '- arrlstSortedFrequency - arrayList containing sorted      -
        '                          disease frequency.               -
        '- intIntervals - the number used to determine intervals.   -
        '- intMaxDisease - the max frequency from a disease.        -
        '- intNumStars - the number used to determine star count.   -
        '- intScaleLine - the number used to determine scale.       -
        '- strTemp - formatting for writing the '*' character for   -
        '-            each disease in the histogram.                -
        '- stwWrite - streamwriter instance to write to the file.   -
        '------------------------------------------------------------
        Dim stwWrite As StreamWriter = New StreamWriter(strFileName) 'instance of streamwriter to write to the report file
        Dim arrDates() As String = udtReportInstance.strDateRange.Split(vbTab) 'get the dates from the date range
        Dim intMaxDisease = findMaxDiseaseOccurance(udtReportInstance.arrlstFrequencyOfDiseases) 'get the max frequency of a disease (max number)
        Dim intScaleLine = findScale(intMaxDisease) 'gets the number for scale
        Dim arrlstSortedFrequency = orderFrequency(udtReportInstance.arrlstFrequencyOfDiseases) 'gets the sorted array for disease and their frequencies
        Dim intIntervals = findIntervals(intMaxDisease) 'gets the number for intervals
        stwWrite.WriteLine("                        MuchoMedical Health Center") 'block of write statements to write to the file
        stwWrite.WriteLine("          Disease Report for the period " & arrDates(0) & " through " & arrDates(1))
        stwWrite.WriteLine("There were a total of " & udtReportInstance.intNumUniqueDiseases & " unique diseases observed.")
        stwWrite.WriteLine("A total of " & udtReportInstance.intTotalPatients & " patient encounters were held.")
        stwWrite.WriteLine()
        stwWrite.WriteLine("Relative Histogram of each disease:")
        stwWrite.WriteLine()
        For i = 0 To arrlstSortedFrequency.Count - 1 'loop to write each disease and frequency to the file
            Dim arrDiseaseInstance = arrlstSortedFrequency(i).Split(vbTab) 'splits the disease instance into its' respective components
            Dim intNumStars = findNumStars(arrDiseaseInstance(1), intMaxDisease, intScaleLine) 'finds the number of stars to use for this particular disease
            Dim strTemp = New String("*", intNumStars) 'constructs a string with '*' in the correct quantity from above
            stwWrite.WriteLine(String.Format("{0, -25}{1,3}{2,5}{3,-10}", arrDiseaseInstance(0), ": ", arrDiseaseInstance(1).ToString.PadLeft(4, "0") & vbTab, strTemp)) 'formatted string to write the disease info to a line of the histogram in the file
        Next
        stwWrite.WriteLine("--------------------------------------------------------------------------------------------")
        stwWrite.Write(String.Format("{0, -25}{1,3}{2,5}", "Scale", " : ", udtReportInstance.intTotalPatients.ToString.PadLeft(4, "0"))) 'write the first part of the line for the scale
        For j = 0 To 3 'arbitrary choice to show amount of numbers at the bottom for the histogram scale
            If ((intIntervals * (j + 1)) < intMaxDisease) Then
                stwWrite.Write(String.Format("{0, 20}", intIntervals * (j + 1))) 'writes the number for scale at the bottom of the histogram
            End If
        Next
        stwWrite.WriteLine()
        stwWrite.Close() 'closes the streamwriter and the file is completed
    End Sub

End Module
