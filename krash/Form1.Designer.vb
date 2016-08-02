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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lb_inputs = New System.Windows.Forms.ListBox()
        Me.cmd_removeinput = New System.Windows.Forms.Button()
        Me.cmd_addinput = New System.Windows.Forms.Button()
        Me.bw_extracttests = New System.ComponentModel.BackgroundWorker()
        Me.gb_testblocks = New System.Windows.Forms.GroupBox()
        Me.cmd_clear = New System.Windows.Forms.Button()
        Me.lbl_selected_test = New System.Windows.Forms.Label()
        Me.lb_testblocks = New System.Windows.Forms.ListBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.sb_status = New System.Windows.Forms.ToolStripStatusLabel()
        Me.cmd_krash = New System.Windows.Forms.Button()
        Me.bw_krash = New System.ComponentModel.BackgroundWorker()
        Me.gb_jmp = New System.Windows.Forms.GroupBox()
        Me.chk_jmp = New System.Windows.Forms.CheckBox()
        Me.GroupBox1.SuspendLayout()
        Me.gb_testblocks.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lb_inputs)
        Me.GroupBox1.Controls.Add(Me.cmd_removeinput)
        Me.GroupBox1.Controls.Add(Me.cmd_addinput)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 4)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(177, 215)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Input files"
        '
        'lb_inputs
        '
        Me.lb_inputs.FormattingEnabled = True
        Me.lb_inputs.Location = New System.Drawing.Point(6, 20)
        Me.lb_inputs.Name = "lb_inputs"
        Me.lb_inputs.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lb_inputs.Size = New System.Drawing.Size(164, 160)
        Me.lb_inputs.TabIndex = 3
        '
        'cmd_removeinput
        '
        Me.cmd_removeinput.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmd_removeinput.Location = New System.Drawing.Point(117, 185)
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
        Me.gb_testblocks.Controls.Add(Me.cmd_clear)
        Me.gb_testblocks.Controls.Add(Me.lbl_selected_test)
        Me.gb_testblocks.Controls.Add(Me.lb_testblocks)
        Me.gb_testblocks.Location = New System.Drawing.Point(190, 4)
        Me.gb_testblocks.Margin = New System.Windows.Forms.Padding(4)
        Me.gb_testblocks.Name = "gb_testblocks"
        Me.gb_testblocks.Padding = New System.Windows.Forms.Padding(4)
        Me.gb_testblocks.Size = New System.Drawing.Size(177, 215)
        Me.gb_testblocks.TabIndex = 1
        Me.gb_testblocks.TabStop = False
        Me.gb_testblocks.Text = "Testblocks"
        '
        'cmd_clear
        '
        Me.cmd_clear.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmd_clear.Location = New System.Drawing.Point(116, 185)
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
        Me.lbl_selected_test.Size = New System.Drawing.Size(94, 13)
        Me.lbl_selected_test.TabIndex = 2
        Me.lbl_selected_test.Text = "0 Item(s) selected"
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
        Me.lb_testblocks.Size = New System.Drawing.Size(163, 160)
        Me.lb_testblocks.TabIndex = 1
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sb_status})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 484)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 17, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(373, 22)
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
        Me.cmd_krash.Location = New System.Drawing.Point(292, 459)
        Me.cmd_krash.Name = "cmd_krash"
        Me.cmd_krash.Size = New System.Drawing.Size(75, 22)
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
        Me.gb_jmp.Location = New System.Drawing.Point(7, 226)
        Me.gb_jmp.Name = "gb_jmp"
        Me.gb_jmp.Size = New System.Drawing.Size(360, 227)
        Me.gb_jmp.TabIndex = 4
        Me.gb_jmp.TabStop = False
        Me.gb_jmp.Text = "JMP"
        '
        'chk_jmp
        '
        Me.chk_jmp.AutoSize = True
        Me.chk_jmp.Checked = True
        Me.chk_jmp.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_jmp.Location = New System.Drawing.Point(7, 460)
        Me.chk_jmp.Name = "chk_jmp"
        Me.chk_jmp.Size = New System.Drawing.Size(80, 17)
        Me.chk_jmp.TabIndex = 5
        Me.chk_jmp.Text = "Enable JMP"
        Me.chk_jmp.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(373, 506)
        Me.Controls.Add(Me.chk_jmp)
        Me.Controls.Add(Me.gb_jmp)
        Me.Controls.Add(Me.cmd_krash)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.gb_testblocks)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Krash 0.0.1a"
        Me.GroupBox1.ResumeLayout(False)
        Me.gb_testblocks.ResumeLayout(False)
        Me.gb_testblocks.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
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

End Class
