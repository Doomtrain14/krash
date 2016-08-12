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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
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
        Me.sb_label_spacer = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sb_menu = New System.Windows.Forms.ToolStripDropDownButton()
        Me.sb_menu_about = New System.Windows.Forms.ToolStripMenuItem()
        Me.sb_menu_config = New System.Windows.Forms.ToolStripMenuItem()
        Me.sb_menu_enable_jmp = New System.Windows.Forms.ToolStripMenuItem()
        Me.sb_menu_main_reset = New System.Windows.Forms.ToolStripMenuItem()
        Me.sb_menu_reset_roles = New System.Windows.Forms.ToolStripMenuItem()
        Me.sb_menu_reset_axis = New System.Windows.Forms.ToolStripMenuItem()
        Me.sb_menu_reset_lines = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.sb_menu_reset_all = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmd_krash = New System.Windows.Forms.Button()
        Me.bw_krash = New System.ComponentModel.BackgroundWorker()
        Me.lbl_script = New System.Windows.Forms.Label()
        Me.cmb_jmp_script = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmb_wafers = New System.Windows.Forms.ComboBox()
        Me.txt_wafer_def = New System.Windows.Forms.TextBox()
        Me.gb_columns = New System.Windows.Forms.GroupBox()
        Me.lb_header_list = New System.Windows.Forms.ListBox()
        Me.gb_roles = New System.Windows.Forms.GroupBox()
        Me.cmd_clear_roles = New System.Windows.Forms.Button()
        Me.chk_tabulate = New System.Windows.Forms.CheckBox()
        Me.cmb_ymultiplier = New System.Windows.Forms.ComboBox()
        Me.cmd_legend = New System.Windows.Forms.Button()
        Me.cmd_by = New System.Windows.Forms.Button()
        Me.cmd_xfactor = New System.Windows.Forms.Button()
        Me.cmd_yresponse = New System.Windows.Forms.Button()
        Me.lb_legend = New System.Windows.Forms.ListBox()
        Me.lb_xfactor = New System.Windows.Forms.ListBox()
        Me.lb_yvalue = New System.Windows.Forms.ListBox()
        Me.lb_groupby = New System.Windows.Forms.ListBox()
        Me.gb_jmp = New System.Windows.Forms.GroupBox()
        Me.gb_lines = New System.Windows.Forms.GroupBox()
        Me.lv_refcolor = New System.Windows.Forms.ListView()
        Me.col_key = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_value = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_line = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.width = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cmd_add_refline = New System.Windows.Forms.Button()
        Me.pic_ref_color = New System.Windows.Forms.PictureBox()
        Me.cmb_ref_axis = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.num_line_width = New System.Windows.Forms.NumericUpDown()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txt_ref_label = New System.Windows.Forms.TextBox()
        Me.txt_ref_value = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmd_clear_lines = New System.Windows.Forms.Button()
        Me.gb_axis = New System.Windows.Forms.GroupBox()
        Me.cmd_clear_axis = New System.Windows.Forms.Button()
        Me.txt_yincrement = New System.Windows.Forms.TextBox()
        Me.txt_ymaximum = New System.Windows.Forms.TextBox()
        Me.txt_yminimum = New System.Windows.Forms.TextBox()
        Me.txt_ybase_power = New System.Windows.Forms.TextBox()
        Me.cmb_yscale = New System.Windows.Forms.ComboBox()
        Me.chk_yminor = New System.Windows.Forms.CheckBox()
        Me.chk_xminor = New System.Windows.Forms.CheckBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.chk_ymajor = New System.Windows.Forms.CheckBox()
        Me.chk_xmajor = New System.Windows.Forms.CheckBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txt_xincrement = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txt_xmaximum = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txt_xminimum = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_xbase_power = New System.Windows.Forms.TextBox()
        Me.lbl_base_power = New System.Windows.Forms.Label()
        Me.cmb_xscale = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tool_tip = New System.Windows.Forms.ToolTip(Me.components)
        Me.gb_inputfiles.SuspendLayout()
        Me.gb_testblocks.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.gb_columns.SuspendLayout()
        Me.gb_roles.SuspendLayout()
        Me.gb_jmp.SuspendLayout()
        Me.gb_lines.SuspendLayout()
        CType(Me.pic_ref_color, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_line_width, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gb_axis.SuspendLayout()
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
        Me.gb_inputfiles.Size = New System.Drawing.Size(236, 259)
        Me.gb_inputfiles.TabIndex = 0
        Me.gb_inputfiles.TabStop = False
        Me.gb_inputfiles.Text = "Input files"
        '
        'lb_inputs
        '
        Me.lb_inputs.BackColor = System.Drawing.Color.Ivory
        Me.lb_inputs.FormattingEnabled = True
        Me.lb_inputs.Location = New System.Drawing.Point(6, 20)
        Me.lb_inputs.Name = "lb_inputs"
        Me.lb_inputs.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lb_inputs.Size = New System.Drawing.Size(223, 199)
        Me.lb_inputs.TabIndex = 0
        '
        'cmd_removeinput
        '
        Me.cmd_removeinput.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmd_removeinput.Location = New System.Drawing.Point(175, 226)
        Me.cmd_removeinput.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.cmd_removeinput.Name = "cmd_removeinput"
        Me.cmd_removeinput.Size = New System.Drawing.Size(54, 22)
        Me.cmd_removeinput.TabIndex = 2
        Me.cmd_removeinput.Text = "&Remove"
        Me.cmd_removeinput.UseVisualStyleBackColor = True
        '
        'cmd_addinput
        '
        Me.cmd_addinput.Location = New System.Drawing.Point(6, 226)
        Me.cmd_addinput.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.cmd_addinput.Name = "cmd_addinput"
        Me.cmd_addinput.Size = New System.Drawing.Size(54, 22)
        Me.cmd_addinput.TabIndex = 1
        Me.cmd_addinput.Text = "&Add"
        Me.tool_tip.SetToolTip(Me.cmd_addinput, "Click this button to add input files")
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
        Me.gb_testblocks.Location = New System.Drawing.Point(7, 271)
        Me.gb_testblocks.Margin = New System.Windows.Forms.Padding(4)
        Me.gb_testblocks.Name = "gb_testblocks"
        Me.gb_testblocks.Padding = New System.Windows.Forms.Padding(4)
        Me.gb_testblocks.Size = New System.Drawing.Size(236, 296)
        Me.gb_testblocks.TabIndex = 1
        Me.gb_testblocks.TabStop = False
        Me.gb_testblocks.Text = "Testblocks"
        '
        'cmd_all
        '
        Me.cmd_all.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmd_all.Location = New System.Drawing.Point(117, 264)
        Me.cmd_all.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.cmd_all.Name = "cmd_all"
        Me.cmd_all.Size = New System.Drawing.Size(54, 22)
        Me.cmd_all.TabIndex = 2
        Me.cmd_all.Text = "&All"
        Me.cmd_all.UseVisualStyleBackColor = True
        '
        'cmd_clear
        '
        Me.cmd_clear.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmd_clear.Location = New System.Drawing.Point(175, 264)
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
        Me.lbl_selected_test.Location = New System.Drawing.Point(4, 269)
        Me.lbl_selected_test.Name = "lbl_selected_test"
        Me.lbl_selected_test.Size = New System.Drawing.Size(56, 13)
        Me.lbl_selected_test.TabIndex = 1
        Me.lbl_selected_test.Text = "0 selected"
        '
        'lb_testblocks
        '
        Me.lb_testblocks.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lb_testblocks.BackColor = System.Drawing.Color.Ivory
        Me.lb_testblocks.FormattingEnabled = True
        Me.lb_testblocks.Location = New System.Drawing.Point(7, 20)
        Me.lb_testblocks.Margin = New System.Windows.Forms.Padding(4)
        Me.lb_testblocks.Name = "lb_testblocks"
        Me.lb_testblocks.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
        Me.lb_testblocks.Size = New System.Drawing.Size(222, 238)
        Me.lb_testblocks.TabIndex = 0
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sb_status, Me.sb_label_spacer, Me.sb_menu})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 573)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 17, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(917, 22)
        Me.StatusStrip1.TabIndex = 3
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
        'sb_label_spacer
        '
        Me.sb_label_spacer.AutoSize = False
        Me.sb_label_spacer.Name = "sb_label_spacer"
        Me.sb_label_spacer.Size = New System.Drawing.Size(622, 17)
        Me.sb_label_spacer.Text = resources.GetString("sb_label_spacer.Text")
        '
        'sb_menu
        '
        Me.sb_menu.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.sb_menu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.sb_menu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sb_menu_about, Me.sb_menu_config})
        Me.sb_menu.Image = CType(resources.GetObject("sb_menu.Image"), System.Drawing.Image)
        Me.sb_menu.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.sb_menu.Name = "sb_menu"
        Me.sb_menu.Size = New System.Drawing.Size(51, 20)
        Me.sb_menu.Text = "&Menu"
        '
        'sb_menu_about
        '
        Me.sb_menu_about.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.sb_menu_about.Name = "sb_menu_about"
        Me.sb_menu_about.Size = New System.Drawing.Size(148, 22)
        Me.sb_menu_about.Text = "About"
        Me.sb_menu_about.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'sb_menu_config
        '
        Me.sb_menu_config.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.sb_menu_config.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sb_menu_enable_jmp, Me.sb_menu_main_reset})
        Me.sb_menu_config.Name = "sb_menu_config"
        Me.sb_menu_config.Size = New System.Drawing.Size(148, 22)
        Me.sb_menu_config.Text = "Configuration"
        Me.sb_menu_config.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'sb_menu_enable_jmp
        '
        Me.sb_menu_enable_jmp.Checked = True
        Me.sb_menu_enable_jmp.CheckState = System.Windows.Forms.CheckState.Checked
        Me.sb_menu_enable_jmp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.sb_menu_enable_jmp.Name = "sb_menu_enable_jmp"
        Me.sb_menu_enable_jmp.Size = New System.Drawing.Size(134, 22)
        Me.sb_menu_enable_jmp.Text = "Enable JMP"
        '
        'sb_menu_main_reset
        '
        Me.sb_menu_main_reset.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sb_menu_reset_roles, Me.sb_menu_reset_axis, Me.sb_menu_reset_lines, Me.ToolStripMenuItem1, Me.sb_menu_reset_all})
        Me.sb_menu_main_reset.Name = "sb_menu_main_reset"
        Me.sb_menu_main_reset.Size = New System.Drawing.Size(134, 22)
        Me.sb_menu_main_reset.Text = "Reset"
        '
        'sb_menu_reset_roles
        '
        Me.sb_menu_reset_roles.Name = "sb_menu_reset_roles"
        Me.sb_menu_reset_roles.Size = New System.Drawing.Size(161, 22)
        Me.sb_menu_reset_roles.Text = "Roles"
        '
        'sb_menu_reset_axis
        '
        Me.sb_menu_reset_axis.Name = "sb_menu_reset_axis"
        Me.sb_menu_reset_axis.Size = New System.Drawing.Size(161, 22)
        Me.sb_menu_reset_axis.Text = "Axis"
        '
        'sb_menu_reset_lines
        '
        Me.sb_menu_reset_lines.Name = "sb_menu_reset_lines"
        Me.sb_menu_reset_lines.Size = New System.Drawing.Size(161, 22)
        Me.sb_menu_reset_lines.Text = "Lines"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(158, 6)
        '
        'sb_menu_reset_all
        '
        Me.sb_menu_reset_all.Name = "sb_menu_reset_all"
        Me.sb_menu_reset_all.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.R), System.Windows.Forms.Keys)
        Me.sb_menu_reset_all.Size = New System.Drawing.Size(161, 22)
        Me.sb_menu_reset_all.Text = "All"
        '
        'cmd_krash
        '
        Me.cmd_krash.Location = New System.Drawing.Point(367, 17)
        Me.cmd_krash.Name = "cmd_krash"
        Me.cmd_krash.Size = New System.Drawing.Size(279, 49)
        Me.cmd_krash.TabIndex = 4
        Me.cmd_krash.Text = "Krash"
        Me.cmd_krash.UseVisualStyleBackColor = True
        '
        'bw_krash
        '
        Me.bw_krash.WorkerReportsProgress = True
        Me.bw_krash.WorkerSupportsCancellation = True
        '
        'lbl_script
        '
        Me.lbl_script.AutoSize = True
        Me.lbl_script.Location = New System.Drawing.Point(9, 20)
        Me.lbl_script.Name = "lbl_script"
        Me.lbl_script.Size = New System.Drawing.Size(60, 13)
        Me.lbl_script.TabIndex = 0
        Me.lbl_script.Text = "JSL Script: "
        '
        'cmb_jmp_script
        '
        Me.cmb_jmp_script.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_jmp_script.FormattingEnabled = True
        Me.cmb_jmp_script.Items.AddRange(New Object() {"Select Script", "Distribution", "Fit Y by X", "Contour Plot", "Overlay Plot", "Tabulate"})
        Me.cmb_jmp_script.Location = New System.Drawing.Point(105, 17)
        Me.cmb_jmp_script.Name = "cmb_jmp_script"
        Me.cmb_jmp_script.Size = New System.Drawing.Size(256, 21)
        Me.cmb_jmp_script.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(10, 49)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(89, 13)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "Wafer Definition:"
        '
        'cmb_wafers
        '
        Me.cmb_wafers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_wafers.FormattingEnabled = True
        Me.cmb_wafers.Location = New System.Drawing.Point(105, 44)
        Me.cmb_wafers.Name = "cmb_wafers"
        Me.cmb_wafers.Size = New System.Drawing.Size(140, 21)
        Me.cmb_wafers.TabIndex = 1
        '
        'txt_wafer_def
        '
        Me.txt_wafer_def.BackColor = System.Drawing.Color.Ivory
        Me.txt_wafer_def.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_wafer_def.Location = New System.Drawing.Point(251, 45)
        Me.txt_wafer_def.Name = "txt_wafer_def"
        Me.txt_wafer_def.Size = New System.Drawing.Size(110, 21)
        Me.txt_wafer_def.TabIndex = 2
        '
        'gb_columns
        '
        Me.gb_columns.Controls.Add(Me.lb_header_list)
        Me.gb_columns.Location = New System.Drawing.Point(6, 72)
        Me.gb_columns.Name = "gb_columns"
        Me.gb_columns.Size = New System.Drawing.Size(133, 481)
        Me.gb_columns.TabIndex = 0
        Me.gb_columns.TabStop = False
        Me.gb_columns.Text = "Columns"
        '
        'lb_header_list
        '
        Me.lb_header_list.AllowDrop = True
        Me.lb_header_list.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lb_header_list.BackColor = System.Drawing.Color.Ivory
        Me.lb_header_list.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.lb_header_list.FormattingEnabled = True
        Me.lb_header_list.Location = New System.Drawing.Point(6, 20)
        Me.lb_header_list.Name = "lb_header_list"
        Me.lb_header_list.Size = New System.Drawing.Size(121, 433)
        Me.lb_header_list.TabIndex = 0
        '
        'gb_roles
        '
        Me.gb_roles.Controls.Add(Me.cmd_clear_roles)
        Me.gb_roles.Controls.Add(Me.chk_tabulate)
        Me.gb_roles.Controls.Add(Me.cmb_ymultiplier)
        Me.gb_roles.Controls.Add(Me.cmd_legend)
        Me.gb_roles.Controls.Add(Me.cmd_by)
        Me.gb_roles.Controls.Add(Me.cmd_xfactor)
        Me.gb_roles.Controls.Add(Me.cmd_yresponse)
        Me.gb_roles.Controls.Add(Me.lb_legend)
        Me.gb_roles.Controls.Add(Me.lb_xfactor)
        Me.gb_roles.Controls.Add(Me.lb_yvalue)
        Me.gb_roles.Controls.Add(Me.lb_groupby)
        Me.gb_roles.Location = New System.Drawing.Point(145, 72)
        Me.gb_roles.Name = "gb_roles"
        Me.gb_roles.Size = New System.Drawing.Size(216, 481)
        Me.gb_roles.TabIndex = 1
        Me.gb_roles.TabStop = False
        Me.gb_roles.Text = "Roles"
        '
        'cmd_clear_roles
        '
        Me.cmd_clear_roles.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmd_clear_roles.Location = New System.Drawing.Point(155, 449)
        Me.cmd_clear_roles.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.cmd_clear_roles.Name = "cmd_clear_roles"
        Me.cmd_clear_roles.Size = New System.Drawing.Size(54, 22)
        Me.cmd_clear_roles.TabIndex = 10
        Me.cmd_clear_roles.Text = "&Clear"
        Me.cmd_clear_roles.UseVisualStyleBackColor = True
        '
        'chk_tabulate
        '
        Me.chk_tabulate.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.chk_tabulate.AutoSize = True
        Me.chk_tabulate.Location = New System.Drawing.Point(98, 324)
        Me.chk_tabulate.Name = "chk_tabulate"
        Me.chk_tabulate.Size = New System.Drawing.Size(68, 17)
        Me.chk_tabulate.TabIndex = 0
        Me.chk_tabulate.Text = "Tabulate"
        Me.chk_tabulate.UseVisualStyleBackColor = True
        '
        'cmb_ymultiplier
        '
        Me.cmb_ymultiplier.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_ymultiplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_ymultiplier.FormattingEnabled = True
        Me.cmb_ymultiplier.Items.AddRange(New Object() {"None", "N*10^3", "N*10^6", "Log N", "Log N*10^3", "Log N*10^6"})
        Me.cmb_ymultiplier.Location = New System.Drawing.Point(5, 50)
        Me.cmb_ymultiplier.Name = "cmb_ymultiplier"
        Me.cmb_ymultiplier.Size = New System.Drawing.Size(87, 21)
        Me.cmb_ymultiplier.TabIndex = 2
        '
        'cmd_legend
        '
        Me.cmd_legend.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmd_legend.Location = New System.Drawing.Point(5, 347)
        Me.cmd_legend.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.cmd_legend.Name = "cmd_legend"
        Me.cmd_legend.Size = New System.Drawing.Size(88, 22)
        Me.cmd_legend.TabIndex = 8
        Me.cmd_legend.Text = "Legend"
        Me.cmd_legend.UseVisualStyleBackColor = True
        '
        'cmd_by
        '
        Me.cmd_by.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmd_by.Location = New System.Drawing.Point(5, 223)
        Me.cmd_by.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.cmd_by.Name = "cmd_by"
        Me.cmd_by.Size = New System.Drawing.Size(88, 22)
        Me.cmd_by.TabIndex = 6
        Me.cmd_by.Text = "By"
        Me.cmd_by.UseVisualStyleBackColor = True
        '
        'cmd_xfactor
        '
        Me.cmd_xfactor.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmd_xfactor.Location = New System.Drawing.Point(5, 122)
        Me.cmd_xfactor.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.cmd_xfactor.Name = "cmd_xfactor"
        Me.cmd_xfactor.Size = New System.Drawing.Size(88, 22)
        Me.cmd_xfactor.TabIndex = 4
        Me.cmd_xfactor.Text = "X Factor"
        Me.cmd_xfactor.UseVisualStyleBackColor = True
        '
        'cmd_yresponse
        '
        Me.cmd_yresponse.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmd_yresponse.Location = New System.Drawing.Point(5, 21)
        Me.cmd_yresponse.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.cmd_yresponse.Name = "cmd_yresponse"
        Me.cmd_yresponse.Size = New System.Drawing.Size(88, 22)
        Me.cmd_yresponse.TabIndex = 0
        Me.cmd_yresponse.Text = "Y, Response"
        Me.cmd_yresponse.UseVisualStyleBackColor = True
        '
        'lb_legend
        '
        Me.lb_legend.AllowDrop = True
        Me.lb_legend.BackColor = System.Drawing.Color.Ivory
        Me.lb_legend.FormattingEnabled = True
        Me.lb_legend.Location = New System.Drawing.Point(98, 347)
        Me.lb_legend.Name = "lb_legend"
        Me.lb_legend.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
        Me.lb_legend.Size = New System.Drawing.Size(111, 95)
        Me.lb_legend.TabIndex = 9
        '
        'lb_xfactor
        '
        Me.lb_xfactor.AllowDrop = True
        Me.lb_xfactor.BackColor = System.Drawing.Color.Ivory
        Me.lb_xfactor.FormattingEnabled = True
        Me.lb_xfactor.Location = New System.Drawing.Point(98, 122)
        Me.lb_xfactor.Name = "lb_xfactor"
        Me.lb_xfactor.Size = New System.Drawing.Size(111, 95)
        Me.lb_xfactor.TabIndex = 5
        '
        'lb_yvalue
        '
        Me.lb_yvalue.AllowDrop = True
        Me.lb_yvalue.BackColor = System.Drawing.Color.Ivory
        Me.lb_yvalue.FormattingEnabled = True
        Me.lb_yvalue.Location = New System.Drawing.Point(98, 21)
        Me.lb_yvalue.Name = "lb_yvalue"
        Me.lb_yvalue.Size = New System.Drawing.Size(111, 95)
        Me.lb_yvalue.TabIndex = 3
        '
        'lb_groupby
        '
        Me.lb_groupby.AllowDrop = True
        Me.lb_groupby.BackColor = System.Drawing.Color.Ivory
        Me.lb_groupby.FormattingEnabled = True
        Me.lb_groupby.Location = New System.Drawing.Point(98, 223)
        Me.lb_groupby.Name = "lb_groupby"
        Me.lb_groupby.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
        Me.lb_groupby.Size = New System.Drawing.Size(111, 95)
        Me.lb_groupby.TabIndex = 7
        '
        'gb_jmp
        '
        Me.gb_jmp.Controls.Add(Me.cmd_krash)
        Me.gb_jmp.Controls.Add(Me.gb_lines)
        Me.gb_jmp.Controls.Add(Me.gb_axis)
        Me.gb_jmp.Controls.Add(Me.gb_roles)
        Me.gb_jmp.Controls.Add(Me.gb_columns)
        Me.gb_jmp.Controls.Add(Me.txt_wafer_def)
        Me.gb_jmp.Controls.Add(Me.cmb_wafers)
        Me.gb_jmp.Controls.Add(Me.Label5)
        Me.gb_jmp.Controls.Add(Me.cmb_jmp_script)
        Me.gb_jmp.Controls.Add(Me.lbl_script)
        Me.gb_jmp.Location = New System.Drawing.Point(248, 4)
        Me.gb_jmp.Name = "gb_jmp"
        Me.gb_jmp.Size = New System.Drawing.Size(657, 563)
        Me.gb_jmp.TabIndex = 2
        Me.gb_jmp.TabStop = False
        Me.gb_jmp.Text = "JMP"
        '
        'gb_lines
        '
        Me.gb_lines.Controls.Add(Me.lv_refcolor)
        Me.gb_lines.Controls.Add(Me.cmd_add_refline)
        Me.gb_lines.Controls.Add(Me.pic_ref_color)
        Me.gb_lines.Controls.Add(Me.cmb_ref_axis)
        Me.gb_lines.Controls.Add(Me.Label13)
        Me.gb_lines.Controls.Add(Me.num_line_width)
        Me.gb_lines.Controls.Add(Me.Label14)
        Me.gb_lines.Controls.Add(Me.txt_ref_label)
        Me.gb_lines.Controls.Add(Me.txt_ref_value)
        Me.gb_lines.Controls.Add(Me.Label12)
        Me.gb_lines.Controls.Add(Me.Label11)
        Me.gb_lines.Controls.Add(Me.Label4)
        Me.gb_lines.Controls.Add(Me.cmd_clear_lines)
        Me.gb_lines.Location = New System.Drawing.Point(367, 323)
        Me.gb_lines.Name = "gb_lines"
        Me.gb_lines.Size = New System.Drawing.Size(279, 230)
        Me.gb_lines.TabIndex = 19
        Me.gb_lines.TabStop = False
        Me.gb_lines.Text = "Reference Lines"
        '
        'lv_refcolor
        '
        Me.lv_refcolor.BackColor = System.Drawing.Color.Ivory
        Me.lv_refcolor.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.col_key, Me.col_value, Me.col_line, Me.width})
        Me.lv_refcolor.FullRowSelect = True
        Me.lv_refcolor.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lv_refcolor.Location = New System.Drawing.Point(100, 20)
        Me.lv_refcolor.MultiSelect = False
        Me.lv_refcolor.Name = "lv_refcolor"
        Me.lv_refcolor.Size = New System.Drawing.Size(173, 171)
        Me.lv_refcolor.TabIndex = 35
        Me.lv_refcolor.UseCompatibleStateImageBehavior = False
        Me.lv_refcolor.View = System.Windows.Forms.View.Details
        '
        'col_key
        '
        Me.col_key.Text = "Value"
        Me.col_key.Width = 0
        '
        'col_value
        '
        Me.col_value.Text = "Value"
        Me.col_value.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.col_value.Width = 120
        '
        'col_line
        '
        Me.col_line.Text = ""
        Me.col_line.Width = 45
        '
        'width
        '
        Me.width.Width = 0
        '
        'cmd_add_refline
        '
        Me.cmd_add_refline.Location = New System.Drawing.Point(9, 156)
        Me.cmd_add_refline.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.cmd_add_refline.Name = "cmd_add_refline"
        Me.cmd_add_refline.Size = New System.Drawing.Size(85, 22)
        Me.cmd_add_refline.TabIndex = 34
        Me.cmd_add_refline.Text = "&Add"
        Me.tool_tip.SetToolTip(Me.cmd_add_refline, "Click this button to add input files")
        Me.cmd_add_refline.UseVisualStyleBackColor = True
        '
        'pic_ref_color
        '
        Me.pic_ref_color.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.pic_ref_color.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pic_ref_color.Location = New System.Drawing.Point(45, 101)
        Me.pic_ref_color.Name = "pic_ref_color"
        Me.pic_ref_color.Size = New System.Drawing.Size(49, 21)
        Me.pic_ref_color.TabIndex = 33
        Me.pic_ref_color.TabStop = False
        '
        'cmb_ref_axis
        '
        Me.cmb_ref_axis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_ref_axis.FormattingEnabled = True
        Me.cmb_ref_axis.Items.AddRange(New Object() {"X", "Y"})
        Me.cmb_ref_axis.Location = New System.Drawing.Point(44, 20)
        Me.cmb_ref_axis.Name = "cmb_ref_axis"
        Me.cmb_ref_axis.Size = New System.Drawing.Size(50, 21)
        Me.cmb_ref_axis.TabIndex = 32
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(6, 23)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(27, 13)
        Me.Label13.TabIndex = 31
        Me.Label13.Text = "Axis"
        '
        'num_line_width
        '
        Me.num_line_width.BackColor = System.Drawing.Color.Ivory
        Me.num_line_width.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.num_line_width.Location = New System.Drawing.Point(45, 128)
        Me.num_line_width.Name = "num_line_width"
        Me.num_line_width.Size = New System.Drawing.Size(49, 21)
        Me.num_line_width.TabIndex = 30
        Me.num_line_width.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(6, 130)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(35, 13)
        Me.Label14.TabIndex = 29
        Me.Label14.Text = "Width"
        '
        'txt_ref_label
        '
        Me.txt_ref_label.BackColor = System.Drawing.Color.Ivory
        Me.txt_ref_label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_ref_label.Location = New System.Drawing.Point(45, 74)
        Me.txt_ref_label.Name = "txt_ref_label"
        Me.txt_ref_label.Size = New System.Drawing.Size(49, 21)
        Me.txt_ref_label.TabIndex = 25
        Me.txt_ref_label.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_ref_value
        '
        Me.txt_ref_value.BackColor = System.Drawing.Color.Ivory
        Me.txt_ref_value.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_ref_value.Location = New System.Drawing.Point(45, 47)
        Me.txt_ref_value.Name = "txt_ref_value"
        Me.txt_ref_value.Size = New System.Drawing.Size(49, 21)
        Me.txt_ref_value.TabIndex = 24
        Me.txt_ref_value.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(6, 103)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(32, 13)
        Me.Label12.TabIndex = 22
        Me.Label12.Text = "Color"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(6, 76)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(32, 13)
        Me.Label11.TabIndex = 21
        Me.Label11.Text = "Label"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 49)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(33, 13)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "Value"
        '
        'cmd_clear_lines
        '
        Me.cmd_clear_lines.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.cmd_clear_lines.Location = New System.Drawing.Point(220, 198)
        Me.cmd_clear_lines.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.cmd_clear_lines.Name = "cmd_clear_lines"
        Me.cmd_clear_lines.Size = New System.Drawing.Size(54, 22)
        Me.cmd_clear_lines.TabIndex = 11
        Me.cmd_clear_lines.Text = "&Clear"
        Me.cmd_clear_lines.UseVisualStyleBackColor = True
        '
        'gb_axis
        '
        Me.gb_axis.Controls.Add(Me.cmd_clear_axis)
        Me.gb_axis.Controls.Add(Me.txt_yincrement)
        Me.gb_axis.Controls.Add(Me.txt_ymaximum)
        Me.gb_axis.Controls.Add(Me.txt_yminimum)
        Me.gb_axis.Controls.Add(Me.txt_ybase_power)
        Me.gb_axis.Controls.Add(Me.cmb_yscale)
        Me.gb_axis.Controls.Add(Me.chk_yminor)
        Me.gb_axis.Controls.Add(Me.chk_xminor)
        Me.gb_axis.Controls.Add(Me.Label10)
        Me.gb_axis.Controls.Add(Me.chk_ymajor)
        Me.gb_axis.Controls.Add(Me.chk_xmajor)
        Me.gb_axis.Controls.Add(Me.Label9)
        Me.gb_axis.Controls.Add(Me.Label8)
        Me.gb_axis.Controls.Add(Me.Label7)
        Me.gb_axis.Controls.Add(Me.txt_xincrement)
        Me.gb_axis.Controls.Add(Me.Label6)
        Me.gb_axis.Controls.Add(Me.txt_xmaximum)
        Me.gb_axis.Controls.Add(Me.Label3)
        Me.gb_axis.Controls.Add(Me.txt_xminimum)
        Me.gb_axis.Controls.Add(Me.Label2)
        Me.gb_axis.Controls.Add(Me.txt_xbase_power)
        Me.gb_axis.Controls.Add(Me.lbl_base_power)
        Me.gb_axis.Controls.Add(Me.cmb_xscale)
        Me.gb_axis.Controls.Add(Me.Label1)
        Me.gb_axis.Location = New System.Drawing.Point(367, 72)
        Me.gb_axis.Name = "gb_axis"
        Me.gb_axis.Size = New System.Drawing.Size(279, 245)
        Me.gb_axis.TabIndex = 2
        Me.gb_axis.TabStop = False
        Me.gb_axis.Text = "Axis"
        '
        'cmd_clear_axis
        '
        Me.cmd_clear_axis.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.cmd_clear_axis.Location = New System.Drawing.Point(220, 216)
        Me.cmd_clear_axis.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.cmd_clear_axis.Name = "cmd_clear_axis"
        Me.cmd_clear_axis.Size = New System.Drawing.Size(54, 22)
        Me.cmd_clear_axis.TabIndex = 35
        Me.cmd_clear_axis.Text = "&Clear"
        Me.cmd_clear_axis.UseVisualStyleBackColor = True
        '
        'txt_yincrement
        '
        Me.txt_yincrement.BackColor = System.Drawing.Color.Ivory
        Me.txt_yincrement.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_yincrement.Location = New System.Drawing.Point(186, 141)
        Me.txt_yincrement.Name = "txt_yincrement"
        Me.txt_yincrement.Size = New System.Drawing.Size(71, 21)
        Me.txt_yincrement.TabIndex = 9
        Me.txt_yincrement.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_ymaximum
        '
        Me.txt_ymaximum.BackColor = System.Drawing.Color.Ivory
        Me.txt_ymaximum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_ymaximum.Location = New System.Drawing.Point(186, 114)
        Me.txt_ymaximum.Name = "txt_ymaximum"
        Me.txt_ymaximum.Size = New System.Drawing.Size(71, 21)
        Me.txt_ymaximum.TabIndex = 7
        Me.txt_ymaximum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_yminimum
        '
        Me.txt_yminimum.BackColor = System.Drawing.Color.Ivory
        Me.txt_yminimum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_yminimum.Location = New System.Drawing.Point(186, 86)
        Me.txt_yminimum.Name = "txt_yminimum"
        Me.txt_yminimum.Size = New System.Drawing.Size(71, 21)
        Me.txt_yminimum.TabIndex = 5
        Me.txt_yminimum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_ybase_power
        '
        Me.txt_ybase_power.BackColor = System.Drawing.Color.Ivory
        Me.txt_ybase_power.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_ybase_power.Enabled = False
        Me.txt_ybase_power.Location = New System.Drawing.Point(186, 59)
        Me.txt_ybase_power.Name = "txt_ybase_power"
        Me.txt_ybase_power.Size = New System.Drawing.Size(71, 21)
        Me.txt_ybase_power.TabIndex = 3
        Me.txt_ybase_power.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmb_yscale
        '
        Me.cmb_yscale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_yscale.FormattingEnabled = True
        Me.cmb_yscale.Items.AddRange(New Object() {"Linear", "Log", "Power"})
        Me.cmb_yscale.Location = New System.Drawing.Point(186, 33)
        Me.cmb_yscale.Name = "cmb_yscale"
        Me.cmb_yscale.Size = New System.Drawing.Size(71, 21)
        Me.cmb_yscale.TabIndex = 1
        '
        'chk_yminor
        '
        Me.chk_yminor.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.chk_yminor.AutoSize = True
        Me.chk_yminor.Location = New System.Drawing.Point(186, 198)
        Me.chk_yminor.Name = "chk_yminor"
        Me.chk_yminor.Size = New System.Drawing.Size(15, 14)
        Me.chk_yminor.TabIndex = 13
        Me.chk_yminor.UseVisualStyleBackColor = True
        '
        'chk_xminor
        '
        Me.chk_xminor.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.chk_xminor.AutoSize = True
        Me.chk_xminor.Location = New System.Drawing.Point(79, 198)
        Me.chk_xminor.Name = "chk_xminor"
        Me.chk_xminor.Size = New System.Drawing.Size(15, 14)
        Me.chk_xminor.TabIndex = 12
        Me.chk_xminor.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(9, 198)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(59, 13)
        Me.Label10.TabIndex = 34
        Me.Label10.Text = "Minor Grid:"
        '
        'chk_ymajor
        '
        Me.chk_ymajor.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.chk_ymajor.AutoSize = True
        Me.chk_ymajor.Checked = True
        Me.chk_ymajor.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_ymajor.Location = New System.Drawing.Point(186, 173)
        Me.chk_ymajor.Name = "chk_ymajor"
        Me.chk_ymajor.Size = New System.Drawing.Size(15, 14)
        Me.chk_ymajor.TabIndex = 11
        Me.chk_ymajor.UseVisualStyleBackColor = True
        '
        'chk_xmajor
        '
        Me.chk_xmajor.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.chk_xmajor.AutoSize = True
        Me.chk_xmajor.Checked = True
        Me.chk_xmajor.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_xmajor.Location = New System.Drawing.Point(79, 173)
        Me.chk_xmajor.Name = "chk_xmajor"
        Me.chk_xmajor.Size = New System.Drawing.Size(15, 14)
        Me.chk_xmajor.TabIndex = 10
        Me.chk_xmajor.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(183, 17)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(36, 13)
        Me.Label9.TabIndex = 31
        Me.Label9.Text = "Y Axis"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(81, 17)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(36, 13)
        Me.Label8.TabIndex = 30
        Me.Label8.Text = "X Axis"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(9, 171)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(60, 13)
        Me.Label7.TabIndex = 29
        Me.Label7.Text = "Major Grid:"
        '
        'txt_xincrement
        '
        Me.txt_xincrement.BackColor = System.Drawing.Color.Ivory
        Me.txt_xincrement.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_xincrement.Location = New System.Drawing.Point(79, 141)
        Me.txt_xincrement.Name = "txt_xincrement"
        Me.txt_xincrement.Size = New System.Drawing.Size(71, 21)
        Me.txt_xincrement.TabIndex = 8
        Me.txt_xincrement.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(9, 143)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(60, 13)
        Me.Label6.TabIndex = 27
        Me.Label6.Text = "Increment:"
        '
        'txt_xmaximum
        '
        Me.txt_xmaximum.BackColor = System.Drawing.Color.Ivory
        Me.txt_xmaximum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_xmaximum.Location = New System.Drawing.Point(79, 114)
        Me.txt_xmaximum.Name = "txt_xmaximum"
        Me.txt_xmaximum.Size = New System.Drawing.Size(71, 21)
        Me.txt_xmaximum.TabIndex = 6
        Me.txt_xmaximum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 116)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 13)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "Maximum:"
        '
        'txt_xminimum
        '
        Me.txt_xminimum.BackColor = System.Drawing.Color.Ivory
        Me.txt_xminimum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_xminimum.Location = New System.Drawing.Point(79, 87)
        Me.txt_xminimum.Name = "txt_xminimum"
        Me.txt_xminimum.Size = New System.Drawing.Size(71, 21)
        Me.txt_xminimum.TabIndex = 4
        Me.txt_xminimum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 89)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 13)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "Minimum:"
        '
        'txt_xbase_power
        '
        Me.txt_xbase_power.BackColor = System.Drawing.Color.Ivory
        Me.txt_xbase_power.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_xbase_power.Enabled = False
        Me.txt_xbase_power.Location = New System.Drawing.Point(79, 60)
        Me.txt_xbase_power.Name = "txt_xbase_power"
        Me.txt_xbase_power.Size = New System.Drawing.Size(71, 21)
        Me.txt_xbase_power.TabIndex = 2
        Me.txt_xbase_power.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbl_base_power
        '
        Me.lbl_base_power.AutoSize = True
        Me.lbl_base_power.Location = New System.Drawing.Point(9, 62)
        Me.lbl_base_power.Name = "lbl_base_power"
        Me.lbl_base_power.Size = New System.Drawing.Size(68, 13)
        Me.lbl_base_power.TabIndex = 21
        Me.lbl_base_power.Text = "Base/Power:"
        '
        'cmb_xscale
        '
        Me.cmb_xscale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_xscale.FormattingEnabled = True
        Me.cmb_xscale.Items.AddRange(New Object() {"Linear", "Log", "Power"})
        Me.cmb_xscale.Location = New System.Drawing.Point(79, 33)
        Me.cmb_xscale.Name = "cmb_xscale"
        Me.cmb_xscale.Size = New System.Drawing.Size(71, 21)
        Me.cmb_xscale.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 13)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Scale:"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(917, 595)
        Me.Controls.Add(Me.gb_jmp)
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
        Me.gb_columns.ResumeLayout(False)
        Me.gb_roles.ResumeLayout(False)
        Me.gb_roles.PerformLayout()
        Me.gb_jmp.ResumeLayout(False)
        Me.gb_jmp.PerformLayout()
        Me.gb_lines.ResumeLayout(False)
        Me.gb_lines.PerformLayout()
        CType(Me.pic_ref_color, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_line_width, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gb_axis.ResumeLayout(False)
        Me.gb_axis.PerformLayout()
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
    Friend WithEvents cmd_all As System.Windows.Forms.Button
    Friend WithEvents lbl_script As System.Windows.Forms.Label
    Friend WithEvents cmb_jmp_script As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmb_wafers As System.Windows.Forms.ComboBox
    Friend WithEvents txt_wafer_def As System.Windows.Forms.TextBox
    Friend WithEvents gb_columns As System.Windows.Forms.GroupBox
    Friend WithEvents lb_header_list As System.Windows.Forms.ListBox
    Friend WithEvents gb_roles As System.Windows.Forms.GroupBox
    Friend WithEvents lb_xfactor As System.Windows.Forms.ListBox
    Friend WithEvents lb_yvalue As System.Windows.Forms.ListBox
    Friend WithEvents lb_groupby As System.Windows.Forms.ListBox
    Friend WithEvents gb_jmp As System.Windows.Forms.GroupBox
    Friend WithEvents lb_legend As System.Windows.Forms.ListBox
    Friend WithEvents cmd_legend As System.Windows.Forms.Button
    Friend WithEvents cmd_by As System.Windows.Forms.Button
    Friend WithEvents cmd_xfactor As System.Windows.Forms.Button
    Friend WithEvents cmd_yresponse As System.Windows.Forms.Button
    Friend WithEvents cmb_ymultiplier As System.Windows.Forms.ComboBox
    Friend WithEvents sb_menu As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents sb_menu_config As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents sb_menu_about As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents sb_label_spacer As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents chk_tabulate As System.Windows.Forms.CheckBox
    Friend WithEvents gb_axis As System.Windows.Forms.GroupBox
    Friend WithEvents cmb_xscale As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_xincrement As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_xmaximum As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_xminimum As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_xbase_power As System.Windows.Forms.TextBox
    Friend WithEvents lbl_base_power As System.Windows.Forms.Label
    Friend WithEvents txt_ybase_power As System.Windows.Forms.TextBox
    Friend WithEvents cmb_yscale As System.Windows.Forms.ComboBox
    Friend WithEvents chk_yminor As System.Windows.Forms.CheckBox
    Friend WithEvents chk_xminor As System.Windows.Forms.CheckBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents chk_ymajor As System.Windows.Forms.CheckBox
    Friend WithEvents chk_xmajor As System.Windows.Forms.CheckBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txt_yincrement As System.Windows.Forms.TextBox
    Friend WithEvents txt_ymaximum As System.Windows.Forms.TextBox
    Friend WithEvents txt_yminimum As System.Windows.Forms.TextBox
    Friend WithEvents sb_menu_enable_jmp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents sb_menu_main_reset As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents sb_menu_reset_roles As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents sb_menu_reset_axis As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents sb_menu_reset_lines As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents sb_menu_reset_all As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gb_lines As System.Windows.Forms.GroupBox
    Friend WithEvents tool_tip As System.Windows.Forms.ToolTip
    Friend WithEvents cmd_clear_roles As System.Windows.Forms.Button
    Friend WithEvents cmd_clear_lines As System.Windows.Forms.Button
    Friend WithEvents cmd_clear_axis As System.Windows.Forms.Button
    Friend WithEvents pic_ref_color As System.Windows.Forms.PictureBox
    Friend WithEvents cmb_ref_axis As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents num_line_width As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txt_ref_label As System.Windows.Forms.TextBox
    Friend WithEvents txt_ref_value As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmd_add_refline As System.Windows.Forms.Button
    Friend WithEvents lv_refcolor As System.Windows.Forms.ListView
    Friend WithEvents col_line As System.Windows.Forms.ColumnHeader
    Friend WithEvents col_key As System.Windows.Forms.ColumnHeader
    Friend WithEvents col_value As System.Windows.Forms.ColumnHeader
    Friend WithEvents width As System.Windows.Forms.ColumnHeader

End Class
