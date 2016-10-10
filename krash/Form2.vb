Public Class frm_about

    Private Sub frm_about_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lbl_info.Text = "App Name: Krash" & vbNewLine & "Version: " & Application.ProductVersion & vbNewLine & "Release: 08/15/2016" & vbNewLine & "Email: Ysmael.Ebreo@latticesemi.com"
    End Sub

    Private Sub pic_border_Click(sender As Object, e As EventArgs) Handles pic_border.Click
        Me.Close()
    End Sub

    Private Sub pic_logo_Click(sender As Object, e As EventArgs) Handles pic_logo.Click
        Me.Close()
    End Sub
End Class