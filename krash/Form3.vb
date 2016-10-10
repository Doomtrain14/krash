Public Class frm_runscript
    Dim script_files As New List(Of String)
    Dim g_script_input As New Hashtable
    Private Sub frm_runscript_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim perl_path As String = Application.StartupPath & "\scripts\perl"

        Dim dirs As List(Of String) = New List(Of String)(System.IO.Directory.EnumerateDirectories(perl_path))

        g_script_input.Clear()
        script_files.Clear()
        cmb_script.Items.Clear()
        lb_input_files.Items.Clear()
        lbl_version.Text = ""
        txt_description.Text = ""
        For Each folder As String In dirs
            If System.IO.File.Exists(folder & "\_config") Then
                Dim objReader As New System.IO.StreamReader(folder & "\_config")
                Dim strLine As String

                Do While objReader.Peek() <> -1
                    strLine = objReader.ReadLine()
                    If InStr(strLine, "script=", CompareMethod.Binary) > 0 Then
                        Dim script As String = (strLine.Split("="))(1)
                        If (System.IO.File.Exists(folder & "\" & script)) Then
                            If (script_files.Contains(folder & "\" & script) = False) Then
                                script_files.Add(folder & "\" & script)
                                
                            End If
                            If (cmb_script.Items.Contains(folder.Substring(folder.LastIndexOf("\") + 1)) = False) Then
                                cmb_script.Items.Add(folder.Substring(folder.LastIndexOf("\") + 1))
                            End If
                        End If
                    End If
                Loop
                objReader.Close()
            End If
        Next
    End Sub

    Private Sub cmb_script_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_script.SelectedIndexChanged

        Dim parent_dir As String = System.IO.Path.GetDirectoryName(script_files.Item(cmb_script.SelectedIndex))
        If System.IO.File.Exists(parent_dir & "\_description") Then
            txt_description.Text = System.IO.File.ReadAllText(parent_dir & "\_description")
        Else
            txt_description.Text = "No description found"
        End If

        Dim subReader As New System.IO.StreamReader(script_files.Item(cmb_script.SelectedIndex))
        Dim subLine As String
        Do While subReader.Peek() <> -1
            subLine = subReader.ReadLine()
            If InStr(subLine, "$version=", CompareMethod.Binary) > 0 Then
                lbl_version.Text = "Version: " & (subLine.Split("="))(1).Replace("""", "").Replace(";", "")
            End If
        Loop
        subReader.Close()

        cmd_run_script.Enabled = (g_script_input.Count > 0)

    End Sub

    Private Sub gb_main_Enter(sender As Object, e As EventArgs) Handles gb_main.Enter

    End Sub

    Private Sub cmd_open_Click(sender As Object, e As EventArgs) Handles cmd_open.Click
        Dim dg_open As New OpenFileDialog
        dg_open.Multiselect = True
        dg_open.Filter = "Datalog files (*.datalog)|*.datalog|Raw files (*.raw)|*.raw|All files (*.*)|*.*"
        If (dg_open.ShowDialog() = Windows.Forms.DialogResult.Cancel) Then
            Exit Sub
        End If

        For Each file As String In dg_open.FileNames
            Dim m_key As String = System.IO.Path.GetFileName(file)
            If Not g_script_input.ContainsValue(file) Then
                lb_input_files.Items.Add(m_key)
                g_script_input.Add(m_key, file)
            End If
        Next
        cmd_run_script.Enabled = (lb_input_files.Items.Count > 0) And cmb_script.SelectedIndex > -1
    End Sub


    Private Sub lb_input_files_KeyUp(sender As Object, e As KeyEventArgs) Handles lb_input_files.KeyUp

        If e.KeyCode = Keys.Delete Then
            Do While (lb_input_files.SelectedItems.Count > 0)
                g_script_input.Remove(lb_input_files.SelectedItem.ToString)
                lb_input_files.Items.Remove(lb_input_files.SelectedItem)
            Loop
        End If

    End Sub


    Private Sub lb_input_files_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lb_input_files.SelectedIndexChanged
        cmd_run_script.Enabled = (lb_input_files.Items.Count > 0) And cmb_script.SelectedIndex > -1
    End Sub

    Private Sub cmd_run_script_Click(sender As Object, e As EventArgs) Handles cmd_run_script.Click
        Dim string_input As String = ""

        For Each item As DictionaryEntry In g_script_input
            string_input &= """" & item.Value & """ "
        Next


        Dim objWriter As New System.IO.StreamWriter(Application.StartupPath & "\run.bat", False)
        objWriter.WriteLine("cd """ & System.IO.Path.GetDirectoryName(script_files.Item(cmb_script.SelectedIndex)) & """")
        objWriter.WriteLine("""" & script_files.Item(cmb_script.SelectedIndex) & """ " & string_input)
        objWriter.Close()

        System.Threading.Thread.Sleep(500)

        Dim m_proc As New Process
        m_proc.StartInfo.FileName = Application.StartupPath & "\run.bat"
        m_proc.StartInfo.UseShellExecute = True
        m_proc.StartInfo.RedirectStandardOutput = False
        m_proc.StartInfo.WindowStyle = ProcessWindowStyle.Normal

        cmd_run_script.Enabled = False
        cmd_open.Enabled = False
        cmb_script.Enabled = False
        m_proc.Start()
        m_proc.WaitForExit()
        cmd_run_script.Enabled = True
        cmd_open.Enabled = True
        cmb_script.Enabled = True
        m_proc.Dispose()
    End Sub
End Class