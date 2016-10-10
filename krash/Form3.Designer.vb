<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_runscript
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_runscript))
        Me.gb_main = New System.Windows.Forms.GroupBox()
        Me.cmd_run_script = New System.Windows.Forms.Button()
        Me.lbl_version = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_description = New System.Windows.Forms.TextBox()
        Me.cmb_script = New System.Windows.Forms.ComboBox()
        Me.lbl_script = New System.Windows.Forms.Label()
        Me.gb_input = New System.Windows.Forms.GroupBox()
        Me.cmd_open = New System.Windows.Forms.Button()
        Me.lb_input_files = New System.Windows.Forms.ListBox()
        Me.gb_main.SuspendLayout()
        Me.gb_input.SuspendLayout()
        Me.SuspendLayout()
        '
        'gb_main
        '
        Me.gb_main.Controls.Add(Me.cmd_run_script)
        Me.gb_main.Controls.Add(Me.lbl_version)
        Me.gb_main.Controls.Add(Me.Label1)
        Me.gb_main.Controls.Add(Me.txt_description)
        Me.gb_main.Controls.Add(Me.cmb_script)
        Me.gb_main.Controls.Add(Me.lbl_script)
        Me.gb_main.Location = New System.Drawing.Point(9, 237)
        Me.gb_main.Name = "gb_main"
        Me.gb_main.Size = New System.Drawing.Size(480, 226)
        Me.gb_main.TabIndex = 0
        Me.gb_main.TabStop = False
        '
        'cmd_run_script
        '
        Me.cmd_run_script.Enabled = False
        Me.cmd_run_script.Location = New System.Drawing.Point(395, 195)
        Me.cmd_run_script.Name = "cmd_run_script"
        Me.cmd_run_script.Size = New System.Drawing.Size(75, 23)
        Me.cmd_run_script.TabIndex = 5
        Me.cmd_run_script.Text = "&Run"
        Me.cmd_run_script.UseVisualStyleBackColor = True
        '
        'lbl_version
        '
        Me.lbl_version.AutoSize = True
        Me.lbl_version.Location = New System.Drawing.Point(234, 17)
        Me.lbl_version.Name = "lbl_version"
        Me.lbl_version.Size = New System.Drawing.Size(0, 13)
        Me.lbl_version.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Description:"
        '
        'txt_description
        '
        Me.txt_description.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.txt_description.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_description.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_description.Location = New System.Drawing.Point(9, 66)
        Me.txt_description.Multiline = True
        Me.txt_description.Name = "txt_description"
        Me.txt_description.ReadOnly = True
        Me.txt_description.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txt_description.Size = New System.Drawing.Size(461, 123)
        Me.txt_description.TabIndex = 2
        '
        'cmb_script
        '
        Me.cmb_script.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_script.FormattingEnabled = True
        Me.cmb_script.Location = New System.Drawing.Point(88, 14)
        Me.cmb_script.Name = "cmb_script"
        Me.cmb_script.Size = New System.Drawing.Size(140, 21)
        Me.cmb_script.TabIndex = 1
        '
        'lbl_script
        '
        Me.lbl_script.AutoSize = True
        Me.lbl_script.Location = New System.Drawing.Point(6, 17)
        Me.lbl_script.Name = "lbl_script"
        Me.lbl_script.Size = New System.Drawing.Size(76, 13)
        Me.lbl_script.TabIndex = 0
        Me.lbl_script.Text = "Script to Run: "
        '
        'gb_input
        '
        Me.gb_input.Controls.Add(Me.cmd_open)
        Me.gb_input.Controls.Add(Me.lb_input_files)
        Me.gb_input.Location = New System.Drawing.Point(9, 12)
        Me.gb_input.Name = "gb_input"
        Me.gb_input.Size = New System.Drawing.Size(480, 219)
        Me.gb_input.TabIndex = 1
        Me.gb_input.TabStop = False
        Me.gb_input.Text = "Input Files"
        '
        'cmd_open
        '
        Me.cmd_open.Location = New System.Drawing.Point(395, 187)
        Me.cmd_open.Name = "cmd_open"
        Me.cmd_open.Size = New System.Drawing.Size(75, 23)
        Me.cmd_open.TabIndex = 6
        Me.cmd_open.Text = "&Open"
        Me.cmd_open.UseVisualStyleBackColor = True
        '
        'lb_input_files
        '
        Me.lb_input_files.FormattingEnabled = True
        Me.lb_input_files.Location = New System.Drawing.Point(9, 21)
        Me.lb_input_files.Name = "lb_input_files"
        Me.lb_input_files.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
        Me.lb_input_files.Size = New System.Drawing.Size(461, 160)
        Me.lb_input_files.TabIndex = 0
        '
        'frm_runscript
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(501, 473)
        Me.Controls.Add(Me.gb_input)
        Me.Controls.Add(Me.gb_main)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_runscript"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Run Script"
        Me.gb_main.ResumeLayout(False)
        Me.gb_main.PerformLayout()
        Me.gb_input.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gb_main As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_description As System.Windows.Forms.TextBox
    Friend WithEvents cmb_script As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_script As System.Windows.Forms.Label
    Friend WithEvents lbl_version As System.Windows.Forms.Label
    Friend WithEvents gb_input As System.Windows.Forms.GroupBox
    Friend WithEvents cmd_run_script As System.Windows.Forms.Button
    Friend WithEvents cmd_open As System.Windows.Forms.Button
    Friend WithEvents lb_input_files As System.Windows.Forms.ListBox
End Class
