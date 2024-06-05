Public NotInheritable Class frmAbout
    '------------------------------------------------------------
    '-                File Name : frmAbout.vb                    - 
    '-                Part of Project: cis311hw6                 -
    '------------------------------------------------------------
    '-                Written By: Adam Cossin                    -
    '-                Written On: Feb 21, 2023        -
    '------------------------------------------------------------
    '- File Purpose:                                            -
    '- This file contains the about form which will display an aboutbox- 
    '------------------------------------------------------------

    Private Sub frmAbout_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '------------------------------------------------------------
        '-                Subprogram Name: frmAbout_Load          -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                    -
        '-                Written On: Feb 21, 2023                   -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine is called whenever the 'about' form is shown.-
        '– The form will display relevant info about the application. -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- sender – Identifies which particular control raised the  –
        '-          click event                                     - 
        '- e – Holds the EventArgs object sent to the routine       -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- ApplicationTitle - title of application                  -
        '------------------------------------------------------------
        ' Set the title of the form.
        Dim ApplicationTitle As String
        If My.Application.Info.Title <> "" Then
            ApplicationTitle = My.Application.Info.Title
        Else
            ApplicationTitle = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If
        Me.Text = String.Format("About")
        ' Initialize all of the text displayed on the About Box.
        ' TODO: Customize the application's assembly information in the "Application" pane of the project 
        '    properties dialog (under the "Project" menu).
        Me.LabelProductName.Text = My.Application.Info.ProductName
        Me.LabelVersion.Text = String.Format("Version {0}", My.Application.Info.Version.ToString)
        Me.LabelCopyright.Text = My.Application.Info.Copyright
        Me.LabelCompanyName.Text = My.Application.Info.CompanyName
        Me.TextBoxDescription.Text = My.Application.Info.Description
    End Sub

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
        '------------------------------------------------------------
        '-                Subprogram Name: OKButton_Click        -
        '------------------------------------------------------------
        '-                Written By: Adam Cossin                    -
        '-                Written On: Feb 21, 2023                   -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine is called whenever the ok button is clicked.-
        '- The form will close.                                     -
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        '- sender – Identifies which particular control raised the  –
        '-          click event                                     - 
        '- e – Holds the EventArgs object sent to the routine       -
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        Me.Close() 'close the form
    End Sub

End Class
