Imports System.IO

Module SalesReportingSystem
    '------------------------------------------------------------
    '-                File Name : SalesReportingSystem.vb       - 
    '-                Part of Project: cis311hw5                -
    '------------------------------------------------------------
    '-                Written By: Adam Cossin                   -
    '-                Written On: Feb 11th, 2023                -
    '------------------------------------------------------------
    '- File Purpose:                                            -
    '- This file contains the main application that will read   -
    '- in a file from the user and print out a result containing-
    '- sales report information.                                -
    '------------------------------------------------------------
    '- Program Purpose:                                         -
    '- This program takes in a file path from the user and reads-
    '- in the file by taking each line and making it an instance-
    '- of the 'employee' class. Then, a sales report is         -
    '- generated.                                               -
    '------------------------------------------------------------
    '- Global Variable Dictionary (alphabetically):             -
    '- (None)                                                   -
    '------------------------------------------------------------

    Public Class clsEmployee 'class for an employee instance
        Public Property strFirstName As String 'block containing the atributes for an employee
        Public Property strLastName As String
        Public Property intID As Integer
        Public Property sngMonSales As Single
        Public Property sngTueSales As Single
        Public Property sngWedSales As Single
        Public Property sngThuSales As Single
        Public Property sngFriSales As Single
        Public Property sngTotalSales As Single

        Public Sub New(firstName As String, lastName As String, ID As Integer, mondaySales As Single, tuesdaySales As Single, wednesdaySales As Single,
                       thursdaySales As Single, fridaySales As Single, totalSales As Single)
            '------------------------------------------------------------
            '-                Subprogram Name: New                      -
            '------------------------------------------------------------
            '-                Written By: Adam Cossin                   -
            '-                Written On: Feb 11th, 2023                -
            '------------------------------------------------------------
            '- Subprogram Purpose:                                      -
            '-                                                          -
            '- This subroutine is called whenever a new employee needs  –
            '- to be created.                                           -
            '------------------------------------------------------------
            '- Parameter Dictionary (in parameter order):               -
            '- firstName - the first name of the employee               -
            '- lastName - the last name of the employee                 -
            '- ID - the employee's ID                                   -
            '- mondaySales - the employee's sales for Monday            -
            '- tuesdaySales - the employee's sales for Tuesday          -
            '- wednesdaySales - the employee's sales for Wednesday      -
            '- thursdaySales - the employee's sales for Thursday        -
            '- fridaySales - the employee's sales for Friday            -
            '- totalSales - the employee's total sales for the week     -
            '------------------------------------------------------------
            '- Local Variable Dictionary (alphabetically):              -
            '- (None)                                                   -
            '------------------------------------------------------------
            Me.strFirstName = firstName 'block to assign passed values to the instance of the employee class
            Me.strLastName = lastName
            Me.intID = ID
            Me.sngMonSales = mondaySales
            Me.sngTueSales = tuesdaySales
            Me.sngWedSales = wednesdaySales
            Me.sngThuSales = thursdaySales
            Me.sngFriSales = fridaySales
            Me.sngTotalSales = totalSales
        End Sub

        Public Overrides Function ToString() As String
            '------------------------------------------------------------
            '-                Function Name: ToString                   -
            '------------------------------------------------------------
            '-                Written By: Adam Cossin                   -
            '-                Written On: Feb 11th, 2023                -
            '------------------------------------------------------------
            '- Function Purpose:                                        -
            '-                                                          -
            '- This function is called whenever an employee instance    -
            '- is printed out (ie. 'employee.ToString()) to override    -
            '- the default ToString which would not output the data in  -
            '- the way we want.                                         -
            '------------------------------------------------------------
            '- Parameter Dictionary (in parameter order):               -
            '- (None)                                                   -
            '------------------------------------------------------------
            '- Local Variable Dictionary (alphabetically):              -
            '- strFullName - holds the employee's first and last name   -
            '-              in a single string                          -
            '------------------------------------------------------------
            '- Returns:                                                 -
            '- String – the string representation of the employee       -
            '-          instance.                                       -
            '------------------------------------------------------------
            Dim strFullName As String = strLastName & ", " & strFirstName 'get fullName by having 'lastname, firstname'
            Return String.Format("{0,-15} {1,12} {2,12:C2} {3,12:C2} {4,12:C2} {5,12:C2} {6,12:C2} {7,15:C2}",
                   strFullName, intID, sngMonSales, sngTueSales, sngWedSales, sngThuSales, sngFriSales, sngTotalSales)
        End Function
    End Class

    Sub Main(args As String())
        '------------------------------------------------------------
        '-                Subprogram Name: Main                     -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: Feb 11th, 2023                -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine is called when the program is launched.  -
        '- It will call other methods to get the file name and data.-
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- (None)                                                   -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- lstEmployees - a list of class employee instances        -
        '- strFile - the file name passed by the user               -
        '------------------------------------------------------------
        Dim strFile As String = initialize() 'call initialize to get the file name and to validate the file
        Dim lstEmployees As List(Of clsEmployee) = readInFile(strFile) 'call readInFile to populate the list with employee instances
        printEmployeeData(lstEmployees) 'prints the employee data
        printSalesStatistics(lstEmployees) 'prints the summary data
    End Sub

    Function initialize() As String
        '------------------------------------------------------------
        '-                Function Name: initialize                 -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: Feb 11th, 2023                -
        '------------------------------------------------------------
        '- Function Purpose:                                        -
        '-                                                          -
        '- This function is called to get the file name from the    -
        '- user and to validate the file path.                      -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- (None)                                                   -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- strFilePath - holds the file path                        -
        '------------------------------------------------------------
        '- Returns:                                                 -
        '- String – the file path                                   -
        '------------------------------------------------------------
        Console.Title = "Cybertech Manufacturing Sales Report" 'sets the title of the console
        Console.Write("Please enter the path and name of the file to process: ") 'prompt the user to enter the path and name of the file to be read
        Dim strFilePath As String = Console.ReadLine() 'gets the path name for the file from the user
        If (Not File.Exists(strFilePath)) Then 'if the file doesn't exist
            Console.Write("There has been a problem locating the file. Please press 'Enter' to exit...") 'a message is shown to the user to exit the program
            Console.ReadLine() 'wait for the user to hit enter
            End
        End If
        Return strFilePath 'returns the file path
    End Function

    Function readInFile(strFile As String) As List(Of clsEmployee)
        '------------------------------------------------------------
        '-                Function Name: readInFile                 -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: Feb 11th, 2023                -
        '------------------------------------------------------------
        '- Function Purpose:                                        -
        '-                                                          -
        '- This function is called to read the data from the file   -
        '- into a list of class employee instances.                 -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- strFile - the file path                                  -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- arrTemp - array to hold each element from a single line  -
        '- lstEmployees - list to hold instances of employee        -
        '- sngTotal - holds the employee's total sales for the week -
        '- strrReader - StreamReader to read in data from the file  -
        '------------------------------------------------------------
        '- Returns:                                                 -
        '- List – the list of employees from the file               -
        '------------------------------------------------------------
        Dim strrReader As New StreamReader(strFile) 'initialize a StreamReader to read from the file
        Dim lstEmployees As New List(Of clsEmployee) 'initialize a list to hold class employee instances
        While Not strrReader.EndOfStream 'while loop to read from the file while there is something to read
            Dim arrTemp() As String = strrReader.ReadLine.Split(" ") 'temp array to hold each element from the line
            Dim sngTotal As Single = CSng(arrTemp(3)) + CSng(arrTemp(4)) + CSng(arrTemp(5)) + CSng(arrTemp(6)) + CSng(arrTemp(7)) 'get the total sales for the employee by adding amounts from each day
            lstEmployees.Add(New clsEmployee(arrTemp(0), arrTemp(1), CInt(arrTemp(2)), CSng(arrTemp(3)), CSng(arrTemp(4)), CSng(arrTemp(5)), CSng(arrTemp(6)), CSng(arrTemp(7)), sngTotal)) 'add the new employee instance to the list
        End While
        strrReader.Close() 'close the StreamReader as we do not need to read from the file anymore
        lstEmployees = lstEmployees.OrderBy(Function(emp) emp.intID).ToList() 'order the list of employees by their ID
        Return lstEmployees 'return the ordered list
    End Function

    Sub printEmployeeData(lstOfEmployees As List(Of clsEmployee))
        '------------------------------------------------------------
        '-                Subprogram Name: printEmployeeData        -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: Feb 11th, 2023                -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine is called to print out the employee's    -
        '- name, ID, and sales numbers.                             -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- lstOfEmployees - the list of employee instances          -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- lstSortedByLastName - list of employees sorted by their  -
        '-                      last name, and first name (if last  -
        '-                      name had more than one employee)    -
        '------------------------------------------------------------
        Console.WriteLine(String.Format("{0, 70} {1,68}", "Cybertech Manufacturing" & vbCrLf, "*** Sales Report by ID ***")) 'write header lines to console
        Console.WriteLine(String.Format("{0,-15} {1,12} {2,12} {3,12} {4,12} {5,12} {6,12} {7,15}",
                          "Name", "ID", "Mon Sales", "Tue Sales", "Wed Sales", "Thu Sales", "Fri Sales", "Total Sales"))
        Console.WriteLine(String.Format("{0,-15} {1,11} {2,12} {3,12} {4,12} {5,12} {6,12} {7,15}",
                          "----------------", "---", "----------", "---------", "----------", "----------", "----------", "-------------"))
        For Each employee In lstOfEmployees 'prints the employees out (and since they're already ordered by ID, just printing them out means they are ordered)
            Console.WriteLine(employee.ToString)
        Next
        Console.WriteLine("")
        Dim lstSortedByLastName = From employee In lstOfEmployees 'sorts the employees by last name and then first name if more than one employee had the same last name
                                  Order By employee.strLastName, employee.strFirstName
                                  Select employee
        Console.WriteLine(String.Format("{0, 70} {1,70}", "Cybertech Manufacturing" & vbCrLf, "*** Sales Report by Name ***")) 'write header lines to console
        Console.WriteLine(String.Format("{0,-15} {1,12} {2,12} {3,12} {4,12} {5,12} {6,12} {7,15}",
                          "Name", "ID", "Mon Sales", "Tue Sales", "Wed Sales", "Thu Sales", "Fri Sales", "Total Sales"))
        Console.WriteLine(String.Format("{0,-15} {1,11} {2,12} {3,12} {4,12} {5,12} {6,12} {7,15}",
                          "----------------", "---", "----------", "---------", "----------", "----------", "----------", "-------------"))
        For Each employee In lstSortedByLastName 'prints the employees out ordered by last name and then first name if more than one employee had the same last name
            Console.WriteLine(employee.ToString)
        Next
        Console.WriteLine("")
    End Sub

    Sub printSalesStatistics(lstOfEmployees As List(Of clsEmployee))
        '------------------------------------------------------------
        '-                Subprogram Name: printSalesStatistics     -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                   -
        '-                Written On: Feb 11th, 2023                -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine is called to print out the low, average, -
        '- and high values from each day of the week. It also will  -
        '- print out the number of higher-than and lower-than avg   -
        '- employees in terms of sales. And then also prints out the-
        '- names of the higher-than average selling employees.      -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- lstOfEmployees - the list of employee instances          -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- empGreaterThanAverage - a list of employees who have high-
        '-                        er than average sale numbers.     -
        '- empLessThanAverage - a list of employees who have lower  -
        '                       than average sale numbers.          -
        '------------------------------------------------------------
        Console.WriteLine(String.Format("{0,0}{1, 50}{2,0}", "-----------------------------------------------------------------------------" & vbCrLf, 'print out header lines
                           "Sales Value Statistics" & vbCrLf, "-----------------------------------------------------------------------------"))
        Console.WriteLine(String.Format("{0,14} {1,11} {2,11} {3,11} {4,11} {5,11}", "Mon", "Tue", "Wed", "Thu", "Fri", "Total"))
        Console.WriteLine(String.Format("{0,-5} {1,11:C2} {2,11:C2} {3,11:C2} {4,11:C2} {5,11:C2} {6,11:C2}", "Low", lstOfEmployees.Min(Function(emp) emp.sngMonSales), 'prints out each minimum sales amount for each day
                                        lstOfEmployees.Min(Function(emp) emp.sngTueSales), lstOfEmployees.Min(Function(emp) emp.sngWedSales),
                                        lstOfEmployees.Min(Function(emp) emp.sngThuSales), lstOfEmployees.Min(Function(emp) emp.sngFriSales),
                                        lstOfEmployees.Min(Function(emp) emp.sngTotalSales)))
        Console.WriteLine(String.Format("{0,-5} {1,11:C2} {2,11:C2} {3,11:C2} {4,11:C2} {5,11:C2} {6,11:C2}", "Ave", lstOfEmployees.Average(Function(emp) emp.sngMonSales), 'prints out each average sales amount for each day
                                lstOfEmployees.Average(Function(emp) emp.sngTueSales), lstOfEmployees.Average(Function(emp) emp.sngWedSales),
                                lstOfEmployees.Average(Function(emp) emp.sngThuSales), lstOfEmployees.Average(Function(emp) emp.sngFriSales),
                                lstOfEmployees.Average(Function(emp) emp.sngTotalSales)))
        Console.WriteLine(String.Format("{0,-5} {1,11:C2} {2,11:C2} {3,11:C2} {4,11:C2} {5,11:C2} {6,11:C2}", "High", lstOfEmployees.Max(Function(emp) emp.sngMonSales), 'prints out each maximum sales amount for each day
                        lstOfEmployees.Max(Function(emp) emp.sngTueSales), lstOfEmployees.Max(Function(emp) emp.sngWedSales),
                        lstOfEmployees.Max(Function(emp) emp.sngThuSales), lstOfEmployees.Max(Function(emp) emp.sngFriSales),
                        lstOfEmployees.Max(Function(emp) emp.sngTotalSales)))
        Console.WriteLine("-----------------------------------------------------------------------------")
        Console.WriteLine(String.Format("{0,-5} {1,11:C2} {2,11:C2} {3,11:C2} {4,11:C2} {5,11:C2} {6,11:C2}", "Total", lstOfEmployees.Sum(Function(emp) emp.sngMonSales), 'prints out the total sales amounts for each day
                        lstOfEmployees.Sum(Function(emp) emp.sngTueSales), lstOfEmployees.Sum(Function(emp) emp.sngWedSales),
                        lstOfEmployees.Sum(Function(emp) emp.sngThuSales), lstOfEmployees.Sum(Function(emp) emp.sngFriSales),
                        lstOfEmployees.Sum(Function(emp) emp.sngTotalSales)))
        Console.WriteLine("")
        Dim empLessThanAverage = From employee In lstOfEmployees 'query to get the employees who have less than average sales
                                 Where employee.sngTotalSales < lstOfEmployees.Average(Function(emp) emp.sngTotalSales)
                                 Select employee
        Dim empGreaterThanAverage = From employee In lstOfEmployees 'query to get the employees who have greater than average sales
                                    Where employee.sngTotalSales > lstOfEmployees.Average(Function(emp) emp.sngTotalSales)
                                    Order By employee.strFirstName, employee.strLastName
                                    Select employee
        Console.WriteLine("There are " & empLessThanAverage.Count & " employees who sold less than the average total.") 'prints out the total from 'empLessThanAverage' which will be the number of employees who have below average sales
        Console.WriteLine("")
        Console.WriteLine("There are " & empGreaterThanAverage.Count & " employees who sold above the average total.") 'prints out the total from 'empGreaterThanAverage' which will be the number of employees who have higher than average sales
        Console.WriteLine("")
        Console.WriteLine("The names of the above average selling employees in alphabetical order are:")
        For Each employee In empGreaterThanAverage
            Console.WriteLine(String.Format("{0,-10}{1}", employee.strFirstName, employee.strLastName)) 'prints out the names of the employees who had higher than average sales
        Next
        Console.WriteLine("")
        Console.Write("Please press enter to exit...")
        Console.ReadLine() 'waits for the user to press enter to exit
    End Sub
End Module
