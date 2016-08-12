Public Class Form1
    Dim g_test_blocks As New Hashtable()
    Dim g_krash_test_blocks As New Hashtable()

    Dim g_krashed_input_files As New List(Of String)

    Dim g_input_files As New Hashtable()
    Dim g_input_files_testblocks As New Hashtable
    Dim g_input_files_wafers As New Hashtable

    Dim g_curr_input_files As New Hashtable()
    Dim g_curr_filelength As Long
    Dim g_byteread As Long
    Dim g_curr_selected_test As String = ""
    Dim g_wafers_list As New List(Of String)
    Dim g_wafer_def As New Hashtable()

    Dim g_lot As String
    Dim g_wafer As String
    Dim g_reticle As String
    Dim g_die_x As String
    Dim g_die_y As String
    Dim g_temp As String
    Dim g_test_header As String
    Dim g_supplies As String

    Dim g_overwrite As Boolean = True
    Public Sub reset_roles()
        lb_groupby.Items.Clear()
        lb_legend.Items.Clear()
        lb_yvalue.Items.Clear()
        lb_xfactor.Items.Clear()
        cmb_ymultiplier.SelectedIndex = 0
        chk_tabulate.Checked = False
    End Sub

    Public Sub reset_reflines()
        cmb_ref_axis.SelectedIndex = 0
        txt_ref_value.Text = ""
        txt_ref_label.Text = ""
        pic_ref_color.BackColor = Color.FromArgb(0, 128, 255)
        num_line_width.Value = 1
        lv_refcolor.Items.Clear()
    End Sub

    Public Sub reset_axis()
        cmb_xscale.SelectedIndex = 0
        cmb_yscale.SelectedIndex = 0
        txt_xbase_power.Text = ""
        txt_ybase_power.Text = ""
        txt_xbase_power.Enabled = False
        txt_ybase_power.Enabled = False
        txt_xmaximum.Text = ""
        txt_ymaximum.Text = ""
        txt_xminimum.Text = ""
        txt_yminimum.Text = ""
        txt_xincrement.Text = ""
        txt_yincrement.Text = ""

        chk_xmajor.Checked = True
        chk_ymajor.Checked = True

        chk_xminor.Checked = False
        chk_yminor.Checked = False
    End Sub
    Public Sub reset_jmp_settings()
        reset_roles()
        reset_axis()
        reset_reflines()
    End Sub

    Private Sub cmd_addinput_Click(sender As Object, e As EventArgs) Handles cmd_addinput.Click
        Dim dg_open As New OpenFileDialog
        dg_open.Multiselect = True
        dg_open.Filter = "Datalog files (*.datalog)|*.datalog|Raw files (*.raw)|*.raw|All files (*.*)|*.*"
        If (dg_open.ShowDialog() = Windows.Forms.DialogResult.Cancel) Then
            Exit Sub
        End If
        g_curr_input_files.Clear()
        For Each file As String In dg_open.FileNames
            Dim m_key As String = System.IO.Path.GetFileName(file)
            If Not g_input_files.ContainsValue(file) Then
                lb_inputs.Items.Add(m_key)
                g_input_files.Add(m_key, file)
                g_curr_input_files.Add(m_key, file)
            End If
        Next


        gb_inputfiles.Enabled = False
        gb_jmp.Enabled = False
        gb_testblocks.Enabled = False
        cmd_krash.Enabled = False
        sb_menu.Enabled = False

        bw_extracttests.RunWorkerAsync()
    End Sub

    Private Sub cmd_removeinput_Click(sender As Object, e As EventArgs) Handles cmd_removeinput.Click


        Do While (lb_inputs.SelectedItems.Count > 0)
            g_input_files.Remove(lb_inputs.SelectedItem.ToString)
            lb_inputs.Items.Remove(lb_inputs.SelectedItem)
        Loop

        'Update testblocks available for krash
        lb_testblocks.Items.Clear()
        Dim keys_to_remove As New List(Of String)
        For Each item As DictionaryEntry In g_input_files_testblocks

            Dim m_item As String = item.Key
            If lb_inputs.Items.Contains((m_item.Split("@"))(0)) Then


                Dim m_testblock As String = (m_item.Split("@"))(1)
                If Not lb_testblocks.Items.Contains(m_testblock) Then
                    lb_testblocks.Items.Add(m_testblock)
                End If
            Else
                keys_to_remove.Add(m_item)
            End If
        Next

        For Each m_string As String In keys_to_remove
            g_input_files_testblocks.Remove(m_string)
        Next
        lb_testblocks.Sorted = True
        lb_header_list.Items.Clear()
        lbl_selected_test.Text = lb_testblocks.SelectedItems.Count & " selected"
    End Sub



    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If (bw_extracttests.IsBusy) Then
            bw_extracttests.CancelAsync()
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        reset_jmp_settings()
    End Sub

    Private Sub bw_extracttests_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bw_extracttests.DoWork
        'For Each file As String In g_input_files
        g_wafers_list.Clear()
        For Each file As DictionaryEntry In g_curr_input_files

            If System.IO.File.Exists(file.Value) = True Then
                g_curr_filelength = New System.IO.FileInfo(file.Value).Length
                g_byteread = 0

                Dim modulo As Long
                Dim objReader As New System.IO.StreamReader(file.Value.ToString)
                Dim strLine As String
                Do While objReader.Peek() <> -1
                    If (bw_extracttests.CancellationPending = True) Then
                        e.Cancel = True
                        Exit Sub
                    End If
                    strLine = objReader.ReadLine()
                    If strLine.Length < 1 Then
                        Continue Do
                    End If
                    Dim firstword As String
                    firstword = (strLine.Split(" "))(0)
                    If InStr(strLine, "#LOT", CompareMethod.Binary) = 1 Then
                        g_lot = (strLine.Split(" "))(1)
                    ElseIf InStr(strLine, "#WAFER", CompareMethod.Binary) = 1 Then
                        Dim m_wafer As String = (strLine.Split(" "))(1)
                        g_wafer = UCase$(g_lot & "-" & m_wafer)
                        If (Not g_wafers_list.Contains(g_wafer)) Then
                            g_wafers_list.Add(UCase$(g_wafer))
                        End If
                    ElseIf InStr(strLine, "#SUPPLIES", CompareMethod.Binary) = 1 Then
                        g_supplies = (strLine.Split(" "))(1)
                    ElseIf InStr(strLine, "TNAME", CompareMethod.Binary) = 1 Then
                        g_test_header = strLine
                        If InStr(g_test_header, "SUPPLIES", CompareMethod.Binary) > 0 Then
                            If g_supplies <> "" Then
                                g_test_header = g_test_header.Replace("SUPPLIES", g_supplies.Replace(",", " ").Trim())
                            End If
                        End If
                    ElseIf (String.Compare(firstword, "TNAME") And String.Compare(firstword.Substring(0, 1), "#")) Then
                        If (Not g_test_blocks.ContainsKey(firstword)) Then
                            g_test_blocks.Add(firstword, g_test_header)
                        End If

                        If (Not g_input_files_testblocks.ContainsKey(file.Key & "@" & firstword)) Then
                            g_input_files_testblocks.Add(file.Key & "@" & firstword, "")
                        End If
                    End If
                    g_byteread += (strLine.Length + 2)

                    If (modulo Mod 1024 = 0) Then
                        bw_extracttests.ReportProgress(Convert.ToInt32((g_byteread / g_curr_filelength) * 100))
                        modulo = 0
                    End If
                    modulo += 1
                Loop

                objReader.Close()
            End If
        Next

    End Sub

    Private Sub bw_extracttests_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles bw_extracttests.ProgressChanged
        sb_status.Text = "Status: Reading input file(s) - " & e.ProgressPercentage & "%"

    End Sub

    Private Sub bw_extracttests_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bw_extracttests.RunWorkerCompleted
        lb_testblocks.Items.Clear()
        Dim keys As New List(Of String)
        keys.AddRange(From i As String In g_test_blocks.Keys)
        keys.Sort()
        For Each k In keys
            lb_testblocks.Items.Add(k)
        Next k
        sb_status.Text = "Status: Idle/Ready"

        'Enable Controls
        gb_inputfiles.Enabled = True
        gb_jmp.Enabled = True
        gb_testblocks.Enabled = True
        cmd_krash.Enabled = True
        sb_menu.Enabled = True

        'Fill wafer list
        For Each i As String In g_wafers_list
            If Not cmb_wafers.Items.Contains(i) Then
                cmb_wafers.Items.Add(i)
                g_wafer_def.Add(i, "")
            End If
        Next
        lbl_selected_test.Text = lb_testblocks.SelectedItems.Count & " selected"
    End Sub

    Private Sub cmd_clear_Click(sender As Object, e As EventArgs) Handles cmd_clear.Click
        lb_testblocks.SelectedItems.Clear()
        lb_header_list.Items.Clear()
        reset_jmp_settings()
    End Sub



 

    Private Sub lb_testblocks_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lb_testblocks.SelectedIndexChanged
        lbl_selected_test.Text = lb_testblocks.SelectedItems.Count & " selected"

        If g_curr_selected_test <> lb_testblocks.SelectedItem And sb_menu_enable_jmp.Checked Then
            g_curr_selected_test = lb_testblocks.SelectedItem

            If g_test_blocks.ContainsKey(lb_testblocks.Text) = True Then
                lb_header_list.Items.Clear()
                If IsNothing(g_test_blocks(lb_testblocks.Text)) = False Then
                    lb_header_list.Items.AddRange(Split("LOT WAFER RETICLE DIE_X DIE_Y TEMP " & g_test_blocks(lb_testblocks.Text).Trim(), " "))
                End If

            End If
        End If
        g_krash_test_blocks.Clear()

        For i = 0 To lb_testblocks.SelectedItems.Count - 1
            If Not g_krash_test_blocks.ContainsKey(lb_testblocks.SelectedItems(i)) Then
                g_krash_test_blocks.Add(lb_testblocks.SelectedItems(i), "1")
            End If
        Next
    End Sub

    Private Sub cmd_krash_Click(sender As Object, e As EventArgs) Handles cmd_krash.Click
        'Error Checks
        If g_input_files.Count = 0 Then
            'MsgBox("Add input file(s) to krash", vbExclamation + vbOKOnly, "Error")
            cmd_addinput.Focus()
            tool_tip.Show("Click this button to add input files", cmd_addinput, 0, cmd_addinput.Height, 2500)
            Exit Sub
        End If

        If lb_testblocks.Text = "" Then
            'MsgBox("Select test block to krash", vbExclamation + vbOKOnly, "Error")
            tool_tip.Show("Select test block to krash", lb_testblocks, 0, lb_testblocks.Height, 2500)
            Exit Sub
        End If

        If sb_menu_enable_jmp.Checked = True And (cmb_jmp_script.Text = "" Or cmb_jmp_script.SelectedIndex = 0) Then
            'MsgBox("Select JMP script from the pull down menu", vbExclamation + vbOKOnly, "Error")
            tool_tip.Show("Select JMP script from the pull down menu", cmb_jmp_script, 0, cmb_jmp_script.Height, 2500)
            cmb_jmp_script.Focus()
            Exit Sub
        End If

        If cmb_xscale.SelectedIndex > 0 And txt_xbase_power.Text = "" Then
            MsgBox("Base/Power can not be empty when scale is Log or Power", vbExclamation + vbOKOnly, "Error")
            txt_xbase_power.Focus()
            Exit Sub
        End If

        If cmb_yscale.SelectedIndex > 0 And txt_ybase_power.Text = "" Then
            MsgBox("Base/Power can not be empty when scale is Log or Power", vbExclamation + vbOKOnly, "Error")
            txt_ybase_power.Focus()
            Exit Sub
        End If

        If cmb_jmp_script.Text = "Fit Y by X" Then
            If lb_yvalue.Items.Count = 0 Or lb_xfactor.Items.Count = 0 Then
                MsgBox("Both Y Response and X Factor are required", vbExclamation + vbOKOnly, "Error")
                Exit Sub
            End If
        ElseIf cmb_jmp_script.Text = "Distribution" Then
            If lb_yvalue.Items.Count = 0 Then
                MsgBox("Y Value is required", vbExclamation + vbOKOnly, "Error")
                Exit Sub
            End If
        ElseIf cmb_jmp_script.Text = "Contour Plot" Then
            If lb_yvalue.Items.Count = 0 Then
                MsgBox("Y Value is required", vbExclamation + vbOKOnly, "Error")
                Exit Sub
            End If
            If lb_xfactor.Items.Count < 2 Then
                MsgBox("Two x factors are required required", vbExclamation + vbOKOnly, "Error")
                Exit Sub
            End If
        End If


        gb_testblocks.Enabled = False
        gb_jmp.Enabled = False
        gb_inputfiles.Enabled = False
        cmd_krash.Enabled = False
        sb_menu.Enabled = False

        bw_krash.RunWorkerAsync()
        While (bw_krash.IsBusy)
            Application.DoEvents()
        End While

        If sb_menu_enable_jmp.Checked = True Then
            For Each i As String In g_krashed_input_files
                If cmb_jmp_script.SelectedIndex = 0 Then
                    Continue For
                End If
                Dim objWriter As New System.IO.StreamWriter(Application.StartupPath & "\temp.jsl", False)
                objWriter.AutoFlush = True
                If (cmb_jmp_script.Text = "Distribution") Then
                    objWriter.WriteLine("//!")
                    objWriter.WriteLine("open(""" & i & """);")

                    'Multiply Y Value
                    For x As Integer = 0 To lb_yvalue.Items.Count - 1
                        If cmb_ymultiplier.SelectedIndex = 1 Then
                            objWriter.WriteLine("column(""" & lb_yvalue.Items(x) & """)<<Set Values(Multiply(1000,column(""" & lb_yvalue.Items(x) & """)<<Get As Matrix));")
                        ElseIf cmb_ymultiplier.SelectedIndex = 2 Then
                            objWriter.WriteLine("column(""" & lb_yvalue.Items(x) & """)<<Set Values(Multiply(1000000,column(""" & lb_yvalue.Items(x) & """)<<Get As Matrix));")
                        ElseIf cmb_ymultiplier.SelectedIndex = 3 Then
                            objWriter.WriteLine("column(""" & lb_yvalue.Items(x) & """)<<Set Values(Log(column(""" & lb_yvalue.Items(x) & """)<<Get As Matrix),10);")
                        ElseIf cmb_ymultiplier.SelectedIndex = 4 Then
                            objWriter.WriteLine("column(""" & lb_yvalue.Items(x) & """)<<Set Values(Multiply(1000,column(""" & lb_yvalue.Items(x) & """)<<Get As Matrix));")
                            objWriter.WriteLine("column(""" & lb_yvalue.Items(x) & """)<<Set Values(Log(column(""" & lb_yvalue.Items(x) & """)<<Get As Matrix),10);")
                        ElseIf cmb_ymultiplier.SelectedIndex = 5 Then
                            objWriter.WriteLine("column(""" & lb_yvalue.Items(x) & """)<<Set Values(Multiply(1000000,column(""" & lb_yvalue.Items(x) & """)<<Get As Matrix));")
                            objWriter.WriteLine("column(""" & lb_yvalue.Items(x) & """)<<Set Values(Log(column(""" & lb_yvalue.Items(x) & """)<<Get As Matrix),10);")
                        End If
                    Next

                    objWriter.WriteLine("Distribution(")
                    objWriter.WriteLine("    Continuous Distribution(")
                    objWriter.WriteLine("        Column( :" & lb_yvalue.Items(0) & " ),")
                    objWriter.WriteLine("        Horizontal Layout( 0 ),")
                    objWriter.WriteLine("        Fit Distribution(Normal),")
                    objWriter.WriteLine("        Vertical( 0 ),")
                    objWriter.WriteLine("        SendToReport(")

                    'X Axis settings
                    objWriter.WriteLine("        Dispatch({},""1"",ScaleBox,{")

                    If cmb_xscale.Text = "Log" Then
                        objWriter.WriteLine("            ,Scale( ""Log"", {Log Base(" & txt_xbase_power.Text & ")} )")
                    ElseIf cmb_xscale.Text = "Power" Then
                        objWriter.WriteLine("            ,Scale( ""Power"", {Power(" & txt_xbase_power.Text & ")} )")
                    End If

                    If txt_xmaximum.Text.Length > 0 Then
                        objWriter.WriteLine("            ,Max(  " & txt_xmaximum.Text & " )")
                    End If

                    If txt_xminimum.Text.Length > 0 Then
                        objWriter.WriteLine("            ,Min(  " & txt_xminimum.Text & " )")
                    End If

                    If txt_xincrement.Text.Length > 0 Then
                        objWriter.WriteLine("            ,Inc(  " & txt_xincrement.Text & " )")
                    End If

                    If chk_xmajor.Checked = True Then
                        objWriter.WriteLine("            ,Show Major Grid( 1 )")
                    End If

                    If chk_xminor.Checked = True Then
                        objWriter.WriteLine("            ,Show Minor Grid( 1 )")
                    End If

                    For Each item As ListViewItem In lv_refcolor.Items
                        If (item.SubItems(0).Text).Substring(0, 1) = "X" Then
                            Dim StringItem As String = item.SubItems(1).Text
                            StringItem = StringItem.Replace("(", " ")
                            StringItem = StringItem.Replace(")", " ")
                            StringItem = StringItem.Replace("X:", "@")
                            objWriter.WriteLine("            ,Add Ref Line( " & (StringItem.Split("@"))(1) & " , Dashed, {" & item.SubItems(2).ForeColor.R & "," & item.SubItems(2).ForeColor.G & "," & item.SubItems(2).ForeColor.B & "}, " & """" & (StringItem.Split("@"))(0) & """, " & item.SubItems(3).Text & ")")
                        End If
                    Next

                    objWriter.WriteLine("        }),")

                    'Y Axis settings
                    objWriter.WriteLine("        Dispatch({},""2"",ScaleBox,{")

                    If cmb_yscale.Text = "Log" Then
                        objWriter.WriteLine("            ,Scale( ""Log"", {Log Base(" & txt_ybase_power.Text & ")} )")
                    ElseIf cmb_yscale.Text = "Power" Then
                        objWriter.WriteLine("            ,Scale( ""Power"", {Power(" & txt_ybase_power.Text & ")} )")
                    End If

                    If txt_ymaximum.Text.Length > 0 Then
                        objWriter.WriteLine("            ,Max(  " & txt_ymaximum.Text & " )")
                    End If

                    If txt_yminimum.Text.Length > 0 Then
                        objWriter.WriteLine("            ,Min(  " & txt_yminimum.Text & " )")
                    End If

                    If txt_yincrement.Text.Length > 0 Then
                        objWriter.WriteLine("            ,Inc(  " & txt_yincrement.Text & " )")
                    End If

                    If chk_ymajor.Checked = True Then
                        objWriter.WriteLine("            ,Show Major Grid( 1 )")
                    End If

                    If chk_yminor.Checked = True Then
                        objWriter.WriteLine("            ,Show Minor Grid( 1 )")
                    End If

                    For Each item As ListViewItem In lv_refcolor.Items
                        If (item.SubItems(0).Text).Substring(0, 1) = "Y" Then
                            Dim StringItem As String = item.SubItems(1).Text
                            StringItem = StringItem.Replace("(", " ")
                            StringItem = StringItem.Replace(")", " ")
                            StringItem = StringItem.Replace("Y:", "@")
                            objWriter.WriteLine("            ,Add Ref Line( " & (StringItem.Split("@"))(1) & " , Dashed, {" & item.SubItems(2).ForeColor.R & "," & item.SubItems(2).ForeColor.G & "," & item.SubItems(2).ForeColor.B & "}, " & """" & (StringItem.Split("@"))(0) & """, " & item.SubItems(3).Text & ")")
                        End If
                    Next

                    objWriter.WriteLine("        }),")

                    'Set Frame Size
                    objWriter.WriteLine("            Dispatch(")
                    objWriter.WriteLine("                {},")
                    objWriter.WriteLine("                ""Distrib Histogram"",")
                    objWriter.WriteLine("                FrameBox,")
                    objWriter.WriteLine("                {Frame Size( 378, 201 )}")
                    objWriter.WriteLine("            )")

                    objWriter.WriteLine("        )")
                    objWriter.WriteLine("    ),")
                    objWriter.Write("    By( ")
                    For x As Integer = 0 To lb_groupby.Items.Count - 1
                        objWriter.Write(" :" & lb_groupby.Items(x) & ", ")
                    Next
                    objWriter.WriteLine(" ),")
                    objWriter.WriteLine("    Stack( 1 )")
                    objWriter.WriteLine(");")
                ElseIf (cmb_jmp_script.Text = "Fit Y by X") Then
                    objWriter.WriteLine("//!")
                    objWriter.WriteLine("open(""" & i & """);")

                    'Multiply Y Value
                    For x As Integer = 0 To lb_yvalue.Items.Count - 1
                        If cmb_ymultiplier.SelectedIndex = 1 Then
                            objWriter.WriteLine("column(""" & lb_yvalue.Items(x) & """)<<Set Values(Multiply(1000,column(""" & lb_yvalue.Items(x) & """)<<Get As Matrix));")
                        ElseIf cmb_ymultiplier.SelectedIndex = 2 Then
                            objWriter.WriteLine("column(""" & lb_yvalue.Items(x) & """)<<Set Values(Multiply(1000000,column(""" & lb_yvalue.Items(x) & """)<<Get As Matrix));")
                        ElseIf cmb_ymultiplier.SelectedIndex = 3 Then
                            objWriter.WriteLine("column(""" & lb_yvalue.Items(x) & """)<<Set Values(Log(column(""" & lb_yvalue.Items(x) & """)<<Get As Matrix),10);")
                        ElseIf cmb_ymultiplier.SelectedIndex = 4 Then
                            objWriter.WriteLine("column(""" & lb_yvalue.Items(x) & """)<<Set Values(Multiply(1000,column(""" & lb_yvalue.Items(x) & """)<<Get As Matrix));")
                            objWriter.WriteLine("column(""" & lb_yvalue.Items(x) & """)<<Set Values(Log(column(""" & lb_yvalue.Items(x) & """)<<Get As Matrix),10);")
                        ElseIf cmb_ymultiplier.SelectedIndex = 5 Then
                            objWriter.WriteLine("column(""" & lb_yvalue.Items(x) & """)<<Set Values(Multiply(1000000,column(""" & lb_yvalue.Items(x) & """)<<Get As Matrix));")
                            objWriter.WriteLine("column(""" & lb_yvalue.Items(x) & """)<<Set Values(Log(column(""" & lb_yvalue.Items(x) & """)<<Get As Matrix),10);")
                        End If
                    Next


                    objWriter.Write("Bivariate( ")

                    'Insert Y Values
                    objWriter.Write("Y( ")
                    For x As Integer = 0 To lb_yvalue.Items.Count - 1
                        objWriter.Write(" :" & lb_yvalue.Items(x) & ", ")
                    Next
                    objWriter.WriteLine(" ),")

                    'Insert X Factor
                    objWriter.Write("X( ")
                    For x As Integer = 0 To lb_xfactor.Items.Count - 1
                        objWriter.Write(" :" & lb_xfactor.Items(x) & ", ")
                    Next
                    objWriter.WriteLine(" ),")

                    'Insert Group By
                    objWriter.Write("By( ")
                    For x As Integer = 0 To lb_groupby.Items.Count - 1
                        objWriter.Write(" :" & lb_groupby.Items(x) & ", ")
                    Next
                    objWriter.WriteLine(" ),")

                    'Set Y Axis TexT
                    objWriter.WriteLine("    SendToReport(")
                    objWriter.WriteLine("        Dispatch( {},""" & lb_yvalue.Items(0).ToString & """,TextEditBox,{Set Text( """ & UCase(System.IO.Path.GetFileNameWithoutExtension(i).Replace("krash_", "")) & """ )}),")

                    'X Axis settings
                    objWriter.WriteLine("        Dispatch({},""1"",ScaleBox,{")

                    If cmb_xscale.Text = "Log" Then
                        objWriter.WriteLine("            ,Scale( ""Log"", {Log Base(" & txt_xbase_power.Text & ")} )")
                    ElseIf cmb_xscale.Text = "Power" Then
                        objWriter.WriteLine("            ,Scale( ""Power"", {Power(" & txt_xbase_power.Text & ")} )")
                    End If

                    If txt_xmaximum.Text.Length > 0 Then
                        objWriter.WriteLine("            ,Max(  " & txt_xmaximum.Text & " )")
                    End If

                    If txt_xminimum.Text.Length > 0 Then
                        objWriter.WriteLine("            ,Min(  " & txt_xminimum.Text & " )")
                    End If

                    If txt_xincrement.Text.Length > 0 Then
                        objWriter.WriteLine("            ,Inc(  " & txt_xincrement.Text & " )")
                    End If

                    If chk_xmajor.Checked = True Then
                        objWriter.WriteLine("            ,Show Major Grid( 1 )")
                    End If

                    If chk_xminor.Checked = True Then
                        objWriter.WriteLine("            ,Show Minor Grid( 1 )")
                    End If

                    For Each item As ListViewItem In lv_refcolor.Items
                        If (item.SubItems(0).Text).Substring(0, 1) = "X" Then
                            Dim StringItem As String = item.SubItems(1).Text
                            StringItem = StringItem.Replace("(", " ")
                            StringItem = StringItem.Replace(")", " ")
                            StringItem = StringItem.Replace("X:", "@")
                            objWriter.WriteLine("            ,Add Ref Line( " & (StringItem.Split("@"))(1) & " , Dashed, {" & item.SubItems(2).ForeColor.R & "," & item.SubItems(2).ForeColor.G & "," & item.SubItems(2).ForeColor.B & "}, " & """" & (StringItem.Split("@"))(0) & """, " & item.SubItems(3).Text & ")")
                        End If
                    Next

                    objWriter.WriteLine("        }),")

                    'Y Axis settings
                    objWriter.WriteLine("        Dispatch({},""2"",ScaleBox,{")

                    If cmb_yscale.Text = "Log" Then
                        objWriter.WriteLine("            ,Scale( ""Log"", {Log Base(" & txt_ybase_power.Text & ")} )")
                    ElseIf cmb_yscale.Text = "Power" Then
                        objWriter.WriteLine("            ,Scale( ""Power"", {Power(" & txt_ybase_power.Text & ")} )")
                    End If

                    If txt_ymaximum.Text.Length > 0 Then
                        objWriter.WriteLine("            ,Max(  " & txt_ymaximum.Text & " )")
                    End If

                    If txt_yminimum.Text.Length > 0 Then
                        objWriter.WriteLine("            ,Min(  " & txt_yminimum.Text & " )")
                    End If

                    If txt_yincrement.Text.Length > 0 Then
                        objWriter.WriteLine("            ,Inc(  " & txt_yincrement.Text & " )")
                    End If

                    If chk_ymajor.Checked = True Then
                        objWriter.WriteLine("            ,Show Major Grid( 1 )")
                    End If

                    If chk_yminor.Checked = True Then
                        objWriter.WriteLine("            ,Show Minor Grid( 1 )")
                    End If

                    For Each item As ListViewItem In lv_refcolor.Items
                        If (item.SubItems(0).Text).Substring(0, 1) = "Y" Then
                            Dim StringItem As String = item.SubItems(1).Text
                            StringItem = StringItem.Replace("(", " ")
                            StringItem = StringItem.Replace(")", " ")
                            StringItem = StringItem.Replace("Y:", "@")
                            objWriter.WriteLine("            ,Add Ref Line( " & (StringItem.Split("@"))(1) & " , Dashed, {" & item.SubItems(2).ForeColor.R & "," & item.SubItems(2).ForeColor.G & "," & item.SubItems(2).ForeColor.B & "}, " & """" & (StringItem.Split("@"))(0) & """, " & item.SubItems(3).Text & ")")
                        End If
                    Next

                    objWriter.WriteLine("        }),")

                    'Insert Legend 
                    If lb_legend.Items.Count > 0 Then
                        objWriter.WriteLine("        Dispatch( {}, ""Bivar Plot"", FrameBox,")
                        objWriter.WriteLine("            {Row Legend(")
                        objWriter.WriteLine("                " & lb_legend.Items(0).ToString & " ,")
                        objWriter.WriteLine("                Color( 1 ),")
                        objWriter.WriteLine("                Color Theme( ""JMP Default"" )")
                        objWriter.WriteLine("            )}")
                        objWriter.WriteLine("        )")
                    End If

                    objWriter.WriteLine("    )")
                    objWriter.WriteLine(");")
                ElseIf (cmb_jmp_script.Text = "Contour Plot") Then
                    objWriter.WriteLine("//!")
                    objWriter.WriteLine("open(""" & i & """);")

                    'Multiply Y Value
                    For x As Integer = 0 To lb_yvalue.Items.Count - 1
                        If cmb_ymultiplier.SelectedIndex = 1 Then
                            objWriter.WriteLine("column(""" & lb_yvalue.Items(x) & """)<<Set Values(Multiply(1000,column(""" & lb_yvalue.Items(x) & """)<<Get As Matrix));")
                        ElseIf cmb_ymultiplier.SelectedIndex = 2 Then
                            objWriter.WriteLine("column(""" & lb_yvalue.Items(x) & """)<<Set Values(Multiply(1000000,column(""" & lb_yvalue.Items(x) & """)<<Get As Matrix));")
                        ElseIf cmb_ymultiplier.SelectedIndex = 3 Then
                            objWriter.WriteLine("column(""" & lb_yvalue.Items(x) & """)<<Set Values(Log(column(""" & lb_yvalue.Items(x) & """)<<Get As Matrix),10);")
                        ElseIf cmb_ymultiplier.SelectedIndex = 4 Then
                            objWriter.WriteLine("column(""" & lb_yvalue.Items(x) & """)<<Set Values(Multiply(1000,column(""" & lb_yvalue.Items(x) & """)<<Get As Matrix));")
                            objWriter.WriteLine("column(""" & lb_yvalue.Items(x) & """)<<Set Values(Log(column(""" & lb_yvalue.Items(x) & """)<<Get As Matrix),10);")
                        ElseIf cmb_ymultiplier.SelectedIndex = 5 Then
                            objWriter.WriteLine("column(""" & lb_yvalue.Items(x) & """)<<Set Values(Multiply(1000000,column(""" & lb_yvalue.Items(x) & """)<<Get As Matrix));")
                            objWriter.WriteLine("column(""" & lb_yvalue.Items(x) & """)<<Set Values(Log(column(""" & lb_yvalue.Items(x) & """)<<Get As Matrix),10);")
                        End If
                    Next

                    objWriter.WriteLine("Contour Plot(")
                    'Insert X Factor
                    objWriter.Write("X( ")
                    For x As Integer = 0 To lb_xfactor.Items.Count - 1
                        objWriter.Write(" :" & lb_xfactor.Items(x) & ", ")
                    Next
                    objWriter.WriteLine(" ),")

                    'Insert Y Values
                    objWriter.Write("Y( ")
                    For x As Integer = 0 To lb_yvalue.Items.Count - 1
                        objWriter.Write(" :" & lb_yvalue.Items(x) & ", ")
                    Next
                    objWriter.WriteLine(" ),")

                    'Insert Group By
                    objWriter.Write("By( ")
                    For x As Integer = 0 To lb_groupby.Items.Count - 1
                        objWriter.Write(" :" & lb_groupby.Items(x) & ", ")
                    Next
                    objWriter.WriteLine(" ),")

                    

                    objWriter.WriteLine("Fill Areas( 1 ),")
                    objWriter.WriteLine("Color Theme( ""Jet"" )")
                    objWriter.WriteLine(");")
                ElseIf (cmb_jmp_script.Text = "Overlay Plot") Then
                    objWriter.WriteLine("//!")
                    objWriter.WriteLine("open(""" & i & """);")

                    'Multiply Y Value
                    For x As Integer = 0 To lb_yvalue.Items.Count - 1
                        If cmb_ymultiplier.SelectedIndex = 1 Then
                            objWriter.WriteLine("column(""" & lb_yvalue.Items(x) & """)<<Set Values(Multiply(1000,column(""" & lb_yvalue.Items(x) & """)<<Get As Matrix));")
                        ElseIf cmb_ymultiplier.SelectedIndex = 2 Then
                            objWriter.WriteLine("column(""" & lb_yvalue.Items(x) & """)<<Set Values(Multiply(1000000,column(""" & lb_yvalue.Items(x) & """)<<Get As Matrix));")
                        ElseIf cmb_ymultiplier.SelectedIndex = 3 Then
                            objWriter.WriteLine("column(""" & lb_yvalue.Items(x) & """)<<Set Values(Log(column(""" & lb_yvalue.Items(x) & """)<<Get As Matrix),10);")
                        ElseIf cmb_ymultiplier.SelectedIndex = 4 Then
                            objWriter.WriteLine("column(""" & lb_yvalue.Items(x) & """)<<Set Values(Multiply(1000,column(""" & lb_yvalue.Items(x) & """)<<Get As Matrix));")
                            objWriter.WriteLine("column(""" & lb_yvalue.Items(x) & """)<<Set Values(Log(column(""" & lb_yvalue.Items(x) & """)<<Get As Matrix),10);")
                        ElseIf cmb_ymultiplier.SelectedIndex = 5 Then
                            objWriter.WriteLine("column(""" & lb_yvalue.Items(x) & """)<<Set Values(Multiply(1000000,column(""" & lb_yvalue.Items(x) & """)<<Get As Matrix));")
                            objWriter.WriteLine("column(""" & lb_yvalue.Items(x) & """)<<Set Values(Log(column(""" & lb_yvalue.Items(x) & """)<<Get As Matrix),10);")
                        End If
                    Next

                    objWriter.WriteLine("Overlay Plot(")
                    'Insert X Factor
                    objWriter.Write("X( ")
                    For x As Integer = 0 To lb_xfactor.Items.Count - 1
                        objWriter.Write(" :" & lb_xfactor.Items(x) & ", ")
                    Next
                    objWriter.WriteLine(" ),")

                    'Insert Y Values
                    objWriter.Write("Y( ")
                    For x As Integer = 0 To lb_yvalue.Items.Count - 1
                        objWriter.Write(" :" & lb_yvalue.Items(x) & ", ")
                    Next
                    objWriter.WriteLine(" ),")

                    'Insert Group By
                    objWriter.Write("By( ")
                    For x As Integer = 0 To lb_groupby.Items.Count - 1
                        objWriter.Write(" :" & lb_groupby.Items(x) & ", ")
                    Next
                    objWriter.WriteLine(" ),")

                    objWriter.WriteLine("SendToReport(")

                    'X Axis settings
                    objWriter.WriteLine("        Dispatch({},""101"",ScaleBox,{")

                    If cmb_xscale.Text = "Log" Then
                        objWriter.WriteLine("            ,Scale( ""Log"", {Log Base(" & txt_xbase_power.Text & ")} )")
                    ElseIf cmb_xscale.Text = "Power" Then
                        objWriter.WriteLine("            ,Scale( ""Power"", {Power(" & txt_xbase_power.Text & ")} )")
                    End If

                    If txt_xmaximum.Text.Length > 0 Then
                        objWriter.WriteLine("            ,Max(  " & txt_xmaximum.Text & " )")
                    End If

                    If txt_xminimum.Text.Length > 0 Then
                        objWriter.WriteLine("            ,Min(  " & txt_xminimum.Text & " )")
                    End If

                    If txt_xincrement.Text.Length > 0 Then
                        objWriter.WriteLine("            ,Inc(  " & txt_xincrement.Text & " )")
                    End If

                    If chk_xmajor.Checked = True Then
                        objWriter.WriteLine("            ,Show Major Grid( 1 )")
                    End If

                    If chk_xminor.Checked = True Then
                        objWriter.WriteLine("            ,Show Minor Grid( 1 )")
                    End If

                    For Each item As ListViewItem In lv_refcolor.Items
                        If (item.SubItems(0).Text).Substring(0, 1) = "X" Then
                            Dim StringItem As String = item.SubItems(1).Text
                            StringItem = StringItem.Replace("(", " ")
                            StringItem = StringItem.Replace(")", " ")
                            StringItem = StringItem.Replace("X:", "@")
                            objWriter.WriteLine("            ,Add Ref Line( " & (StringItem.Split("@"))(1) & " , Dashed, {" & item.SubItems(2).ForeColor.R & "," & item.SubItems(2).ForeColor.G & "," & item.SubItems(2).ForeColor.B & "}, " & """" & (StringItem.Split("@"))(0) & """, " & item.SubItems(3).Text & ")")
                        End If
                    Next

                    objWriter.WriteLine("        }),")

                    'Y Axis settings
                    objWriter.WriteLine("        Dispatch({},""106"",ScaleBox,{")

                    If cmb_yscale.Text = "Log" Then
                        objWriter.WriteLine("            ,Scale( ""Log"", {Log Base(" & txt_ybase_power.Text & ")} )")
                    ElseIf cmb_yscale.Text = "Power" Then
                        objWriter.WriteLine("            ,Scale( ""Power"", {Power(" & txt_ybase_power.Text & ")} )")
                    End If

                    If txt_ymaximum.Text.Length > 0 Then
                        objWriter.WriteLine("            ,Max(  " & txt_ymaximum.Text & " )")
                    End If

                    If txt_yminimum.Text.Length > 0 Then
                        objWriter.WriteLine("            ,Min(  " & txt_yminimum.Text & " )")
                    End If

                    If txt_yincrement.Text.Length > 0 Then
                        objWriter.WriteLine("            ,Inc(  " & txt_yincrement.Text & " )")
                    End If

                    If chk_ymajor.Checked = True Then
                        objWriter.WriteLine("            ,Show Major Grid( 1 )")
                    End If

                    If chk_yminor.Checked = True Then
                        objWriter.WriteLine("            ,Show Minor Grid( 1 )")
                    End If

                    For Each item As ListViewItem In lv_refcolor.Items
                        If (item.SubItems(0).Text).Substring(0, 1) = "Y" Then
                            Dim StringItem As String = item.SubItems(1).Text
                            StringItem = StringItem.Replace("(", " ")
                            StringItem = StringItem.Replace(")", " ")
                            StringItem = StringItem.Replace("Y:", "@")
                            objWriter.WriteLine("            ,Add Ref Line( " & (StringItem.Split("@"))(1) & " , Dashed, {" & item.SubItems(2).ForeColor.R & "," & item.SubItems(2).ForeColor.G & "," & item.SubItems(2).ForeColor.B & "}, " & """" & (StringItem.Split("@"))(0) & """, " & item.SubItems(3).Text & ")")
                        End If
                    Next

                    objWriter.WriteLine("        }),")

                    objWriter.WriteLine("        Dispatch(")
                    objWriter.WriteLine("            {},")
                    objWriter.WriteLine("            ""Overlay Plot Graph"",")
                    objWriter.WriteLine("            FrameBox,")
                    objWriter.WriteLine("            {Row Legend(")
                    objWriter.WriteLine("                " & lb_legend.Items(0).ToString & ",")
                    objWriter.WriteLine("                Color( 1 ),")
                    objWriter.WriteLine("                Color Theme( ""JMP Default"" ),")
                    objWriter.WriteLine("                Color Theme( ""JMP Default"" ),")
                    objWriter.WriteLine("            )}")
                    objWriter.WriteLine("        )")
                    objWriter.WriteLine("    )")
                    objWriter.WriteLine(");")

                ElseIf (cmb_jmp_script.Text = "Tabulate") Then
                    objWriter.WriteLine("//!")
                    objWriter.WriteLine("open(""" & i & """);")

                    'Multiply Y Value
                    For x As Integer = 0 To lb_yvalue.Items.Count - 1
                        If cmb_ymultiplier.SelectedIndex = 1 Then
                            objWriter.WriteLine("column(""" & lb_yvalue.Items(x) & """)<<Set Values(Multiply(1000,column(""" & lb_yvalue.Items(x) & """)<<Get As Matrix));")
                        ElseIf cmb_ymultiplier.SelectedIndex = 2 Then
                            objWriter.WriteLine("column(""" & lb_yvalue.Items(x) & """)<<Set Values(Multiply(1000000,column(""" & lb_yvalue.Items(x) & """)<<Get As Matrix));")
                        ElseIf cmb_ymultiplier.SelectedIndex = 3 Then
                            objWriter.WriteLine("column(""" & lb_yvalue.Items(x) & """)<<Set Values(Log(column(""" & lb_yvalue.Items(x) & """)<<Get As Matrix),10);")
                        ElseIf cmb_ymultiplier.SelectedIndex = 4 Then
                            objWriter.WriteLine("column(""" & lb_yvalue.Items(x) & """)<<Set Values(Multiply(1000,column(""" & lb_yvalue.Items(x) & """)<<Get As Matrix));")
                            objWriter.WriteLine("column(""" & lb_yvalue.Items(x) & """)<<Set Values(Log(column(""" & lb_yvalue.Items(x) & """)<<Get As Matrix),10);")
                        ElseIf cmb_ymultiplier.SelectedIndex = 5 Then
                            objWriter.WriteLine("column(""" & lb_yvalue.Items(x) & """)<<Set Values(Multiply(1000000,column(""" & lb_yvalue.Items(x) & """)<<Get As Matrix));")
                            objWriter.WriteLine("column(""" & lb_yvalue.Items(x) & """)<<Set Values(Log(column(""" & lb_yvalue.Items(x) & """)<<Get As Matrix),10);")
                        End If
                    Next

                    objWriter.WriteLine("Tabulate(")
                    objWriter.WriteLine("	Show Control Panel( 0 ),")
                    objWriter.WriteLine("	Add Table(")
                    objWriter.WriteLine("		Column Table(")

                    'Insert Grouping Values
                    objWriter.Write("Grouping Columns( ")
                    For x As Integer = 0 To lb_groupby.Items.Count - 1
                        objWriter.Write(" :" & lb_groupby.Items(x) & ", ")
                    Next
                    objWriter.WriteLine(" ),")

                    'Insert Analysis Values
                    objWriter.Write("Analysis Columns( ")
                    For x As Integer = 0 To lb_yvalue.Items.Count - 1
                        objWriter.Write(" :" & lb_yvalue.Items(x) & ", ")
                    Next
                    objWriter.WriteLine(" ),")

                    objWriter.WriteLine("			Statistics( Mean, Median, Min, Max, Sum ,Std Dev, N )")
                    objWriter.WriteLine("		)")
                    objWriter.WriteLine("	)")
                    objWriter.WriteLine(");")
                End If

                If chk_tabulate.Checked = True And cmb_jmp_script.Text <> "Tabulate" Then
                    objWriter.WriteLine("Tabulate(")
                    objWriter.WriteLine("	Show Control Panel( 0 ),")
                    objWriter.WriteLine("	Add Table(")
                    objWriter.WriteLine("		Column Table(")

                    'Insert Grouping Values
                    objWriter.Write("Grouping Columns( ")
                    For x As Integer = 0 To lb_groupby.Items.Count - 1
                        objWriter.Write(" :" & lb_groupby.Items(x) & ", ")
                    Next
                    objWriter.WriteLine(" ),")

                    'Insert Analysis Values
                    objWriter.Write("Analysis Columns( ")
                    For x As Integer = 0 To lb_yvalue.Items.Count - 1
                        objWriter.Write(" :" & lb_yvalue.Items(x) & ", ")
                    Next
                    objWriter.WriteLine(" ),")

                    objWriter.WriteLine("			Statistics( Mean, Median, Min, Max, Sum ,Std Dev, N )")
                    objWriter.WriteLine("		)")
                    objWriter.WriteLine("	)")
                    objWriter.WriteLine(");")
                End If

                objWriter.Close()
                ShellExecute(Application.StartupPath & "\temp.jsl")
            Next


            g_krashed_input_files.Clear()
        End If
    End Sub

    Private Sub bw_krash_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bw_krash.DoWork
        For Each testblock As DictionaryEntry In g_krash_test_blocks
            Dim headerflag As Boolean = False
            Dim cleanupflag As Boolean = False
            For Each file As DictionaryEntry In g_input_files

                If System.IO.File.Exists(file.Value) = True Then
                    Dim str_output_file = System.IO.Path.GetDirectoryName(file.Value) & "\krash_" & testblock.Key & ".csv"

                    If System.IO.File.Exists(str_output_file) = True And cleanupflag = False Then
                        System.IO.File.Delete(str_output_file)
                    End If
                    cleanupflag = True

                    Dim objWriter As New System.IO.StreamWriter(str_output_file, g_input_files.Count > 1)
                    If Not g_krashed_input_files.Contains(str_output_file) Then
                        g_krashed_input_files.Add(str_output_file)
                    End If


                    Dim objReader As New System.IO.StreamReader(file.Value.ToString)

                    Dim strLine As String
                    Dim strBuff As New System.Text.StringBuilder()

                    g_curr_filelength = New System.IO.FileInfo(file.Value).Length
                    g_byteread = 0
                    Dim modulo As Long

                    'Default
                    g_wafer = "99"
                    g_reticle = "99"

                    Do While objReader.Peek() <> -1
                        strLine = objReader.ReadLine()
                        g_byteread += (strLine.Length + 2)

                        If (modulo Mod 1024 = 0) Then
                            bw_krash.ReportProgress(Convert.ToInt32((g_byteread / g_curr_filelength) * 100))
                            modulo = 0
                        End If
                        modulo += 1

                        'SKip blank lines
                        If strLine.Length < 1 Then
                            Continue Do
                        End If
                        If InStr(strLine, "#LOT", CompareMethod.Binary) = 1 Then
                            g_lot = (strLine.Split(" "))(1)
                        ElseIf InStr(strLine, "TNAME", CompareMethod.Binary) = 1 Then
                            g_test_header = strLine
                            If InStr(g_test_header, "SUPPLIES", CompareMethod.Binary) > 0 Then
                                If g_supplies.Length > 0 Then
                                    g_test_header = g_test_header.Replace("SUPPLIES", g_supplies.Replace(",", " ").Trim())
                                End If
                            End If
                        ElseIf InStr(strLine, "#TEMP", CompareMethod.Binary) = 1 Then
                            g_temp = (strLine.Split(" "))(1)
                        ElseIf InStr(strLine, "#WAFER", CompareMethod.Binary) = 1 Then
                            Dim m_wafer As String = (strLine.Split(" "))(1)
                            g_wafer = UCase$(g_lot & "-" & m_wafer)
                            If g_wafer_def.Item(g_wafer).ToString.Length > 0 Then
                                g_wafer &= "-" & UCase$(g_wafer_def.Item(g_wafer))
                            End If
                        ElseIf InStr(strLine, "#DIE_X", CompareMethod.Binary) = 1 Then
                            g_die_x = (strLine.Split(" "))(1)
                        ElseIf InStr(strLine, "#DIE_Y", CompareMethod.Binary) = 1 Then
                            g_die_y = (strLine.Split(" "))(1)
                        ElseIf InStr(strLine, "#RETICLE", CompareMethod.Binary) = 1 Then
                            g_reticle = (strLine.Split(" "))(1)
                        ElseIf InStr(strLine, "#SUPPLIES", CompareMethod.Binary) = 1 Then
                            g_supplies = (strLine.Split(" "))(1)
                        ElseIf strLine.Length >= testblock.Key.ToString.Length Then
                            'Dim tempsplit As String()
                            'tempsplit = (strLine.Split(" "))(0)
                            'If strLine.Substring(0, testblock.Key.ToString.Length) = testblock.Key Then
                            If (strLine.Split(" "))(0) = testblock.Key Then
                                If headerflag = False Then
                                    headerflag = True
                                    objWriter.WriteLine("LOT,WAFER,RETICLE,DIE_X,DIE_Y,TEMP," & g_test_header.Replace(" ", ",").Trim(","))
                                End If
                                objWriter.WriteLine(g_lot & "," & g_wafer & "," & g_reticle & "," & g_die_x & "," & g_die_y & "," & g_temp & "," & (strLine.Replace(" ", ",").Trim(",")).Replace(":", ","))
                            End If
                        End If

                    Loop

                    objReader.Close()
                    objWriter.Close()
                End If
            Next
        Next
    End Sub

    Private Sub bw_krash_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles bw_krash.ProgressChanged
        sb_status.Text = "Status: Krashing input file(s) - " & e.ProgressPercentage & "%"
    End Sub

    Private Sub bw_krash_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bw_krash.RunWorkerCompleted
        gb_testblocks.Enabled = True
        gb_jmp.Enabled = True
        gb_inputfiles.Enabled = True
        cmd_krash.Enabled = True
        sb_menu.Enabled = True

        sb_status.Text = "Status: Idle/Ready"
    End Sub






    Private Sub cmd_all_Click(sender As Object, e As EventArgs) Handles cmd_all.Click
        For x As Integer = 0 To lb_testblocks.Items.Count - 1
            If lb_testblocks.GetSelected(x) = False Then
                lb_testblocks.SetSelected(x, True)
            End If
        Next
    End Sub



    Private Sub cmb_jmp_script_MouseDown(sender As Object, e As MouseEventArgs) Handles cmb_jmp_script.MouseDown
        If g_input_files.Count = 0 Then
            'MsgBox("Add input file(s) to krash", vbExclamation + vbOKOnly, "Error")
            cmd_addinput.Focus()
            tool_tip.Show("Click this button to add input files", cmd_addinput, 0, cmd_addinput.Height, 2500)
            Exit Sub
        End If
        If lb_testblocks.Items.Count > 0 And lb_testblocks.Text = "" Then
            'MsgBox("Select test block to krash", vbExclamation + vbOKOnly, "Error")
            lb_testblocks.Focus()
            tool_tip.Show("Select test block to krash", lb_testblocks, 0, lb_testblocks.Height, 2500)
            Exit Sub
        End If
    End Sub



    Private Sub cmb_jmp_script_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_jmp_script.SelectedIndexChanged
        cmd_yresponse.Enabled = True
        lb_yvalue.Enabled = True
        cmb_ymultiplier.Enabled = True

        cmd_xfactor.Enabled = True
        lb_xfactor.Enabled = True

        cmd_by.Enabled = True
        lb_groupby.Enabled = True

        cmd_legend.Enabled = True
        lb_legend.Enabled = True

        gb_axis.Enabled = True
        gb_lines.Enabled = True

        If cmb_jmp_script.Text = "Distribution" Then
            cmd_xfactor.Enabled = False
            lb_xfactor.Enabled = False

            cmd_legend.Enabled = False
            lb_legend.Enabled = False

        ElseIf cmb_jmp_script.Text = "Tabulate" Then
            cmd_xfactor.Enabled = False
            lb_xfactor.Enabled = False

            cmd_legend.Enabled = False
            lb_legend.Enabled = False

            gb_axis.Enabled = False
            gb_lines.Enabled = False
        ElseIf cmb_jmp_script.Text = "Contour Plot" Then
            gb_axis.Enabled = False
            gb_lines.Enabled = False

            cmd_legend.Enabled = False
            lb_legend.Enabled = False

        End If
    End Sub



    Private Sub lb_groupby_DragDrop(sender As Object, e As DragEventArgs) Handles lb_groupby.DragDrop
        Dim str As String = CStr(e.Data.GetData(DataFormats.StringFormat))
        If lb_groupby.Items.Contains(str) = False Then
            lb_groupby.Items.Add(str)
        End If

    End Sub

    Private Sub lb_groupby_DragEnter(sender As Object, e As DragEventArgs) Handles lb_groupby.DragEnter
        e.Effect = DragDropEffects.All
    End Sub

    Private Sub lb_groupby_KeyUp(sender As Object, e As KeyEventArgs) Handles lb_groupby.KeyUp
        If e.KeyCode = Keys.Delete Then
            Do While (lb_groupby.SelectedItems.Count > 0)
                lb_groupby.Items.Remove(lb_groupby.SelectedItem)
            Loop
        End If
    End Sub

    Private Sub txt_wafer_def_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_wafer_def.KeyPress
        e.KeyChar = UCase(e.KeyChar)
    End Sub



    Private Sub txt_wafer_def_KeyUp(sender As Object, e As KeyEventArgs) Handles txt_wafer_def.KeyUp
        If cmb_wafers.Text = "" Then
            Exit Sub
        End If
        g_wafer_def.Item(cmb_wafers.Text) = txt_wafer_def.Text
    End Sub

    Private Sub cmb_wafers_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_wafers.SelectedIndexChanged
        txt_wafer_def.Text = g_wafer_def.Item(cmb_wafers.Text)
    End Sub


    Private Sub lb_header_list_MouseDown(sender As Object, e As MouseEventArgs) Handles lb_header_list.MouseDown

        If lb_header_list.Items.Count = 0 Then
            Return
        End If
        Dim index As Integer = lb_header_list.IndexFromPoint(e.X, e.Y)
        If index < 0 Then
            Exit Sub
        End If
        Dim sourceStr As String = lb_header_list.Items(index).ToString()
        Dim objDragDropEff As DragDropEffects = DoDragDrop(sourceStr, DragDropEffects.All)
        'If objDragDropEff = DragDropEffects.All Then
        '   ListBox1.Items.RemoveAt(ListBox1.IndexFromPoint(e.X, e.Y))
        'End If
    End Sub

    Private Sub lb_yvalue_DragDrop(sender As Object, e As DragEventArgs) Handles lb_yvalue.DragDrop
        Dim str As String = CStr(e.Data.GetData(DataFormats.StringFormat))
        If lb_yvalue.Items.Contains(str) = False Then
            lb_yvalue.Items.Add(str)
        End If
    End Sub

    Private Sub lb_yvalue_DragEnter(sender As Object, e As DragEventArgs) Handles lb_yvalue.DragEnter
        e.Effect = DragDropEffects.All
    End Sub

    Private Sub lb_yvalue_KeyUp(sender As Object, e As KeyEventArgs) Handles lb_yvalue.KeyUp
        If e.KeyCode = Keys.Delete Then
            Do While (lb_yvalue.SelectedItems.Count > 0)
                lb_yvalue.Items.Remove(lb_yvalue.SelectedItem)
            Loop
        End If
    End Sub

    Private Sub lb_xfactor_DragDrop(sender As Object, e As DragEventArgs) Handles lb_xfactor.DragDrop
        Dim str As String = CStr(e.Data.GetData(DataFormats.StringFormat))

        If lb_xfactor.Items.Contains(str) = False Then
            lb_xfactor.Items.Add(str)
        End If
    End Sub

    Private Sub lb_xfactor_DragEnter(sender As Object, e As DragEventArgs) Handles lb_xfactor.DragEnter
        e.Effect = DragDropEffects.All
    End Sub


    Private Sub lb_xfactor_KeyUp(sender As Object, e As KeyEventArgs) Handles lb_xfactor.KeyUp
        If e.KeyCode = Keys.Delete Then
            Do While (lb_xfactor.SelectedItems.Count > 0)
                lb_xfactor.Items.Remove(lb_xfactor.SelectedItem)
            Loop
        End If
    End Sub

    Private Sub lb_legend_DragDrop(sender As Object, e As DragEventArgs) Handles lb_legend.DragDrop
        Dim str As String = CStr(e.Data.GetData(DataFormats.StringFormat))
        lb_legend.Items.Clear()
        lb_legend.Items.Add(str)
    End Sub

    Private Sub lb_legend_DragEnter(sender As Object, e As DragEventArgs) Handles lb_legend.DragEnter
        e.Effect = DragDropEffects.All
    End Sub

    Private Sub lb_legend_KeyUp(sender As Object, e As KeyEventArgs) Handles lb_legend.KeyUp
        If e.KeyCode = Keys.Delete Then
            Do While (lb_legend.SelectedItems.Count > 0)
                lb_legend.Items.Remove(lb_legend.SelectedItem)
            Loop
        End If
    End Sub




    Private Sub cmd_yresponse_Click(sender As Object, e As EventArgs) Handles cmd_yresponse.Click
        If lb_header_list.Text.Length > 0 And lb_yvalue.Items.Contains(lb_header_list.Text) = False Then
            lb_yvalue.Items.Add(lb_header_list.Text)
        End If
    End Sub


    Private Sub cmd_xfactor_Click(sender As Object, e As EventArgs) Handles cmd_xfactor.Click
        If lb_header_list.Text.Length > 0 And lb_xfactor.Items.Contains(lb_header_list.Text) = False Then
            lb_xfactor.Items.Add(lb_header_list.Text)
        End If
    End Sub

    Private Sub cmd_by_Click(sender As Object, e As EventArgs) Handles cmd_by.Click
        If lb_header_list.Text.Length > 0 And lb_groupby.Items.Contains(lb_header_list.Text) = False Then
            lb_groupby.Items.Add(lb_header_list.Text)
        End If
    End Sub

    Private Sub cmd_legend_Click(sender As Object, e As EventArgs) Handles cmd_legend.Click
        If lb_header_list.Text.Length > 0 Then
            lb_legend.Items.Clear()
            lb_legend.Items.Add(lb_header_list.Text)
        End If
    End Sub





    Private Sub Label1_Click(sender As Object, e As EventArgs)

    End Sub


    Private Sub cmb_xscale_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_xscale.SelectedIndexChanged
        If cmb_xscale.SelectedIndex = 0 Then
            txt_xbase_power.Enabled = False
            txt_xbase_power.Text = ""
        ElseIf cmb_xscale.SelectedIndex = 1 Then
            txt_xbase_power.Text = "10"
            txt_xbase_power.Enabled = True
        ElseIf cmb_xscale.SelectedIndex = 2 Then
            txt_xbase_power.Text = "10"
            txt_xbase_power.Enabled = True
        End If
    End Sub

    Private Sub cmb_yscale_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_yscale.SelectedIndexChanged
        If cmb_yscale.SelectedIndex = 0 Then
            txt_ybase_power.Enabled = False
            txt_ybase_power.Text = ""
        ElseIf cmb_yscale.SelectedIndex = 1 Then
            txt_ybase_power.Text = "10"
            txt_ybase_power.Enabled = True
        ElseIf cmb_yscale.SelectedIndex = 2 Then
            txt_ybase_power.Text = "10"
            txt_ybase_power.Enabled = True
        End If
    End Sub

    Private Sub txt_xbase_power_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_xbase_power.KeyPress

        e.Handled = Not (IsNumeric(e.KeyChar) Or Asc(e.KeyChar) = 8 Or (e.KeyChar = "." And InStr(txt_xbase_power.Text, ".") < 1))

    End Sub

    Private Sub txt_xincrement_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_xincrement.KeyPress
        e.Handled = Not (IsNumeric(e.KeyChar) Or Asc(e.KeyChar) = 8 Or (e.KeyChar = "." And InStr(txt_xincrement.Text, ".") < 1))
    End Sub

    Private Sub txt_xmaximum_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_xmaximum.KeyPress

    End Sub

    Private Sub txt_xminimum_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_xminimum.KeyPress
        e.Handled = Not (IsNumeric(e.KeyChar) Or Asc(e.KeyChar) = 8 Or (e.KeyChar = "." And InStr(txt_xminimum.Text, ".") < 1))
    End Sub

    Private Sub txt_ybase_power_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_ybase_power.KeyPress
        e.Handled = Not (IsNumeric(e.KeyChar) Or Asc(e.KeyChar) = 8 Or (e.KeyChar = "." And InStr(txt_ybase_power.Text, ".") < 1))
    End Sub

    Private Sub txt_yminimum_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_yminimum.KeyPress
        e.Handled = Not (IsNumeric(e.KeyChar) Or Asc(e.KeyChar) = 8 Or (e.KeyChar = "." And InStr(txt_yminimum.Text, ".") < 1))
    End Sub

    Private Sub txt_ymaximum_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_ymaximum.KeyPress
        e.Handled = Not (IsNumeric(e.KeyChar) Or Asc(e.KeyChar) = 8 Or (e.KeyChar = "." And InStr(txt_ymaximum.Text, ".") < 1))
    End Sub

    Private Sub txt_yincrement_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_yincrement.KeyPress
        e.Handled = Not (IsNumeric(e.KeyChar) Or Asc(e.KeyChar) = 8 Or (e.KeyChar = "." And InStr(txt_yincrement.Text, ".") < 1))
    End Sub

    Private Sub sb_menu_enable_jmp_CheckedChanged(sender As Object, e As EventArgs) Handles sb_menu_enable_jmp.CheckedChanged
        'gb_jmp.Enabled = sb_menu_enable_jmp.Checked
        gb_columns.Enabled = sb_menu_enable_jmp.Checked
        gb_axis.Enabled = sb_menu_enable_jmp.Checked
        gb_lines.Enabled = sb_menu_enable_jmp.Checked
        gb_roles.Enabled = sb_menu_enable_jmp.Checked
        cmb_jmp_script.Enabled = sb_menu_enable_jmp.Checked
        cmb_wafers.Enabled = sb_menu_enable_jmp.Checked
        txt_wafer_def.Enabled = sb_menu_enable_jmp.Checked

        If sb_menu_enable_jmp.Checked Then
            cmd_all.Enabled = False
            lb_testblocks.SelectionMode = SelectionMode.One
            'Me.Width = 933
            'sb_label_spacer.Width = 622
            'sb_status.Width = 230
        Else
            cmd_all.Enabled = True
            lb_testblocks.SelectionMode = SelectionMode.MultiSimple
            'Me.Width = 264
            'sb_status.Width = 184
            'sb_label_spacer.Width = 0
        End If
    End Sub


    Private Sub sb_menu_enable_jmp_Click(sender As Object, e As EventArgs) Handles sb_menu_enable_jmp.Click
        sb_menu_enable_jmp.Checked = Not sb_menu_enable_jmp.Checked
    End Sub


    Private Sub sb_menu_reset_roles_Click(sender As Object, e As EventArgs) Handles sb_menu_reset_roles.Click
        reset_roles()
    End Sub

    Private Sub sb_menu_reset_axis_Click(sender As Object, e As EventArgs) Handles sb_menu_reset_axis.Click
        reset_axis()
    End Sub

    Private Sub sb_menu_reset_all_Click(sender As Object, e As EventArgs) Handles sb_menu_reset_all.Click
        reset_jmp_settings()
    End Sub


    Private Sub cmd_clear_roles_Click(sender As Object, e As EventArgs) Handles cmd_clear_roles.Click
        reset_roles()
    End Sub

    Private Sub cmd_clear_axis_Click(sender As Object, e As EventArgs) Handles cmd_clear_axis.Click
        reset_axis()
    End Sub

    Private Sub pic_ref_color_Click(sender As Object, e As EventArgs) Handles pic_ref_color.Click
        Dim dg_color As New ColorDialog
        If dg_color.ShowDialog = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If

        pic_ref_color.BackColor = dg_color.Color
    End Sub

    Private Sub txt_ref_value_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_ref_value.KeyPress
        e.Handled = Not (IsNumeric(e.KeyChar) Or Asc(e.KeyChar) = 8 Or (e.KeyChar = "." And InStr(txt_ref_value.Text, ".") < 1))
    End Sub

    Private Sub cmd_add_refline_Click(sender As Object, e As EventArgs) Handles cmd_add_refline.Click
        If cmb_ref_axis.Text = "" Or txt_ref_value.Text = "" Then
            tool_tip.Show("Set the reference value to be added", cmb_ref_axis, 2500)
            Exit Sub
        End If

        If txt_ref_label.Text = "" Then
            txt_ref_label.Text = txt_ref_value.Text
            tool_tip.Show("Label can not be empty, auto filled with reference value", txt_ref_label, 2500)
        End If


        If lv_refcolor.Items.ContainsKey(cmb_ref_axis.Text & ": " & txt_ref_value.Text) = True Then
            Dim KeyString As String = cmb_ref_axis.Text & ": " & txt_ref_value.Text
            lv_refcolor.Items(KeyString).SubItems(1).Text = txt_ref_label.Text & "(" & cmb_ref_axis.Text & ": " & txt_ref_value.Text & ")"
            lv_refcolor.Items(KeyString).SubItems(2).ForeColor = pic_ref_color.BackColor
            lv_refcolor.Items(KeyString).SubItems(3).Text = num_line_width.Value
        Else
            lv_refcolor.Items.Add(cmb_ref_axis.Text & ": " & txt_ref_value.Text, cmb_ref_axis.Text & ": " & txt_ref_value.Text, 0)
            Dim index As Integer = lv_refcolor.Items.Count - 1

            lv_refcolor.Items(index).UseItemStyleForSubItems = False

            lv_refcolor.Items(index).SubItems.Add(txt_ref_label.Text & "(" & cmb_ref_axis.Text & ": " & txt_ref_value.Text & ")")
            lv_refcolor.Items(index).SubItems(1).ForeColor = Color.Black

            lv_refcolor.Items(index).SubItems.Add("- - - - -")
            lv_refcolor.Items(index).SubItems(2).ForeColor = pic_ref_color.BackColor

            lv_refcolor.Items(index).SubItems.Add(num_line_width.Value)
        End If
        
    End Sub

    Private Sub cmd_clear_lines_Click(sender As Object, e As EventArgs) Handles cmd_clear_lines.Click
        reset_reflines()
    End Sub

    Private Sub lv_refcolor_ItemSelectionChanged(sender As Object, e As ListViewItemSelectionChangedEventArgs) Handles lv_refcolor.ItemSelectionChanged

        pic_ref_color.BackColor = e.Item.SubItems(2).ForeColor
        Dim StringItem As String = e.Item.SubItems(1).Text
        StringItem = StringItem.Replace(" ", "")
        StringItem = StringItem.Replace("(", ":")
        StringItem = StringItem.Replace(")", ":")
        txt_ref_label.Text = (StringItem.Split(":"))(0)
        cmb_ref_axis.Text = (StringItem.Split(":"))(1)
        txt_ref_value.Text = (StringItem.Split(":"))(2)
        num_line_width.Value = e.Item.SubItems(3).Text
    End Sub

    Private Sub lv_refcolor_KeyUp(sender As Object, e As KeyEventArgs) Handles lv_refcolor.KeyUp
        If e.KeyCode = Keys.Delete Then
            For Each i As ListViewItem In lv_refcolor.SelectedItems
                lv_refcolor.Items.Remove(i)
            Next
        End If
    End Sub

    Private Sub lb_yvalue_MouseDown(sender As Object, e As MouseEventArgs) Handles lb_yvalue.MouseDown

        If lb_yvalue.Items.Count = 0 Then
            Return
        End If
        Dim index As Integer = lb_yvalue.IndexFromPoint(e.X, e.Y)
        If index < 0 Then
            Exit Sub
        End If
        Dim sourceStr As String = lb_yvalue.Items(index).ToString()
        Dim objDragDropEff As DragDropEffects = DoDragDrop(sourceStr, DragDropEffects.All)
        If objDragDropEff = DragDropEffects.All Then
            lb_yvalue.Items.RemoveAt(lb_yvalue.IndexFromPoint(e.X, e.Y))
        End If
    End Sub

    Private Sub lb_yvalue_MouseEnter(sender As Object, e As EventArgs) Handles lb_yvalue.MouseEnter
        lb_yvalue.AllowDrop = False
        lb_yvalue.BackColor = Color.FromArgb(230, 255, 255)
    End Sub


    Private Sub lb_yvalue_MouseLeave(sender As Object, e As EventArgs) Handles lb_yvalue.MouseLeave
        lb_yvalue.AllowDrop = True
        lb_yvalue.BackColor = Color.Ivory
    End Sub

    Private Sub lb_xfactor_MouseDown(sender As Object, e As MouseEventArgs) Handles lb_xfactor.MouseDown
        If lb_xfactor.Items.Count = 0 Then
            Return
        End If
        Dim index As Integer = lb_xfactor.IndexFromPoint(e.X, e.Y)
        If index < 0 Then
            Exit Sub
        End If
        Dim sourceStr As String = lb_xfactor.Items(index).ToString()
        Dim objDragDropEff As DragDropEffects = DoDragDrop(sourceStr, DragDropEffects.All)
        If objDragDropEff = DragDropEffects.All Then
            lb_xfactor.Items.RemoveAt(lb_xfactor.IndexFromPoint(e.X, e.Y))
        End If
    End Sub

    Private Sub lb_xfactor_MouseEnter(sender As Object, e As EventArgs) Handles lb_xfactor.MouseEnter
        lb_xfactor.AllowDrop = False
        lb_xfactor.BackColor = Color.FromArgb(230, 255, 255)
    End Sub


    Private Sub lb_xfactor_MouseLeave(sender As Object, e As EventArgs) Handles lb_xfactor.MouseLeave
        lb_xfactor.AllowDrop = True
        lb_xfactor.BackColor = Color.Ivory
    End Sub

    Private Sub lb_groupby_MouseDown(sender As Object, e As MouseEventArgs) Handles lb_groupby.MouseDown
        If lb_groupby.Items.Count = 0 Then
            Return
        End If
        Dim index As Integer = lb_groupby.IndexFromPoint(e.X, e.Y)
        If index < 0 Then
            Exit Sub
        End If
        Dim sourceStr As String = lb_groupby.Items(index).ToString()
        Dim objDragDropEff As DragDropEffects = DoDragDrop(sourceStr, DragDropEffects.All)
        If objDragDropEff = DragDropEffects.All Then
            lb_groupby.Items.RemoveAt(lb_groupby.IndexFromPoint(e.X, e.Y))
        End If
    End Sub

    Private Sub lb_groupby_MouseEnter(sender As Object, e As EventArgs) Handles lb_groupby.MouseEnter
        lb_groupby.AllowDrop = False
        lb_groupby.BackColor = Color.FromArgb(230, 255, 255)
    End Sub

    Private Sub lb_groupby_MouseLeave(sender As Object, e As EventArgs) Handles lb_groupby.MouseLeave
        lb_groupby.AllowDrop = True
        lb_groupby.BackColor = Color.Ivory
    End Sub

    Private Sub lb_legend_MouseDown(sender As Object, e As MouseEventArgs) Handles lb_legend.MouseDown
        If lb_legend.Items.Count = 0 Then
            Return
        End If
        Dim index As Integer = lb_legend.IndexFromPoint(e.X, e.Y)
        If index < 0 Then
            Exit Sub
        End If
        Dim sourceStr As String = lb_legend.Items(index).ToString()
        Dim objDragDropEff As DragDropEffects = DoDragDrop(sourceStr, DragDropEffects.All)
        If objDragDropEff = DragDropEffects.All Then
            lb_legend.Items.RemoveAt(lb_legend.IndexFromPoint(e.X, e.Y))
        End If
    End Sub

    Private Sub lb_legend_MouseEnter(sender As Object, e As EventArgs) Handles lb_legend.MouseEnter
        lb_legend.AllowDrop = False
        lb_legend.BackColor = Color.FromArgb(230, 255, 255)
    End Sub

    Private Sub lb_legend_MouseLeave(sender As Object, e As EventArgs) Handles lb_legend.MouseLeave
        lb_legend.AllowDrop = True
        lb_legend.BackColor = Color.Ivory
    End Sub



    Private Sub lb_header_list_MouseEnter(sender As Object, e As EventArgs) Handles lb_header_list.MouseEnter
        lb_header_list.BackColor = Color.FromArgb(230, 255, 255)
    End Sub


    Private Sub lb_header_list_MouseLeave(sender As Object, e As EventArgs) Handles lb_header_list.MouseLeave
        lb_header_list.BackColor = Color.Ivory
    End Sub

    Private Sub lb_inputs_MouseEnter(sender As Object, e As EventArgs) Handles lb_inputs.MouseEnter
        lb_inputs.BackColor = Color.FromArgb(230, 255, 255)
    End Sub

    Private Sub lb_inputs_MouseLeave(sender As Object, e As EventArgs) Handles lb_inputs.MouseLeave
        lb_inputs.BackColor = Color.Ivory
    End Sub

    Private Sub lb_testblocks_MouseEnter(sender As Object, e As EventArgs) Handles lb_testblocks.MouseEnter
        lb_testblocks.BackColor = Color.FromArgb(230, 255, 255)
    End Sub

    Private Sub lb_testblocks_MouseLeave(sender As Object, e As EventArgs) Handles lb_testblocks.MouseLeave
        lb_testblocks.BackColor = Color.Ivory
    End Sub

    Private Sub lv_refcolor_MouseEnter(sender As Object, e As EventArgs) Handles lv_refcolor.MouseEnter
        lv_refcolor.BackColor = Color.FromArgb(230, 255, 255)
    End Sub

    Private Sub lv_refcolor_MouseLeave(sender As Object, e As EventArgs) Handles lv_refcolor.MouseLeave
        lv_refcolor.BackColor = Color.Ivory
    End Sub

    Private Sub txt_wafer_def_MouseEnter(sender As Object, e As EventArgs) Handles txt_wafer_def.MouseEnter
        txt_wafer_def.BackColor = Color.FromArgb(230, 255, 255)
    End Sub

    Private Sub txt_wafer_def_MouseLeave(sender As Object, e As EventArgs) Handles txt_wafer_def.MouseLeave
        txt_wafer_def.BackColor = Color.Ivory
    End Sub

    Private Sub txt_xbase_power_MouseEnter(sender As Object, e As EventArgs) Handles txt_xbase_power.MouseEnter
        txt_xbase_power.BackColor = Color.FromArgb(230, 255, 255)
    End Sub

    Private Sub txt_xbase_power_MouseLeave(sender As Object, e As EventArgs) Handles txt_xbase_power.MouseLeave
        txt_xbase_power.BackColor = Color.Ivory
    End Sub

    Private Sub txt_xminimum_MouseEnter(sender As Object, e As EventArgs) Handles txt_xminimum.MouseEnter
        txt_xminimum.BackColor = Color.FromArgb(230, 255, 255)
    End Sub

    Private Sub txt_xminimum_MouseLeave(sender As Object, e As EventArgs) Handles txt_xminimum.MouseLeave
        txt_xminimum.BackColor = Color.Ivory
    End Sub

    Private Sub txt_xmaximum_MouseEnter(sender As Object, e As EventArgs) Handles txt_xmaximum.MouseEnter
        txt_xmaximum.BackColor = Color.FromArgb(230, 255, 255)
    End Sub

    Private Sub txt_xmaximum_MouseLeave(sender As Object, e As EventArgs) Handles txt_xmaximum.MouseLeave
        txt_xmaximum.BackColor = Color.Ivory
    End Sub

    Private Sub txt_xincrement_MouseEnter(sender As Object, e As EventArgs) Handles txt_xincrement.MouseEnter
        txt_xincrement.BackColor = Color.FromArgb(230, 255, 255)
    End Sub

    Private Sub txt_xincrement_MouseLeave(sender As Object, e As EventArgs) Handles txt_xincrement.MouseLeave
        txt_xincrement.BackColor = Color.Ivory
    End Sub

    Private Sub txt_ybase_power_MouseEnter(sender As Object, e As EventArgs) Handles txt_ybase_power.MouseEnter
        txt_ybase_power.BackColor = Color.FromArgb(230, 255, 255)
    End Sub

    Private Sub txt_ybase_power_MouseLeave(sender As Object, e As EventArgs) Handles txt_ybase_power.MouseLeave
        txt_ybase_power.BackColor = Color.Ivory
    End Sub

    Private Sub txt_yminimum_MouseEnter(sender As Object, e As EventArgs) Handles txt_yminimum.MouseEnter
        txt_yminimum.BackColor = Color.FromArgb(230, 255, 255)
    End Sub

    Private Sub txt_yminimum_MouseLeave(sender As Object, e As EventArgs) Handles txt_yminimum.MouseLeave
        txt_yminimum.BackColor = Color.Ivory
    End Sub

    Private Sub txt_ymaximum_MouseEnter(sender As Object, e As EventArgs) Handles txt_ymaximum.MouseEnter
        txt_ymaximum.BackColor = Color.FromArgb(230, 255, 255)
    End Sub

    Private Sub txt_ymaximum_MouseLeave(sender As Object, e As EventArgs) Handles txt_ymaximum.MouseLeave
        txt_ymaximum.BackColor = Color.Ivory
    End Sub

    Private Sub txt_yincrement_MouseEnter(sender As Object, e As EventArgs) Handles txt_yincrement.MouseEnter
        txt_yincrement.BackColor = Color.FromArgb(230, 255, 255)
    End Sub

    Private Sub txt_yincrement_MouseLeave(sender As Object, e As EventArgs) Handles txt_yincrement.MouseLeave
        txt_yincrement.BackColor = Color.Ivory
    End Sub

    Private Sub txt_ref_value_MouseEnter(sender As Object, e As EventArgs) Handles txt_ref_value.MouseEnter
        txt_ref_value.BackColor = Color.FromArgb(230, 255, 255)
    End Sub

    Private Sub txt_ref_value_MouseLeave(sender As Object, e As EventArgs) Handles txt_ref_value.MouseLeave
        txt_ref_value.BackColor = Color.Ivory
    End Sub

    Private Sub txt_ref_label_MouseEnter(sender As Object, e As EventArgs) Handles txt_ref_label.MouseEnter
        txt_ref_label.BackColor = Color.FromArgb(230, 255, 255)
    End Sub

    Private Sub txt_ref_label_MouseLeave(sender As Object, e As EventArgs) Handles txt_ref_label.MouseLeave
        txt_ref_label.BackColor = Color.Ivory
    End Sub

    Private Sub lb_yvalue_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lb_yvalue.SelectedIndexChanged

    End Sub
End Class
