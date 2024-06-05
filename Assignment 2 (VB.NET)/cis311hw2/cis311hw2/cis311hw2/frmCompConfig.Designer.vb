<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCompConfig
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
        Me.lblCustName = New System.Windows.Forms.Label()
        Me.txtCustName = New System.Windows.Forms.TextBox()
        Me.lblQuantity = New System.Windows.Forms.Label()
        Me.txtQuantity = New System.Windows.Forms.TextBox()
        Me.grbFormFactor = New System.Windows.Forms.GroupBox()
        Me.rdoTablet = New System.Windows.Forms.RadioButton()
        Me.rdoNotebook = New System.Windows.Forms.RadioButton()
        Me.rdoDesktop = New System.Windows.Forms.RadioButton()
        Me.btnPlaceOrder = New System.Windows.Forms.Button()
        Me.grbNotebookCool = New System.Windows.Forms.GroupBox()
        Me.chkNotebookCool = New System.Windows.Forms.CheckBox()
        Me.grbNotebookSD = New System.Windows.Forms.GroupBox()
        Me.chkNotebookSD = New System.Windows.Forms.CheckBox()
        Me.grbNotebookDVD = New System.Windows.Forms.GroupBox()
        Me.chkNotebookDVD = New System.Windows.Forms.CheckBox()
        Me.grbNotebookProcessor = New System.Windows.Forms.GroupBox()
        Me.rdoNotebookLgProc = New System.Windows.Forms.RadioButton()
        Me.rdoNotebookSmProc = New System.Windows.Forms.RadioButton()
        Me.grbNotebookHD = New System.Windows.Forms.GroupBox()
        Me.rdoNotebookLgHD = New System.Windows.Forms.RadioButton()
        Me.rdoNotebookSmHD = New System.Windows.Forms.RadioButton()
        Me.grbNotebookRAM = New System.Windows.Forms.GroupBox()
        Me.rdoNotebookLgRAM = New System.Windows.Forms.RadioButton()
        Me.rdoNotebookSmRAM = New System.Windows.Forms.RadioButton()
        Me.grbNotebookVideo = New System.Windows.Forms.GroupBox()
        Me.rdoNotebookATI = New System.Windows.Forms.RadioButton()
        Me.rdoNotebookIntel = New System.Windows.Forms.RadioButton()
        Me.grbNotebookCam = New System.Windows.Forms.GroupBox()
        Me.chkNotebookCam = New System.Windows.Forms.CheckBox()
        Me.grbTabletHD = New System.Windows.Forms.GroupBox()
        Me.rdoTabletLrgHD = New System.Windows.Forms.RadioButton()
        Me.rdoTabletMedHD = New System.Windows.Forms.RadioButton()
        Me.rdoTabletSmHD = New System.Windows.Forms.RadioButton()
        Me.grbTabletSD = New System.Windows.Forms.GroupBox()
        Me.chkTabletSD = New System.Windows.Forms.CheckBox()
        Me.grbTabletProcessor = New System.Windows.Forms.GroupBox()
        Me.rdoTabletLgProc = New System.Windows.Forms.RadioButton()
        Me.rdoTabletSmProc = New System.Windows.Forms.RadioButton()
        Me.grbTabletCam = New System.Windows.Forms.GroupBox()
        Me.chkTabletCam = New System.Windows.Forms.CheckBox()
        Me.grbDesktopVideo = New System.Windows.Forms.GroupBox()
        Me.rdoDesktopATI = New System.Windows.Forms.RadioButton()
        Me.rdoDesktopNVIDIA = New System.Windows.Forms.RadioButton()
        Me.grbDesktopRAM = New System.Windows.Forms.GroupBox()
        Me.rdoDesktopLrgRAM = New System.Windows.Forms.RadioButton()
        Me.rdoDesktopMedRAM = New System.Windows.Forms.RadioButton()
        Me.rdoDesktopSmRAM = New System.Windows.Forms.RadioButton()
        Me.grbDesktopHD = New System.Windows.Forms.GroupBox()
        Me.rdoDesktopLrgHD = New System.Windows.Forms.RadioButton()
        Me.rdoDesktopMedHD = New System.Windows.Forms.RadioButton()
        Me.rdoDesktopSmHD = New System.Windows.Forms.RadioButton()
        Me.grbDesktopProcessor = New System.Windows.Forms.GroupBox()
        Me.rdoDesktopLgProc = New System.Windows.Forms.RadioButton()
        Me.rdoDesktopSmProc = New System.Windows.Forms.RadioButton()
        Me.grbDesktopDVD = New System.Windows.Forms.GroupBox()
        Me.chkDesktopDVD = New System.Windows.Forms.CheckBox()
        Me.grbDesktopSound = New System.Windows.Forms.GroupBox()
        Me.chkDesktopSound = New System.Windows.Forms.CheckBox()
        Me.grbDesktopCool = New System.Windows.Forms.GroupBox()
        Me.chkDesktopCool = New System.Windows.Forms.CheckBox()
        Me.grbFormFactor.SuspendLayout()
        Me.grbNotebookCool.SuspendLayout()
        Me.grbNotebookSD.SuspendLayout()
        Me.grbNotebookDVD.SuspendLayout()
        Me.grbNotebookProcessor.SuspendLayout()
        Me.grbNotebookHD.SuspendLayout()
        Me.grbNotebookRAM.SuspendLayout()
        Me.grbNotebookVideo.SuspendLayout()
        Me.grbNotebookCam.SuspendLayout()
        Me.grbTabletHD.SuspendLayout()
        Me.grbTabletSD.SuspendLayout()
        Me.grbTabletProcessor.SuspendLayout()
        Me.grbTabletCam.SuspendLayout()
        Me.grbDesktopVideo.SuspendLayout()
        Me.grbDesktopRAM.SuspendLayout()
        Me.grbDesktopHD.SuspendLayout()
        Me.grbDesktopProcessor.SuspendLayout()
        Me.grbDesktopDVD.SuspendLayout()
        Me.grbDesktopSound.SuspendLayout()
        Me.grbDesktopCool.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblCustName
        '
        Me.lblCustName.AutoSize = True
        Me.lblCustName.Location = New System.Drawing.Point(10, 10)
        Me.lblCustName.Name = "lblCustName"
        Me.lblCustName.Size = New System.Drawing.Size(97, 15)
        Me.lblCustName.TabIndex = 0
        Me.lblCustName.Text = "Customer Name:"
        '
        'txtCustName
        '
        Me.txtCustName.Location = New System.Drawing.Point(113, 7)
        Me.txtCustName.Name = "txtCustName"
        Me.txtCustName.Size = New System.Drawing.Size(257, 23)
        Me.txtCustName.TabIndex = 1
        '
        'lblQuantity
        '
        Me.lblQuantity.AutoSize = True
        Me.lblQuantity.Location = New System.Drawing.Point(661, 10)
        Me.lblQuantity.Name = "lblQuantity"
        Me.lblQuantity.Size = New System.Drawing.Size(56, 15)
        Me.lblQuantity.TabIndex = 2
        Me.lblQuantity.Text = "Quantity:"
        '
        'txtQuantity
        '
        Me.txtQuantity.Location = New System.Drawing.Point(723, 7)
        Me.txtQuantity.Name = "txtQuantity"
        Me.txtQuantity.Size = New System.Drawing.Size(65, 23)
        Me.txtQuantity.TabIndex = 3
        '
        'grbFormFactor
        '
        Me.grbFormFactor.Controls.Add(Me.rdoTablet)
        Me.grbFormFactor.Controls.Add(Me.rdoNotebook)
        Me.grbFormFactor.Controls.Add(Me.rdoDesktop)
        Me.grbFormFactor.Location = New System.Drawing.Point(21, 53)
        Me.grbFormFactor.Name = "grbFormFactor"
        Me.grbFormFactor.Size = New System.Drawing.Size(767, 40)
        Me.grbFormFactor.TabIndex = 4
        Me.grbFormFactor.TabStop = False
        Me.grbFormFactor.Text = "Form Factor:"
        '
        'rdoTablet
        '
        Me.rdoTablet.AutoSize = True
        Me.rdoTablet.Location = New System.Drawing.Point(619, 15)
        Me.rdoTablet.Name = "rdoTablet"
        Me.rdoTablet.Size = New System.Drawing.Size(56, 19)
        Me.rdoTablet.TabIndex = 2
        Me.rdoTablet.Text = "Tablet"
        Me.rdoTablet.UseVisualStyleBackColor = True
        '
        'rdoNotebook
        '
        Me.rdoNotebook.AutoSize = True
        Me.rdoNotebook.Location = New System.Drawing.Point(353, 15)
        Me.rdoNotebook.Name = "rdoNotebook"
        Me.rdoNotebook.Size = New System.Drawing.Size(78, 19)
        Me.rdoNotebook.TabIndex = 1
        Me.rdoNotebook.Text = "Notebook"
        Me.rdoNotebook.UseVisualStyleBackColor = True
        '
        'rdoDesktop
        '
        Me.rdoDesktop.AutoSize = True
        Me.rdoDesktop.Checked = True
        Me.rdoDesktop.Location = New System.Drawing.Point(92, 15)
        Me.rdoDesktop.Name = "rdoDesktop"
        Me.rdoDesktop.Size = New System.Drawing.Size(68, 19)
        Me.rdoDesktop.TabIndex = 0
        Me.rdoDesktop.TabStop = True
        Me.rdoDesktop.Text = "Desktop"
        Me.rdoDesktop.UseVisualStyleBackColor = True
        '
        'btnPlaceOrder
        '
        Me.btnPlaceOrder.Location = New System.Drawing.Point(62, 428)
        Me.btnPlaceOrder.Name = "btnPlaceOrder"
        Me.btnPlaceOrder.Size = New System.Drawing.Size(668, 43)
        Me.btnPlaceOrder.TabIndex = 5
        Me.btnPlaceOrder.Text = "Place Order for Custom Computers"
        Me.btnPlaceOrder.UseVisualStyleBackColor = True
        '
        'grbNotebookCool
        '
        Me.grbNotebookCool.Controls.Add(Me.chkNotebookCool)
        Me.grbNotebookCool.Location = New System.Drawing.Point(316, 367)
        Me.grbNotebookCool.Name = "grbNotebookCool"
        Me.grbNotebookCool.Size = New System.Drawing.Size(103, 43)
        Me.grbNotebookCool.TabIndex = 19
        Me.grbNotebookCool.TabStop = False
        Me.grbNotebookCool.Text = "Liquid Cooling"
        Me.grbNotebookCool.Visible = False
        '
        'chkNotebookCool
        '
        Me.chkNotebookCool.AutoSize = True
        Me.chkNotebookCool.Location = New System.Drawing.Point(7, 18)
        Me.chkNotebookCool.Name = "chkNotebookCool"
        Me.chkNotebookCool.Size = New System.Drawing.Size(48, 19)
        Me.chkNotebookCool.TabIndex = 0
        Me.chkNotebookCool.Text = "Yes?"
        Me.chkNotebookCool.UseVisualStyleBackColor = True
        '
        'grbNotebookSD
        '
        Me.grbNotebookSD.Controls.Add(Me.chkNotebookSD)
        Me.grbNotebookSD.Location = New System.Drawing.Point(433, 318)
        Me.grbNotebookSD.Name = "grbNotebookSD"
        Me.grbNotebookSD.Size = New System.Drawing.Size(80, 43)
        Me.grbNotebookSD.TabIndex = 18
        Me.grbNotebookSD.TabStop = False
        Me.grbNotebookSD.Text = "SD Card"
        Me.grbNotebookSD.Visible = False
        '
        'chkNotebookSD
        '
        Me.chkNotebookSD.AutoSize = True
        Me.chkNotebookSD.Location = New System.Drawing.Point(9, 18)
        Me.chkNotebookSD.Name = "chkNotebookSD"
        Me.chkNotebookSD.Size = New System.Drawing.Size(48, 19)
        Me.chkNotebookSD.TabIndex = 0
        Me.chkNotebookSD.Text = "Yes?"
        Me.chkNotebookSD.UseVisualStyleBackColor = True
        '
        'grbNotebookDVD
        '
        Me.grbNotebookDVD.Controls.Add(Me.chkNotebookDVD)
        Me.grbNotebookDVD.Location = New System.Drawing.Point(316, 318)
        Me.grbNotebookDVD.Name = "grbNotebookDVD"
        Me.grbNotebookDVD.Size = New System.Drawing.Size(80, 43)
        Me.grbNotebookDVD.TabIndex = 17
        Me.grbNotebookDVD.TabStop = False
        Me.grbNotebookDVD.Text = "DVD-ROM"
        Me.grbNotebookDVD.Visible = False
        '
        'chkNotebookDVD
        '
        Me.chkNotebookDVD.AutoSize = True
        Me.chkNotebookDVD.Location = New System.Drawing.Point(9, 18)
        Me.chkNotebookDVD.Name = "chkNotebookDVD"
        Me.chkNotebookDVD.Size = New System.Drawing.Size(48, 19)
        Me.chkNotebookDVD.TabIndex = 0
        Me.chkNotebookDVD.Text = "Yes?"
        Me.chkNotebookDVD.UseVisualStyleBackColor = True
        '
        'grbNotebookProcessor
        '
        Me.grbNotebookProcessor.Controls.Add(Me.rdoNotebookLgProc)
        Me.grbNotebookProcessor.Controls.Add(Me.rdoNotebookSmProc)
        Me.grbNotebookProcessor.Location = New System.Drawing.Point(316, 269)
        Me.grbNotebookProcessor.Name = "grbNotebookProcessor"
        Me.grbNotebookProcessor.Size = New System.Drawing.Size(197, 43)
        Me.grbNotebookProcessor.TabIndex = 16
        Me.grbNotebookProcessor.TabStop = False
        Me.grbNotebookProcessor.Text = "Processor"
        Me.grbNotebookProcessor.Visible = False
        '
        'rdoNotebookLgProc
        '
        Me.rdoNotebookLgProc.AutoSize = True
        Me.rdoNotebookLgProc.Location = New System.Drawing.Point(114, 18)
        Me.rdoNotebookLgProc.Name = "rdoNotebookLgProc"
        Me.rdoNotebookLgProc.Size = New System.Drawing.Size(34, 19)
        Me.rdoNotebookLgProc.TabIndex = 1
        Me.rdoNotebookLgProc.Text = "i7"
        Me.rdoNotebookLgProc.UseVisualStyleBackColor = True
        '
        'rdoNotebookSmProc
        '
        Me.rdoNotebookSmProc.AutoSize = True
        Me.rdoNotebookSmProc.Checked = True
        Me.rdoNotebookSmProc.Location = New System.Drawing.Point(13, 18)
        Me.rdoNotebookSmProc.Name = "rdoNotebookSmProc"
        Me.rdoNotebookSmProc.Size = New System.Drawing.Size(34, 19)
        Me.rdoNotebookSmProc.TabIndex = 0
        Me.rdoNotebookSmProc.TabStop = True
        Me.rdoNotebookSmProc.Text = "i5"
        Me.rdoNotebookSmProc.UseVisualStyleBackColor = True
        '
        'grbNotebookHD
        '
        Me.grbNotebookHD.Controls.Add(Me.rdoNotebookLgHD)
        Me.grbNotebookHD.Controls.Add(Me.rdoNotebookSmHD)
        Me.grbNotebookHD.Location = New System.Drawing.Point(316, 220)
        Me.grbNotebookHD.Name = "grbNotebookHD"
        Me.grbNotebookHD.Size = New System.Drawing.Size(197, 43)
        Me.grbNotebookHD.TabIndex = 15
        Me.grbNotebookHD.TabStop = False
        Me.grbNotebookHD.Text = "Hard Drive"
        Me.grbNotebookHD.Visible = False
        '
        'rdoNotebookLgHD
        '
        Me.rdoNotebookLgHD.AutoSize = True
        Me.rdoNotebookLgHD.Location = New System.Drawing.Point(114, 18)
        Me.rdoNotebookLgHD.Name = "rdoNotebookLgHD"
        Me.rdoNotebookLgHD.Size = New System.Drawing.Size(58, 19)
        Me.rdoNotebookLgHD.TabIndex = 1
        Me.rdoNotebookLgHD.Text = "720GB"
        Me.rdoNotebookLgHD.UseVisualStyleBackColor = True
        '
        'rdoNotebookSmHD
        '
        Me.rdoNotebookSmHD.AutoSize = True
        Me.rdoNotebookSmHD.Checked = True
        Me.rdoNotebookSmHD.Location = New System.Drawing.Point(11, 19)
        Me.rdoNotebookSmHD.Name = "rdoNotebookSmHD"
        Me.rdoNotebookSmHD.Size = New System.Drawing.Size(58, 19)
        Me.rdoNotebookSmHD.TabIndex = 0
        Me.rdoNotebookSmHD.TabStop = True
        Me.rdoNotebookSmHD.Text = "320GB"
        Me.rdoNotebookSmHD.UseVisualStyleBackColor = True
        '
        'grbNotebookRAM
        '
        Me.grbNotebookRAM.Controls.Add(Me.rdoNotebookLgRAM)
        Me.grbNotebookRAM.Controls.Add(Me.rdoNotebookSmRAM)
        Me.grbNotebookRAM.Location = New System.Drawing.Point(316, 172)
        Me.grbNotebookRAM.Name = "grbNotebookRAM"
        Me.grbNotebookRAM.Size = New System.Drawing.Size(197, 42)
        Me.grbNotebookRAM.TabIndex = 14
        Me.grbNotebookRAM.TabStop = False
        Me.grbNotebookRAM.Text = "RAM"
        Me.grbNotebookRAM.Visible = False
        '
        'rdoNotebookLgRAM
        '
        Me.rdoNotebookLgRAM.AutoSize = True
        Me.rdoNotebookLgRAM.Location = New System.Drawing.Point(114, 15)
        Me.rdoNotebookLgRAM.Name = "rdoNotebookLgRAM"
        Me.rdoNotebookLgRAM.Size = New System.Drawing.Size(46, 19)
        Me.rdoNotebookLgRAM.TabIndex = 2
        Me.rdoNotebookLgRAM.Text = "8GB"
        Me.rdoNotebookLgRAM.UseVisualStyleBackColor = True
        '
        'rdoNotebookSmRAM
        '
        Me.rdoNotebookSmRAM.AutoSize = True
        Me.rdoNotebookSmRAM.Checked = True
        Me.rdoNotebookSmRAM.Location = New System.Drawing.Point(7, 15)
        Me.rdoNotebookSmRAM.Name = "rdoNotebookSmRAM"
        Me.rdoNotebookSmRAM.Size = New System.Drawing.Size(46, 19)
        Me.rdoNotebookSmRAM.TabIndex = 0
        Me.rdoNotebookSmRAM.TabStop = True
        Me.rdoNotebookSmRAM.Text = "4GB"
        Me.rdoNotebookSmRAM.UseVisualStyleBackColor = True
        '
        'grbNotebookVideo
        '
        Me.grbNotebookVideo.Controls.Add(Me.rdoNotebookATI)
        Me.grbNotebookVideo.Controls.Add(Me.rdoNotebookIntel)
        Me.grbNotebookVideo.Location = New System.Drawing.Point(316, 123)
        Me.grbNotebookVideo.Name = "grbNotebookVideo"
        Me.grbNotebookVideo.Size = New System.Drawing.Size(197, 43)
        Me.grbNotebookVideo.TabIndex = 13
        Me.grbNotebookVideo.TabStop = False
        Me.grbNotebookVideo.Text = "Video Card"
        Me.grbNotebookVideo.Visible = False
        '
        'rdoNotebookATI
        '
        Me.rdoNotebookATI.AutoSize = True
        Me.rdoNotebookATI.Location = New System.Drawing.Point(114, 20)
        Me.rdoNotebookATI.Name = "rdoNotebookATI"
        Me.rdoNotebookATI.Size = New System.Drawing.Size(41, 19)
        Me.rdoNotebookATI.TabIndex = 1
        Me.rdoNotebookATI.Text = "ATI"
        Me.rdoNotebookATI.UseVisualStyleBackColor = True
        '
        'rdoNotebookIntel
        '
        Me.rdoNotebookIntel.AutoSize = True
        Me.rdoNotebookIntel.Checked = True
        Me.rdoNotebookIntel.Location = New System.Drawing.Point(13, 18)
        Me.rdoNotebookIntel.Name = "rdoNotebookIntel"
        Me.rdoNotebookIntel.Size = New System.Drawing.Size(48, 19)
        Me.rdoNotebookIntel.TabIndex = 0
        Me.rdoNotebookIntel.TabStop = True
        Me.rdoNotebookIntel.Text = "Intel"
        Me.rdoNotebookIntel.UseVisualStyleBackColor = True
        '
        'grbNotebookCam
        '
        Me.grbNotebookCam.Controls.Add(Me.chkNotebookCam)
        Me.grbNotebookCam.Location = New System.Drawing.Point(433, 367)
        Me.grbNotebookCam.Name = "grbNotebookCam"
        Me.grbNotebookCam.Size = New System.Drawing.Size(80, 43)
        Me.grbNotebookCam.TabIndex = 20
        Me.grbNotebookCam.TabStop = False
        Me.grbNotebookCam.Text = "Camera"
        Me.grbNotebookCam.Visible = False
        '
        'chkNotebookCam
        '
        Me.chkNotebookCam.AutoSize = True
        Me.chkNotebookCam.Location = New System.Drawing.Point(9, 18)
        Me.chkNotebookCam.Name = "chkNotebookCam"
        Me.chkNotebookCam.Size = New System.Drawing.Size(48, 19)
        Me.chkNotebookCam.TabIndex = 0
        Me.chkNotebookCam.Text = "Yes?"
        Me.chkNotebookCam.UseVisualStyleBackColor = True
        '
        'grbTabletHD
        '
        Me.grbTabletHD.Controls.Add(Me.rdoTabletLrgHD)
        Me.grbTabletHD.Controls.Add(Me.rdoTabletMedHD)
        Me.grbTabletHD.Controls.Add(Me.rdoTabletSmHD)
        Me.grbTabletHD.Location = New System.Drawing.Point(571, 220)
        Me.grbTabletHD.Name = "grbTabletHD"
        Me.grbTabletHD.Size = New System.Drawing.Size(197, 43)
        Me.grbTabletHD.TabIndex = 21
        Me.grbTabletHD.TabStop = False
        Me.grbTabletHD.Text = "Hard Drive"
        Me.grbTabletHD.Visible = False
        '
        'rdoTabletLrgHD
        '
        Me.rdoTabletLrgHD.AutoSize = True
        Me.rdoTabletLrgHD.Location = New System.Drawing.Point(139, 18)
        Me.rdoTabletLrgHD.Name = "rdoTabletLrgHD"
        Me.rdoTabletLrgHD.Size = New System.Drawing.Size(52, 19)
        Me.rdoTabletLrgHD.TabIndex = 2
        Me.rdoTabletLrgHD.Text = "32GB"
        Me.rdoTabletLrgHD.UseVisualStyleBackColor = True
        '
        'rdoTabletMedHD
        '
        Me.rdoTabletMedHD.AutoSize = True
        Me.rdoTabletMedHD.Location = New System.Drawing.Point(69, 18)
        Me.rdoTabletMedHD.Name = "rdoTabletMedHD"
        Me.rdoTabletMedHD.Size = New System.Drawing.Size(52, 19)
        Me.rdoTabletMedHD.TabIndex = 1
        Me.rdoTabletMedHD.Text = "16GB"
        Me.rdoTabletMedHD.UseVisualStyleBackColor = True
        '
        'rdoTabletSmHD
        '
        Me.rdoTabletSmHD.AutoSize = True
        Me.rdoTabletSmHD.Checked = True
        Me.rdoTabletSmHD.Location = New System.Drawing.Point(11, 19)
        Me.rdoTabletSmHD.Name = "rdoTabletSmHD"
        Me.rdoTabletSmHD.Size = New System.Drawing.Size(46, 19)
        Me.rdoTabletSmHD.TabIndex = 0
        Me.rdoTabletSmHD.TabStop = True
        Me.rdoTabletSmHD.Text = "8GB"
        Me.rdoTabletSmHD.UseVisualStyleBackColor = True
        '
        'grbTabletSD
        '
        Me.grbTabletSD.Controls.Add(Me.chkTabletSD)
        Me.grbTabletSD.Location = New System.Drawing.Point(571, 318)
        Me.grbTabletSD.Name = "grbTabletSD"
        Me.grbTabletSD.Size = New System.Drawing.Size(80, 43)
        Me.grbTabletSD.TabIndex = 22
        Me.grbTabletSD.TabStop = False
        Me.grbTabletSD.Text = "SD Card"
        Me.grbTabletSD.Visible = False
        '
        'chkTabletSD
        '
        Me.chkTabletSD.AutoSize = True
        Me.chkTabletSD.Location = New System.Drawing.Point(9, 18)
        Me.chkTabletSD.Name = "chkTabletSD"
        Me.chkTabletSD.Size = New System.Drawing.Size(48, 19)
        Me.chkTabletSD.TabIndex = 0
        Me.chkTabletSD.Text = "Yes?"
        Me.chkTabletSD.UseVisualStyleBackColor = True
        '
        'grbTabletProcessor
        '
        Me.grbTabletProcessor.Controls.Add(Me.rdoTabletLgProc)
        Me.grbTabletProcessor.Controls.Add(Me.rdoTabletSmProc)
        Me.grbTabletProcessor.Location = New System.Drawing.Point(571, 269)
        Me.grbTabletProcessor.Name = "grbTabletProcessor"
        Me.grbTabletProcessor.Size = New System.Drawing.Size(197, 43)
        Me.grbTabletProcessor.TabIndex = 23
        Me.grbTabletProcessor.TabStop = False
        Me.grbTabletProcessor.Text = "Processor"
        Me.grbTabletProcessor.Visible = False
        '
        'rdoTabletLgProc
        '
        Me.rdoTabletLgProc.AutoSize = True
        Me.rdoTabletLgProc.Location = New System.Drawing.Point(111, 18)
        Me.rdoTabletLgProc.Name = "rdoTabletLgProc"
        Me.rdoTabletLgProc.Size = New System.Drawing.Size(48, 19)
        Me.rdoTabletLgProc.TabIndex = 1
        Me.rdoTabletLgProc.Text = "Intel"
        Me.rdoTabletLgProc.UseVisualStyleBackColor = True
        '
        'rdoTabletSmProc
        '
        Me.rdoTabletSmProc.AutoSize = True
        Me.rdoTabletSmProc.Checked = True
        Me.rdoTabletSmProc.Location = New System.Drawing.Point(13, 18)
        Me.rdoTabletSmProc.Name = "rdoTabletSmProc"
        Me.rdoTabletSmProc.Size = New System.Drawing.Size(51, 19)
        Me.rdoTabletSmProc.TabIndex = 0
        Me.rdoTabletSmProc.TabStop = True
        Me.rdoTabletSmProc.Text = "ARM"
        Me.rdoTabletSmProc.UseVisualStyleBackColor = True
        '
        'grbTabletCam
        '
        Me.grbTabletCam.Controls.Add(Me.chkTabletCam)
        Me.grbTabletCam.Location = New System.Drawing.Point(688, 318)
        Me.grbTabletCam.Name = "grbTabletCam"
        Me.grbTabletCam.Size = New System.Drawing.Size(80, 43)
        Me.grbTabletCam.TabIndex = 24
        Me.grbTabletCam.TabStop = False
        Me.grbTabletCam.Text = "Camera"
        Me.grbTabletCam.Visible = False
        '
        'chkTabletCam
        '
        Me.chkTabletCam.AutoSize = True
        Me.chkTabletCam.Location = New System.Drawing.Point(9, 18)
        Me.chkTabletCam.Name = "chkTabletCam"
        Me.chkTabletCam.Size = New System.Drawing.Size(48, 19)
        Me.chkTabletCam.TabIndex = 0
        Me.chkTabletCam.Text = "Yes?"
        Me.chkTabletCam.UseVisualStyleBackColor = True
        '
        'grbDesktopVideo
        '
        Me.grbDesktopVideo.Controls.Add(Me.rdoDesktopATI)
        Me.grbDesktopVideo.Controls.Add(Me.rdoDesktopNVIDIA)
        Me.grbDesktopVideo.Location = New System.Drawing.Point(52, 123)
        Me.grbDesktopVideo.Name = "grbDesktopVideo"
        Me.grbDesktopVideo.Size = New System.Drawing.Size(197, 43)
        Me.grbDesktopVideo.TabIndex = 6
        Me.grbDesktopVideo.TabStop = False
        Me.grbDesktopVideo.Text = "Video Card"
        '
        'rdoDesktopATI
        '
        Me.rdoDesktopATI.AutoSize = True
        Me.rdoDesktopATI.Location = New System.Drawing.Point(114, 20)
        Me.rdoDesktopATI.Name = "rdoDesktopATI"
        Me.rdoDesktopATI.Size = New System.Drawing.Size(41, 19)
        Me.rdoDesktopATI.TabIndex = 1
        Me.rdoDesktopATI.Text = "ATI"
        Me.rdoDesktopATI.UseVisualStyleBackColor = True
        '
        'rdoDesktopNVIDIA
        '
        Me.rdoDesktopNVIDIA.AutoSize = True
        Me.rdoDesktopNVIDIA.Checked = True
        Me.rdoDesktopNVIDIA.Location = New System.Drawing.Point(13, 18)
        Me.rdoDesktopNVIDIA.Name = "rdoDesktopNVIDIA"
        Me.rdoDesktopNVIDIA.Size = New System.Drawing.Size(58, 19)
        Me.rdoDesktopNVIDIA.TabIndex = 0
        Me.rdoDesktopNVIDIA.TabStop = True
        Me.rdoDesktopNVIDIA.Text = "nVidia"
        Me.rdoDesktopNVIDIA.UseVisualStyleBackColor = True
        '
        'grbDesktopRAM
        '
        Me.grbDesktopRAM.Controls.Add(Me.rdoDesktopLrgRAM)
        Me.grbDesktopRAM.Controls.Add(Me.rdoDesktopMedRAM)
        Me.grbDesktopRAM.Controls.Add(Me.rdoDesktopSmRAM)
        Me.grbDesktopRAM.Location = New System.Drawing.Point(52, 172)
        Me.grbDesktopRAM.Name = "grbDesktopRAM"
        Me.grbDesktopRAM.Size = New System.Drawing.Size(197, 42)
        Me.grbDesktopRAM.TabIndex = 7
        Me.grbDesktopRAM.TabStop = False
        Me.grbDesktopRAM.Text = "RAM"
        '
        'rdoDesktopLrgRAM
        '
        Me.rdoDesktopLrgRAM.AutoSize = True
        Me.rdoDesktopLrgRAM.Location = New System.Drawing.Point(139, 15)
        Me.rdoDesktopLrgRAM.Name = "rdoDesktopLrgRAM"
        Me.rdoDesktopLrgRAM.Size = New System.Drawing.Size(52, 19)
        Me.rdoDesktopLrgRAM.TabIndex = 2
        Me.rdoDesktopLrgRAM.Text = "16GB"
        Me.rdoDesktopLrgRAM.UseVisualStyleBackColor = True
        '
        'rdoDesktopMedRAM
        '
        Me.rdoDesktopMedRAM.AutoSize = True
        Me.rdoDesktopMedRAM.Location = New System.Drawing.Point(69, 15)
        Me.rdoDesktopMedRAM.Name = "rdoDesktopMedRAM"
        Me.rdoDesktopMedRAM.Size = New System.Drawing.Size(52, 19)
        Me.rdoDesktopMedRAM.TabIndex = 1
        Me.rdoDesktopMedRAM.Text = "12GB"
        Me.rdoDesktopMedRAM.UseVisualStyleBackColor = True
        '
        'rdoDesktopSmRAM
        '
        Me.rdoDesktopSmRAM.AutoSize = True
        Me.rdoDesktopSmRAM.Checked = True
        Me.rdoDesktopSmRAM.Location = New System.Drawing.Point(7, 15)
        Me.rdoDesktopSmRAM.Name = "rdoDesktopSmRAM"
        Me.rdoDesktopSmRAM.Size = New System.Drawing.Size(46, 19)
        Me.rdoDesktopSmRAM.TabIndex = 0
        Me.rdoDesktopSmRAM.TabStop = True
        Me.rdoDesktopSmRAM.Text = "8GB"
        Me.rdoDesktopSmRAM.UseVisualStyleBackColor = True
        '
        'grbDesktopHD
        '
        Me.grbDesktopHD.Controls.Add(Me.rdoDesktopLrgHD)
        Me.grbDesktopHD.Controls.Add(Me.rdoDesktopMedHD)
        Me.grbDesktopHD.Controls.Add(Me.rdoDesktopSmHD)
        Me.grbDesktopHD.Location = New System.Drawing.Point(52, 220)
        Me.grbDesktopHD.Name = "grbDesktopHD"
        Me.grbDesktopHD.Size = New System.Drawing.Size(197, 43)
        Me.grbDesktopHD.TabIndex = 8
        Me.grbDesktopHD.TabStop = False
        Me.grbDesktopHD.Text = "Hard Drive"
        '
        'rdoDesktopLrgHD
        '
        Me.rdoDesktopLrgHD.AutoSize = True
        Me.rdoDesktopLrgHD.Location = New System.Drawing.Point(139, 18)
        Me.rdoDesktopLrgHD.Name = "rdoDesktopLrgHD"
        Me.rdoDesktopLrgHD.Size = New System.Drawing.Size(44, 19)
        Me.rdoDesktopLrgHD.TabIndex = 2
        Me.rdoDesktopLrgHD.Text = "4TB"
        Me.rdoDesktopLrgHD.UseVisualStyleBackColor = True
        '
        'rdoDesktopMedHD
        '
        Me.rdoDesktopMedHD.AutoSize = True
        Me.rdoDesktopMedHD.Location = New System.Drawing.Point(69, 18)
        Me.rdoDesktopMedHD.Name = "rdoDesktopMedHD"
        Me.rdoDesktopMedHD.Size = New System.Drawing.Size(44, 19)
        Me.rdoDesktopMedHD.TabIndex = 1
        Me.rdoDesktopMedHD.Text = "2TB"
        Me.rdoDesktopMedHD.UseVisualStyleBackColor = True
        '
        'rdoDesktopSmHD
        '
        Me.rdoDesktopSmHD.AutoSize = True
        Me.rdoDesktopSmHD.Checked = True
        Me.rdoDesktopSmHD.Location = New System.Drawing.Point(11, 19)
        Me.rdoDesktopSmHD.Name = "rdoDesktopSmHD"
        Me.rdoDesktopSmHD.Size = New System.Drawing.Size(44, 19)
        Me.rdoDesktopSmHD.TabIndex = 0
        Me.rdoDesktopSmHD.TabStop = True
        Me.rdoDesktopSmHD.Text = "1TB"
        Me.rdoDesktopSmHD.UseVisualStyleBackColor = True
        '
        'grbDesktopProcessor
        '
        Me.grbDesktopProcessor.Controls.Add(Me.rdoDesktopLgProc)
        Me.grbDesktopProcessor.Controls.Add(Me.rdoDesktopSmProc)
        Me.grbDesktopProcessor.Location = New System.Drawing.Point(52, 269)
        Me.grbDesktopProcessor.Name = "grbDesktopProcessor"
        Me.grbDesktopProcessor.Size = New System.Drawing.Size(197, 43)
        Me.grbDesktopProcessor.TabIndex = 9
        Me.grbDesktopProcessor.TabStop = False
        Me.grbDesktopProcessor.Text = "Processor"
        '
        'rdoDesktopLgProc
        '
        Me.rdoDesktopLgProc.AutoSize = True
        Me.rdoDesktopLgProc.Location = New System.Drawing.Point(114, 18)
        Me.rdoDesktopLgProc.Name = "rdoDesktopLgProc"
        Me.rdoDesktopLgProc.Size = New System.Drawing.Size(34, 19)
        Me.rdoDesktopLgProc.TabIndex = 1
        Me.rdoDesktopLgProc.Text = "i7"
        Me.rdoDesktopLgProc.UseVisualStyleBackColor = True
        '
        'rdoDesktopSmProc
        '
        Me.rdoDesktopSmProc.AutoSize = True
        Me.rdoDesktopSmProc.Checked = True
        Me.rdoDesktopSmProc.Location = New System.Drawing.Point(13, 18)
        Me.rdoDesktopSmProc.Name = "rdoDesktopSmProc"
        Me.rdoDesktopSmProc.Size = New System.Drawing.Size(34, 19)
        Me.rdoDesktopSmProc.TabIndex = 0
        Me.rdoDesktopSmProc.TabStop = True
        Me.rdoDesktopSmProc.Text = "i5"
        Me.rdoDesktopSmProc.UseVisualStyleBackColor = True
        '
        'grbDesktopDVD
        '
        Me.grbDesktopDVD.Controls.Add(Me.chkDesktopDVD)
        Me.grbDesktopDVD.Location = New System.Drawing.Point(52, 318)
        Me.grbDesktopDVD.Name = "grbDesktopDVD"
        Me.grbDesktopDVD.Size = New System.Drawing.Size(80, 43)
        Me.grbDesktopDVD.TabIndex = 10
        Me.grbDesktopDVD.TabStop = False
        Me.grbDesktopDVD.Text = "DVD-ROM"
        '
        'chkDesktopDVD
        '
        Me.chkDesktopDVD.AutoSize = True
        Me.chkDesktopDVD.Location = New System.Drawing.Point(9, 18)
        Me.chkDesktopDVD.Name = "chkDesktopDVD"
        Me.chkDesktopDVD.Size = New System.Drawing.Size(48, 19)
        Me.chkDesktopDVD.TabIndex = 0
        Me.chkDesktopDVD.Text = "Yes?"
        Me.chkDesktopDVD.UseVisualStyleBackColor = True
        '
        'grbDesktopSound
        '
        Me.grbDesktopSound.Controls.Add(Me.chkDesktopSound)
        Me.grbDesktopSound.Location = New System.Drawing.Point(169, 318)
        Me.grbDesktopSound.Name = "grbDesktopSound"
        Me.grbDesktopSound.Size = New System.Drawing.Size(80, 43)
        Me.grbDesktopSound.TabIndex = 11
        Me.grbDesktopSound.TabStop = False
        Me.grbDesktopSound.Text = "Sound"
        '
        'chkDesktopSound
        '
        Me.chkDesktopSound.AutoSize = True
        Me.chkDesktopSound.Location = New System.Drawing.Point(9, 18)
        Me.chkDesktopSound.Name = "chkDesktopSound"
        Me.chkDesktopSound.Size = New System.Drawing.Size(48, 19)
        Me.chkDesktopSound.TabIndex = 0
        Me.chkDesktopSound.Text = "Yes?"
        Me.chkDesktopSound.UseVisualStyleBackColor = True
        '
        'grbDesktopCool
        '
        Me.grbDesktopCool.Controls.Add(Me.chkDesktopCool)
        Me.grbDesktopCool.Location = New System.Drawing.Point(52, 367)
        Me.grbDesktopCool.Name = "grbDesktopCool"
        Me.grbDesktopCool.Size = New System.Drawing.Size(197, 43)
        Me.grbDesktopCool.TabIndex = 12
        Me.grbDesktopCool.TabStop = False
        Me.grbDesktopCool.Text = "Liquid Cooling"
        '
        'chkDesktopCool
        '
        Me.chkDesktopCool.AutoSize = True
        Me.chkDesktopCool.Location = New System.Drawing.Point(65, 18)
        Me.chkDesktopCool.Name = "chkDesktopCool"
        Me.chkDesktopCool.Size = New System.Drawing.Size(48, 19)
        Me.chkDesktopCool.TabIndex = 0
        Me.chkDesktopCool.Text = "Yes?"
        Me.chkDesktopCool.UseVisualStyleBackColor = True
        '
        'frmCompConfig
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(806, 483)
        Me.Controls.Add(Me.grbDesktopCool)
        Me.Controls.Add(Me.grbDesktopSound)
        Me.Controls.Add(Me.grbTabletCam)
        Me.Controls.Add(Me.grbDesktopDVD)
        Me.Controls.Add(Me.grbTabletProcessor)
        Me.Controls.Add(Me.grbDesktopProcessor)
        Me.Controls.Add(Me.grbTabletSD)
        Me.Controls.Add(Me.grbDesktopHD)
        Me.Controls.Add(Me.grbTabletHD)
        Me.Controls.Add(Me.grbDesktopRAM)
        Me.Controls.Add(Me.grbNotebookCam)
        Me.Controls.Add(Me.grbDesktopVideo)
        Me.Controls.Add(Me.grbNotebookCool)
        Me.Controls.Add(Me.grbNotebookSD)
        Me.Controls.Add(Me.grbNotebookDVD)
        Me.Controls.Add(Me.grbNotebookProcessor)
        Me.Controls.Add(Me.grbNotebookHD)
        Me.Controls.Add(Me.grbNotebookRAM)
        Me.Controls.Add(Me.grbNotebookVideo)
        Me.Controls.Add(Me.btnPlaceOrder)
        Me.Controls.Add(Me.grbFormFactor)
        Me.Controls.Add(Me.txtQuantity)
        Me.Controls.Add(Me.lblQuantity)
        Me.Controls.Add(Me.txtCustName)
        Me.Controls.Add(Me.lblCustName)
        Me.Name = "frmCompConfig"
        Me.Text = "Computer Configurator"
        Me.grbFormFactor.ResumeLayout(False)
        Me.grbFormFactor.PerformLayout()
        Me.grbNotebookCool.ResumeLayout(False)
        Me.grbNotebookCool.PerformLayout()
        Me.grbNotebookSD.ResumeLayout(False)
        Me.grbNotebookSD.PerformLayout()
        Me.grbNotebookDVD.ResumeLayout(False)
        Me.grbNotebookDVD.PerformLayout()
        Me.grbNotebookProcessor.ResumeLayout(False)
        Me.grbNotebookProcessor.PerformLayout()
        Me.grbNotebookHD.ResumeLayout(False)
        Me.grbNotebookHD.PerformLayout()
        Me.grbNotebookRAM.ResumeLayout(False)
        Me.grbNotebookRAM.PerformLayout()
        Me.grbNotebookVideo.ResumeLayout(False)
        Me.grbNotebookVideo.PerformLayout()
        Me.grbNotebookCam.ResumeLayout(False)
        Me.grbNotebookCam.PerformLayout()
        Me.grbTabletHD.ResumeLayout(False)
        Me.grbTabletHD.PerformLayout()
        Me.grbTabletSD.ResumeLayout(False)
        Me.grbTabletSD.PerformLayout()
        Me.grbTabletProcessor.ResumeLayout(False)
        Me.grbTabletProcessor.PerformLayout()
        Me.grbTabletCam.ResumeLayout(False)
        Me.grbTabletCam.PerformLayout()
        Me.grbDesktopVideo.ResumeLayout(False)
        Me.grbDesktopVideo.PerformLayout()
        Me.grbDesktopRAM.ResumeLayout(False)
        Me.grbDesktopRAM.PerformLayout()
        Me.grbDesktopHD.ResumeLayout(False)
        Me.grbDesktopHD.PerformLayout()
        Me.grbDesktopProcessor.ResumeLayout(False)
        Me.grbDesktopProcessor.PerformLayout()
        Me.grbDesktopDVD.ResumeLayout(False)
        Me.grbDesktopDVD.PerformLayout()
        Me.grbDesktopSound.ResumeLayout(False)
        Me.grbDesktopSound.PerformLayout()
        Me.grbDesktopCool.ResumeLayout(False)
        Me.grbDesktopCool.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblCustName As Label
    Friend WithEvents txtCustName As TextBox
    Friend WithEvents lblQuantity As Label
    Friend WithEvents txtQuantity As TextBox
    Friend WithEvents grbFormFactor As GroupBox
    Friend WithEvents rdoTablet As RadioButton
    Friend WithEvents rdoNotebook As RadioButton
    Friend WithEvents rdoDesktop As RadioButton
    Friend WithEvents btnPlaceOrder As Button
    Friend WithEvents grbNotebookCool As GroupBox
    Friend WithEvents chkNotebookCool As CheckBox
    Friend WithEvents grbNotebookSD As GroupBox
    Friend WithEvents chkNotebookSD As CheckBox
    Friend WithEvents grbNotebookDVD As GroupBox
    Friend WithEvents chkNotebookDVD As CheckBox
    Friend WithEvents grbNotebookProcessor As GroupBox
    Friend WithEvents rdoNotebookLgProc As RadioButton
    Friend WithEvents rdoNotebookSmProc As RadioButton
    Friend WithEvents grbNotebookHD As GroupBox
    Friend WithEvents rdoNotebookLgHD As RadioButton
    Friend WithEvents rdoNotebookSmHD As RadioButton
    Friend WithEvents grbNotebookRAM As GroupBox
    Friend WithEvents rdoNotebookLgRAM As RadioButton
    Friend WithEvents rdoNotebookSmRAM As RadioButton
    Friend WithEvents grbNotebookVideo As GroupBox
    Friend WithEvents rdoNotebookATI As RadioButton
    Friend WithEvents rdoNotebookIntel As RadioButton
    Friend WithEvents grbNotebookCam As GroupBox
    Friend WithEvents chkNotebookCam As CheckBox
    Friend WithEvents grbTabletHD As GroupBox
    Friend WithEvents rdoTabletLrgHD As RadioButton
    Friend WithEvents rdoTabletMedHD As RadioButton
    Friend WithEvents rdoTabletSmHD As RadioButton
    Friend WithEvents grbTabletSD As GroupBox
    Friend WithEvents chkTabletSD As CheckBox
    Friend WithEvents grbTabletProcessor As GroupBox
    Friend WithEvents rdoTabletLgProc As RadioButton
    Friend WithEvents rdoTabletSmProc As RadioButton
    Friend WithEvents grbTabletCam As GroupBox
    Friend WithEvents chkTabletCam As CheckBox
    Friend WithEvents grbDesktopVideo As GroupBox
    Friend WithEvents rdoDesktopATI As RadioButton
    Friend WithEvents rdoDesktopNVIDIA As RadioButton
    Friend WithEvents grbDesktopRAM As GroupBox
    Friend WithEvents rdoDesktopLrgRAM As RadioButton
    Friend WithEvents rdoDesktopMedRAM As RadioButton
    Friend WithEvents rdoDesktopSmRAM As RadioButton
    Friend WithEvents grbDesktopHD As GroupBox
    Friend WithEvents rdoDesktopLrgHD As RadioButton
    Friend WithEvents rdoDesktopMedHD As RadioButton
    Friend WithEvents rdoDesktopSmHD As RadioButton
    Friend WithEvents grbDesktopProcessor As GroupBox
    Friend WithEvents rdoDesktopLgProc As RadioButton
    Friend WithEvents rdoDesktopSmProc As RadioButton
    Friend WithEvents grbDesktopDVD As GroupBox
    Friend WithEvents chkDesktopDVD As CheckBox
    Friend WithEvents grbDesktopSound As GroupBox
    Friend WithEvents chkDesktopSound As CheckBox
    Friend WithEvents grbDesktopCool As GroupBox
    Friend WithEvents chkDesktopCool As CheckBox
End Class
