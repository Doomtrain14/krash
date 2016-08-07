Imports System.Text.RegularExpressions

Public Class Form1
    Dim g_test_blocks As New Hashtable()
    Dim g_krash_test_blocks As New Hashtable()

    Dim g_krashed_input_files As New List(Of String)
    Dim g_input_files As New Hashtable()
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
    Public Sub reset_jmp_selection()

        cmb_groupby.SelectedIndex = 0
        cmb_legend.SelectedIndex = 0
        cmb_presets.SelectedIndex = 0
        cmb_xfactor.SelectedIndex = 0
        cmb_yvalue.SelectedIndex = 0
        cmb_wafers.SelectedIndex = 0
        cmb_grid.SelectedIndex = 0
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
        bw_extracttests.RunWorkerAsync()
    End Sub

    Private Sub cmd_removeinput_Click(sender As Object, e As EventArgs) Handles cmd_removeinput.Click


        Do While (lb_inputs.SelectedItems.Count > 0)
            g_input_files.Remove(lb_inputs.SelectedItem.ToString)
            lb_inputs.Items.Remove(lb_inputs.SelectedItem)
        Loop

        If g_input_files.Count = 0 Then
            lb_testblocks.Items.Clear()
            cmb_jmp_script.SelectedIndex = 0
            reset_jmp_selection()
        End If
    End Sub



    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If (bw_extracttests.IsBusy) Then
            bw_extracttests.CancelAsync()
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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
                    If InStr(strLine, "#WAFER", CompareMethod.Binary) = 1 Then
                        g_wafer = (strLine.Split(" "))(1)
                        If (Not g_wafers_list.Contains(g_wafer)) Then
                            g_wafers_list.Add(g_wafer)
                        End If
                    ElseIf (String.Compare(firstword, "TNAME") And String.Compare(firstword.Substring(0, 1), "#")) Then
                        If (Not g_test_blocks.ContainsKey(firstword)) Then
                            g_test_blocks.Add(firstword, 1)
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

        'Fill wafer list
        For Each i As String In g_wafers_list
            If Not cmb_wafers.Items.Contains(i) Then
                cmb_wafers.Items.Add(i)
                g_wafer_def.Add(i, "")
            End If
        Next

    End Sub

    Private Sub cmd_clear_Click(sender As Object, e As EventArgs) Handles cmd_clear.Click
        lb_testblocks.SelectedItems.Clear()
    End Sub

    Private Sub lb_testblocks_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lb_testblocks.SelectedIndexChanged
        lbl_selected_test.Text = lb_testblocks.SelectedItems.Count & " selected"

        If g_curr_selected_test <> lb_testblocks.SelectedItem And chk_jmp.Enabled Then
            g_curr_selected_test = lb_testblocks.SelectedItem
            bw_headergetter.RunWorkerAsync()

            While bw_headergetter.IsBusy
                Application.DoEvents()
            End While

            cmb_groupby.Items.Clear()
            cmb_groupby.Items.AddRange(Split("None LOT WAFER RETICLE DIE_X DIE_Y TEMP " & g_test_header.Trim(), " "))

            cmb_xfactor.Items.Clear()
            cmb_xfactor.Items.AddRange(Split("None LOT WAFER RETICLE DIE_X DIE_Y TEMP " & g_test_header.Trim(), " "))

            cmb_legend.Items.Clear()
            cmb_legend.Items.AddRange(Split("None LOT WAFER RETICLE DIE_X DIE_Y TEMP " & g_test_header.Trim(), " "))

            cmb_yvalue.Items.Clear()
            cmb_yvalue.Items.AddRange(Split("None LOT WAFER RETICLE DIE_X DIE_Y TEMP " & g_test_header.Trim(), " "))

            lb_groupby.Items.Clear()

            cmb_jmp_script.SelectedIndex = 0
            reset_jmp_selection()
        End If
        g_krash_test_blocks.Clear()

        For i = 0 To lb_testblocks.SelectedItems.Count - 1
            If Not g_krash_test_blocks.ContainsKey(lb_testblocks.SelectedItems(i)) Then
                g_krash_test_blocks.Add(lb_testblocks.SelectedItems(i), "1")
            End If
        Next
    End Sub

    Private Sub cmd_krash_Click(sender As Object, e As EventArgs) Handles cmd_krash.Click
        gb_testblocks.Enabled = False
        gb_jmp.Enabled = False
        gb_inputfiles.Enabled = False
        cmd_krash.Enabled = False



        bw_krash.RunWorkerAsync()
        While (bw_krash.IsBusy)
            Application.DoEvents()
        End While


        For Each i As String In g_krashed_input_files
            If cmb_jmp_script.SelectedIndex = 0 Then
                Continue For
            End If
            Dim objWriter As New System.IO.StreamWriter(Application.StartupPath & "\temp.jsl", False)
            objWriter.AutoFlush = True
            If (cmb_jmp_script.Text = "Distribution") Then
                objWriter.WriteLine("//!")
                objWriter.WriteLine("open(""" & i & """);")
                objWriter.WriteLine("Distribution(")
                objWriter.WriteLine("    Continuous Distribution(")
                objWriter.WriteLine("        Column( :VALUE ),")
                objWriter.WriteLine("        Horizontal Layout( 0 ),")
                objWriter.WriteLine("        Fit Distribution(Normal),")
                objWriter.WriteLine("        Vertical( 0 ),")
                objWriter.WriteLine("        SendToReport(")
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
                objWriter.WriteLine("Bivariate( Y( :" & cmb_yvalue.Text & " ), X( :" & cmb_xfactor.Text & " ),")
                objWriter.Write("    By( ")
                For x As Integer = 0 To lb_groupby.Items.Count - 1
                    objWriter.Write(" :" & lb_groupby.Items(x) & ", ")
                Next
                objWriter.WriteLine(" ),")
                objWriter.WriteLine("    SendToReport(")
                objWriter.WriteLine("        Dispatch( {},""" & cmb_yvalue.Text & """,TextEditBox,{Set Text( """ & UCase(System.IO.Path.GetFileNameWithoutExtension(i).Replace("krash_", "")) & """ )}),")

                'Vertical Grid Lines
                If cmb_grid.Text = "Vertical" Or cmb_grid.Text = "Both" Then
                    objWriter.WriteLine("        Dispatch({},""1"",ScaleBox,{Show Major Grid( 1 )}),")
                End If
                'Horizontal Grid Lines
                If cmb_grid.Text = "Horizontal" Or cmb_grid.Text = "Both" Then
                    objWriter.WriteLine("        Dispatch({},""2"",ScaleBox,{Show Major Grid( 1 )}),")
                End If

                objWriter.WriteLine("        Dispatch( {}, ""Bivar Plot"", FrameBox,")
                objWriter.WriteLine("            {Row Legend(")
                objWriter.WriteLine("                " & cmb_legend.Text & " ,")
                objWriter.WriteLine("                Color( 1 ),")
                objWriter.WriteLine("                Color Theme( ""JMP Default"" )")
                objWriter.WriteLine("            )}")
                objWriter.WriteLine("        )")
                objWriter.WriteLine("    )")
                objWriter.WriteLine(");")
            ElseIf (cmb_jmp_script.Text = "Bin Map") Then
                objWriter.WriteLine("//!")
                objWriter.WriteLine("open(""" & i & """);")
                objWriter.WriteLine("Overlay Plot(")
                objWriter.WriteLine("    X( :DIE_X ),")
                objWriter.WriteLine("    Y( :DIE_Y ),")
                objWriter.Write("    By( :" & cmb_groupby.Text & " ),")
                objWriter.WriteLine("    Separate Axes( 1 ),")
                objWriter.WriteLine("    SendToReport(")
                objWriter.WriteLine("        Dispatch(")
                objWriter.WriteLine("            {},")
                objWriter.WriteLine("            ""Overlay Plot Graph"",")
                objWriter.WriteLine("            FrameBox,")
                objWriter.WriteLine("            {Frame Size( 440, 420 ), Row Legend(")
                objWriter.WriteLine("                " & cmb_legend.Text & ",")
                objWriter.WriteLine("                Color( 1 ),")
                objWriter.WriteLine("                Color Theme( ""JMP Default"" ),")
                objWriter.WriteLine("                Marker( 0 ),")
                objWriter.WriteLine("                Marker Theme( """" ),")
                objWriter.WriteLine("                Continuous Scale( 0 ),")
                objWriter.WriteLine("                Reverse Scale( 0 ),")
                objWriter.WriteLine("                Excluded Rows( 0 )")
                objWriter.WriteLine("            )}")
                objWriter.WriteLine("        ),")
                objWriter.WriteLine("        Dispatch(")
                objWriter.WriteLine("            {},")
                objWriter.WriteLine("            """",")
                objWriter.WriteLine("            AxisBox( 3 ),")
                objWriter.WriteLine("        ),")
                objWriter.WriteLine("        Dispatch(")
                objWriter.WriteLine("           {},")
                objWriter.WriteLine("           """ & cmb_legend.Text & """,")
                objWriter.WriteLine("           StringColBox,")
                objWriter.WriteLine("           {Set Heading( ""Bin Name"" )}")
                objWriter.WriteLine("        )")
                objWriter.WriteLine("    )")
                objWriter.WriteLine(");")
            End If
            objWriter.Close()
            ShellExecute(Application.StartupPath & "\temp.jsl")
        Next


        g_krashed_input_files.Clear()
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
                                g_test_header = g_test_header.Replace("SUPPLIES", g_supplies.Replace(",", " ").Trim())
                            End If
                        ElseIf InStr(strLine, "#TEMP", CompareMethod.Binary) = 1 Then
                            g_temp = (strLine.Split(" "))(1)
                        ElseIf InStr(strLine, "#WAFER", CompareMethod.Binary) = 1 Then
                            Dim m_wafer As String = (strLine.Split(" "))(1)
                            g_wafer = UCase$(g_lot) & "-" & m_wafer
                            If g_wafer_def.Item(m_wafer).ToString.Length > 0 Then
                                g_wafer &= "-" & UCase$(g_wafer_def.Item(m_wafer))
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
                            If strLine.Substring(0, testblock.Key.ToString.Length) = testblock.Key Then
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

        sb_status.Text = "Status: Idle/Ready"
    End Sub

    Private Sub chk_jmp_CheckedChanged(sender As Object, e As EventArgs) Handles chk_jmp.CheckedChanged
        gb_jmp.Enabled = chk_jmp.Checked
        If chk_jmp.Checked Then
            lb_testblocks.SelectionMode = SelectionMode.One
            cmd_all.Enabled = False

        Else
            cmd_all.Enabled = True
            lb_testblocks.SelectionMode = SelectionMode.MultiSimple
        End If
    End Sub




    Private Sub cmd_all_Click(sender As Object, e As EventArgs) Handles cmd_all.Click
        For x As Integer = 0 To lb_testblocks.Items.Count - 1
            If lb_testblocks.GetSelected(x) = False Then
                lb_testblocks.SetSelected(x, True)
            End If
        Next
    End Sub

    Private Sub bw_headergetter_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bw_headergetter.DoWork
        For Each file As DictionaryEntry In g_input_files
            Dim strLine As String
            Dim objReader As New System.IO.StreamReader(file.Value.ToString)
            Do While objReader.Peek() <> -1
                strLine = objReader.ReadLine()

                If InStr(strLine, "TNAME", CompareMethod.Text) = 1 Then
                    g_test_header = strLine
                    If InStr(g_test_header, "SUPPLIES", CompareMethod.Text) > 0 Then
                        g_test_header = g_test_header.Replace("SUPPLIES", g_supplies.Replace(",", " ").Trim())
                    End If
                ElseIf InStr(strLine, "#SUPPLIES", CompareMethod.Text) = 1 Then
                    g_supplies = (strLine.Split(" "))(1)
                ElseIf Not g_curr_selected_test = Nothing Then
                    If strLine.Length >= g_curr_selected_test.Length Then
                        If strLine.Substring(0, g_curr_selected_test.Length) = g_curr_selected_test Then
                            objReader.Close()
                            Exit For
                        End If
                    End If
                End If

            Loop

            objReader.Close()
        Next
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_xfactor.SelectedIndexChanged

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub cmb_jmp_script_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_jmp_script.SelectedIndexChanged
        reset_jmp_selection()
        If cmb_jmp_script.Text = "Bin Map" Then
            lb_testblocks.Text = "bin_result"

            cmb_jmp_script.Text = "Bin Map"

            cmb_xfactor.Text = "DIE_X"
            cmb_yvalue.Text = "DIE_Y"
            cmb_legend.Text = "TEXT"
            cmb_groupby.Text = "WAFER"
        End If
    End Sub

    Private Sub cmd_add_groupby_Click(sender As Object, e As EventArgs) Handles cmd_add_groupby.Click
        If (cmb_groupby.SelectedIndex > 0) Then
            If lb_groupby.Items.Contains(cmb_groupby.Text) = False Then
                lb_groupby.Items.Add(cmb_groupby.Text)
            End If
        End If

    End Sub

    Private Sub lb_groupby_KeyUp(sender As Object, e As KeyEventArgs) Handles lb_groupby.KeyUp
        If e.KeyCode = Keys.Delete Then
            Do While (lb_groupby.SelectedItems.Count > 0)
                lb_groupby.Items.Remove(lb_groupby.SelectedItem)
            Loop
        End If
    End Sub



    Private Sub txt_wafer_def_KeyUp(sender As Object, e As KeyEventArgs) Handles txt_wafer_def.KeyUp
        g_wafer_def.Item(cmb_wafers.Text) = txt_wafer_def.Text
    End Sub

    Private Sub cmb_wafers_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_wafers.SelectedIndexChanged
        txt_wafer_def.Text = g_wafer_def.Item(cmb_wafers.Text)
    End Sub
End Class
