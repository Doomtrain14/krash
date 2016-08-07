<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.gb_inputfiles = New System.Windows.Forms.GroupBox()
        Me.lb_inputs = New System.Windows.Forms.ListBox()
        Me.cmd_removeinput = New System.Windows.Forms.Button()
        Me.cmd_addinput = New System.Windows.Forms.Button()
        Me.bw_extracttests = New System.ComponentModel.BackgroundWorker()
        Me.gb_testblocks = New System.Windows.Forms.GroupBox()
        Me.cmd_all = New System.Windows.Forms.Button()
        Me.cmd_clear = New System.Windows.Forms.Button()
        Me.lbl_selected_test = New System.Windows.Forms.Label()
        Me.lb_testblocks = New System.Windows.Forms.ListBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.sb_status = New System.Windows.Forms.ToolStripStatusLabel()
        Me.cmd_krash = New System.Windows.Forms.Button()
        Me.bw_krash = New System.ComponentModel.BackgroundWorker()
        Me.gb_jmp = New System.Windows.Forms.GroupBox()
        Me.txt_wafer_def = New System.Windows.Forms.TextBox()
        Me.cmb_wafers = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmb_grid = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmd_add_groupby = New System.Windows.Forms.Button()
        Me.cmb_presets = New System.Windows.Forms.ComboBox()
        Me.lbl_preset = New System.Windows.Forms.Label()
        Me.lb_groupby = New System.Windows.Forms.ListBox()
        Me.cmb_yvalue = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmb_legend = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmb_xfactor = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmb_groupby = New System.Windows.Forms.ComboBox()
        Me.lbl_group = New System.Windows.Forms.Label()
        Me.cmb_jmp_script = New System.Windows.Forms.ComboBox()
        Me.lbl_script = New System.Windows.Forms.Label()
        Me.chk_jmp = New System.Windows.Forms.CheckBox()
        Me.bw_headergetter = New System.ComponentModel.BackgroundWorker()
        Me.gb_inputfiles.SuspendLayout()
        Me.gb_testblocks.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.gb_jmp.SuspendLayout()
        Me.SuspendLayout()
        '
        'gb_inputfiles
        '
        Me.gb_inputfiles.Controls.Add(Me.lb_inputs)
        Me.gb_inputfiles.Controls.Add(Me.cmd_removeinput)
        Me.gb_inputfiles.Controls.Add(Me.cmd_addinput)
        Me.gb_inputfiles.Location = New System.Drawing.Point(7, 4)
        Me.gb_inputfiles.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.gb_inputfiles.Name = "gb_inputfiles"
        Me.gb_inputfiles.Padding = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.gb_inputfiles.Size = New System.Drawing.Size(221, 215)
        Me.gb_inputfiles.TabIndex = 0
        Me.gb_inputfiles.TabStop = False
        Me.gb_inputfiles.Text = "Input files"
        '
        'lb_inputs
        '
        Me.lb_inputs.FormattingEnabled = True
        Me.lb_inputs.Location = New System.Drawing.Point(6, 20)
        Me.lb_inputs.Name = "lb_inputs"
        Me.lb_inputs.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lb_inputs.Size = New System.Drawing.Size(209, 160)
        Me.lb_inputs.TabIndex = 3
        '
        'cmd_removeinput
        '
        Me.cmd_removeinput.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmd_removeinput.Location = New System.Drawing.Point(161, 185)
        Me.cmd_removeinput.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.cmd_removeinput.Name = "cmd_removeinput"
        Me.cmd_removeinput.Size = New System.Drawing.Size(54, 22)
        Me.cmd_removeinput.TabIndex = 2
        Me.cmd_removeinput.Text = "&Remove"
        Me.cmd_removeinput.UseVisualStyleBackColor = True
        '
        'cmd_addinput
        '
        Me.cmd_addinput.Location = New System.Drawing.Point(6, 185)
        Me.cmd_addinput.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.cmd_addinput.Name = "cmd_addinput"
        Me.cmd_addinput.Size = New System.Drawing.Size(54, 22)
        Me.cmd_addinput.TabIndex = 1
        Me.cmd_addinput.Text = "&Add"
        Me.cmd_addinput.UseVisualStyleBackColor = True
        '
        'bw_extracttests
        '
        Me.bw_extracttests.WorkerReportsProgress = True
        Me.bw_extracttests.WorkerSupportsCancellation = True
        '
        'gb_testblocks
        '
        Me.gb_testblocks.Controls.Add(Me.cmd_all)
        Me.gb_testblocks.Controls.Add(Me.cmd_clear)
        Me.gb_testblocks.Controls.Add(Me.lbl_selected_test)
        Me.gb_testblocks.Controls.Add(Me.lb_testblocks)
        Me.gb_testblocks.Location = New System.Drawing.Point(234, 4)
        Me.gb_testblocks.Margin = New System.Windows.Forms.Padding(4)
        Me.gb_testblocks.Name = "gb_testblocks"
        Me.gb_testblocks.Padding = New System.Windows.Forms.Padding(4)
        Me.gb_testblocks.Size = New System.Drawing.Size(236, 215)
        Me.gb_testblocks.TabIndex = 1
        Me.gb_testblocks.TabStop = False
        Me.gb_testblocks.Text = "Testblocks"
        '
        'cmd_all
        '
        Me.cmd_all.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmd_all.Location = New System.Drawing.Point(117, 185)
        Me.cmd_all.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.cmd_all.Name = "cmd_all"
        Me.cmd_all.Size = New System.Drawing.Size(54, 22)
        Me.cmd_all.TabIndex = 4
        Me.cmd_all.Text = "&All"
        Me.cmd_all.UseVisualStyleBackColor = True
        '
        'cmd_clear
        '
        Me.cmd_clear.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmd_clear.Location = New System.Drawing.Point(175, 185)
        Me.cmd_clear.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.cmd_clear.Name = "cmd_clear"
        Me.cmd_clear.Size = New System.Drawing.Size(54, 22)
        Me.cmd_clear.TabIndex = 3
        Me.cmd_clear.Text = "&Clear"
        Me.cmd_clear.UseVisualStyleBackColor = True
        '
        'lbl_selected_test
        '
        Me.lbl_selected_test.AutoSize = True
        Me.lbl_selected_test.Location = New System.Drawing.Point(4, 190)
        Me.lbl_selected_test.Name = "lbl_selected_test"
        Me.lbl_selected_test.Size = New System.Drawing.Size(56, 13)
        Me.lbl_selected_test.TabIndex = 2
        Me.lbl_selected_test.Text = "0 selected"
        '
        'lb_testblocks
        '
        Me.lb_testblocks.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lb_testblocks.FormattingEnabled = True
        Me.lb_testblocks.Location = New System.Drawing.Point(7, 20)
        Me.lb_testblocks.Margin = New System.Windows.Forms.Padding(4)
        Me.lb_testblocks.Name = "lb_testblocks"
        Me.lb_testblocks.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
        Me.lb_testblocks.Size = New System.Drawing.Size(222, 160)
        Me.lb_testblocks.TabIndex = 1
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sb_status})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 489)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 17, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(483, 22)
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'sb_status
        '
        Me.sb_status.AutoSize = False
        Me.sb_status.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.sb_status.Name = "sb_status"
        Me.sb_status.Size = New System.Drawing.Size(230, 17)
        Me.sb_status.Text = "Status: Idle/Ready"
        Me.sb_status.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmd_krash
        '
        Me.cmd_krash.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmd_krash.Location = New System.Drawing.Point(270, 454)
        Me.cmd_krash.Name = "cmd_krash"
        Me.cmd_krash.Size = New System.Drawing.Size(189, 28)
        Me.cmd_krash.TabIndex = 3
        Me.cmd_krash.Text = "Krash"
        Me.cmd_krash.UseVisualStyleBackColor = True
        '
        'bw_krash
        '
        Me.bw_krash.WorkerReportsProgress = True
        Me.bw_krash.WorkerSupportsCancellation = True
        '
        'gb_jmp
        '
        Me.gb_jmp.Controls.Add(Me.txt_wafer_def)
        Me.gb_jmp.Controls.Add(Me.cmb_wafers)
        Me.gb_jmp.Controls.Add(Me.Label5)
        Me.gb_jmp.Controls.Add(Me.cmb_grid)
        Me.gb_jmp.Controls.Add(Me.Label4)
        Me.gb_jmp.Controls.Add(Me.cmd_add_groupby)
        Me.gb_jmp.Controls.Add(Me.cmb_presets)
        Me.gb_jmp.Controls.Add(Me.lbl_preset)
        Me.gb_jmp.Controls.Add(Me.lb_groupby)
        Me.gb_jmp.Controls.Add(Me.cmb_yvalue)
        Me.gb_jmp.Controls.Add(Me.Label3)
        Me.gb_jmp.Controls.Add(Me.cmb_legend)
        Me.gb_jmp.Controls.Add(Me.Label2)
        Me.gb_jmp.Controls.Add(Me.cmb_xfactor)
        Me.gb_jmp.Controls.Add(Me.Label1)
        Me.gb_jmp.Controls.Add(Me.cmb_groupby)
        Me.gb_jmp.Controls.Add(Me.lbl_group)
        Me.gb_jmp.Controls.Add(Me.cmb_jmp_script)
        Me.gb_jmp.Controls.Add(Me.lbl_script)
        Me.gb_jmp.Location = New System.Drawing.Point(7, 226)
        Me.gb_jmp.Name = "gb_jmp"
        Me.gb_jmp.Size = New System.Drawing.Size(463, 222)
        Me.gb_jmp.TabIndex = 4
        Me.gb_jmp.TabStop = False
        Me.gb_jmp.Text = "JMP"
        '
        'txt_wafer_def
        '
        Me.txt_wafer_def.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_wafer_def.Location = New System.Drawing.Point(142, 48)
        Me.txt_wafer_def.Name = "txt_wafer_def"
        Me.txt_wafer_def.Size = New System.Drawing.Size(73, 21)
        Me.txt_wafer_def.TabIndex = 20
        '
        'cmb_wafers
        '
        Me.cmb_wafers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_wafers.FormattingEnabled = True
        Me.cmb_wafers.Location = New System.Drawing.Point(62, 48)
        Me.cmb_wafers.Name = "cmb_wafers"
        Me.cmb_wafers.Size = New System.Drawing.Size(71, 21)
        Me.cmb_wafers.TabIndex = 19
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(7, 53)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 13)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "W. Def:"
        '
        'cmb_grid
        '
        Me.cmb_grid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_grid.FormattingEnabled = True
        Me.cmb_grid.Items.AddRange(New Object() {"None", "Horizontal", "Vertical", "Both"})
        Me.cmb_grid.Location = New System.Drawing.Point(62, 158)
        Me.cmb_grid.Name = "cmb_grid"
        Me.cmb_grid.Size = New System.Drawing.Size(153, 21)
        Me.cmb_grid.TabIndex = 16
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 161)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(30, 13)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Grid:"
        '
        'cmd_add_groupby
        '
        Me.cmd_add_groupby.Location = New System.Drawing.Point(426, 47)
        Me.cmd_add_groupby.Name = "cmd_add_groupby"
        Me.cmd_add_groupby.Size = New System.Drawing.Size(28, 23)
        Me.cmd_add_groupby.TabIndex = 14
        Me.cmd_add_groupby.Text = "+"
        Me.cmd_add_groupby.UseVisualStyleBackColor = True
        '
        'cmb_presets
        '
        Me.cmb_presets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_presets.FormattingEnabled = True
        Me.cmb_presets.Items.AddRange(New Object() {"None"})
        Me.cmb_presets.Location = New System.Drawing.Point(344, 21)
        Me.cmb_presets.Name = "cmb_presets"
        Me.cmb_presets.Size = New System.Drawing.Size(109, 21)
        Me.cmb_presets.TabIndex = 13
        '
        'lbl_preset
        '
        Me.lbl_preset.AutoSize = True
        Me.lbl_preset.Location = New System.Drawing.Point(288, 24)
        Me.lbl_preset.Name = "lbl_preset"
        Me.lbl_preset.Size = New System.Drawing.Size(50, 13)
        Me.lbl_preset.TabIndex = 12
        Me.lbl_preset.Text = "Presets: "
        '
        'lb_groupby
        '
        Me.lb_groupby.FormattingEnabled = True
        Me.lb_groupby.Location = New System.Drawing.Point(263, 78)
        Me.lb_groupby.Name = "lb_groupby"
        Me.lb_groupby.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
        Me.lb_groupby.Size = New System.Drawing.Size(189, 134)
        Me.lb_groupby.TabIndex = 11
        '
        'cmb_yvalue
        '
        Me.cmb_yvalue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_yvalue.FormattingEnabled = True
        Me.cmb_yvalue.Items.AddRange(New Object() {"None"})
        Me.cmb_yvalue.Location = New System.Drawing.Point(62, 77)
        Me.cmb_yvalue.Name = "cmb_yvalue"
        Me.cmb_yvalue.Size = New System.Drawing.Size(153, 21)
        Me.cmb_yvalue.TabIndex = 10
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 82)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Y Value: "
        '
        'cmb_legend
        '
        Me.cmb_legend.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_legend.FormattingEnabled = True
        Me.cmb_legend.Items.AddRange(New Object() {"None"})
        Me.cmb_legend.Location = New System.Drawing.Point(62, 131)
        Me.cmb_legend.Name = "cmb_legend"
        Me.cmb_legend.Size = New System.Drawing.Size(153, 21)
        Me.cmb_legend.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 134)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Legend: "
        '
        'cmb_xfactor
        '
        Me.cmb_xfactor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_xfactor.FormattingEnabled = True
        Me.cmb_xfactor.Items.AddRange(New Object() {"NONE"})
        Me.cmb_xfactor.Location = New System.Drawing.Point(62, 104)
        Me.cmb_xfactor.Name = "cmb_xfactor"
        Me.cmb_xfactor.Size = New System.Drawing.Size(153, 21)
        Me.cmb_xfactor.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 107)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "X Factor:"
        '
        'cmb_groupby
        '
        Me.cmb_groupby.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_groupby.FormattingEnabled = True
        Me.cmb_groupby.Items.AddRange(New Object() {"None"})
        Me.cmb_groupby.Location = New System.Drawing.Point(263, 48)
        Me.cmb_groupby.Name = "cmb_groupby"
        Me.cmb_groupby.Size = New System.Drawing.Size(159, 21)
        Me.cmb_groupby.TabIndex = 4
        '
        'lbl_group
        '
        Me.lbl_group.AutoSize = True
        Me.lbl_group.Location = New System.Drawing.Point(231, 51)
        Me.lbl_group.Name = "lbl_group"
        Me.lbl_group.Size = New System.Drawing.Size(26, 13)
        Me.lbl_group.TabIndex = 2
        Me.lbl_group.Text = "By: "
        '
        'cmb_jmp_script
        '
        Me.cmb_jmp_script.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_jmp_script.FormattingEnabled = True
        Me.cmb_jmp_script.Items.AddRange(New Object() {"Select Script", "Distribution", "Fit Y by X", "Bin Map"})
        Me.cmb_jmp_script.Location = New System.Drawing.Point(62, 21)
        Me.cmb_jmp_script.Name = "cmb_jmp_script"
        Me.cmb_jmp_script.Size = New System.Drawing.Size(220, 21)
        Me.cmb_jmp_script.TabIndex = 1
        '
        'lbl_script
        '
        Me.lbl_script.AutoSize = True
        Me.lbl_script.Location = New System.Drawing.Point(6, 24)
        Me.lbl_script.Name = "lbl_script"
        Me.lbl_script.Size = New System.Drawing.Size(41, 13)
        Me.lbl_script.TabIndex = 0
        Me.lbl_script.Text = "Script: "
        '
        'chk_jmp
        '
        Me.chk_jmp.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chk_jmp.AutoSize = True
        Me.chk_jmp.Checked = True
        Me.chk_jmp.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_jmp.Location = New System.Drawing.Point(7, 465)
        Me.chk_jmp.Name = "chk_jmp"
        Me.chk_jmp.Size = New System.Drawing.Size(80, 17)
        Me.chk_jmp.TabIndex = 5
        Me.chk_jmp.Text = "Enable JMP"
        Me.chk_jmp.UseVisualStyleBackColor = True
        '
        'bw_headergetter
        '
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(483, 511)
        Me.Controls.Add(Me.chk_jmp)
        Me.Controls.Add(Me.gb_jmp)
        Me.Controls.Add(Me.cmd_krash)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.gb_testblocks)
        Me.Controls.Add(Me.gb_inputfiles)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Krash 0.0.1a"
        Me.gb_inputfiles.ResumeLayout(False)
        Me.gb_testblocks.ResumeLayout(False)
        Me.gb_testblocks.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.gb_jmp.ResumeLayout(False)
        Me.gb_jmp.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gb_inputfiles As System.Windows.Forms.GroupBox
    Friend WithEvents cmd_removeinput As System.Windows.Forms.Button
    Friend WithEvents cmd_addinput As System.Windows.Forms.Button
    Friend WithEvents bw_extracttests As System.ComponentModel.BackgroundWorker
    Friend WithEvents gb_testblocks As System.Windows.Forms.GroupBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents sb_status As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lb_testblocks As System.Windows.Forms.ListBox
    Friend WithEvents lb_inputs As System.Windows.Forms.ListBox
    Friend WithEvents cmd_clear As System.Windows.Forms.Button
    Friend WithEvents lbl_selected_test As System.Windows.Forms.Label
    Friend WithEvents cmd_krash As System.Windows.Forms.Button
    Friend WithEvents bw_krash As System.ComponentModel.BackgroundWorker
    Friend WithEvents gb_jmp As System.Windows.Forms.GroupBox
    Friend WithEvents chk_jmp As System.Windows.Forms.CheckBox
    Friend WithEvents cmb_jmp_script As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_script As System.Windows.Forms.Label
    Friend WithEvents lbl_group As System.Windows.Forms.Label
    Friend WithEvents cmd_all As System.Windows.Forms.Button
    Friend WithEvents bw_headergetter As System.ComponentModel.BackgroundWorker
    Friend WithEvents cmb_groupby As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_xfactor As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmb_legend As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmb_yvalue As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lb_groupby As System.Windows.Forms.ListBox
    Friend WithEvents cmd_add_groupby As System.Windows.Forms.Button
    Friend WithEvents cmb_presets As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_preset As System.Windows.Forms.Label
    Friend WithEvents cmb_grid As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txt_wafer_def As System.Windows.Forms.TextBox
    Friend WithEvents cmb_wafers As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label

End Class
