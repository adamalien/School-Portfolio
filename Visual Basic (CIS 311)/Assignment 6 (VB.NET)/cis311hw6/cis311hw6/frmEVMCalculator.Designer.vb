<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEVMCalculator
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
        Me.lblParameters = New System.Windows.Forms.Label()
        Me.lblValues = New System.Windows.Forms.Label()
        Me.lblPresentValue = New System.Windows.Forms.Label()
        Me.lblActualCost = New System.Windows.Forms.Label()
        Me.lblEarnedValue = New System.Windows.Forms.Label()
        Me.lblCompBalance = New System.Windows.Forms.Label()
        Me.lblOriginalTime = New System.Windows.Forms.Label()
        Me.txtPresentValue = New System.Windows.Forms.TextBox()
        Me.txtActualCost = New System.Windows.Forms.TextBox()
        Me.txtEarnedValue = New System.Windows.Forms.TextBox()
        Me.txtBalanceAtCompletion = New System.Windows.Forms.TextBox()
        Me.txtOriginalTime = New System.Windows.Forms.TextBox()
        Me.grbTimeframe = New System.Windows.Forms.GroupBox()
        Me.rdoYears = New System.Windows.Forms.RadioButton()
        Me.rdoMonths = New System.Windows.Forms.RadioButton()
        Me.btnCalculateValues = New System.Windows.Forms.Button()
        Me.btnClearForm = New System.Windows.Forms.Button()
        Me.lblCostVariance = New System.Windows.Forms.Label()
        Me.lblScheduleVariance = New System.Windows.Forms.Label()
        Me.lblCostPerformanceIndex = New System.Windows.Forms.Label()
        Me.lblSchedulePerformanceIndex = New System.Windows.Forms.Label()
        Me.lblEstimateAtCompletion = New System.Windows.Forms.Label()
        Me.lblTimeAtCompletion = New System.Windows.Forms.Label()
        Me.txtCostVariance = New System.Windows.Forms.TextBox()
        Me.txtScheduleVariance = New System.Windows.Forms.TextBox()
        Me.txtCostPerformanceIndex = New System.Windows.Forms.TextBox()
        Me.txtSchedulePerformanceIndex = New System.Windows.Forms.TextBox()
        Me.txtEstimateAtCompletion = New System.Windows.Forms.TextBox()
        Me.txtTimeAtCompletion = New System.Windows.Forms.TextBox()
        Me.btnCostVariance = New System.Windows.Forms.Button()
        Me.btnScheduleVariance = New System.Windows.Forms.Button()
        Me.btnCostPerformanceIndex = New System.Windows.Forms.Button()
        Me.btnSchedulePerformanceIndex = New System.Windows.Forms.Button()
        Me.btnEstimateAtCompletion = New System.Windows.Forms.Button()
        Me.btnTimeAtCompletion = New System.Windows.Forms.Button()
        Me.grbTimeframe.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblParameters
        '
        Me.lblParameters.AutoSize = True
        Me.lblParameters.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.lblParameters.Location = New System.Drawing.Point(12, 25)
        Me.lblParameters.Name = "lblParameters"
        Me.lblParameters.Size = New System.Drawing.Size(311, 25)
        Me.lblParameters.TabIndex = 0
        Me.lblParameters.Text = "Enter Current Project Parameters:"
        '
        'lblValues
        '
        Me.lblValues.AutoSize = True
        Me.lblValues.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.lblValues.Location = New System.Drawing.Point(12, 221)
        Me.lblValues.Name = "lblValues"
        Me.lblValues.Size = New System.Drawing.Size(142, 25)
        Me.lblValues.TabIndex = 1
        Me.lblValues.Text = "Project Values:"
        '
        'lblPresentValue
        '
        Me.lblPresentValue.AutoSize = True
        Me.lblPresentValue.Location = New System.Drawing.Point(12, 70)
        Me.lblPresentValue.Name = "lblPresentValue"
        Me.lblPresentValue.Size = New System.Drawing.Size(105, 15)
        Me.lblPresentValue.TabIndex = 2
        Me.lblPresentValue.Text = "Present Value (PV):"
        '
        'lblActualCost
        '
        Me.lblActualCost.AutoSize = True
        Me.lblActualCost.Location = New System.Drawing.Point(12, 111)
        Me.lblActualCost.Name = "lblActualCost"
        Me.lblActualCost.Size = New System.Drawing.Size(98, 15)
        Me.lblActualCost.TabIndex = 3
        Me.lblActualCost.Text = "Actual Cost (AC):"
        '
        'lblEarnedValue
        '
        Me.lblEarnedValue.AutoSize = True
        Me.lblEarnedValue.Location = New System.Drawing.Point(12, 152)
        Me.lblEarnedValue.Name = "lblEarnedValue"
        Me.lblEarnedValue.Size = New System.Drawing.Size(101, 15)
        Me.lblEarnedValue.TabIndex = 4
        Me.lblEarnedValue.Text = "Earned Value (EV):"
        '
        'lblCompBalance
        '
        Me.lblCompBalance.AutoSize = True
        Me.lblCompBalance.Location = New System.Drawing.Point(310, 70)
        Me.lblCompBalance.Name = "lblCompBalance"
        Me.lblCompBalance.Size = New System.Drawing.Size(164, 15)
        Me.lblCompBalance.TabIndex = 5
        Me.lblCompBalance.Text = "Balance at Completion (BAC):"
        '
        'lblOriginalTime
        '
        Me.lblOriginalTime.AutoSize = True
        Me.lblOriginalTime.Location = New System.Drawing.Point(310, 111)
        Me.lblOriginalTime.Name = "lblOriginalTime"
        Me.lblOriginalTime.Size = New System.Drawing.Size(106, 15)
        Me.lblOriginalTime.TabIndex = 6
        Me.lblOriginalTime.Text = "Original Time (OT):"
        '
        'txtPresentValue
        '
        Me.txtPresentValue.Location = New System.Drawing.Point(123, 67)
        Me.txtPresentValue.Name = "txtPresentValue"
        Me.txtPresentValue.Size = New System.Drawing.Size(137, 23)
        Me.txtPresentValue.TabIndex = 7
        '
        'txtActualCost
        '
        Me.txtActualCost.Location = New System.Drawing.Point(123, 108)
        Me.txtActualCost.Name = "txtActualCost"
        Me.txtActualCost.Size = New System.Drawing.Size(137, 23)
        Me.txtActualCost.TabIndex = 8
        '
        'txtEarnedValue
        '
        Me.txtEarnedValue.Location = New System.Drawing.Point(123, 149)
        Me.txtEarnedValue.Name = "txtEarnedValue"
        Me.txtEarnedValue.Size = New System.Drawing.Size(137, 23)
        Me.txtEarnedValue.TabIndex = 9
        '
        'txtBalanceAtCompletion
        '
        Me.txtBalanceAtCompletion.Location = New System.Drawing.Point(486, 67)
        Me.txtBalanceAtCompletion.Name = "txtBalanceAtCompletion"
        Me.txtBalanceAtCompletion.Size = New System.Drawing.Size(137, 23)
        Me.txtBalanceAtCompletion.TabIndex = 10
        '
        'txtOriginalTime
        '
        Me.txtOriginalTime.Location = New System.Drawing.Point(486, 108)
        Me.txtOriginalTime.Name = "txtOriginalTime"
        Me.txtOriginalTime.Size = New System.Drawing.Size(137, 23)
        Me.txtOriginalTime.TabIndex = 11
        '
        'grbTimeframe
        '
        Me.grbTimeframe.Controls.Add(Me.rdoYears)
        Me.grbTimeframe.Controls.Add(Me.rdoMonths)
        Me.grbTimeframe.Location = New System.Drawing.Point(310, 149)
        Me.grbTimeframe.Name = "grbTimeframe"
        Me.grbTimeframe.Size = New System.Drawing.Size(313, 53)
        Me.grbTimeframe.TabIndex = 12
        Me.grbTimeframe.TabStop = False
        Me.grbTimeframe.Text = "Timeframe"
        '
        'rdoYears
        '
        Me.rdoYears.AutoSize = True
        Me.rdoYears.Location = New System.Drawing.Point(227, 22)
        Me.rdoYears.Name = "rdoYears"
        Me.rdoYears.Size = New System.Drawing.Size(52, 19)
        Me.rdoYears.TabIndex = 1
        Me.rdoYears.TabStop = True
        Me.rdoYears.Text = "Years"
        Me.rdoYears.UseVisualStyleBackColor = True
        '
        'rdoMonths
        '
        Me.rdoMonths.AutoSize = True
        Me.rdoMonths.Location = New System.Drawing.Point(40, 22)
        Me.rdoMonths.Name = "rdoMonths"
        Me.rdoMonths.Size = New System.Drawing.Size(66, 19)
        Me.rdoMonths.TabIndex = 0
        Me.rdoMonths.TabStop = True
        Me.rdoMonths.Text = "Months"
        Me.rdoMonths.UseVisualStyleBackColor = True
        '
        'btnCalculateValues
        '
        Me.btnCalculateValues.Location = New System.Drawing.Point(660, 67)
        Me.btnCalculateValues.Name = "btnCalculateValues"
        Me.btnCalculateValues.Size = New System.Drawing.Size(159, 35)
        Me.btnCalculateValues.TabIndex = 13
        Me.btnCalculateValues.Text = "Calculate Values"
        Me.btnCalculateValues.UseVisualStyleBackColor = True
        '
        'btnClearForm
        '
        Me.btnClearForm.Location = New System.Drawing.Point(660, 137)
        Me.btnClearForm.Name = "btnClearForm"
        Me.btnClearForm.Size = New System.Drawing.Size(159, 35)
        Me.btnClearForm.TabIndex = 14
        Me.btnClearForm.Text = "Clear Form"
        Me.btnClearForm.UseVisualStyleBackColor = True
        '
        'lblCostVariance
        '
        Me.lblCostVariance.AutoSize = True
        Me.lblCostVariance.Location = New System.Drawing.Point(12, 268)
        Me.lblCostVariance.Name = "lblCostVariance"
        Me.lblCostVariance.Size = New System.Drawing.Size(107, 15)
        Me.lblCostVariance.TabIndex = 15
        Me.lblCostVariance.Text = "Cost Variance (CV):"
        '
        'lblScheduleVariance
        '
        Me.lblScheduleVariance.AutoSize = True
        Me.lblScheduleVariance.Location = New System.Drawing.Point(12, 310)
        Me.lblScheduleVariance.Name = "lblScheduleVariance"
        Me.lblScheduleVariance.Size = New System.Drawing.Size(129, 15)
        Me.lblScheduleVariance.TabIndex = 16
        Me.lblScheduleVariance.Text = "Schedule Variance (SV):"
        '
        'lblCostPerformanceIndex
        '
        Me.lblCostPerformanceIndex.AutoSize = True
        Me.lblCostPerformanceIndex.Location = New System.Drawing.Point(12, 355)
        Me.lblCostPerformanceIndex.Name = "lblCostPerformanceIndex"
        Me.lblCostPerformanceIndex.Size = New System.Drawing.Size(166, 15)
        Me.lblCostPerformanceIndex.TabIndex = 17
        Me.lblCostPerformanceIndex.Text = "Cost Performance Index (CPI):"
        '
        'lblSchedulePerformanceIndex
        '
        Me.lblSchedulePerformanceIndex.AutoSize = True
        Me.lblSchedulePerformanceIndex.Location = New System.Drawing.Point(12, 402)
        Me.lblSchedulePerformanceIndex.Name = "lblSchedulePerformanceIndex"
        Me.lblSchedulePerformanceIndex.Size = New System.Drawing.Size(188, 15)
        Me.lblSchedulePerformanceIndex.TabIndex = 18
        Me.lblSchedulePerformanceIndex.Text = "Schedule Performance Index (SPI):"
        '
        'lblEstimateAtCompletion
        '
        Me.lblEstimateAtCompletion.AutoSize = True
        Me.lblEstimateAtCompletion.Location = New System.Drawing.Point(422, 310)
        Me.lblEstimateAtCompletion.Name = "lblEstimateAtCompletion"
        Me.lblEstimateAtCompletion.Size = New System.Drawing.Size(167, 15)
        Me.lblEstimateAtCompletion.TabIndex = 19
        Me.lblEstimateAtCompletion.Text = "Estimate at Completion (EAC):"
        '
        'lblTimeAtCompletion
        '
        Me.lblTimeAtCompletion.AutoSize = True
        Me.lblTimeAtCompletion.Location = New System.Drawing.Point(422, 355)
        Me.lblTimeAtCompletion.Name = "lblTimeAtCompletion"
        Me.lblTimeAtCompletion.Size = New System.Drawing.Size(147, 15)
        Me.lblTimeAtCompletion.TabIndex = 20
        Me.lblTimeAtCompletion.Text = "Time at Completion (TAC):"
        '
        'txtCostVariance
        '
        Me.txtCostVariance.Location = New System.Drawing.Point(215, 265)
        Me.txtCostVariance.Name = "txtCostVariance"
        Me.txtCostVariance.ReadOnly = True
        Me.txtCostVariance.Size = New System.Drawing.Size(135, 23)
        Me.txtCostVariance.TabIndex = 21
        Me.txtCostVariance.TabStop = False
        '
        'txtScheduleVariance
        '
        Me.txtScheduleVariance.Location = New System.Drawing.Point(215, 307)
        Me.txtScheduleVariance.Name = "txtScheduleVariance"
        Me.txtScheduleVariance.ReadOnly = True
        Me.txtScheduleVariance.Size = New System.Drawing.Size(135, 23)
        Me.txtScheduleVariance.TabIndex = 22
        Me.txtScheduleVariance.TabStop = False
        '
        'txtCostPerformanceIndex
        '
        Me.txtCostPerformanceIndex.Location = New System.Drawing.Point(215, 352)
        Me.txtCostPerformanceIndex.Name = "txtCostPerformanceIndex"
        Me.txtCostPerformanceIndex.ReadOnly = True
        Me.txtCostPerformanceIndex.Size = New System.Drawing.Size(135, 23)
        Me.txtCostPerformanceIndex.TabIndex = 23
        Me.txtCostPerformanceIndex.TabStop = False
        '
        'txtSchedulePerformanceIndex
        '
        Me.txtSchedulePerformanceIndex.Location = New System.Drawing.Point(215, 399)
        Me.txtSchedulePerformanceIndex.Name = "txtSchedulePerformanceIndex"
        Me.txtSchedulePerformanceIndex.ReadOnly = True
        Me.txtSchedulePerformanceIndex.Size = New System.Drawing.Size(135, 23)
        Me.txtSchedulePerformanceIndex.TabIndex = 24
        Me.txtSchedulePerformanceIndex.TabStop = False
        '
        'txtEstimateAtCompletion
        '
        Me.txtEstimateAtCompletion.Location = New System.Drawing.Point(605, 307)
        Me.txtEstimateAtCompletion.Name = "txtEstimateAtCompletion"
        Me.txtEstimateAtCompletion.ReadOnly = True
        Me.txtEstimateAtCompletion.Size = New System.Drawing.Size(135, 23)
        Me.txtEstimateAtCompletion.TabIndex = 25
        Me.txtEstimateAtCompletion.TabStop = False
        '
        'txtTimeAtCompletion
        '
        Me.txtTimeAtCompletion.Location = New System.Drawing.Point(605, 352)
        Me.txtTimeAtCompletion.Name = "txtTimeAtCompletion"
        Me.txtTimeAtCompletion.ReadOnly = True
        Me.txtTimeAtCompletion.Size = New System.Drawing.Size(135, 23)
        Me.txtTimeAtCompletion.TabIndex = 26
        Me.txtTimeAtCompletion.TabStop = False
        '
        'btnCostVariance
        '
        Me.btnCostVariance.BackColor = System.Drawing.Color.DarkGray
        Me.btnCostVariance.Location = New System.Drawing.Point(369, 265)
        Me.btnCostVariance.Name = "btnCostVariance"
        Me.btnCostVariance.Size = New System.Drawing.Size(24, 23)
        Me.btnCostVariance.TabIndex = 27
        Me.btnCostVariance.TabStop = False
        Me.btnCostVariance.UseVisualStyleBackColor = False
        '
        'btnScheduleVariance
        '
        Me.btnScheduleVariance.BackColor = System.Drawing.Color.DarkGray
        Me.btnScheduleVariance.Location = New System.Drawing.Point(369, 307)
        Me.btnScheduleVariance.Name = "btnScheduleVariance"
        Me.btnScheduleVariance.Size = New System.Drawing.Size(24, 23)
        Me.btnScheduleVariance.TabIndex = 28
        Me.btnScheduleVariance.TabStop = False
        Me.btnScheduleVariance.UseVisualStyleBackColor = False
        '
        'btnCostPerformanceIndex
        '
        Me.btnCostPerformanceIndex.BackColor = System.Drawing.Color.DarkGray
        Me.btnCostPerformanceIndex.Location = New System.Drawing.Point(369, 352)
        Me.btnCostPerformanceIndex.Name = "btnCostPerformanceIndex"
        Me.btnCostPerformanceIndex.Size = New System.Drawing.Size(24, 23)
        Me.btnCostPerformanceIndex.TabIndex = 29
        Me.btnCostPerformanceIndex.TabStop = False
        Me.btnCostPerformanceIndex.UseVisualStyleBackColor = False
        '
        'btnSchedulePerformanceIndex
        '
        Me.btnSchedulePerformanceIndex.BackColor = System.Drawing.Color.DarkGray
        Me.btnSchedulePerformanceIndex.Location = New System.Drawing.Point(369, 399)
        Me.btnSchedulePerformanceIndex.Name = "btnSchedulePerformanceIndex"
        Me.btnSchedulePerformanceIndex.Size = New System.Drawing.Size(24, 23)
        Me.btnSchedulePerformanceIndex.TabIndex = 30
        Me.btnSchedulePerformanceIndex.TabStop = False
        Me.btnSchedulePerformanceIndex.UseVisualStyleBackColor = False
        '
        'btnEstimateAtCompletion
        '
        Me.btnEstimateAtCompletion.BackColor = System.Drawing.Color.DarkGray
        Me.btnEstimateAtCompletion.Location = New System.Drawing.Point(756, 307)
        Me.btnEstimateAtCompletion.Name = "btnEstimateAtCompletion"
        Me.btnEstimateAtCompletion.Size = New System.Drawing.Size(24, 22)
        Me.btnEstimateAtCompletion.TabIndex = 31
        Me.btnEstimateAtCompletion.TabStop = False
        Me.btnEstimateAtCompletion.UseVisualStyleBackColor = False
        '
        'btnTimeAtCompletion
        '
        Me.btnTimeAtCompletion.BackColor = System.Drawing.Color.DarkGray
        Me.btnTimeAtCompletion.Location = New System.Drawing.Point(756, 352)
        Me.btnTimeAtCompletion.Name = "btnTimeAtCompletion"
        Me.btnTimeAtCompletion.Size = New System.Drawing.Size(24, 23)
        Me.btnTimeAtCompletion.TabIndex = 32
        Me.btnTimeAtCompletion.TabStop = False
        Me.btnTimeAtCompletion.UseVisualStyleBackColor = False
        '
        'frmEVMCalculator
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(831, 450)
        Me.Controls.Add(Me.btnTimeAtCompletion)
        Me.Controls.Add(Me.btnEstimateAtCompletion)
        Me.Controls.Add(Me.btnSchedulePerformanceIndex)
        Me.Controls.Add(Me.btnCostPerformanceIndex)
        Me.Controls.Add(Me.btnScheduleVariance)
        Me.Controls.Add(Me.btnCostVariance)
        Me.Controls.Add(Me.txtTimeAtCompletion)
        Me.Controls.Add(Me.txtEstimateAtCompletion)
        Me.Controls.Add(Me.txtSchedulePerformanceIndex)
        Me.Controls.Add(Me.txtCostPerformanceIndex)
        Me.Controls.Add(Me.txtScheduleVariance)
        Me.Controls.Add(Me.txtCostVariance)
        Me.Controls.Add(Me.lblTimeAtCompletion)
        Me.Controls.Add(Me.lblEstimateAtCompletion)
        Me.Controls.Add(Me.lblSchedulePerformanceIndex)
        Me.Controls.Add(Me.lblCostPerformanceIndex)
        Me.Controls.Add(Me.lblScheduleVariance)
        Me.Controls.Add(Me.lblCostVariance)
        Me.Controls.Add(Me.btnClearForm)
        Me.Controls.Add(Me.btnCalculateValues)
        Me.Controls.Add(Me.grbTimeframe)
        Me.Controls.Add(Me.txtOriginalTime)
        Me.Controls.Add(Me.txtBalanceAtCompletion)
        Me.Controls.Add(Me.txtEarnedValue)
        Me.Controls.Add(Me.txtActualCost)
        Me.Controls.Add(Me.txtPresentValue)
        Me.Controls.Add(Me.lblOriginalTime)
        Me.Controls.Add(Me.lblCompBalance)
        Me.Controls.Add(Me.lblEarnedValue)
        Me.Controls.Add(Me.lblActualCost)
        Me.Controls.Add(Me.lblPresentValue)
        Me.Controls.Add(Me.lblValues)
        Me.Controls.Add(Me.lblParameters)
        Me.Name = "frmEVMCalculator"
        Me.Text = "EVM -"
        Me.grbTimeframe.ResumeLayout(False)
        Me.grbTimeframe.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblParameters As Label
    Friend WithEvents lblValues As Label
    Friend WithEvents lblPresentValue As Label
    Friend WithEvents lblActualCost As Label
    Friend WithEvents lblEarnedValue As Label
    Friend WithEvents lblCompBalance As Label
    Friend WithEvents lblOriginalTime As Label
    Friend WithEvents txtPresentValue As TextBox
    Friend WithEvents txtActualCost As TextBox
    Friend WithEvents txtEarnedValue As TextBox
    Friend WithEvents txtBalanceAtCompletion As TextBox
    Friend WithEvents txtOriginalTime As TextBox
    Friend WithEvents grbTimeframe As GroupBox
    Friend WithEvents rdoYears As RadioButton
    Friend WithEvents rdoMonths As RadioButton
    Friend WithEvents btnCalculateValues As Button
    Friend WithEvents btnClearForm As Button
    Friend WithEvents lblCostVariance As Label
    Friend WithEvents lblScheduleVariance As Label
    Friend WithEvents lblCostPerformanceIndex As Label
    Friend WithEvents lblSchedulePerformanceIndex As Label
    Friend WithEvents lblEstimateAtCompletion As Label
    Friend WithEvents lblTimeAtCompletion As Label
    Friend WithEvents txtCostVariance As TextBox
    Friend WithEvents txtScheduleVariance As TextBox
    Friend WithEvents txtCostPerformanceIndex As TextBox
    Friend WithEvents txtSchedulePerformanceIndex As TextBox
    Friend WithEvents txtEstimateAtCompletion As TextBox
    Friend WithEvents txtTimeAtCompletion As TextBox
    Friend WithEvents btnCostVariance As Button
    Friend WithEvents btnScheduleVariance As Button
    Friend WithEvents btnCostPerformanceIndex As Button
    Friend WithEvents btnSchedulePerformanceIndex As Button
    Friend WithEvents btnEstimateAtCompletion As Button
    Friend WithEvents btnTimeAtCompletion As Button
End Class
