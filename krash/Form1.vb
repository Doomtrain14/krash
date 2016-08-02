Imports System.Text.RegularExpressions


Public Class Form1

    Dim g_test_blocks As New Hashtable()
    Dim g_krash_test_blocks As New Hashtable()

    Dim g_input_files As New Hashtable()
    Dim g_curr_input_files As New Hashtable()
    Dim g_curr_filelength As Long
    Dim g_byteread As Long

    Dim g_lot As String
    Dim g_wafer As String
    Dim g_reticle As String
    Dim g_die_x As String
    Dim g_die_y As String
    Dim g_temp As String
    Dim g_test_header As String

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

        cmd_addinput.Enabled = False
        cmd_removeinput.Enabled = False
        bw_extracttests.RunWorkerAsync()

    End Sub

    Private Sub cmd_removeinput_Click(sender As Object, e As EventArgs) Handles cmd_removeinput.Click


        Do While (lb_inputs.SelectedItems.Count > 0)
            g_input_files.Remove(lb_inputs.SelectedItem.ToString)
            lb_inputs.Items.Remove(lb_inputs.SelectedItem)
        Loop

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
                    Dim firstword As String
                    firstword = (strLine.Split(" "))(0)
                    If (String.Compare(firstword, "TNAME") And String.Compare(firstword.Substring(0, 1), "#")) Then
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
        cmd_addinput.Enabled = True
        cmd_removeinput.Enabled = True
    End Sub

    Private Sub cmd_clear_Click(sender As Object, e As EventArgs) Handles cmd_clear.Click
        lb_testblocks.SelectedItems.Clear()
    End Sub

    Private Sub lb_testblocks_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lb_testblocks.SelectedIndexChanged
        lbl_selected_test.Text = lb_testblocks.SelectedItems.Count & " Item(s) selected"
        g_krash_test_blocks.Clear()

        For i = 0 To lb_testblocks.SelectedItems.Count - 1
            If Not g_krash_test_blocks.ContainsKey(lb_testblocks.SelectedItems(i)) Then
                g_krash_test_blocks.Add(lb_testblocks.SelectedItems(i), "1")
            End If
        Next
    End Sub

    Private Sub cmd_krash_Click(sender As Object, e As EventArgs) Handles cmd_krash.Click
        lb_inputs.Enabled = False
        lb_testblocks.Enabled = False
        cmd_addinput.Enabled = False
        cmd_removeinput.Enabled = False
        cmd_krash.Enabled = False
        cmd_clear.Enabled = False


        bw_krash.RunWorkerAsync()


    End Sub

    Private Sub bw_krash_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bw_krash.DoWork
        For Each file As DictionaryEntry In g_input_files
            Dim headerflag As Boolean = False
            If System.IO.File.Exists(file.Value) = True Then
                For Each testblock As DictionaryEntry In g_krash_test_blocks
                    Dim objWriter As New System.IO.StreamWriter(System.IO.Path.GetDirectoryName(file.Value) & "\krash_" & testblock.Key & ".csv", True)
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

                        If strLine.Substring(0, 4) = "#LOT" Then
                            g_lot = (strLine.Split(" "))(1)
                        ElseIf strLine.Substring(0, 5) = "TNAME" Then
                            g_test_header = strLine
                        ElseIf strLine.Substring(0, 5) = "#TEMP" Then
                            g_temp = (strLine.Split(" "))(1)
                        ElseIf strLine.Substring(0, 6) = "#WAFER" Then
                            g_wafer = (strLine.Split(" "))(1)
                        ElseIf strLine.Substring(0, 6) = "#DIE_X" Then
                            g_die_x = (strLine.Split(" "))(1)
                        ElseIf strLine.Substring(0, 6) = "#DIE_Y" Then
                            g_die_y = (strLine.Split(" "))(1)
                        ElseIf strLine.Substring(0, 8) = "#RETICLE" Then
                            g_reticle = (strLine.Split(" "))(1)
                        ElseIf strLine.Length >= testblock.Key.ToString.Length Then
                            If strLine.Substring(0, testblock.Key.ToString.Length) = testblock.Key Then
                                If headerflag = False Then
                                    headerflag = True
                                    objWriter.WriteLine("LOT,WAFER,RETICLE,DIE_X,DIE_Y,TEMP," & g_test_header.Replace(" ", ",").Trim(","))
                                End If
                                objWriter.WriteLine(g_lot & "," & g_wafer & "," & g_reticle & "," & g_die_x & "," & g_die_y & "," & g_temp & "," & strLine.Replace(" ", ",").Trim(","))
                            End If
                        End If

                    Loop

                    objReader.Close()
                    objWriter.Close()
                Next
            End If
        Next
    End Sub

    Private Sub bw_krash_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles bw_krash.ProgressChanged
        sb_status.Text = "Status: Krashing input file(s) - " & e.ProgressPercentage & "%"
    End Sub

    Private Sub bw_krash_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bw_krash.RunWorkerCompleted
        lb_inputs.Enabled = True
        lb_testblocks.Enabled = True
        cmd_addinput.Enabled = True
        cmd_removeinput.Enabled = True
        cmd_krash.Enabled = True
        cmd_clear.Enabled = True

        sb_status.Text = "Status: Idle/Ready"
    End Sub

    Private Sub chk_jmp_CheckedChanged(sender As Object, e As EventArgs) Handles chk_jmp.CheckedChanged
        gb_jmp.Enabled = chk_jmp.Checked
    End Sub
End Class
