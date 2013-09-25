Public Class frmLauncher
    Private Sub lblFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblFechar.Click
        Application.Exit()
    End Sub

    Private Sub frmLauncher_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub lblMinimizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblMinimizar.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
End Class
